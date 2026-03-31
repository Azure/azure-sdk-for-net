// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Generated DeviceAdminPassword property is getter-only, but baseline API had a setter.
// This Custom/ property shadows the generated one to add a setter for backward compatibility.
// Also requires SecuritySettingsProperties.cs Custom/ to add setter on the inner property.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class DataBoxEdgeSecuritySettings
    {
        /// <summary> Device administrator password as an encrypted string. </summary>
        public AsymmetricEncryptedSecret DeviceAdminPassword
        {
            get => Properties.DeviceAdminPassword;
            set => Properties.DeviceAdminPassword = value;
        }
    }
}
