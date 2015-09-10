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
        /// Gets Application id of the service principal 
        /// </summary>
        public Guid ApplicationId { get; private set; }

        /// <summary>
        /// Gets certificate file bytes associated with service principal
        /// </summary>
        public byte[] CertificateFileBytes { get; private set; }

        /// <summary>
        /// Gets certificate password associated with service principal
        /// </summary>
        public string CertificatePassword { get; private set; }

        /// <summary>
        /// Gets AAD tenant id of the service principal
        /// </summary>
        public Guid AADTenantId { get; private set; }

        /// <summary>
        /// Gets Resource uri of the service principal
        /// </summary>
        public Uri ResourceUri { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ServicePrincipal class.
        /// </summary>
        /// <param name="applicationId">Application id of the service principal.</param>
        /// <param name="certificateFileBytes">certificate file bytes associated with service principal.</param>
        /// <param name="certificatePassword">certificate password associated with service principal.</param>
        /// <param name="aadTenantId">AAD tenant id of the service principal</param>
        public ServicePrincipal(Guid applicationId, Guid aadTenantId, byte[] certificateFileBytes, string certificatePassword)
        {
            if (applicationId == Guid.Empty)
                throw new ArgumentException("Input cannot be empty", "applicationId");

            if (aadTenantId == Guid.Empty)
                throw new ArgumentException("Input cannot be empty", "aadTenantId");
            
            if (certificateFileBytes == null)
                throw new ArgumentNullException("certificateFileBytes");
    
            this.ApplicationId = applicationId;
            this.AADTenantId = aadTenantId;
            this.CertificateFileBytes = certificateFileBytes;
            this.CertificatePassword = certificatePassword;

            //Resource Uri of data lake 
            this.ResourceUri = new Uri("https://management.core.windows.net/");
        }
    }
}
