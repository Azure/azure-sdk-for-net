// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.GuestConfiguration.Models;
using Azure.ResourceManager.GuestConfiguration.Tests.Utilities;
using NUnit.Framework;

namespace Azure.ResourceManager.GuestConfiguration.Tests.Scenario
{
    [TestFixture]
    public class GuestConfigurationAssignmentCollectionTests : GuestConfigurationManagementTestBase
    {
        public GuestConfigurationAssignmentCollectionTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        public async Task CanCreateGetUpdateGuestConfigurationAssignment()
        {
            var resourceGroupName = GuestConfigurationManagementUtilities.DefaultResourceGroupName;
            var vmName = GuestConfigurationManagementUtilities.DefaultAzureVMName;
            GuestConfigurationAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName, vmName);
            GuestConfigurationAssignmentData gcAssignmentData = GetDefaultContactGuestConfigurationAssignmentData(guestConfigurationAssignmentCollection.Id);

            // Create a new guest configuration assignment
            ArmOperation<GuestConfigurationAssignmentResource> createAssignmentOperation = await guestConfigurationAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
            await createAssignmentOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAssignmentOperation.HasCompleted);
            Assert.IsTrue(createAssignmentOperation.HasValue);

            // Get created guest configuration assignment
            Response<GuestConfigurationAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.DefaultAssignmentName);
            GuestConfigurationAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);
            Assert.AreEqual(gcAssignmentData.Location, guestAssignmentResourceRetrieved.Data.Location);

            // Update guest configuration assignment
            string updatedContext = "Azure Policy Updated";
            gcAssignmentData.Properties.Context = updatedContext;
            ArmOperation<GuestConfigurationAssignmentResource> updateAssignmentOperation = await guestConfigurationAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
            await updateAssignmentOperation.WaitForCompletionAsync();
            Assert.IsTrue(updateAssignmentOperation.HasCompleted);
            Assert.IsTrue(updateAssignmentOperation.HasValue);
            GuestConfigurationAssignmentResource updatedGuestAssignmentResourceRetrieved = updateAssignmentOperation.Value;
            Assert.AreEqual(updatedContext, updatedGuestAssignmentResourceRetrieved.Data.Properties.Context);
        }

        [TestCase]
        public async Task CanCreateGetUpdateGuestConfigurationHCRPAssignment()
        {
            // TODO: Track 2 code has bug. Until that is fixed, this method is broken
            var resourceGroupName = GuestConfigurationManagementUtilities.HybridRG;
            var vmName = GuestConfigurationManagementUtilities.HybridMachineName;
            GuestConfigurationAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName, vmName);
            GuestConfigurationAssignmentData gcAssignmentData = GetDefaultContactGuestConfigurationAssignmentData(guestConfigurationAssignmentCollection.Id);

            // Create a new guest configuration assignment
            ArmOperation<GuestConfigurationAssignmentResource> createAssignmentOperation = await guestConfigurationAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
            await createAssignmentOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAssignmentOperation.HasCompleted);
            Assert.IsTrue(createAssignmentOperation.HasValue);

            // Get created guest configuration assignment
            Response<GuestConfigurationAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.DefaultAssignmentName);
            GuestConfigurationAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);
            Assert.AreEqual(gcAssignmentData.Location, guestAssignmentResourceRetrieved.Data.Location);

            // Update guest configuration assignment
            string updatedContext = "Azure Policy Updated";
            gcAssignmentData.Properties.Context = updatedContext;
            ArmOperation<GuestConfigurationAssignmentResource> updateAssignmentOperation = await guestConfigurationAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
            await updateAssignmentOperation.WaitForCompletionAsync();
            Assert.IsTrue(updateAssignmentOperation.HasCompleted);
            Assert.IsTrue(updateAssignmentOperation.HasValue);
            GuestConfigurationAssignmentResource updatedGuestAssignmentResourceRetrieved = updateAssignmentOperation.Value;
            Assert.AreEqual(updatedContext, updatedGuestAssignmentResourceRetrieved.Data.Properties.Context);
        }

        [TestCase]
        public async Task CanGetGuestConfigurationAssignmentReports()
        {
            var resourceGroupName = GuestConfigurationManagementUtilities.DefaultResourceGroupName;
            var vmName = GuestConfigurationManagementUtilities.DefaultAzureVMName;
            GuestConfigurationAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName, vmName);

            // get guest configuration assignment
            Response<GuestConfigurationAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.DefaultAssignmentName);
            GuestConfigurationAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);

            // Get reports
            var gcAssignmentReportsRetrieved = guestAssignmentResourceRetrieved.GetGuestConfigurationAssignmentReportsAsync();
            await foreach (GuestConfigurationAssignmentReport gcReport in gcAssignmentReportsRetrieved)
            {
                Assert.NotNull(gcReport);
            }
        }

        [TestCase]
        public async Task CanGetGuestConfigurationHCRPAssignmentReports()
        {
            //TODO: Track 2 code bug: Need it to reroute to .HybridCompute
            var resourceGroupName = GuestConfigurationManagementUtilities.HybridRG;
            var vmName = GuestConfigurationManagementUtilities.HybridMachineName;
            GuestConfigurationAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName, vmName);

            // get guest configuration assignment
            Response<GuestConfigurationAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.DefaultAssignmentName);
            GuestConfigurationAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);

            // Get reports
            var gcAssignmentReportsRetrieved = guestAssignmentResourceRetrieved.GetGuestConfigurationAssignmentReportsAsync();
            await foreach (GuestConfigurationAssignmentReport gcReport in gcAssignmentReportsRetrieved)
            {
                Assert.NotNull(gcReport);
            }
        }

        [TestCase]
        public async Task CanListAllGuestConfigurationAssignments()
        {
            var resourceGroupName = GuestConfigurationManagementUtilities.DefaultResourceGroupName;
            var vmName = GuestConfigurationManagementUtilities.DefaultAzureVMName;
            GuestConfigurationAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName, vmName);

            // get guest configuration assignments
            var gcAssignments = guestConfigurationAssignmentCollection.GetAllAsync();
            await foreach (GuestConfigurationAssignmentResource gcAssignment in gcAssignments)
            {
                Assert.NotNull(gcAssignment);
            }
        }

        [TestCase]
        public async Task CanListAllGuestConfigurationHCRPAssignments()
        {
            // TODO: Breaking due to Tack 2 code bug
            var resourceGroupName = GuestConfigurationManagementUtilities.HybridRG;
            var vmName = GuestConfigurationManagementUtilities.HybridMachineName;
            GuestConfigurationAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName, vmName);

            // get guest configuration assignments
            var gcAssignments = guestConfigurationAssignmentCollection.GetAllAsync();
            await foreach (GuestConfigurationAssignmentResource gcAssignment in gcAssignments)
            {
                Assert.NotNull(gcAssignment);
            }
        }

        [TestCase]
        public async Task CanGetVMSSAssignment()
        {
            // TODO: Breaking due to Tack 2 code bug
            var resourceGroupName = GuestConfigurationManagementUtilities.VMSSRG;
            var vmName = GuestConfigurationManagementUtilities.VMSSName;
            GuestConfigurationAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName, vmName);
            GuestConfigurationAssignmentData gcAssignmentData = GetDefaultContactGuestConfigurationAssignmentData(guestConfigurationAssignmentCollection.Id);

            // Get created guest configuration assignment
            Response<GuestConfigurationAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.VMSSAssignmentName);
            GuestConfigurationAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);
            Assert.AreEqual(gcAssignmentData.Location, guestAssignmentResourceRetrieved.Data.Location);
        }
    }
}
