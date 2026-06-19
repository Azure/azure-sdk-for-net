// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ApiManagement.Models
{
    public partial class ApiManagementBackendPatch
    {
        // Old SDK name was BackendType; generated name is TypePropertiesType
        // (from @@clientName(BackendBaseParameters.type, "typePropertiesType")).
        // Can't change that clientName because BackendBaseParameters is shared
        // with BackendContractProperties, which needs the current name.

        /// <summary> Type of the backend. A backend can be either Single or Pool. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.type")]
        public BackendType? BackendType
        {
            get => TypePropertiesType;
            set => TypePropertiesType = value;
        }

        // Deep path shortcut (properties.pool.services) with lazy init.
        // Not spec-fixable: @@flattenProperty only handles one level.

        /// <summary> Backend pool services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.pool.services")]
        public IList<BackendPoolItem> PoolServices
        {
            get
            {
                if (Pool is null)
                {
                    Pool = new BackendBaseParametersPool();
                }

                return Pool.Services;
            }
        }
    }
}
