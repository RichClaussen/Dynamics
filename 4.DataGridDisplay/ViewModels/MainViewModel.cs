using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Dynamics.ViewModels
{
    public class MainViewModel : ObservableItem
    {
        public ObservableCollection<dynamic> Songs { get; set; }

        private string performer;
        public string Performer
        {
            get => performer;
            set
            {
                performer = value;
                OnPropertyChanged(() => Performer);
            }
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(() => Title);
            }
        }

        public ICommand AddCommand { get; private set; }

        public MainViewModel()
        {
            AddCommand = new Command
                         {
                             CanExecuteDelegate = d => CanAddSong(),
                             ExecuteDelegate = d => AddSong(),
                         };

            Songs = new ObservableCollection<dynamic>
                    {
                        new SongViewModel { Performer = "Journey", Title = "Can't Stop Believing", },
                        new SongViewModel { Performer = "Styx", Title = "Paradise Theater", },
                        new SongViewModel { Performer = "Led Zepplin", Title = "Stairway to Heaven", },
                    };
        }

        private bool CanAddSong() => !string.IsNullOrWhiteSpace(Performer) && !string.IsNullOrWhiteSpace(Title);

        private void AddSong()
        {
            Songs.Add(new SongViewModel { Performer = Performer, Title = Title, });
            Performer = null;
            Title = null;
        }
    }
}
