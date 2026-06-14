// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving GA constructor and setters for module error info.
    [CodeGenSuppress("AutomationModuleErrorInfo")]
    [CodeGenSuppress("Code")]
    [CodeGenSuppress("Message")]
    public partial class AutomationModuleErrorInfo
    {
        /// <summary> Initializes a new instance of <see cref="AutomationModuleErrorInfo"/>. </summary>
        public AutomationModuleErrorInfo()
        {
        }

        /// <summary> Gets or sets the error code. </summary>
        public string Code { get; set; }

        /// <summary> Gets or sets the error message. </summary>
        public string Message { get; set; }
    }
}
