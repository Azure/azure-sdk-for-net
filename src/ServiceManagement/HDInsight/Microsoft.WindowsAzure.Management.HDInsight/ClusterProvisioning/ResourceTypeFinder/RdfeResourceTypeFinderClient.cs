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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ResourceTypeFinder
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.ClustersResource;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class RdfeResourceTypeFinderClient : IRdfeResourceTypeFinderClient
    {
        private readonly IRdfeClustersResourceRestClient rdfeRestClient;
        private readonly IHDInsightSubscriptionCredentials credentials;
        private readonly IAbstractionContext context;

        public RdfeResourceTypeFinderClient(IHDInsightSubscriptionCredentials credentials, IAbstractionContext context, bool ignoreSslErrors, string schemaVersion)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.context = context;
            this.credentials = credentials;
            this.rdfeRestClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(credentials, context, ignoreSslErrors, schemaVersion);
        }

        /// <summary>
        /// Gets the resource type for cluster.
        /// </summary>
        /// <param name="dnsName">Name of the DNS.</param>
        /// <returns>
        /// An RdfeResourceType.
        /// </returns>
        public async Task<RdfeResourceType> GetResourceTypeForCluster(string dnsName)
        {
            var services =
                await
                this.rdfeRestClient.ListCloudServicesAsync(
                    this.credentials.SubscriptionId.ToString(), this.context.CancellationToken);

            foreach (var service in services)
            {
                foreach (var resource in service.Resources)
                {
                    if (resource.Name.Equals(dnsName, StringComparison.OrdinalIgnoreCase))
                    {
                        switch (resource.Type.ToUpperInvariant())
                        {
                            case "CONTAINERS":
                                return RdfeResourceType.Containers;
                            case "CLUSTERS":
                                return RdfeResourceType.Clusters;
                            case "IAASCLUSTERS":
                                return RdfeResourceType.IaasClusters;
                            default:
                                return RdfeResourceType.Unknown;
                        }
                    }
                }
            }

            return RdfeResourceType.Unknown;
        }
    }
}
