using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox.ViewModels
{
    public class ChildOneViewModel : Screen
    {
        private string someProp;

        public string SomeProp
        {
            get { return someProp; }
            set { someProp = value; }
        }

        public ChildOneViewModel()
        {
            SomeProp = "page 1";
        }
    }
}
