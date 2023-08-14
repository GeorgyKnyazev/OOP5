using System;
using System.Collections.Generic;


namespace OOP5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ConsoleKey CreateBookInMenu = ConsoleKey.D1;
            const ConsoleKey DeleteBookInMenu = ConsoleKey.D2;
            const ConsoleKey ShowAllBooksInMenu = ConsoleKey.D3;
            const ConsoleKey FindBookInMenu = ConsoleKey.D4;
            const ConsoleKey ExitInMenu = ConsoleKey.D5;

            bool isWork = true;

            Library library = new Library();

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Для добавления книги нажмите: {CreateBookInMenu}");
                Console.WriteLine($"Для удаления книги нажмите: {DeleteBookInMenu}");
                Console.WriteLine($"Для просмотра всех книг нажмите: {ShowAllBooksInMenu}");
                Console.WriteLine($"Для поиска книги нажмите: {FindBookInMenu}");
                Console.WriteLine($"Для выхода нажмите: {ExitInMenu}");

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

                switch (consoleKeyInfo.Key)
                {
                    case CreateBookInMenu:
                        library.CreateBook();
                        break;
                    case DeleteBookInMenu:
                        library.DeleteBook();
                        break;
                    case ShowAllBooksInMenu:
                        library.ShowAllBook();
                        break;
                    case FindBookInMenu:
                        library.FindBook();
                        break;
                    case ExitInMenu:
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Book 
    {
        public Book(int index, string title, string author , int year)
        {
            Title = title;
            Author = author;
            Year = year;
            Index = index;
        }

        public string Title { get; private set; } 
        public string Author { get; private set; }
        public int Year { get; private set; }
        public int Index { get; private set; }
    }

    class Library
    {
        private int _bookIndex = 0;
        private List<Book> _books = new List<Book>();

        public void CreateBook()
        {
            Console.Clear();

            string titleTextInMenu = "Введите название книги: ";
            string authorTextInMenu = "Введите автора книги: ";
            string yearTextInMenu = "Введите год выпуска книги: ";

            string title = GetString(titleTextInMenu);
            string author = GetString(authorTextInMenu);
            int year = GetYear(yearTextInMenu);

            AddBook(title, author, year);
        }

        public void ShowAllBook()
        {
            Console.Clear();

            foreach (Book book in _books)
            {
                Console.WriteLine(book.Index + " " + book.Title + " " + book.Author + " " + book.Year);
            }

            Console.ReadKey();
        }

        public void FindBook()
        {
            const ConsoleKey TitleFindInMenu = ConsoleKey.D1;
            const ConsoleKey AuthorFindInMenu = ConsoleKey.D2;
            const ConsoleKey YearFindInMenu = ConsoleKey.D3;

            Console.Clear();
            Console.WriteLine($"Для поиска по названию нажмите: {TitleFindInMenu}");
            Console.WriteLine($"Для поиска по автору нажмите: {AuthorFindInMenu}");
            Console.WriteLine($"Для поиску по году издания нажмите: {YearFindInMenu}");

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            switch ( consoleKeyInfo.Key )
            {
                case TitleFindInMenu:
                    SearchTitle();
                    break;
                case AuthorFindInMenu:
                    SearchAuthor();
                    break;
                case YearFindInMenu:
                    SearchYear();
                    break;
            }

            Console.ReadKey();
        }

        public void DeleteBook()
        {
            string deleteBookText = "Введите индекс книги для удаления: ";

            Console.Clear();
            ShowAllBook();

             int index = TakeNumber(deleteBookText);
            
            foreach (Book book in _books)
            {
                if ( book.Index == index)
                {
                    _books.Remove(book);
                    break;
                }
            }
        }

        private void SearchTitle()
        {
            bool isBookSearch = false;

            Console.Clear();
            Console.Write("Введите название книги, которую хотите найти: ");

            string userInput = Console.ReadLine();

            foreach (Book book in _books)
            {
                if(book.Title.ToLower() == userInput.ToLower())
                {
                    Console.WriteLine(book.Title + " " + book.Author + " " + book.Year);
                    isBookSearch = true;
                }
            }

            if (isBookSearch == false)
            {
                Console.WriteLine("Книга с таким названием не найдена");
            }

            Console.ReadKey();
        }

        private void SearchAuthor()
        {
            bool isBookSearch = false;

            Console.Clear();
            Console.Write("Введите автора книги, которую хотите найти: ");

            string userInput = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (book.Author.ToLower() == userInput.ToLower())
                {
                    Console.WriteLine(book.Title + " " + book.Author + " " + book.Year);
                    isBookSearch = true;
                }
            }

            if (isBookSearch == false)
            {
                Console.WriteLine("Книга с таким автором не найдена");
            }

            Console.ReadKey();
        }

        private void SearchYear()
        {
            bool isBookSearch = false;
            string searhBookYear = "Введите год издания";
            
            Console.Clear();

            int year = TakeNumber(searhBookYear);

            foreach (Book book in _books)
            {
                if (book.Year == year)
                {
                    Console.WriteLine(book.Title + " " + book.Author + " " + book.Year);
                    isBookSearch = true;
                }
            }

            if (isBookSearch == false)
            {
                Console.WriteLine("Книга с таким годом не найдена");
            }

            Console.ReadKey();
        }

        private string GetString(string text)
        {
            Console.Write(text);
            string userInput = Console.ReadLine();

            return userInput;
        }

        private int GetYear(string text)
        {
            bool result = false;
            int number = -1;

            while (result == false)
            {
                Console.Write(text);

                string userInput = Console.ReadLine();
                result = int.TryParse(userInput, out number);

                if (result == false)
                {
                    Console.WriteLine("Вы ввели неправильное значение");
                    Console.ReadKey();
                }
            }

            return number;
        }

        private void AddBook(string title, string author, int year)
        {
            _bookIndex++;
            Book book = new Book(_bookIndex, title, author, year);
            _books.Add(book);
        }

        private int TakeNumber(string text)
        {
            bool result = false;
            int number = 0;

            while (result == false)
            {
                Console.Write(text);

                string userInput = Console.ReadLine();
                result = int.TryParse(userInput, out number);

                if (result == false)
                {
                    Console.WriteLine("Вы ввели неправильное значение");
                    Console.ReadKey();
                }
            }

            return number;
        }
    }
}
