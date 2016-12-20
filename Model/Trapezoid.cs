using System;
using System.Collections.Generic;
using System.Linq;

namespace ForMyFather.Model
{
	class Trapezoid
	{
		private double _upper;
		private double _lower;
		private double _height;
		
		public double Upper
		{
			get { return _upper; }
			set { _upper = value; }
		}

		public double Lower
		{
			get { return _lower; }
			set { _lower = value; }
		}

		public double Height
		{
			get { return _height; }
			set { _height = value; }
		}

		public Trapezoid(double u, double l, double h)
		{
			_upper = u;
			_lower = l;
			_height = h;
		}
	}
}
