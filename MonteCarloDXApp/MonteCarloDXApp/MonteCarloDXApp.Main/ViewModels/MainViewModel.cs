using DevExpress.Mvvm.POCO;

namespace MonteCarloDXApp.Main.ViewModels
{
    public class MainViewModel
    {
        public static MainViewModel Create()
        {
            return ViewModelSource.Create(() => new MainViewModel());
        }
    }
}
