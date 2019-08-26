// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Threading.Tasks;
using System;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class TenantGitTests : TestBase
    {
        [Fact]
        public async Task ValidateSaveDeploy()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // test git is enabled
                var getResponse = testBase.client.TenantAccessGit.Get(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(getResponse);
                Assert.True(getResponse.Enabled);

                // get the sync state of the repository
                var getSyncState = testBase.client.TenantConfiguration.GetSyncState(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(getSyncState);
                Assert.NotNull(getSyncState);
                Assert.True(getSyncState.IsGitEnabled);

                // save changes in current database to configuration database
                var saveConfigurationParameters = new SaveConfigurationParameter("master");
                OperationResultContract getSaveResponse = testBase.client.TenantConfiguration.Save(
                    testBase.rgName,
                    testBase.serviceName,
                    saveConfigurationParameters);

                Assert.NotNull(getSaveResponse);
                Assert.NotNull(getSaveResponse.Status);
                Assert.NotNull(getSaveResponse.ResultInfo);
                Assert.Null(getSaveResponse.Error);
                Assert.Equal(AsyncOperationStatus.Succeeded, getSaveResponse.Status);

                // get the sync state of the repository after Save
                getSyncState = testBase.client.TenantConfiguration.GetSyncState(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(getSyncState);
                Assert.True(getSyncState.IsGitEnabled);
                Assert.Equal("master", getSyncState.Branch);

                // validate changes in current database to configuration database
                var deployConfigurationParameters = new DeployConfigurationParameters("master");
                OperationResultContract getValidateResponse = testBase.client.TenantConfiguration.Validate(
                    testBase.rgName,
                    testBase.serviceName,
                    deployConfigurationParameters);

                Assert.NotNull(getValidateResponse);
                Assert.NotNull(getSaveResponse.ResultInfo);
                Assert.Null(getSaveResponse.Error);
                Assert.Equal(AsyncOperationStatus.Succeeded, getSaveResponse.Status);

                // deploy changes in current database to configuration database
                OperationResultContract getDeployResponse = testBase.client.TenantConfiguration.Deploy(
                    testBase.rgName,
                    testBase.serviceName,
                    deployConfigurationParameters);

                Assert.NotNull(getDeployResponse);
                Assert.NotNull(getDeployResponse.ResultInfo);
                Assert.Null(getSaveResponse.Error);
                Assert.Equal(AsyncOperationStatus.Succeeded, getDeployResponse.Status);

                // get the sync state of the repository
                var getSyncStateResponse = await testBase.client.TenantConfiguration.GetSyncStateWithHttpMessagesAsync(
                    testBase.rgName,
                    testBase.serviceName);

                Assert.NotNull(getSyncStateResponse);
                Assert.NotNull(getSyncStateResponse.Body.CommitId);
                Assert.True(getSyncStateResponse.Body.IsGitEnabled);
                Assert.True(getSyncStateResponse.Body.IsSynced);
                Assert.False(getSyncStateResponse.Body.IsExport);
                Assert.NotNull(getSyncStateResponse.Body.SyncDate);
                Assert.Equal("master", getSyncStateResponse.Body.Branch);
            }
        }
    }
}
