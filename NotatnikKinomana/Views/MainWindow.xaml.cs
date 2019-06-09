using NotatnikKinomana.ViewModel;
using System.Windows;

namespace NotatnikKinomana
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IDialogService dialogService = new DialogService(this);

            dialogService.Register<LoginViewModel, Login>();
            dialogService.Register<RejestracjaViewModel, Rejestracja>();
            dialogService.Register<RecenzjaViewModel, NowaRecenzja>();

            var viewModel = new MainWindowViewModel();
            viewModel.dialogService = dialogService;
            viewModel.CurrentView = new ListaFilmowView(null, null);
            this.DataContext = viewModel;
            this.Show();
            if (viewModel.Uzytkownik == null)
            {
                viewModel.PokazLogowanieCommand.Execute(null);
            }
        }

        private void UserImage_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((MainWindowViewModel)this.DataContext).PokazUzytkownikaCommand.Execute(null);
        }
    }
}
