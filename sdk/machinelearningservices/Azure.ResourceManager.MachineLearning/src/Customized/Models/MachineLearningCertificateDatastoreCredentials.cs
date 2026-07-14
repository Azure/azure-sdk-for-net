// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningCertificateDatastoreCredentials
    {
        // The generated constructor follows the current TypeSpec property order, but GA shipped constructor overloads with Swagger-era
        // parameter ordering. Constructor parameter order cannot be restored with TypeSpec decorators, so these overloads delegate to the
        // generated constructor.
        /// <summary> Initializes a new instance of <see cref="MachineLearningCertificateDatastoreCredentials"/>. </summary>
        public MachineLearningCertificateDatastoreCredentials(Guid tenantId, MachineLearningCertificateDatastoreSecrets secrets, Guid clientId, string thumbprint)
            : this(CredentialsType.Certificate, additionalBinaryDataProperties: null, authorityUri: null, clientId, resourceUri: null, secrets, tenantId, thumbprint)
        {
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningCertificateDatastoreCredentials"/>. </summary>
        public MachineLearningCertificateDatastoreCredentials(Guid tenantId, Guid clientId, string thumbprint, MachineLearningCertificateDatastoreSecrets secrets)
            : this(tenantId, secrets, clientId, thumbprint)
        {
        }
    }
}
