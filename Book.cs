using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsBorrowed { get; set; }

    public Book(int bookId, string title, string author, string genre, bool isBorrowed) 
    { 
        this.BookId = bookId;
        this.Title = title;
        this.Author = author;
        this.Genre = genre;
        this.IsBorrowed = isBorrowed;
    }

    public override string ToString()
    {
        return $"Book Id: {BookId}, Title: {Title}, Author: {Author}, Genre: {Genre}, IsBorrowed: {IsBorrowed}";
    }
}
