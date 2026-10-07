// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration.Models
{
    // Backward-compat justification: restore the GA-era protected constructor suppressed by the new generator for ApiCompat.
    public abstract partial class ConnectToSourceSqlServerTaskOutput
    {
        // Backward-compatible protected constructor for ApiCompat.
        protected ConnectToSourceSqlServerTaskOutput() : this(default(string)) { }
    }
}
