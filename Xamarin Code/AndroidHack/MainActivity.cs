using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using PortableClassLibrary;
using System.Collections.Generic;
using System.Linq;

namespace AndroidHack
{
	[Activity (Label = "AndroidHack", MainLauncher = true)]
	public class MainActivity : Activity
	{
		private TodoViewModel todoVm;
		private ListView listView;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			Button addNewButton = FindViewById<Button>(Resource.Id.addNewButton);
			EditText addNewTextBox = FindViewById<EditText> (Resource.Id.addNewTextBox);
			listView = FindViewById<ListView> (Resource.Id.todoList);
			/* http://docs.xamarin.com/guides/android/user_interface/working_with_listviews_and_adapters/part_3_-_customizing_a_listview's_appearance/ */
			//listView.ChoiceMode = ChoiceMode.Multiple;

			todoVm = new TodoViewModel ();
			listView.Adapter = new TodoAdapter(this, todoVm.Todos);

			addNewButton.Click += (object sender, EventArgs e) => {
				todoVm.Add(new Todo{
					Id = todoVm.Todos.Count + 1,
					Text = addNewTextBox.Text,
					IsComplete = false
				});
				addNewTextBox.Text = "";
				ShowTodos();
			};
		}

		protected void ShowTodos()
		{
			listView.Adapter = new TodoAdapter(this, todoVm.Todos);
		}
	}

	public class TodoAdapter : BaseAdapter<Todo> {
		List<Todo> items;
		Activity context;
		public TodoAdapter(Activity context, List<Todo> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override Todo this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];
			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.TodoRow, null);
			var checkBox = view.FindViewById<CheckBox> (Resource.Id.todoCheckbox);
			checkBox.Checked = item.IsComplete;
			checkBox.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
				var cb = sender as CheckBox;
			};
			view.FindViewById<TextView>(Resource.Id.todoText).Text = item.Text;
			return view;
		}
	}
}


