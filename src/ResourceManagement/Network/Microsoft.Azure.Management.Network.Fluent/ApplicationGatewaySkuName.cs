using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ApplicationGatewaySkuName
    {
        public static readonly ApplicationGatewaySkuName STANDARD_SMALL = new ApplicationGatewaySkuName("Standard_Small");
        public static readonly ApplicationGatewaySkuName STANDARD_MEDIUM = new ApplicationGatewaySkuName("Standard_Medium");
        public static readonly ApplicationGatewaySkuName STANDARD_LARGE = new ApplicationGatewaySkuName("Standard_Large");

        private string value;

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(ApplicationGatewaySkuName lhs, ApplicationGatewaySkuName rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ApplicationGatewaySkuName lhs, ApplicationGatewaySkuName rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            string value = this.ToString();
            if (!(obj is ApplicationGatewaySkuName))
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }
            ApplicationGatewaySkuName rhs = (ApplicationGatewaySkuName)obj;
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
        /// Creates ApplicationGatewaySkuName.
        /// </summary>
        /// <param name="value">The value.</param>
        public ApplicationGatewaySkuName(string value)
        {
            this.value = value;
        }
    }
}
