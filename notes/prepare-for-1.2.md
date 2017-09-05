# Prepare for Azure Management Libraries for .NET 1.2 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.1 to 1.2 …

> If this note missed any breaking changes, please open a pull request.

V1.2 is backwards compatible with V1.1 in the APIs intended for public use that reached the general availability (stable) stage in V1.0. 

Some breaking changes were introduced in APIs that were still in Beta in V1.1 as inherited from the `IBeta` interface.

## Graph RBAC

When you create a service principal, there's an option to export an authentication file:

```CSharp
return authenticated.ServicePrincipals
    .Define(SpName)
    .WithNewApplication(AppName)
    // password credentials definition
    .DefinePasswordCredential("password")
        .WithPasswordValue("P@ssw0rd")
        // export the credentials to the file
        .WithAuthFileToExport(authFileStream)
    .Attach()
    .WithNewRoleInSubscription(role, subscriptionId)
    .Create();
```

For more information about the auth file formats, please see the documentations here: https://github.com/Azure/azure-sdk-for-net/blob/Fluent/AUTH.md#auth-file-formats .

## Load Balancer API rework

The load balancer API, which has been in Beta, has undergone a major rework to further simplify the user model, to achieve greater consistency with 
the application gateway model, as well as to enable additional configuration scenarios that became possible as a result of more recent enhancements
in the Azure Load Balancer service.

The rework includes naming changes, some API removals, some additions, as well as a reordering of the load balancer definition flow.


### Definition flow changes

#### Simplified required flow

Other than the usual requirement for a region and a resource group at the beginning of a load balancer definition flow, the only other syntactically required element is the definition of at least one load balancing rule (`.DefineLoadBalancingRule()`), OR an inbound NAT rule (`.DefineInboundNatRule()`), OR an inbound NAT pool (`.DefineInboundNatPool()`). Attaching at least one of these child elements results in a minimally functional and useful load balancer configuration. This change also enables the creation of load balancers which only have NAT rules or NAT pools and no LB rules, which was not possible in the earlier versions of the SDK. 

#### Frontends optional

Previously, at least one explicit frontend definition was required near the beginning of a load balancer definition flow, which could then be referred to from load balancing rules, NAT rules, and/or NAT pools. Although a frontend IP configuration is still a required child element of a load balancer under the hood, there are now methods within the LB rule, NAT rule and NAT pool definition flows which create automatically-named frontends implicitly, via a reference to a new or existing public IP address (`.FromExistingPublicIPAddress(pip)` | `.FromNewPublicIPAddress(dnsLabel)`) or to an existing virtual network subnet (`.FromExistingSubnet(network, subnetName)`). The former would result in the creation of a public (Internet-facing) frontend, whereas the latter would create a private internal frontend.

Note that if the same public IP reference is used by two or more rules/pools, they will all be automatically associated with the same frontend IP configuration under the hood, since multiple frontends pointing to the same public IP address are not allowed by the underlying service. Analogous logic applies to subnets.

Hence, frontend definitions are now in the optional ("Creatable") section of the load balancer definition. Note however that if any of these \*rules or \*pools reference a frontend *by name*, rather than implicitly by a public IP address or subnet, then a frontend with that name MUST be defined explicitly later in that load balancer definition flow, despite of its "optional" status.

#### Probes optional
Probe definitions (`.DefineHttpProbe() | .DefineTcpProbe()`) have now been moved into the optional ("Creatable") section of the load balancer definition flow as they are no longer required by the underlying service. Default probes are provided by Azure if no explicit probes are defined.

#### Backends optional
Backend definitions (`.DefineBackend()`) have now been moved into the optional ("Creatable") section of the load balancer definition flow. Backends can be implicitly created by the load balancing or NAT rule definitions by merely referencing their name (`.ToBackend(name)`).

#### No more "default" child elements
Previous releases of the load balancer API supported a notion of "default" child elements, such as default frontends, backends, etc. Those elements, when created implicitly, would assume the name "default" and would be the ones that other methods would refer to in implicit ways. In some sense, these "default" child elements were "global" across the load balancer definition.

This entire notion of a "default" child element of a load balancer has now been removed. The name "default" no longer has any special meaning and the methods operating on such default elements have been either removed or reworked. For example, `.WithExistingPublicIPAddress()` which would have created a public frontend named "default" no longer appears in the load balancer definition flow. As mentioned earlier, certain child elements still can be created implicitly (e.g. frontends), but the names generated for them in such cases are unique and associated with the context they are created from (i.e., for example a specific load balancing rule).


### Renames

The following naming associated with load balancers has been changed in ways that break backwards compatibility with the previous Beta releases of this API:

<table>
  <tr>
    <th align=left>From</th>
    <th align=left>To</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
      <td><code>LoadBalancer.UpdateInternetFrontend()</code></td>
      <td><code>LoadBalancer.UpdatePublicFrontend()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/c6e01e205bc26e168193afa1c437082a2cdcb497">cb497</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancer.UpdateInternalFrontend()</code></td>
      <td><code>LoadBalancer.UpdatePrivateFrontend()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/c6e01e205bc26e168193afa1c437082a2cdcb497">cb497</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancingRule.WithFrontend()</code></td>
      <td><code>LoadBalancingRule.FromFrontend()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancerInboundNatRule.WithFrontend()</code></td>
      <td><code>LoadBalancerRuleInboundNatRule.FromFrontend()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancerInboundNatPool.WithFrontend()</code></td>
      <td><code>LoadBalancerRuleInboundNatPool.FromFrontend()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancingRule.WithBackend()</code></td>
      <td><code>LoadBalancingRule.ToBackend()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancingRule.WithBackendPort()</code></td>
      <td><code>LoadBalancingRule.ToBackendPort()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancerInboundNatRule.WithBackendPort()</code></td>
      <td><code>LoadBalancerInboundNatRule.ToBackendPort()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancerInboundNatPool.WithBackendPort()</code></td>
      <td><code>LoadBalancerInboundNatPool.ToBackendPort()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancingRule.WithFrontendPort()</code></td>
      <td><code>LoadBalancingRule.FromFrontendPort()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancerInboundNatRule.WithFrontendPort()</code></td>
      <td><code>LoadBalancerInboundNatRule.FromFrontendPort()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancerInboundNatPool.WithFrontendPortRange()</code></td>
      <td><code>LoadBalancerInboundNatPool.FromFrontendPortRange()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancingRule.WithExistingPublicIPAddress()</code></td>
      <td><code>LoadBalancingRule.FromExistingPublicIPAddress()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancerInboundNatRule.WithExistingPublicIPAddress()</code></td>
      <td><code>LoadBalancerInboundNatRule.FromExistingPublicIPAddress()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
      <td><code>LoadBalancerInboundNatPool.WithExistingPublicIPAddress()</code></td>
      <td><code>LoadBalancerInboundNatPool.FromExistingPublicIPAddress()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>

</table>

### API Removals

<table>
  <tr>
    <th>Removed</th>
    <th>Alternate to switch to</th>
    <th>PR</th>
  </tr>
  <tr>
    <td><code>LoadBalancer.WithNewPublicIPAddress()</code></td>
    <td><code>LoadBalancerPublicFrontend.WithNewPublicIPAddress()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
    <td><code>LoadBalancer.WithExistingPublicIPAddress()</code></td>
    <td><code>LoadBalancerPublicFrontend.WithExistingPublicIPAddress()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
    <td><code>LoadBalancer.WithFrontendSubnet()</code></td>
    <td><code>LoadBalancerPrivateFrontend.WithExistingSubnet()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>  
  <tr>
    <td><code>LoadBalancer.WithLoadBalancingRule()</code></td>
    <td><code>LoadBalancer.DefineLoadBalancingRule()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
    <td><code>LoadBalancer.WithHttpProbe()</code></td>
    <td><code>LoadBalancer.DefineHttpProbe()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
    <td><code>LoadBalancer.WithTcpProbe()</code></td>
    <td><code>LoadBalancer.DefineTcpProbe()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
  <tr>
    <td><code>LoadBalancer.WithExistingVirtualMachines()</code></td>
    <td><code>LoadBalancerBackend.WithExistingVirtualMachines()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/24969e3371d49e9b8088457722e51a3878bd5815">d5815</a></td>
  </tr>
</table>

## DocumentDB API renamed to CosmosDB.

The document db API which was in the Microsoft.Azure.Management.DocumentDB.Fluent namespace has been moved to Microsoft.Azure.Management.CosmosDB.Fluent. The Nuget package id has been changed from Microsoft.Azure.Management.DocumentDB.Fluent to Microsoft.Azure.Management.CosmosDB.Fluent. 

### Renames

The following naming associated with document db has been changed in ways that break backwards compatibility with the previous releases of this API:

<table>
  <tr>
    <th align=left>From</th>
    <th align=left>To</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
      <td><code>DocumentDBAccount</code></td>
      <td><code>CosmosDBAccount</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/a28b18c59f463f88e6d8322e2a5a733e1f0a594d">a594d</a></td>
  </tr>
  <tr>
      <td><code>DocumentDBAccounts</code></td>
      <td><code>CosmosDBAccounts</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/a28b18c59f463f88e6d8322e2a5a733e1f0a594d">a594d</a></td>
  </tr>
  <tr>
      <td><code>DocumentDBManager.databaseAccounts</code></td>
      <td><code>CosmosDBManager.databaseAccounts</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/commit/a28b18c59f463f88e6d8322e2a5a733e1f0a594d">a594d</a></td>
  </tr>
</table>

