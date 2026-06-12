// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving the GA resource name setter on hybrid worker create/update content.
    [CodeGenSuppress("Name")]
    public partial class HybridRunbookWorkerCreateOrUpdateContent
    {
        /// <summary> Gets or sets the name of the resource. </summary>
        public string Name { get; set; }
    }
}
