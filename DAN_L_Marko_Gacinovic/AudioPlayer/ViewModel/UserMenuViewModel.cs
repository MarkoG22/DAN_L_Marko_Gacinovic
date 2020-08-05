using AudioPlayer.Commands;
using AudioPlayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AudioPlayer.ViewModel
{
    class UserMenuViewModel : ViewModelBase
    {
        UserMenu userMenu;

        public UserMenuViewModel(UserMenu userMenuOpen)
        {
            userMenu = userMenuOpen;
        }

        private ICommand addSong;
        public ICommand AddSong
        {
            get
            {
                if (addSong == null)
                {
                    addSong = new RelayCommand(param => AddSongExecute(), param => CanAddSongExecute());
                }
                return addSong;
            }
        }

        private bool CanAddSongExecute()
        {
            return true;
        }

        private void AddSongExecute()
        {
            try
            {
                AddNewSong addSong = new AddNewSong();
                addSong.ShowDialog();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        private ICommand deleteSong;
        public ICommand DeleteSong
        {
            get
            {
                if (deleteSong == null)
                {
                    deleteSong = new RelayCommand(param => DeleteSongExecute(), param => CanDeleteSongExecute());
                }
                return deleteSong;
            }
        }

        private bool CanDeleteSongExecute()
        {
            return true;
        }

        private void DeleteSongExecute()
        {
            try
            {
                DeleteTheSong deleteSong = new DeleteTheSong();
                deleteSong.ShowDialog();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        private ICommand playSong;
        public ICommand PlaySong
        {
            get
            {
                if (playSong == null)
                {
                    playSong = new RelayCommand(param => PlaySongExecute(), param => CanPlaySongExecute());
                }
                return playSong;
            }
        }

        private bool CanPlaySongExecute()
        {
            return true;
        }

        private void PlaySongExecute()
        {
            try
            {
                PlayTheSong playSong = new PlayTheSong();
                playSong.ShowDialog();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
    }
}
