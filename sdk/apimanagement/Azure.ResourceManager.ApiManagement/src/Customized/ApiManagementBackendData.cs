// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementBackendData
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
