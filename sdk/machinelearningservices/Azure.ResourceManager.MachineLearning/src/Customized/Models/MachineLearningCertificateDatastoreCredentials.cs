// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningCertificateDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningCertificateDatastoreCredentials"/>. </summary>
        public MachineLearningCertificateDatastoreCredentials(Guid tenantId, Guid clientId, string thumbprint, MachineLearningCertificateDatastoreSecrets secrets)
            : this(clientId, secrets, tenantId, thumbprint)
        {
        }
    }
}
