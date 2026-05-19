// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the protected parameterless constructor dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("IntegrationRuntimeStatus")]
    public abstract partial class IntegrationRuntimeStatus
    {
        /// <summary> Initializes a new instance of <see cref="IntegrationRuntimeStatus"/>. </summary>
        protected IntegrationRuntimeStatus() : this(default(IntegrationRuntimeType))
        {
        }
    }
}
