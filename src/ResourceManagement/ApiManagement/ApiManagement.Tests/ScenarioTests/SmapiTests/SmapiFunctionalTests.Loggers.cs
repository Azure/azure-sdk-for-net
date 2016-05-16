//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.


using ApiManagement.Tests;

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.SmapiTests
{
    using System;
    using System.Net;
    using Hyak.Common;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void LoggersCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "LoggersCreateListUpdateDelete");

            try
            {
                // create new group with default parameters
                string newloggerId = TestUtilities.GenerateName("newlogger");
                string loggerDescription = TestUtilities.GenerateName("newloggerDescription");
                string eventHubName = ApiManagementHelper.EventHubName;
                string eventHubConnectionString = ApiManagementHelper.EventHubConnectionSendPolicyConnectionString;

                var credentials = new Dictionary<string, string>();
                credentials.Add("name", eventHubName);
                credentials.Add("connectionString", eventHubConnectionString);

                var loggerCreateParameters = new LoggerCreateParameters(LoggerTypeContract.AzureEventHub, credentials);
                loggerCreateParameters.Description = loggerDescription;
                
                var createResponse = ApiManagementClient.Loggers.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newloggerId,
                    loggerCreateParameters);

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get to check it was created
                var getResponse = ApiManagementClient.Loggers.Get(ResourceGroupName, ApiManagementServiceName, newloggerId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(newloggerId, getResponse.Value.Id);
                Assert.NotNull(getResponse.Value.Description);
                Assert.Equal(LoggerTypeContract.AzureEventHub, getResponse.Value.Type);

                var listLoggers = ApiManagementClient.Loggers.List(ResourceGroupName, ApiManagementServiceName, null);

                Assert.NotNull(listLoggers);
                Assert.NotNull(listLoggers.Result);
                Assert.NotNull(listLoggers.Result.Values);

                // there should be one user
                Assert.True(listLoggers.Result.TotalCount >= 1);
                Assert.True(listLoggers.Result.Values.Count >= 1);

                // patch logger
                string patchedDescription = TestUtilities.GenerateName("patchedDescription");
                var patchResponse = ApiManagementClient.Loggers.Update(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newloggerId,
                    new LoggerUpdateParameters(LoggerTypeContract.AzureEventHub) 
                    {
                        Description = patchedDescription
                    },
                    getResponse.ETag);

                Assert.NotNull(patchResponse);

                // get to check it was patched
                getResponse = ApiManagementClient.Loggers.Get(ResourceGroupName, ApiManagementServiceName, newloggerId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(newloggerId, getResponse.Value.Id);
                Assert.Equal(patchedDescription, getResponse.Value.Description);
                Assert.Equal(LoggerTypeContract.AzureEventHub, getResponse.Value.Type);

                // delete the logger 
                var deleteResponse = ApiManagementClient.Loggers.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newloggerId,
                    getResponse.ETag);

                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted logger to make sure it was deleted
                try
                {
                    ApiManagementClient.Loggers.Get(ResourceGroupName, ApiManagementServiceName, newloggerId);
                    throw new Exception("This code should not have been executed.");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}