// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsSecurityRuleData
    {
        // Backward-compat convenience constructor preserved from the AutoRest-generated API surface.
        /// <param name="location"> The location. </param>
        /// <param name="priority"> The priority of the DNS security rule. </param>
        /// <param name="action"> The action to take on DNS requests that match the DNS security rule. </param>
        /// <param name="dnsResolverDomainLists"> DNS resolver policy domains lists that the DNS security rule applies to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="action"/> or <paramref name="dnsResolverDomainLists"/> is null. </exception>
        public DnsSecurityRuleData(AzureLocation location, int priority, DnsSecurityRuleAction action, IEnumerable<WritableSubResource> dnsResolverDomainLists) : this(location, priority)
        {
            Argument.AssertNotNull(action, nameof(action));
            Argument.AssertNotNull(dnsResolverDomainLists, nameof(dnsResolverDomainLists));

            ActionType = action.ActionType;
            foreach (var item in dnsResolverDomainLists)
            {
                DnsResolverDomainLists.Add(item);
            }
        }
    }
}
