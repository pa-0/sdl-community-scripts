using System.Collections.Generic;
using System.Windows;
using Sdl.Versioning;

namespace StudioVersioning_CodeSample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		private StudioVersionService _studioVersionService;

        public MainWindow()
        {
			_studioVersionService = new StudioVersionService();

			InitializeComponent();
        }

		// Set different versions
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var studioVersion = _studioVersionService.GetStudioVersion();
			if (studioVersion != null)
			{
				Edition_TxtBox.Text = studioVersion.Edition;
				ExecutableVersion_TxtBox.Text = studioVersion.ExecutableVersion?.ToString();
				InstalledPath_TxtBox.Text = studioVersion.InstallPath;
				PublicVersion_TxtBox.Text = studioVersion.PublicVersion;
				StudioShortVersion_TxtBox.Text = studioVersion.ShortVersion;
				StudioDocumentsFolderName_TxtBox.Text = studioVersion.StudioDocumentsFolderName;
				Version_TxtBox.Text = studioVersion.Version;
			}
		}

		// Set all the installed Studio versions
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			var installedVersions = _studioVersionService.GetInstalledStudioVersions();
			var installedVersionsList = new List<string>();
			if (installedVersions != null)
			{
				foreach (var installedVersion in installedVersions)
				{
					installedVersionsList.Add(installedVersion.PublicVersion);
				}
			}

			InstalledStudioVersions_ListBox.ItemsSource = installedVersionsList;
		}
	}
}