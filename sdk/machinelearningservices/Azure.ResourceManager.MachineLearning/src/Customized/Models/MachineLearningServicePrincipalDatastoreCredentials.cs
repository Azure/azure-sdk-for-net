// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningServicePrincipalDatastoreCredentials
    {
        // The generated constructor follows the current TypeSpec property order, but GA shipped constructor overloads with Swagger-era
        // parameter ordering. Constructor parameter order cannot be restored with TypeSpec decorators, so these overloads delegate to the
        // generated constructor.
        /// <summary> Initializes a new instance of <see cref="MachineLearningServicePrincipalDatastoreCredentials"/>. </summary>
        public MachineLearningServicePrincipalDatastoreCredentials(Guid tenantId, MachineLearningServicePrincipalDatastoreSecrets secrets, Guid clientId)
            : this(CredentialsType.ServicePrincipal, additionalBinaryDataProperties: null, authorityUri: null, clientId, resourceUri: null, secrets, tenantId)
        {
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningServicePrincipalDatastoreCredentials"/>. </summary>
        public MachineLearningServicePrincipalDatastoreCredentials(Guid tenantId, Guid clientId, MachineLearningServicePrincipalDatastoreSecrets secrets)
            : this(tenantId, secrets, clientId)
        {
        }
    }
}
