using System.Windows;
using ViewModel;

namespace View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.DataContext = new MainVM();
        InitializeComponent();
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        ((MainVM)this.DataContext).SaveStatusCommand.Execute(null);
    }
}