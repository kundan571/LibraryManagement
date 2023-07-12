namespace LibraryManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        Library library = new Library("SchoolLibrary");
        bool menu = true;
        while (menu)
        {
            Console.WriteLine("Enter Menu:");
            Console.WriteLine("Enter 1 to Add Book & Library:");
            Console.WriteLine("Enter 2 to Get Total Books:");
            Console.WriteLine("Enter 3 to Get Available Book:");
            Console.WriteLine("Enter 4 to Get Borrowed Book:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    library.AddLibrary(library);
                    library.AddBook(new Book(1, "The Da Vinci Code", " Dan Brow", "Mystry", true));
                    library.AddBook(new Book(2, "Harry Potter", "J.K Rowling", "Fantsy", true));
                    library.AddBook(new Book(3, "RashmiRathi", "Dinker", "Mythology", true));
                    library.AddBook(new Book(4,"Ramayan","Valmiki","Hindu Mythology", false));
                    break;
                case 2:
                    int totalBooks = library.GetTotalBooks();
                    Console.WriteLine("Total Books: " + totalBooks);
                    break;
                case 3:
                    int getAvailableBooks = library.GetAvailableBook();
                    Console.WriteLine($"Available Books: {getAvailableBooks}");
                    break;
                case 4:
                    int getBorrowedBooks = library.GetBorrowedBook();
                    Console.WriteLine($"Get Borrowed Books: {getBorrowedBooks}");
                    break;
                default:
                    menu = false;
                    break;
            }
        }
    }
}