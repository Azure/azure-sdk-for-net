// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the protected parameterless constructor dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CompressionReadSettings")]
    public abstract partial class CompressionReadSettings
    {
        /// <summary> Initializes a new instance of <see cref="CompressionReadSettings"/>. </summary>
        protected CompressionReadSettings() : this(null)
        {
        }
    }
}
