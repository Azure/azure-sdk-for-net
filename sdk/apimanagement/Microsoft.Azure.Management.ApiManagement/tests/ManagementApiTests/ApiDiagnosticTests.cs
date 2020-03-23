// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.Rest.Azure;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class ApiDiagnosticTests : TestBase
    {
        [Fact]
        [Trait("owner", "glfeokti")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list all the APIs
                IPage<ApiContract> apiResponse = testBase.client.Api.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);
                Assert.NotNull(apiResponse);
                Assert.Single(apiResponse);
                Assert.Null(apiResponse.NextPageLink);

                //api to use
                ApiContract apiToUse = apiResponse.First();

                // list diagnostics: there should be none for the Api currently
                var apiDiagnostics = testBase.client.ApiDiagnostic.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    apiToUse.Name);

                Assert.NotNull(apiDiagnostics);
                Assert.Empty(apiDiagnostics);

                // create new diagnostic, supported Ids are applicationinsights, azuremonitor
                string apiDiagnosticId = "applicationinsights";
                string loggerId = TestUtilities.GenerateName("appInsights");

                try
                {
                    // create a logger
                    Guid applicationInsightsGuid = TestUtilities.GenerateGuid("appInsights");
                    var credentials = new Dictionary<string, string>();
                    credentials.Add("instrumentationKey", applicationInsightsGuid.ToString());

                    var loggerCreateParameters = new LoggerContract(LoggerType.ApplicationInsights, credentials);
                    var loggerContract = await testBase.client.Logger.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        loggerId,
                        loggerCreateParameters);
                    Assert.NotNull(loggerContract);
                    Assert.Equal(loggerId, loggerContract.Name);
                    Assert.Equal(LoggerType.ApplicationInsights, loggerContract.LoggerType);
                    Assert.NotNull(loggerContract.Credentials);
                    Assert.Equal(1, loggerContract.Credentials.Keys.Count);

                    // create a diagnostic entity with just loggerId
                    var diagnosticContractParams = new DiagnosticContract()
                    {
                        LoggerId = loggerContract.Id
                    };
                    var apiDiagnosticContract = await testBase.client.ApiDiagnostic.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        apiToUse.Name,
                        apiDiagnosticId,
                        diagnosticContractParams);
                    Assert.NotNull(apiDiagnosticContract);
                    Assert.Equal(apiDiagnosticId, apiDiagnosticContract.Name);

                    // check the diagnostic entity etag
                    var apiDiagnosticTag = await testBase.client.ApiDiagnostic.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        apiToUse.Name,
                        apiDiagnosticId);
                    Assert.NotNull(apiDiagnosticTag);
                    Assert.NotNull(apiDiagnosticTag.ETag);

                    // now update the sampling and other settings of the diagnostic
                    diagnosticContractParams.AlwaysLog = "allErrors";
                    diagnosticContractParams.Sampling = new SamplingSettings("fixed", 50);
                    var listOfHeaders = new List<string> { "Content-type" };
                    var bodyDiagnostic = new BodyDiagnosticSettings(512);
                    diagnosticContractParams.Frontend = new PipelineDiagnosticSettings
                    {
                        Request = new HttpMessageDiagnostic()
                        {
                            Body = bodyDiagnostic,
                            Headers = listOfHeaders
                        },
                        Response = new HttpMessageDiagnostic()
                        {
                            Body = bodyDiagnostic,
                            Headers = listOfHeaders
                        }
                    };
                    diagnosticContractParams.Backend = new PipelineDiagnosticSettings
                    {
                        Request = new HttpMessageDiagnostic()
                        {
                            Body = bodyDiagnostic,
                            Headers = listOfHeaders
                        },
                        Response = new HttpMessageDiagnostic()
                        {
                            Body = bodyDiagnostic,
                            Headers = listOfHeaders
                        }
                    };

                    var updatedApiDiagnostic = await testBase.client.ApiDiagnostic.CreateOrUpdateWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        apiToUse.Name,
                        apiDiagnosticId,
                        diagnosticContractParams,
                        apiDiagnosticTag.ETag);
                    Assert.NotNull(updatedApiDiagnostic);
                    Assert.Equal("allErrors", updatedApiDiagnostic.Body.AlwaysLog);
                    Assert.NotNull(updatedApiDiagnostic.Body.Sampling);
                    Assert.NotNull(updatedApiDiagnostic.Body.Frontend);
                    Assert.NotNull(updatedApiDiagnostic.Body.Backend);

                    // delete the diagnostic entity
                    await testBase.client.ApiDiagnostic.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        apiToUse.Name,
                        apiDiagnosticId,
                        updatedApiDiagnostic.Headers.ETag);

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.ApiDiagnostic.GetEntityTag(
                            testBase.rgName,
                            testBase.serviceName,
                            apiToUse.Name,
                            apiDiagnosticId));

                    // check the logger entity etag
                    var loggerTag = await testBase.client.Logger.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        loggerId);
                    Assert.NotNull(loggerTag);
                    Assert.NotNull(loggerTag.ETag);

                    // delete the logger entity
                    await testBase.client.Logger.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        loggerId,
                        loggerTag.ETag);

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Logger.GetEntityTag(testBase.rgName, testBase.serviceName, loggerId));
                }
                finally
                {
                    testBase.client.ApiDiagnostic.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        apiToUse.Name,
                        apiDiagnosticId,
                        "*");
                    testBase.client.Logger.Delete(testBase.rgName, testBase.serviceName, loggerId, "*");

                    // clean up all properties
                    var listOfProperties = testBase.client.NamedValue.ListByService(
                        testBase.rgName,
                        testBase.serviceName);
                    foreach (var property in listOfProperties)
                    {
                        testBase.client.NamedValue.Delete(
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
