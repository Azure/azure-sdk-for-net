using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ApplicationGatewayTier
    {
        public static readonly ApplicationGatewayTier STANDARD = new ApplicationGatewayTier("Standard");

        private string value;

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(ApplicationGatewayTier lhs, ApplicationGatewayTier rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ApplicationGatewayTier lhs, ApplicationGatewayTier rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            string value = this.ToString();
            if (!(obj is ApplicationGatewayTier))
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }
            ApplicationGatewayTier rhs = (ApplicationGatewayTier)obj;
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
        /// Creates ApplicationGatewayTier.
        /// </summary>
        /// <param name="value">The value.</param>
        public ApplicationGatewayTier(string value)
        {
            this.value = value;
        }
    }
}
