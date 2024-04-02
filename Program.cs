using EntelectUniCup_PracticeProblem1;
using System;
using System.Collections.Generic;

namespace EntelectUniCup_PracticeProblem1
{
	internal class Program
	{
		public static void Main(String[] args)
		{
			int V = 4; // Number of vegetables
			int E = 5; // Number of paths
			GardenAsEdges SproutopiaGarden = new GardenAsEdges(V, E);

			// Add paths between vegetables
			SproutopiaGarden.Paths[0].SourceVeggie = "Carrots";
			SproutopiaGarden.Paths[0].DestinationVeggie = "Spinach";
			SproutopiaGarden.Paths[0].People = 3;

			SproutopiaGarden.Paths[1].SourceVeggie = "Carrot";
			SproutopiaGarden.Paths[1].DestinationVeggie = "Tomatoes";
			SproutopiaGarden.Paths[1].People = 4;

			SproutopiaGarden.Paths[2].SourceVeggie = "Spinach";
			SproutopiaGarden.Paths[2].DestinationVeggie = "Corn";
			SproutopiaGarden.Paths[2].People = 2;

			SproutopiaGarden.Paths[3].SourceVeggie = "Spinach";
			SproutopiaGarden.Paths[3].DestinationVeggie = "Yams";
			SproutopiaGarden.Paths[3].People = 3;

			SproutopiaGarden.Paths[3].SourceVeggie = "Corn";
			SproutopiaGarden.Paths[3].DestinationVeggie = "Yams";
			SproutopiaGarden.Paths[3].People = 1;

			SproutopiaGarden.Paths[4].SourceVeggie = "Tomato";
			SproutopiaGarden.Paths[4].DestinationVeggie = "Corn";
			SproutopiaGarden.Paths[4].People = 5;

			// Function call to find MST
			List<string> traversalOrder = SproutopiaGarden.GetGardenMST();

			// Output the traversal order
			Console.WriteLine("Work on veggies in this order:");
			foreach (var vegetable in traversalOrder)
			{
				Console.WriteLine(vegetable);
			}
		}
	}
}