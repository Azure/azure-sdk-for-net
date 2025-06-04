// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Service Principal datastore credentials configuration. </summary>
    public partial class MachineLearningServicePrincipalDatastoreCredentials : MachineLearningDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningServicePrincipalDatastoreCredentials"/>. </summary>
        /// <param name="clientId"> [Required] Service principal client ID. </param>
        /// <param name="secrets"> [Required] Service principal secrets. </param>
        /// <param name="tenantId"> [Required] ID of the tenant to which the service principal belongs. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="secrets"/> is null. </exception>
        public MachineLearningServicePrincipalDatastoreCredentials(Guid clientId, MachineLearningServicePrincipalDatastoreSecrets secrets, Guid tenantId)
        {
            Argument.AssertNotNull(secrets, nameof(secrets));

            TenantId = tenantId;
            ClientId = clientId;
            Secrets = secrets;
            CredentialsType = CredentialsType.ServicePrincipal;
        }
    }
}
