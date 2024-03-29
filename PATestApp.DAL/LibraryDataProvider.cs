﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using PATestApp.Entities;

namespace PATestApp.DAL {
    public class LibraryDataProvider : ILibraryDataProvider {
        
        const string BOOK_FILE_NAME = "books.xml";
        
        private static class BookProperties {
            public const string Book = "book";
            public const string Authors = "authors";
            public const string ISBN = "isbn";
            public const string Title = "title";
            public const string Price = "price";
            public const string PublishedYear = "publishedyear";
        }

        public List<Book> GetBooks(){
//            List<Book> books = GetTestBooks();
            List<Book> books = GetBooksFromXml();

            return books;
        }

        private List<Book> GetBooksFromXml(){
            var books = new List<Book>();
            var document = new XmlDocument();
            var assemblyPath = Assembly.GetExecutingAssembly().CodeBase.Substring(8).Replace('/', '\\');
            var dataFilePath = new FileInfo(assemblyPath).DirectoryName?? string.Empty;
            var fileInfo = new FileInfo(Path.Combine(dataFilePath, BOOK_FILE_NAME));
            if (!fileInfo.Exists){
                Debug.Fail("File with books not exist");
                return books;
            }
            using (FileStream stream = fileInfo.OpenRead()) {
                document.Load(stream);
                books = LoadBooks(document.DocumentElement.GetElementsByTagName(BookProperties.Book));
            }
            return books;
        }

        private List<Book> LoadBooks(XmlNodeList nodes) {
            var books = new List<Book>();
            if (nodes == null)
                return books;
            foreach (XmlNode node in nodes) {
                var book = new Book();
                book.ISBN = GetValueFor(node, BookProperties.ISBN);
                book.Title = GetValueFor(node, BookProperties.Title);
                book.Price = GetNumValueFor(node, BookProperties.Price);
                book.PublishedYear = GetIntValueFor(node, BookProperties.PublishedYear);
                book.Authors = LoadAuthors(node);
                books.Add(book);
            }
            return books;
        }

        private List<string> LoadAuthors(XmlNode parentNode) {
            var authors = new List<string>();
            if (parentNode == null)
                return authors;
            var authorNode = parentNode.SelectSingleNode(BookProperties.Authors);
            if (authorNode == null)
                return authors;
            foreach (XmlNode node in authorNode.ChildNodes)
                authors.Add(node.InnerText);
            return authors;
        }

        private int GetIntValueFor(XmlNode node, string name){
            var value = GetValueFor(node, name);
            int intValue;
            return int.TryParse(value, out intValue) ? intValue : 0;
        }

        private decimal GetNumValueFor(XmlNode node, string name){
            var value = GetValueFor(node, name);
            decimal numValue;
            var formatter = new CultureInfo("en-US");
            formatter.NumberFormat.CurrencyDecimalSeparator = ".";
            var valueFor = decimal.TryParse(value, NumberStyles.Currency, formatter, out numValue)? numValue: 0m;
            return valueFor;
        }

        private string GetValueFor(XmlNode node, string nodeName){
            var targetNode = node.SelectSingleNode(nodeName);
            return targetNode != null ?targetNode.InnerText: string.Empty;
        }

/*
        private List<Book> GetTestBooks(){
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
*/
    }
}
