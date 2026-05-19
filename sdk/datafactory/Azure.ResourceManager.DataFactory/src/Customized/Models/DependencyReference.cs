// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the protected parameterless constructor dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("DependencyReference")]
    public abstract partial class DependencyReference
    {
        /// <summary> Initializes a new instance of <see cref="DependencyReference"/>. </summary>
        protected DependencyReference() : this(null)
        {
        }
    }
}
