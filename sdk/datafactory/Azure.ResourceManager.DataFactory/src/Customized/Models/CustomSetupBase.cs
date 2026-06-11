// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    // Restores the protected parameterless constructor dropped by MPG generator (issue #59298).
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CustomSetupBase")]
    public abstract partial class CustomSetupBase
    {
        /// <summary> Initializes a new instance of <see cref="CustomSetupBase"/>. </summary>
        protected CustomSetupBase() : this(null)
        {
        }
    }
}
