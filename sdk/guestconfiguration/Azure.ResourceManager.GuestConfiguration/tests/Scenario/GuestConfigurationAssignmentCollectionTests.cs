// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.GuestConfiguration.Models;
using Azure.ResourceManager.GuestConfiguration.Tests.Utilities;
using NUnit.Framework;

namespace Azure.ResourceManager.GuestConfiguration.Tests.Scenario
{
    public class GuestConfigurationAssignmentCollectionTests : GuestConfigurationManagementTestBase
    {
        public GuestConfigurationAssignmentCollectionTests(bool isAsync) : base(isAsync)
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
            GuestConfigurationVmAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName, vmName);
            GuestConfigurationAssignmentData gcAssignmentData = GetDefaultContactGuestConfigurationAssignmentData(guestConfigurationAssignmentCollection.Id);

            // Create a new guest configuration assignment
            ArmOperation<GuestConfigurationVmAssignmentResource> createAssignmentOperation = await guestConfigurationAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
            await createAssignmentOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAssignmentOperation.HasCompleted);
            Assert.IsTrue(createAssignmentOperation.HasValue);

            // Get created guest configuration assignment
            Response<GuestConfigurationVmAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.DefaultAssignmentName);
            GuestConfigurationVmAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);
            Assert.AreEqual(gcAssignmentData.Location, guestAssignmentResourceRetrieved.Data.Location);

            // Update guest configuration assignment
            string updatedContext = "Azure Policy Updated";
            gcAssignmentData.Properties.Context = updatedContext;
            ArmOperation<GuestConfigurationVmAssignmentResource> updateAssignmentOperation = await guestConfigurationAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
            await updateAssignmentOperation.WaitForCompletionAsync();
            Assert.IsTrue(updateAssignmentOperation.HasCompleted);
            Assert.IsTrue(updateAssignmentOperation.HasValue);
            GuestConfigurationVmAssignmentResource updatedGuestAssignmentResourceRetrieved = updateAssignmentOperation.Value;
            Assert.AreEqual(updatedContext, updatedGuestAssignmentResourceRetrieved.Data.Properties.Context);
        }

        [TestCase]
        public async Task CanGetGuestConfigurationAssignmentReports()
        {
            var resourceGroupName = GuestConfigurationManagementUtilities.DefaultResourceGroupName;
            var vmName = GuestConfigurationManagementUtilities.DefaultAzureVMName;
            GuestConfigurationVmAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName, vmName);

            // get guest configuration assignment
            Response<GuestConfigurationVmAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.DefaultAssignmentName);
            GuestConfigurationVmAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);

            // Get reports
            AsyncPageable<GuestConfigurationAssignmentReport> gcAssignmentReportsRetrieved = guestAssignmentResourceRetrieved.GetReportsAsync();
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
            GuestConfigurationVmAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentCollectionAsync(resourceGroupName, vmName);

            // get guest configuration assignments
            var gcAssignments = guestConfigurationAssignmentCollection.GetAllAsync();
            await foreach (GuestConfigurationVmAssignmentResource gcAssignment in gcAssignments)
            {
                Assert.NotNull(gcAssignment);
            }
        }
    }
}
