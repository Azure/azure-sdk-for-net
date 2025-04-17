// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Class representing device credential used for FDO
    /// </summary>
    public class DeviceCredential
    {
        /// <summary>
        /// Whether the sepcified device credential is active
        /// </summary>
        public bool IsActive { get; internal set; }
        /// <summary>
        /// Version of FDO protocol
        /// </summary>
        public ProtocolVersion DeviceProtocolVersion { get; internal set; }
        /// <summary>
        /// Registration guid used for the device
        /// </summary>
        public Guid DeviceGuid { get; internal set; }
        /// <summary>
        /// Instructions for connecting to RV for performing TO1
        /// </summary>
        public RendezvousInfo DeviceRVInfo { get; internal set; }
        /// <summary>
        /// Manufacturer public key hash
        /// </summary>
        public Hash PublicKeyHash { get; internal set; }
        /// <summary>
        /// Device info
        /// </summary>
        public string DeviceInfo { get; internal set; }
        /// <summary>
        /// HMAC secret identifier
        /// </summary>
        internal Hash HmacSecret { get; set; }
        /// <summary>
        /// Device secret identifier
        /// </summary>
        internal string DeviceSecret { get; set; }
        /// <summary>
        /// Device key size
        /// </summary>
        internal int DeviceKeySize { get; set; }
        /// <summary>
        /// Device key type
        /// </summary>
        public PublicKeyType DeviceKeyType { get; set; }

        /// <summary>
        /// Create new instance of DeviceCredential
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="guid"></param>
        /// <param name="protocolVersion"></param>
        /// <param name="deviceInfo"></param>
        /// <param name="rendezvousInfo"></param>
        /// <param name="publicKeyType"></param>
        /// <param name="keySize"></param>
        public DeviceCredential(
            bool isActive,
            Guid guid,
            ProtocolVersion protocolVersion,
            string deviceInfo,
            RendezvousInfo rendezvousInfo,
            PublicKeyType publicKeyType,
            KeySize keySize)
        {
            IsActive = isActive;
            DeviceGuid = guid;
            DeviceProtocolVersion = protocolVersion;
            DeviceInfo = deviceInfo;
            DeviceRVInfo = rendezvousInfo;
            DeviceKeyType = publicKeyType;
            DeviceKeySize = (int)keySize;
        }
    }

    /// <summary>
    /// Version of the FDO protocol being used
    /// </summary>
    public enum ProtocolVersion
    {
        /// <summary>
        /// Version 101 of the FDO protocol
        /// Defined at: https://fidoalliance.org/specs/FDO/FIDO-Device-Onboard-PS-v1.1-20220419/FIDO-Device-Onboard-PS-v1.1-20220419.html
        /// </summary>
        V101 = 101
    }
}
