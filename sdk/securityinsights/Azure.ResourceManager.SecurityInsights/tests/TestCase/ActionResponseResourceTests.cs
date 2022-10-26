// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class ActionResponseResourceTests : SecurityInsightsManagementTestBase
    {
        public ActionResponseResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ActionResponseResource> GetActionResponseResourceAsync(string actionResopnseName)
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetSecurityInsightsAlertRules(workspaceName);
            var alertRulesName = Recording.GenerateAssetName("testAlertRule-");
            var input = ResourceDataHelpers.GetSecurityInsightsAlertRuleData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, alertRulesName, input);
            var alertRules = lro.Value;
            var actionCollection =  alertRules.GetActionResponses();
            var actionInput = ResourceDataHelpers.GetActionResponseData(resourceGroup.Data.Name);
            var lroa = await actionCollection.CreateOrUpdateAsync(WaitUntil.Completed, actionResopnseName, actionInput);
            return lroa.Value;
        }

        [TestCase]
        public async Task ActionResponseResourceApiTests()
        {
            //1.Get
            var actionName = Recording.GenerateAssetName("testactionResponse");
            var actionResponse = await GetActionResponseResourceAsync(actionName);
            ActionResponseResource engine2 = await actionResponse.GetAsync();

            ResourceDataHelpers.AssertActionResponseData(actionResponse.Data, engine2.Data);
            //2.Delete
            await actionResponse.DeleteAsync(WaitUntil.Completed);
        }
    }
}
