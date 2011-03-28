namespace WebApp {
    public class Presenter {
        public IView View { get; set; }

        public Presenter(IView view){
            View = view;
        }

        public void LoadData(){
            var libraryProvider = PATestApp.BL.BusinessProviderFactory.GetLibraryBusinessProvider();
            View.RefreshView(libraryProvider.GetBooks());
        }
    }
}
