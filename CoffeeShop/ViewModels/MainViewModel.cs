using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Basta2020Feb.CoffeeShop.Repositories;
using Basta2020Feb.CoffeeShop.ViewModels.Common;

namespace Basta2020Feb.CoffeeShop.ViewModels
{
    internal class MainViewModel : BaseViewModel, IMainViewModel
    {
	    private const int TimeToRefillCoffee = 10000;

	    private readonly ObservableReadOnlyList<IAlertViewModel> _alerts = new ObservableReadOnlyList<IAlertViewModel>();
		private readonly ObservableReadOnlyList<IMachineViewModel> _machines = new ObservableReadOnlyList<IMachineViewModel>();
	    private IMachineViewModel _selectedMachine;

	    public IObservableReadOnlyList<IAlertViewModel> Alerts => _alerts;

		public IObservableReadOnlyList<IMachineViewModel> Machines => _machines;

		public IMachineViewModel SelectedMachine
	    {
		    get => _selectedMachine;
		    set
		    {
			    _selectedMachine = value;
			    OnPropertyChanged();
		    }
	    }

	    public MainViewModel()
        {
	        foreach (var machineName in MachineRepo.LoadMachineNames())
	        {
		        var coffees = CoffeeRepo.LoadCoffees(machineName);
		        var machine = new MachineViewModel(machineName, coffees);
				foreach (var coffee in machine.Coffees)
				{
					coffee.PropertyChanged += CoffeeOnPropertyChanged;
				}
				_machines.Add(machine);
	        }

	        if (_machines.Count > 0)
	        {
		        SelectedMachine = _machines[0];
	        }
        }

	    private async void CoffeeOnPropertyChanged(object sender, PropertyChangedEventArgs e)
	    {
		    if (e?.PropertyName == nameof(ICoffeeViewModel.StockCount)
		        && sender is ICoffeeViewModel coffee
		        && coffee.StockCount == 0)
		    {
				var alert = AddAlert($"\"{coffee.DisplayName}\" ist derzeit leer. Nachschub ist unterwegs...");
				await OrderNewCoffeeAsync(coffee, 10)
				    .ConfigureAwait(true);
				_alerts.Remove(alert);
			}
	    }

	    private AlertViewModel AddAlert(string message)
	    {
		    var alert = new AlertViewModel(message);
		    _alerts.Add(alert);
		    alert.AlertConfirmed += (sender, args) => _alerts.Remove(alert);

		    return alert;
	    }

		private async Task OrderNewCoffeeAsync(ICoffeeViewModel coffee, int quantity)
	    {
		    await Task.Delay(TimeToRefillCoffee)
			    .ConfigureAwait(false);
		    coffee.Refill(quantity);
	    }
    }
}
