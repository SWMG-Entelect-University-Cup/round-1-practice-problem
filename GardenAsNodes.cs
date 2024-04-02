using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntelectUniCup_PractiveProblem1
{
	public class GardenAsNodes<T>
	{
		private class Vegetable
		{
			public String Name { get; set; }
			public List<Vegetable> Neighbours { get; set; }
			public List<int> People { get; set; }

			public Vegetable(String _Name)
			{
				this.Name = _Name;
				Neighbours = new List<Vegetable>();
				People = new List<int>();
			}

			public override string ToString()
			{
				return this.Name;
			}
		}

		private Vegetable[] Vegetables;

		public GardenAsNodes()
		{
			Vegetables = new Vegetable[0];
		}

		public int Size
		{
			get { return Vegetables.Length; }
		}

		private Vegetable GetVegetable(String _Name)
		{
			foreach (Vegetable vegetable in this.Vegetables)
				if (vegetable.Name == _Name)
					return vegetable;

			return null;
		}
		public void AddVegetable(String _Name)
		{
			Vegetable newVeg = GetVegetable(_Name);
			if (newVeg == null) 
			{
				Array.Resize(ref Vegetables, Vegetables.Length + 1);
				int newVegIndex = Vegetables.Length - 1;
				Vegetables[newVegIndex] = new Vegetable(_Name);

			}
		}

		public void AddPath(String _Vegetable01, String _Vegetable02, int _People = 0)
		{
			Vegetable Vegetable01 = GetVegetable(_Vegetable01);
			Vegetable Vegetable02 = GetVegetable(_Vegetable02);

			if (Vegetable01 != null && Vegetable02 != null)
			{
				Vegetable01.Neighbours.Add(Vegetable02);
				Vegetable01.People.Add(_People);
			}

		}

		public bool HasNeighbour(String _Vegetable01, String _Vegetable02)
		{
			Vegetable Vegetable01 = GetVegetable(_Vegetable01);
			Vegetable Vegetable02 = GetVegetable(_Vegetable02);

			if (Vegetable01 != null && Vegetable02 != null)
				return Vegetable01.Neighbours.Contains(Vegetable02);

			return false;
		}

		public List<String> GetNeighbours(String _Vegetable)
		{
			Vegetable vegetable = GetVegetable(_Vegetable);
			if (vegetable != null)
				return vegetable.Neighbours.Select(neighbour => neighbour.Name).ToList();
			else
				return null;
		}

		public List<KeyValuePair<String, int>> GetNeighboursWithPaths(String _Vegetable)
		{
			Vegetable vegetable = GetVegetable(_Vegetable);

			if (vegetable != null)
			{
				List<KeyValuePair<String, int>> lstNeighbours = new List<KeyValuePair<String, int>>();
				for (int i = 0; i < vegetable.Neighbours.Count; i++)
					lstNeighbours.Add(new KeyValuePair<string, int>(vegetable.Neighbours[i].Name, vegetable.People[i]));

				return lstNeighbours;

			}
			else
				return null;
		}


	}
}
