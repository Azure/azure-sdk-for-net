// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
//
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

using Microsoft.Azure.Common.Authentication.Interfaces;
using System.Security;

namespace Microsoft.Azure.Common.Authentication.Authentication
{
    /// <summary>
    /// A store for application credentials that used the windows Credential cache.
    /// </summary>
    public class KeyStoreApplicationCredentialStore : IApplicationCredentialStore
    {
        
        /// <summary>
        /// Add an application credential to the store.
        /// </summary>
        /// <param name="applicationId">The applicationId for the application.</param>
        /// <param name="tenant">The tenantId for the credential.</param>
        /// <param name="secret">The application secret.</param>
        public void AddCredential(string applicationId, string tenant, System.Security.SecureString secret)
        {
            ServicePrincipalKeyStore.SaveKey(applicationId, tenant, secret);
        }

        /// <summary>
        /// Remove the given credential from the store.
        /// </summary>
        /// <param name="applicationId">The applicationId of the credential to remove.</param>
        /// <param name="tenant">The tenant of the credential to remove.</param>
        public void RemoveCredential(string applicationId, string tenant)
        {
            ServicePrincipalKeyStore.DeleteKey(applicationId, tenant);
        }

        /// <summary>
        /// Get the credential for the given applicationId and tenant.
        /// </summary>
        /// <param name="applicationId">The Active Directory applicationId.</param>
        /// <param name="tenant">The tenant.</param>
        /// <returns>The application secret as a secure string.</returns>
        public SecureString GetCredential(string applicationId, string tenant)
        {
            return ServicePrincipalKeyStore.GetKey(applicationId, tenant);
        }

        /// <summary>
        /// Returns a credential provider that uses this key store.
        /// </summary>
        /// <param name="tenant">The tenant for the provided credentials.</param>
        /// <returns>A credential provder that can access credentials from thios store for the given tenant.</returns>
        public Rest.Azure.Authentication.IApplicationCredentialProvider GetCredentialProvider(string tenant)
        {
            return new BasicCredentialProvider(this, tenant);
        }
    }
}
