using System;
using Models;
using Dapper;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using System.Data.SqlClient;
using System.Linq;

namespace Repositories
{
    public class Repository : IRepository
    {
        private readonly IConfiguration configuration;
        private string conexao()
        {
            return configuration.GetSection("ConnectionStrings").GetSection("connectionLib").Value;
        }
        public Repository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void AddBook(Book book)
        {
            using (var serve = new SqlConnection(conexao()))
            {
                try
                {
                    serve.Open();
                    var QueryStr = "INSERT INTO Livros(Title, Author, Summary) VALUES(@Title, @Author, @Summary); " +
                    "SELECT CAST(SCOPE_IDENTITY() as INT);";
                    var count = serve.Execute(QueryStr, book);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }
                finally
                {
                    serve.Close();
                }

            }
        }

        public void DeleteBook(int id)
        {
            using (var serve = new SqlConnection(conexao()))
            {
                try
                {
                    serve.Open();
                    var queryStr = "DELETE FROM Livros WHERE Id =" + id;
                    var count = serve.Execute(queryStr);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }
                finally
                {
                    serve.Close();
                }

            }
        }

        public IEnumerable<Book> GetAll()
        {
            IEnumerable<Book> books = new List<Book>();
            using (var serve = new SqlConnection(conexao()))
            {
                try
                {
                    serve.Open();
                    var queryStr = "SELECT * FROM LIVROS";
                    books = serve.Query<Book>(queryStr).ToList();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }
                finally
                {
                    serve.Close();
                }
                return books;
            }
        }

        public Book GetBook(int id)
        {
            Book book = new Book();
            using (var serve = new SqlConnection(conexao()))
            {
                try
                {
                    serve.Open();
                    var queryStr = "SELECT * FROM Livros WHERE Id =" + id;
                    book = serve.Query<Book>(queryStr).FirstOrDefault();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }
                finally
                {
                    serve.Close();
                }
                return book;

            }
        }
        public void UpdateBook(Book book)
        {
            using (var serve = new SqlConnection(conexao()))
            {
                try
                {
                    serve.Open();
                    var queryStr = "UPDATE Livros SET Title = @Title, Author = @Author, Summary = @Summary " +
                    "WHERE Id = @Id";
                    var count = serve.Execute(queryStr, book);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                }
                finally
                {
                    serve.Close();
                }

            }
        }
    }
}