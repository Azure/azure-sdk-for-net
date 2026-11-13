// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    // The spec defines this as a fixed enum so resource detection can recognize the singleton resource.
    // Keep the previous GA extensible-enum shape for compatibility.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ManagementPolicyName
    {
    }
}
