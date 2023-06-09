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
    /// Interaction logic for RulesPage.xaml
    /// </summary>
    public partial class RulesPage : Page
    {
        public RulesPage()
        {
            InitializeComponent();
        }

        private void Pawn_MouseEnter(object sender, MouseEventArgs e)
        {
            ChessGame.SetBoard(new List<IFigure> { new Pawn(){ Position = new System.Drawing.Point(3, 4), FirstMove = false, IsWhite = true},
                new Pawn(){ Position = new System.Drawing.Point(4, 6), FirstMove = true, IsWhite = true}});
        }

        private void Rook_MouseEnter(object sender, MouseEventArgs e)
        {
            ChessGame.SetBoard(new List<IFigure> { new Tower(){ Position = new System.Drawing.Point(3, 4), IsWhite = true}});
        }

        private void Bishop_MouseEnter(object sender, MouseEventArgs e)
        {
            ChessGame.SetBoard(new List<IFigure> { new Bishop() { Position = new System.Drawing.Point(3, 4), IsWhite = true } });
        }

        private void Knight_MouseEnter(object sender, MouseEventArgs e)
        {
            ChessGame.SetBoard(new List<IFigure> { new Knight() { Position = new System.Drawing.Point(3, 4), IsWhite = true } });
        }

        private void Queen_MouseEnter(object sender, MouseEventArgs e)
        {
            ChessGame.SetBoard(new List<IFigure> { new Queen() { Position = new System.Drawing.Point(3, 4), IsWhite = true } });
        }

        private void King_MouseEnter(object sender, MouseEventArgs e)
        {
            ChessGame.SetBoard(new List<IFigure> { new King() { Position = new System.Drawing.Point(3, 4), IsWhite = true } });
        }

        private void Promotion_MouseEnter(object sender, MouseEventArgs e)
        {
            ChessGame.SetBoard(new List<IFigure> { 
                new Pawn() { Position = new System.Drawing.Point(4, 1), IsWhite = true },
                new Queen() { Position = new System.Drawing.Point(4, 0), IsWhite = true },
            });
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            ChessGame.SetBoard(new List<IFigure>());
        }
    }
}
