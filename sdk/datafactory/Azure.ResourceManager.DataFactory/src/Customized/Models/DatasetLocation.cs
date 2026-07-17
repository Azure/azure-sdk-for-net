// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    // Restores the protected parameterless constructor dropped by MPG generator (issue #59298).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("DatasetLocation")]
    public abstract partial class DatasetLocation
    {
        /// <summary> Initializes a new instance of <see cref="DatasetLocation"/>. </summary>
        protected DatasetLocation() : this(null)
        {
        }
    }
}
