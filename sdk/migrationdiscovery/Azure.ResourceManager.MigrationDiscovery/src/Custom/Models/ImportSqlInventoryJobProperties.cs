// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MigrationDiscovery.Models
{
    [CodeGenSuppress("ErrorSummary")]
    public partial class ImportSqlInventoryJobProperties
    {
        internal SqlImportJobErrorSummary ErrorSummary { get; }
    }
}