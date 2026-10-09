// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class CostControlLifecycleTests : ManagementRecordedTestBase<CostControlTestEnvironment>
    {
        private ArmClient Client { get; set; }

        public CostControlLifecycleTests(bool isAsync)
            : base(isAsync)
        {
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=/subscriptions/)(?<group>[^/]+)")
            {
                GroupForReplace = "group",
                Value = "00000000-0000-0000-0000-000000000000"
            });
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=/resourceGroups/)(?<group>[^/]+)")
            {
                GroupForReplace = "group",
                Value = "sanitized-resource-group"
            });
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=/accounts/)(?<group>[^/?]+)")
            {
                GroupForReplace = "group",
                Value = "sanitized-cognitive-account"
            });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("ETag") { Value = "Sanitized" });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("If-Match") { Value = "Sanitized" });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("x-ms-operation-identifier") { Value = "Sanitized" });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("x-ms-correlation-request-id") { Value = "Sanitized" });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("x-ms-routing-request-id") { Value = "Sanitized" });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("x-ms-request-id") { Value = "Sanitized" });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..etag") { Value = "Sanitized" });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(
                @"/subscriptions/[^/""]+/resourceGroups/[^/""]+/providers/Microsoft\.CognitiveServices/accounts/[^/""]+")
            {
                Value = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sanitized-resource-group/providers/Microsoft.CognitiveServices/accounts/sanitized-cognitive-account"
            });
        }

        [SetUp]
        public void CreateClient()
        {
            Client = GetArmClient(subscriptionId: TestEnvironment.CostControlSubscriptionId);
        }

        [TestCase]
        public async Task CostControlLifecycle()
        {
            string costControlName = Recording.GenerateAssetName("costctrl-");
            ResourceIdentifier accountId = CognitiveServicesAccountResource.CreateResourceIdentifier(
                TestEnvironment.CostControlSubscriptionId,
                TestEnvironment.CostControlResourceGroup,
                TestEnvironment.CostControlAccountName);
            CognitiveServicesAccountCostControlCollection collection = Client
                .GetCognitiveServicesAccountResource(accountId)
                .GetCognitiveServicesAccountCostControls();
            CognitiveServicesAccountCostControlResource resource = null;

            try
            {
                CognitiveServicesAccountCostControlData data = CreateData("SDK recorded test", 25);
                MatchConditions createOnly = new() { IfNoneMatch = ETag.All };
                ArmOperation<CognitiveServicesAccountCostControlResource> create = await collection.CreateOrUpdateAsync(
                    WaitUntil.Started,
                    costControlName,
                    data,
                    createOnly);
                resource = create.Value;

                Assert.That(resource.Data.Properties.Rules[0].Thresholds[0].Action,
                    Is.EqualTo(CostControlThresholdAction.Audit));

                resource = (await collection.GetAsync(costControlName)).Value;
                Assert.That(resource.Data.ETag, Is.Not.Null);
                Assert.That(resource.Data.Properties.Rules[0].Thresholds[0].Value, Is.Zero);

                var resources = await collection.GetAllAsync().ToEnumerableAsync();
                Assert.That(resources.Any(item => item.Data.Properties.DisplayName == "SDK recorded test"), Is.True);

                CostControlPatchProperties patchProperties = new() { DisplayName = "SDK recorded test updated" };
                patchProperties.Rules.Add(CreateRule(50));
                resource = (await resource.UpdateAsync(
                    new CognitiveServicesAccountCostControlPatch(patchProperties),
                    resource.Data.ETag)).Value;

                Assert.That(resource.Data.Properties.DisplayName, Is.EqualTo("SDK recorded test updated"));
                Assert.That(resource.Data.Properties.Rules[0].Amount, Is.EqualTo(50));

                resource = (await collection.GetAsync(costControlName)).Value;
                await resource.DeleteAsync(WaitUntil.Started, resource.Data.ETag);
                resource = null;

                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                    async () => await collection.GetAsync(costControlName));
                Assert.That(exception.Status, Is.EqualTo(404));
            }
            finally
            {
                if (resource != null && Mode != RecordedTestMode.Playback)
                {
                    try
                    {
                        await resource.DeleteAsync(WaitUntil.Started);
                    }
                    catch (RequestFailedException exception) when (exception.Status == 404)
                    {
                    }
                }
            }
        }

        private static CognitiveServicesAccountCostControlData CreateData(string displayName, double amount)
            => new()
            {
                Properties = new CostControlProperties(new[] { CreateRule(amount) })
                {
                    DisplayName = displayName
                }
            };

        private static CostControlRule CreateRule(double amount)
        {
            CostControlRule rule = new(
                "account-budget",
                new[] { new CostControlDimension(CostControlDimensionType.Account) },
                CostControlUnit.Usd,
                amount)
            {
                Period = CostControlPeriod.Month,
                Recurring = true
            };
            rule.Thresholds.Add(new CostControlThreshold(CostControlThresholdType.Percentage, 0)
            {
                Action = CostControlThresholdAction.Audit
            });
            return rule;
        }
    }
}