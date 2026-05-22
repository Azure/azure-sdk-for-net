// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Preserve the GA model name while the spec-side replacement prevents the management-plane resource data suffix.
    /// <summary> External Security Solution. </summary>
    [CodeGenSuppress("ExternalSecuritySolution")]
    [CodeGenSuppress("Kind")]
    public partial class ExternalSecuritySolution
    {
        /// <summary> Initializes a new instance of <see cref="ExternalSecuritySolution"/>. </summary>
        public ExternalSecuritySolution()
        {
        }

        /// <summary> Gets or sets the kind of the external security solution. </summary>
        public ExternalSecuritySolutionKind? Kind { get => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); set => throw new System.NotSupportedException("This member is preserved for compatibility with a previous SecurityCenter API surface."); }
    }
}
