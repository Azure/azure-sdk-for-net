// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Rest.Azure.Authentication
{
    /// <summary>
    /// Interface to platform-specific methods for securely storing client credentials
    /// </summary>
    public interface IApplicationAuthenticationProvider
    {
        /// <summary>
        /// Retrieve ClientCredentials for an active directory application.
        /// </summary>
        /// <param name="clientId">The active directory client Id of the application.</param>
        /// <param name="audience">The audience to target</param>
        /// <param name="context">The authentication context</param>
        /// <returns>authentication result which can be used for authentication with the given audience.</returns>
        Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience, AuthenticationContext context);
    }
}
