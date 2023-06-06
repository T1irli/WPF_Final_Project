using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private int gameTime = 15;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FillGameboard()
        {
            for (int i = 0; i < 10; i++)
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
                for (int j = 1; j < 9; j++)
                {
                    var grid = new Grid() {
                        Background = new SolidColorBrush(((i + j) % 2 == 0 ?
                        Color.FromArgb(255, 238, 238, 238) : Color.FromArgb(255, 122, 62, 62))),
                    };

                    grid.MouseEnter += gridMouseEnter;

                    gameboardGrid.Children.Add(grid);
                    Grid.SetColumn(grid, j);
                    Grid.SetRow(grid, i);
                }
            }

            for (int i = 1; i < 9; i++)
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

        private void gridMouseEnter(object sender, MouseEventArgs e)
        {
            if (selectedFigure != null)
            {
                tempCanvas.Children.Remove(selectedFigure);

                var endPos = new System.Drawing.Point(Grid.GetColumn((sender as Grid)) - 1, Grid.GetRow((sender as Grid)) - 1);
                if (ChessGame.CanMove(startPos, endPos))
                {
                    (sender as Grid).Children.Clear();
                    (sender as Grid).Children.Add(selectedFigure);
                    ChessGame.Move(startPos, endPos);
                }
                else
                {
                    startGrid.Children.Add(selectedFigure);
                }

                RefreshBoard();
                startGrid = null;
                selectedFigure = null;
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

        private void AddFigure(string path, Point point)
        {
            Image pawn = new Image()
            {
                Margin = new Thickness(10),
                Source = new BitmapImage(new Uri(path, UriKind.Relative))
            };
            pawn.MouseDown += FigureMouseDown;
            (gameboardGrid.Children[(int)(point.Y * 8 + point.X)] as Grid).Children.Add(pawn);
        }

        private void SetFigures()
        {
            foreach(var item in ChessGame.WhiteFigures)
            {
                string path = "";
                if (item is Pawn) path = "pawn";
                else if (item is Tower) path = "tower";
                else if (item is Bishop) path = "bishop";
                else if (item is Knight) path = "knight";
                else if (item is Queen) path = "queen";
                else if (item is King) path = "king";

                AddFigure($"/Images/{path}.png", new Point(item.Position.X, item.Position.Y));
            }

            foreach (var item in ChessGame.BlackFigures)
            {
                string path = "";
                if (item is Pawn) path = "b_pawn";
                else if (item is Tower) path = "b_tower";
                else if (item is Bishop) path = "b_bishop";
                else if (item is Knight) path = "b_knight";
                else if (item is Queen) path = "b_queen";
                else if (item is King) path = "b_king";

                AddFigure($"/Images/{path}.png", new Point(item.Position.X, item.Position.Y));
            }
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
            var attacks = ChessGame.GetAttacks(startPos);
            foreach (var p in attacks)
            {
                (gameboardGrid.Children[(p.Y) * 8 + p.X] as Grid).Background = Brushes.Red;
            }

            selectedFigure = (sender as Image);

            Panel.SetZIndex(tempCanvas, 1);
            startGrid.Children.Clear();
            var grid = new Grid()
            {
                Background = startGrid.Background
            };
            grid.MouseEnter += gridMouseEnter;
            int c = Grid.GetColumn(startGrid);
            int r = Grid.GetRow(startGrid);
            int index = gameboardGrid.Children.IndexOf(startGrid);
            gameboardGrid.Children.RemoveAt(index);
            gameboardGrid.Children.Insert(index, grid);
            Grid.SetColumn(grid, c);
            Grid.SetRow(grid, r);
            startGrid = grid;
            tempCanvas.Children.Add(selectedFigure);
            Canvas.SetLeft(selectedFigure, Math.Abs(e.GetPosition(tempCanvas).X - 10));
            Canvas.SetTop(selectedFigure, Math.Abs(e.GetPosition(tempCanvas).Y - 10));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillGameboard();
            timeTextBlock.Text = $"{gameTime} min";
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

        private void playButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            settingGrid.Visibility = Visibility.Hidden;
            playGrid.Visibility = Visibility.Visible;
            ChessGame.StartGame();
            SetFigures();
        }
    }
}
