// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System.Collections.Generic;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementBackendData
    {
        /// <summary> Backend pool services. </summary>
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

namespace Azure.ResourceManager.ApiManagement.Models
{
    public partial class ApiManagementBackendPatch
    {
        /// <summary> Backend pool services. </summary>
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
