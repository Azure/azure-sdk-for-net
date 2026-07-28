// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ImageBuilder.Tests
{
    public class ImageBuilderManagementTestBase : ManagementRecordedTestBase<ImageBuilderManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected ImageBuilderManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
            AddCustomSanitizers();
        }

        protected ImageBuilderManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            AddCustomSanitizers();
        }

        private void AddCustomSanitizers()
        {
            // Sanitize the response header that leaks tenant/object identifiers.
            SanitizedHeaders.Add("x-ms-operation-identifier");

            // Sanitize identity GUIDs that appear in response bodies. Use the all-zero GUID
            // (matching other services) so the values remain valid GUIDs during playback.
            const string EmptyGuid = "00000000-0000-0000-0000-000000000000";
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..principalId") { Value = EmptyGuid });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..clientId") { Value = EmptyGuid });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..tenantId") { Value = EmptyGuid });
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
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
