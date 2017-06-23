# Prepare for Azure Management Libraries for .NET 1.1 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.0 to 1.1 …

> If this note missed any breaking changes, please open a pull request.

V1.1 is backwards compatible with V1.0 in the APIs intended for public use that reached the general availability (stable) stage in V1.0. 

Some breaking changes were introduced in APIs that were still in Beta in V1.0, as inherited from the `IBeta` interface.

## GA'd APIs in V1.1

Some of the APIs that were still in Beta in V1.0 are now GA in V1.1, in particular:
- async methods
- all methods in CDN that were previously in Beta
- all methods and interfaces in Application Gateways that were previously in Beta


## Naming Changes ##

<table>
  <tr>
    <th align=left>Area</th>
    <th align=left>From</th>
    <th align=left>To</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
      <td>Graph RBAC</td>
      <td><code>IUser</code></td>
      <td><code>IActiveDirectoryUser</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3316">#3316</a></td>
  </tr>
  <tr>
      <td>Graph RBAC</td>
      <td><code>IUsers</code></td>
      <td><code>IActiveDirectoryUsers</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3316">#3316</a></td>
  </tr>
  <tr>
      <td>Graph RBAC</td>
      <td><code>GraphRbacManager.Users()</code></td>
      <td><code>GraphRbacManager.ActiveDirectoryUsers()</code></td>
      <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3316">#3316</a></td>
  </tr>
</table>



## Changes in Return or Input Parameter Types ##

<table>
  <tr>
    <th align=left>Area</th>
    <th align=left>Method</th>
    <th align=left>From</th>
    <th align=left>To</th>
    <th align=left>Ref</th>
  </tr>
  <tr>
    <td>Networking</td>
    <td><code>ApplicationGatewayBackend.Addresses()</code></td>
    <td><code>IList&lt;&gt;</code></td>
    <td><code>IReadOnlyCollection&lt;&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3287">#3287</a></td>
  </tr>
  <tr>
    <td>Networking</td>
    <td><code>ApplicationGatewayRequestRoutingRule.BackendAddresses()</code></td>
    <td><code>IReadOnlyList&lt;&gt;</code></td>
    <td><code>IReadOnlyCollection&lt;&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3287">#3287</a></td>
  </tr>

  <tr>
    <td>CDN</td>
    <td><code>CdnEndpoint.ContentTypesToCompress</code></td>
    <td><code>List&lt;String&gt;</code></td>
    <td><code>Set&lt;String&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3281">#3281</a></td>
  </tr>
  <tr>
    <td>CDN</td>
    <td><code>CdnEndpoint.withContentTypesToCompress()</code></td>
    <td><code>IReadOnlyList&lt;String&gt;</code></td>
    <td><code>ISet&lt;String&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3281">#3281</a></td>
  </tr>
  <tr>
    <td>CDN</td>
    <td><code>CdnEndpoint.CustomDomains</code></td>
    <td><code>IReadOnlyList&lt;String&gt;</code></td>
    <td><code>ISet&lt;String&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3281">#3281</a></td>
  </tr>
  <tr>
    <td>CDN</td>
    <td><code>CdnEndpoint.PurgeContent() /  .PurgeContentAsync()</code></td>
    <td><code>IList&lt;String&gt;</code></td>
    <td><code>ISet&lt;String&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3281">#3281</a></td>
  </tr>
  <tr>
    <td>CDN</td>
    <td><code>CdnEndpoint.LoadContent() / .LoadContentAsync()</code></td>
    <td><code>IList&lt;String&gt;</code></td>
    <td><code>ISet&lt;String&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3281">#3281</a></td>
  </tr>
  <tr>
    <td>CDN</td>
    <td><code>CdnEndpoint.WithGeoFilters()</code></td>
    <td><code>IList&lt;&gt;</code></td>
    <td><code>ICollection&lt;&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3281">#3281</a></td>
  </tr>
  <tr>
    <td>CDN</td>
    <td><code>CdnEndpoint.WithGeoFilter()</code></td>
    <td><code>IList&lt;&gt;</code></td>
    <td><code>ICollection&lt;&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3281">#3281</a></td>
  </tr>
  <tr>
    <td>CDN</td>
    <td><code>CdnProfile.PurgeEndpointContent() / .PurgeEndpointContentAsync()</code></td>
    <td><code>IList&lt;String&gt;</code></td>
    <td><code>ISet&lt;String&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3281">#3281</a></td>
  </tr>
  <tr>
    <td>CDN</td>
    <td><code>CdnProfile.LoadEndpointContent() / .LoadEndpointContentAsync()</code></td>
    <td><code>IList&lt;String&gt;</code></td>
    <td><code>ISet&lt;String&gt;</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3281">#3281</a></td>
  </tr>
  <tr>
    <td>KeyVault</td>
    <td><code>Vault.DefineAccessPolicy().ForUser()</code></td>
    <td><code>IUser</code></td>
    <td><code>IActiveDirectoryUser</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3316">#3316</a></td>
  </tr>
</table>


## API Removals ##

<table>
  <tr>
    <th>Removed</th>
    <th>Alternate to switch to</th>
    <th>PR</th>
  </tr>
  <tr>
    <td><code>ApplicationGateway.SslPolicy()</code></td>
    <td><code>ApplicationGateway.DisabledSslProtocols()</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3287">#3287</a></td>
  </tr>
  <tr>
    <td><code>RuntimeStack.NodeJS_6_9_3</code></td>
    <td><code>RuntimeStack.NodeJS_6_9</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3326">#3326</a></td>
  </tr>
  <tr>
    <td><code>RuntimeStack.NodeJS_6_6_0</code></td>
    <td><code>RuntimeStack.NodeJS_6_6</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3326">#3326</a></td>
  </tr>
  <tr>
    <td><code>RuntimeStack.NodeJS_6_2_2</code></td>
    <td><code>RuntimeStack.NodeJS_6_2</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3326">#3326</a></td>
  </tr>
  <tr>
    <td><code>RuntimeStack.NodeJS_4_5_0</code></td>
    <td><code>RuntimeStack.NodeJS_4_5</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3326">#3326</a></td>
  </tr>
  <tr>
    <td><code>RuntimeStack.NodeJS_4_4_7</code></td>
    <td><code>RuntimeStack.NodeJS_4_4</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3326">#3326</a></td>
  </tr>
  <tr>
    <td><code>RuntimeStack.PHP_5_6_23</code></td>
    <td><code>RuntimeStack.PHP_5_6</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3326">#3326</a></td>
  </tr>
  <tr>
    <td><code>RuntimeStack.PHP_7_0_6</code></td>
    <td><code>RuntimeStack.PHP_7_0</code></td>
    <td><a href="https://github.com/Azure/azure-sdk-for-net/pull/3326">#3326</a></td>
  </tr>
</table>

