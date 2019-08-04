using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Xml.Serialization;

namespace EventPlusX
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		protected bool _isLoading;
		protected bool _isOffline;

		public event PropertyChangedEventHandler PropertyChanged;

		[XmlIgnore]
		public ICommand TryAgain
		{
			private set;
			get;
		}

		public BaseViewModel()
		{
			this._isLoading = false;
		}

		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (Object.Equals(storage, value))
				return false;
			storage = value;
			OnPropertyChanged(propertyName);
			return true;

		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public bool IsLoading
		{
			get { return _isLoading; }
			set { SetProperty(ref _isLoading, value); }
		}

		public void StartLoading()
		{
			if (!IsLoading)
				this.IsLoading = true;
		}

		public void StopLoading()
		{
			if (IsLoading)
				this.IsLoading = false;
		}

		public bool IsOffline
		{
			get { return _isOffline; }
			set { SetProperty(ref _isOffline, value); }
		}

		public bool HasInternetConnection
		{
			get { return true; }
		}

	}
}

