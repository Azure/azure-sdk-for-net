// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class ApplicationGatewayRequestRoutingRuleType : ExpandableStringEnum<ApplicationGatewayRequestRoutingRuleType>
    {
        public static readonly ApplicationGatewayRequestRoutingRuleType Basic = new ApplicationGatewayRequestRoutingRuleType() { Value = "Basic" };
        public static readonly ApplicationGatewayRequestRoutingRuleType PathBasedRouting = new ApplicationGatewayRequestRoutingRuleType() { Value = "PathBasedRouting" };
    }
}
