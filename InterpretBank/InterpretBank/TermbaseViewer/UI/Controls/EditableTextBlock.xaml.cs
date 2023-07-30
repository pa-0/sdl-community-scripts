﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace InterpretBank.TermbaseViewer.UI.Controls
{
	/// <summary>
	/// Interaction logic for EditableTextBlock.xaml
	/// </summary>
	public partial class EditableTextBlock : UserControl
	{
		public static readonly DependencyProperty IsEditingProperty =
			DependencyProperty.Register(nameof(IsEditing), typeof(bool), typeof(EditableTextBlock), new PropertyMetadata(false));

		public static readonly DependencyProperty TextProperty =
					DependencyProperty.Register(nameof(Text), typeof(string), typeof(EditableTextBlock), new PropertyMetadata(""));

		public EditableTextBlock()
		{
			InitializeComponent();
		}

		public bool IsEditing
		{
			get { return (bool)GetValue(IsEditingProperty); }
			set
			{
				SetValue(IsEditingProperty, value);
				SetEditing();
			}
		}

		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		private void SetEditing()
		{
			if (IsEditing)
			{
				TextBox.Visibility = Visibility.Visible;
				TextBlock.Visibility = Visibility.Collapsed;
			}
			else
			{
				TextBox.Visibility = Visibility.Collapsed;
				TextBlock.Visibility = Visibility.Visible;
			}
		}
	}
}