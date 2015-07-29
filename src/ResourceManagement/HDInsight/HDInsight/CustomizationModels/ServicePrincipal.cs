// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;

namespace Microsoft.Azure.Management.HDInsight.Models
{
    /// <summary>
    /// Service Principal that is used to get an OAuth2 token 
    /// </summary>
    public class ServicePrincipal : Principal
    {
        /// <summary>
        /// Gets Application principal id of the service principal 
        /// </summary>
        public Guid AppPrincipalId { get; private set; }

        /// <summary>
        /// Gets client certificate associated with service principal
        /// </summary>
        public byte[] ClientCertificate { get; private set; }

        /// <summary>
        /// Gets client certificate password associated with service principal
        /// </summary>
        public string ClientCertificatePassword { get; private set; }

        /// <summary>
        /// Gets AAD tenant uri of the service principal
        /// </summary>
        public Uri AADTenantId { get; private set; }

        /// <summary>
        /// Gets Resource uri of the service principal
        /// </summary>
        public Uri ResourceUri { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ServicePrincipal class.
        /// </summary>
        /// <param name="appPrincipalId">Application principal id of the service principal.</param>
        /// <param name="clientCertificate">client certificate associated with service principal.</param>
        /// <param name="clientCertificatePassword">client certificate password associated with service principal.</param>
        /// <param name="aadTenantId">AAD tenant uri of the service principal</param>
        public ServicePrincipal(Guid appPrincipalId, Uri aadTenantId, byte[] clientCertificate, string clientCertificatePassword)
        {
            if (appPrincipalId == Guid.Empty)
                throw new ArgumentException("Input cannot be empty", "appPrincipalId");

            if (aadTenantId == null)
                throw new ArgumentNullException("aadTenantId");
            
            if (clientCertificate == null)
                throw new ArgumentNullException("clientCertificate");
    
            this.AppPrincipalId = appPrincipalId;
            this.AADTenantId = aadTenantId;
            this.ClientCertificate = clientCertificate;
            this.ClientCertificatePassword = clientCertificatePassword;

            //Resource Uri of data lake 
            this.ResourceUri = new Uri("https://management.core.windows.net/");
        }
    }
}
