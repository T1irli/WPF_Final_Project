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

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Image selectedFigure = null;
        private System.Drawing.Point startPos;
        private Grid startGrid = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FillGameboard()
        {
            for(int i = 0; i < 10; i++)
            {
                gameboardGrid.RowDefinitions.Add(new RowDefinition());
                gameboardGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            gameboardGrid.RowDefinitions[0].Height = new GridLength(0.4, GridUnitType.Star);
            gameboardGrid.ColumnDefinitions[0].Width = new GridLength(0.4, GridUnitType.Star);
            gameboardGrid.RowDefinitions[9].Height = new GridLength(0.4, GridUnitType.Star);
            gameboardGrid.ColumnDefinitions[9].Width = new GridLength(0.4, GridUnitType.Star);

            for (int i = 1; i < 9; i++)
            {
                for(int j = 1; j < 9; j++)
                {
                    var grid = new Grid() { 
                        Background =  new SolidColorBrush(((i + j) % 2 == 0? 
                        Color.FromArgb(255, 238, 238, 238) : Color.FromArgb(255, 122, 62, 62)))
                    };
                    grid.MouseEnter += (s, e) =>
                    {
                        if (selectedFigure != null)
                        {
                            grid.Children.Clear();
                            tempCanvas.Children.Remove(selectedFigure);
                            
                            var endPos = new System.Drawing.Point(Grid.GetColumn(grid) - 1, Grid.GetRow(grid) - 1);
                            if (ChessGame.CanMove(startPos, endPos))
                            {
                                grid.Children.Add(selectedFigure);
                                ChessGame.Move(startPos, endPos);
                            }
                            else
                                startGrid.Children.Add(selectedFigure);

                            RefreshBoard();
                            startGrid = null;
                            selectedFigure = null;
                        }
                    };
                    
                    gameboardGrid.Children.Add(grid);
                    Grid.SetColumn(grid, j);
                    Grid.SetRow(grid, i);
                }
            }

            for(int i = 1; i < 9; i++)
            {
                var textNum = new TextBlock() { Text = i.ToString() };
                var textLetter = new TextBlock() { Text = ((char)('a' + (i - 1))).ToString() };
                gameboardGrid.Children.Add(textNum);
                Grid.SetRow(textNum, 9 - i);
                Grid.SetColumn(textNum, 0);
                gameboardGrid.Children.Add(textLetter);
                Grid.SetRow(textLetter, 0);
                Grid.SetColumn(textLetter, i);
            }
        }

        private void RefreshBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    (gameboardGrid.Children[i * 8 + j] as Grid).Background = new SolidColorBrush(((i + j) % 2 == 0 ?
                        Color.FromArgb(255, 238, 238, 238) : Color.FromArgb(255, 122, 62, 62)));
                }
            }
        }

        private void SetFigures()
        {
            Image image = new Image()
            {
                Margin = new Thickness(10),
                Source = new BitmapImage(new Uri("/Images/pawn.png", UriKind.Relative))
            };
            Image image2 = new Image()
            {
                Margin = new Thickness(10),
                Source = new BitmapImage(new Uri("/Images/knight.png", UriKind.Relative))
            };
            Image image3 = new Image()
            {
                Margin = new Thickness(10),
                Source = new BitmapImage(new Uri("/Images/bishop.png", UriKind.Relative))
            };
            image.MouseDown += FigureMouseDown;
            image2.MouseDown += FigureMouseDown;
            image3.MouseDown += FigureMouseDown;

            // Test
            (gameboardGrid.Children[6 * 8 + 3] as Grid).Children.Add(image);
            (gameboardGrid.Children[4 * 8 + 4] as Grid).Children.Add(image2);
            (gameboardGrid.Children[1 * 8 + 2] as Grid).Children.Add(image3);
        }

        private void FigureMouseDown(object sender, MouseEventArgs e)
        {
            startGrid = (sender as Image).Parent as Grid;
            startPos = new System.Drawing.Point(Grid.GetColumn((sender as Image).Parent as Grid) - 1,
                Grid.GetRow((sender as Image).Parent as Grid) - 1);
            var points = ChessGame.GetMoves(startPos);
            foreach (var p in points)
            {
                (gameboardGrid.Children[(p.Y) * 8 + p.X] as Grid).Background = Brushes.Yellow;
            }

            selectedFigure = (sender as Image);

            Panel.SetZIndex(tempCanvas, 1);
            (selectedFigure.Parent as Grid).Children.Clear();
            tempCanvas.Children.Add(selectedFigure);
            Canvas.SetLeft(selectedFigure, Math.Abs(e.GetPosition(tempCanvas).X - 10));
            Canvas.SetTop(selectedFigure, Math.Abs(e.GetPosition(tempCanvas).Y - 10));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillGameboard();
            SetFigures();
            ChessGame.StartGame();
        }

        private void tempCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedFigure == null) return;
            Canvas.SetLeft(selectedFigure, Math.Abs(e.GetPosition(tempCanvas).X - 10));
            Canvas.SetTop(selectedFigure, Math.Abs(e.GetPosition(tempCanvas).Y - 10));
        }

        private void tempCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (selectedFigure == null) return;
            Panel.SetZIndex(tempCanvas, -1);
        }
    }
}
