using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntelectUniCup_PracticeProblem1
{
	public class GardenAsEdges
	{
		class Path : IComparable<Path>
		{
			public String SourceVeggie, DestinationVeggie;
			public int People;

			public int CompareTo(Path comparePath)
			{
				return this.People - comparePath.People;
			}
		}

		public class Subset
		{
			public string Parent;
			public int Rank;
		}

		int iVegetables, iPaths;

		Path[] Paths;

		GardenAsEdges(int _vegetables, int _paths)
		{
			iVegetables = _vegetables;
			iPaths = _paths;

			Paths = new Path[_paths];
			for (int i = 0; i < iPaths; i++) 
			{
				Paths[i] = new Path();
			}
		}

		public string Find(Subset[] _Subsets, string _Vegetable)
		{
			if (_Subsets[Array.IndexOf(_Subsets, _Vegetable)].Parent != _Vegetable)
			{
				_Subsets[Array.IndexOf(_Subsets, _Vegetable)].Parent = Find(_Subsets, _Subsets[Array.IndexOf(_Subsets, _Vegetable)].Parent);
			}

			return _Subsets[Array.IndexOf(_Subsets, _Vegetable)].Parent;
		}

		void Union(Subset[] _Subsets, string Vegetable01, string Vegetable02) 
		{
			string Veg1Root = Find(_Subsets, Vegetable01);
			string Veg2Root = Find(_Subsets, Vegetable02);

			if (_Subsets[Array.IndexOf(_Subsets, Veg1Root)].Rank < _Subsets[Array.IndexOf(_Subsets, Veg2Root)].Rank)
				_Subsets[Array.IndexOf(_Subsets, Veg2Root)].Parent = Veg2Root;

			else
			{
				_Subsets[Array.IndexOf(_Subsets, Veg1Root)].Parent = Veg2Root;
				_Subsets[Array.IndexOf(_Subsets, Veg2Root)].Rank++;
			}
		}




	}
}
