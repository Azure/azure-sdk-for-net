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
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class LoggerTests : ApiManagementManagementTestBase
    {
        public LoggerTests(bool isAsync)
                    : base(isAsync)//, RecordedTestMode.Record)
        {
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
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceData(AzureLocation.EastUS, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementLoggers();

            string newloggerId = Recording.GenerateAssetName("newlogger");
            string eventHubNameSpaceName = Recording.GenerateAssetName("eventHubNamespace");
            string eventHubName = Recording.GenerateAssetName("eventhubname");
            // first create the event hub namespace
            var eventHubNamespace = testBase.eventHubClient.Namespaces.CreateOrUpdate(
                testBase.rgName,
                eventHubNameSpaceName,
                new NamespaceCreateOrUpdateParameters(testBase.location));
            Assert.NotNull(eventHubNamespace);
            Assert.NotNull(eventHubNamespace.Name);

            // then create eventhub
            var eventHub = testBase.eventHubClient.EventHubs.CreateOrUpdate(
                testBase.rgName,
                eventHubNameSpaceName,
                eventHubName,
                new EventHubCreateOrUpdateParameters(testBase.location));
            Assert.NotNull(eventHub);

            // create send policy auth rule
            string sendPolicy = TestUtilities.GenerateName("sendPolicy");
            var eventHubAuthRule = testBase.eventHubClient.EventHubs.CreateOrUpdateAuthorizationRule(
                testBase.rgName,
                eventHubNameSpaceName,
                eventHubName,
                sendPolicy,
                new SharedAccessAuthorizationRuleCreateOrUpdateParameters()
                {
                    Rights = new List<AccessRights?>() { AccessRights.Send }
                });

            // get the keys
            var eventHubKeys = testBase.eventHubClient.EventHubs.ListKeys(
                testBase.rgName,
                eventHubNameSpaceName,
                eventHubName,
                sendPolicy);

            // now create logger using the eventhub
            var credentials = new Dictionary<string, string>();
            credentials.Add("name", eventHubName);
            credentials.Add("connectionString", eventHubKeys.PrimaryConnectionString);

            var loggerCreateParameters = new LoggerContract(LoggerType.AzureEventHub, credentials: credentials);
            // create new group with default parameters
            string loggerDescription = TestUtilities.GenerateName("newloggerDescription");
            loggerCreateParameters.Description = loggerDescription;

            var loggerContract = testBase.client.Logger.CreateOrUpdate(
                testBase.rgName,
                testBase.serviceName,
                newloggerId,
                loggerCreateParameters);

            Assert.NotNull(loggerContract);
            Assert.Equal(newloggerId, loggerContract.Name);
            Assert.True(loggerContract.IsBuffered);
            Assert.Equal(LoggerType.AzureEventHub, loggerContract.LoggerType);
            Assert.NotNull(loggerContract.Credentials);
            Assert.Equal(2, loggerContract.Credentials.Keys.Count);

            var listLoggers = testBase.client.Logger.ListByService(
                testBase.rgName,
                testBase.serviceName,
                null);

            Assert.NotNull(listLoggers);
            // there should be one user
            Assert.True(listLoggers.Count() >= 1);

            // get the logger tag
            var loggerTag = await testBase.client.Logger.GetEntityTagAsync(
                testBase.rgName,
                testBase.serviceName,
                newloggerId);
            Assert.NotNull(loggerTag);
            Assert.NotNull(loggerTag.ETag);

            // patch logger
            string patchedDescription = TestUtilities.GenerateName("patchedDescription");
            testBase.client.Logger.Update(
                testBase.rgName,
                testBase.serviceName,
                newloggerId,
                new LoggerUpdateContract(LoggerType.AzureEventHub)
                {
                    Description = patchedDescription
                },
                loggerTag.ETag);

            // get to check it was patched
            loggerContract = await testBase.client.Logger.GetAsync(
                testBase.rgName,
                testBase.serviceName,
                newloggerId);

            Assert.NotNull(loggerContract);
            Assert.Equal(newloggerId, loggerContract.Name);
            Assert.Equal(patchedDescription, loggerContract.Description);
            Assert.NotNull(loggerContract.Credentials);
            Assert.NotNull(loggerContract.CredentialsPropertyName);

            // get the logger tag
            loggerTag = await testBase.client.Logger.GetEntityTagAsync(
                testBase.rgName,
                testBase.serviceName,
                newloggerId);
            Assert.NotNull(loggerTag);
            Assert.NotNull(loggerTag.ETag);

            // delete the logger 
            testBase.client.Logger.Delete(
                testBase.rgName,
                testBase.serviceName,
                newloggerId,
                loggerTag.ETag);

        }
    }
}
