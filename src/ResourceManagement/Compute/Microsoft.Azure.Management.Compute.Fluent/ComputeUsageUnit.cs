// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Compute
{
    /// <summary>
    /// Compute usage units.
    /// </summary>
    public class ComputeUsageUnit
    {
        public static readonly ComputeUsageUnit COUNT = new ComputeUsageUnit("Count");
        public static readonly ComputeUsageUnit BYTES = new ComputeUsageUnit("Bytes");
        public static readonly ComputeUsageUnit SECONDS = new ComputeUsageUnit("Seconds");
        public static readonly ComputeUsageUnit PERCENT = new ComputeUsageUnit("Percent");
        public static readonly ComputeUsageUnit COUNTS_PER_SECOND = new ComputeUsageUnit("CountsPerSecond");
        public static readonly ComputeUsageUnit BYTES_PER_SECOND = new ComputeUsageUnit("BytesPerSecond");

        private string value;
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(ComputeUsageUnit lhs, ComputeUsageUnit rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ComputeUsageUnit lhs, ComputeUsageUnit rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {

            string value = this.ToString();
            if (!(obj is ComputeUsageUnit))
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }
            ComputeUsageUnit rhs = (ComputeUsageUnit)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value);
        }

        /// <summary>
        /// Creates ProfileMonitorStatus.
        /// </summary>
        /// <param name="value">The status.</param>
        public ComputeUsageUnit(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return this.value;
        }
    }
}
