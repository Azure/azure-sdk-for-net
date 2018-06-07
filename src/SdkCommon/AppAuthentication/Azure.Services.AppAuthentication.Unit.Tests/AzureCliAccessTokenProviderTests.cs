// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Tests for AzureCliAccessTokenProvider class. 
    /// </summary>
    public class AzureCliAccessTokenProviderTests
    {
        [Fact]
        public async Task GetTokenUsingAzureCliTest()
        {
            // Mock the progress manager. This emulates running an actual process e.g. az account get-access-token
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);

            // AzureCliAccessTokenProvider has in internal only constructor to allow for unit testing. 
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            // Get token and validate it
            var token = await azureCliAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            Validator.ValidateToken(token, azureCliAccessTokenProvider.PrincipalUsed, Constants.UserType, Constants.TenantId);
        }

        /// <summary>
        /// Test that if Azure CLI is not installed, the right type of exception is thrown, and that the error response is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CliNotFoundTest()
        {
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.ProcessNotFound);

            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => azureCliAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(Constants.ProgramNotFoundError, exception.Message);
        }

        /// <summary>
        /// Test that if Azure CLI failed to get token, the right type of exception is thrown, and that the error response is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task FailedToGetTokenUsingAzureCliTest()
        {
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Failure);

            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => azureCliAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(Constants.FailedToGetTokenError, exception.Message);
            Assert.Contains(Constants.DeveloperToolError, exception.Message);
        }

        /// <summary>
        /// This is a security test. The resource id should only have allowed characters. 
        /// Check that the right type of exception is thrown, and the error message is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ResourceInvalidCharsTest()
        {
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);

            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => azureCliAccessTokenProvider.GetTokenAsync("https://test^", Constants.TenantId)));

            Assert.Contains(Constants.NotInExpectedFormatError, exception.Message);
        }
    }
}
