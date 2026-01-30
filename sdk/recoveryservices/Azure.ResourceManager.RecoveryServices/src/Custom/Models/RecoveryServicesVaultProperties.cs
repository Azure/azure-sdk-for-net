// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServices.Models
{
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

        /// <summary> Gets or sets the cross subscription restore state. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CrossSubscriptionRestoreState? CrossSubscriptionRestoreState
        {
            get => RestoreSettings is null ? default : RestoreSettings.CrossSubscriptionRestoreState;
            set
            {
                if (RestoreSettings is null)
                    RestoreSettings = new RestoreSettings();
                RestoreSettings.CrossSubscriptionRestoreState = value;
            }
        }
    }
}
