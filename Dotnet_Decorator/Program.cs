using System;
using System.Collections;
using System.Collections.Generic;

namespace Dotnet_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("J.K. Rowling", "Harry Potter", 10);
            book.Display();

            var borrow = new Borrowable (book);
            borrow.BorrowItem("Rashif");
            borrow.BorrowItem("Rama");
            borrow.BorrowItem("Nadya");
            borrow.BorrowItem("Hanna");
            borrow.BorrowItem("Nugi");
            borrow.BorrowItem("Mia");
            borrow.Display();
        }
    }

    abstract class LibraryItem
    {
        ////Properties kalo dijabarkan
        //private int _numCopies;

        //public int NumCopies
        //{
        //    get { return _numCopies; }
        //    set { _numCopies = value; }
        //}

        //Properties yang lebih singkat
        public int NumCopies { get; set; }

        public abstract void Display();
    }

    class Book : LibraryItem
    {
        private string _author;
        private string _title;

        public Book(string author, string title, int numCopies)
        {
            _author = author;
            _title = title;
            this.NumCopies = numCopies;
        }
      
        public override void Display()
        {
            Console.WriteLine("Book:");
            Console.WriteLine($"Author : {_author}");
            Console.WriteLine($"Title : {_title}");
            Console.WriteLine($"Number of Copies : {NumCopies} \n");
        }
    }

    class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;

        public Decorator(LibraryItem library)
        {
            libraryItem = library;
        }


        public override void Display()
        {
            libraryItem.Display();
        }
    }

    class Borrowable : Decorator
    {
        protected List<string> borrowers = new List<string>();

        public Borrowable(LibraryItem library) : base(library)
        {
            
        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }

        public override void Display()
        {
            base.Display();

            foreach(string borrower in borrowers)
            {
                Console.WriteLine("borrower: " + borrower);
            }
        }

        /* kalo abstract class, cuma bisa pake 1 (1 class hanya punya 1 abstract class)
         * kalo interface bisa pake lebih dari 1 (1 class bisa punya lebih dari 1 interface)
         * 
        */
    }
}
