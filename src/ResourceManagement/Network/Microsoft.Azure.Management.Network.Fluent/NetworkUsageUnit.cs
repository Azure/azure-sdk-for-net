// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class NetworkUsageUnit
    {
        public static readonly NetworkUsageUnit COUNT = new NetworkUsageUnit("Count");
        public static readonly NetworkUsageUnit BYTES = new NetworkUsageUnit("Bytes");
        public static readonly NetworkUsageUnit SECONDS = new NetworkUsageUnit("Seconds");
        public static readonly NetworkUsageUnit PERCENT = new NetworkUsageUnit("Percent");
        public static readonly NetworkUsageUnit COUNTS_PER_SECOND = new NetworkUsageUnit("CountsPerSecond");
        public static readonly NetworkUsageUnit BYTES_PER_SECOND = new NetworkUsageUnit("BytesPerSecond");

        private string value;

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(NetworkUsageUnit lhs, NetworkUsageUnit rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(NetworkUsageUnit lhs, NetworkUsageUnit rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            string value = this.ToString();
            if (!(obj is IPVersion))
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }
            NetworkUsageUnit rhs = (NetworkUsageUnit)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value);
        }

        public override string ToString()
        {
            return this.value;
        }

        /// <summary>
        /// Creates NetworkUsageUnit.
        /// </summary>
        /// <param name="value">The value.</param>
        public NetworkUsageUnit(string value)
        {
            this.value = value;
        }
    }
}
