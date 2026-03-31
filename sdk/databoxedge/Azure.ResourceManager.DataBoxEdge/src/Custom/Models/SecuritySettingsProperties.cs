// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Generated DeviceAdminPassword is getter-only auto-property. This Custom/ partial replaces it
// with a field-backed property that has both getter and setter, needed by DataBoxEdgeSecuritySettings.DeviceAdminPassword setter.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    internal partial class SecuritySettingsProperties
    {
        private AsymmetricEncryptedSecret _deviceAdminPassword;

        /// <summary> Device administrator password as an encrypted string. </summary>
        public AsymmetricEncryptedSecret DeviceAdminPassword
        {
            get => _deviceAdminPassword;
            set => _deviceAdminPassword = value;
        }
    }
}
