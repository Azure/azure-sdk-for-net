// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Rest.Azure.Authentication;
using System.Security;

namespace Microsoft.Azure.Common.Authentication.Interfaces
{
    /// <summary>
    /// Methods for managing a store of application credewntials.
    /// </summary>
    public interface IApplicationCredentialStore
    {
        /// <summary>
        /// Add the given credential to the store.
        /// </summary>
        /// <param name="applicationId">The active directory applicationId.</param>
        /// <param name="tenant">The Active Directory tenant containing the application.</param>
        /// <param name="secret">The application secret.</param>
        void AddCredential(string applicationId, string tenant, SecureString secret);

        /// <summary>
        /// Delete the given credential from the store.
        /// </summary>
        /// <param name="applicationId">The active directory applicationId.</param>
        /// <param name="tenant">The Active Directory tenant containing the application.</param>
        void RemoveCredential(string applicationId, string tenant);

        /// <summary>
        /// Retrieve the given credential from the store.
        /// </summary>
        /// <param name="applicationId">The active directory applicationId.</param>
        /// <param name="tenant">The Active Directory tenant containing the application.</param>
        /// <returns>The application secret associate with the given application, if present 
        /// in the store, otherwise null.</returns>
        SecureString GetCredential(string applicationId, string tenant);

        /// <summary>
        /// Return a credential provider for use in authenticating http requests.
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns></returns>
        IApplicationCredentialProvider GetCredentialProvider(string tenant);
    }
}
