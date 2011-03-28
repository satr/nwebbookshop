using System.Collections.Generic;
using PATestApp.Entities;

namespace PATestApp.DAL{
    public interface ILibraryDataProvider: IDataProvider{
        List<Book> GetBooks();
    }
}