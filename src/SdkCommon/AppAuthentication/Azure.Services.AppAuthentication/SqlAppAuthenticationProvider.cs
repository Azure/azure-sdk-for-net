// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if net472
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// An implementation of SqlAuthenticationProvider that implements Active Directory Interactive SQL authentication.
    /// </summary>
    public class SqlAppAuthenticationProvider : SqlAuthenticationProvider
    {
        /// <summary>
        /// Acquires an access token for SQL using AzureServiceTokenProvider with the given SQL authentication parameters.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override async Task<SqlAuthenticationToken> AcquireTokenAsync(SqlAuthenticationParameters parameters)
        {
            var appAuthParameters = new SqlAppAuthenticationParameters(parameters);
            return await AcquireTokenAsync(appAuthParameters);
        }

        /// <summary>
        /// Acquires an access token for SQL using AzureServiceTokenProvider with the given SQL authentication parameters.
        /// </summary>
        /// <param name="parameters">The parameters needed in order to obtain a SQL access token</param>
        /// <returns></returns>
        public async Task<SqlAuthenticationToken> AcquireTokenAsync(SqlAppAuthenticationParameters parameters)
        {
            string azureAdInstance = UriHelper.GetAzureAdInstanceByAuthority(parameters.Authority);
            string tenantId = UriHelper.GetTenantByAuthority(parameters.Authority);

            if (string.IsNullOrEmpty(azureAdInstance))
            {
                throw new ArgumentException("The Azure AD instance could not be parsed from the authority provided in SqlAuthenticationParameters");
            }

            if (string.IsNullOrEmpty(parameters.Resource))
            {
                throw new ArgumentException("A resource must be specified in SqlAuthenticationParameters");
            }

            AzureServiceTokenProvider tokenProvider = new AzureServiceTokenProvider(azureAdInstance: azureAdInstance);

            var authResult = await tokenProvider.GetAuthenticationResultAsync(parameters.Resource, tenantId).ConfigureAwait(false);

            return new SqlAuthenticationToken(authResult.AccessToken, authResult.ExpiresOn);
        }

        /// <summary>
        /// Implements virtual method in SqlAuthenticationProvider. Only Active Directory Interactive Authentication is supported.
        /// </summary>
        /// <param name="authenticationMethod">The SQL authentication method to check whether supported</param>
        /// <returns></returns>
        public override bool IsSupported(SqlAuthenticationMethod authenticationMethod)
        {
            return authenticationMethod == SqlAuthenticationMethod.ActiveDirectoryInteractive;
        }
    }
}
#endif