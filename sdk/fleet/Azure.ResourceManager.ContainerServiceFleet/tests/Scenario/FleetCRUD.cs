// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ContainerServiceFleet.Models;
using Azure.ResourceManager.ContainerService;
using Azure.ResourceManager.Resources.Models;
using System.Security.AccessControl;
using System;
using Azure.ResourceManager.Models;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ContainerService.Models;
using System.Drawing;

namespace Azure.ResourceManager.ContainerServiceFleet.Tests.Scenario
{
    [TestFixture]
    public class FleetCRUD : ContainerServiceFleetManagementTestBase
    {
        public FleetCRUD() : base(true)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task FleetCRUDTest()
        {
            Console.WriteLine("starting FleetCRUDTest");
            ArmClient armClient = GetArmClient();
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroup;
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = armClient.GetResourceGroupResource(resourceGroupResourceId);
            ContainerServiceFleetCollection fleetCollection = resourceGroupResource.GetContainerServiceFleets();

            string fleetName = Recording.GenerateAssetName("fleet-");
            ContainerServiceFleetData fleetData = new ContainerServiceFleetData(DefaultLocation);

            ResourceIdentifier fleetResourceId = ContainerServiceFleetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, fleetName);
            // Test Fleet operations
            ArmOperation<ContainerServiceFleetResource> createFleetLRO = await fleetCollection.CreateOrUpdateAsync(WaitUntil.Completed, fleetName, fleetData);
            ContainerServiceFleetResource fleetResource = createFleetLRO.Value;
            Console.WriteLine($"Succeeded on id: {fleetResource.Data.Id}");
            Console.WriteLine($"Created Fleet was: {fleetResource.Data}");

            // Test GetFleet
            // Test GetAllAsync - Get all fleets in RG, which should just be 1
            int fleetCount = 0;
            await foreach (ContainerServiceFleetResource item in fleetCollection.GetAllAsync())
            {
                fleetCount++;
            }
            Debug.Assert(fleetCount == 1, "Unexpected amount of fleets exist");

            // Test GetAsync
            ContainerServiceFleetResource getAsyncResult = await fleetCollection.GetAsync(fleetName);
            Debug.Assert(getAsyncResult.HasData, "GetAsync Result was not valid");

            // Test UpdateFleet
            fleetResource.Data.Tags.Add("newtag1", "newtagvalue");
            ArmOperation<ContainerServiceFleetResource> updateFleetLRO = await fleetCollection.CreateOrUpdateAsync(WaitUntil.Completed, fleetResource.Data.Name, fleetResource.Data);
            Console.WriteLine($"Succeeded on id: {updateFleetLRO.Value.Data.Id}");
            Console.WriteLine($"Updated Fleet was: {updateFleetLRO.Value.Data}");
            Debug.Assert(updateFleetLRO.Value.Data.Tags.ContainsKey("newtag1"), "new tag was not found, update failed");

            // Create a managed cluster to be able to become a Fleet Member
            ContainerServiceManagedClusterResource managedCluster = await CreateContainerServiceAsync(resourceGroupResource, "aks-cluster", DefaultLocation);

            // Test Member operations
            ContainerServiceFleetMemberCollection memberCollection = fleetResource.GetContainerServiceFleetMembers();
            string fleetMemberName = "fleetmember1";
            ContainerServiceFleetMemberData memberData = new ContainerServiceFleetMemberData()
            {
                ClusterResourceId = new ResourceIdentifier(managedCluster.Data.Id),
            };
            ArmOperation<ContainerServiceFleetMemberResource> createMemberLRO = await memberCollection.CreateOrUpdateAsync(WaitUntil.Completed, fleetMemberName, memberData);
            ContainerServiceFleetMemberResource memberResource = createMemberLRO.Value;
            Console.WriteLine($"Succeeded on id: {createMemberLRO.Value.Data.Id}");
            Console.WriteLine($"Created FleetMember was: {memberResource.Data}");

            // Test GetFleetMember
            // Test GetAllAsync
            int fleetMemberCount = 0;
            await foreach (ContainerServiceFleetMemberResource item in memberCollection.GetAllAsync())
            {
                fleetMemberCount++;
            }
            Debug.Assert(fleetMemberCount == 1, "Unexpected amount of fleet members exist");

            // Test GetAsync
            ContainerServiceFleetMemberResource getMemberAsyncResult = await memberCollection.GetAsync(fleetMemberName);
            Debug.Assert(getMemberAsyncResult.HasData, "GetAsync Result was not valid");

            // Create UpdateRun
            ContainerServiceFleetUpdateRunCollection updateRunCollection = fleetResource.GetContainerServiceFleetUpdateRuns();
            string updateRunName = "run1";
            ContainerServiceFleetUpdateRunData updateRunData = new ContainerServiceFleetUpdateRunData();
            updateRunData.ManagedClusterUpdate = new ContainerServiceFleetManagedClusterUpdate(
                new ContainerServiceFleetManagedClusterUpgradeSpec(ContainerServiceFleetManagedClusterUpgradeType.Full, "1.26.1", null), new NodeImageSelection(NodeImageSelectionType.Latest), null);

            ArmOperation<ContainerServiceFleetUpdateRunResource> createUpdateRunLRO = await updateRunCollection.CreateOrUpdateAsync(WaitUntil.Completed, updateRunName, updateRunData);
            ContainerServiceFleetUpdateRunResource updateRunResource = createUpdateRunLRO.Value;
            Debug.Assert(updateRunResource.HasData, "No UpdateRunData found");
            Console.WriteLine($"Succeeded on id: {updateRunResource.Data.Id}");

            // Get UpdateRun
            ContainerServiceFleetUpdateRunResource getUpdateRun = await updateRunResource.GetAsync();
            Console.WriteLine($"Succeeded on id: {getUpdateRun.Data.Id}");

            // Start UpdateRun
            ArmOperation<ContainerServiceFleetUpdateRunResource> startUpdateRunLRO = await updateRunResource.StartAsync(WaitUntil.Completed);
            Console.WriteLine($"Succeeded on id: {startUpdateRunLRO.Value.Data.Id}");

            // Stop UpdateRun
            ArmOperation<ContainerServiceFleetUpdateRunResource> stopUpdateRunLRO = await updateRunResource.StopAsync(WaitUntil.Completed);
            Console.WriteLine($"Succeeded on id: {stopUpdateRunLRO.Value.Data.Id}");

            // Delete UpdateRun
            await updateRunResource.DeleteAsync(WaitUntil.Completed);
            bool doesUpdateRunExist = await updateRunCollection.ExistsAsync(updateRunName);
            Debug.Assert(doesUpdateRunExist == false, "UpdateRun was not deleted.");

            // Delete Member
            // Wait for ManagedCluster to be in Succeeded State in order to delete Member
            int tryCount = 0;
            int maxTries = 10;
            managedCluster = await managedCluster.GetAsync(); // refresh data
            Console.WriteLine($"Provisining state was : {managedCluster.Data.ProvisioningState}");
            while (managedCluster.Data.ProvisioningState != "Succeeded" && tryCount < maxTries)
            {
                managedCluster = await managedCluster.GetAsync();
                System.Threading.Thread.Sleep(Mode == RecordedTestMode.Record ? 60000 : 10);
                tryCount++;
                Console.WriteLine($"Provisining state was : {managedCluster.Data.ProvisioningState}");
            }
            Debug.Assert(tryCount < maxTries, "Took too long to wait for ManagedCluster to be in Succeeded state.");

            await memberResource.DeleteAsync(WaitUntil.Completed);
            bool doesMemberExist = await memberCollection.ExistsAsync(fleetMemberName);
            Debug.Assert(doesMemberExist == false, "FleetMember was not deleted.");

            // Delete Fleet
            await fleetResource.DeleteAsync(WaitUntil.Completed);
            bool doesFleetExist = await fleetCollection.ExistsAsync(fleetName);
            Debug.Assert(doesFleetExist == false, "Fleet of was not deleted.");

            // Delete ManagedCluster
            await managedCluster.DeleteAsync(WaitUntil.Completed);
        }
    }
}
