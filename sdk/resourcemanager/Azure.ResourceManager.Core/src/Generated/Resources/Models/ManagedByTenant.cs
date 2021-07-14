﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary> Information about a tenant managing the subscription. </summary>
    public partial class ManagedByTenant
    {
        /// <summary> Initializes a new instance of ManagedByTenant. </summary>
        internal ManagedByTenant()
        {
        }

        /// <summary> Initializes a new instance of ManagedByTenant. </summary>
        /// <param name="tenantId"> The tenant ID of the managing tenant. This is a GUID. </param>
        internal ManagedByTenant(string tenantId)
        {
            TenantId = tenantId;
        }

        /// <summary> The tenant ID of the managing tenant. This is a GUID. </summary>
        public string TenantId { get; }
    }
}
