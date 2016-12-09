// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for IPVersion.
    /// </summary>
    public class IPVersion
    {
        public static readonly IPVersion IPV4 = new IPVersion("IPv4");
        public static readonly IPVersion IPV6 = new IPVersion("IPv6");

        private string value;

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(IPVersion lhs, IPVersion rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(IPVersion lhs, IPVersion rhs)
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
            IPVersion rhs = (IPVersion)obj;
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
        /// Creates IPVersion.
        /// </summary>
        /// <param name="value">The value.</param>
        public IPVersion(string value)
        {
            this.value = value;
        }
    }
}
