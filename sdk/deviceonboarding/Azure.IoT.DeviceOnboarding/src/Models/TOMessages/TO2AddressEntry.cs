// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// To2 Address Entry
    /// </summary>
    public class TO2AddressEntry
    {
        /// <summary>
        /// IP address where Owner is waiting for TO2
        /// </summary>
        public byte[] IpAddress { get; set; }

        /// <summary>
        /// DNS address where Owner is waiting for TO2
        /// </summary>
        public string DnsAddress { get; set; }

        /// <summary>
        /// TCP/UDP port to go with above
        /// </summary>
#pragma warning disable CS3003 // Type is not CLS-compliant
        public ushort Port { get; set; }
#pragma warning restore CS3003 // Type is not CLS-compliant

        /// <summary>
        /// Transport Protocol, to go with above
        /// </summary>
        public TransportProtocol Protocol { get; set; }

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
            if (obj is TO2AddressEntry to2AddressEntry)
            {
                return StructuralComparisons.StructuralEqualityComparer.Equals(this.IpAddress, to2AddressEntry.IpAddress) &&
                    string.Equals(this.DnsAddress, to2AddressEntry.DnsAddress) &&
                    this.Port == to2AddressEntry.Port &&
                    this.Protocol == to2AddressEntry.Protocol;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.DnsAddress, this.Port, this.Protocol,
                StructuralComparisons.StructuralEqualityComparer.GetHashCode(this.IpAddress));
        }
    }
}
