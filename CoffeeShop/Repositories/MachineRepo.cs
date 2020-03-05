using System;
using System.Collections.Generic;

namespace Basta2020Feb.CoffeeShop.Repositories
{
	internal static class MachineRepo
	{
		internal static IEnumerable<string> LoadMachineNames()
		{
			yield return "Standard";
			yield return "Specials";
		}
	}
}
