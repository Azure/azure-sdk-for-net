// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: the spec-side replacement restores the GA model name, while this preserves the GA public constructor and settable Kind property.
    [CodeGenSuppress("ExternalSecuritySolution")]
    [CodeGenSuppress("Kind")]
    public partial class ExternalSecuritySolution
    {
        /// <summary> Initializes a new instance of <see cref="ExternalSecuritySolution"/>. </summary>
        public ExternalSecuritySolution()
        {
        }

        /// <summary> Gets or sets the kind of the external security solution. </summary>
        public ExternalSecuritySolutionKind? Kind { get; set; }
    }
}
