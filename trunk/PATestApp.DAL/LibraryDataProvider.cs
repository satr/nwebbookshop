using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PATestApp.Entities;

namespace PATestApp.DAL {
    public class LibraryDataProvider : ILibraryDataProvider {
        public List<Book> GetBooks(){
            var books = new List<Book>();
            books.Add(GetBook(0, "Title1", 12.3m));
            books.Add(GetBook(3, "Title2", 22.4m));
            books.Add(GetBook(5, "Title3", 32.5m));

            return books;
        }

        private Book GetBook(int set, string title, decimal price){
            var book = new Book();
            book.Authors.Add("Auth 1");
            book.Authors.Add("Auth 2");
            book.Title = title;
            book.ISBN = "isbn1";
            book.Price = price;
            book.PublishedYear = DateTime.Now.Year - set;
            return book;
        }
    }
}
