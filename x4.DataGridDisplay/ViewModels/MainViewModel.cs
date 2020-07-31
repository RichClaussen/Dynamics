using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Dynamics.ViewModels
{
    public class MainViewModel : ObservableItem
    {
        public ObservableCollection<SongViewModel> Songs { get; set; }
        public ObservableCollection<SongViewModel> Abc { get; set; }

        private string performer;
        public string Performer
        {
            get { return performer; }
            set
            {
                performer = value;
                this.OnPropertyChanged(() => Performer);
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                this.OnPropertyChanged(() => Title);
            }
        }

        public ICommand AddCommand { get; private set; }

        public MainViewModel()
        {
            AddCommand = new Command
                         {
                             CanExecuteDelegate = d => this.CanAddSong(),
                             ExecuteDelegate = d => this.AddSong(),
                         };

            Songs = new ObservableCollection<SongViewModel>
                    {
                        new SongViewModel { Performer = "Journey", Title = "Can't Stop Believing", },
                        new SongViewModel { Performer = "Styx", Title = "Paradise Theater", },
                        new SongViewModel { Performer = "Led Zepplin", Title = "Stairway to Heaven", },
                        //new SongViewModel { Performer = "Led Zepplin", Title = "Stairway to Heaven", },
                        //new SongViewModel { Performer = "Led Zepplin", Title = "Stairway to Heaven", },
                        //new SongViewModel { Performer = "Led Zepplin", Title = "Stairway to Heaven", },
                        //new SongViewModel { Performer = "Led Zepplin", Title = "Stairway to Heaven", },
                        //new SongViewModel { Performer = "Led Zepplin", Title = "Stairway to Heaven", },
                        //new SongViewModel { Performer = "Led Zepplin", Title = "Stairway to Heaven", },
                    };
        }

        private bool CanAddSong()
        {
            return !string.IsNullOrWhiteSpace(this.Performer) && !string.IsNullOrWhiteSpace(this.Title);
        }

        private void AddSong()
        {
            Songs.Add(new SongViewModel { Performer = this.Performer, Title = this.Title, });
            Performer = null;
            Title = null;
        }
    }
}
