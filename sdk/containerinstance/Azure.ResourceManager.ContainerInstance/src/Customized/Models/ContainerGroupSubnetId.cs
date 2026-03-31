// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupSubnetId
    {
        // backward-compat shim: old constructor accepted ResourceIdentifier, new accepts string
        /// <summary> Initializes a new instance of <see cref="ContainerGroupSubnetId"/>. </summary>
        /// <param name="id"> Resource ID of virtual network and subnet. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupSubnetId(ResourceIdentifier id) : this(id?.ToString()) { }

        // backward-compat shim: old property was ResourceIdentifier, new is string
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Id
        {
            get => _id != null ? new ResourceIdentifier(_id) : null;
            set => _id = value?.ToString();
        }
    }
}
