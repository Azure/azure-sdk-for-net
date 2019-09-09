// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ApiOperationTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // there should be 'Echo API' which is created by default for every new instance of API Management

                var apis = testBase.client.Api.ListByService(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.Single(apis);
                var api = apis.Single();

                // list operations

                var listResponse = testBase.client.ApiOperation.ListByApi(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name);

                Assert.NotNull(listResponse); ;
                Assert.Equal(6, listResponse.Count());
                Assert.Null(listResponse.NextPageLink);
                foreach (var operationContract in listResponse)
                {
                    Assert.Equal(api.Name, operationContract.ApiIdentifier);
                }

                // list paged 
                listResponse = testBase.client.ApiOperation.ListByApi(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    new Microsoft.Rest.Azure.OData.ODataQuery<OperationContract> { Top = 3 });

                Assert.NotNull(listResponse);
                Assert.Equal(3, listResponse.Count());
                Assert.NotNull(listResponse.NextPageLink);
                Assert.NotEmpty(listResponse.NextPageLink);

                // list next page
                listResponse = testBase.client.ApiOperation.ListByApiNext(listResponse.NextPageLink);
                Assert.NotNull(listResponse);
                Assert.Equal(3, listResponse.Count());

                // get first operation
                var firstOperation = listResponse.First();

                var getResponse = testBase.client.ApiOperation.Get(
                    testBase.rgName,
                    testBase.serviceName,
                    api.Name,
                    firstOperation.Name);

                Assert.NotNull(getResponse);
                //Assert.Equal(firstOperation., getResponse.ApiId);
                Assert.Equal(firstOperation.Name, getResponse.Name);
                Assert.Equal(firstOperation.Method, getResponse.Method);
                Assert.Equal(firstOperation.Name, getResponse.Name);
                Assert.Equal(firstOperation.UrlTemplate, getResponse.UrlTemplate);

                // add new operation
                string newOperationId = TestUtilities.GenerateName("operationid");
                try
                {
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
                        DisplayName = newOperationName,
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

                    OperationContract createResponse = testBase.client.ApiOperation.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        newOperationId,
                        newOperation);

                    Assert.NotNull(createResponse);

                    // get the operation to check it was created
                    OperationContract apiOperationResponse = await testBase.client.ApiOperation.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        newOperationId);

                    Assert.NotNull(getResponse);

                    Assert.Equal(api.Name, apiOperationResponse.ApiIdentifier);
                    Assert.Equal(newOperationId, apiOperationResponse.Name);
                    Assert.Equal(newOperationName, apiOperationResponse.DisplayName);
                    Assert.Equal(newOperationMethod, apiOperationResponse.Method);
                    Assert.Equal(newperationUrlTemplate, apiOperationResponse.UrlTemplate);
                    Assert.Equal(newOperationDescription, apiOperationResponse.Description);

                    Assert.NotNull(apiOperationResponse.Request);
                    Assert.Equal(newOperationRequestDescription, apiOperationResponse.Request.Description);

                    Assert.NotNull(apiOperationResponse.Request.Headers);
                    Assert.Equal(1, apiOperationResponse.Request.Headers.Count);
                    Assert.Equal(newOperationRequestHeaderParamName, apiOperationResponse.Request.Headers[0].Name);
                    Assert.Equal(newOperationRequestHeaderParamDescr, apiOperationResponse.Request.Headers[0].Description);
                    Assert.Equal(newOperationRequestHeaderParamIsRequired, apiOperationResponse.Request.Headers[0].Required);
                    Assert.Equal(newOperationRequestHeaderParamDefaultValue, apiOperationResponse.Request.Headers[0].DefaultValue);
                    Assert.Equal(newOperationRequestHeaderParamType, apiOperationResponse.Request.Headers[0].Type);
                    Assert.NotNull(apiOperationResponse.Request.Headers[0].Values);
                    Assert.Equal(4, apiOperationResponse.Request.Headers[0].Values.Count);
                    Assert.True(newOperation.Request.Headers[0].Values.All(value => apiOperationResponse.Request.Headers[0].Values.Contains(value)));

                    Assert.NotNull(apiOperationResponse.Request.QueryParameters);
                    Assert.Equal(1, apiOperationResponse.Request.QueryParameters.Count);
                    Assert.Equal(newOperationRequestParmName, apiOperationResponse.Request.QueryParameters[0].Name);
                    Assert.Equal(newOperationRequestParamDescr, apiOperationResponse.Request.QueryParameters[0].Description);
                    Assert.Equal(newOperationRequestParamIsRequired, apiOperationResponse.Request.QueryParameters[0].Required);
                    Assert.Equal(newOperationRequestParamDefaultValue, apiOperationResponse.Request.QueryParameters[0].DefaultValue);
                    Assert.Equal(newOperationRequestParamType, apiOperationResponse.Request.QueryParameters[0].Type);
                    Assert.True(newOperation.Request.QueryParameters[0].Values.All(value => apiOperationResponse.Request.QueryParameters[0].Values.Contains(value)));

                    Assert.NotNull(apiOperationResponse.Request.Representations);
                    Assert.Equal(1, apiOperationResponse.Request.Representations.Count);
                    Assert.Equal(newOperationRequestRepresentationContentType, apiOperationResponse.Request.Representations[0].ContentType);
                    Assert.Equal(newOperationRequestRepresentationSample, apiOperationResponse.Request.Representations[0].Sample);

                    Assert.NotNull(apiOperationResponse.Responses);
                    Assert.Equal(1, apiOperationResponse.Responses.Count);
                    Assert.Equal(newOperationResponseDescription, apiOperationResponse.Responses[0].Description);
                    Assert.Equal(newOperationResponseStatusCode, apiOperationResponse.Responses[0].StatusCode);
                    Assert.NotNull(apiOperationResponse.Responses[0].Representations);
                    Assert.Equal(1, apiOperationResponse.Responses[0].Representations.Count);
                    Assert.Equal(newOperationResponseRepresentationContentType, apiOperationResponse.Responses[0].Representations[0].ContentType);
                    Assert.Equal(newOperationResponseRepresentationSample, apiOperationResponse.Responses[0].Representations[0].Sample);

                    // get the Api Operation Etag
                    ApiOperationGetEntityTagHeaders operationTag = await testBase.client.ApiOperation.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        newOperationId);

                    Assert.NotNull(operationTag);
                    Assert.NotNull(operationTag.ETag);

                    // patch the operation
                    string patchedName = TestUtilities.GenerateName("patchedName");
                    string patchedDescription = TestUtilities.GenerateName("patchedDescription");
                    string patchedMethod = "HEAD";

                    testBase.client.ApiOperation.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        newOperationId,
                        new OperationUpdateContract
                        {
                            DisplayName = patchedName,
                            Description = patchedDescription,
                            Method = patchedMethod
                        },
                        operationTag.ETag);


                    // get the operation to check it was patched
                    getResponse = testBase.client.ApiOperation.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        newOperationId);

                    Assert.NotNull(getResponse);

                    Assert.Equal(api.Name, getResponse.ApiIdentifier);
                    Assert.Equal(newOperationId, getResponse.Name);
                    Assert.Equal(patchedName, getResponse.DisplayName);
                    Assert.Equal(patchedMethod, getResponse.Method);
                    Assert.Equal(newperationUrlTemplate, getResponse.UrlTemplate);
                    Assert.Equal(patchedDescription, getResponse.Description);

                    Assert.NotNull(getResponse.Request);
                    Assert.Equal(newOperationRequestDescription, getResponse.Request.Description);

                    Assert.NotNull(getResponse.Request.Headers);
                    Assert.Equal(1, getResponse.Request.Headers.Count);
                    Assert.Equal(newOperationRequestHeaderParamName, getResponse.Request.Headers[0].Name);
                    Assert.Equal(newOperationRequestHeaderParamDescr, getResponse.Request.Headers[0].Description);
                    Assert.Equal(newOperationRequestHeaderParamIsRequired, getResponse.Request.Headers[0].Required);
                    Assert.Equal(newOperationRequestHeaderParamDefaultValue, getResponse.Request.Headers[0].DefaultValue);
                    Assert.Equal(newOperationRequestHeaderParamType, getResponse.Request.Headers[0].Type);
                    Assert.NotNull(getResponse.Request.Headers[0].Values);
                    Assert.Equal(4, getResponse.Request.Headers[0].Values.Count);
                    Assert.True(newOperation.Request.Headers[0].Values.All(value => getResponse.Request.Headers[0].Values.Contains(value)));

                    Assert.NotNull(getResponse.Request.QueryParameters);
                    Assert.Equal(1, getResponse.Request.QueryParameters.Count);
                    Assert.Equal(newOperationRequestParmName, getResponse.Request.QueryParameters[0].Name);
                    Assert.Equal(newOperationRequestParamDescr, getResponse.Request.QueryParameters[0].Description);
                    Assert.Equal(newOperationRequestParamIsRequired, getResponse.Request.QueryParameters[0].Required);
                    Assert.Equal(newOperationRequestParamDefaultValue, getResponse.Request.QueryParameters[0].DefaultValue);
                    Assert.Equal(newOperationRequestParamType, getResponse.Request.QueryParameters[0].Type);
                    Assert.True(newOperation.Request.QueryParameters[0].Values.All(value => getResponse.Request.QueryParameters[0].Values.Contains(value)));

                    Assert.NotNull(getResponse.Request.Representations);
                    Assert.Equal(1, getResponse.Request.Representations.Count);
                    Assert.Equal(newOperationRequestRepresentationContentType, getResponse.Request.Representations[0].ContentType);
                    Assert.Equal(newOperationRequestRepresentationSample, getResponse.Request.Representations[0].Sample);

                    Assert.NotNull(getResponse.Responses);
                    Assert.Equal(1, getResponse.Responses.Count);
                    Assert.Equal(newOperationResponseDescription, getResponse.Responses[0].Description);
                    Assert.Equal(newOperationResponseStatusCode, getResponse.Responses[0].StatusCode);
                    Assert.NotNull(getResponse.Responses[0].Representations);
                    Assert.Equal(1, getResponse.Responses[0].Representations.Count);
                    Assert.Equal(newOperationResponseRepresentationContentType, getResponse.Responses[0].Representations[0].ContentType);
                    Assert.Equal(newOperationResponseRepresentationSample, getResponse.Responses[0].Representations[0].Sample);

                    // get the tag again
                    operationTag = await testBase.client.ApiOperation.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        newOperationId);
                    Assert.NotNull(operationTag);
                    Assert.NotNull(operationTag.ETag);

                    // delete the operation
                    testBase.client.ApiOperation.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        api.Name,
                        newOperationId,
                        operationTag.ETag);

                    // get the deleted operation to make sure it was deleted
                    try
                    {
                        testBase.client.ApiOperation.Get(testBase.rgName, testBase.serviceName, api.Name, newOperationId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    testBase.client.ApiOperation.Delete(testBase.rgName, testBase.serviceName, api.Name, newOperationId, "*");
                }
            }
        }
    }
}
