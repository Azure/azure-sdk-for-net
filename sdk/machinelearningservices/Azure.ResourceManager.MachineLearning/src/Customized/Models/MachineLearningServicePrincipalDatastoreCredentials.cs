// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore shipped constructors/properties that latest TypeSpec generation normalized but cannot remove from the GA API surface.
    public partial class MachineLearningServicePrincipalDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningServicePrincipalDatastoreCredentials"/>. </summary>
        public MachineLearningServicePrincipalDatastoreCredentials(Guid tenantId, MachineLearningServicePrincipalDatastoreSecrets secrets, Guid clientId)
            : this(tenantId, clientId, secrets)
        {
        }
    }
}
