// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeActions.Tests
{
    public class EdgeActionsManagementTestBase : ManagementRecordedTestBase<EdgeActionsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected EdgeActionsManagementTestBase(bool isAsync, RecordedTestMode? mode = null)
        : base(isAsync, mode)
        {
            IgnoredQueryParameters.Remove("api-version");
            // Preserve distinct status/result paths while removing signed polling query values.
            foreach (string parameter in new[] { "t", "c", "s", "h" })
            {
                UriRegexSanitizers.Add(UriRegexSanitizer.CreateWithQueryParameter(parameter, "Sanitized"));
                HeaderRegexSanitizers.Add(HeaderRegexSanitizer.CreateWithQueryParameter("Azure-AsyncOperation", parameter, "Sanitized"));
                HeaderRegexSanitizers.Add(HeaderRegexSanitizer.CreateWithQueryParameter("Location", parameter, "Sanitized"));
            }
            foreach (string header in new[] { "x-ms-correlation-request-id", "x-ms-routing-request-id", "x-ms-operation-identifier", "x-ms-original-request-ids", "X-MSEdge-Ref" })
            {
                SanitizedHeaders.Add(header);
            }
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(AzureLocation.EastUS);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
