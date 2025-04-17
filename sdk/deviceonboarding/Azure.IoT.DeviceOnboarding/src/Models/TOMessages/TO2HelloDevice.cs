// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Hello Device
    /// </summary>
    public class TO2HelloDevice
    {
        /// <summary>
        /// Maximum sized FIDO Device Onboard message the Device is able to receive, buffer, and decode;
        /// Value of 0 indicates default message size
        /// </summary>
        public ushort MaxMessageSize { get; set; }

        /// <summary>
        /// Device protocol guid
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// FDONonce To2 Prove OV
        /// </summary>
        public FDONonce NonceProveTo2Ov { get; set; }

        /// <summary>
        /// Key Exchange Protocol Suite to use
        /// </summary>
        public string KexSuiteName { get; set; }

        /// <summary>
        /// Cipher Suite Type  to use
        /// </summary>
        public CipherSuiteType CipherSuiteType { get; set; }

        /// <summary>
        /// Device attestation signature info
        /// </summary>
        public SigInfo EASigInfo { get; set; }

        /// <summary>
        /// Override Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj is TO2HelloDevice to2HelloDevice)
            {
                return this.MaxMessageSize == to2HelloDevice.MaxMessageSize &&
                    this.Guid.Equals(to2HelloDevice.Guid) &&
                    object.Equals(this.NonceProveTo2Ov, to2HelloDevice.NonceProveTo2Ov) &&
                    string.Equals(this.KexSuiteName, to2HelloDevice.KexSuiteName, System.StringComparison.Ordinal) &&
                    this.CipherSuiteType == to2HelloDevice.CipherSuiteType &&
                    object.Equals(this.EASigInfo, to2HelloDevice.EASigInfo);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(
                MaxMessageSize,
                Guid,
                NonceProveTo2Ov?.GetHashCode() ?? 0,
                KexSuiteName, CipherSuiteType,
                EASigInfo?.GetHashCode() ?? 0);
        }
    }
}
