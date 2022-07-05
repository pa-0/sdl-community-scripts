﻿using System;
using System.IO;
using Sdl.ProjectAutomation.Core;
using Sdl.ProjectAutomation.FileBased;

namespace PretranslateProjectsCreatedFromTemplateSample.Helpers
{
	public class Pretranslator : IDisposable
	{
		public FileBasedProject CreateProjectFromTemplate(ProjectTemplateReference template, string pathToFiles, string newProjectPath)
		{
			var newProjectDirectory = DirectoryHelper.GetDestinationDirectory($"{newProjectPath}_{new DirectoryInfo(pathToFiles).Name}");

			var projectInfo = new ProjectInfo
			{
				Name = newProjectDirectory.Name,
				LocalProjectFolder = newProjectDirectory.FullName
			};

			var newProject = new FileBasedProject(projectInfo, template);
			newProject.AddFolderWithFiles(pathToFiles, false);

			_ = newProject.RunAutomaticTasks(
				newProject.GetSourceLanguageFiles().GetIds(),
				new[]
				{
					AutomaticTaskTemplateIds.Scan,
					AutomaticTaskTemplateIds.ConvertToTranslatableFormat,
					AutomaticTaskTemplateIds.CopyToTargetLanguages,
					AutomaticTaskTemplateIds.PreTranslateFiles
				});
			newProject.Save();

			return newProject;
		}

		public void Dispose()
		{
		}
	}
}