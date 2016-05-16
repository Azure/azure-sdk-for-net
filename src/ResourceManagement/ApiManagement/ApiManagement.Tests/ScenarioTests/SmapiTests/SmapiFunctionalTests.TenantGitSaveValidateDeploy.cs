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
    using System.Net;
    using Microsoft.Azure.Test;
    using SmapiModels;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void TenantGitSaveValidateAndDeploy()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "TenantGitSaveValidateAndDeploy");

            try
            {
                var getResponse = ApiManagementClient.TenantAccessGit.Get(ResourceGroupName, ApiManagementServiceName);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

                // enable git access
                var parameters = new AccessInformationUpdateParameters
                {
                    Enabled = true
                };
                var response = ApiManagementClient.TenantAccessGit.Update(ResourceGroupName,
                    ApiManagementServiceName, parameters, getResponse.ETag);

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

                // test git is enabled
                getResponse = ApiManagementClient.TenantAccessGit.Get(ResourceGroupName, ApiManagementServiceName);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.True(getResponse.Value.Enabled);
                
                // get the sync state of the repository
                var getSyncState = ApiManagementClient.TenantConfigurationSyncState.Get(ResourceGroupName,
                    ApiManagementServiceName);

                Assert.NotNull(getSyncState);
                Assert.NotNull(getSyncState.Value);
                Assert.True(getSyncState.Value.IsGitEnabled);

                // save changes in current database to configuration database
                var saveConfigurationParameters = new SaveConfigurationParameter("master");
                var getSaveResponse = ApiManagementClient.TenantConfiguration.Save(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    saveConfigurationParameters);

                Assert.NotNull(getSaveResponse);
                Assert.Equal(HttpStatusCode.OK, getSaveResponse.StatusCode);
                Assert.NotNull(getSaveResponse.OperationResult);
                Assert.Equal(AsyncOperationState.Succeeded, getSaveResponse.OperationResult.Status);

                // get the sync state of the repository after Save
                getSyncState = ApiManagementClient.TenantConfigurationSyncState.Get(ResourceGroupName,
                    ApiManagementServiceName);

                Assert.NotNull(getSyncState);
                Assert.NotNull(getSyncState.Value);
                Assert.True(getSyncState.Value.IsGitEnabled);
                Assert.Equal("master", getSyncState.Value.Branch);

                // validate changes in current database to configuration database
                var deployConfigurationParameters = new DeployConfigurationParameters("master");
                var getValidateResponse = ApiManagementClient.TenantConfiguration.Validate(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    deployConfigurationParameters);

                Assert.NotNull(getValidateResponse);
                Assert.Equal(HttpStatusCode.OK, getValidateResponse.StatusCode);
                Assert.NotNull(getSaveResponse.OperationResult);
                Assert.Equal(AsyncOperationState.Succeeded, getSaveResponse.OperationResult.Status);

                // deploy changes in current database to configuration database
                var getDeployResponse = ApiManagementClient.TenantConfiguration.Deploy(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    deployConfigurationParameters);

                Assert.NotNull(getDeployResponse);
                Assert.Equal(HttpStatusCode.OK, getDeployResponse.StatusCode);
                Assert.NotNull(getSaveResponse.OperationResult);
                Assert.Equal(AsyncOperationState.Succeeded, getSaveResponse.OperationResult.Status);

                // get the sync state of the repository
                getSyncState = ApiManagementClient.TenantConfigurationSyncState.Get(ResourceGroupName,
                    ApiManagementServiceName);

                Assert.NotNull(getSyncState);
                Assert.NotNull(getSyncState.Value);
                Assert.True(getSyncState.Value.IsGitEnabled);
                Assert.Equal("master", getSyncState.Value.Branch);

                // disable git access
                parameters.Enabled = false;

                response = ApiManagementClient.TenantAccessGit.Update(ResourceGroupName,
                    ApiManagementServiceName, parameters, getResponse.ETag);

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

                // test git is disabled
                getResponse = ApiManagementClient.TenantAccessGit.Get(ResourceGroupName, ApiManagementServiceName);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.False(getResponse.Value.Enabled);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}