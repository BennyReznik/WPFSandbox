using Autofac;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSandbox.ViewModels
{
    public class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        private readonly Func<ChildOneViewModel> childOneViewModelFunctor;
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


        public ShellViewModel(Func<ChildOneViewModel> childOneViewModelFunctor)
        {
            MyProperty = "start";
            this.childOneViewModelFunctor = childOneViewModelFunctor;
        }

        public void AddPage()
        {
            ChildOneViewModel childViewModel = childOneViewModelFunctor();
            Items.Add(childViewModel);
            //ActivateItem(childViewModel);
        }

        public void RemovePage()
        {
            if (Items.Count > 0)
            {
                Items.Remove(Items.Last());
            }
        }
    }
}
