// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.DeviceUpdate.Models
{
    /// <summary>
    /// Update compatibility information.
    /// </summary>
    public class ImportManifestCompatibilityInfo
    {
        public ImportManifestCompatibilityInfo(string deviceManufacturer, string deviceModel)
        {
            DeviceManufacturer = deviceManufacturer;
            DeviceModel = deviceModel;
        }

        /// <summary>
        /// Device manufacturer an update is compatible with.
        /// </summary>
        public string DeviceManufacturer { get; private set; }

        /// <summary>
        /// Device model an update is compatible with.
        /// </summary>
        public string DeviceModel { get; private set; }
    }
}
