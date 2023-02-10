// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.GuestConfiguration.Tests.Utilities;
using NUnit.Framework;

namespace Azure.ResourceManager.GuestConfiguration.Tests.Scenario
{
    public class GuestConfigurationVmssAssignmentCollectionTests : GuestConfigurationManagementTestBase
    {
        public GuestConfigurationVmssAssignmentCollectionTests(bool isAsync) : base(isAsync)
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
        public async Task CanGetVMSSAssignment()
        {
            var resourceGroupName = GuestConfigurationManagementUtilities.VMSSRG;
            var vmName = GuestConfigurationManagementUtilities.VMSSName;
            GuestConfigurationVmssAssignmentCollection guestConfigurationAssignmentCollection = await GetGuestConfigurationVmssAssignmentCollection(resourceGroupName, vmName);

            // Get created guest configuration assignment
            Response<GuestConfigurationVmssAssignmentResource> getGuestAssignmentResponse = await guestConfigurationAssignmentCollection.GetAsync(GuestConfigurationManagementUtilities.VMSSAssignmentName);
            GuestConfigurationVmssAssignmentResource guestAssignmentResourceRetrieved = getGuestAssignmentResponse.Value;
            Assert.IsNotNull(guestAssignmentResourceRetrieved);
            Assert.AreEqual(GuestConfigurationManagementUtilities.VMSSAssignmentName, guestAssignmentResourceRetrieved.Data.Name);
        }
    }
}
