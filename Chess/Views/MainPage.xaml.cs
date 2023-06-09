using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private int gameTime = 15;

        public MainPage()
        {
            InitializeComponent();
        }

        private void upNum_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            gameTime = Math.Min(gameTime + 5, 30);
            timeTextBlock.Text = $"{gameTime} min";
        }

        private void downNum_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            gameTime = Math.Max(gameTime - 5, 5);
            timeTextBlock.Text = $"{gameTime} min";
        }
    }
}
