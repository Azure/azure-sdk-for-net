// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Interface that helps mock ADAL usage for unit testing. 
    /// </summary>
    interface IAuthenticationContext
    {
        Task<string> AcquireTokenSilentAsync(string authority, string resource, string clientId);
        Task<string> AcquireTokenAsync(string authority, string resource, string clientId, UserCredential userCredential);
        Task<string> AcquireTokenAsync(string authority, string resource, ClientCredential clientCredential);
        Task<string> AcquireTokenAsync(string authority, string resource, IClientAssertionCertificate clientCertificate);
    }
}
