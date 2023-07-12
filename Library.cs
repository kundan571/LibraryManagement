using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryManagementSystem;

public class Library
{
    private string connectionString = "Data Source=KUNDAN;Initial Catalog=LibraryManagementDB;Integrated Security=True;";

    public string Name { get; set; }

    public Library(string name)
    {
        this.Name = name;
    }

    public void AddBook(Book book)
    {
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using(SqlCommand command = new SqlCommand("AddBook",connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", book.BookId);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@IsBorrowed", book.IsBorrowed);
                command.ExecuteNonQuery();
            }
        }
    }

    public void AddLibrary(Library library)
    {
        using(SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using(SqlCommand command =new SqlCommand("AddLibrary",conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", library.Name);
                command.ExecuteNonQuery();
            }
        }
    }

    public int GetTotalBooks()
    {
        using(SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            using(SqlCommand command = new SqlCommand("GetTotalBooks",con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                return (int)command.ExecuteScalar();
            }
        }
    }

    public int GetAvailableBook()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            using (SqlCommand command = new SqlCommand("GetAvailableBooks", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                return (int)command.ExecuteScalar();
            }
        }
    }

    public int GetBorrowedBook()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            using (SqlCommand command = new SqlCommand("GetBorrowedBooks", con))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                return (int)command.ExecuteScalar();
            }
        }
    }

    public Book GetBooksByAuthor(string authorName)
    {
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using(SqlCommand command= new SqlCommand("GetBooksByAuthor",connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Author", authorName);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        int bookId = (int)reader["BookId"];
                        string title = (string)reader["Title"];
                        string author = (string)reader["Author"];
                        string genre = (string)reader["Genre"];
                        bool isBorrowed = (bool)reader["IsBorrowed"];

                        Book book = new Book(bookId, title, author,genre,isBorrowed);
                        PrintBook(book);
                    }
                    else
                    {
                        Console.WriteLine("There is no such book Exist for this Author:");
                    }
                }
            }
        }
        return null;
    }

    public void PrintBook(Book book)
    {
        if (book != null)
        {
            Console.WriteLine($"Book Id: {book.BookId}");
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"Genre: {book.Genre}");
            Console.WriteLine($"IsBorrowed: {book.IsBorrowed}");
        }
        else
        {
            Console.WriteLine("There is no such Book: ");
        }
    }

    public Book GetBooksByGenre(string genreName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("GetBooksByGenre", connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Genre", genreName);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        int bookId = (int)reader["BookId"];
                        string title = (string)reader["Title"];
                        string author = (string)reader["Author"];
                        string genre = (string)reader["Genre"];
                        bool isBorrowed = (bool)reader["IsBorrowed"];

                        Book book = new Book(bookId, title, author, genre, isBorrowed);
                        PrintBook(book);
                    }
                    else
                    {
                        Console.WriteLine("There is no such book Exist for this Author:");
                    }
                }
            }
        }
        return null;
    }
}
