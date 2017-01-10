/*
 Copyright (c) Microsoft.  All rights reserved.

 Licensed under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License.
 You may obtain a copy of the License at
   http://www.apache.org/licenses/LICENSE-2.0

 Unless required by applicable law or agreed to in writing, software
 distributed under the License is distributed on an "AS IS" BASIS,
 WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 See the License for the specific language governing permissions and
 limitations under the License.
 */

namespace Microsoft.WindowsAzure.Build.Tasks
{
    using System;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.IO.Compression;

    public class BuildProjectTemplatesTask : Task
    {
        /// <summary>
        /// list of directories that contain template data
        /// </summary>
        IEnumerable<string> TemplateDirList;

        /// <summary>
        /// Directory path where the templates will be copied after build
        /// </summary>
        public string TemplateBuildOutputDirPath { get; set; }

        /// <summary>
        /// True: If errors were detected during execution of task
        /// False: If no errors were detected during task execution
        /// </summary>
        [Output]
        public bool TaskErrorDetected { get; private set; }

        /// <summary>
        /// Initialize data
        /// </summary>
        private void Init()
        {
            TaskErrorDetected = false;
            TemplateDirList = new List<string> { @"AutoRest-AzureDotNetSDK", @"AzureDotNetSDK-TestProject" };
            if (!Directory.Exists(TemplateBuildOutputDirPath))
            {
                TemplateBuildOutputDirPath = Environment.GetEnvironmentVariable("Temp");
            }
        }

        /// <summary>
        /// Execute Build Template task
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            try
            {
                Init();
                string projTemplateBaseDir = Path.Combine(Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), "projectTemplates");
                foreach (string templateDir in TemplateDirList)
                {
                    string autoRestTemplateDir = Path.Combine(projTemplateBaseDir, templateDir);
                    string zipTemplateFile = Path.GetFullPath(Path.Combine(TemplateBuildOutputDirPath, string.Concat(templateDir, ".zip")));
                    if (File.Exists(zipTemplateFile))
                    {
                        File.Delete(zipTemplateFile);
                    }

                    ZipFile.CreateFromDirectory(autoRestTemplateDir, zipTemplateFile);
                    Log.LogMessage("Successfully build and copied {0} template to '{1}'", templateDir, zipTemplateFile);
                }
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex);
                TaskErrorDetected = true;
            }
            return true;
        }
    }
}
