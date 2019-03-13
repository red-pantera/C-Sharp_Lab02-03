using System.Windows;
using Zhenchak03.ViewModels;

namespace Zhenchak03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(PersonInfoGrid);
        }
    }
}

