// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: Adds public constructor matching prior GA signature.
// The old API had StorageTaskAssignmentData(StorageTaskAssignmentProperties),
// the new ProxyResource-based code generates only a parameterless constructor.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageTaskAssignmentData
    {
        // Backward-compatible constructor.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageTaskAssignmentData(StorageTaskAssignmentProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            Properties = properties;
        }
    }
}
