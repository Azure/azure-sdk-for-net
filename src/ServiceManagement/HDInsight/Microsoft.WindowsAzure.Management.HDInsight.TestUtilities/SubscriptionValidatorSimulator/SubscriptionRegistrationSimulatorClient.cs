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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.RestSimulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.AzureManagementClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    internal class SubscriptionRegistrationSimulatorClient : ISubscriptionRegistrationClient
    {
        private static Dictionary<Guid, List<string>> subcriptions;
        private static readonly object locker = new object();
        private IHDInsightCertificateCredential credentials;
        private readonly IAbstractionContext context;

        public SubscriptionRegistrationSimulatorClient(IHDInsightCertificateCredential creds, IAbstractionContext context)
        {
            this.context = context;
            lock (locker)
            {
                if (subcriptions == null)
                {
                    subcriptions = new Dictionary<Guid, List<string>>();
                    subcriptions.Add(IntegrationTestBase.GetValidCredentials().SubscriptionId, new List<string> { "East US 2" });
                }
            }

            this.credentials = creds;
        }

        public async Task RegisterSubscription()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            lock (locker)
            {
                if (!subcriptions.ContainsKey(credentials.SubscriptionId))
                {
                    subcriptions.Add(credentials.SubscriptionId, new List<string>());
                }
            }
        }

        public async Task<bool> ValidateSubscriptionLocation(string location)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            lock (locker)
            {
                List<string> registeredLocations;
                if (!subcriptions.TryGetValue(credentials.SubscriptionId, out registeredLocations))
                    return false;

                return registeredLocations.Any(registeredLocation => string.Equals(registeredLocation, location));
            }
        }

        public async Task RegisterSubscriptionLocation(string location)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            lock (locker)
            {
                List<string> registeredLocations;
                if (!subcriptions.TryGetValue(credentials.SubscriptionId, out registeredLocations))
                    throw new InvalidOperationException("Invalid subscription");

                if (!registeredLocations.Any(registeredLocation => string.Equals(registeredLocation, location)))
                {
                    registeredLocations.Add(location);
                }
            }
        }

        public async Task UnregisterSubscriptionLocation(string location)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            lock (locker)
            {
                var managementClient = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().Create(this.credentials, IntegrationTestBase.GetAbstractionContext(), false);
                var payload = managementClient.ListCloudServices().WaitForResult();
                var clusters = new PayloadConverter().DeserializeListContainersResult(payload.Content, this.credentials.DeploymentNamespace, this.credentials.SubscriptionId);
                if (clusters.Any(cluster => cluster.Location == location))
                {
                    throw new InvalidOperationException("Cannot unregister a subscription location if it contains clusters");
                }

                List<string> registeredLocations;
                if (!subcriptions.TryGetValue(credentials.SubscriptionId, out registeredLocations))
                    throw new InvalidOperationException("Invalid subscription");

                // The service doesn't fail if the location wasn't registered
                if (!registeredLocations.Any(registeredLocation => string.Equals(registeredLocation, location)))
                {
                    var resolver = ServiceLocator.Instance.Locate<ICloudServiceNameResolver>();
                    string regionCloudServicename = resolver.GetCloudServiceName(this.credentials.SubscriptionId,
                                                                                 this.credentials.DeploymentNamespace,
                                                                                 location);

                    throw new HttpLayerException(
                        HttpStatusCode.NotFound,
                        string.Format("The cloud service with name {0} was not found.", regionCloudServicename));
                }

                registeredLocations.Remove(registeredLocations.First(registeredLocation => string.Equals(registeredLocation, location)));
            }
        }

    }
}