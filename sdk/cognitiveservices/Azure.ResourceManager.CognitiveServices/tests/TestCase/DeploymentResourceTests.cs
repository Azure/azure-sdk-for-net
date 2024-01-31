// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.CognitiveServices.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class DeploymentResourceTests : CognitiveServicesManagementTestBase
    {
        public DeploymentResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<CognitiveServicesAccountDeploymentResource> CreateDeploymentAsync(string deploymentName)
        {
            var accountContainer = (await CreateResourceGroupAsync()).GetCognitiveServicesAccounts();
            var accountInput = ResourceDataHelper.GetBasicAccountData(AzureLocation.EastUS);
            accountInput.Kind = "OpenAI";
            accountInput.Sku = new CognitiveServicesSku("S0");
            var lro = await accountContainer.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testAccount-"), accountInput);
            var account = lro.Value;
            var container = account.GetCognitiveServicesAccountDeployments();
            var input = ResourceDataHelper.GetBasicDeploymentData();
            var lro_connection = await container.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
            return lro_connection.Value;
        }

        [TestCase]
        public async Task DeploymentResourceApiTests()
        {
            //1.Get
            var deploymentName = Recording.GenerateAssetName("testDeployment-");
            var deployment1 = await CreateDeploymentAsync(deploymentName);
            CognitiveServicesAccountDeploymentResource deployment2 = await deployment1.GetAsync();

            ResourceDataHelper.AssertDeployment(deployment1.Data, deployment2.Data);
            //2.Delete
            await deployment1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
