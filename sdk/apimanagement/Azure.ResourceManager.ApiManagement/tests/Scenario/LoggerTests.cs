// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.Core.TestFramework.Models;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class LoggerTests : ApiManagementManagementTestBase
    {
        public LoggerTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
            IgnoreApiVersionInEventHubOperations();
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        private void IgnoreApiVersionInEventHubOperations()
        {
            // Ignore the api-version of EventHub operations
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/providers/Microsoft.EventHub/namespaces/([\S]+)?pi-version=(?<group>[a-z0-9-]+)")
            {
                GroupForReplace = "group",
                Value = "**"
            });
        }

        [Test]
        public async Task CRUD()
        {
            await SetCollectionsAsync();

            string newloggerId = Recording.GenerateAssetName("newlogger");
            string eventHubNameSpaceName = Recording.GenerateAssetName("eventHubNamespace");
            string eventHubName = Recording.GenerateAssetName("eventhubname");

            // first create the event hub namespace
            var eventCollection = ResourceGroup.GetEventHubsNamespaces();
            var eventHubNamespace = (await eventCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventHubNameSpaceName, new EventHubsNamespaceData(AzureLocation.WestUS2))).Value;
            Assert.NotNull(eventHubNamespace.Data.Name);

            // then create eventhub
            var hubCollection = eventHubNamespace.GetEventHubs();
            var eventHub = (await hubCollection.CreateOrUpdateAsync(WaitUntil.Completed, eventHubName, new EventHubData())).Value;
            Assert.NotNull(eventHub.Data.Name);

            // create send policy auth rule
            string sendPolicy = Recording.GenerateAssetName("sendPolicy");
            var authCollection = eventHub.GetEventHubAuthorizationRules();
            var eventHubAuthRule = (await authCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                sendPolicy,
                new EventHubsAuthorizationRuleData()
                {
                    Rights = { EventHubsAccessRight.Send }
                })).Value;

            // get the keys
            var eventHubKeys = (await eventHubAuthRule.GetKeysAsync()).Value;

            // now create logger using the eventhub
            await CreateApiServiceAsync();
            var logCollection = ApiServiceResource.GetApiManagementLoggers();
            var loggerCreateParameters = new ApiManagementLoggerData()
            {
                LoggerType = LoggerType.AzureEventHub,
                Credentials = { { "name", eventHubName }, { "connectionString", eventHubKeys.PrimaryConnectionString } }
            };
            // create new group with default parameters
            string loggerDescription = Recording.GenerateAssetName("newloggerDescription");
            loggerCreateParameters.Description = loggerDescription;

            var loggerContract = (await logCollection.CreateOrUpdateAsync(WaitUntil.Completed, newloggerId, loggerCreateParameters)).Value;

            Assert.NotNull(loggerContract);
            Assert.AreEqual(newloggerId, loggerContract.Data.Name);
            Assert.IsTrue(loggerContract.Data.IsBuffered);
            Assert.AreEqual(LoggerType.AzureEventHub, loggerContract.Data.LoggerType);
            Assert.NotNull(loggerContract.Data.Credentials);
            Assert.AreEqual(2, loggerContract.Data.Credentials.Keys.Count);

            var listLoggers = await logCollection.GetAllAsync().ToEnumerableAsync();
            // there should be one user
            Assert.GreaterOrEqual(listLoggers.Count, 1);

            // patch logger
            string patchedDescription = Recording.GenerateAssetName("patchedDescription");
            await loggerContract.UpdateAsync(ETag.All, new ApiManagementLoggerPatch() { Description = patchedDescription });

            // get to check it was patched
            loggerContract = await logCollection.GetAsync(newloggerId);

            Assert.NotNull(loggerContract);
            Assert.AreEqual(newloggerId, loggerContract.Data.Name);
            Assert.AreEqual(patchedDescription, loggerContract.Data.Description);
            Assert.NotNull(loggerContract.Data.Credentials);

            // delete the logger
            await loggerContract.DeleteAsync(WaitUntil.Completed, ETag.All);
            var falseResult = await logCollection.ExistsAsync(newloggerId);
            Assert.IsFalse(falseResult);
        }
    }
}
