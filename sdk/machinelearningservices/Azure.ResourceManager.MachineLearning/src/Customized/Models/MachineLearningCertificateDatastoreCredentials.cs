// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore shipped constructors/properties that latest TypeSpec generation normalized but cannot remove from the GA API surface.
    public partial class MachineLearningCertificateDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningCertificateDatastoreCredentials"/>. </summary>
        public MachineLearningCertificateDatastoreCredentials(Guid tenantId, MachineLearningCertificateDatastoreSecrets secrets, Guid clientId, string thumbprint)
            : this(tenantId, clientId, thumbprint, secrets)
        {
        }
    }
}
