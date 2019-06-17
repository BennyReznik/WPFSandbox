using Caliburn.Micro;

namespace WPFSandbox.ViewModels
{
    public class ChildOneViewModel : PropertyChangedBase
    {
        public string SomeProp { get; set; }

        public ChildOneViewModel()
        {
            SomeProp = "page 1";
        }
    }
}
