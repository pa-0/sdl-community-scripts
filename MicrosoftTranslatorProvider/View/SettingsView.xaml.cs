﻿using System.ComponentModel;
using System.Windows;
using MicrosoftTranslatorProvider.Helpers;
using System.Windows.Input;

namespace MicrosoftTranslatorProvider.View
{
	/// <summary>
	/// Interaction logic for SettingsViewModel.xaml
	/// </summary>
	public partial class SettingsView : Window
	{
		public SettingsView()
		{
			InitializeComponent();
		}

		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			AnimationsHelper.StartOpeningWindowAnimation(this);
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			Closing -= Window_Closing;
			e.Cancel = true;
			AnimationsHelper.StartClosingWindowAnimation(this);
		}
	}
}