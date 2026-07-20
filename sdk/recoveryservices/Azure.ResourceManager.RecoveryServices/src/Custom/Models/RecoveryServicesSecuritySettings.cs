// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServices.Models
{
    public partial class RecoveryServicesSecuritySettings
    {
        /// <summary> Gets or sets the immutability state. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImmutabilityState? ImmutabilityState
        {
            get => ImmutabilitySettings?.State;
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
