# Prepare for Azure Management Libraries for NET 1.0.0-beta4#

Steps to migrate code that uses Azure Management Libraries for NET from beta 3 to beta 4 …

> If this note missed any breaking changes, please open a pull request.

# Change Property and Method Names #

<table>
  <tr>
    <th>From</th>
    <th>To</th>
    <th>Ref</th>
  </tr>
    <tr>
    <td><code>LoadBalancer.Frontend</code></td>
    <td><code>LoadBalancer.LoadBalancerFrontend</code></td>
  </tr>
  <tr>
    <td><code>LoadBalancer.Probe</code></td>
    <td><code>LoadBalancer.LoadBalancerProbe</code></td>
  </tr>
  <tr>
    <td><code>LoadBalancer.TcpProbe</code></td>
    <td><code>LoadBalancer.LoadBalancerTcpProbe</code></td>
  </tr>
  <tr>
    <td><code>LoadBalancer.HttpProbe</code></td>
    <td><code>LoadBalancer.LoadBalancerHttpProbe</code></td>
  </tr>
  <tr>
    <td><code>LoadBalancer.Backend</code></td>
    <td><code>LoadBalancer.LoadBalancerBackend</code></td>
  </tr>
    <tr>
    <td><code>VirtualMachine.DisableVmAgent()</code></td>
    <td><code>VirtualMachine.WithoutVmAgent()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.DisableAutoUpdate()</code></td>
    <td><code>VirtualMachine.WithoutAutoUpdate()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithRootUserName()</code></td>
    <td><code>VirtualMachine.WithRootUsername()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithAdminUserName()</code></td>
    <td><code>VirtualMachine.WithAdminUsername()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachine.WithPassword()</code></td>
    <td><code>VirtualMachine.WithRootPassword()</code></td>
  </tr>
    <tr>
    <td><code>VirtualMachine.WithPassword()</code></td>
    <td><code>VirtualMachine.WithAdminPassword()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithPrimaryInternetFacingLoadBalancer()</code></td>
    <td><code>VirtualMachineScaleSet.WithExistingPrimaryInternetFacingLoadBalancer()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithPrimaryInternalLoadBalancer()</code></td>
    <td><code>VirtualMachineScaleSet.WithExistingPrimaryInternalLoadBalancer()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithAdminUserName()</code></td>
    <td><code>VirtualMachineScaleSet.WithAdminUsername()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithRootUserName()</code></td>
    <td><code>VirtualMachineScaleSet.WithRootUsername()</code></td>
  </tr>
  <tr>
    <td><code>VirtualMachineScaleSet.WithPassword()</code></td>
    <td>
    Windows:
    <br/>
    <code>VirtualMachineScaleSet.WithAdminPassword()</code>
    <br/>
    Linux:
    <br/>
    <code>VirtualMachineScaleSet.WithRootPassword()</code><br/>
    </td>
  </tr>
  <tr>
    <td><code>LoadBalancer.WithExistingSubnet()</code></td>
    <td><code>LoadBalancer.WithFrontendSubnet()</code></td>
  </tr>

  <tr>
    <td><code>ResourceGroups.Delete(String id)</code></td>
    <td><code>ResourceGroups().DeleteByName(String name)</code></td>
  </tr>
  <tr>
    <td>
      <code>{ResourceCollection}.Delete(String id)</code>
      <br/>
      e.g.
      <br/>
      <code>VirtualMachines.Delete(String id)</code>
      <br/>
      <code>Networks.Delete(String id)</code>
      <br/>
      <code>StorageAccounts.Delete(String id)</code>
      <br/>
      ...
    </td>
    <td>
      <code>{ResourceCollection}.DeleteById(String id)</code>
      <br/>
      <br/>
      <code>VirtualMachines.DeleteById(String id)</code>
      <br/>
      <code>Networks.DeleteById(String id)</code>
      <br/>
      <code>StorageAccounts.DeleteById(String id)</code>
      <br/>
      <br/>
    </td>
  </tr>
  <tr>
    <td><code>{ResourceCollection}.Delete(String groupName, String name)</code>
      <br/>
      e.g.
      <br/>
      <code>VirtualMachines.Delete(String groupName, String name)</code>
      <br/>
      <code>Networks.Delete(String groupName, String name)</code>
      <br/>
      <code>StorageAccounts.Delete(String groupName, String name)</code>
      <br/>
      ...
      </td>
    <td><code>{ResourceCollection}.DeleteByGroup(String groupName, String name)</code>
      <br/>
      <br/>
      <code>VirtualMachines.DeleteByGroup(String groupName, String name)</code>
      <br/>
      <code>Networks.DeleteByGroup(String groupName, String name)</code>
      <br/>
      <code>StorageAccounts.DeleteByGroup(String groupName, String name)</code>
      <br/>
      <br/>
    </td>
  </tr>
</table>

# Change interface Names #

<table>
  <tr>
    <th>From</th>
    <th>To</th>
    <th>Ref</th>
  </tr>
   <tr>
    <td><code>cVirtualMachine.Definition.IWithWindowsAdminUserName</code></td>
    <td><code>VirtualMachine.Definition.IWithWindowsAdminUsername</code></td>
  </tr>
   <tr>
    <td><code>VirtualMachine.Definition.IWithLinuxRootUserName</code></td>
    <td><code>VirtualMachine.Definition.IWithLinuxRootUsername</code></td>
  </tr>
   <tr>
    <td><code>VirtualMachine.Definition.IWithPassword</code></td>
    <td>
    Windows:
    <br/>
    <code>VirtualMachine.Definition.IWithWindowsAdminPassword</code>
    <br/>
    Linux:
    <br/>
    <code>VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKey</code>
    </td>
  </tr>
  <tr>
    <td><code>Network.Fluent.IHttpProbe</code></td>
    <td><code>Network.Fluent.ILoadBalancerHttpProbe</code></td>
  </tr>
  <tr>
    <td><code>Network.Fluent.ITcpProbe</code></td>
    <td><code>Network.Fluent.ILoadBalancerTcpProbe</code></td>
  </tr>
  <tr>
    <td><code>Network.Fluent.IProbe</code></td>
    <td><code>Network.Fluent.ILoadBalancerProbe</code></td>
  </tr>
  <tr>
    <td><code>Network.Fluent.IPrivateFrontend</code></td>
    <td><code>Network.Fluent.ILoadBalancerPrivateFrontend</code></td>
  </tr>
  <tr>
    <td><code>Network.Fluent.IPublicFrontend</code></td>
    <td><code>Network.Fluent.ILoadBalancerPublicFrontend</code></td>
  </tr>
  <tr>
    <td><code>Network.Fluent.IInboundNatRule</code></td>
    <td><code>Network.Fluent.ILoadBalancerInboundNatRule</code></td>
  </tr>
  <tr>
    <td><code>Network.Fluent.IInboundNatPool</code></td>
    <td><code>Network.Fluent.ILoadBalancerInboundNatPool</code></td>
  </tr>
</table>
