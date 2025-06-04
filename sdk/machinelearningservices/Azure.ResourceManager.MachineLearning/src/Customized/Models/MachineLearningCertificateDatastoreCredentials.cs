// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Certificate datastore credentials configuration. </summary>
    public partial class MachineLearningCertificateDatastoreCredentials : MachineLearningDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningCertificateDatastoreCredentials"/>. </summary>
        /// <param name="clientId"> [Required] Service principal client ID. </param>
        /// <param name="secrets"> [Required] Service principal secrets. </param>
        /// <param name="tenantId"> [Required] ID of the tenant to which the service principal belongs. </param>
        /// <param name="thumbprint"> [Required] Thumbprint of the certificate used for authentication. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="secrets"/> or <paramref name="thumbprint"/> is null. </exception>
        public MachineLearningCertificateDatastoreCredentials(Guid clientId, MachineLearningCertificateDatastoreSecrets secrets, Guid tenantId, string thumbprint)
        {
            Argument.AssertNotNull(thumbprint, nameof(thumbprint));
            Argument.AssertNotNull(secrets, nameof(secrets));

            TenantId = tenantId;
            ClientId = clientId;
            Thumbprint = thumbprint;
            Secrets = secrets;
            CredentialsType = CredentialsType.Certificate;
        }
    }
}
