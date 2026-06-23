// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    public partial class AutomationAccountModulePatch
    {
        /// <summary> Gets or sets name of the resource. </summary>
        [CodeGenMember("Name")]
        public string Name { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }

        /// <summary> Gets or sets the location of the resource. </summary>
        [CodeGenMember("Location")]
        public AzureLocation? Location { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }
    }
}