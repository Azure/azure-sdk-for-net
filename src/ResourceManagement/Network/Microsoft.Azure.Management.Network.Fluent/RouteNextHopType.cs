// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for RouteNextHopType.
    /// </summary>
    public class RouteNextHopType
    {
        public static readonly RouteNextHopType VIRTUAL_NETWORK_GATEWAY = new RouteNextHopType("VirtualNetworkGateway");
        public static readonly RouteNextHopType VNET_LOCAL = new RouteNextHopType("VnetLocal");
        public static readonly RouteNextHopType INTERNET = new RouteNextHopType("Internet");
        public static readonly RouteNextHopType VIRTUAL_APPLIANCE = new RouteNextHopType("VirtualAppliance");
        public static readonly RouteNextHopType NONE = new RouteNextHopType("None");

        private string value;

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(RouteNextHopType lhs, RouteNextHopType rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(RouteNextHopType lhs, RouteNextHopType rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            string value = this.ToString();
            if (!(obj is RouteNextHopType))
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }
            RouteNextHopType rhs = (RouteNextHopType)obj;
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
        /// Creates RouteNextHopType.
        /// </summary>
        /// <param name="value">The value.</param>
        public RouteNextHopType(string value)
        {
            this.value = value;
        }
    }
}
