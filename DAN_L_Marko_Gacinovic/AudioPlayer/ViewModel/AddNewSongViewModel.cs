using AudioPlayer.Commands;
using AudioPlayer.Models;
using AudioPlayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AudioPlayer.ViewModel
{
    class AddNewSongViewModel : ViewModelBase
    {
        AddNewSong addNewSong;

        private tblSong song;
        public tblSong Song
        {
            get { return song; }
            set { song = value; OnPropertyChanged("Song"); }
        }


        public AddNewSongViewModel(AddNewSong addNewSongOpen)
        {
            song = new tblSong();
            addNewSong = addNewSongOpen;
        }

        // commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        /// <summary>
        /// method for adding the new article
        /// </summary>
        private void SaveExecute()
        {
            try
            {
                using (Zadatak_50Entities context = new Zadatak_50Entities())
                {
                    tblSong newSong = new tblSong();

                    newSong.Title = song.Title;
                    newSong.Author = song.Author;
                    newSong.Duration_s = song.Duration_s;
                    newSong.Logged = song.Logged;
                    newSong.SongID = song.SongID;

                    context.tblSongs.Add(newSong);
                    context.SaveChanges();
                }
                addNewSong.Close();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong inputs, please try again.");
            }
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(song.Title) || String.IsNullOrEmpty(song.Author) || song.Duration_s == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // command for closing the window
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        /// <summary>
        /// method for closing the window
        /// </summary>
        private void CloseExecute()
        {
            try
            {
                addNewSong.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }
    }
}
