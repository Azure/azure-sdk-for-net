// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Rendezvous Instruction
    /// </summary>
    public class RendezvousInstruction
    {
        /// <summary>
        /// Type of Rendezvous Instruction
        /// </summary>
        public RendezvousVariable Variable { get; set; }

        /// <summary>
        /// Value for Rendezvous Instruction in CBOR
        /// </summary>
        public byte[] Value { get; set; }

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
            if (obj is RendezvousInstruction rendezvousInstruction)
            {
                return this.Variable == rendezvousInstruction.Variable &&
                    StructuralComparisons.StructuralEqualityComparer.Equals(this.Value, rendezvousInstruction.Value);
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Variable,
                    Value != null ? StructuralComparisons.StructuralEqualityComparer.GetHashCode(Value) : 0);
        }
    }

    /// <summary>
    /// Types of Rendezvous Variable
    /// </summary>
    public enum RendezvousVariable
    {
        /// <summary>
        /// Owner should skip instruction set
        /// </summary>
        DEV_ONLY = 0,
        /// <summary>
        /// Dev should skip instruction set
        /// </summary>
        OWNER_ONLY = 1,
        /// <summary>
        /// IP address
        /// </summary>
        IP_ADDRESS = 2,
        /// <summary>
        /// Port for device
        /// </summary>
        DEV_PORT = 3,
        /// <summary>
        /// Port of owner
        /// </summary>
        OWNER_PORT = 4,
        /// <summary>
        /// DNS address
        /// </summary>
        DNS = 5,
        /// <summary>
        /// TLS server cert hash
        /// </summary>
        SV_CERT_HASH = 6,
        /// <summary>
        /// TLS CA cert hash
        /// </summary>
        CL_CERT_HASH = 7,
        /// <summary>
        /// User input
        /// </summary>
        USER_INPUT = 8,
        /// <summary>
        /// Wifi SSID
        /// </summary>
        WIFI_SSID = 9,
        /// <summary>
        /// Wifi password
        /// </summary>
        WIFI_PW = 10,
        /// <summary>
        /// Medium
        /// </summary>
        MEDIUM = 11,
        /// <summary>
        /// Protocol
        /// </summary>
        PROTOCOL = 12,
        /// <summary>
        /// Delay before retrying sequence, default 0
        /// </summary>
        DELAYSEC = 13,
        /// <summary>
        /// Bypass
        /// </summary>
        BYPASS = 14,
        /// <summary>
        /// External rendevous server
        /// </summary>
        EXT_RV = 15,
    }
}
