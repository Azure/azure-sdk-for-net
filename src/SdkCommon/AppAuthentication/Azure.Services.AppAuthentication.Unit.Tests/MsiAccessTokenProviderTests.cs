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

        [Fact]
        public async Task GetTokenUsingMsiAzureVm()
        {
            // MockMsi is being asked to act like response from Azure VM MSI suceeded. 
            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAzureVmSuccess);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            // Get token.
            var token = await msiAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId,Constants.TenantId).ConfigureAwait(false);

            // Check if the principalused and type are as expected. 
            Validator.ValidateToken(token, msiAccessTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId);
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
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => msiAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId));

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
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => msiAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId));

            Assert.Contains(Constants.FailedToGetTokenError, exception.ToString());
            Assert.Contains(Constants.CannotBeNullError, exception.ToString());
        }

        [Fact]
        public async Task GetTokenUsingMsiAppServices()
        {
            // Setup the environment variables that App Service MSI would setup. 
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, Constants.ClientSecret);

            // MockMsi is being asked to act like response from App Service MSI suceeded. 
            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesSuccess);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            // Get token. This confirms that the environment variables are being read. 
            var token = await msiAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            // Delete the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, null);

            Validator.ValidateToken(token, msiAccessTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId);
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

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

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

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

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

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            // Delete the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceSecretEnv, null);

            Assert.Contains(AzureServiceTokenProviderException.MsiEndpointNotListening, exception.Message);
        }
    }
    
}
