using System;
using System.Collections.Generic;

namespace LibraryCatalog
{
    class Library
    {
        public string Name { get; set; }
        public string Address { get; set; }
        private List<Book> Books;
        private List<MediaItem> MediaItems;

        public Library(string name, string address)
        {
            Name = name;
            Address = address;
            Books = new List<Book>();
            MediaItems = new List<MediaItem>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (Books.Contains(book))
            {
                Books.Remove(book);
            }
            else
            {
                Console.WriteLine("The book you are trying to remove is not in the Library.");
            }
        }

        public void AddMediaItem(MediaItem item)
        {
            MediaItems.Add(item);
        }

        public void RemoveMediaItem(MediaItem item)
        {
            if (MediaItems.Contains(item))
            {
                MediaItems.Remove(item);
            }
            else
            {
                Console.WriteLine("The item you are trying to remove is not in the MediaItems.");
            }
        }

        public void PrintCatalog()
        {
            Console.WriteLine("Books:");
            foreach (Book book in Books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("Media Items:");
            foreach (MediaItem mediaItem in MediaItems)
            {
                Console.WriteLine(mediaItem);
            }
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }

        public Book(string title, string author, string isbn, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
        }

        public override string ToString()
        {
            return $"{Title} written by {Author} in ({PublicationYear})";
        }
    }

    class MediaItem
    {
        public string Title { get; set; }
        public string MediaType { get; set; }
        public int Duration { get; set; }

        public MediaItem(string title, string mediaType, int duration)
        {
            Title = title;
            MediaType = mediaType;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{Title} ({MediaType}, {Duration} )";
        }
    }

    class Program
    {
        static void Main()
        {
            Library lib = new Library("Abrehot", "Addis Ababa");
            Book book1 = new Book("Random Book", "Random Author", "pdo", 1879);
            lib.AddBook(book1);
            MediaItem mediaItem1 = new MediaItem("Some Title", "Some Type", 45);
            lib.AddMediaItem(mediaItem1);

            lib.PrintCatalog();
        }
    }
}
