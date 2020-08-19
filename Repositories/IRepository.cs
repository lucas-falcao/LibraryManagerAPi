using System.Collections.Generic;
using Models;

namespace Repositories
{
    public interface IRepository
    {
        IEnumerable<Book> GetAll();
        Book GetBook(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);

    }
}