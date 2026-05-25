// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [CodeGenSuppress("SecurityAlertSimulatorRequestProperties")]
    public partial class SecurityAlertSimulatorRequestProperties
    {
        /// <summary> Initializes a new instance of <see cref="SecurityAlertSimulatorRequestProperties"/>. </summary>
        public SecurityAlertSimulatorRequestProperties()
            : this(default(SecurityCenterKind))
        {
        }
    }
}
