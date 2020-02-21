// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class DiagnosticTests : TestBase
    {
        [Fact]
        [Trait("owner", "vifedo")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list diagnostics: there should be none
                var diagnostics = testBase.client.Diagnostic.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(diagnostics);
                Assert.Empty(diagnostics);

                // create new diagnostic, supported Ids are applicationinsights, azuremonitor
                string diagnosticId = "applicationinsights";
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
                    var diagnosticContract = await testBase.client.Diagnostic.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        diagnosticId,
                        diagnosticContractParams);
                    Assert.NotNull(diagnosticContract);
                    Assert.Equal(diagnosticId, diagnosticContract.Name);

                    // check the diagnostic entity etag
                    var diagnosticTag = await testBase.client.Diagnostic.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        diagnosticId);
                    Assert.NotNull(diagnosticTag);
                    Assert.NotNull(diagnosticTag.ETag);

                    // now update the sampling and other settings of the diagnostic
                    diagnosticContractParams.EnableHttpCorrelationHeaders = true;
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

                    var updatedDiagnostic = await testBase.client.Diagnostic.CreateOrUpdateWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        diagnosticId,
                        diagnosticContractParams,
                        diagnosticTag.ETag);
                    Assert.NotNull(updatedDiagnostic);
                    Assert.True(updatedDiagnostic.Body.EnableHttpCorrelationHeaders.Value);
                    Assert.Equal("allErrors", updatedDiagnostic.Body.AlwaysLog);
                    Assert.NotNull(updatedDiagnostic.Body.Sampling);
                    Assert.NotNull(updatedDiagnostic.Body.Frontend);
                    Assert.NotNull(updatedDiagnostic.Body.Backend);
                    Assert.NotNull(updatedDiagnostic.Body.HttpCorrelationProtocol);
                    Assert.Equal(HttpCorrelationProtocol.Legacy, updatedDiagnostic.Body.HttpCorrelationProtocol);

                    // delete the diagnostic entity
                    await testBase.client.Diagnostic.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        diagnosticId,
                        updatedDiagnostic.Headers.ETag);

                    Assert.Throws<ErrorResponseException>(()
                        => testBase.client.Diagnostic.GetEntityTag(testBase.rgName, testBase.serviceName, diagnosticId));

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
                    testBase.client.Diagnostic.Delete(testBase.rgName, testBase.serviceName, diagnosticId, "*");
                    testBase.client.Logger.Delete(testBase.rgName, testBase.serviceName, loggerId, "*");
                }
            }
        }
    }
}
