// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Network.Fluent.Models
{

    /// <summary>
    /// Defines values for ApplicationGatewayProtocol.
    /// </summary>
    public class ApplicationGatewayProtocol
    {
        public static readonly ApplicationGatewayProtocol Http = new ApplicationGatewayProtocol("Http");
        public static readonly ApplicationGatewayProtocol Https = new ApplicationGatewayProtocol("Https");

        private string value;

        public ApplicationGatewayProtocol(string protocolName)
        {
            value = protocolName;
        }

        public override string ToString()
        {
            return value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(ApplicationGatewayProtocol lhs, ApplicationGatewayProtocol rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ApplicationGatewayProtocol lhs, ApplicationGatewayProtocol rhs)
        {
            return !(lhs == rhs);
        }

        public static ApplicationGatewayProtocol Parse(string value)
        {
            if(value == null)
            {
                return null;
            }
            else if (Http.Equals(value))
            {
                return Http;
            }
            else if(Https.Equals(value))
            {
                return Https;
            }
            else
            {
                return new ApplicationGatewayProtocol(value);
            }
        }

        public bool Equals(string value)
        {
            if (value == null)
            {
                return null == this.value;
            }
            else
            {
                return value.ToLower().Equals(this.value.ToLower());
            }
        }

        public override bool Equals(object obj)
        {
            string value = ToString();
            if (!(obj is ApplicationGatewayProtocol))
            {
                return false;
            }
            else if (obj == this)
            {
                return true;
            }

            ApplicationGatewayProtocol rhs = (ApplicationGatewayProtocol)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value);
        }
    }
}
