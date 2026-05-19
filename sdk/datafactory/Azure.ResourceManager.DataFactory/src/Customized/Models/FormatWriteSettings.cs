// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the protected parameterless constructor dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("FormatWriteSettings")]
    public abstract partial class FormatWriteSettings
    {
        /// <summary> Initializes a new instance of <see cref="FormatWriteSettings"/>. </summary>
        protected FormatWriteSettings() : this(null)
        {
        }
    }
}
