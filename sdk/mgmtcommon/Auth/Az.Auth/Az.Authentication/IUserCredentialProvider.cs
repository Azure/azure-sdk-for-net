// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Rest.Azure.Authentication
{
    /// <summary>
    /// Interface to platform-specific methods for securely storing user credentials
    /// </summary>
    public interface IUserCredentialProvider
    {
        /// <summary>
        /// Retrieve credentials for the given user account.
        /// </summary>
        /// <param name="username">The username for the account.</param>
        /// <returns>A UserCredential that can be used for AD authentication for the given account.</returns>
        Task<UserCredential> GetCredentialAsync(string username);
    }
}
