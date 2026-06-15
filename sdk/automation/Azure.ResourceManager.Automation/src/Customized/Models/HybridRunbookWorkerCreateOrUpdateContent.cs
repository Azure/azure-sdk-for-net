// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated hybrid worker create content exposes VmResourceId but keeps resource Name only in the internal constructor shape.
    // Keep the GA public settable Name property on the request content.
    public partial class HybridRunbookWorkerCreateOrUpdateContent
    {
        /// <summary> Gets or sets the name of the resource. </summary>
        public string Name { get; set; }
    }
}
