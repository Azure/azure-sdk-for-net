// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SecretsStoreExtension.Tests
{
    public class SecretsStoreExtensionManagementTestBase : ManagementRecordedTestBase<SecretsStoreExtensionManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        private const string GuidRegex = @"[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}";
        private const string SanitizedSubscriptionId = SecretsStoreExtensionManagementTestEnvironment.NullGuid;

        protected SecretsStoreExtensionManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            SanitizeTenant();
            SanitizeDisplayName();
            SanitizeSubscriptionId();
            SanitizeLocation();
            SanitizeKeyVault();
        }

        // Sanitizes the tenant ID.
        private void SanitizeTenant()
        {
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("x-ms-operation-identifier")
            {
                Regex = "^.*$",
                Value = "Sanitized"
            });
        }

        // Sanitizes the tenant display name.
        private void SanitizeDisplayName()
        {
            const string SanitizedDisplayName = "Sanitized";
            BodyKeySanitizers.Add(new BodyKeySanitizer("displayName")
            {
                Value = SanitizedDisplayName
            });
        }

        // Prevent the subscription ID from appearing in the log files.
        private void SanitizeSubscriptionId()
        {
            // Replace subscription ID subpath in URI with sanitized version.
            const string subscriptionRegex = $@"/subscriptions/(?<subscription>{GuidRegex})";
            UriRegexSanitizers.Add(new UriRegexSanitizer(subscriptionRegex)
            {
                Value = SanitizedSubscriptionId,
                GroupForReplace = "subscription"
            });

            // Replace subscription ID in Location header.
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Location")
            {
                Regex = subscriptionRegex,
                Value = SanitizedSubscriptionId,
                GroupForReplace = "subscription"
            });

            // Replace subscription ID field in response body with sanitized version.
            BodyKeySanitizers.Add(new BodyKeySanitizer("subscriptionId")
            {
                Value = SanitizedSubscriptionId
            });

            // Replace subscription ID subpath in response body with sanitized version.
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(subscriptionRegex)
            {
                Value = SanitizedSubscriptionId,
                GroupForReplace = "subscription"
            });

            // Replace subscription ID in Azure-AsyncOperation header.
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Azure-AsyncOperation")
            {
                Regex = subscriptionRegex,
                Value = SanitizedSubscriptionId,
                GroupForReplace = "subscription"
            });
        }

        // Prevent the geographical location from appearing in the log files.
        private void SanitizeLocation()
        {
            // Replace location in URIs.
            const string locationRegex = $@"/subscriptions/{GuidRegex}/providers/Microsoft.SecretSyncController/locations/(?<location>[^/]+)/";
            const string SanitizedLocation = "Sanitized";
            UriRegexSanitizers.Add(new UriRegexSanitizer(locationRegex)
            {
                Value = SanitizedLocation,
                GroupForReplace = "location"
            });

            // Replace location in response headers.
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Location")
            {
                Regex = locationRegex,
                Value = SanitizedLocation,
                GroupForReplace = "location"
            });

            // Replace location in response bodies.
            BodyKeySanitizers.Add(new BodyKeySanitizer("location")
            {
                Value = SanitizedLocation
            });

            BodyKeySanitizers.Add(new BodyKeySanitizer("value[*].location")
            {
                Value = SanitizedLocation
            });

            // Replace location in response body
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(locationRegex)
            {
                Value = SanitizedLocation,
                GroupForReplace = "location"
            });

            // Replace location in Azure-AsyncOperation header value.
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Azure-AsyncOperation")
            {
                Regex = locationRegex,
                Value = SanitizedLocation,
                GroupForReplace = "location"
            });
        }

        // Prevent the key vault name from appearing in the log files.
        private void SanitizeKeyVault()
        {
            // Sanitize keyvault name.
            JsonPathSanitizers.Add("$..keyvaultName");
        }

        protected async Task CreateCommonClient()
        {
            Client = GetArmClient(subscriptionId: TestEnvironment.SpcSubscriptionId);
            DefaultSubscription = await Client.GetSubscriptions().GetAsync(TestEnvironment.SpcSubscriptionId);
        }

        // The tag tests take around 30 seconds in playback mode.
        private readonly TimeSpan _maxTimeout = TimeSpan.FromSeconds(60);

        public override void GlobalTimeoutTearDown()
        {
            var duration = DateTime.UtcNow - TestStartTime;
            if (duration > _maxTimeout) {
                base.GlobalTimeoutTearDown();
            }
        }
    }
}
