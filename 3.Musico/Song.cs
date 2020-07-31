namespace Dynamics
{
    public class Song : ExpandableBase
    {
        public dynamic Performer { get; set; }
        public string Title { get; set; }

        public override string ToString() => string.Format("{0}: {1}", Performer, Title);
    }
}
