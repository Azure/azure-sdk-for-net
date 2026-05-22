// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    // these customizations are here because the spec defined these enums as extensible enums,
    // but our resource detection logic requires them to be fixed enums to recognize those resources as singleton resources.
    // we worked around this issue by making the enums fixed in the spec,
    // then adding below customizations to change them back to extensible enums
    // because in previous GA versions, they are extensible enums (structs)
    public readonly partial struct BlobInventoryPolicyName
    {
    }

    public readonly partial struct ManagementPolicyName
    {
    }
}
