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
    public class FrontDoorExperimentResourceTests : FrontDoorManagementTestBase
    {
        public FrontDoorExperimentResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<FrontDoorExperimentResource> CreateFrontDoorExperimentResourceAsync(string experimentName)
        {
            var collection = (await CreateResourceGroupAsync()).GetFrontDoorNetworkExperimentProfiles();
            var input = ResourceDataHelpers.GetProfileData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testprofile"), input);
            var profile = lro.Value;
            var experimentCollection = profile.GetFrontDoorExperiments();
            var experimentInput = ResourceDataHelpers.GetFrontDoorExperimentData(DefaultLocation);
            var lroc = await experimentCollection.CreateOrUpdateAsync(WaitUntil.Completed, experimentName, experimentInput);
            return lroc.Value;
        }

        [TestCase]
        [Ignore("no authorization")]
        public async Task ExperimentResourceApiTests()
        {
            //1.Get
            var experimentName = Recording.GenerateAssetName("testengine");
            var experiment1 = await CreateFrontDoorExperimentResourceAsync(experimentName);
            FrontDoorExperimentResource experiment2 = await experiment1.GetAsync();

            ResourceDataHelpers.AssertFrontDoorExperiment(experiment1.Data, experiment2.Data);
            //2.Delete
            await experiment1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
