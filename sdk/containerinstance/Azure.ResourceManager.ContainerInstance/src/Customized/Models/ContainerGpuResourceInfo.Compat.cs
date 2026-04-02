// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGpuResourceInfo
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGpuResourceInfo"/>. </summary>
        /// <param name="count"> The GPU count. </param>
        /// <param name="sku"> The GPU SKU. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGpuResourceInfo(int count, ContainerGpuSku sku)
            : this(count, sku, default)
        {
        }
    }
}
