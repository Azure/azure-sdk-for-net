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
        public List<string> PackageReferenceList { get; set; }


        public override bool Execute()
        {
            List<string> localCacheLocations = new NugetExec().GetRestoreCacheLocation();
            localCacheLocations.ForEach((cachLoc) => CleanRestoredPackages(cachLoc));
            return true;
        }

        private List<string> GetNugetCacheLocation()
        {
            return new NugetExec().GetRestoreCacheLocation();
        }

        private void CleanRestoredPackages(string cacheLocationDirPath)
        {
            if (Directory.Exists(cacheLocationDirPath))
            {
                foreach (string pkgName in PackageReferenceList)
                {
                    try
                    {
                        string fullPkgPath = Path.Combine(cacheLocationDirPath, pkgName);

                        if (Directory.Exists(fullPkgPath))
                        {
                            Directory.Delete(fullPkgPath, true);
                        }

                    }
                    catch (Exception ex)
                    {
                        TaskLogger.LogInfo(ex.ToString());
                    }
                }
            }
        }
    }
}
