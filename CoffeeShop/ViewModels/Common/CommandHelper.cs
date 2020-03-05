using System;
using System.Windows.Input;

namespace Basta2020Feb.CoffeeShop.ViewModels.Common
{
	internal class CommandHelper : ICommand
	{
		private readonly Action _action;
		private readonly Func<bool> _canExecute;

		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		public CommandHelper(Action action, Func<bool> canExecute)
		{
			_action = action;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute.Invoke();
		}

		public void Execute(object parameter)
		{
			_action();
		}
	}
}
