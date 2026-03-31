// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Generated multi-level flatten of authentication.symmetricKey.connectionString produced
// "AuthenticationSymmetricKeyConnectionString", but baseline API had "SymmetricKeyConnectionString".
// This adds a backward-compatible alias property.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class EdgeIotDeviceInfo
    {
        /// <summary> Encrypted IoT device/IoT edge device connection string. </summary>
        public AsymmetricEncryptedSecret SymmetricKeyConnectionString
        {
            get => AuthenticationSymmetricKeyConnectionString;
            set => AuthenticationSymmetricKeyConnectionString = value;
        }
    }
}
