// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Linq;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    public class FilterOutAutoRestLibraries : Task
    {
        [Required]
        public ITaskItem[] SdkNugetPackageInput { get; set; }

        [Required]
        public ITaskItem[] AllLibraries { get; set; }

        [Required]
        public string AutoRestMark { get; set; }

        /// <summary>
        /// Name of packages that needs to be published. Currently for ease for the user, it will be space delimited list of NetCore projects
        /// Non-NetCore projects cannot be published more than one package due to MSBuild limitation as well as our existing architecture of nuget.proj files
        /// Plus as we have very limited set of non-netCore projects, so the effort is not worth it. Worse case for publishing non-netCore projects, each job 
        /// to publish 1 package at a time
        /// 
        /// E.g. for NetCore projects /p:PackageName="PackageName1 PackageName2" string can be passed to publish PacakgeName1 and PackageName2
        /// </summary>
        public string NugetPackagesToPublish { get; set; }

        [Output]
        public ITaskItem[] Non_NetCore_AutoRestLibraries { get; private set; }

        [Output]
        public ITaskItem[] NonAutoRestLibraries { get; private set; }

        [Output]
        public ITaskItem[] NetCore_AutoRestLibraries { get; private set; }

        [Output]
        public ITaskItem[] SdkNuGetPackageOutput { get; private set; }

        public override bool Execute()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (ITaskItem sln in AllLibraries)
            {   
                sb.AppendFormat("{0},", sln.GetMetadata("FullPath"));
            }

            Log.LogMessage(MessageImportance.High, "We have found {0}", sb.ToString());

            var nonNetCoreAutoRestLibraries = new List<ITaskItem>();
            var netCoreAutoRestLibraries = new List<ITaskItem>();
            var netCoreLibraryTestOnes = new List<ITaskItem>();
            var SdkNuGetPackage = new List<ITaskItem>(); 
            var others =  new List<ITaskItem>();
            
            List<string> nPkgsList = null;
            List<string> sdkItemSpec = (from item in SdkNugetPackageInput select item.ItemSpec).ToList<string>();

            if (!string.IsNullOrWhiteSpace(NugetPackagesToPublish))
            {
                nPkgsList = NugetPackagesToPublish.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            }

            if(nPkgsList != null)
            {
                List<string> common = nPkgsList.Intersect<string>(sdkItemSpec).ToList<string>();
                foreach(string projName in common)
                {
                    ITaskItem nProj = SdkNugetPackageInput.Where<ITaskItem>((item) => item.ItemSpec.Equals(projName, StringComparison.OrdinalIgnoreCase)).First<ITaskItem>();
                    if (nProj != null)
                        SdkNuGetPackage.Add(nProj);
                }
            }
            else
            {
                SdkNuGetPackage = SdkNugetPackageInput.ToList<ITaskItem>();
            }

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
                    if (nugetProjects.Length == 1)
                    {
                        solution.SetMetadata("NugetProj", nugetProjects[0]);
                        solution.SetMetadata("PackageName", Path.GetFileNameWithoutExtension(nugetProjects[0]));
                    }

                    if (nPkgsList != null)
                    {
                        //We need to filter out projects from the final output to build and publish limited set of projects
                        //Here we need to get to the name of the nuget.proj file with .nuget.proj
                        string nugetProjName = Path.GetFileName(nugetProjects[0]);
                        string projNameWithoutExt = Path.GetFileNameWithoutExtension(nugetProjName);
                        projNameWithoutExt = Path.GetFileNameWithoutExtension(projNameWithoutExt);
                        string match = nPkgsList.Find((pn) => pn.Equals(projNameWithoutExt, System.StringComparison.OrdinalIgnoreCase));
                        if (!string.IsNullOrEmpty(match))
                        {
                            nonNetCoreAutoRestLibraries.Add(solution);
                        }
                    }
                    else
                    {
                        nonNetCoreAutoRestLibraries.Add(solution);
                    }
                }
                else
                {
                    string[] netCoreProjectJsonFiles = Directory.GetFiles(libFolder, "project.json", SearchOption.AllDirectories);
                    if (netCoreProjectJsonFiles.Length != 0 )
                    {
                        var libDirectories = new List<string>();
                        var testDirectories = new List<string>();

                        foreach (var file in netCoreProjectJsonFiles)
                        {
                            string dirPath = Path.GetDirectoryName(file);
                            string dirName = Path.GetFileName(dirPath);
                            if (dirPath.EndsWith(".test", System.StringComparison.OrdinalIgnoreCase) ||
                                dirPath.EndsWith(".tests", System.StringComparison.OrdinalIgnoreCase))
                            {
                                testDirectories.Add(dirPath);
                            }
                            else
                            {
                                if (nPkgsList != null)
                                {
                                    //We need to filter out projects from the final output to build and publish limited set of projects
                                    string match = nPkgsList.Find((pn) => pn.Equals(dirName, System.StringComparison.OrdinalIgnoreCase));
                                    if (!string.IsNullOrEmpty(match))
                                        libDirectories.Add(dirPath);
                                }
                                else
                                {
                                    libDirectories.Add(dirPath);
                                }
                            }
                        }

                        for(int i = 0; i < libDirectories.Count; i++)
                        {
                            TaskItem netCoreLib = new TaskItem(solution);
                            netCoreLib.SetMetadata("Library", libDirectories[i]);
                            netCoreLib.SetMetadata("PackageName", Path.GetFileName(libDirectories[i]));
                            if (i < testDirectories.Count) {
                                //the matching might not be very accurate, but enough for now.
                                netCoreLib.SetMetadata("Test", testDirectories[i]);
                            }
                            netCoreAutoRestLibraries.Add(netCoreLib);
                        }
                    }
                    else
                    {
                        others.Add(solution);
                    }
                }
            }

            if(nPkgsList != null)
            {
                if (nPkgsList.Any<string>())
                {
                    string pkgNames = string.Join(",", nPkgsList);
                    Log.LogMessage(MessageImportance.High, "Trying to publish packages: {0}", pkgNames);
                }
            }

            Log.LogMessage(MessageImportance.High, "We have found {0} non netcore autorest libraries.", nonNetCoreAutoRestLibraries.Count);
            Log.LogMessage(MessageImportance.High, "We have found {0} netcore autorest libraries.", netCoreAutoRestLibraries.Count);
            Log.LogMessage(MessageImportance.High, "We have found {0} Non autorest libraries.", others.Count);
            Log.LogMessage(MessageImportance.High, "We have found {0} SdkNuget Packages.", SdkNuGetPackage.Count);
            Non_NetCore_AutoRestLibraries = nonNetCoreAutoRestLibraries.ToArray();
            NetCore_AutoRestLibraries = netCoreAutoRestLibraries.ToArray();
            NonAutoRestLibraries = others.ToArray();
            SdkNuGetPackageOutput = SdkNuGetPackage.ToArray();
            return true;
        }
    }
}