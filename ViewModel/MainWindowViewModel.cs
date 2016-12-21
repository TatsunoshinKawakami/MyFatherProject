using System;
using System.Collections.Generic;
using System.Linq;
using ForMyFather.Common;
using ForMyFather.Model;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace ForMyFather.ViewModel
{
	class MainWindowViewModel : ViewModelBase
	{
		private double _upper;
		private double _lower;
		private double _height;
		private double _lap;
		private int _divNum;
		private Trapezoid _original;
		private int _selectedIndex;
		private Trapezoid _big;
		private List<Trapezoid> _ans = new List<Trapezoid>();

		private DelegateCommand _calculateCommand;

		public double Upper
		{
			get { return _upper; }
			set
			{
				_upper = value;
				RaisePropertyChanged("Upper");
			}
		}   //両端の短い方の辺(台形における上底)
		public double Lower
		{
			get { return _lower; }
			set
			{
				_lower = value;
				RaisePropertyChanged("Lower");
			}
		}   //両端の長い方の辺(台形における下底)
		public double Height
		{
			get { return _height; }
			set
			{
				_height = value;
				RaisePropertyChanged("Height");
			}
		}	//長さ(台形における高さ)
		public double Lap
		{
			get { return _lap; }
			set
			{
				_lap = value;
				RaisePropertyChanged("Lap");
			}
		}	 //重ね
		public int DivNum
		{
			get { return _divNum; }
			set
			{
				_divNum = value;
				RaisePropertyChanged("DivNum");
			}
		}	 //何等分か
		public List<Trapezoid> Ans
		{
			get { return _ans; }
			set
			{
				_ans = value;
				RaisePropertyChanged("Ans");
			}
		}	  //答えは多角形
		public int SelectedIndex
		{
			get { return _selectedIndex; }
			set
			{
				_selectedIndex = value;
				if (_selectedIndex != -1)
				{
					_big = new Trapezoid(_ans[_selectedIndex]);
					_big.Max = Math.Max(_original.Lower, Math.Max(_original.Height, _original.Lower));
					_big.DisplaySize = 200;
					RaisePropertyChanged("Big");
				}
				RaisePropertyChanged("SelectedIndex");
			}
		}
		public Trapezoid Big
		{
			get { return _big; }
			set
			{
				_big = value;
				RaisePropertyChanged("Big");
			}
		}
		public Trapezoid Original
		{
			get { return _original; }
			set { _original = value; }
		}	 //切り分ける前の状態

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
			bool isReverse = _upper > _lower;
			Calculate cal = new Calculate(Math.Min(_upper, _lower), Math.Max(_upper, _lower), _height, _lap * 10, _divNum);
			_ans = cal.Ans;
			_original = new Calculate(Math.Min(_upper, _lower), Math.Max(_upper, _lower), _height, _lap * 10, 1).Ans.First();
			if (isReverse)
				_original.Reverse();

			double maxLength = Math.Max(_ans.First().Height, _ans.First().Lower);
			foreach (Trapezoid trape in _ans)
			{
				trape.Max = maxLength;
				trape.DisplaySize = 130;
				if (isReverse)
					trape.Reverse();
			}

			RaisePropertyChanged("Ans");
			RaisePropertyChanged("Original");
		}   //計算してViewに渡す多角形の生成を行う
		private bool CanCalculateExecute()
		{
			return DivNum != 0;
		}	  //0では割れない
	}
}
