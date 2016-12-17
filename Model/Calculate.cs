using System;
using System.Collections.Generic;
using System.Linq;

namespace ForMyFather.Model
{
	class Calculate
	{
		private List<string> _ans = new List<string> { "上底側から出力" };
		private double _upper;
		private double _lower;
		private double _height;
		private double _divNum;

		public List<string> Ans
		{
			get
			{
				calculate();
				return new List<string>(_ans);
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
		public double DivNum
		{
			get { return _divNum; }
			set { _divNum = value; }
		}

		private void calculate()
		{
			for(int i = 1; i < DivNum; i++)
			{
				_ans.Add(string.Format("x{0} = {1}", i, (i / DivNum) * (Lower - Upper) + Upper));
				_ans.Add(string.Format("x{0}(delta) = {1}", i, ((i * Height / DivNum + 100) * (Lower - Upper)) / Height + Upper));
			}
		}

		public Calculate(double u, double l, double h, double d)
		{
			_upper = u;
			_lower = l;
			_height = h;
			_divNum = d;
		}
	}
}
