// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.LocationFinder
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class LocationFinderClient : ILocationFinderClient
    {
        private const string RegionPrefix = "CAPABILITY_REGION_";
        private const string IaasRegionPrefix = "CAPABILITY_IAAS_REGION_";
        private readonly IHDInsightSubscriptionCredentials credentials;
        private readonly IAbstractionContext context;
        private readonly bool ignoreSslErrors;

        internal LocationFinderClient(IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors)
        {
            this.context = context;
            this.ignoreSslErrors = ignoreSslErrors;
            this.credentials = credentials;
        }

        public async Task<Collection<string>> ListAvailableLocations()
        {
            // Creates an HTTP client
            var client = ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>().Create(this.credentials, this.context, this.ignoreSslErrors);

            var capabilities = await client.GetResourceProviderProperties();
            return this.ListAvailableLocations(capabilities);
        }

        public async Task<Collection<string>> ListAvailableIaasLocations()
        {
            // Creates an HTTP client
            var client = ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>().Create(this.credentials, this.context, this.ignoreSslErrors);

            var capabilities = await client.GetResourceProviderProperties();
            return this.ListAvailableIaasLocations(capabilities);
        }

        public Collection<string> ListAvailableLocations(IEnumerable<KeyValuePair<string, string>> capabilities)
        {
            if (capabilities.IsNull())
            {
                throw new ArgumentNullException("capabilities");
            }

            return ParseLocations(capabilities, RegionPrefix);
        }

        public Collection<string> ListAvailableIaasLocations(IEnumerable<KeyValuePair<string, string>> capabilities)
        {
            if (capabilities.IsNull())
            {
                throw new ArgumentNullException("capabilities");
            }

            return ParseLocations(capabilities, IaasRegionPrefix);
        }

        internal static Collection<string> ParseLocations(IEnumerable<KeyValuePair<string, string>> capabilities, string regionCapabilityPrefix)
        {
            var supportedLocations = from capability in capabilities
                                     where capability.Key.StartsWith(regionCapabilityPrefix, StringComparison.OrdinalIgnoreCase)
                                     select capability.Value;

            return new Collection<string>(supportedLocations.ToList());
        }
    }
}