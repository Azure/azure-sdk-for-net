// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Network
{

    using System.Collections.Generic;
    /// <summary>
    /// An interface representing a model's ability to reference load balancing rules.
    /// </summary>
    public interface IHasLoadBalancingRules 
    {
        /// <returns>the associated load balancing rules from this load balancer, indexed by their names</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Network.ILoadBalancingRule> LoadBalancingRules { get; }

    }
}