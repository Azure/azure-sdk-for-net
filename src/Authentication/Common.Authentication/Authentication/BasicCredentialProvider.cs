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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.Azure.Authentication;
using System.Security;
using System.Threading.Tasks;

namespace Microsoft.Azure.Common.Authentication.Authentication
{
    /// <summary>
    /// A Credential provider that makes use of a credential store.
    /// </summary>
    public class BasicCredentialProvider : IApplicationCredentialProvider
    {
        private IApplicationCredentialStore _backingStore;
        private string _tenantId;

        /// <summary>
        /// Create a credential provider using the given credential store and tenant Id.
        /// </summary>
        /// <param name="backingStore">The store containing application credentials.</param>
        /// <param name="tenantId">The tenant to get credentials for.</param>
        public BasicCredentialProvider(IApplicationCredentialStore backingStore, string tenantId)
        {
            this._backingStore = backingStore;
            this._tenantId = tenantId;
        }

        /// <summary>
        /// Get credential for use in authentication requests
        /// </summary>
        /// <param name="clientId">The client Id contianing the request</param>
        /// <returns>The client credential for the given application.</returns>
        public async Task<IdentityModel.Clients.ActiveDirectory.ClientCredential> GetCredentialAsync(string clientId)
        {
            var task = new Task<SecureString>(() =>
            {
                return _backingStore.GetCredential(clientId, _tenantId);
            });
            task.Start();
            var key = await task.ConfigureAwait(false);
            return new ClientCredential(clientId, key);
        }
    }
}
