// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.FrontDoor;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.FrontDoor.Mocking
{
    // The new TypeSpec mgmt generator hardcodes the extension-method name for a List operation as
    // $"Get{resourceName.Pluralize()}[Async]" in
    // eng/packages/http-client-csharp-mgmt/generator/Azure.Generator.Management/src/Utilities/ResourceHelpers.cs
    // (GetExtensionOperationMethodName). The operation's @@clientName is not consulted on that path,
    // so there is no spec-side lever to restore the baseline long method name. Suppress the generated
    // short-named methods here and provide the long-named ones for API back-compat.
    // Tracked by https://github.com/Azure/azure-sdk-for-net/issues/58455 - this customization can be
    // deleted once the generator honors @@clientName on the list operation.
    [CodeGenSuppress("GetFrontDoorWebApplicationFirewallPolicies", typeof(CancellationToken))]
    [CodeGenSuppress("GetFrontDoorWebApplicationFirewallPoliciesAsync", typeof(CancellationToken))]
    public partial class MockableFrontDoorSubscriptionResource
    {
        /// <summary> Lists all of the protection policies within a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<FrontDoorWebApplicationFirewallPolicyResource> GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicyAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<FrontDoorWebApplicationFirewallPolicyData, FrontDoorWebApplicationFirewallPolicyResource>(
                new PoliciesGetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicyAsyncCollectionResultOfT(
                    PoliciesRestClient, Id.SubscriptionId, context,
                    "MockableFrontDoorSubscriptionResource.GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicy"),
                data => new FrontDoorWebApplicationFirewallPolicyResource(Client, data));
        }

        /// <summary> Lists all of the protection policies within a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<FrontDoorWebApplicationFirewallPolicyResource> GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicy(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<FrontDoorWebApplicationFirewallPolicyData, FrontDoorWebApplicationFirewallPolicyResource>(
                new PoliciesGetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicyCollectionResultOfT(
                    PoliciesRestClient, Id.SubscriptionId, context,
                    "MockableFrontDoorSubscriptionResource.GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicy"),
                data => new FrontDoorWebApplicationFirewallPolicyResource(Client, data));
        }
    }
}
