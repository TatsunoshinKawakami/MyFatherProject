using System;
using System.Collections.Generic;
using System.Linq;

namespace ForMyFather.Model
{
	class Calculate
	{
		private List<Trapezoid> _ans = new List<Trapezoid>();
		private double _upper;
		private double _lower;
		private double _height;
		private int _divNum;

		public List<Trapezoid> Ans
		{
			get
			{
				return new List<Trapezoid>(_ans);
			}
			set { _ans = value; }
		}
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
		public int DivNum
		{
			get { return _divNum; }
			set { _divNum = value; }
		}

		private void calculate()
		{
			double lo, up;
			for(int i = DivNum; i > 1; i--)
			{
				lo = (i / (double)DivNum) * (Lower - Upper) + Upper;
				up = (((i - 1) * Height / (double)DivNum - 100) * (Lower - Upper)) / Height + Upper;
				_ans.Add(new Trapezoid(up, lo, _height / DivNum + 100));
			}
			lo = (1 / (double)DivNum) * (Lower - Upper) + Upper;
			up = _upper;
			_ans.Add(new Trapezoid(up, lo, _height / _divNum));
		}

		public Calculate(double u, double l, double h, int d)
		{
			_upper = u;
			_lower = l;
			_height = h;
			_divNum = d;
			calculate();
		}
	}
}
