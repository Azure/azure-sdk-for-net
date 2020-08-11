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
    }
}
