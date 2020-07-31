using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Dynamics.ViewModels
{
    public class MainViewModel : ObservableItem
    {
        public DynamicObservableCollection<SongViewModel> Songs { get; private set; }

        public DynamicObservableCollection<OtherViewModel> Others { get; private set; }

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
            dynamic song = new SongViewModel { Performer = "Journey", Title = "Don't Stop Believing", };

            Songs = new DynamicObservableCollection<SongViewModel>
            {
                song,
                new SongViewModel { Performer = "Styx", Title = "Rockin' the Paradise", },
                new SongViewModel { Performer = "Led Zepplin", Title = "Stairway to Heaven", },
            };

            Songs[1].Composer = "Dennis DeYoung";

            Songs[0].Length = new TimeSpan(0, 0, 4, 11);
            Songs[1].Length = new TimeSpan(0, 0, 3, 35);
            Songs[2].Length = new TimeSpan(0, 0, 8, 02);

            dynamic other = new OtherViewModel { Thing = "Hello World", };

            other.AddProperty("FizzBin", typeof(int), "Fizzy Bin");

            other.FizzBin = 5;
            other.Muskrat = "Sweet Moses";

            Others = new DynamicObservableCollection<OtherViewModel>
            {
                other,
                new OtherViewModel { Thing = "Is Cool?", },
            };

            object value = 85.156;

            other.AddValue("Moose", "My Moose", value);
        }
    }
}
