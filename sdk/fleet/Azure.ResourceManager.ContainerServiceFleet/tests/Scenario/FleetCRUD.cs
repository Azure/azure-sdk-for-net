// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.ContainerService;
using Azure.ResourceManager.ContainerService.Models;
using Azure.ResourceManager.ContainerServiceFleet.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

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
            string clusterName = Recording.GenerateAssetName("cluster-");
            ContainerServiceManagedClusterResource managedCluster = await CreateContainerServiceAsync(resourceGroupResource, clusterName, DefaultLocation);

            // Test Member operations
            ContainerServiceFleetMemberCollection memberCollection = fleetResource.GetContainerServiceFleetMembers();
            string fleetMemberName = "fleetmember1";
            var group1 = new ContainerServiceFleetUpdateGroup("group1");
            ContainerServiceFleetMemberData memberData = new ContainerServiceFleetMemberData()
            {
                ClusterResourceId = new ResourceIdentifier(managedCluster.Data.Id),
                Group = group1.Name
            };
            memberData.Labels["team"] = "fleet";
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
            Debug.Assert(
                getMemberAsyncResult.Data.Labels != null &&
                getMemberAsyncResult.Data.Labels.TryGetValue("team", out var teamValue) &&
                teamValue == "fleet",
                "\"team\" label was missing or not equal to \"fleet\""
            );

            // Create UpdateRun
            ContainerServiceFleetUpdateRunCollection updateRunCollection = fleetResource.GetContainerServiceFleetUpdateRuns();
            string updateRunName = "run1";
            // Stage before/after gates
            var stageBeforeGate = new ContainerServiceFleetGateConfiguration(ContainerServiceFleetGateType.Approval)
            {
                DisplayName = "stage before gate"
            };

            var stageAfterGate = new ContainerServiceFleetGateConfiguration(ContainerServiceFleetGateType.Approval)
            {
                DisplayName = "stage after gate"
            };

            // Group before/after gates
            var groupBeforeGate = new ContainerServiceFleetGateConfiguration(ContainerServiceFleetGateType.Approval)
            {
                DisplayName = "group before gate"
            };

            var groupAfterGate = new ContainerServiceFleetGateConfiguration(ContainerServiceFleetGateType.Approval)
            {
                DisplayName = "group after gate"
            };

            // Create group
            group1.BeforeGates.Add(groupBeforeGate);
            group1.AfterGates.Add(groupAfterGate);

            // Create stage and attach group
            var stage1 = new ContainerServiceFleetUpdateStage("stage1")
            {
                AfterStageWaitInSeconds = 3600
            };
            stage1.BeforeGates.Add(stageBeforeGate);
            stage1.AfterGates.Add(stageAfterGate);
            stage1.Groups.Add(group1);

            // Create the update run data
            var updateRunData = new ContainerServiceFleetUpdateRunData
            {
                ManagedClusterUpdate = new ContainerServiceFleetManagedClusterUpdate(
                    new ContainerServiceFleetManagedClusterUpgradeSpec(
                        ContainerServiceFleetManagedClusterUpgradeType.Full,
                        "1.33.0", // Kubernetes version
                        null
                    ),
                    new NodeImageSelection(NodeImageSelectionType.Latest),
                    null
                ),
                StrategyStages = new List<ContainerServiceFleetUpdateStage>()
            };

            // Add stages into the update run
            updateRunData.StrategyStages.Add(stage1);

            Console.WriteLine("Fleet update run created!");

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

            // Test Gates
            // List Gates
            fleetResource = armClient.GetContainerServiceFleetResource(fleetResourceId);
            ContainerServiceFleetGateCollection gates = fleetResource.GetContainerServiceFleetGates();
            Console.WriteLine($"Listing all gates in fleet '{fleetName}'...");
            List<ContainerServiceFleetGateResource> gateList = new List<ContainerServiceFleetGateResource>();
            await foreach (ContainerServiceFleetGateResource gate in gates.GetAllAsync())
            {
                gateList.Add(gate);
                Console.WriteLine($"- Gate Name: {gate.Data.Name}");
            }
            Debug.Assert(gateList.Count > 0, "No gates were found in the fleet");
            var gateName = gateList[0].Data.Name;
            // Get Gates
            ContainerServiceFleetGateResource getGate = await gates.GetAsync(gateName);
            Debug.Assert(getGate != null, $"Gate '{gateName}' was not found.");
            // Patch Gate
            ContainerServiceFleetGatePatch patch = new ContainerServiceFleetGatePatch
            {
                GatePatchState = ContainerServiceFleetGateState.Completed
            };
            ArmOperation<ContainerServiceFleetGateResource> updateOperation = await getGate.UpdateAsync(WaitUntil.Completed, patch);
            ContainerServiceFleetGateResource updatedGate = updateOperation.Value;
            Debug.Assert(
                updatedGate.Data.State == ContainerServiceFleetGateState.Completed,
                $"Gate '{updatedGate.Data.Name}' did not reach the expected state. Actual: {updatedGate.Data.State}"
            );

            // Create AutoUpgradeProfile
            AutoUpgradeProfileCollection autoUpgradeProfileCollection = fleetResource.GetAutoUpgradeProfiles();
            string autoUpgradeProfileName = "autoupgradeprofile1";
            AutoUpgradeProfileData createAutoUpgradeProfileData = new AutoUpgradeProfileData()
            {
                Channel = ContainerServiceFleetUpgradeChannel.TargetKubernetesVersion,
                LongTermSupport = true,
                TargetKubernetesVersion = "1.30"
            };
            ArmOperation<AutoUpgradeProfileResource> createAutoUpgradeProfileLRO = await autoUpgradeProfileCollection.CreateOrUpdateAsync(WaitUntil.Completed, autoUpgradeProfileName, createAutoUpgradeProfileData);
            AutoUpgradeProfileResource createAutoUpgradeProfileResult = createAutoUpgradeProfileLRO.Value;
            Debug.Assert(createAutoUpgradeProfileResult.HasData, "CreateOrUpdateAsync AutoUpgradeProfile data was not valid");

            createAutoUpgradeProfileData = createAutoUpgradeProfileResult.Data;
            Console.WriteLine($"Succeeded on id: {createAutoUpgradeProfileData.Id}");
            Console.WriteLine($"Created AutoUpgradeProfile was: {createAutoUpgradeProfileData.Id}");

            // Get AutoUpgradeProfile
            AutoUpgradeProfileResource getAutoUpgradeProfileResult = await autoUpgradeProfileCollection.GetAsync(autoUpgradeProfileName);
            Debug.Assert(getAutoUpgradeProfileResult.HasData, "GetAsync AutoUpgradeProfile data was not valid");
            AutoUpgradeProfileData getAutoUpgradeProfileData = getAutoUpgradeProfileResult.Data;
            Console.WriteLine($"Succeeded on id: {getAutoUpgradeProfileData.Id}");
            Console.WriteLine($"Get AutoUpgradeProfile was: {getAutoUpgradeProfileData.Id}");
            Debug.Assert(getAutoUpgradeProfileData.Name == createAutoUpgradeProfileData.Name, "GetAutoUpgradeProfile did not retrieve the correct data.");
            Debug.Assert(getAutoUpgradeProfileData.Id == createAutoUpgradeProfileData.Id, "GetAutoUpgradeProfile did not retrieve the correct data.");
            Debug.Assert(getAutoUpgradeProfileData.TargetKubernetesVersion == createAutoUpgradeProfileData.TargetKubernetesVersion, "GetAutoUpgradeProfile did not retrieve the correct data.");

            // Update AutoUpgradeProfile
            AutoUpgradeProfileData updateAutoUpgradeProfileData = new AutoUpgradeProfileData()
            {
                Channel = ContainerServiceFleetUpgradeChannel.Rapid,
            };
            ArmOperation<AutoUpgradeProfileResource> updateAutoUpgradeProfileLRO = await autoUpgradeProfileCollection.CreateOrUpdateAsync(WaitUntil.Completed, autoUpgradeProfileName, updateAutoUpgradeProfileData);
            AutoUpgradeProfileResource updateAutoUpgradeProfileResult = updateAutoUpgradeProfileLRO.Value;
            Debug.Assert(updateAutoUpgradeProfileResult.HasData, "CreateOrUpdateAsync AutoUpgradeProfile data was not valid");
            Debug.Assert(updateAutoUpgradeProfileResult.Data.Channel == ContainerServiceFleetUpgradeChannel.Rapid, "CreateOrUpdateAsync AutoUpgradeProfile channel was not successfully updated.");

            // GenerateUpdateRun
            getAutoUpgradeProfileResult = await autoUpgradeProfileCollection.GetAsync(autoUpgradeProfileName);
            Debug.Assert(getAutoUpgradeProfileResult.HasData, "GetAsync AutoUpgradeProfile data was not valid");
            ArmOperation<AutoUpgradeProfileGenerateResult> generateUpdateRunLRO = await getAutoUpgradeProfileResult.GenerateUpdateRunAsync(WaitUntil.Completed);
            AutoUpgradeProfileGenerateResult generateResult = generateUpdateRunLRO.Value;
            Console.WriteLine($"GenerateUpdateRun Succeeded: {generateResult.Id}");

            // Verify and Delete the Generated UpdateRun
            string[] generateParts = generateResult.Id.Split('/');

            ContainerServiceFleetUpdateRunResource generateUpdateRunResource = await armClient
                .GetContainerServiceFleetUpdateRunResource(
                    ContainerServiceFleetUpdateRunResource.CreateResourceIdentifier(
                        generateParts[2],  // subscriptionId
                        generateParts[4],  // resourceGroupName
                        generateParts[8],  // fleetName
                        generateParts[10]  // updateRunName
                    )
                )
                .GetAsync();

            ContainerServiceFleetUpdateRunResource getGenerateUpdateRun = await generateUpdateRunResource.GetAsync();
            Console.WriteLine($"generateUpdateRunResource get Succeeded on id: {getGenerateUpdateRun.Data.Id}");

            await generateUpdateRunResource.DeleteAsync(WaitUntil.Completed);
            bool doesGenerateUpdateRunExist = await updateRunCollection.ExistsAsync(generateParts[10]);
            Debug.Assert(doesGenerateUpdateRunExist == false, "UpdateRun was not deleted.");

            // Delete AutoUpgradeProfile
            await updateAutoUpgradeProfileResult.DeleteAsync(WaitUntil.Completed);
            bool doesAutoUpgradeProfileExist = await autoUpgradeProfileCollection.ExistsAsync(autoUpgradeProfileName);
            Debug.Assert(doesAutoUpgradeProfileExist == false, "AutoUpgradeProfile was not deleted.");

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
