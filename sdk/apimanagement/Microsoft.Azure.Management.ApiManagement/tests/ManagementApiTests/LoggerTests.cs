// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.EventHub.Models;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Net;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class LoggerTests : TestBase
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public async Task CreateListUpdateDeleteEventHub()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                string newloggerId = TestUtilities.GenerateName("newlogger");
                string eventHubNameSpaceName = TestUtilities.GenerateName("eventHubNamespace");
                string eventHubName = TestUtilities.GenerateName("eventhubname");

                try
                {
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

                    var loggerCreateParameters = new LoggerContract(LoggerType.AzureEventHub, credentials);
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

                    // get the deleted logger to make sure it was deleted
                    try
                    {
                        testBase.client.Logger.Get(testBase.rgName, testBase.serviceName, newloggerId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    testBase.client.Logger.Delete(testBase.rgName, testBase.serviceName, newloggerId, "*");
                    // clean up all properties
                    var listOfProperties = testBase.client.Property.ListByService(
                        testBase.rgName,
                        testBase.serviceName);
                    foreach (var property in listOfProperties)
                    {
                        testBase.client.Property.Delete(
                            testBase.rgName,
                            testBase.serviceName,
                            property.Name,
                            "*");
                    }
                    testBase.eventHubClient.EventHubs.Delete(testBase.rgName, eventHubNameSpaceName, eventHubName);
                    testBase.eventHubClient.Namespaces.Delete(testBase.rgName, eventHubNameSpaceName);
                }
            }
        }

        [Fact]
        [Trait("owner", "sasolank")]
        public async Task CreateListUpdateDeleteApplicationInsights()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                string newloggerId = TestUtilities.GenerateName("applicationInsight");

                try
                {
                    // now create logger using the event
                    Guid applicationInsightsGuid = TestUtilities.GenerateGuid("appInsights");
                    var credentials = new Dictionary<string, string>();
                    credentials.Add("instrumentationKey", applicationInsightsGuid.ToString());

                    var loggerCreateParameters = new LoggerContract(LoggerType.ApplicationInsights, credentials);
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
                    Assert.Equal(LoggerType.ApplicationInsights, loggerContract.LoggerType);
                    Assert.NotNull(loggerContract.Credentials);
                    Assert.Equal(1, loggerContract.Credentials.Keys.Count);

                    var listLoggers = testBase.client.Logger.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        null);

                    Assert.NotNull(listLoggers);
                    // there should be atleast one logger
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
                        new LoggerUpdateContract(LoggerType.ApplicationInsights)
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

                    // get the deleted logger to make sure it was deleted
                    try
                    {
                        testBase.client.Logger.Get(testBase.rgName, testBase.serviceName, newloggerId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    testBase.client.Logger.Delete(testBase.rgName, testBase.serviceName, newloggerId, "*");
                    var listOfProperties = testBase.client.Property.ListByService(
                        testBase.rgName,
                        testBase.serviceName);

                    foreach (var property in listOfProperties)
                    {
                        testBase.client.Property.Delete(
                            testBase.rgName,
                            testBase.serviceName,
                            property.Name,
                            "*");
                    }
                }
            }
        }
    }
}
