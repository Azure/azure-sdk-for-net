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
    public class SIAlertRulesResourceTests : SecurityInsightsManagementTestBase
    {
        public SIAlertRulesResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<SecurityInsightsAlertRuleResource> CreateSecurityInsightsAlertRuleAsync(string alertRulesName)
        {
            var collection = (await CreateResourceGroupAsync()).GetSecurityInsightsAlertRules(workspaceName);
            var input = ResourceDataHelpers.GetSecurityInsightsAlertRuleData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, alertRulesName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task SIAlertRulesResourceApiTests()
        {
            //1.Get
            var applicationName = Recording.GenerateAssetName("testAlertRules-");
            var alertRules1 = await CreateSecurityInsightsAlertRuleAsync(applicationName);
            SecurityInsightsAlertRuleResource alertRules2 = await alertRules1.GetAsync();

            ResourceDataHelpers.AssertSecurityInsightsAlertRuleData(alertRules1.Data, alertRules2.Data);
            //2.Delete
            await alertRules1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
