// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public partial class BackupVaultSecuritySettings
    {
        /// <summary> Immutability state. </summary>
        public BackupVaultImmutabilityState? ImmutabilityState
        {
            get => ImmutabilitySettings is null ? default : ImmutabilitySettings.State;
            set
            {
                if (ImmutabilitySettings is null)
                {
                    ImmutabilitySettings = new ImmutabilitySettings();
                }
                ImmutabilitySettings.State = value;
            }
        }
    }
}