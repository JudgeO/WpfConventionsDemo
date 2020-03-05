using System;
using System.Collections.Generic;
using Basta2020Feb.CoffeeShop.ViewModels;

namespace Basta2020Feb.CoffeeShop.Repositories
{
	internal static class CoffeeRepo
	{
		internal static IEnumerable<ICoffeeViewModel> LoadCoffees(string machineName)
		{
			var random = new Random();

			if (machineName == "Standard")
			{
				yield return new CoffeeViewModel("Cappuccino", random.Next(1, 11), "Cappuccino.jpg",
					"Italienisches Kaffeegetränk, das aus einem Espresso und heißem Milchschaum zubereitet wird.");

				yield return new CoffeeViewModel("Americano", random.Next(1, 11), "Americano.jpg",
					"Mit Wasser verdünnter Espresso, mit dem Geschmack von Espresso in der Stärke von Filterkaffee.");

				yield return new CoffeeViewModel("Latte macchiato", random.Next(1, 11), "LatteMacchiato.jpg",
					"Warmgetränk aus Milch und Espresso, das dem Milchkaffee ähnelt, aber in der Regel mehr Milch enthält und aus stärker gerösteten Bohnen zubereitet wird.");

				yield return new CoffeeViewModel("Espresso", random.Next(1, 11), "Espresso.jpg",
					"Aus Mailand stammende Kaffeezubereitungsart, bei der heißes Wasser mit hohem Druck durch sehr fein gemahlenes Kaffeemehl aus gerösteten Kaffeebohnen gepresst wird.");
			}
			else if (machineName == "Specials")
			{
				yield return new CoffeeViewModel("Tee, Earl Grey, heiß", random.Next(1, 11), "Enterprise.png",
					"Getränk von der Erde. Beliebt bei Raumschiffkapitänen. Frisch aus dem Replikator.");

				yield return new CoffeeViewModel("Kopi luwak", random.Next(1, 11), "KopiLuwak.jpg",
					"Spezielle Form von Kaffee, salopp „Katzenkaffee“ genannt, ...\nDetails bleiben dem interessierten Betrachter zur Recherche überlassen ;-)");
			}
		}
	}
}
