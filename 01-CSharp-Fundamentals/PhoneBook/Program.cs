namespace ph_book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBook book = new PhoneBook();

            // Add contacts using the string indexer
            book["Ahmed"] = "01012345678";
            book["Mohamed"] = "01112345678";
            book["Ali"] = "01212345678";
            book["Omar"] = "01512345678";
            book["Sara"] = "01098765432";

            Console.WriteLine("\n--- All Contacts ---");

            // Display all contacts using the integer indexer
            for (int i = 0; i < book.Count; i++)
            {
                Console.WriteLine(book[i]);
            }

            // Search for a contact
            Console.WriteLine("\n--- Search Contact ---");
            Console.WriteLine($"Ahmed's Number: {book["Ahmed"]}");

            // Update a contact
            Console.WriteLine("\n--- Update Contact ---");
            book.SetContact("Ahmed", "01099999999");
            Console.WriteLine($"Ahmed's New Number: {book["Ahmed"]}");

            // Add a contact using AddContact
            Console.WriteLine("\n--- Add Contact ---");
            book.AddContact("Khaled", "01155555555");

            // Remove a contact
            Console.WriteLine("\n--- Remove Contact ---");
            book.RemoveContact("Mohamed");

            // Display contacts after removal
            Console.WriteLine("\n--- Contacts After Removal ---");

            for (int i = 0; i < book.Count; i++)
            {
                Console.WriteLine(book[i]);
            }

            // Display PhoneBook information
            Console.WriteLine("\n--- PhoneBook Information ---");
            Console.WriteLine($"Contacts Count: {book.Count}");
            Console.WriteLine($"PhoneBook Size: {book.Size}");
        }
    }
    }
}
