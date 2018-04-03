// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Sdk.Build.Tasks.BaseTasks
{
    using Microsoft.Azure.Sdk.Build.Tasks.Models;
    using Microsoft.Build.Framework;
    using Microsoft.WindowsAzure.Build.Tasks.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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



        public static List<SdkProjectMetaData> FilterCategorizedProjects(ITaskItem[] filterProjectOn, bool filterSdkProjectsOnly = true)
        {
            IEnumerable<SdkProjectMetaData> filteredNetFxFull;
            IEnumerable<SdkProjectMetaData> distinctList = new List<SdkProjectMetaData>();
            if (CategorizedProjects != null)
            {
                var filtered = CategorizedProjects.Where((cat) => filterProjectOn.Any<ITaskItem>((fil) => fil.ItemSpec.Equals(cat.FullProjectPath, StringComparison.OrdinalIgnoreCase)));

                if (filterSdkProjectsOnly == true)
                {
                    filteredNetFxFull = filtered.Where((f) => f.FxMoniker.Equals(TargetFrameworkMoniker.net452) && (f.ProjectType == SdkProjctType.Sdk));
                }
                else
                {
                    filteredNetFxFull = filtered.Where((f) => f.FxMoniker.Equals(TargetFrameworkMoniker.net452));
                }

                distinctList = filteredNetFxFull.Distinct<SdkProjectMetaData>(new ObjectComparer<SdkProjectMetaData>((l, r) => l.FullProjectPath.Equals(r.FullProjectPath, StringComparison.OrdinalIgnoreCase)));

            }

            return distinctList?.ToList<SdkProjectMetaData>();
        }
    }
}
