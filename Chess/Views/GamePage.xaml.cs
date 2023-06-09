using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
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
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();
            ChessGame.BlackKilled += OnBlackKilled;
            ChessGame.WhiteKilled += OnWhiteKilled;
        }

        private void OnBlackKilled(object sender, EventArgs e)
        {
            blackKilledWrap.Children.Add(GetKilledFigure(sender));
        }

        private void OnWhiteKilled(object sender, EventArgs e)
        {
            
            whiteKilledWrap.Children.Add(GetKilledFigure(sender));
        }

        private Image GetKilledFigure(object sender)
        {
            string path = ChessConverter.ConvertFigureToSource(sender as IFigure);
            Image killedFigure = new Image()
            {
                Height = 25,
                Width = 25,
                Source = new BitmapImage(new Uri($"/Images/{path}.png", UriKind.Relative))
            };
            return killedFigure;
        }
    }
}
