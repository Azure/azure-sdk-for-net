// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningServicePrincipalDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningServicePrincipalDatastoreCredentials"/>. </summary>
        public MachineLearningServicePrincipalDatastoreCredentials(Guid tenantId, Guid clientId, MachineLearningServicePrincipalDatastoreSecrets secrets)
            : this(clientId, secrets, tenantId)
        {
        }
    }
}
