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
            Console.WriteLine("Enter 1 to Add Book:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    library.AddBook(new Book(1, "The Da Vinci Code", " Dan Brow", "Mystry", true));
                    library.AddBook(new Book(2, "Harry Potter", "J.K Rowling", "Fantsy", true));
                    library.AddBook(new Book(3, "RashmiRathi", "Dinker", "Mythology", true));
                    break;
                default:
                    menu = false;
                    break;
            }
        }
    }
}