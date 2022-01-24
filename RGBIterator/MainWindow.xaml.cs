using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace RGBIterator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Iterator iterator;

        public MainWindow()
        {
            InitializeComponent();

            iterator = Iterator.getIterator();
        }

        private void MainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainGrid.Background = new SolidColorBrush(iterator.Next());
        }
    }
}
