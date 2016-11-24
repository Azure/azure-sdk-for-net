// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// Possible routing methods supported by Traffic manager profile.
    /// </summary>
    public partial class TrafficRoutingMethod 
    {
        public static readonly TrafficRoutingMethod PERFORMANCE = new TrafficRoutingMethod("Performance");
        public static readonly TrafficRoutingMethod WEIGHTED = new TrafficRoutingMethod("Weighted");
        public static readonly TrafficRoutingMethod PRIORITY = new TrafficRoutingMethod("Priority");

        private string value;

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(TrafficRoutingMethod lhs, TrafficRoutingMethod rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TrafficRoutingMethod lhs, TrafficRoutingMethod rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            string value = this.ToString();
            if (!(obj is TrafficRoutingMethod))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            TrafficRoutingMethod rhs = (TrafficRoutingMethod)obj;
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
        /// Creates TrafficRoutingMethod.
        /// </summary>
        /// <param name="value">The value.</param>
        public TrafficRoutingMethod(string value)
        {
            this.value = value;
        }
    }
}