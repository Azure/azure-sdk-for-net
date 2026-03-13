// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Preserves prior GA type name with 'Response' suffix via partial class.

using System.Diagnostics.CodeAnalysis;

namespace Azure.ResourceManager.Storage.Models
{
    // Preserve prior GA type name with 'Response' suffix.
    [SuppressMessage("StyleCop.CSharp.NamingRules", "AZC0030:DisallowedModelNameSuffix")]
    public partial class LeaseShareResponse
    {
    }
}
