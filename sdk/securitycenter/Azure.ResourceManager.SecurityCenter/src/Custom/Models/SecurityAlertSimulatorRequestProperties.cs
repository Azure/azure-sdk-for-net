// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserve the GA parameterless constructor, which initializes the discriminator with its default value.
    public partial class SecurityAlertSimulatorRequestProperties
    {
        /// <summary> Initializes a new instance of <see cref="SecurityAlertSimulatorRequestProperties"/>. </summary>
        public SecurityAlertSimulatorRequestProperties()
            : this(default(SecurityCenterKind))
        {
        }
    }
}
