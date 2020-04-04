using ShowDynamicData.ViewModels;
using Xamarin.Forms;


namespace ShowDynamicTableData.Views
{    
    public partial class EmployeeDetailsPage : ContentPage
    {
        public EmployeeDetailsPage()
        {
            InitializeComponent();
            this.BindingContext = new EmployeeDetailsViewModel();
        }
    }
}