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
		private double _lap;
		private int _divNum;

		public List<Trapezoid> Ans
		{
			get
			{
				return new List<Trapezoid>(_ans);
			}
			set { _ans = value; }
		}

		private void calculate()
		{
			double lo, up;
			for(int i = _divNum; i > 1; i--)
			{
				lo = (i / (double)_divNum) * (_lower - _upper) + _upper;
				up = (((i - 1) * _height / (double)_divNum - _lap) * (_lower - _upper)) / _height + _upper;
				_ans.Add(new Trapezoid(up, lo, _height / _divNum + 100));
			}
			lo = (1 / (double)_divNum) * (_lower - _upper) + _upper;
			up = _upper;
			_ans.Add(new Trapezoid(up, lo, _height / _divNum));
		}

		public Calculate(double u, double l, double h, double lap, int d)
		{
			_upper = u;
			_lower = l;
			_height = h;
			_lap = lap;
			_divNum = d;
			calculate();
		}
	}
}
