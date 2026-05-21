// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration.Models
{
    [CodeGenSuppress("DataMigrationCommandProperties")]
    public abstract partial class DataMigrationCommandProperties
    {
        /// <summary> Backward-compatible protected constructor for ApiCompat. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected DataMigrationCommandProperties() : this(default(DataMigrationCommandType)) { }
    }
}
