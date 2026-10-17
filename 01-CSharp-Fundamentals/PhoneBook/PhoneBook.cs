using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ph_book
{
        internal struct PhoneBook
        {
            string[] Names;
            string[] Numbers;

            /// Number of elements in PhoneBook
            public int Count { get; private set; }

            /// Capacity of PhoneBook
            public int Size { get; private set; }

            // Constructor Chaining
            public PhoneBook() : this(4)
            {
            }

            public PhoneBook(int _size)
            {
                Size = _size < 4 ? 4 : _size;
                Names = new string[Size];
                Numbers = new string[Size];
                Count = 0;
            }

            public void AddContact(string _name, string _number)
            {
                if (Count == Size)
                {
                    Resizing();
                }

                Names[Count] = _name;
                Numbers[Count] = _number;
                Count++;

                Console.WriteLine("Contact Added Successfully");
            }

            public void RemoveContact(string _name)
            {
                // Step 1: Find the contact index
                int index = Array.IndexOf(Names, _name, 0, Count);

                // Step 2: Check if contact exists
                if (index == -1)
                {
                    Console.WriteLine("Contact not found");
                    return;
                }

                // Step 3: Shift elements to the left
                for (int i = index; i < Count - 1; i++)
                {
                    Names[i] = Names[i + 1];
                    Numbers[i] = Numbers[i + 1];
                }

                // Step 4: Clear the last position
                Names[Count - 1] = null;
                Numbers[Count - 1] = null;

                // Step 5: Update count
                Count--;

                Console.WriteLine("Contact Removed Successfully");
            }

            public void SetContact(string _name, string _number)
            {
                // Find the contact index
                int index = Array.IndexOf(Names, _name, 0, Count);

                if (index == -1)
                {
                    Console.WriteLine("Contact not found");
                    return;
                }

                Numbers[index] = _number;
                Console.WriteLine("Contact Set Successfully");
            }

            public string GetContact(string _name)
            {
                int index = Array.IndexOf(Names, _name, 0, Count);

                if (index == -1)
                {
                    return "Contact not found";
                }

                return Numbers[index];
            }

            // Indexer using an integer index
            public string this[int i]
            {
                get
                {
                    if (i < 0 || i >= Count)
                    {
                        Console.WriteLine("Out of range");
                        return string.Empty;
                    }

                    return $"{Names[i]} => {Numbers[i]}";
                }
            }

            // Indexer using a contact name
            public string this[string _name]
            {
                get
                {
                    return GetContact(_name);
                }

                set
                {
                    int index = Array.IndexOf(Names, _name, 0, Count);

                    if (index == -1)
                    {
                        AddContact(_name, value);
                    }
                    else
                    {
                        Numbers[index] = value;
                        Console.WriteLine("Contact Set Successfully");
                    }
                }
            }

            private void Resizing()
            {
                Size *= 2;

                string[] newNames = new string[Size];
                string[] newNumbers = new string[Size];

                Names.CopyTo(newNames, 0);
                Numbers.CopyTo(newNumbers, 0);

                Names = newNames;
                Numbers = newNumbers;
            }
        }
    


}
