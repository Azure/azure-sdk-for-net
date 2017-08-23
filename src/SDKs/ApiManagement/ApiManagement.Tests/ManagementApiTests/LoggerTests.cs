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
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                    var loggerCreateParameters = new LoggerContract(credentials);
                    // create new group with default parameters
                    string loggerDescription = TestUtilities.GenerateName("newloggerDescription");
                    loggerCreateParameters.Description = loggerDescription;

                    var createResponse = testBase.client.Logger.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newloggerId,
                        loggerCreateParameters);

                    Assert.NotNull(createResponse);
                    Assert.Equal(newloggerId, createResponse.Name);
                    Assert.Equal(true, createResponse.IsBuffered);
                    Assert.NotNull(createResponse.Credentials);

                    // get to check it was created
                    var getResponse = await testBase.client.Logger.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newloggerId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Body);
                    Assert.Equal(newloggerId, getResponse.Body.Name);
                    Assert.NotNull(getResponse.Body.Description);
                    Assert.NotNull(getResponse.Body.Credentials);
                    Assert.Equal(2, getResponse.Body.Credentials.Keys.Count);                    

                    var listLoggers = testBase.client.Logger.ListByService(
                        testBase.rgName, 
                        testBase.serviceName,
                        null);

                    Assert.NotNull(listLoggers);
                    // there should be one user
                    Assert.True(listLoggers.Count() >= 1);

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
                        getResponse.Headers.ETag);

                    // get to check it was patched
                    getResponse = await testBase.client.Logger.GetWithHttpMessagesAsync(
                        testBase.rgName, 
                        testBase.serviceName,
                        newloggerId);

                    Assert.NotNull(getResponse);
                    Assert.NotNull(getResponse.Body);
                    Assert.Equal(newloggerId, getResponse.Body.Name);
                    Assert.Equal(patchedDescription, getResponse.Body.Description);
                    Assert.NotNull(getResponse.Body.Credentials);                    

                    // delete the logger 
                    testBase.client.Logger.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newloggerId,
                        getResponse.Headers.ETag);

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
                    testBase.eventHubClient.EventHubs.Delete(testBase.rgName, eventHubNameSpaceName, eventHubName);
                    testBase.eventHubClient.Namespaces.Delete(testBase.rgName, eventHubNameSpaceName);
                }
            }
        }        
    }
}
