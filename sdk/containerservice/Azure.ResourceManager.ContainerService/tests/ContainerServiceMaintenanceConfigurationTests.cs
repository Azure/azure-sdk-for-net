// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerService.Tests
{
    public class ContainerServiceMaintenanceConfigurationTests : ContainerServiceManagementTestBase
    {
        public ContainerServiceMaintenanceConfigurationTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testaksrg", AzureLocation.EastUS);
            var clusterCollection = rg.GetContainerServiceManagedClusters();
            string clusterName = Recording.GenerateAssetName("akscluster");
            // Create
            var lro = await CreateContainerServiceAsync(WaitUntil.Completed, rg, clusterName, rg.Data.Location);

            ContainerServiceManagedClusterResource cluster = lro.Value;
            Assert.AreEqual(clusterName, cluster.Data.Name);
            Assert.AreEqual(DnsPrefix, cluster.Data.DnsPrefix);
            var maintenanceConfigCollection = cluster.GetContainerServiceMaintenanceConfigurations();
            var configLro = await maintenanceConfigCollection.CreateOrUpdateAsync(WaitUntil.Completed, "default", new ContainerServiceMaintenanceConfigurationData()
            {
                TimesInWeek = { new ContainerServiceTimeInWeek()
                    {
                        Day = ContainerServiceWeekDay.Monday,
                        HourSlots = { 1 }
                    }
                }
            });
            ContainerServiceMaintenanceConfigurationResource configResource = configLro.Value;
            // Delete, it's a fake LRO
            var deleteLro = await configResource.DeleteAsync(WaitUntil.Started);
            var deleteRehydration = new ContainerServiceArmOperationRehydration(Client, deleteLro.Id);
            var deleteRehydratedLro = await deleteRehydration.RehydrateAsync(WaitUntil.Completed);
            await deleteRehydratedLro.WaitForCompletionResponseAsync(CancellationToken.None).ConfigureAwait(false);
            Assert.AreEqual(deleteRehydratedLro.HasCompleted, true);
        }
    }
}
