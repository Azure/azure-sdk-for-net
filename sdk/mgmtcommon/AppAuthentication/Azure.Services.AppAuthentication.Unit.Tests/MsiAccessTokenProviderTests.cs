// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Test cases for MsiAccessTokenProvider class. MsiAccessTokenProvider is an internal class. 
    /// </summary>
    public class MsiAccessTokenProviderTests : IDisposable
    {
        public void Dispose()
        {
            // Delete the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, null);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        private async Task GetTokenUsingManagedIdentityAzureVm(bool specifyUserAssignedManagedIdentity)
        {
            string expectedAppId;
            string managedIdentityArgument;
            MockMsi.MsiTestType msiTestType;

            // Determine arguments and expected values based whether user-assigned managed identity is used
            if (specifyUserAssignedManagedIdentity)
            {
                managedIdentityArgument = Constants.TestUserAssignedManagedIdentityId;
                msiTestType = MockMsi.MsiTestType.MsiUserAssignedIdentityAzureVmSuccess;
                expectedAppId = Constants.TestUserAssignedManagedIdentityId;
            }
            else
            {
                managedIdentityArgument = null;
                msiTestType = MockMsi.MsiTestType.MsiAzureVmSuccess;
                expectedAppId = Constants.TestAppId;
            }

            // MockMsi is being asked to act like response from Azure VM MSI succeeded. 
            MockMsi mockMsi = new MockMsi(msiTestType);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient, managedIdentityArgument);

            // Get token.
            var authResult = await msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            // Check if the principalused and type are as expected. 
            Validator.ValidateToken(authResult.AccessToken, msiAccessTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, expectedAppId, expiresOn: authResult.ExpiresOn);
        }

        /// <summary>
        /// If json parse error when aquiring token, an exception should be thrown. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ParseErrorMsiGetTokenTest()
        {
            // MockMsi is being asked to act like response from Azure VM MSI suceeded. 
            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppJsonParseFailure);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            // Ensure exception is thrown when getting the token
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId));

            Assert.Contains(Constants.TokenResponseFormatExceptionMessage, exception.ToString());
            Assert.Contains(Constants.JsonParseErrorException, exception.ToString());
        }

        /// <summary>
        /// If MSI response if missing the token, an exception should be thrown. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task MsiResponseMissingTokenTest()
        {
            // MockMsi is being asked to act like response from Azure VM MSI failed. 
            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiMissingToken);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            // Ensure exception is thrown when getting the token
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId));

            Assert.Contains(Constants.FailedToGetTokenError, exception.ToString());
            Assert.Contains(Constants.CannotBeNullError, exception.ToString());
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task GetTokenUsingManagedIdentityAppServices(bool specifyUserAssignedManagedIdentity)
        {
            // Setup the environment variables that App Service MSI would setup. 
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, Constants.ClientSecret);

            string expectedAppId;
            string managedIdentityArgument;
            MockMsi.MsiTestType msiTestType;

            // Determine arguments and expected values based whether user-assigned managed identity is used
            if (specifyUserAssignedManagedIdentity)
            {
                managedIdentityArgument = Constants.TestUserAssignedManagedIdentityId;
                msiTestType = MockMsi.MsiTestType.MsiUserAssignedIdentityAppServicesSuccess;
                expectedAppId = Constants.TestUserAssignedManagedIdentityId;
            }
            else
            {
                managedIdentityArgument = null;
                msiTestType = MockMsi.MsiTestType.MsiAppServicesSuccess;
                expectedAppId = Constants.TestAppId;
            }

            // MockMsi is being asked to act like response from App Service MSI suceeded. 
            MockMsi mockMsi = new MockMsi(msiTestType);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient, managedIdentityArgument);

            // Get token. This confirms that the environment variables are being read. 
            var authResult = await msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            // Delete the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, null);

            Validator.ValidateToken(authResult.AccessToken, msiAccessTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, expectedAppId, expiresOn: authResult.ExpiresOn);
        }

        /// <summary>
        /// Test response when MSI_SECRET in AppServices MSI is invalid. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UnauthorizedTest()
        {
            // Setup the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, Constants.ClientSecret);

            // MockMsi is being asked to act like response from App Service MSI failed (unauthorized). 
            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesUnauthorized);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            // Delete the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, null);

            Assert.Contains(Constants.IncorrectSecretError, exception.Message);
            Assert.Contains(HttpStatusCode.Forbidden.ToString(), exception.Message);
        }

        /// <summary>
        /// Test that response when MSI request is not valid is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task IncorrectFormatTest()
        {
            // Setup the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, Constants.ClientSecret);

            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesIncorrectRequest);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            // Delete the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, null);

            Assert.Contains(Constants.IncorrectFormatError, exception.Message);
            Assert.Contains(HttpStatusCode.BadRequest.ToString(), exception.Message);
        }

        /// <summary>
        /// If an unexpected http response has been received, ensure exception is thrown. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task HttpResponseExceptionTest()
        {
            // Setup the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, Constants.ClientSecret);

            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesFailure);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            // use test hook to expedite test
            MsiRetryHelper.WaitBeforeRetry = false;

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            // Delete the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, null);

            Assert.Contains(AzureServiceTokenProviderException.MsiEndpointNotListening, exception.Message);
        }

        [Fact]
        private async Task AzureVmImdsTimeoutTest()
        {
            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAzureVmTimeout);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            DateTime start = DateTime.Now;
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));
            TimeSpan duration = DateTime.Now - start;

            Assert.Contains(AzureServiceTokenProviderException.MsiEndpointNotListening, exception.Message);
        }

        [Theory]
        [InlineData(MockMsi.MsiTestType.MsiUnresponsive)]
        [InlineData(MockMsi.MsiTestType.MsiThrottled)]
        [InlineData(MockMsi.MsiTestType.MsiTransientServerError)]
        private async Task TransientErrorTest(MockMsi.MsiTestType testType)
        {
            MockMsi mockMsi = new MockMsi(testType);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);
            MsiRetryHelper.WaitBeforeRetry = false;

            // Get token.
            var authResult = await msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            // Check if the principalused and type are as expected. 
            Validator.ValidateToken(authResult.AccessToken, msiAccessTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId, expiresOn: authResult.ExpiresOn);
        }
    }

}
