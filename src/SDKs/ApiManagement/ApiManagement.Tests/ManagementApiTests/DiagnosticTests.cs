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
using ApiManagementManagement.Tests.Helpers;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class DiagnosticTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                // create new diagnostic
                string diagnosticId = TestUtilities.GenerateName("diagnoticId");
                string loggerId = TestUtilities.GenerateName("appInsights");

                try
                {
                    // create a diagnostic entity
                    var diagnosticContractParams = new DiagnosticContract()
                    {
                        Enabled = true
                    };
                    var diagnosticContract = await testBase.client.Diagnostic.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        diagnosticId,
                        diagnosticContractParams);
                    Assert.NotNull(diagnosticContract);
                    Assert.Equal(diagnosticId, diagnosticContract.Name);
                    Assert.Equal(diagnosticContractParams.Enabled, diagnosticContract.Enabled);

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

                    // create a diagnostic logger
                    loggerContract = await testBase.client.DiagnosticLogger.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        diagnosticId,
                        loggerId);
                    Assert.NotNull(loggerContract);
                    Assert.Equal(loggerId, loggerContract.Name);
                    Assert.Equal(LoggerType.ApplicationInsights, loggerContract.LoggerType);
                    
                    //list diagnostic loggers
                    var loggerContractList = await testBase.client.DiagnosticLogger.ListByServiceAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        diagnosticId);
                    Assert.NotNull(loggerContractList);
                    Assert.Single(loggerContractList);
                    Assert.Equal(loggerId, loggerContractList.GetEnumerator().ToIEnumerable().First().Name);
                    Assert.Equal(LoggerType.ApplicationInsights, loggerContractList.GetEnumerator().ToIEnumerable().First().LoggerType);
                    
                    // delete the diagnostic logger relationship
                    await testBase.client.DiagnosticLogger.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        diagnosticId,
                        loggerId);

                    var entitystatus = testBase.client.DiagnosticLogger.CheckEntityExists(testBase.rgName, testBase.serviceName, diagnosticId, loggerId);
                    Assert.False(entitystatus);

                    // check the diagnostic entity etag
                    var diagnosticTag = await testBase.client.Diagnostic.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        diagnosticId);
                    Assert.NotNull(diagnosticTag);
                    Assert.NotNull(diagnosticTag.ETag);

                    // delete the diagnostic entity
                    await testBase.client.Diagnostic.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        diagnosticId,
                        diagnosticTag.ETag);

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
                    testBase.client.Logger.Delete(testBase.rgName, testBase.serviceName, loggerId, "*");
                    testBase.client.Diagnostic.Delete(testBase.rgName, testBase.serviceName, diagnosticId, "*");
                }
            }
        }
    }
}
