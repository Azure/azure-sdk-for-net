// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated module error info is materialized through an internal constructor.
    // Keep the GA public constructor and settable Code/Message properties.
    public partial class AutomationModuleErrorInfo
    {
        /// <summary> Initializes a new instance of <see cref="AutomationModuleErrorInfo"/>. </summary>
        public AutomationModuleErrorInfo()
        {
        }

        /// <summary> Gets or sets the error code. </summary>
        public string Code { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }

        /// <summary> Gets or sets the error message. </summary>
        public string Message { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }
    }
}
