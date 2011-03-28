using PATestApp.Common;

namespace PATestApp.DAL {
    public class DataProviderFactory: AbstractFactory {
        public static ILibraryDataProvider GetLibraryDataProvider(){
            return GetInstance<LibraryDataProvider>();
        }
    }
}
