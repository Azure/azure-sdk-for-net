// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.KeyVault.Models
{
    /// <summary> Properties of the vault. </summary>
    [CodeGenSuppress("KeyVaultProperties", typeof(Guid), typeof(KeyVaultSku))]
    public partial class KeyVaultProperties
    {
        /// <summary> Initializes a new instance of KeyVaultProperties. </summary>
        /// <param name="tenantId"> The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault. </param>
        /// <param name="sku"> SKU details. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public KeyVaultProperties(Guid tenantId, KeyVaultSku sku)
        {
            if (sku == null)
            {
                throw new ArgumentNullException(nameof(sku));
            }

            TenantId = tenantId;
            Sku = sku;
            // This is a workaround to ensure the vault can be created successfully
            // See the details of the issue here: https://github.com/Azure/azure-rest-api-specs/issues/19022
            AccessPolicies = new List<KeyVaultAccessPolicy>();
            PrivateEndpointConnections = new ChangeTrackingList<KeyVaultPrivateEndpointConnectionItemData>();
        }
    }
}
