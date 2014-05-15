namespace PortableClassLibrary
{
	public class Todo : BaseViewModel
	{
		public int Id
		{
			get { return _id; }
			set
			{
				if (value == _id) return;
				_id = value;
				OnPropertyChanged();
			}
		}

		public string Text
		{
			get { return _text; }
			set
			{
				if (value == _text) return;
				_text = value;
				OnPropertyChanged();
			}
		}

		public bool IsComplete
		{
			get { return _isComplete; }
			set
			{
				if (value.Equals(_isComplete)) return;
				_isComplete = value;
				OnPropertyChanged();
			}
		}

		private int _id;
		private string _text;
		private bool _isComplete;
	}
}