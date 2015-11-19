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

using Hyak.Common;
using System.Collections.Generic;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// This class handles mapping management client types
    /// to the corresponding required resource provider names.
    /// </summary>
    internal static class RequiredResourceLookup
    {
        private const string BatchProviderNamespace = "microsoft.batch";
        private const string CacheProviderNamespace = "microsoft.cache";
        private const string ComputeProviderNamespace = "Microsoft.Compute";
        private const string DataFactoryProviderNamespace = "Microsoft.DataFactory";
        private const string InsightsProviderNamespace = "microsoft.insights";
        private const string KeyVaultProviderNamespace = "Microsoft.KeyVault";
        private const string NetworkProviderNamespace = "Microsoft.Network";
        private const string StorageProviderNamespace = "Microsoft.Storage";
        private const string WebAppProviderNamespace = "Microsoft.Web";

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
                    CacheProviderNamespace,
                    ComputeProviderNamespace,
                    InsightsProviderNamespace,
                    KeyVaultProviderNamespace,
                    NetworkProviderNamespace,
                    StorageProviderNamespace,
                    WebAppProviderNamespace
                };
            }
            if (typeof(T).FullName.EndsWith("BatchManagementClient"))
            {
                return new[] { BatchProviderNamespace };
            }

            if (typeof(T).FullName.Equals("Microsoft.Azure.Management.Compute.ComputeManagementClient"))
            {
                return new[] { ComputeProviderNamespace };
            }

            if (typeof(T).FullName.Equals("Microsoft.Azure.Management.Dns.DnsManagementClient"))
            {
                return new[] { NetworkProviderNamespace };
            }

            if (typeof(T).FullName.EndsWith("DataFactoryManagementClient"))
            {
                return new[] { DataFactoryProviderNamespace };
            }

            if (typeof(T).FullName.Equals("Microsoft.Azure.Management.Network.NetworkResourceProviderClient"))
            {
                return new[] { NetworkProviderNamespace };
            }

            if (typeof(T).FullName.Equals("Microsoft.Azure.Management.Storage.StorageManagementClient"))
            {
                return new[] { StorageProviderNamespace };
            }

            return new string[0];
        }
    }
}
