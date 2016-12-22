[![Build Status](https://travis-ci.org/Azure/azure-sdk-for-net.svg?style=flat-square&label=build)](https://travis-ci.org/Azure/azure-sdk-for-net)

#Azure Management Libraries for .NET

This README is based on the latest released preview version (1.0.0-beta4). If you are looking for other releases, see [More Information](#more-information)

The Azure Management Libraries for .NET is a higher-level, object-oriented API for managing Azure resources. Libraries are built on the lower-level, request-response style [auto generated clients](https://github.com/Azure/azure-sdk-for-net/tree/AutoRest) and can run side-by-side with [auto generated clients](https://github.com/Azure/azure-sdk-for-net/tree/AutoRest).

**1.0.0-beta4** is a developer preview that supports major parts of: 

- Azure Virtual Machines and VM Extensions
- Virtual Machine Scale Sets
- Storage
- Networking (virtual networks, subnets, network interfaces, IP addresses, network security groups, load balancers, DNS, traffic managers and application gateways)
- Resource Manager
- SQL Database (databases, firewalls and elastic pools)
- App Service (Web Apps)
- Key Vault, Redis, CDN and Batch.

The next preview version of the Azure Management Libraries for .NET is a work in-progress. We will be adding support for more Azure services and tweaking the API over the next few months.

**Azure Authentication**

The `Azure` class is the simplest entry point for creating and interacting with Azure resources.

```csharp
Azure azure = Azure.Authenticate(credFile).WithDefaultSubscription();
``` 

**Create a Virtual Machine**

You can create a virtual machine instance by using a `Define() … Create()` method chain.

```csharp
Console.WriteLine("Creating a Windows VM");

var windowsVM = azure.VirtualMachines.Define("myWindowsVM")
    .WithRegion(Region.US_EAST)
    .WithNewResourceGroup(rgName)
    .WithNewPrimaryNetwork("10.0.0.0/28")
    .WithPrimaryPrivateIpAddressDynamic()
    .WithNewPrimaryPublicIpAddress("mywindowsvmdns")
    .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_R2_DATACENTER)
    .WithAdminUserName("tirekicker")
    .WithPassword(password)
    .WithSize(VirtualMachineSizeTypes.StandardD3V2)
    .Create();
	
Console.WriteLine("Created a Windows VM: " + windowsVM.Id);
```

**Update a Virtual Machine**

You can update a virtual machine instance by using an `Update() … Apply()` method chain.

```csharp
windowsVM.Update()
	.WithNewDataDisk(10)
	.DefineNewDataDisk(dataDiskName)
	    .WithSizeInGB(20)
	    .WithCaching(CachingTypes.ReadWrite)
	    .Attach()
	.Apply();
```
**Create a Virtual Machine Scale Set**

You can create a virtual machine scale set instance by using another `Define() … Create()` method chain.

```csharp
var virtualMachineScaleSet = azure.VirtualMachineScaleSets
	.Define(vmssName)
	.WithRegion(Region.US_EAST)
	.WithExistingResourceGroup(rgName)
	.WithSku(VirtualMachineScaleSetSkuTypes.STANDARD_D3_V2)
	.WithExistingPrimaryNetworkSubnet(network, "Front-end")
	.WithPrimaryInternetFacingLoadBalancer(loadBalancer1)
	.WithPrimaryInternetFacingLoadBalancerBackends(backendPoolName1, backendPoolName2)
	.WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPool50XXto22, natPool60XXto23)
	.WithoutPrimaryInternalLoadBalancer()
	.WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
	.WithRootUserName(userName)
	.WithSsh(sshKey)
	.WithNewStorageAccount(storageAccountName1)
	.WithNewStorageAccount(storageAccountName2)
	.WithNewStorageAccount(storageAccountName3)
	.WithCapacity(3)
	.Create();
```

**Create a Network Security Group**

You can create a network security group instance by using another `Define() … Create()` method chain.

```csharp
var frontEndNSG = azure.NetworkSecurityGroups.Define(frontEndNSGName)
	.WithRegion(Region.US_EAST)
	.WithNewResourceGroup(rgName)
	.DefineRule("ALLOW-SSH")
	    .AllowInbound()
	    .FromAnyAddress()
	    .FromAnyPort()
	    .ToAnyAddress()
	    .ToPort(22)
	    .WithProtocol(SecurityRuleProtocol.Tcp)
	    .WithPriority(100)
	    .WithDescription("Allow SSH")
	    .Attach()
	.DefineRule("ALLOW-HTTP")
	    .AllowInbound()
	    .FromAnyAddress()
	    .FromAnyPort()
	    .ToAnyAddress()
	    .ToPort(80)
	    .WithProtocol(SecurityRuleProtocol.Tcp)
	    .WithPriority(101)
	    .WithDescription("Allow HTTP")
	    .Attach()
	.Create();
```

**Create an Application Gateway**

You can create a application gateway instance by using another `define() … create()` method chain.

```csharp
var applicationGateway = azure.ApplicationGateways().Define("myFirstAppGateway")
    .WithRegion(Region.US_EAST)
    .WithExistingResourceGroup(resourceGroup)
    // Request routing rule for HTTP from public 80 to public 8080
    .DefineRequestRoutingRule("HTTP-80-to-8080")
        .FromPublicFrontend()
        .FromFrontendHttpPort(80)
        .ToBackendHttpPort(8080)
        .ToBackendIpAddress("11.1.1.1")
        .ToBackendIpAddress("11.1.1.2")
        .ToBackendIpAddress("11.1.1.3")
        .ToBackendIpAddress("11.1.1.4")
        .Attach()
    .WithExistingPublicIpAddress(publicIpAddress)
    .Create();
```

**Create a Web App**

You can create a Web App instance by using another `define() … create()` method chain.

```csharp
var webApp = azure.WebApps()
    .Define(appName)
    .WithNewResourceGroup(rgName)
    .WithNewAppServicePlan(planName)
    .WithRegion(Region.US_WEST)
    .WithPricingTier(AppServicePricingTier.STANDARD_S1)
    .Create();
```

**Create a SQL Database**

You can create a SQL server instance by using another `define() … create()` method chain.

```csharp
var sqlServer = azure.SqlServers.Define(sqlServerName)
    .WithRegion(Region.US_EAST)
    .WithNewResourceGroup(rgName)
    .WithAdministratorLogin(administratorLogin)
    .WithAdministratorPassword(administratorPassword)
    .WithNewFirewallRule(firewallRuleIpAddress)
    .WithNewFirewallRule(firewallRuleStartIpAddress, firewallRuleEndIpAddress)
    .Create();
```

Then, you can create a SQL database instance by using another `define() … create()` method chain.

```csharp
var database = sqlServer.Databases.Define(databaseName)
    .WithoutElasticPool()
    .WithoutSourceDatabaseId()
    .WithEdition(DatabaseEditions.Basic)
    .Create();
```

#Sample Code

You can find plenty of sample code that illustrates management scenarios in Azure Virtual Machines, Virtual Machine Scale Sets, Storage, Networking, Resource Manager, SQL Database, App Service (Web Apps), Key Vault, Redis, CDN and Batch … 

<table>
  <tr>
    <th>Service</th>
    <th>Management Scenario</th>
  </tr>
  <tr>
    <td>Virtual Machines</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-vm">Manage virtual machine</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-availability-sets"> Manage availability set</li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-list-vm-images">List virtual machine images</li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-using-vm-extensions">Manage virtual machines using VM extensions</li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-create-virtual-machines-from-generalized-image-or-specialized-vhd">Create virtual machines from generalized image or specialized VHD</li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-list-vm-extension-images">List virtual machine extension images</li>
</ul>
</td>
  </tr>
  <tr>
    <td>Virtual Machines - parallel execution</td>
    <td><ul style="list-style-type:circle">
<li><a href="http://github.com/azure-samples/compute-dotnet-manage-virtual-machines-in-parallel">Create multiple virtual machines in parallel</li>
<li><a href="http://github.com/azure-samples/compute-dotnet-manage-virtual-machines-with-network-in-parallel">Create multiple virtual machines with network in parallel</li>
<li><a href="http://github.com/azure-samples/compute-dotnet-create-virtual-machines-across-regions-in-parallel">Create multiple virtual machines across regions in parallel</li>
</ul></td>
  </tr>
  <tr>
    <td>Virtual Machine Scale Sets</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-scale-sets">Manage virtual machine scale sets (behind an Internet facing load balancer)</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Storage</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/storage-dotnet-manage-storage-accounts">Manage storage accounts</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Networking</td>
    <td><ul style="list-style-type:circle">

<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-virtual-network">Manage virtual network</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-network-interface">Manage network interface</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-network-security-group">Manage network security group</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-ip-address">Manage IP address</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-internet-facing-load-balancers">Manage Internet facing load balancers</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-internal-load-balancers">Manage internal load balancers</a></li>
</ul>
</td>
  </tr>

  <tr>
    <td>Networking - DNS</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/dns-dotnet-host-and-manage-your-domains">Hosting and managing domains</a></li>
</ul></td>
  </tr>

  <tr>
    <td>Traffic Manager</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/traffic-manager-dotnet-manage-profiles">Manage traffic manager profiles</a></li>
</ul></td>
  </tr>

  <tr>
    <td>Application Gateway</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/application-gateway-dotnet-manage-simple-application-gateways">Manage application gateways</a></li>
<li><a href="https://github.com/Azure-Samples/application-gateway-dotnet-manage-application-gateways">Manage application gateways with backend pools</a></li>
</ul></td>
  </tr>

  <tr>
    <td>SQL Database</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-db">Manage SQL databases</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-sql-dbs-in-elastic-pool">Manage SQL databases in elastic pools</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-firewalls-for-sql-databases">Manage firewalls for SQL databases</a></li>
<li><a href="https://github.com/Azure-Samples/sql-database-dotnet-manage-sql-databases-across-regions">Manage SQL databases across regions</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Redis Cache</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/redis-cache-dotnet-manage-cache">Manage Redis Cache</a></li>
</ul></td>
</tr>

  <tr>
    <td>App Service - Web Apps</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-web-apps">Manage Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-web-apps-with-custom-domains">Manage Web apps with custom domains</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-configure-deployment-sources-for-web-apps">Configure deployment sources for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-staging-and-production-slots-for-web-apps">Manage staging and production slots for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-scale-web-apps">Scale Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-storage-connections-for-web-apps">Manage storage connections for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-data-connections-for-web-apps">Manage data connections (such as SQL database and Redis cache) for Web apps</a></li>
</ul></td>
  </tr>

  <tr>
    <td>Resource Groups</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/resources-dotnet-manage-resource-group">Manage resource groups</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-manage-resource">Manage resources</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-deploy-using-arm-template">Deploy resources with ARM templates</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-deploy-using-arm-template-with-progress">Deploy resources with ARM templates (with progress)</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Key Vault</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/key-vault-dotnet-manage-key-vaults">Manage key vaults</a></li>
</ul></td>
  </tr>
  <tr>
    <td>CDN</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/cdn-dotnet-manage-cdn">Manage CDNs</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Batch</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/batch-dotnet-manage-batch-accounts">Manage batch accounts</a></li>
</ul></td>
  </tr>
</table>




# Download


**1.0.0-beta4**

1.0.0-beta4 release builds are available on NuGet:

Azure Management Library                              | Package name                              | Stable (`1.0.0-beta4` release)
-----------------------|-------------------------------------------|-----------------------------|-------------------------
Azure Management Client (wrapper package) | `Microsoft.Azure.Management.Fluent` | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Fluent/)
App Service (Web Apps) | `Microsoft.Azure.Management.AppService.Fluent` | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.AppService.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.AppService.Fluent/)
Batch | `Microsoft.Azure.Management.Batch.Fluent` | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Batch.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Batch.Fluent/)
CDN | `Microsoft.Azure.Management.Cdn.Fluent` | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Cdn.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Cdn.Fluent/)
Virtual Machines & Virtual Machine Scale Sets | `Microsoft.Azure.Management.Compute.Fluent`    | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Compute.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Compute.Fluent/)
DNS | `Microsoft.Azure.Management.Dns.Fluent` | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Dns.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Dns.Fluent/)
Key Vault |`Microsoft.Azure.Management.KeyVault.Fluent`  | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.KeyVault.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.KeyVault.Fluent/)
Networking  |`Microsoft.Azure.Management.Network.Fluent`  | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Network.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Network.Fluent/)
Redis Cache  |`Microsoft.Azure.Management.Redis.Fluent`  | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Redis.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Redis.Fluent/)
Resource Manager  |`Microsoft.Azure.Management.ResourceManager.Fluent`  | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.ResourceManager.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.ResourceManager.Fluent/)
SQL Database  |`Microsoft.Azure.Management.Sql.Fluent`  | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Sql.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Sql.Fluent/)
Storage  |`Microsoft.Azure.Management.Storage.Fluent`  | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Storage.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Storage.Fluent/)
Traffic Manager  |`Microsoft.Azure.Management.TrafficManager.Fluent`  | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.TrafficManager.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.TrafficManager.Fluent/)

#Pre-requisites

- [.NET Core](https://www.microsoft.com/net/core) 
- Azure Service Principal - see [how to create authentication info](./AUTH.md).

# Help

If you are migrating your code to 1.0.0-beta4, you can use these notes for [preparing your code for 1.0.0-beta4 from 1.0.0-beta3](./notes/prepare-for-1.0.0-beta4.md).

If you encounter any bugs with these libraries, please file issues via [Issues](https://github.com/Azure/azure-sdk-for-net/issues) and tag them [Fluent](https://github.com/Azure/azure-sdk-for-net/labels/Fluent) or checkout [StackOverflow for Azure Management Libraries for .NET](http://stackoverflow.com/questions/tagged/azure-sdk).

#Contribute Code

If you would like to become an active contributor to this project please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](http://azure.github.io/guidelines.html).

1. Fork it
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create new Pull Request

#More Information
* [https://azure.microsoft.com/en-us/develop/net/](https://azure.microsoft.com/en-us/develop/net/)
* If you don't have a Microsoft Azure subscription you can get a FREE trial account [here](http://go.microsoft.com/fwlink/?LinkId=330212).

**Previous Releases and Corresponding Repo Branches**

| Version           | SHA1                                                                                      | Remarks                                               |
|-------------------|-------------------------------------------------------------------------------------------|-------------------------------------------------------|
| 1.0.0-beta3       | [1.0.0-beta3](https://github.com/Azure/azure-net-for-net/tree/1.0.0-beta3)               | Tagged release for 1.0.0-beta3 version of Azure management libraries |
| AutoRest       | [AutoRest](https://github.com/selvasingh/azure-sdk-for-net/tree/AutoRest)               | Main branch for AutoRest generated raw clients |

---

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
