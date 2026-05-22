// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class DiskEncryptionSetParameters
    {
        // Backward compatibility for generated setters that construct this type from only a ResourceIdentifier.
        // Without this constructor, generated convenience setters fail to compile after the base type gains additional serialization state.
        internal DiskEncryptionSetParameters(ResourceIdentifier id) : this(id, null)
        {
        }
    }
}
