// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MigrationDiscovery.Models
{
    // The error summary is an implementation detail and is not part of the public SDK API.
    // Suppress the generated member and declare it as internal.
    [CodeGenSuppress("ErrorSummary")]
    public partial class ImportSqlInventoryJobProperties
    {
        internal SqlImportJobErrorSummary ErrorSummary { get; }
    }
}
