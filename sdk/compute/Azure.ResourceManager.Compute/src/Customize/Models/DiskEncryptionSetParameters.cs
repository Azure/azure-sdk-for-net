// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    // The generator does not currently internalize this helper model even though it is only
    // referenced by internal backing properties.
    internal partial class DiskEncryptionSetParameters
    {
        // This model only backs internal diskEncryptionSet properties that are surfaced publicly as
        // ResourceIdentifier convenience properties, so keep it out of the public API. The generated
        // convenience setters still construct the backing model from only a ResourceIdentifier.
        internal DiskEncryptionSetParameters(ResourceIdentifier id) : this(id, null)
        {
        }
    }
}
