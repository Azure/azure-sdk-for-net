// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MigrationDiscovery.Models
{
    // The SQL import error summary is an implementation detail and is not part of the public SDK API.
    // This customization keeps the generated model internal.
    [CodeGenType("SqlImportJobErrorSummary")]
    internal partial class SqlImportJobErrorSummary
    {
    }
}
