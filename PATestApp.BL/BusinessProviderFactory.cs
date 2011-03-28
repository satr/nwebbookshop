using PATestApp.Common;

namespace PATestApp.BL {
    public class BusinessProviderFactory: AbstractFactory {
        public static ILibraryBusinessProvider GetLibraryBusinessProvider() {
            return GetInstance<LibraryBusinessProvider>();
        }
    }
}

