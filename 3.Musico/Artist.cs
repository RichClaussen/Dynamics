namespace Dynamics
{
    public class Artist : ExpandableBase
    {
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
