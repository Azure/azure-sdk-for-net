// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated credential content keeps Description under CredentialCreateOrUpdateProperties.
    // Keep the GA top-level settable Description property.
    public partial class AutomationCredentialCreateOrUpdateContent
    {
        /// <summary> Gets or sets the description of the credential. </summary>
        public string Description
        {
            get => Properties.Description;
            set => Properties.Description = value;
        }
    }
}
