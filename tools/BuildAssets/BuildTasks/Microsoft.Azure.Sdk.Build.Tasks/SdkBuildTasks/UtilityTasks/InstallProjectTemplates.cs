// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.UtilityTasks
{
    using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public class InstallProjectTemplates : NetSdkTask
    {
        #region fields
        public string[] templateDirNames;
        //List<string> templateZipFilePaths;
        string tempFilePath;

        List<string> inputTemplateFileDirPath = new List<string>();
        List<string> outputTemplateFilePath = new List<string>();

        Dictionary<string, string> DirToTemplate;
        #endregion

        #region Override properties
        protected override INetSdkTask TaskInstance => this;

        public override string NetSdkTaskName => "InstallProjectTemplates";

        #endregion

        #region Inputs
        /// <summary>
        /// Directory path to the tools directory in the repo
        /// </summary>
        [Required]
        public string ToolsDirPath { get; set; }

        public bool DebugTrace { get; set; }

        //public string PathToTemplateFiles { get; set; }

        #endregion

        #region output
        /// <summary>
        /// True: If errors were detected during execution of task
        /// False: If no errors were detected during task execution
        /// </summary>
        [Output]
        public bool TaskErrorDetected { get; private set; }

        #endregion

        /// <summary>
        /// list of directories that contain template data
        /// </summary>
        //IEnumerable<string> TemplateDirList;

        /// <summary>
        /// Directory path where the templates will be copied after build
        /// </summary>
        public string TemplateBuildOutputDirPath { get; set; }



        /// <summary>
        /// Initialize data
        /// </summary>
        private void Init()
        {
            DirToTemplate = new Dictionary<string, string>();
            TaskErrorDetected = false;
            templateDirNames = new string[] { @"AutoRest-AzureDotNetSDK", @"AzureDotNetSDK-TestProject" };
            
            //templateZipFilePaths = new List<string>();

            string tempDirFullPath = Environment.GetEnvironmentVariable("Temp");

            foreach (string templateDir in templateDirNames)
            {
                string dirFullPath = Path.Combine(ToolsDirPath, "ProjectTemplates", templateDir);
                string templateFileFullPath = string.Concat(Path.Combine(tempDirFullPath, templateDir), ".zip");

                if (Directory.Exists(dirFullPath))
                {
                    DirToTemplate.Add(dirFullPath, templateFileFullPath);
                    //inputTemplateFileDirPath.Add(dirFullPath);
                    //outputTemplateFilePath.Add(dirFullPath);
                }
            }
        }

        /// <summary>
        /// Execute Build Template task
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            this.DebugTraceEnabled = DebugTrace;
            Init();
            CreateTemplate();
            InstallTemplate();
            return true;
        }


        private void CreateTemplate()
        {
            ////string projTemplateBaseDir = Path.Combine(Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), "ProjectTemplates");
            //string projTemplateBaseDir = Path.Combine(ToolsDirPath, "ProjectTemplates");
            //string tempDirPath = Environment.GetEnvironmentVariable("Temp");


            //foreach (string templateDir in templateDirNames)
            //{
            //    string autoRestTemplateDir = Path.Combine(projTemplateBaseDir, templateDir);
            //    string zipTemplateFile = Path.GetFullPath(Path.Combine(TemplateBuildOutputDirPath, string.Concat(templateDir, ".zip")));
            //    if (File.Exists(zipTemplateFile))
            //    {
            //        File.Delete(zipTemplateFile);
            //    }

            //    ZipFile.CreateFromDirectory(autoRestTemplateDir, zipTemplateFile);
            //    Log.LogMessage("Successfully build and copied {0} template to '{1}'", templateDir, zipTemplateFile);
            //}

            foreach(KeyValuePair<string,string> kv in DirToTemplate)
            {
                if(File.Exists(kv.Value))
                {
                    File.Delete(kv.Value);
                }

                ZipFile.CreateFromDirectory(kv.Key, kv.Value);
                TaskLogger.LogDebugInfo("Successfully build and copied template to '{0}'",  kv.Value);
            }

        }

        private void InstallTemplate()
        {
            string templateDestinationDir = GetVSTemplatesDir();

            foreach (KeyValuePair<string, string> kv in DirToTemplate)
            {
                if (File.Exists(kv.Value))
                {
                    string destinationFilePath = Path.Combine(templateDestinationDir, Path.GetFileName(kv.Value));
                    TaskLogger.LogDebugInfo("Copying '{0}' to '{1}'", kv.Value, destinationFilePath);
                    File.Copy(kv.Value, destinationFilePath, overwrite: true);
                }
            }
        }


        private string GetVSTemplatesDir()
        {
            string userTemplateDir = string.Empty;
            string userProfDir = Environment.GetEnvironmentVariable("UserProfile");

            if(Directory.Exists(userProfDir))
            {
                string templateDir = Path.Combine(userProfDir, @"Documents\Visual Studio 2017\Templates\ProjectTemplates");
                if(Directory.Exists(templateDir))
                {
                    userTemplateDir = templateDir;
                }
            }

            if(string.IsNullOrEmpty(userTemplateDir))
            {
                TaskLogger.LogException(new ApplicationException("Unable to locate either userProfile or userTemplate directory"));
            }

            return userTemplateDir;
        }
    }
}
