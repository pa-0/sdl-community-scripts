using System.Windows.Input;
using Microsoft.Win32;
using TmxTmDatabase;
using TmxTmDatabaseManager.Commands;
using TMXTMDatabaseManager.Model;

namespace TmxTmDatabaseManager.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private TmxTmDb _tmxTmDb;
		private string _selectedFilePaths;
		private ICommand _openDialogCommand;
		private ICommand _insertFileCommand;

		public MainViewModel()
		{
			_tmxTmDb = new TmxTmDb();
		}

		public ICommand OpenDialogCommand => _openDialogCommand ?? (_openDialogCommand = new CommandHandler(OpenDialog, true));
		public ICommand InsertFileCommand => _insertFileCommand ?? (_insertFileCommand = new CommandHandler(InsertFile, true));

		public string SelectedFilePaths
		{
			get => _selectedFilePaths;
			set
			{
				_selectedFilePaths = value;
				OnPropertyChanged(nameof(SelectedFilePaths));
			}
		}

		private void OpenDialog()
		{
			var dlg = new OpenFileDialog();
			dlg.DefaultExt = ".tmx";
			dlg.Filter = "TMX Files (*.tmx)|*.tmx";
			dlg.Multiselect = true;
			var dialogResult = dlg.ShowDialog();

			if (dialogResult == true)
			{
				if (dlg.FileNames.Length > 1)
				{
					foreach (var file in dlg.FileNames)
					{
						SelectedFilePaths += $"{file};";
					}
					SelectedFilePaths.TrimEnd(',');
				}
				else
				{
					SelectedFilePaths = dlg.FileName;
				}
			}
		}

		private async void InsertFile()
		{
			var filePaths = SelectedFilePaths.Split(';');
			foreach (var filePath in filePaths)
			{
				await _tmxTmDb.InsertFile(filePath);
			}
		}
	}	
}