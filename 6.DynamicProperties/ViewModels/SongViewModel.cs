using System.ComponentModel;

namespace Dynamics.ViewModels
{
    public class SongViewModel : BindableExpandoBase
    {
        [DisplayName("XPerformerX")]
        public string Performer { get; set; }
        public string Title { get; set; }

        public override string ToString() => string.Format("{0}: {1}", Performer, Title);
    }
}
