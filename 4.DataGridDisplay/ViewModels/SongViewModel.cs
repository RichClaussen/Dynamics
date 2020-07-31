namespace Dynamics.ViewModels
{
    public class SongViewModel : ExpandableBase
    {
        public string Performer { get; set; }
        public string Title { get; set; }

        public override string ToString() => string.Format("{0}: {1}", Performer, Title);
    }
}
