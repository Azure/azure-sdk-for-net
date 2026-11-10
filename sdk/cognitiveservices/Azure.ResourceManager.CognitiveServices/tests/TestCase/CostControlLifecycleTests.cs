// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
                DateTimeOffset startsOn = Recording.UtcNow;
                CognitiveServicesAccountCostControlData data = new()
                {
                    Properties = new CostControlProperties(CostControlCategory.Cost, 25, CostControlTimeGrain.Monthly,
                        new CostControlTimePeriod(startsOn, startsOn.AddMonths(1)))
                };
                MatchConditions createOnly = new() { IfNoneMatch = ETag.All };
                ArmOperation<CognitiveServicesAccountCostControlResource> create = await collection.CreateOrUpdateAsync(
                    WaitUntil.Started,
                    costControlName,
                    data,
                    createOnly);
                resource = create.Value;

                Assert.That(resource.Data.Properties.Category, Is.EqualTo(CostControlCategory.Cost));
                Assert.That(resource.Data.Properties.Amount, Is.EqualTo(25));

                resource = (await collection.GetAsync(costControlName)).Value;
                Assert.That(resource.Data.ETag, Is.Not.Null);
                Assert.That(resource.Data.Properties.TimeGrain, Is.EqualTo(CostControlTimeGrain.Monthly));

                var resources = await collection.GetAllAsync().ToEnumerableAsync();
                Assert.That(resources.Any(item => item.Id == resource.Id), Is.True);

                CostControlPatchProperties patchProperties = new() { Amount = 50 };
                resource = (await resource.UpdateAsync(
                    new CostControlPatch { Properties = patchProperties },
                    resource.Data.ETag)).Value;

                Assert.That(resource.Data.Properties.Amount, Is.EqualTo(50));

                resource = (await collection.GetAsync(costControlName)).Value;
                Assert.That(resource.Data.Properties.Amount, Is.EqualTo(50));
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
    }
}