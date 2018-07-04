using System;

namespace Iterator
{
    public class Book
    {
        private string name;

        public Book(string inName)
        {
            name = inName;
        }

        public string GetName()
        {
            return name;
        }
    }

    public interface Iterator
    {
        bool HasNext();
        object Next();
    }

    public interface Aggregate
    {
        Iterator iterator();
    }

    public class BookShelfIterator : Iterator
    {
        private BookShelf bookShelf;
        private int index;

        public BookShelfIterator(BookShelf inBookShelf)
        {
            this.bookShelf = inBookShelf;
            this.index = 0;
        }

        public bool HasNext()
        {
            return index < bookShelf.GetLength();
        }

        public object Next()
        {
            Book book = bookShelf.GetBookAt(index);
            index++;
            return book;
        }
    }

    public class BookShelf : Aggregate
    {
        private Book[] books;
        private int last = 0;

        public BookShelf(int inIndex)
        {
            this.books = new Book[inIndex];
        }

        public Book GetBookAt(int index)
        {
            return books[index];
        }

        public void AddBook(Book inBook)
        {
            this.books[last] = inBook;
            last++;
        }

        public int GetLength()
        {
            return last;
        }

        public Iterator iterator()
        {
            return new BookShelfIterator(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BookShelf bookShelf = new BookShelf(5);

            bookShelf.AddBook(new Book("자바 디자인 패턴"));
            bookShelf.AddBook(new Book("자바의 정석"));
            bookShelf.AddBook(new Book("jsp/servlet 3.0"));
            bookShelf.AddBook(new Book("데이터베이스"));

            Iterator it = bookShelf.iterator();

            while (it.HasNext())
            {
                Book books = (Book)it.Next();
                Console.Write(books.GetName());
            }
        }
    }
}
