using System.Collections.Generic;
using PATestApp.Entities;

namespace PATestApp.BL{
    public interface ILibraryBusinessProvider : IBusinessProvider {
        List<Book> GetBooks();
    }
}