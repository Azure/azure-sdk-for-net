// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
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
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, null);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task GetTokenUsingManagedIdentityAzureVm(bool specifyUserAssignedManagedIdentity)
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
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient, managedIdentityClientId: managedIdentityArgument);

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
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, Constants.ClientSecret);

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
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient, managedIdentityClientId: managedIdentityArgument);

            // Get token. This confirms that the environment variables are being read. 
            var authResult = await msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            Validator.ValidateToken(authResult.AccessToken, msiAccessTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, expectedAppId, expiresOn: authResult.ExpiresOn);
        }

        /// <summary>
        /// Test response when IDENTITY_HEADER in AppServices MSI is invalid. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UnauthorizedTest()
        {
            // Setup the environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, Constants.ClientSecret);

            // MockMsi is being asked to act like response from App Service MSI failed (unauthorized). 
            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesUnauthorized);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

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
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, Constants.ClientSecret);

            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesIncorrectRequest);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

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
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, Constants.ClientSecret);

            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesFailure);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            // use test hook to expedite test
            MsiRetryHelper.WaitBeforeRetry = false;

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(AzureServiceTokenProviderException.MsiEndpointNotListening, exception.Message);
        }

        [Fact]
        public async Task AzureVmImdsTimeoutTest()
        {
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, null);

            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAzureVmTimeout);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(AzureServiceTokenProviderException.MsiEndpointNotListening, exception.Message);
            Assert.DoesNotContain(AzureServiceTokenProviderException.RetryFailure, exception.Message);
        }

        [Theory]
        [InlineData(MockMsi.MsiTestType.MsiUnresponsive)]
        [InlineData(MockMsi.MsiTestType.MsiThrottled)]
        [InlineData(MockMsi.MsiTestType.MsiTransientServerError)]
        internal async Task TransientErrorRetryTest(MockMsi.MsiTestType testType)
        {
            // To simplify tests, mock as MSI App Services to skip Azure VM IDMS probe request by 
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, Constants.ClientSecret);

            MockMsi mockMsi = new MockMsi(testType);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);
            MsiRetryHelper.WaitBeforeRetry = false;

            // Get token, requests will fail several times before success
            var authResult = await msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            Validator.ValidateToken(authResult.AccessToken, msiAccessTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId, expiresOn: authResult.ExpiresOn);

            // Request for token again, subsequent requests will all fail
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(AzureServiceTokenProviderException.RetryFailure, exception.Message);

            if (testType == MockMsi.MsiTestType.MsiUnresponsive)
            {
                Assert.Contains(AzureServiceTokenProviderException.MsiEndpointNotListening, exception.Message);
            }
            else
            {
                Assert.Contains(AzureServiceTokenProviderException.GenericErrorMessage, exception.Message);
                Assert.Contains(testType.ToString(), exception.Message);
            }
        }

        [Fact]
        private async Task MsiRetryTimeoutTest()
        {
            // To simplify tests, mock as MSI App Services to skip Azure VM IDMS probe request
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, Constants.ClientSecret);

            int timeoutInSeconds = (new Random()).Next(1, 4);

            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiUnresponsive);
            HttpClient httpClient = new HttpClient(mockMsi);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient, retryTimeoutInSeconds: timeoutInSeconds);

            // Do not use test hook to skip wait, test should timeout while waiting
            MsiRetryHelper.WaitBeforeRetry = true;

            Stopwatch timer = new Stopwatch();
            timer.Start();
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId)));
            timer.Stop();

            // validate correct error message and and that total elapsed time is (roughly) the retry timeout specified
            Assert.Contains(MsiRetryHelper.RetryTimeoutError, exception.Message);
            Assert.True(timer.Elapsed.TotalSeconds - timeoutInSeconds < 1.0);
        }

#if !NETCOREAPP1_1
        [Fact]
        private async Task AppServicesDifferentCultureTest()
        {
            var defaultCulture = Thread.CurrentThread.CurrentCulture;

            try
            {
                // ensure thread culture is NOT using en-US culture (App Services MSI endpoint always uses en-US DateTime format)
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

                // Setup the environment variables that App Service MSI would setup. 
                Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
                Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, Constants.ClientSecret);

                // MockMsi is being asked to act like response from App Service MSI suceeded. 
                MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesSuccess);
                HttpClient httpClient = new HttpClient(mockMsi);
                MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(httpClient);

                // Get token.
                var authResult = await msiAccessTokenProvider.GetAuthResultAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

                // Check if the principalused and type are as expected.
                Validator.ValidateToken(authResult.AccessToken, msiAccessTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId, expiresOn: authResult.ExpiresOn);
            }
            finally
            {
                // revert back to default thread culture
                Thread.CurrentThread.CurrentCulture = defaultCulture;
            }
        }
#endif
    }
}
