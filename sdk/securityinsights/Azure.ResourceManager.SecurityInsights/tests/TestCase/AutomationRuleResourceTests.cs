// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class AutomationRuleResourceTests : SecurityInsightsManagementTestBase
    {
        public AutomationRuleResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<AutomationRuleResource> CreateAutomationRuleAsync(string automationName)
        {
            var collection = (await CreateResourceGroupAsync()).GetAutomationRules(workspaceName);
            var input = ResourceDataHelpers.GetAutomationRuleData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, automationName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task AutomationRuleResourceApiTests()
        {
            //1.Get
            var automationName = Recording.GenerateAssetName("testAutomationRule-");
            var automation1 = await CreateAutomationRuleAsync(automationName);
            AutomationRuleResource automation = await automation1.GetAsync();

            ResourceDataHelpers.AssertAutomationRuleData(automation1.Data, automation.Data);
            //2.Delete
            await automation1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
