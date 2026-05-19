// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the protected parameterless constructor dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("DatasetLocation")]
    public abstract partial class DatasetLocation
    {
        /// <summary> Initializes a new instance of <see cref="DatasetLocation"/>. </summary>
        protected DatasetLocation() : this(null)
        {
        }
    }
}
