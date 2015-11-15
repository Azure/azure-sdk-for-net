//
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
        public ITaskItem[] Non_Dnx_AutoRestLibraries { get; private set; }

        [Output]
        public ITaskItem[] NonAutoRestLibraries { get; private set; }

        [Output]
        public ITaskItem[] Dnx_AutoRestLibraries { get; private set; }

        public override bool Execute()
        {
            var nonDnxAutoRestLibraries = new List<ITaskItem>();
            var dnxAutoRestLibraries = new List<ITaskItem>();
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
                    string[] nugetProjects = Directory.GetFiles(libFolder, "*.nuget.proj", SearchOption.AllDirectories);
                    if (nugetProjects.Length > 1)
                    {
                        throw new System.InvalidOperationException("We are not able to handle more than 1 nuget projects from the same library");
                    }
                    if (nugetProjects.Length == 0)
                    {
                        solution.SetMetadata("NugetProj", nugetProjects[0]);
                        solution.SetMetadata("PackageName", Path.GetFileNameWithoutExtension(nugetProjects[0]));
                    }
                    nonDnxAutoRestLibraries.Add(solution);
                }
                else
                {
                    string[] dnxProjectJsonFiles = Directory.GetFiles(libFolder, "project.json", SearchOption.AllDirectories);
                    if (dnxProjectJsonFiles.Length != 0 )
                    {
                        var libDirectories = new List<string>();
                        var testDirectories = new List<string>();

                        foreach (var file in dnxProjectJsonFiles)
                        {
                            string dir = Path.GetDirectoryName(file);
                            if (dir.EndsWith(".test", System.StringComparison.OrdinalIgnoreCase) ||
                                dir.EndsWith(".tests", System.StringComparison.OrdinalIgnoreCase))
                            {
                                testDirectories.Add(dir);
                            }
                            else
                            {
                                libDirectories.Add(dir);
                            }
                        }

                        for(int i = 0; i < libDirectories.Count; i++)
                        {
                            TaskItem dnxLib = new TaskItem(solution);
                            dnxLib.SetMetadata("Library", libDirectories[i]);
                            dnxLib.SetMetadata("PackageName", Path.GetFileName(libDirectories[i]));
                            if (i < testDirectories.Count) {
                                //the matching might not be very accurate, but enough for now.
                                dnxLib.SetMetadata("Test", testDirectories[i]);
                            }
                            dnxAutoRestLibraries.Add(dnxLib);
                        }
                    }
                    else
                    {
                        others.Add(solution);
                    }
                }
            }

            Log.LogMessage(MessageImportance.High, "We have found {0} non dnx autorest libraries.", nonDnxAutoRestLibraries.Count);
            Log.LogMessage(MessageImportance.High, "We have found {0} dnx autorest libraries.", dnxAutoRestLibraries.Count);
            Log.LogMessage(MessageImportance.High, "we have found {0} Non autorest libraries.", others.Count);
            Non_Dnx_AutoRestLibraries = nonDnxAutoRestLibraries.ToArray();
            Dnx_AutoRestLibraries = dnxAutoRestLibraries.ToArray();
            NonAutoRestLibraries = others.ToArray();
            return true;
        }
    }
}
