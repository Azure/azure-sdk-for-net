// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ApiManagement.Models
{
    public partial class ApiManagementBackendPatch
    {
        /// <summary> The list of backend entities belonging to a pool. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.pool.services")]
        public IList<BackendPoolItem> PoolServices
        {
            get
            {
                if (Pool is null)
                    Pool = new BackendBaseParametersPool();
                return Pool.Services;
            }
        }
    }
}
