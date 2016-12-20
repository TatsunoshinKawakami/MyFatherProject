using System;
using System.Collections.Generic;
using System.Linq;
using ForMyFather.Common;
using ForMyFather.Model;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ForMyFather.ViewModel
{
	class MainWindowViewModel : ViewModelBase
	{
		private double _upper;
		private double _lower;
		private double _height;
		private double _lap;
		private int _divNum;
		private List<Trapezoid> _ans = new List<Trapezoid>();
		private List<Polygon> _shapes = new List<Polygon>();

		private DelegateCommand _calculateCommand;

		public double Upper
		{
			get { return _upper; }
			set
			{
				_upper = value;
				RaisePropertyChanged("Upper");
			}
		}
		public double Lower
		{
			get { return _lower; }
			set
			{
				_lower = value;
				RaisePropertyChanged("Lower");
			}
		}
		public double Height
		{
			get { return _height; }
			set
			{
				_height = value;
				RaisePropertyChanged("Height");
			}
		}
		public double Lap
		{
			get { return _lap; }
			set
			{
				_lap = value;
				RaisePropertyChanged("Lap");
			}
		}
		public int DivNum
		{
			get { return _divNum; }
			set
			{
				_divNum = value;
				RaisePropertyChanged("DivNum");
			}
		}
		public List<Trapezoid> Ans
		{
			get { return _ans; }
			set
			{
				_ans = value;
				RaisePropertyChanged("Ans");
			}
		}
		public List<Polygon> Shapes
		{
			get	{ return _shapes; }
			set
			{
				_shapes = value;
				RaisePropertyChanged("Shapes");
			}
		}

		public DelegateCommand CalculateCommand
		{
			get
			{
				if (_calculateCommand == null)
				{
					_calculateCommand = new DelegateCommand(CalculateExecute, CanCalculateExecute);
				}

				return _calculateCommand;
			}
		}
		private void CalculateExecute()
		{
			Calculate cal = new Calculate(Math.Min(_upper, _lower), Math.Max(_upper, _lower), _height, _lap*10, _divNum);
			_ans = cal.Ans;
			List<Polygon> polies = new List<Polygon>();
			foreach (Trapezoid trape in _ans)
			{
				Polygon poly = new Polygon { Stroke = Brushes.Black, StrokeThickness = 1 };
				poly.Points.Add(new System.Windows.Point(0, 0));
				poly.Points.Add(new System.Windows.Point(trape.Height, 0));
				poly.Points.Add(new System.Windows.Point(trape.Height, trape.Lower));
				poly.Points.Add(new System.Windows.Point(0, trape.Upper));
				polies.Add(poly);
			}
			Shapes = new List<Polygon>(polies);
			RaisePropertyChanged("Ans");
			RaisePropertyChanged("Shapes");
		}
		private bool CanCalculateExecute()
		{
			return DivNum != 0;
		}
	}
}
