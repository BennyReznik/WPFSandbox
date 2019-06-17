using Autofac;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox.ViewModels
{
    public class ShellViewModel : Screen
    {
        private string myVar;

        public string MyProperty
        {
            get { return myVar; }
            set
            {
                myVar = value;
                NotifyOfPropertyChange(() => MyProperty);
            }
        }

        public BindableCollection<object> MyViews { get; set; }


        public ShellViewModel()
        {
            MyProperty = "start";
            MyViews = new BindableCollection<object>();
        }

        public void AddPage()
        {
            var viewModel = Bootstrapper.Container.Resolve<ChildOneViewModel>();
            MyViews.Add(viewModel);
        }
    }
}
