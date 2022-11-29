// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.GuestConfiguration.Models;
using Azure.ResourceManager.GuestConfiguration.Tests.Utilities;
using NUnit.Framework;

namespace Azure.ResourceManager.GuestConfiguration.Tests.Scenario
{
    public class GuestConfigurationHcrpAssignmentCollectionTests : GuestConfigurationManagementTestBase
    {
        public GuestConfigurationHcrpAssignmentCollectionTests(bool isAsync) : base(isAsync)
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
        public async Task CanCreateGetUpdateGuestConfigurationHCRPAssignment()
        {
            var resourceGroupName = GuestConfigurationManagementUtilities.HybridRG;
            var vmName = GuestConfigurationManagementUtilities.HybridMachineName;
            GuestConfigurationHcrpAssignmentCollection guestConfigurationHcrpAssignmentCollection = await GetGuestConfigurationAssignmentHcrpCollectionAsync(resourceGroupName, vmName);
            GuestConfigurationAssignmentData gcAssignmentData = GetDefaultContactGuestConfigurationAssignmentData(guestConfigurationHcrpAssignmentCollection.Id);

            // Create a new guest configuration assignment
            ArmOperation<GuestConfigurationHcrpAssignmentResource> createAssignmentOperation = await guestConfigurationHcrpAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
            await createAssignmentOperation.WaitForCompletionAsync();
            Assert.IsTrue(createAssignmentOperation.HasCompleted);
            Assert.IsTrue(createAssignmentOperation.HasValue);

            // Get created guest configuration assignment
            Response<GuestConfigurationHcrpAssignmentResource> getGuestAssignmentResponse = await guestConfigurationHcrpAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.DefaultAssignmentName);
            GuestConfigurationHcrpAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);
            Assert.AreEqual(gcAssignmentData.Location, guestAssignmentResourceRetrieved.Data.Location);

            // Update guest configuration assignment
            string updatedContext = "Azure Policy Updated";
            gcAssignmentData.Properties.Context = updatedContext;
            ArmOperation<GuestConfigurationHcrpAssignmentResource> updateAssignmentOperation = await guestConfigurationHcrpAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
            await updateAssignmentOperation.WaitForCompletionAsync();
            Assert.IsTrue(updateAssignmentOperation.HasCompleted);
            Assert.IsTrue(updateAssignmentOperation.HasValue);
            GuestConfigurationHcrpAssignmentResource updatedGuestAssignmentResourceRetrieved = updateAssignmentOperation.Value;
            Assert.AreEqual(updatedContext, updatedGuestAssignmentResourceRetrieved.Data.Properties.Context);
        }

        [TestCase]
        public async Task CanGetGuestConfigurationHCRPAssignmentReports()
        {
            var resourceGroupName = GuestConfigurationManagementUtilities.HybridRG;
            var vmName = GuestConfigurationManagementUtilities.HybridMachineName;
            GuestConfigurationHcrpAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentHcrpCollectionAsync(resourceGroupName, vmName);

            // get guest configuration assignment
            Response<GuestConfigurationHcrpAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.DefaultAssignmentName);
            GuestConfigurationHcrpAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);

            // Get reports
            AsyncPageable<GuestConfigurationAssignmentReport> gcAssignmentReportsRetrieved = guestAssignmentResourceRetrieved.GetReportsAsync();
            await foreach (GuestConfigurationAssignmentReport gcReport in gcAssignmentReportsRetrieved)
            {
                Assert.NotNull(gcReport);
            }
        }

        [TestCase]
        public async Task CanListAllGuestConfigurationHCRPAssignments()
        {
            var resourceGroupName = GuestConfigurationManagementUtilities.HybridRG;
            var vmName = GuestConfigurationManagementUtilities.HybridMachineName;
            GuestConfigurationHcrpAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationAssignmentHcrpCollectionAsync(resourceGroupName, vmName);

            // get guest configuration assignments
            var gcAssignments = guestConfigurationAssignmentCollection.GetAllAsync();
            await foreach (GuestConfigurationHcrpAssignmentResource gcAssignment in gcAssignments)
            {
                Assert.NotNull(gcAssignment);
            }
        }
    }
}
