// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: kind is read-visible in the spec and that visibility cannot be overridden for C# only, so preserve the GA settable Kind property here.
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
