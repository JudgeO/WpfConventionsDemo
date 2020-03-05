using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Basta2020Feb.CoffeeShop.ViewModels.Common
{
	internal abstract class BaseViewModel : IBaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
