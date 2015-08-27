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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security;

namespace Microsoft.Azure.Common.Authentication.Authentication
{
    /// <summary>
    /// An in-memory store for application credentials
    /// </summary>
    internal class MemoryApplicationCredentialStore : IApplicationCredentialStore
    {
        private IDictionary<CredentialKey, SecureString> _credentialData = new Dictionary<CredentialKey, SecureString>();

        /// <summary>
        /// Add the given credential to the in-memory store.
        /// </summary>
        /// <param name="applicationId">The Active Directory application Id.</param>
        /// <param name="tenant">The tenant scope for the credential.</param>
        /// <param name="secret">The application secret.</param>
        public void AddCredential(string applicationId, string tenant, System.Security.SecureString secret)
        {
            var key = new CredentialKey(applicationId, tenant);
            if (_credentialData.ContainsKey(key))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Key with applicationId {0} and " +
                    "Tenant ID {1} already exists.", applicationId, tenant));
            }

            _credentialData[key] = secret;
        }

        /// <summary>
        /// Remove the given credential from the in-memory store.
        /// </summary>
        /// <param name="applicationId">The Active Directory application Id.</param>
        /// <param name="tenant">The tenant scope for the credential.</param>
        public void RemoveCredential(string applicationId, string tenant)
        {
            var key = new CredentialKey(applicationId, tenant);
            if (_credentialData.ContainsKey(key))
            {
                _credentialData.Remove(key);
            }
        }

        /// <summary>
        /// Retrieve the given credential from the in-memory store.
        /// </summary>
        /// <param name="applicationId">The Active Directory application Id.</param>
        /// <param name="tenant">The tenant scope for the credential.</param>
        /// <returns>The application secret for the given application and tenant, if found, or null if no such credential has been stored.</returns>
        public System.Security.SecureString GetCredential(string applicationId, string tenant)
        {
            var key = new CredentialKey(applicationId, tenant);
            SecureString returnValue = null;
            if (_credentialData.ContainsKey(key))
            {
                returnValue = _credentialData[key];
            }

            return returnValue;
        }

        /// <summary>
        /// Return a credential provider that can retrieve application credentials from this store for the given tenant id scope.
        /// </summary>
        /// <param name="tenant">The teanant id scope for credentials to be retrieved.</param>
        /// <returns>A credential provider using this store for the given tenant scope.</returns>
        public Rest.Azure.Authentication.IApplicationCredentialProvider GetCredentialProvider(string tenant)
        {
            return new BasicCredentialProvider(this, tenant);
        }

        class CredentialKey : IComparable<CredentialKey>
        {
            private string _combinedKey;
            public CredentialKey(string applicationId, string tenant)
            {
                this.ApplicationId = applicationId;
                this.Tenant = tenant;
                this._combinedKey = string.Format("{0}_{1}", applicationId, tenant);
            }
            public string ApplicationId { get; set; }

            public string Tenant { get; set; }

            public override int GetHashCode()
            {
                return _combinedKey.GetHashCode();
            }

            public int CompareTo(CredentialKey other)
            {
                return string.Compare( _combinedKey, other._combinedKey, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
