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
using Azure.ResourceManager.ResourceConnector.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ResourceConnector.Tests
{
    public class ApplianceOperationTests : ResourceConnectorManagementTestBase
    {
        public ApplianceOperationTests(bool isAsync)
                    : base(isAsync, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApplianceCollection LocationCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroup();
            LocationCollection = ResourceGroup.GetAppliances();
        }

        [Test]
        public async Task TestOperationsAppliances()
        {
            await SetCollectionsAsync();
            // Refer to this page to create a hybrid K8s https://docs.microsoft.com/en-us/rest/api/hybridkubernetes/connected-cluster/create?tabs=HTTP
            // string AnsibleTest = "/subscriptions/"+ DefaultSubscription.Data.SubscriptionId + "/resourceGroups/sdktestrg/providers/Microsoft.Kubernetes/connectedClusters/cle2edfkapconnectedcluster/providers/Microsoft.KubernetesConfiguration/extensions/cli-test-operator-ansible";
            // string CassandraTest = "/subscriptions/"+ DefaultSubscription.Data.SubscriptionId + "/resourceGroups/sdktestrg/providers/Microsoft.Kubernetes/connectedClusters/cle2edfkapconnectedcluster/providers/Microsoft.KubernetesConfiguration/extensions/cli-test-operator";

            // CREATE CL
            var resourceName = Recording.GenerateAssetName("appliancetest-");
            var parameters = new ApplianceData(DefaultLocation)
            {
            };
            var appliance = (await LocationCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, parameters)).Value;

            Assert.AreEqual(appliance.Data.DisplayName, resourceName);
            Assert.AreEqual(appliance.Data.ProvisioningState, "Succeeded");
            Assert.IsFalse(String.IsNullOrEmpty(appliance.Data.Identity.PrincipalId.ToString()));
            Assert.AreEqual(appliance.Data.Identity.ManagedServiceIdentityType, ManagedServiceIdentityType.SystemAssigned);

            // GET ON CREATED CL
            appliance = await LocationCollection.GetAsync(resourceName);
            Assert.AreEqual(appliance.Data.DisplayName, resourceName);

            // PATCH CL
            var patchData = new AppliancePatch()
            {
                Tags = { { "newkey", "newvalue"} }
            };
            appliance = await appliance.UpdateAsync(patchData);
            appliance = await appliance.GetAsync();
            // Assert.AreEqual(CassandraTest, customLocation.Data.ClusterExtensionIds[0].ToString());
            // Assert.AreEqual(AnsibleTest, customLocation.Data.ClusterExtensionIds[1].ToString());
            // Assert.AreEqual(AnsibleTest, customLocation.Data.ClusterExtensionIds[1].ToString());

            // LIST BY SUBSCRIPTION
            var listResult = await DefaultSubscription.GetAppliancesAsync().ToEnumerableAsync();
            Assert.GreaterOrEqual(listResult.Count, 1);

            // LIST BY RESOURCE GROUP
            listResult = await LocationCollection.GetAppliances().ToEnumerableAsync();
            Assert.GreaterOrEqual(listResult.Count, 1);

            // DELETE CREATED CL
            await appliance.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await LocationCollection.ExistsAsync(resourceName)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
