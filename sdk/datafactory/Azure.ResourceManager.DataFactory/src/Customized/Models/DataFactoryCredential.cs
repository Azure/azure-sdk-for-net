// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    // Restores the protected parameterless constructor dropped by MPG generator (issue #59298).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("DataFactoryCredential")]
    public abstract partial class DataFactoryCredential
    {
        /// <summary> Initializes a new instance of <see cref="DataFactoryCredential"/>. </summary>
        protected DataFactoryCredential() : this(null)
        {
        }
    }
}
