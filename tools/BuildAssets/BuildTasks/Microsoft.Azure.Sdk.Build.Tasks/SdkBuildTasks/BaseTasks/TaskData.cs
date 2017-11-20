using Microsoft.Azure.Sdk.Build.Tasks.Models;
using Microsoft.Build.Framework;
using Microsoft.WindowsAzure.Build.Tasks.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Sdk.Build.Tasks.BaseTasks
{
    public static class TaskData
    {
        //private List<SdkProjectMetaData> _categorizedProjects;

        public static List<SdkProjectMetaData> CategorizedProjects { get; set; }


        static TaskData()
        {
            //AppDomain ad = AppDomain.CurrentDomain;

            //ad.ReflectionOnlyAssemblyResolve += Ad_ReflectionOnlyAssemblyResolve;
            //ad.AssemblyResolve += Ad_AssemblyResolve;
        }

        

        public static List<SdkProjectMetaData> FilterCategorizedProjects(ITaskItem[] filterProjectOn)
        {
            //IEnumerable<SdkProjectMetaData> distinctList = new List<SdkProjectMetaData>();
            //if (filterProjectOn.Any<ITaskItem>())
            //{
                var filtered = CategorizedProjects.Where((cat) => filterProjectOn.Any<ITaskItem>((fil) => fil.ItemSpec.Equals(cat.FullProjectPath, StringComparison.OrdinalIgnoreCase)));
                var filteredNetFxFull = filtered.Where((f) => f.FxMoniker.Equals(TargetFrameworkMoniker.net452));
                var distinctList = filteredNetFxFull.Distinct<SdkProjectMetaData>(new ObjectComparer<SdkProjectMetaData>((l, r) => l.FullProjectPath.Equals(r.FullProjectPath, StringComparison.OrdinalIgnoreCase)));
            //}

            return distinctList?.ToList<SdkProjectMetaData>();
        }
    }
}
