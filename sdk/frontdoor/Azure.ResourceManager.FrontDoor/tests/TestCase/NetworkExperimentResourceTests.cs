// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.FrontDoor.Models;
using Azure.ResourceManager.FrontDoor.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.FrontDoor.Tests.TestCase
{
    public class NetworkExperimentResourceTests : FrontDoorManagementTestBase
    {
        public NetworkExperimentResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<FrontDoorNetworkExperimentProfileResource> CreateProfileResourceAsync(string profileName)
        {
            var collection = (await CreateResourceGroupAsync()).GetFrontDoorNetworkExperimentProfiles();
            var input = ResourceDataHelpers.GetProfileData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, profileName, input);
            return lro.Value;
        }

        [TestCase]
        [Ignore("no authorization")]
        public async Task AFDNetworkResourceApiTests()
        {
            //1.Get
            var profileName = Recording.GenerateAssetName("testprofile");
            var profile1 = await CreateProfileResourceAsync(profileName);
            FrontDoorNetworkExperimentProfileResource profile2 = await profile1.GetAsync();

            ResourceDataHelpers.AssertFrontDoorNetWorkExperiment(profile1.Data, profile2.Data);
            //2.Delete
            await profile1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
