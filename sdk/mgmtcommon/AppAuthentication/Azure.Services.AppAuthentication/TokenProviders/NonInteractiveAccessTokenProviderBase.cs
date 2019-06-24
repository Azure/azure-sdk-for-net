// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Base class from which other token providers derive. 
    /// </summary>
    internal abstract class NonInteractiveAzureServiceTokenProviderBase
    {
        public string ConnectionString;
        public Principal PrincipalUsed;

        public abstract Task<AppAuthenticationResult> GetAuthResultAsync(string resource, string authority, CancellationToken cancellationToken);

        internal async Task<AppAuthenticationResult> GetAuthResultAsync(string authority, string resource, string scope, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(resource))
            {
                throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                    AzureServiceTokenProviderException.MissingResource);
            }

            return await GetAuthResultAsync(resource, authority, cancellationToken).ConfigureAwait(false);
        }
    }
}
