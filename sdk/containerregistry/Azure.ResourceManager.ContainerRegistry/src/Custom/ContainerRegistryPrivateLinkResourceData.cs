// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.ContainerRegistry
{
    // Backward-compatibility shim: the TypeSpec-based generator only emits an
    // internal constructor with 7 parameters (id, name, resourceType, systemData,
    // additionalBinaryDataProperties, properties, groupName).  The previous
    // AutoRest-generated SDK (≤ 1.4.0) exposed a public parameterless constructor.
    // This partial class restores it so existing callers and reflection-based
    // instantiation are not broken.
    public partial class ContainerRegistryPrivateLinkResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ContainerRegistryPrivateLinkResourceData"/>. </summary>
        public ContainerRegistryPrivateLinkResourceData()
        { }
    }
}
