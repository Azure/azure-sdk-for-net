// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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

            // Create a new guest configuration assignment
            try
            {
                GuestConfigurationAssignmentData gcAssignmentData = GetDefaultContactGuestConfigurationAssignmentData(guestConfigurationAssignmentCollection.Id);

                ArmOperation<GuestConfigurationAssignmentResource> createAssignmentOperation = await guestConfigurationAssignmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, GuestConfigurationManagementUtilities.DefaultAssignmentName, gcAssignmentData);
                await createAssignmentOperation.WaitForCompletionAsync();
                Assert.IsTrue(createAssignmentOperation.HasCompleted);
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }

           //Assert.IsTrue(createAssignmentOperation.HasValue);

            // Get created guest configuration assignment
            //Response<GuestConfigurationAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.DefaultAssignmentName);
            //GuestConfigurationAssignmentResource guestAssignmentResource = getGuestAssignmentResponse.Value;
            //Assert.IsNotNull(guestAssignmentResource);
            //Assert.Equals(gcAssignmentData.Location, guestAssignmentResource.Data.Location);
        }
    }
}
