// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ExtendedLocations.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ExtendedLocations.Tests
{
    public class CustomLocationOperationTests : ExtendedLocationsManagementTestBase
    {
        public CustomLocationOperationTests(bool isAsync)
                    : base(isAsync, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private CustomLocationCollection LocationCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            LocationCollection = ResourceGroup.GetCustomLocations();
        }

        [Test]
        [Ignore("Host resource region does not match Custom Location region")]
        public async Task TestOperationsCustomLocation()
        {
            await SetCollectionsAsync();
            // Refer to this page to create a hybrid K8s https://docs.microsoft.com/en-us/rest/api/hybridkubernetes/connected-cluster/create?tabs=HTTP
            string AnsibleTest = "/subscriptions/"+ DefaultSubscription.Data.SubscriptionId + "/resourceGroups/sdktestrg/providers/Microsoft.Kubernetes/connectedClusters/cle2edfkapconnectedcluster/providers/Microsoft.KubernetesConfiguration/extensions/cli-test-operator-ansible";
            string CassandraTest = "/subscriptions/"+ DefaultSubscription.Data.SubscriptionId + "/resourceGroups/sdktestrg/providers/Microsoft.Kubernetes/connectedClusters/cle2edfkapconnectedcluster/providers/Microsoft.KubernetesConfiguration/extensions/cli-test-operator";

            // CREATE CL
            var resourceName = Recording.GenerateAssetName("cltest-");
            var parameters = new CustomLocationData(DefaultLocation)
            {
                HostResourceId = new ResourceIdentifier("/subscriptions/" + DefaultSubscription.Data.SubscriptionId + "/resourceGroups/sdktestrg/providers/Microsoft.Kubernetes/connectedClusters/cle2edfkapconnectedcluster"),
                ClusterExtensionIds = { new ResourceIdentifier(CassandraTest) },
                HostType = CustomLocationHostType.Kubernetes,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Namespace = Recording.GenerateAssetName("clnamespace-"),
                DisplayName = Recording.GenerateAssetName("cltest-"),
                Authentication = null
            };
            var customLocation = (await LocationCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, parameters)).Value;

            Assert.AreEqual(customLocation.Data.DisplayName, resourceName);
            Assert.AreEqual(customLocation.Data.ProvisioningState, "Succeeded");
            Assert.IsFalse(String.IsNullOrEmpty(customLocation.Data.Identity.PrincipalId.ToString()));
            Assert.AreEqual(customLocation.Data.Identity.ManagedServiceIdentityType, ManagedServiceIdentityType.SystemAssigned);

            // GET ON CREATED CL
            customLocation = await LocationCollection.GetAsync(resourceName);
            Assert.AreEqual(customLocation.Data.DisplayName, resourceName);

            // PATCH CL
            var patchData = new CustomLocationPatch()
            {
                Tags = { { "newkey", "newvalue"} }
            };
            customLocation = await customLocation.UpdateAsync(patchData);
            customLocation = await customLocation.GetAsync();
            Assert.AreEqual(CassandraTest, customLocation.Data.ClusterExtensionIds[0].ToString());
            Assert.AreEqual(AnsibleTest, customLocation.Data.ClusterExtensionIds[1].ToString());

            // LIST BY SUBSCRIPTION
            var listResult = await DefaultSubscription.GetCustomLocationsAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(listResult.Count, 1);

            // LIST BY RESOURCE GROUP
            listResult = await LocationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(listResult.Count, 1);

            // DELETE CREATED CL
            await customLocation.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await LocationCollection.ExistsAsync(resourceName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
