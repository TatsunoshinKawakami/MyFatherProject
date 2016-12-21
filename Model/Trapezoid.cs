using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace ForMyFather.Model
{
	class Trapezoid
	{
		private double _upper;
		private double _lower;
		private double _height;
		private double _max = 1;
		private double _displaySize = 1;
		private Polygon _poly = new Polygon();
		
		public double Upper
		{
			get { return _upper; }
			set { _upper = value; }
		}   //上底プロパティ

		public double Lower
		{
			get { return _lower; }
			set { _lower = value; }
		}   //下底プロパティ

		public double Height
		{
			get { return _height; }
			set { _height = value; }
		}	//高さプロパティ

		private void calAgain()
		{
			_poly.Points[0] = new Point(0, 0);
			_poly.Points[1] = new Point(_height / _max * _displaySize, 0);
			_poly.Points[2] = new Point(_height / _max * _displaySize, _lower / _max * _displaySize);
			_poly.Points[3] = new Point(0, _upper / _max * _displaySize);
		}

		public double Max
		{
			get { return _max; }
			set
			{
				_max = value;
				calAgain();
			}
		}	 //縮小用

		public double DisplaySize
		{
			get { return _displaySize; }
			set
			{
				_displaySize = value;
				calAgain();
			}
		}

		public void Reverse()
		{
			double up = _upper;
			_upper = _lower;
			_lower = up;
			calAgain();
		}   //台形反転用

		public Polygon Poly
		{
			get { return _poly; }
			set { _poly = value; }
		}

		public Trapezoid(double u, double l, double h)
		{
			_poly.Points = new PointCollection(Enumerable.Range(1, 4).Select(x => new Point()));
			_upper = u;
			_lower = l;
			_height = h;
			calAgain();
		}	  //コンストラクタ
		public Trapezoid(Trapezoid trape)
		{
			_poly.Points = new PointCollection(Enumerable.Range(1, 4).Select(x => new Point()).ToList());
			_upper = trape.Upper;
			_lower = trape.Lower;
			_height = trape.Height;
			calAgain();
		}
	}
}
