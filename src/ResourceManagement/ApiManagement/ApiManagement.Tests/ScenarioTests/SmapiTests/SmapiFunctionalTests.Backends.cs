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


using System.Collections.Generic;

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.SmapiTests
{
    using System;
    using System.Net;
    using Hyak.Common;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void BackendsCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "BackendsCreateListUpdateDelete");

            try
            {
                // create new group with default parameters
                string backendId = TestUtilities.GenerateName("backendid");
                string backendName = TestUtilities.GenerateName("backendName");
                string urlParameter = new UriBuilder(Uri.UriSchemeHttps, backendName, 443).Uri.ToString();
                string protocol = Uri.UriSchemeHttp;
                
                var backendCreateParameters = new BackendCreateParameters(urlParameter, protocol);
                backendCreateParameters.Description = TestUtilities.GenerateName("description");
                backendCreateParameters.Properties.Add("skipCertificateChainValidation", true);
                backendCreateParameters.Properties.Add("skipCertificateNameValidation", true);
                backendCreateParameters.Credentials = new BackendCredentialsContract
                {
                    Authorization = new AuthorizationHeaderCredentialsContract
                    {
                        Scheme = "Basic",
                        Parameter = "opensesma"
                    }
                };
                backendCreateParameters.Credentials.Query.Add("sv", new List<string> { "xx", "bb", "cc" });
                backendCreateParameters.Credentials.Header.Add("x-my-1", new List<string> {"val1", "val2"});

                var createResponse = ApiManagementClient.Backends.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    backendId,
                    backendCreateParameters);

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get to check it was created
                var getResponse = ApiManagementClient.Backends.Get(ResourceGroupName, ApiManagementServiceName, backendId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(backendId, getResponse.Value.Id);
                Assert.NotNull(getResponse.Value.Description);
                Assert.NotNull(getResponse.Value.Credentials);
                Assert.NotNull(getResponse.Value.Properties);
                Assert.Equal(2, getResponse.Value.Properties.Keys.Count);
                Assert.Equal(1, getResponse.Value.Credentials.Query.Keys.Count);
                Assert.Equal(1, getResponse.Value.Credentials.Header.Keys.Count);
                Assert.NotNull(getResponse.Value.Credentials.Authorization);
                Assert.Equal("Basic", getResponse.Value.Credentials.Authorization.Scheme);

                var listBackends = ApiManagementClient.Backends.List(ResourceGroupName, ApiManagementServiceName, null);

                Assert.NotNull(listBackends);
                Assert.NotNull(listBackends.Result);
                Assert.NotNull(listBackends.Result.Values);

                // there should be one user
                Assert.True(listBackends.Result.TotalCount >= 1);
                Assert.True(listBackends.Result.Values.Count >= 1);

                // patch backend
                string patchedDescription = TestUtilities.GenerateName("patchedDescription");
                var patchResponse = ApiManagementClient.Backends.Update(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    backendId,
                    new BackendUpdateParameters()
                    {
                        Description = patchedDescription
                    },
                    getResponse.ETag);

                Assert.NotNull(patchResponse);

                // get to check it was patched
                getResponse = ApiManagementClient.Backends.Get(ResourceGroupName, ApiManagementServiceName, backendId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(backendId, getResponse.Value.Id);
                Assert.Equal(patchedDescription, getResponse.Value.Description);
                
                // delete the backend
                var deleteResponse = ApiManagementClient.Backends.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    backendId,
                    getResponse.ETag);

                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted backend to make sure it was deleted
                try
                {
                    ApiManagementClient.Backends.Get(ResourceGroupName, ApiManagementServiceName, backendId);
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