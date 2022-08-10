// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            GuestConfigurationAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName);
            GuestConfigurationAssignmentData gcAssignmentData = GetDefaultContactGuestConfigurationAssignmentData(guestConfigurationAssignmentCollection.Id);

            // Create a new guest configuration assignment
            ArmOperation<GuestConfigurationAssignmentResource> createAssignmentOperation = await guestConfigurationAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
            await createAssignmentOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAssignmentOperation.HasCompleted);
            Assert.IsTrue(createAssignmentOperation.HasValue);

            // Get created guest configuration assignment
            Response<GuestConfigurationAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(vmName, GuestConfigurationManagementUtilities.DefaultAssignmentName);
            GuestConfigurationAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);
            Assert.AreEqual(gcAssignmentData.Location, guestAssignmentResourceRetrieved.Data.Location);

            // Update guest configuration assignment
            string updatedContext = "Azure Policy Updated";
            gcAssignmentData.Properties.Context = updatedContext;
            ArmOperation<GuestConfigurationAssignmentResource> updateAssignmentOperation = await guestConfigurationAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
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
            GuestConfigurationAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName);

            // get guest configuration assignment
            Response<GuestConfigurationAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(vmName, GuestConfigurationManagementUtilities.DefaultAssignmentName);
            GuestConfigurationAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);

            // Get reports
            AsyncPageable<GuestConfigurationAssignmentReport> gcAssignmentReportsRetrieved = guestAssignmentResourceRetrieved.GetGuestConfigurationAssignmentReportsAsync();
            await foreach (GuestConfigurationAssignmentReport gcReport in gcAssignmentReportsRetrieved)
            {
                Assert.NotNull(gcReport);
            }
        }

        // SDK Team has currently disabled Lists for a bug/feature they are implementing.
        //[TestCase]
        //public async Task CanListAllGuestConfigurationAssignments()
        //{
        //    var resourceGroupName = GuestConfigurationManagementUtilities.DefaultResourceGroupName;
        //    var vmName = GuestConfigurationManagementUtilities.DefaultAzureVMName;
        //    GuestConfigurationAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName);

        //    // get guest configuration assignments
        //    var gcAssignments = guestConfigurationAssignmentCollection.GetAllAsync();
        //    await foreach (GuestConfigurationAssignmentResource gcAssignment in gcAssignments)
        //    {
        //        Assert.NotNull(gcAssignment);
        //    }
        //}
    }
}
