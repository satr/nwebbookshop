using System;

namespace WebApp {
    public partial class _Default : System.Web.UI.Page, IView {
        private Presenter _presenter;

        protected void Page_Load(object sender, EventArgs e){
            _presenter = new Presenter(this);
        }

        protected void buttonRefresh_Click(object sender, EventArgs e){
            _presenter.LoadData();
        }

        public void RefreshView(object dataSource){
            gridView.DataSource = dataSource;
            gridView.DataBind();
        }
    }
}
