using BusinessLogicLayer.Services;
using Chess.Commands;
using Chess.Views;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chess.ViewModels
{
    public class PageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private MainPage mainPage;
        private GamePage gamePage;
        private Page currentPage;

        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartGame
        {
            get => new StartCommand((obj) => {
                CurrentPage = gamePage;
                ChessGame.StartGame();
            });
        }

        public PageViewModel()
        {
            mainPage = new MainPage();
            gamePage = new GamePage();

            mainPage.playButton.Command = StartGame;
            CurrentPage = mainPage;
        }

        public void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
