// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Test cases for AzureServiceTokenProvider class. 
    /// </summary>
    public class AzureServiceTokenProviderTests
    {
        /// <summary>
        /// Test that the cache works as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTokenCacheTest()
        {
            // Create an instance of AzureServiceTokenProvider based on AzureCliAccessTokenProvider. 
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(azureCliAccessTokenProvider);
            AzureServiceTokenProvider azureServiceTokenProvider1 = new AzureServiceTokenProvider(azureCliAccessTokenProvider);

            List<Task<string>> tasks = new List<Task<string>>();

            // Use AzureServiceTokenProvider to get tokens in parallel.
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(azureServiceTokenProvider.GetAccessTokenAsync(Constants.KeyVaultResourceId));
            }

            await Task.WhenAll(tasks);
            
            // Use a new token provider instance to get a token, and check token was fetched correctly. 
            // The token is set to expire in 5 minutes and 2 seconds. 
            var token = await azureServiceTokenProvider1.GetAccessTokenAsync(Constants.KeyVaultResourceId).ConfigureAwait(false);
            Validator.ValidateToken(token, azureCliAccessTokenProvider.PrincipalUsed, Constants.UserType, Constants.TenantId);

            // Even though multiple calls are made to get token, using two different instances, the actual process manager should only be called once. 
            // This test tells us that the cache is working as intended. 
            Assert.Equal(1, mockProcessManager.HitCount);

            // Wait for 2 seconds. The previous token was created to expire in 5 minutes and 2 seconds. 
            await Task.Delay(2000);

            // It should be within 5 minutes of expiry now. 
            // Get the token again. 
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(azureServiceTokenProvider.GetAccessTokenAsync(Constants.KeyVaultResourceId));
            }

            await Task.WhenAll(tasks);

            // Hit count should be 2 now, since new token should have been aquired. 
            Assert.Equal(2, mockProcessManager.HitCount);

            AccessTokenCache.Clear();
        }

        /// <summary>
        /// Check that the exception thrown by the AzureServiceTokenProvider is as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTokenExceptionTest()
        {
            // Mock ProcessManager is being asked to act like Azure CLI is not installed. 
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.ProcessNotFound);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(azureCliAccessTokenProvider);

            await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => azureServiceTokenProvider.GetAccessTokenAsync(Constants.GraphResourceId, Constants.TenantId)));

            // Hit count should be 1, since we called Get Token once. 
            Assert.Equal(1, mockProcessManager.HitCount);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => azureServiceTokenProvider.GetAccessTokenAsync(Constants.GraphResourceId, Constants.TenantId)));

            // Hit count is 2, since token could not be fetched, and so was not in cache. 
            // This tells us that tokens are only cached if they are aquired. 
            Assert.Equal(2, mockProcessManager.HitCount);

            // Exception should contain the resource and tenant
            Assert.Contains(Constants.GraphResourceId, exception.ToString());
            Assert.Contains(Constants.TenantId, exception.ToString());
        }

        /// <summary>
        /// If azureAdInstance does not start with https, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void InvalidAzureAdInstanceTest()
        {
            var exception = Assert.Throws<ArgumentException>(() =>  new AzureServiceTokenProvider(azureAdInstance:"http://aadinstance/"));
            
            Assert.Contains(Constants.MustUseHttpsError, exception.ToString());
        }

        [Fact]
        public async Task DiscoveryTestFirstSuccess()
        {
            // Mock process manager is being asked to act like Azure CLI was able to get the token. 
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            // Mock MSI is being asked to act like MSI was able to get token. 
            MockMsi msiStubHandler = new MockMsi(MockMsi.MsiTestType.MsiAppServicesSuccess);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(msiStubHandler);

            // AzureServiceTokenProvider is being asked to use two providers, and return token from the first that succeeds.  
            var providers = new List<NonInteractiveAzureServiceTokenProviderBase> { azureCliAccessTokenProvider, msiAccessTokenProvider };
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(providers);

            var token = await azureServiceTokenProvider.GetAccessTokenAsync(Constants.GraphResourceId, Constants.TenantId);

            // Mock process manager will be hit first, and so the hit count should be 1.
            Assert.Equal(1, mockProcessManager.HitCount);

            // Msi handler will not be hit, since AzureCliAccessTokenProvider was able to return token. So this hit count should be 0. 
            Assert.Equal(0, msiStubHandler.HitCount);

            Validator.ValidateToken(token, azureServiceTokenProvider.PrincipalUsed, Constants.UserType, Constants.TenantId);

            AccessTokenCache.Clear();

        }

        [Fact]
        public async Task DiscoveryTestFirstFail()
        {
            // Mock process manager is being asked to act like Azure CLI was NOT able to get the token. 
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.ProcessNotFound);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            // Mock MSI is being asked to act like MSI was able to get token. 
            MockMsi msiStubHandler = new MockMsi(MockMsi.MsiTestType.MsiAppServicesSuccess);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(msiStubHandler);

            // AzureServiceTokenProvider is being asked to use two providers, and return token from the first that succeeds.  
            var providers = new List<NonInteractiveAzureServiceTokenProviderBase>{azureCliAccessTokenProvider, msiAccessTokenProvider};
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(providers);

            var token = await azureServiceTokenProvider.GetAccessTokenAsync(Constants.GraphResourceId, Constants.TenantId);

            // Mock process manager will be hit first, and so hit count will be 1. 
            Assert.Equal(1, mockProcessManager.HitCount);

            // AzureCliAccessTokenProvider will fail, and so Msi handler will be hit next. So hit count is 1 here.
            Assert.Equal(1, msiStubHandler.HitCount);

            // MsiAccessTokenProvider should succeed, and we should get a valid token. 
            Validator.ValidateToken(token, azureServiceTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId);

            AccessTokenCache.Clear();
        }
    }
}
