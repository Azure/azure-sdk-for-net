// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class ExternalSecuritySolution : ResourceData
    {
        /// <summary> The kind of the external solution. </summary>
        public ExternalSecuritySolutionKind? Kind { get; set; }
    }
}
