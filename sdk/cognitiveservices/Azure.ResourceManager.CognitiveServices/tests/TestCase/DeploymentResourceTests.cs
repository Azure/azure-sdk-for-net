// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests.TestCase
{
    public class DeploymentResourceTests : CognitiveServicesManagementTestBase
    {
        public DeploymentResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<DeploymentResource> CreateDeploymentAsync(string deploymentName)
        {
            var accountContainer = (await CreateResourceGroupAsync()).GetAccounts();
            var accountInput = ResourceDataHelper.GetBasicAccountData(DefaultLocation);
            var lro = await accountContainer.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAccount-"), accountInput);
            var account = lro.Value;
            var container = account.GetDeployments();
            var input = ResourceDataHelper.GetBasicDeploymentData();
            var lro_connection = await container.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
            return lro_connection.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task DeploymentResourceApiTests()
        {
            //1.Get
            var deploymentName = Recording.GenerateAssetName("testDeployment-");
            var deployment1 = await CreateDeploymentAsync(deploymentName);
            DeploymentResource deployment2 = await deployment1.GetAsync();

            ResourceDataHelper.AssertDeployment(deployment1.Data, deployment2.Data);
            //2.Delete
            await deployment1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
