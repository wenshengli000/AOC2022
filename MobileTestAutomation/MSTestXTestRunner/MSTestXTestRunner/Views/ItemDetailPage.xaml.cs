using MSTestXTestRunner.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MSTestXTestRunner.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}