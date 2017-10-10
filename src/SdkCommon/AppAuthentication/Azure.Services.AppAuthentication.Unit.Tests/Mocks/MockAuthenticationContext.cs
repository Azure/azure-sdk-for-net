// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    /// <summary>
    /// The response from the class depends on what MockAuthenticationContextTestType the calling method is testing for. 
    /// e.g. to test for scenario where client certificate based authentication fails, use AcquireTokenAsyncUserCredentialFail. 
    /// The response will be what ADAL would send.
    /// </summary>
    internal class MockAuthenticationContext : IAuthenticationContext
    {
        // Responses types
        internal enum MockAuthenticationContextTestType
        {
            AcquireTokenSilentAsyncSuccess,
            AcquireTokenSilentAsyncFail,
            AcquireTokenAsyncUserCredentialSuccess,
            AcquireTokenAsyncUserCredentialFail,
            AcquireTokenAsyncException,
            AcquireTokenAsyncClientCredentialSuccess,
            AcquireTokenAsyncClientCredentialFail,
            AcquireTokenAsyncClientCertificateSuccess,
            AcquireTokenAsyncClientCertificateFail,
            AcquireInvalidTokenAsyncFail
        }

        private readonly MockAuthenticationContextTestType _mockAuthenticationContextTestType;

        internal MockAuthenticationContext(MockAuthenticationContextTestType mockAuthenticationContextTestType)
        {
            _mockAuthenticationContextTestType = mockAuthenticationContextTestType;
        }

        /// <summary>
        /// Returns an access token depending on the type requested for testing. 
        /// </summary>
        /// <returns></returns>
        private Task<string> AcquireTokenAsync()
        {
            switch (_mockAuthenticationContextTestType)
            {
                case MockAuthenticationContextTestType.AcquireTokenSilentAsyncFail:
                case MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateFail:
                case MockAuthenticationContextTestType.AcquireTokenAsyncClientCredentialFail:
                case MockAuthenticationContextTestType.AcquireTokenAsyncUserCredentialFail:
                    return Task.FromResult<string>(null);

                case MockAuthenticationContextTestType.AcquireInvalidTokenAsyncFail:
                    return Task.FromResult(TokenHelper.GetInvalidAppToken());

                case MockAuthenticationContextTestType.AcquireTokenAsyncException:
                    throw new Exception(Constants.AdalException);

                case MockAuthenticationContextTestType.AcquireTokenSilentAsyncSuccess:
                case MockAuthenticationContextTestType.AcquireTokenAsyncUserCredentialSuccess:
                    return Task.FromResult(TokenHelper.GetUserToken());

                case MockAuthenticationContextTestType.AcquireTokenAsyncClientCertificateSuccess:
                case MockAuthenticationContextTestType.AcquireTokenAsyncClientCredentialSuccess:
                    return Task.FromResult(TokenHelper.GetAppToken());
                
            }

            return null;
        }
        public Task<string> AcquireTokenSilentAsync(string authority, string resource, string clientId)
        {
            return AcquireTokenAsync();
        }

        public Task<string> AcquireTokenAsync(string authority, string resource, string clientId, UserCredential userCredential)
        {
            return AcquireTokenAsync();
        }

        public Task<string> AcquireTokenAsync(string authority, string resource, ClientCredential clientCredential)
        {
            return AcquireTokenAsync();
        }

        public Task<string> AcquireTokenAsync(string authority, string resource, IClientAssertionCertificate clientCertificate)
        {
            return AcquireTokenAsync();
        }
    }
}
