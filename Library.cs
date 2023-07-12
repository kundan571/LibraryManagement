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
}
