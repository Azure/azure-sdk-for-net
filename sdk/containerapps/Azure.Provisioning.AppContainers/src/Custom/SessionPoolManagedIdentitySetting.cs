// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppContainers
{
    public partial class SessionPoolManagedIdentitySetting
    {
        private BicepValue<ContainerAppIdentitySettingsLifeCycle> _lifecycle;

        // Preserve the released lifecycle enum type after the stable API introduced a session-pool-specific enum.
        /// <summary> Gets or sets the Lifecycle. </summary>
        [CodeGenMember("Lifecycle")]
        public BicepValue<ContainerAppIdentitySettingsLifeCycle> Lifecycle
        {
            get
            {
                Initialize();
                return _lifecycle;
            }
            set
            {
                Initialize();
                _lifecycle.Assign(value);
            }
        }

        partial void DefineAdditionalProperties()
        {
            _lifecycle = DefineProperty<ContainerAppIdentitySettingsLifeCycle>(nameof(Lifecycle), new string[] { "lifecycle" });
        }
    }
}
