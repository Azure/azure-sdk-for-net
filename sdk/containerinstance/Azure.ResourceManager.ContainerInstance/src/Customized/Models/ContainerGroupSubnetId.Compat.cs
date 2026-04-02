// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupSubnetId
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupSubnetId"/>. </summary>
        /// <param name="id"> The resource identifier. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupSubnetId(ResourceIdentifier id) : this(id, default, default)
        {
        }
    }
}
