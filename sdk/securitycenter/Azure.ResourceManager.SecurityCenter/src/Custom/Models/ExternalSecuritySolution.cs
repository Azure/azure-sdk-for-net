// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class ExternalSecuritySolution
    {
        /// <summary> Initializes a new instance of <see cref="ExternalSecuritySolution"/>. </summary>
        public ExternalSecuritySolution()
        {
        }

        // Compatibility customization: the spec marks kind as read-only, but the GA SDK exposed a settable Kind property.
        /// <summary> Gets or sets the kind of the external security solution. </summary>
        public ExternalSecuritySolutionKind? Kind { get; set; }
    }
}
