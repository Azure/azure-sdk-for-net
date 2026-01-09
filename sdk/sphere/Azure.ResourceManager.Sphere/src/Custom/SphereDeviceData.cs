// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Sphere.Models;

namespace Azure.ResourceManager.Sphere
{
    public partial class SphereDeviceData
    {
        /// <summary> Device ID. </summary>
        public string DeviceId
        {
            get => Properties?.DeviceId;
            set
            {
                EnsureProperties();
                Properties.DeviceId = value;
            }
        }

        /// <summary> The chip SKU of the device. </summary>
        public string ChipSku => Properties?.ChipSku;

        /// <summary> The last available OS version for the device. </summary>
        public string LastAvailableOSVersion => Properties?.LastAvailableOsVersion;

        /// <summary> The last installed OS version for the device. </summary>
        public string LastInstalledOSVersion => Properties?.LastInstalledOsVersion;

        /// <summary> The date and time when the OS was last updated (UTC). </summary>
        public DateTimeOffset? LastOSUpdateUtc => Properties?.LastOsUpdateUtc;

        /// <summary> The date and time when the OS update was last requested (UTC). </summary>
        public DateTimeOffset? LastUpdateRequestUtc => Properties?.LastUpdateRequestUtc;

        /// <summary> The status of the last operation. </summary>
        public SphereProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        private void EnsureProperties() => Properties ??= new DeviceProperties();
    }
}
