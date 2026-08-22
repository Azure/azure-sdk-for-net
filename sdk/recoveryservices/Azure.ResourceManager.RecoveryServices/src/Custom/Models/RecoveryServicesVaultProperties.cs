// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServices.Models
{
    [CodeGenSuppress("RegionOfChoiceStatus")]
    public partial class RecoveryServicesVaultProperties
    {
        /// <summary>
        /// Immutability Settings of a vault
        /// Serialized Name: SecuritySettings.immutabilitySettings
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImmutabilityState? ImmutabilityState
        {
            get => SecuritySettings?.ImmutabilityState;
            set
            {
                if (SecuritySettings is null)
                {
                    SecuritySettings = new RecoveryServicesSecuritySettings();
                }
                SecuritySettings.ImmutabilityState = value;
            }
        }

        /// <summary> The status of region of choice settings - Enabled or Disabled. </summary>
        public RecoveryServicesSourceScanState? RegionOfChoiceStatus
        {
            get => RegionOfChoiceSettings?.Status;
            set
            {
                if (value.HasValue)
                {
                    RegionOfChoiceSettings ??= new RegionOfChoiceSettings();
                    RegionOfChoiceSettings.Status = value;
                }
                else
                {
                    RegionOfChoiceSettings = null;
                }
            }
        }
    }
}
