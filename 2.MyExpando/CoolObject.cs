namespace Dynamics
{
    public class CoolObject : RExpandoObject
    {
        public string Dudley { get; set; }
        public string Snidely { get; set; }

        public CoolObject()
        {
            Dudley = "Do-Right";
            Snidely = "Whiplash";
        }
    }
}
