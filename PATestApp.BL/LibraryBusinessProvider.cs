using System.Collections.Generic;
using PATestApp.DAL;
using PATestApp.Entities;

namespace PATestApp.BL{
    public class LibraryBusinessProvider: ILibraryBusinessProvider{
        public List<Book> GetBooks(){
            var dataProvider = DataProviderFactory.GetLibraryDataProvider();
            var books = dataProvider.GetBooks();
            //TODO - change price
            return books;
        }
    }
}