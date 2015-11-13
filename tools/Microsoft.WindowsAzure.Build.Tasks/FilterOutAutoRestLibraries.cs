﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    public class FilterOutAutoRestLibraries : Task
    {
        [Required]
        public ITaskItem[] AllLibraries { get; set; }

        [Required]
        public string AutoRestMark { get; set; }

        [Output]
        public ITaskItem[] AutoRestLibraries { get; private set; }

        [Output]
        public ITaskItem[] NonAutoRestLibraries { get; private set; }

        [Output]
        public ITaskItem[] DnxLibraries { get; private set; }

        public override bool Execute()
        {
            var autoRestOnes = new List<ITaskItem>();
            var dnxLibraryOnes = new List<ITaskItem>();
            var dnxLibraryTestOnes = new List<ITaskItem>();
            var others =  new List<ITaskItem>();
            foreach (ITaskItem solution in AllLibraries)
            {
                bool isAutoRestLibrary = false;
                string solutionFile = solution.GetMetadata("FullPath");
                string libFolder = Path.GetDirectoryName(solutionFile);
                string[] csProjects = Directory.GetFiles(libFolder, "*.csproj", SearchOption.AllDirectories);
                foreach (string project in csProjects)
                {
                    string text = File.ReadAllText(project);
                    if (text.Contains(AutoRestMark))
                    {
                        isAutoRestLibrary = true;
                        break;
                    }
                }
                if (isAutoRestLibrary)
                {
                    autoRestOnes.Add(solution);
                }
                else
                {
                    string[] dnxProjectJsonFiles = Directory.GetFiles(libFolder, "project.json", SearchOption.AllDirectories);
                    if (dnxProjectJsonFiles.Length != 0)
                    {
                        dnxLibraryOnes.Add(solution);
                        foreach (var file in dnxProjectJsonFiles)
                        {
                            string dir = Path.GetDirectoryName(file);
                            if (dir.EndsWith("test", System.StringComparison.OrdinalIgnoreCase) ||
                                dir.EndsWith("tests", System.StringComparison.OrdinalIgnoreCase))
                            {
                                solution.SetMetadata("Test", dir);
                            }
                            else
                            {
                                solution.SetMetadata("Library", dir);
                            }
                        }
                    }
                    else
                    {
                        others.Add(solution);
                    }
                }
            }

            Log.LogMessage(MessageImportance.High, "We have found {0} autorest libraries.", autoRestOnes.Count);
            Log.LogMessage(MessageImportance.High, "we have found {0} Non autorest libraries.", others.Count);
            AutoRestLibraries = autoRestOnes.ToArray();
            DnxLibraries = dnxLibraryOnes.ToArray();
            NonAutoRestLibraries = others.ToArray();
            return true;
        }
    }
}
