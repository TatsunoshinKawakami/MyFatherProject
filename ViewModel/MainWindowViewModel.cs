﻿using System;
using System.Collections.Generic;
using System.Linq;
using ForMyFather.Common;
using ForMyFather.Model;

namespace ForMyFather.ViewModel
{
	class MainWindowViewModel : ViewModelBase
	{
		private double _upper;
		private double _lower;
		private double _height;
		private double _divNum;
		private List<string> _ans;

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
		public double DivNum
		{
			get { return _divNum; }
			set
			{
				_divNum = value;
				RaisePropertyChanged("DivNum");
			}
		}
		public List<string> Ans
		{
			get { return _ans; }
			set
			{
				_ans = value;
				RaisePropertyChanged("Ans");
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
			Calculate cal = new Calculate(_upper, _lower, _height, _divNum);
			_ans = cal.Ans;
			RaisePropertyChanged("Ans");
		}
		private bool CanCalculateExecute()
		{
			return DivNum != 0;
		}
	}
}
