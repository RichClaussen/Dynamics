namespace Dynamics.ViewModels
{
    public class SongViewModel : BindableExpandoBase
    {
        public string Performer { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Performer, Title);
        }
    }
}
