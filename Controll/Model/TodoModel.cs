using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Controll.Model 
{
    class TodoModel :INotifyPropertyChanged
    {
		private string _FirstName;
		private string _LastName;
		private string _Adress;
		private string _BirthDay;

		// для динамического отслеживания изм.

		public string FirstName
		{
			get { return _FirstName; }
			set { if (_FirstName == value)
					return;
				_FirstName = value;
				OnPropertyChaged("FirstName");
			}

		}

		public string Adress {
			get { return _Adress; }
			set
			{
				if (_Adress == value)
					return;
				_Adress = value;
				OnPropertyChaged("Adresss");
			}
		}

		public string LastName
		{
			get { return _LastName; }
			set
			{
				if (_LastName == value)
					return;
				_LastName = value;
				OnPropertyChaged("LastName");
			}
		}



		public DateTime DateOfVisit { get; set; }
		
		public string BirthDay
		{
			get { return _BirthDay; }
			set
			{
				if (_BirthDay == value)
					return;
				_BirthDay = value;
				OnPropertyChaged("BirthDay");
			}
		}






		public event PropertyChangedEventHandler PropertyChanged;


		protected virtual void OnPropertyChaged(string propertyName="")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			
		}
	

	}
	
}
