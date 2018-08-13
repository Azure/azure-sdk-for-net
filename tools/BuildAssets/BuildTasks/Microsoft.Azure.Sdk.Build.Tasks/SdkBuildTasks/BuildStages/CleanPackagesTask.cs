using Microsoft.Azure.Sdk.Build.ExecProcess;
using Microsoft.Azure.Sdk.Build.Tasks.BaseTasks;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Sdk.Build.Tasks.BuildStages
{
    public class CleanPackagesTask : NetSdkTask
    {
        protected override INetSdkTask TaskInstance => this;

        public override string NetSdkTaskName => "CleanPackagesTask";

        [Required]
        public string[] PackageReferenceList { get; set; }

        public string[] RestoreCacheLocations { get; set; }

        public bool DebugTrace { get; set; }


        public override bool Execute()
        {
            this.DebugTraceEnabled = DebugTrace;
            List<string> localCacheLocations = new NugetExec().GetRestoreCacheLocation();

            if (RestoreCacheLocations != null)
            {
                localCacheLocations.AddRange(RestoreCacheLocations);
                //RestoreCacheLocations = new NugetExec().GetRestoreCacheLocation();
            }

            if(localCacheLocations.Any<string>())
            {
                Task[] delTsks = new Task[localCacheLocations.Count];
                int tskCount = 0;

                localCacheLocations.ForEach((cl) =>
                {
                    TaskLogger.LogDebugInfo("Checking {0}", cl);
                    delTsks[tskCount] = Task.Run(async () => await CleanRestoredPackagesAsync(cl));
                    tskCount++;
                });

                Task.WaitAll(delTsks);
            }

            //localCacheLocations.ForEach((cacheLoc) => Task.Run(() => CleanRestoredPackagesAsync(cacheLoc)));
            //localCacheLocations.ForEach((cachLoc) => CleanRestoredPackages(cachLoc));
            return true;
        }

        private async Task CleanRestoredPackagesAsync(string cacheLocationDirPath)
        {
            await Task.Run(() =>
            {
                if (Directory.Exists(cacheLocationDirPath))
                {
                    foreach (string pkgName in PackageReferenceList)
                    {
                        try
                        {
                            string fullPkgPath = Path.Combine(cacheLocationDirPath, pkgName);
                            //TaskLogger.LogInfo("Checking {0} from {1}", pkgName, cacheLocationDirPath);

                            if (Directory.Exists(fullPkgPath))
                            {
                                TaskLogger.LogDebugInfo("Cleaning {0} from {1}", pkgName, cacheLocationDirPath);
                                Directory.Delete(fullPkgPath, true);
                            }

                        }
                        catch (Exception ex)
                        {
                            TaskLogger.LogInfo(ex.ToString());
                        }
                    }
                }
            });
        }
    }
}
