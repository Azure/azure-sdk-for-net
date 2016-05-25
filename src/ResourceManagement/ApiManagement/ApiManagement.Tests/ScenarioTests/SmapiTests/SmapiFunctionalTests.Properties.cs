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
        public void PropertyCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "PropertyCreateListUpdateDelete");

            try
            {
                // create non Secret property
                string propertyId = TestUtilities.GenerateName("propertyId");
                string propertyName = TestUtilities.GenerateName("propertyName");
                string propertyValue = TestUtilities.GenerateName("propertyValue");
                var propertyCreateParameters = new PropertyCreateParameters(propertyName, propertyValue);
                
                var createResponse = ApiManagementClient.Property.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    propertyId,
                    propertyCreateParameters);

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get to check it was created
                var getResponse = ApiManagementClient.Property.Get(ResourceGroupName, ApiManagementServiceName, propertyId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);

                Assert.Equal(propertyName, getResponse.Value.Name);
                Assert.Equal(propertyValue, getResponse.Value.Value);
                Assert.NotNull(getResponse.Value.Tags);
                Assert.Equal(propertyId, getResponse.Value.Id);
                Assert.Equal(false, getResponse.Value.Secret);

                // create a Secret property
                string secretPropertyId = TestUtilities.GenerateName("secretPropertyId");
                string secretPropertyName = TestUtilities.GenerateName("secretPropertyName");
                string secretPropertyValue = TestUtilities.GenerateName("secretPropertyValue");
                var secretPropertyCreateParameters = new PropertyCreateParameters(secretPropertyName, secretPropertyValue);
                secretPropertyCreateParameters.Secret = true;

                var createSecretResponse = ApiManagementClient.Property.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    secretPropertyId,
                    secretPropertyCreateParameters);

                Assert.NotNull(createSecretResponse);
                Assert.Equal(HttpStatusCode.Created, createSecretResponse.StatusCode);

                // get to check it was created
                var getSecretResponse = ApiManagementClient.Property.Get(ResourceGroupName, ApiManagementServiceName, secretPropertyId);

                Assert.NotNull(getSecretResponse);
                Assert.NotNull(getSecretResponse.Value);

                Assert.Equal(secretPropertyName, getSecretResponse.Value.Name);
                Assert.Equal(secretPropertyValue, getSecretResponse.Value.Value);
                Assert.NotNull(getSecretResponse.Value.Tags);
                Assert.Equal(secretPropertyId, getSecretResponse.Value.Id);
                Assert.Equal(true, getSecretResponse.Value.Secret);

                // list the properties
                var listResponse = ApiManagementClient.Property.List(ResourceGroupName, ApiManagementServiceName, null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);

                // there should be atleast 2 properties.
                Assert.True(listResponse.Result.TotalCount >= 2);
                Assert.True(listResponse.Result.Values.Count >= 2);

                // list paged
                listResponse = ApiManagementClient.Property.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new QueryParameters { Top = 1 });

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);
                Assert.True(listResponse.Result.TotalCount >= 2);
                Assert.Equal(1, listResponse.Result.Values.Count);

                // delete a property
                var deleteResponse = ApiManagementClient.Property.Delete(ResourceGroupName, ApiManagementServiceName, propertyId, getResponse.ETag);
                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted property to make sure it was deleted
                try
                {
                    ApiManagementClient.Property.Get(ResourceGroupName, ApiManagementServiceName, propertyId);
                    throw new Exception("This code should not have been executed.");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }

                // patch the secret Property
                string patchedSecretValue = TestUtilities.GenerateName("patchedSecret");
                var patchResponse = ApiManagementClient.Property.Update(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    secretPropertyId,
                    new PropertyUpdateParameters
                    { 
                        Value = patchedSecretValue,
                        Tags = new List<string> { "secret" }
                    },
                    getSecretResponse.ETag);

                Assert.NotNull(patchResponse);

                // get to check it was patched
                getSecretResponse = ApiManagementClient.Property.Get(ResourceGroupName, ApiManagementServiceName, secretPropertyId);

                Assert.NotNull(getSecretResponse);
                Assert.NotNull(getSecretResponse.Value);

                Assert.Equal(secretPropertyName, getSecretResponse.Value.Name);
                Assert.Equal(patchedSecretValue, getSecretResponse.Value.Value);
                Assert.Equal(true, getSecretResponse.Value.Secret);
                Assert.NotNull(getSecretResponse.Value.Tags);
                Assert.Equal(1, getSecretResponse.Value.Tags.Count);

                // delete the property 
                deleteResponse = ApiManagementClient.Property.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    secretPropertyId,
                    getSecretResponse.ETag);

                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted property to make sure it was deleted
                try
                {
                    ApiManagementClient.Property.Get(ResourceGroupName, ApiManagementServiceName, secretPropertyId);
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