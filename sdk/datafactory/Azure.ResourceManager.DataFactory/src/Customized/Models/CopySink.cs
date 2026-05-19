// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the protected parameterless constructor dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CopySink")]
    public abstract partial class CopySink
    {
        /// <summary> Initializes a new instance of <see cref="CopySink"/>. </summary>
        protected CopySink() : this(null)
        {
        }
    }
}
