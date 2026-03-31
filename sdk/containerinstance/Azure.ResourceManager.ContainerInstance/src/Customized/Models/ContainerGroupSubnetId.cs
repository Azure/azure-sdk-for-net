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

        // NOTE: Property type shim (Id→ResourceIdentifier) cannot be added here because
        // ContainerGroupSubnetId is a generated partial class and Id already exists with string type.
    }
}
