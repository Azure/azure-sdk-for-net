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
    using System.Linq;
    using System.Net;
    using Hyak.Common;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Newtonsoft.Json;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void ApiOperationsCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ApiOperationsCreateListUpdateDelete");

            try
            {
                // there should be 'Echo API' which is created by default for every new instance of API Management

                var apis = ApiManagementClient.Apis.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    null);

                var api = apis.Result.Values.Single();

                // list operations

                var listResponse = ApiManagementClient.ApiOperations.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.Equal(6, listResponse.Result.TotalCount);
                Assert.Equal(6, listResponse.Result.Values.Count);
                Assert.Null(listResponse.Result.NextLink);
                foreach (var operationContract in listResponse.Result.Values)
                {
                    Assert.Equal(api.Id, operationContract.ApiId);
                }

                // list paged 
                listResponse = ApiManagementClient.ApiOperations.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    new QueryParameters {Top = 3});

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.Equal(6, listResponse.Result.TotalCount);
                Assert.Equal(3, listResponse.Result.Values.Count);
                Assert.NotNull(listResponse.Result.NextLink);

                // list next page
                listResponse = ApiManagementClient.ApiOperations.ListNext(listResponse.Result.NextLink);
                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.Equal(6, listResponse.Result.TotalCount);
                Assert.Equal(3, listResponse.Result.Values.Count);

                // get first operation
                var firstOperation = listResponse.Result.Values.First();

                var getResponse = ApiManagementClient.ApiOperations.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    firstOperation.OperationId);

                Assert.NotNull(getResponse);
                Assert.Equal(firstOperation.ApiId, getResponse.Value.ApiId);
                Assert.Equal(firstOperation.OperationId, getResponse.Value.OperationId);
                Assert.Equal(firstOperation.Method, getResponse.Value.Method);
                Assert.Equal(firstOperation.Name, getResponse.Value.Name);
                Assert.Equal(firstOperation.UrlTemplate, getResponse.Value.UrlTemplate);

                // add new operation
                string newOperationId = TestUtilities.GenerateName("operationid");
                string newOperationName = TestUtilities.GenerateName("operationName");
                string newOperationMethod = "PATCH";
                string newperationUrlTemplate = "/newresource";
                string newOperationDescription = TestUtilities.GenerateName("operationDescription");
                string newOperationRequestDescription = TestUtilities.GenerateName("operationRequestDescription");

                string newOperationRequestHeaderParamName = TestUtilities.GenerateName("newOperationRequestHeaderParmName");
                string newOperationRequestHeaderParamDescr = TestUtilities.GenerateName("newOperationRequestHeaderParamDescr");
                bool newOperationRequestHeaderParamIsRequired = true;
                string newOperationRequestHeaderParamDefaultValue = TestUtilities.GenerateName("newOperationRequestHeaderParamDefaultValue");
                string newOperationRequestHeaderParamType = "string";

                string newOperationRequestParmName = TestUtilities.GenerateName("newOperationRequestParmName");
                string newOperationRequestParamDescr = TestUtilities.GenerateName("newOperationRequestParamDescr");
                bool newOperationRequestParamIsRequired = true;
                string newOperationRequestParamDefaultValue = TestUtilities.GenerateName("newOperationRequestParamDefaultValue");
                string newOperationRequestParamType = "string";

                string newOperationRequestRepresentationContentType = TestUtilities.GenerateName("newOperationRequestRepresentationContentType");
                string newOperationRequestRepresentationSample = TestUtilities.GenerateName("newOperationRequestRepresentationSample");

                string newOperationResponseDescription = TestUtilities.GenerateName("newOperationResponseDescription");
                int newOperationResponseStatusCode = 1980785443;
                string newOperationResponseRepresentationContentType = TestUtilities.GenerateName("newOperationResponseRepresentationContentType");
                string newOperationResponseRepresentationSample = TestUtilities.GenerateName("newOperationResponseRepresentationSample");

                var newOperation = new OperationContract
                {
                    Name = newOperationName,
                    Method = newOperationMethod,
                    UrlTemplate = newperationUrlTemplate,
                    Description = newOperationDescription,
                    Request = new RequestContract
                    {
                        Description = newOperationRequestDescription,
                        Headers = new[]
                        {
                            new ParameterContract
                            {
                                Name = newOperationRequestHeaderParamName,
                                Description = newOperationRequestHeaderParamDescr,
                                Required = newOperationRequestHeaderParamIsRequired,
                                DefaultValue = newOperationRequestHeaderParamDefaultValue,
                                Type = newOperationRequestHeaderParamType,
                                Values = new[] {newOperationRequestHeaderParamDefaultValue, "1", "2", "3"}
                            }
                        },
                        QueryParameters = new[]
                        {
                            new ParameterContract
                            {
                                Name = newOperationRequestParmName,
                                Description = newOperationRequestParamDescr,
                                Required = newOperationRequestParamIsRequired,
                                DefaultValue = newOperationRequestParamDefaultValue,
                                Type = newOperationRequestParamType,
                                Values = new[] {newOperationRequestParamDefaultValue, "1", "2", "3"}
                            }
                        },
                        Representations = new[]
                        {
                            new RepresentationContract
                            {
                                ContentType = newOperationRequestRepresentationContentType,
                                Sample = newOperationRequestRepresentationSample
                            }
                        }
                    },
                    Responses = new[]
                    {
                        new ResponseContract
                        {
                            Description = newOperationResponseDescription,
                            StatusCode = newOperationResponseStatusCode,
                            Representations = new[]
                            {
                                new RepresentationContract
                                {
                                    ContentType = newOperationResponseRepresentationContentType,
                                    Sample = newOperationResponseRepresentationSample
                                }
                            }
                        }
                    }
                };

                var createResponse = ApiManagementClient.ApiOperations.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    newOperationId,
                    new OperationCreateOrUpdateParameters(newOperation));

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get the operation to check it was created
                getResponse = ApiManagementClient.ApiOperations.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    newOperationId);

                Assert.NotNull(getResponse);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

                Assert.Equal(api.Id, getResponse.Value.ApiId);
                Assert.Equal(newOperationId, getResponse.Value.OperationId);
                Assert.Equal(newOperationName, getResponse.Value.Name);
                Assert.Equal(newOperationMethod, getResponse.Value.Method);
                Assert.Equal(newperationUrlTemplate, getResponse.Value.UrlTemplate);
                Assert.Equal(newOperationDescription, getResponse.Value.Description);

                Assert.NotNull(getResponse.Value.Request);
                Assert.Equal(newOperationRequestDescription, getResponse.Value.Request.Description);

                Assert.NotNull(getResponse.Value.Request.Headers);
                Assert.Equal(1, getResponse.Value.Request.Headers.Count);
                Assert.Equal(newOperationRequestHeaderParamName, getResponse.Value.Request.Headers[0].Name);
                Assert.Equal(newOperationRequestHeaderParamDescr, getResponse.Value.Request.Headers[0].Description);
                Assert.Equal(newOperationRequestHeaderParamIsRequired, getResponse.Value.Request.Headers[0].Required);
                Assert.Equal(newOperationRequestHeaderParamDefaultValue, getResponse.Value.Request.Headers[0].DefaultValue);
                Assert.Equal(newOperationRequestHeaderParamType, getResponse.Value.Request.Headers[0].Type);
                Assert.NotNull(getResponse.Value.Request.Headers[0].Values);
                Assert.Equal(4, getResponse.Value.Request.Headers[0].Values.Count);
                Assert.True(newOperation.Request.Headers[0].Values.All(value => getResponse.Value.Request.Headers[0].Values.Contains(value)));

                Assert.NotNull(getResponse.Value.Request.QueryParameters);
                Assert.Equal(1, getResponse.Value.Request.QueryParameters.Count);
                Assert.Equal(newOperationRequestParmName, getResponse.Value.Request.QueryParameters[0].Name);
                Assert.Equal(newOperationRequestParamDescr, getResponse.Value.Request.QueryParameters[0].Description);
                Assert.Equal(newOperationRequestParamIsRequired, getResponse.Value.Request.QueryParameters[0].Required);
                Assert.Equal(newOperationRequestParamDefaultValue, getResponse.Value.Request.QueryParameters[0].DefaultValue);
                Assert.Equal(newOperationRequestParamType, getResponse.Value.Request.QueryParameters[0].Type);
                Assert.True(newOperation.Request.QueryParameters[0].Values.All(value => getResponse.Value.Request.QueryParameters[0].Values.Contains(value)));

                Assert.NotNull(getResponse.Value.Request.Representations);
                Assert.Equal(1, getResponse.Value.Request.Representations.Count);
                Assert.Equal(newOperationRequestRepresentationContentType, getResponse.Value.Request.Representations[0].ContentType);
                Assert.Equal(newOperationRequestRepresentationSample, getResponse.Value.Request.Representations[0].Sample);

                Assert.NotNull(getResponse.Value.Responses);
                Assert.Equal(1, getResponse.Value.Responses.Count);
                Assert.Equal(newOperationResponseDescription, getResponse.Value.Responses[0].Description);
                Assert.Equal(newOperationResponseStatusCode, getResponse.Value.Responses[0].StatusCode);
                Assert.NotNull(getResponse.Value.Responses[0].Representations);
                Assert.Equal(1, getResponse.Value.Responses[0].Representations.Count);
                Assert.Equal(newOperationResponseRepresentationContentType, getResponse.Value.Responses[0].Representations[0].ContentType);
                Assert.Equal(newOperationResponseRepresentationSample, getResponse.Value.Responses[0].Representations[0].Sample);

                // patch the operation
                string patchedName = TestUtilities.GenerateName("patchedName");
                string patchedDescription = TestUtilities.GenerateName("patchedDescription");
                string patchedMethod = "HEAD";

                var patchResponse = ApiManagementClient.ApiOperations.Patch(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    newOperationId,
                    new PatchParameters
                    {
                        RawJson = JsonConvert.SerializeObject(
                            new
                            {
                                Name = patchedName,
                                Description = patchedDescription,
                                Method = patchedMethod
                            })
                    },
                    getResponse.ETag);

                Assert.NotNull(patchResponse);
                Assert.Equal(HttpStatusCode.NoContent, patchResponse.StatusCode);

                // get the operation to check it was patched
                getResponse = ApiManagementClient.ApiOperations.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    newOperationId);

                Assert.NotNull(getResponse);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

                Assert.Equal(api.Id, getResponse.Value.ApiId);
                Assert.Equal(newOperationId, getResponse.Value.OperationId);
                Assert.Equal(patchedName, getResponse.Value.Name);
                Assert.Equal(patchedMethod, getResponse.Value.Method);
                Assert.Equal(newperationUrlTemplate, getResponse.Value.UrlTemplate);
                Assert.Equal(patchedDescription, getResponse.Value.Description);

                Assert.NotNull(getResponse.Value.Request);
                Assert.Equal(newOperationRequestDescription, getResponse.Value.Request.Description);

                Assert.NotNull(getResponse.Value.Request.Headers);
                Assert.Equal(1, getResponse.Value.Request.Headers.Count);
                Assert.Equal(newOperationRequestHeaderParamName, getResponse.Value.Request.Headers[0].Name);
                Assert.Equal(newOperationRequestHeaderParamDescr, getResponse.Value.Request.Headers[0].Description);
                Assert.Equal(newOperationRequestHeaderParamIsRequired, getResponse.Value.Request.Headers[0].Required);
                Assert.Equal(newOperationRequestHeaderParamDefaultValue, getResponse.Value.Request.Headers[0].DefaultValue);
                Assert.Equal(newOperationRequestHeaderParamType, getResponse.Value.Request.Headers[0].Type);
                Assert.NotNull(getResponse.Value.Request.Headers[0].Values);
                Assert.Equal(4, getResponse.Value.Request.Headers[0].Values.Count);
                Assert.True(newOperation.Request.Headers[0].Values.All(value => getResponse.Value.Request.Headers[0].Values.Contains(value)));

                Assert.NotNull(getResponse.Value.Request.QueryParameters);
                Assert.Equal(1, getResponse.Value.Request.QueryParameters.Count);
                Assert.Equal(newOperationRequestParmName, getResponse.Value.Request.QueryParameters[0].Name);
                Assert.Equal(newOperationRequestParamDescr, getResponse.Value.Request.QueryParameters[0].Description);
                Assert.Equal(newOperationRequestParamIsRequired, getResponse.Value.Request.QueryParameters[0].Required);
                Assert.Equal(newOperationRequestParamDefaultValue, getResponse.Value.Request.QueryParameters[0].DefaultValue);
                Assert.Equal(newOperationRequestParamType, getResponse.Value.Request.QueryParameters[0].Type);
                Assert.True(newOperation.Request.QueryParameters[0].Values.All(value => getResponse.Value.Request.QueryParameters[0].Values.Contains(value)));

                Assert.NotNull(getResponse.Value.Request.Representations);
                Assert.Equal(1, getResponse.Value.Request.Representations.Count);
                Assert.Equal(newOperationRequestRepresentationContentType, getResponse.Value.Request.Representations[0].ContentType);
                Assert.Equal(newOperationRequestRepresentationSample, getResponse.Value.Request.Representations[0].Sample);

                Assert.NotNull(getResponse.Value.Responses);
                Assert.Equal(1, getResponse.Value.Responses.Count);
                Assert.Equal(newOperationResponseDescription, getResponse.Value.Responses[0].Description);
                Assert.Equal(newOperationResponseStatusCode, getResponse.Value.Responses[0].StatusCode);
                Assert.NotNull(getResponse.Value.Responses[0].Representations);
                Assert.Equal(1, getResponse.Value.Responses[0].Representations.Count);
                Assert.Equal(newOperationResponseRepresentationContentType, getResponse.Value.Responses[0].Representations[0].ContentType);
                Assert.Equal(newOperationResponseRepresentationSample, getResponse.Value.Responses[0].Representations[0].Sample);

                // delete the operation
                var deleteResponse = ApiManagementClient.ApiOperations.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    newOperationId,
                    "*");

                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted operation to make sure it was deleted
                try
                {
                    ApiManagementClient.ApiOperations.Get(ResourceGroupName, ApiManagementServiceName, api.Id, newOperationId);
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