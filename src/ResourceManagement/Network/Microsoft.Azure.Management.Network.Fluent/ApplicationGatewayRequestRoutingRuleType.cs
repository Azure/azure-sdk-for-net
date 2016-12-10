// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ApplicationGatewayRequestRoutingRuleType
    {
        public static readonly ApplicationGatewayRequestRoutingRuleType BASIC = new ApplicationGatewayRequestRoutingRuleType("Basic");
        public static readonly ApplicationGatewayRequestRoutingRuleType PATHBASED_ROUTING = new ApplicationGatewayRequestRoutingRuleType("PathBasedRouting");

        private string value;

        public ApplicationGatewayRequestRoutingRuleType(string protocolName)
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

        public static bool operator ==(ApplicationGatewayRequestRoutingRuleType lhs, ApplicationGatewayRequestRoutingRuleType rhs)
        {
            if (ReferenceEquals(lhs, null))
            {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ApplicationGatewayRequestRoutingRuleType lhs, ApplicationGatewayRequestRoutingRuleType rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            string value = ToString();
            if (!(obj is ApplicationGatewayRequestRoutingRuleType))
            {
                return false;
            }
            else if (obj == this)
            {
                return true;
            }
            ApplicationGatewayRequestRoutingRuleType rhs = (ApplicationGatewayRequestRoutingRuleType)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value);
        }
    }
}
