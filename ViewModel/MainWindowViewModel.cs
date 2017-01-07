using System;
using System.Collections.Generic;
using System.Linq;
using ForMyFather.Common;
using ForMyFather.Model;

using System.Printing;
using System.Windows.Xps;
using System.Windows.Documents;
using System.Windows.Controls;

namespace ForMyFather.ViewModel
{
	public class MainWindowViewModel : ViewModelBase
	{
		private double? _upper;
		private double? _lower;
		private double? _height;
		private double? _lap;
		private int? _divNum;
		private Trapezoid _original;
		private List<Trapezoid> _ans;

		private DelegateCommand _calculateCommand;
		private DelegateCommand _printCommand;

		public double? Upper
		{
			get { return _upper; }
			set
			{
				_upper = value;
				RaisePropertyChanged("Upper");
			}
		}   //両端の短い方の辺(台形における上底)
		public double? Lower
		{
			get { return _lower; }
			set
			{
				_lower = value;
				RaisePropertyChanged("Lower");
			}
		}   //両端の長い方の辺(台形における下底)
		public double? Height
		{
			get { return _height; }
			set
			{
				_height = value;
				RaisePropertyChanged("Height");
			}
		}	//長さ(台形における高さ)
		public double? Lap
		{
			get { return _lap; }
			set
			{
				_lap = value;
				RaisePropertyChanged("Lap");
			}
		}	 //重ね
		public int? DivNum
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
		}
		public Trapezoid Original
		{
			get { return _original; }
			set
			{
				_original = value;
				RaisePropertyChanged("Original");
			}
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
			_ans = new Calculate(Math.Min(_upper??-1, _lower??-1), Math.Max(_upper??0, _lower??0), _height??0, _lap??0, _divNum??1).Ans;
			_original = new Trapezoid(_upper??0, _lower??0, _height??0);
			_original.Max = Math.Max(_original.Lower, _original.Height);

			int count = _ans.Count;
			for (int i = 1; i <= count; i++)
			{
				_ans[i - 1].Max = _original.Max;
				_ans[i - 1].DisplaySize = 300;
				if (isReverse)
					_ans[i - 1].Reverse();
			}

			if (isReverse)
				_ans.Reverse();

			for (int i = 1; i <= count; i++)
				_ans[i - 1].Index = i;

			RaisePropertyChanged("Ans");
			RaisePropertyChanged("Original");
		}   //計算してViewに渡す多角形の生成を行う
		private bool CanCalculateExecute()
		{
			return DivNum != 0;
		}	  //0では割れない

		public DelegateCommand PrintCommand
		{
			get
			{
				return this._printCommand ?? (this._printCommand = new DelegateCommand(this.Print));
			}
		}

		private void Print()
		{
			Printer.Print(this);
		}
	}
}
