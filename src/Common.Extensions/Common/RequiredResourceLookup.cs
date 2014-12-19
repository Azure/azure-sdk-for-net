// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Common.Extensions
{
    /// <summary>
    /// This class handles mapping management client types
    /// to the corresponding required resource provider names.
    /// </summary>
    internal static class RequiredResourceLookup
    {
        internal static IList<string> RequiredProvidersForServiceManagement<T>() where T : ServiceClient<T>
        {
            if (typeof(T).FullName.EndsWith("WebSiteManagementClient"))
            {
                return new[] { "website" };
            }

            if (typeof(T).FullName.EndsWith("ManagedCacheClient"))
            {
                return new[] { "cacheservice.Caching" };
            }

            if (typeof(T).FullName.EndsWith("SchedulerManagementClient"))
            {
                return new[] { "scheduler.jobcollections" };
            }

            return new string[0];
        }

        internal static IList<string> RequiredProvidersForResourceManager<T>() where T : ServiceClient<T>
        {
            if (typeof(T).FullName.EndsWith("ResourceManagementClient"))
            {
                return new[] {
                    "Microsoft.Web",
                    "microsoft.visualstudio",
                    "microsoft.insights",
                    "successbricks.cleardb",
                    "microsoft.cache" };
            }
            if (typeof(T).FullName.EndsWith("BatchManagementClient"))
            {
                return new[] { "microsoft.batch" };
            }
            
            if (typeof(T).FullName.EndsWith("DataPipelineManagementClient"))
            {
                return new[] { "Microsoft.DataFactory" };
            }


            return new string[0];
        }
    }
}
