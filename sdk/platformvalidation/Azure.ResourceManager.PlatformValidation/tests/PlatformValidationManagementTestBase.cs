// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.PlatformValidation.Tests
{
    public class PlatformValidationManagementTestBase : ManagementRecordedTestBase<PlatformValidationManagementTestEnvironment>
    {
        // Match only sourceVhdUri values, including escaped property delimiters in embedded JSON.
        internal const string SourceVhdUriPattern = @"(?i)(?<=sourceVhdUri(?:\\*""|\\+u0022)\s*:\s*(?:\\*""|\\+u0022))https://(?:[^""\\\s]|\\+(?:u(?!0022|005c)[0-9a-f]{4}|/))+";
        private const string SubscriptionIdPattern = @"(?i)(?<=/subscriptions/)[0-9a-f-]{36}";
        private const string SanitizedSubscriptionId = "00000000-0000-0000-0000-000000000000";

        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected PlatformValidationManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            ConfigureSanitizers();
        }

        protected PlatformValidationManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            ConfigureSanitizers();
        }

        private void ConfigureSanitizers()
        {
            UriRegexSanitizers.Add(new UriRegexSanitizer(SubscriptionIdPattern) { Value = SanitizedSubscriptionId });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(SubscriptionIdPattern) { Value = SanitizedSubscriptionId });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..subscriptionId") { Value = SanitizedSubscriptionId });
            foreach (string header in new[] { "Location", "Azure-AsyncOperation", "Operation-Location" })
            {
                HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(header)
                {
                    Regex = SubscriptionIdPattern,
                    Value = SanitizedSubscriptionId
                });
            }
            Condition subscription = new() { UriRegex = @"(?i)/subscriptions/[^/?]+(?:\?|$)" };
            foreach (string key in new[] { "displayName", "locationPlacementId", "quotaId" })
            {
                BodyRegexSanitizers.Add(new BodyRegexSanitizer($@"""{key}""\s*:\s*""(?<value>(?:\\.|[^""\\])*)""")
                {
                    Value = SanitizeValue,
                    GroupForReplace = "value",
                    Condition = subscription
                });
            }
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"""tags""\s*:\s*\{(?:\s*""(?:\\.|[^""\\])*""\s*:\s*""(?:\\.|[^""\\])*""\s*,?)*\s*\}")
            {
                Value = @"""tags"":{}",
                Condition = subscription
            });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(SourceVhdUriPattern)
            {
                Value = PlatformValidationManagementTestEnvironment.SanitizedSourceVhdUri
            });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..owners[*]") { Value = SanitizeValue });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..systemData.createdBy") { Value = SanitizeValue });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..systemData.lastModifiedBy") { Value = SanitizeValue });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}")
            {
                Value = SanitizeValue
            });
            SanitizedHeaders.Add("x-ms-operation-identifier");
            SanitizedHeaders.Add("Request-Context");
            SanitizedHeaders.Add("x-ms-resource-provider-hint");
            SanitizedHeaders.Add("x-ms-providerhub-traffic");
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        [TearDown]
        public void SanitizeSubscriptionVariable()
        {
            Recording.SetVariable("SUBSCRIPTION_ID", SanitizedSubscriptionId);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
