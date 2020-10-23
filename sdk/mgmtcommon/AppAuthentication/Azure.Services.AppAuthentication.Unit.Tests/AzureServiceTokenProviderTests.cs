﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Microsoft.Azure.Services.AppAuthentication.Unit.Tests.Mocks;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Test cases for AzureServiceTokenProvider class. 
    /// </summary>
    public class AzureServiceTokenProviderTests : IDisposable
    {
        public void Dispose()
        {
            // Clear the cache after running each test.
            AppAuthResultCache.Clear();

            // Delete environment variables
            Environment.SetEnvironmentVariable(Constants.TestCertUrlEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, null);
        }

        /// <summary>
        /// Test that the cache works as expected. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAppAuthResultCacheTest()
        {
            // Create two instances of AzureServiceTokenProvider based on AzureCliAccessTokenProvider. 
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(azureCliAccessTokenProvider);
            AzureServiceTokenProvider azureServiceTokenProvider1 = new AzureServiceTokenProvider(azureCliAccessTokenProvider);

            List<Task> tasks = new List<Task>();

            // ManualResetEvent will enable testing of SemaphoreSlim used in AzureServiceTokenProvider.
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);

            // Use AzureServiceTokenProviders to get tokens in parallel.
            for (int i = 0; i < 5; i++)
            {
                Task task = Task.Run(async delegate
                {
                    // This will prevent the next line from running, until manualResetEvent.Set() is called. 
                    // This will ensure all GetAccessTokenAsync calls are made at once.
                    manualResetEvent.WaitOne();

                    await azureServiceTokenProvider.GetAccessTokenAsync(Constants.KeyVaultResourceId);
                });

                tasks.Add(task);

                Task task1 = Task.Run(async delegate
                {
                    manualResetEvent.WaitOne();

                    // This is using the other instance of AzureServiceTokenProvider.
                    await azureServiceTokenProvider1.GetAccessTokenAsync(Constants.KeyVaultResourceId);
                });

                tasks.Add(task1);
            }

            // This will cause GetAccessTokenAsync calls to be made concurrently. 
            manualResetEvent.Set();
            await Task.WhenAll(tasks);

            // Even though multiple calls are made to get token concurrently, using two different instances, the process manager should only be called once. 
            // This test tells us that the cache is working as intended. 
            Assert.Equal(1, mockProcessManager.HitCount);

            // Get the token again. This will test if the cache call before semaphore use is working as intended.
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(azureServiceTokenProvider.GetAccessTokenAsync(Constants.KeyVaultResourceId));
            }

            await Task.WhenAll(tasks);

            // The hit count should still be 1, since the token should be fetched from cache. 
            Assert.Equal(1, mockProcessManager.HitCount);

            // Update the cache entry, to simulate token expiration. This updated token will expire in just less than 5 minutes. 
            // In a real scenario, the token will expire after some time. 
            // AppAuthResultCache should not return this, since it is about to expire. 
            var tokenResponse = TokenResponse.Parse(TokenHelper.GetUserTokenResponse(5 * 60 - 2));
            var authResult = AppAuthenticationResult.Create(tokenResponse);
            AppAuthResultCache.AddOrUpdate("ConnectionString:;Authority:;Resource:https://vault.azure.net/",
                new Tuple<AppAuthenticationResult, Principal>(authResult, null));

            // Get the token again. 
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(azureServiceTokenProvider.GetAccessTokenAsync(Constants.KeyVaultResourceId));
            }

            await Task.WhenAll(tasks);

            // Hit count should be 2 now, since new token should have been aquired. 
            Assert.Equal(2, mockProcessManager.HitCount);
        }

        /// <summary>
        /// Test that the force refresh works as expected.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAppAuthResultForceRefreshTest()
        {
            // Create two instances of AzureServiceTokenProvider based on AzureCliAccessTokenProvider. 
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(azureCliAccessTokenProvider);
            AzureServiceTokenProvider azureServiceTokenProvider1 = new AzureServiceTokenProvider(azureCliAccessTokenProvider);

            // Part 1: Verify force refresh of sequential requests will request new tokens.
            await azureServiceTokenProvider.GetAccessTokenAsync(Constants.KeyVaultResourceId);
            Assert.Equal(1, mockProcessManager.HitCount);

            await azureServiceTokenProvider.GetAccessTokenAsync(Constants.KeyVaultResourceId);
            Assert.Equal(1, mockProcessManager.HitCount); // cache hit.

            await azureServiceTokenProvider.GetAccessTokenAsync(Constants.KeyVaultResourceId, forceRefresh: true);
            Assert.Equal(2, mockProcessManager.HitCount); // force refresh hit.

            await azureServiceTokenProvider1.GetAccessTokenAsync(Constants.KeyVaultResourceId);
            Assert.Equal(2, mockProcessManager.HitCount); // cache hit.

            await azureServiceTokenProvider1.GetAccessTokenAsync(Constants.KeyVaultResourceId, forceRefresh: true);
            Assert.Equal(3, mockProcessManager.HitCount); // force refresh hit.

            // Part 2: Verify parallel force-refreshes re-use the same fetched token.
            // TODO: current system does not allow for controlling this flow, test would be non-deterministic and intermitently fail.
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
            var exception = Assert.Throws<ArgumentException>(() => new AzureServiceTokenProvider(azureAdInstance: "http://aadinstance/"));

            Assert.Contains(Constants.MustUseHttpsError, exception.ToString());
        }

        /// <summary>
        /// If resource id is null or empty, an exception should be thrown. 
        /// </summary>
        [Fact]
        public async Task ResourceNullOrEmptyWhenGettingTokenTest()
        {
            // Mock ProcessManager is being asked to act like Azure CLI is not installed. 
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.ProcessNotFound);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(azureCliAccessTokenProvider);

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => Task.Run(() => azureServiceTokenProvider.GetAccessTokenAsync(null, Constants.TenantId)));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());

            exception = await Assert.ThrowsAsync<ArgumentNullException>(() => Task.Run(() => azureServiceTokenProvider.GetAccessTokenAsync(string.Empty, Constants.TenantId)));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());

        }

        /// <summary>
        /// If azureAdInstance is null or empty, an exception should be thrown. 
        /// </summary>
        [Fact]
        public void NullOrEmptyAzureAdInstanceTest()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new AzureServiceTokenProvider(azureAdInstance: null));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());

            exception = Assert.Throws<ArgumentNullException>(() => new AzureServiceTokenProvider(azureAdInstance: string.Empty));

            Assert.Contains(Constants.CannotBeNullError, exception.ToString());
        }

        /// <summary>
        /// If connectionstring is not specified in AzureServiceTokenProvider, ensure connection string is assigned from 
        /// AzureServicesAuthConnectionString environment variable.
        /// </summary>
        [Fact]
        public void UnspecifiedConnectionStringTest()
        {
            // Set environment variable AzureServicesAuthConnectionString
            Environment.SetEnvironmentVariable(Constants.ConnectionStringEnvironmentVariableName, Constants.AzureCliConnectionString);

            var provider = new AzureServiceTokenProvider();

            Assert.NotNull(provider);
            Assert.IsType<AzureServiceTokenProvider>(provider);

            Environment.SetEnvironmentVariable(Constants.ConnectionStringEnvironmentVariableName, null);
        }

        [Fact]
        public async Task DiscoveryTestFirstSuccess()
        {
            // Mock process manager is being asked to act like Azure CLI was able to get the token. 
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.Success);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            // Mock MSI is being asked to act like MSI was able to get token. 
            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesSuccess);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(mockMsi);

            // set env vars so MsiAccessTokenProvider assumes App Service environment and not VM environment
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, Constants.ClientSecret);

            // AzureServiceTokenProvider is being asked to use two providers, and return token from the first that succeeds.  
            var providers = new List<NonInteractiveAzureServiceTokenProviderBase> { azureCliAccessTokenProvider, msiAccessTokenProvider };
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(providers);

            var token = await azureServiceTokenProvider.GetAccessTokenAsync(Constants.GraphResourceId, Constants.TenantId);

            // Mock process manager will be hit first, and so the hit count should be 1.
            Assert.Equal(1, mockProcessManager.HitCount);

            // Msi handler will not be hit, since AzureCliAccessTokenProvider was able to return token. So this hit count should be 0. 
            Assert.Equal(0, mockMsi.HitCount);

            Validator.ValidateToken(token, azureServiceTokenProvider.PrincipalUsed, Constants.UserType, Constants.TenantId);
        }

        [Fact]
        public async Task DiscoveryTestFirstFail()
        {
            // Mock process manager is being asked to act like Azure CLI was NOT able to get the token. 
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.ProcessNotFound);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            // Mock MSI is being asked to act like MSI was able to get token. 
            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesSuccess);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(mockMsi);

            // set env vars so MsiAccessTokenProvider assumes App Service environment and not VM environment
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, Constants.ClientSecret);

            // AzureServiceTokenProvider is being asked to use two providers, and return token from the first that succeeds.  
            var providers = new List<NonInteractiveAzureServiceTokenProviderBase> { azureCliAccessTokenProvider, msiAccessTokenProvider };
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(providers);

            var token = await azureServiceTokenProvider.GetAccessTokenAsync(Constants.GraphResourceId, Constants.TenantId);

            // Mock process manager will be hit first, and so hit count will be 1. 
            Assert.Equal(1, mockProcessManager.HitCount);

            // AzureCliAccessTokenProvider will fail, and so Msi handler will be hit next. So hit count is 1 here.
            Assert.Equal(1, mockMsi.HitCount);

            // MsiAccessTokenProvider should succeed, and we should get a valid token. 
            Validator.ValidateToken(token, azureServiceTokenProvider.PrincipalUsed, Constants.AppType, Constants.TenantId, Constants.TestAppId);
        }

        /// <summary>
        /// If token could not be acquired through any of the specified providers, an exception should be thrown
        /// </summary>
        [Fact]
        public void DiscoveryTestBothFail()
        {
            // Mock process manager is being asked to act like Azure CLI was NOT able to get the token. 
            MockProcessManager mockProcessManager = new MockProcessManager(MockProcessManager.MockProcessManagerRequestType.ProcessNotFound);
            AzureCliAccessTokenProvider azureCliAccessTokenProvider = new AzureCliAccessTokenProvider(mockProcessManager);

            // Mock MSI is being asked to act like MSI was NOT able to get token. 
            MockMsi mockMsi = new MockMsi(MockMsi.MsiTestType.MsiAppServicesFailure);
            MsiAccessTokenProvider msiAccessTokenProvider = new MsiAccessTokenProvider(mockMsi);

            // set env vars so MsiAccessTokenProvider assumes App Service environment and not VM environment
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, Constants.MsiEndpoint);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, Constants.ClientSecret);

            // use test hook to expedite test
            MsiRetryHelper.WaitBeforeRetry = false;

            // AzureServiceTokenProvider is being asked to use two providers, and and both should fail to get token.  
            var providers = new List<NonInteractiveAzureServiceTokenProviderBase> { azureCliAccessTokenProvider, msiAccessTokenProvider };
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider(providers);

            var exception = Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => azureServiceTokenProvider.GetAccessTokenAsync(Constants.GraphResourceId, Constants.TenantId));
            Assert.Contains(Constants.NoMethodWorkedToGetTokenError, exception.Result.Message);

            // Mock process manager will fail, and so hit count will be 1. 
            Assert.Equal(1, mockProcessManager.HitCount);

            // AzureCliAccessTokenProvider will fail, and so MSI handler will be hit next. MSI retry count is 5 so hit count is 5 here.
            Assert.Equal(5, mockMsi.HitCount);

            // Clean up environment variables
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceEndpointEnv, null);
            Environment.SetEnvironmentVariable(Constants.MsiAppServiceHeaderEnv, null);
        }

        /// <summary>
        /// Ensure that all public methods are marked virtual to maintain mockability
        /// </summary>
        [Fact]
        public void RemainMockable()
        {
            MockUtil.AssertPublicMethodsAreVirtual<AzureServiceTokenProvider>();
        }

        /// <summary>
        /// Injects an HTTP factory.
        /// </summary>
        [Fact]
        public async Task InjectHttpFactory()
        {
            var factory = new MockHttpClientFactory();

            // create a client secret token provider
            var azureServiceTokenProvider = new AzureServiceTokenProvider(Constants.ClientSecretConnString, Constants.AzureAdInstance, factory);

            // trying to use the provider should fail because the http factory isn't implemented. We can verify it was used though.
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() =>
                azureServiceTokenProvider.GetAccessTokenAsync(Constants.GraphResourceId, Constants.TenantId));

            Assert.EndsWith(MockHttpClientFactory.ExceptionMessage, exception.Message);
        }

        /// <summary>
        /// Side load an HTTP factory.
        /// </summary>
        [Fact]
        public async Task SideLoadHttpFactory()
        {
            MockHttpClientFactory factory = new MockHttpClientFactory();

            // create a client secret token provider
            AzureServiceTokenProvider.HttpClientFactory = factory;
            var azureServiceTokenProvider = new AzureServiceTokenProvider(Constants.ClientSecretConnString, Constants.AzureAdInstance);

            // trying to use the provider should fail because the http factory isn't implemented. We can verify it was used though.
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() =>
                azureServiceTokenProvider.GetAccessTokenAsync(Constants.GraphResourceId, Constants.TenantId));

            Assert.EndsWith(MockHttpClientFactory.ExceptionMessage, exception.Message);
        }

        /// <summary>
        /// Verify backwards compatibility with constructor and method signatures
        /// </summary>
        [Fact]
        public void VerifyPublicSignatures()
        {
            var KnownPublicCtors = new List<string>()
            {
                "Void .ctor(System.String, System.String)",
                "Void .ctor(System.String, System.String, Microsoft.IdentityModel.Clients.ActiveDirectory.IHttpClientFactory)"
            };

            var KnownPublicMethods = new List<string>()
            {
                "Microsoft.IdentityModel.Clients.ActiveDirectory.IHttpClientFactory get_HttpClientFactory()",
                "Void set_HttpClientFactory(Microsoft.IdentityModel.Clients.ActiveDirectory.IHttpClientFactory)",
                "TokenCallback get_KeyVaultTokenCallback()",
                "Microsoft.Azure.Services.AppAuthentication.Principal get_PrincipalUsed()",
                "System.Threading.Tasks.Task`1[System.String] GetAccessTokenAsync(System.String, System.String, Boolean, System.Threading.CancellationToken)",
                "System.Threading.Tasks.Task`1[System.String] GetAccessTokenAsync(System.String, Boolean, System.Threading.CancellationToken)",
                "System.Threading.Tasks.Task`1[System.String] GetAccessTokenAsync(System.String, System.String, System.Threading.CancellationToken)",
                "System.Threading.Tasks.Task`1[System.String] GetAccessTokenAsync(System.String, System.String)",
                "System.Threading.Tasks.Task`1[Microsoft.Azure.Services.AppAuthentication.AppAuthenticationResult] GetAuthenticationResultAsync(System.String, System.String, Boolean, System.Threading.CancellationToken)",
                "System.Threading.Tasks.Task`1[Microsoft.Azure.Services.AppAuthentication.AppAuthenticationResult] GetAuthenticationResultAsync(System.String, Boolean, System.Threading.CancellationToken)",
                "System.Threading.Tasks.Task`1[Microsoft.Azure.Services.AppAuthentication.AppAuthenticationResult] GetAuthenticationResultAsync(System.String, System.String, System.Threading.CancellationToken)",
                "System.Threading.Tasks.Task`1[Microsoft.Azure.Services.AppAuthentication.AppAuthenticationResult] GetAuthenticationResultAsync(System.String, System.String)",
                "Boolean Equals(System.Object)",
                "Int32 GetHashCode()",
                "System.Type GetType()",
                "System.String ToString()"
            };

            var publicCtorSignatures = typeof(AzureServiceTokenProvider).GetConstructors().Select(o => o.ToString()).ToList();
            var publicMethodSignatures = typeof(AzureServiceTokenProvider).GetMethods().Select(o => o.ToString()).ToList();

            Assert.True(Enumerable.SequenceEqual(KnownPublicCtors.OrderBy(i => i), publicCtorSignatures.OrderBy(i => i)));
            Assert.True(Enumerable.SequenceEqual(KnownPublicMethods.OrderBy(i => i), publicMethodSignatures.OrderBy(i => i)));
        }
    }
}
