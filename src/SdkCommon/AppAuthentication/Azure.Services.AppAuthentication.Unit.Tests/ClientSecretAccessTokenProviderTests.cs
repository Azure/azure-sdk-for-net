// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Xunit;
using System;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Tests for ClientSecretAccessTokenProvider class. ClientSecretAccessTokenProvider is in internal class. 
    /// </summary>
    public class ClientSecretAccessTokenProviderTests
    {
        [Fact]
        public async Task ClientSecretSuccessTest()
        {
            // MockAuthenticationContext is being asked to act like client secret auth suceeded. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCredentialSuccess);

            // Create ClientSecretAccessTokenProvider instance
            ClientSecretAccessTokenProvider clientSecretAccessTokenProvider = new ClientSecretAccessTokenProvider(Constants.TestAppId, Constants.ClientSecret, Constants.TenantId, Constants.AzureAdInstance, mockAuthenticationContext);

            // Get the token
            var token = await clientSecretAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId).ConfigureAwait(false);

            // Check if the principal used and type were as expected. 
            Validator.ValidateToken(token, clientSecretAccessTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId);
        }

        /// <summary>
        /// Test that when ClientSecretAccessTokenProvider fails, the exception type and message is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ClientSecretFailTest()
        {
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCredentialFail);
            ClientSecretAccessTokenProvider clientSecretAccessTokenProvider = new ClientSecretAccessTokenProvider(Constants.TestAppId, Constants.ClientSecret, Constants.TenantId, Constants.AzureAdInstance, mockAuthenticationContext);
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => clientSecretAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, string.Empty)));

            Assert.Contains(Constants.KeyVaultResourceId, exception.Message);
            Assert.Contains(Constants.TenantId, exception.Message);
            Assert.Contains(Constants.NoConnectionString, exception.Message);
        }

        /// <summary>
        /// Test that when ClientSecretAccessTokenProvider fails, the exception type and message is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ClientSecretFailTestWithTenant()
        {
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncException);
            ClientSecretAccessTokenProvider clientSecretAccessTokenProvider = new ClientSecretAccessTokenProvider(Constants.TestAppId, Constants.ClientSecret, Constants.TenantId, Constants.AzureAdInstance, mockAuthenticationContext);
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => clientSecretAccessTokenProvider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(Constants.KeyVaultResourceId, exception.Message);
            Assert.Contains(Constants.TenantId, exception.Message);
            Assert.Contains(Constants.AdalException, exception.Message);
            Assert.Contains(Constants.NoConnectionString, exception.Message);
        }

        /// <summary>
        /// Test that when AzureServiceTokenProvider fails to get token based on ClientSecretConnString, the actual secret value is redacted in the exception. 
        /// This is important so that the secret is not logged. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ClientSecretRedactionTest()
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(Constants.ClientSecretConnString);
            
                var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => azureServiceTokenProvider.GetAccessTokenAsync(Constants.KeyVaultResourceId)));

            Assert.Contains(Constants.KeyVaultResourceId, exception.Message);
            Assert.Contains(Constants.TenantId, exception.Message);
            Assert.Contains(Constants.Redacted, exception.Message);
            Assert.DoesNotContain(Constants.ClientSecret, exception.Message);
        }

        /// <summary>
        /// If the clientId is null or empty, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void ClientIdNullOrEmptyTest()
        {
            // MockAuthenticationContext is being asked to act like client secret auth suceeded. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCredentialSuccess);

            // Create ClientSecretAccessTokenProvider instance
            var exception = Assert.Throws<ArgumentNullException>(() => new ClientSecretAccessTokenProvider(null, Constants.ClientSecret, Constants.TenantId, Constants.AzureAdInstance, mockAuthenticationContext));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());

            // Create ClientSecretAccessTokenProvider instance
            exception = Assert.Throws<ArgumentNullException>(() => new ClientSecretAccessTokenProvider(string.Empty, Constants.ClientSecret, Constants.TenantId, Constants.AzureAdInstance, mockAuthenticationContext));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());
        }

        /// <summary>
        /// If the clientSecret is null or empty, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void ClientSecretNullOrEmptyTest()
        {
            // MockAuthenticationContext is being asked to act like client secret auth suceeded. 
            MockAuthenticationContext mockAuthenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncClientCredentialSuccess);

            // Create ClientSecretAccessTokenProvider instance
            var exception = Assert.Throws<ArgumentNullException>(() => new ClientSecretAccessTokenProvider(Constants.TestAppId, null, Constants.TenantId, Constants.AzureAdInstance, mockAuthenticationContext));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());

            // Create ClientSecretAccessTokenProvider instance
            exception = Assert.Throws<ArgumentNullException>(() => new ClientSecretAccessTokenProvider(Constants.TestAppId, string.Empty, Constants.TenantId, Constants.AzureAdInstance, mockAuthenticationContext));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());
        }
    }
}
