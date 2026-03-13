// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Preserves prior GA type name with 'Definition' suffix via partial class.

using System.Diagnostics.CodeAnalysis;

namespace Azure.ResourceManager.Storage.Models
{
    // Preserve prior GA type name with 'Definition' suffix.
    [SuppressMessage("StyleCop.CSharp.NamingRules", "AZC0031:DisallowedModelNameSuffix")]
    public partial class ManagementPolicyDefinition
    {
    }
}
