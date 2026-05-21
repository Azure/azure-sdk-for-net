// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration.Models
{
    [CodeGenSuppress("DatabaseMigrationBaseProperties")]
    // Backward-compat justification: restore the GA-era protected constructor suppressed by the new generator for ApiCompat.
    public abstract partial class DatabaseMigrationBaseProperties
    {
        // Backward-compatible protected constructor for ApiCompat.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected DatabaseMigrationBaseProperties() : this(default(ResourceType)) { }
    }
}
