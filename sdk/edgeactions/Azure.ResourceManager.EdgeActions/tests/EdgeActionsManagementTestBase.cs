// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
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
        internal const string DeploymentCountProperty = "DeploymentCount";
        private CancellationTokenSource _testTimeout;

        protected ArmClient Client { get; private set; }
        protected CancellationToken TestCancellationToken => _testTimeout.Token;

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
        public async Task CreateCommonClientAsync()
        {
            var options = new ArmClientOptions();
            Client = GetArmClient(options);
            await TestEnvironment.InitializeLocalAzureCliAsync(options.Environment.Value);
            int deploymentCount = (int?)TestContext.CurrentContext.Test.Properties.Get(DeploymentCountProperty) ?? 0;
            _testTimeout = new CancellationTokenSource(GetTestTimeout(deploymentCount));
        }

        [TearDown]
        public void DisposeTestTimeout()
        {
            _testTimeout?.Dispose();
        }

        internal static TimeSpan GetTestTimeout(int deploymentCount)
        {
            if (deploymentCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(deploymentCount));
            }
            return TimeSpan.FromMinutes(deploymentCount == 0 ? 20 : checked(deploymentCount * 40 + 10));
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(AzureLocation.EastUS);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input, TestCancellationToken);
            return lro.Value;
        }
    }
}
