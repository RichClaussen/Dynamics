using System;
using System.Windows.Input;

namespace Dynamics.ViewModels
{
    public class MainViewModel : ObservableItem
    {
        public DynamicObservableCollection<SongViewModel> Songs { get; private set; }

        public DynamicObservableCollection<OtherViewModel> Strings { get; private set; }

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

            Songs = new DynamicObservableCollection<SongViewModel>
                    {
                        new SongViewModel { Performer = "Journey", Title = "Don't Stop Believing", },
                        new SongViewModel { Performer = "Styx", Title = "Rockin' the Paradise", },
                        new SongViewModel { Performer = "Led Zepplin", Title = "Stairway to Heaven", },
                    };

            Songs[0].Length = new TimeSpan(0, 0, 4, 11);
            Songs[1].Length = new TimeSpan(0, 0, 3, 35);
            Songs[2].Length = new TimeSpan(0, 0, 8, 02);

            Songs[1].Composer = "Dennis DeYoung";

            Strings = new DynamicObservableCollection<OtherViewModel>
            {
                new OtherViewModel { Thing = "Hello World", },
                new OtherViewModel { Thing = "Is Cool?", },
            };

            Strings[0].FizzBin = 5;
            Strings[0].Muskrat = "Sweet Moses";
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
