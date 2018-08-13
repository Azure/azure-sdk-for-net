using Microsoft.Azure.Sdk.Build.ExecProcess;
using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages
{
    public class CleanPackagesTask : NetSdkTask
    {
        #region fields
        List<string> packageToBeCleaned;
        int testCount;
        #endregion

        protected override INetSdkTask TaskInstance => this;

        public override string NetSdkTaskName => "CleanPackagesTask";

        [Required]
        public string[] PackageReferences { get; set; }

        public string[] RestoreCacheLocations { get; set; }

        public string PackageSearchPattern { get; set; }

        public bool DebugTrace { get; set; }

        public bool WhatIf { get; set; }

        public bool DebugMode { get; set; }


        public CleanPackagesTask()
        {
            packageToBeCleaned = new List<string>();
            testCount = 1;
        }

        /// <summary>
        /// Deletes packages from known nuget cache location
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            //InitExecute(DebugTrace, DebugMode);

            this.DebugTraceEnabled = DebugTrace;

            packageToBeCleaned?.AddRange(PackageReferences);

            List<string> localCacheLocations = new NugetExec().GetRestoreCacheLocation();

            if (RestoreCacheLocations != null)
            {
                localCacheLocations.AddRange(RestoreCacheLocations);
            }

            if(!string.IsNullOrEmpty(PackageSearchPattern))
            {
                packageToBeCleaned.Add(PackageSearchPattern);
            }

            if(localCacheLocations.Any<string>())
            {
                Task[] delTsks = new Task[localCacheLocations.Count];
                int tskCount = 0;

                localCacheLocations.ForEach((cl) =>
                {
                    //TaskLogger.LogDebugInfo("Checking {0}", cl);
                    delTsks[tskCount] = Task.Run(async () => await CleanRestoredPackagesAsync(cl));
                    tskCount++;
                });

                Task.WaitAll(delTsks);

                TaskLogger.LogDebugInfo("Cleaning of Packages completed.....");
            }

            return true;
        }

        private async Task CleanRestoredPackagesAsync(string cacheLocationDirPath)
        {
            //await Task.Run(() =>
            //{
            if (Directory.Exists(cacheLocationDirPath))
            {
                TaskLogger.LogDebugInfo("Checking {0}", cacheLocationDirPath);

                foreach (string pkgName in packageToBeCleaned)
                {   
                    try
                    {
                        if (pkgName.Contains("*") || pkgName.Contains("?"))
                        {
                            var pkgSearchDirs = Directory.EnumerateDirectories(cacheLocationDirPath, pkgName, SearchOption.TopDirectoryOnly);

                            if (pkgSearchDirs.Any<string>())
                            {
                                TaskLogger.LogDebugInfo("Found {0} package(s) under {1}", pkgSearchDirs.Count<string>().ToString(), cacheLocationDirPath);
                            }

                            foreach (string dirWithPkg in pkgSearchDirs)
                            {
                                await DeleteDirAsync(dirWithPkg);
                            }
                        }
                        else
                        {
                            await DeleteDirAsync(Path.Combine(cacheLocationDirPath, pkgName));
                        }
                    }
                    catch (Exception ex)
                    {
                        TaskLogger.LogInfo(ex.ToString());
                    }
                }
            }
        }
            //});
        

        private async Task DeleteDirAsync(string dirToBeDeletedFullPath)
        {
            if(WhatIf)
            {
                //if (testCount == 4)
                //{
                //    await Task.Delay(TimeSpan.FromSeconds(15));
                //}

                if (Directory.Exists(dirToBeDeletedFullPath))
                {
                    TaskLogger.LogInfo("** Would be deleted {0}", dirToBeDeletedFullPath);
                }
            }
            else
            {   
                if (Directory.Exists(dirToBeDeletedFullPath))
                {
                    TaskLogger.LogDebugInfo("Cleaning {0}", dirToBeDeletedFullPath);
                    await Task.Run(() => Directory.Delete(dirToBeDeletedFullPath, true));
                }
            }

            testCount++;
        }
    }
}
