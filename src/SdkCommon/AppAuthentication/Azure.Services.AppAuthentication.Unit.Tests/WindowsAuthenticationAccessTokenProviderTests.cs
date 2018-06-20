// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// Test cases for WindowsAuthenticationAccessTokenProvider class. WindowsAuthenticationAccessTokenProviderTests is an internal class. 
    /// </summary>
    public class WindowsAuthenticationAccessTokenProviderTests
    {
        /// <summary>
        /// Test that token is fetched for silent authentication case. This is where ADAL has cached the token. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task SilentSuccessTest()
        {
            MockAuthenticationContext authenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenSilentAsyncSuccess);

            WindowsAuthenticationAzureServiceTokenProvider provider = new WindowsAuthenticationAzureServiceTokenProvider(authenticationContext, Constants.AzureAdInstance);

            var token = await provider.GetTokenAsync(Constants.KeyVaultResourceId, string.Empty).ConfigureAwait(false);

            Validator.ValidateToken(token, provider.PrincipalUsed, Constants.UserType, Constants.TenantId);
        }

        /// <summary>
        /// Test case where token cannot be fetched using silent authentication, but actual Integrated Windows Authentication (IWA) succeeds. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task SilentFailAndUserCredentialSuccessTest()
        {
            MockAuthenticationContext authenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncUserCredentialSuccess);

            WindowsAuthenticationAzureServiceTokenProvider provider = new WindowsAuthenticationAzureServiceTokenProvider(authenticationContext, Constants.AzureAdInstance);

            var token = await provider.GetTokenAsync(Constants.KeyVaultResourceId, string.Empty).ConfigureAwait(false);

            Validator.ValidateToken(token, provider.PrincipalUsed, Constants.UserType, Constants.TenantId);
        }

        /// <summary>
        /// Test if exception type and response are as expected when token cannot be aquired (and token returned is empty)
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task SilentFailAndUserCredentialFailTest()
        {
            MockAuthenticationContext authenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncUserCredentialFail);

            WindowsAuthenticationAzureServiceTokenProvider provider = new WindowsAuthenticationAzureServiceTokenProvider(authenticationContext, Constants.AzureAdInstance);
            
            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => provider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(Constants.KeyVaultResourceId, exception.Message);
            Assert.Contains(Constants.TenantId, exception.Message);

        }

        /// <summary>
        /// Test if exception type and response are as expected when token cannot be aquired (and exception is thrown)
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task SilentFailAndUserCredentialExceptionTest()
        {
            MockAuthenticationContext authenticationContext = new MockAuthenticationContext(MockAuthenticationContext.MockAuthenticationContextTestType.AcquireTokenAsyncException);

            WindowsAuthenticationAzureServiceTokenProvider provider = new WindowsAuthenticationAzureServiceTokenProvider(authenticationContext, Constants.AzureAdInstance);

            var exception = await Assert.ThrowsAsync<AzureServiceTokenProviderException>(() => Task.Run(() => provider.GetTokenAsync(Constants.KeyVaultResourceId, Constants.TenantId)));

            Assert.Contains(Constants.KeyVaultResourceId, exception.Message);
            Assert.Contains(Constants.TenantId, exception.Message);
            Assert.Contains(Constants.AdalException, exception.Message);
        }
    }
}
