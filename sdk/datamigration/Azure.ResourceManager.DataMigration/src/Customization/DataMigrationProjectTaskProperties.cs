// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration.Models
{
    // Suppress the generated internal parameterless ctor and replace with protected
    // to maintain backward compatibility with the GA API surface.
    [CodeGenSuppress("DataMigrationProjectTaskProperties")]
    public abstract partial class DataMigrationProjectTaskProperties
    {
        /// <summary> Backward-compatible protected constructor for ApiCompat. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected DataMigrationProjectTaskProperties() : this(default(DataMigrationTaskType)) { }
    }
}
