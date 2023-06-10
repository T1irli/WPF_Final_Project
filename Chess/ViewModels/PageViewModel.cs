using BusinessLogicLayer.Services;
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
        private RulesPage rulesPage;
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
            get => new RelayCommand(() => {
                CurrentPage = gamePage;
                gamePage.GameTime = mainPage.GameTime;
                ChessGame.StartGame();
            });
        }

        public ICommand OpenRules
        {
            get => new RelayCommand(() => {
                CurrentPage = rulesPage;
            });
        }

        public ICommand GoBack
        {
            get => new RelayCommand(() => {
                CurrentPage = mainPage;
            });
        }

        public PageViewModel()
        {
            mainPage = new MainPage();
            gamePage = new GamePage();
            rulesPage = new RulesPage();

            mainPage.playButton.Command = StartGame;
            mainPage.rulesTextBlock.InputBindings.Add(new MouseBinding() { Command = OpenRules, MouseAction = MouseAction.LeftClick });
            rulesPage.backArrow.InputBindings.Add(new MouseBinding() { Command = GoBack, MouseAction = MouseAction.LeftClick });
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
