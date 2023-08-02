using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment11_2
{
    interface CRUD
    {
        void AddRecord(BooksDB book);
        void DeleteRecord(BooksDB book);
        ICollection<BooksDB> GetAll();
        BooksDB FindBook(int ISBN);
        void UpdateRecord(int ISBN,BooksDB book);
    }

    class BookRepository : CRUD
    {
        BooksEntities entities;
        public BookRepository()
        {
            entities = new BooksEntities();
        }
        public void AddRecord(BooksDB book)
        {
            entities.BooksDBs.Add(book);
            entities.SaveChanges();
        }

        public void DeleteRecord(BooksDB book)
        {
            entities.BooksDBs.Remove(book);
            entities.SaveChanges();
        }

        public BooksDB FindBook(int ISBN)
        {
            return entities.BooksDBs.Find(ISBN);
        }

        public ICollection<BooksDB> GetAll()
        {
            return entities.BooksDBs.ToList();
        }

        public void UpdateRecord(int ISBN,BooksDB book)
        {
            var bookToUpdate = entities.BooksDBs.Find(ISBN);
            bookToUpdate.ISBN = book.ISBN;
            bookToUpdate.Author_Name = book.Author_Name;
            bookToUpdate.Title = book.Title;
            bookToUpdate.Description = book.Description;
            entities.SaveChanges();
        }
    }
}
