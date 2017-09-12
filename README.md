
# Azure Management Libraries for .NET #

This README is based on the released stable version (1.2). If you are looking for other releases, see [More Information](#more-information)

The Azure Management Libraries for .NET is a higher-level, object-oriented API for managing Azure resources. Libraries are built on the lower-level, request-response style [auto generated clients](https://github.com/Azure/azure-sdk-for-net/tree/AutoRest) and can run side-by-side with [auto generated clients](https://github.com/Azure/azure-sdk-for-net/tree/AutoRest).

## Feature Availability and Road Map as of Version 1.2 ##

<table>
  <tr>
    <th align="left">Service | feature</th>
    <th align="left">Available as GA</th>
    <th align="left">Available as Preview</th>
    <th align="left">Coming soon</th>
  </tr>
  <tr>
    <td>Compute</td>
    <td>Virtual machines and VM extensions<br>Virtual machine scale sets<br>Managed disks</td>
    <td valign="top">Azure container service and registry</td>
    <td valign="top">More Azure container registry features</td>
  </tr>
  <tr>
    <td>Storage</td>
    <td>Storage accounts</td>
    <td>Encryption</td>
    <td></td>
  </tr>
  <tr>
    <td>SQL Database</td>
    <td>Databases<br>Firewalls<br>Elastic pools</td>
    <td></td>
    <td valign="top">More features</td>
  </tr>
  <tr>
    <td>Networking</td>
    <td>Virtual networks<br>Network interfaces<br>IP addresses<br>Routing table<br>Network security groups<br>Application gateways<br>DNS<br>Traffic managers</td>
    <td valign="top">Load balancers<br>Network watchers</td>
    <td valign="top">VPN<br>More application gateway features</td>
  </tr>
  <tr>
    <td>More services</td>
    <td>Resource Manager<br>Key Vault<br>Redis<br>CDN<br>Batch</td>
    <td valign="top">Web apps<br>Function Apps<br>Service bus<br>Graph RBAC<br>Cosmos DB<br>Search</td>
    <td valign="top">Monitor<br>Azure container instances<br>Data Lake</td>
  </tr>
  <tr>
    <td>Fundamentals</td>
    <td>Authentication - core<br>Async methods<br>Managed Service Identity</td>
    <td></td>
    <td valign="top"></td>
  </tr>
</table>

> *Preview* features are flagged in documentation comments in libraries. These features are subject to change. They can be modified in any way, or even removed, in the future.

#### Azure Authentication

The `Azure` class is the simplest entry point for creating and interacting with Azure resources.

```csharp
IAzure azure = Azure.Authenticate(credFile).WithDefaultSubscription();
``` 

#### Create a Cosmos DB with DocumentDB Programming Model

You can create a Cosmos DB account by using a `define() … create()` method chain.

```csharp
var documentDBAccount = azure.DocumentDBAccounts.Define(docDBName)
    .WithRegion(Region.USEast)
    .WithNewResourceGroup(rgName)
    .WithKind(DatabaseAccountKind.GlobalDocumentDB)
    .WithSessionConsistency()
    .WithWriteReplication(Region.USWest)
    .WithReadReplication(Region.USCentral)
    .Create();
```

#### Create a Virtual Machine

You can create a virtual machine instance by using a `Define() … Create()` method chain.

```csharp
Console.WriteLine("Creating a Windows VM");

var windowsVM = azure.VirtualMachines.Define("myWindowsVM")
    .WithRegion(Region.USEast)
    .WithNewResourceGroup(rgName)
    .WithNewPrimaryNetwork("10.0.0.0/28")
    .WithPrimaryPrivateIPAddressDynamic()
    .WithNewPrimaryPublicIPAddress("mywindowsvmdns")
    .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
    .WithAdminUsername("tirekicker")
    .WithAdminPassword(password)
    .WithSize(VirtualMachineSizeTypes.StandardD3V2)
    .Create();
	
Console.WriteLine("Created a Windows VM: " + windowsVM.Id);
```

#### Update a Virtual Machine

You can update a virtual machine instance by using an `Update() … Apply()` method chain.

```csharp
windowsVM.Update()
    .WithNewDataDisk(20, lun, CachingTypes.ReadWrite)
    .Apply();
```
#### Create a Virtual Machine Scale Set

You can create a virtual machine scale set instance by using another `Define() … Create()` method chain.

```csharp
var virtualMachineScaleSet = azure.VirtualMachineScaleSets.Define(vmssName)
    .WithRegion(Region.USEast)
    .WithExistingResourceGroup(rgName)
    .WithSku(VirtualMachineScaleSetSkuTypes.StandardD3v2)
    .WithExistingPrimaryNetworkSubnet(network, "Front-end")
    .WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer1)
    .WithPrimaryInternetFacingLoadBalancerBackends(backendPoolName1, backendPoolName2)
    .WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPool50XXto22, natPool60XXto23)
    .WithoutPrimaryInternalLoadBalancer()
    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
    .WithRootUsername(userName)
    .WithSsh(sshKey)
    .WithNewDataDisk(100)
    .WithNewDataDisk(100, 1, CachingTypes.ReadWrite)
    .WithNewDataDisk(100, 2, CachingTypes.ReadWrite, StorageAccountTypes.StandardLRS)
    .WithCapacity(3)
    .Create();
```

#### Create a Network Security Group

You can create a network security group instance by using another `Define() … Create()` method chain.

```csharp
var frontEndNSG = azure.NetworkSecurityGroups.Define(frontEndNSGName)
    .WithRegion(Region.USEast)
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

#### Create an Application Gateway

You can create a application gateway instance by using another `define() … create()` method chain.

```csharp
var applicationGateway = azure.ApplicationGateways.Define("myFirstAppGateway")
    .WithRegion(Region.USEast)
    .WithExistingResourceGroup(resourceGroup)
    // Request routing rule for HTTP from public 80 to public 8080
    .DefineRequestRoutingRule("HTTP-80-to-8080")
        .FromPublicFrontend()
        .FromFrontendHttpPort(80)
        .ToBackendHttpPort(8080)
        .ToBackendIPAddress("11.1.1.1")
        .ToBackendIPAddress("11.1.1.2")
        .ToBackendIPAddress("11.1.1.3")
        .ToBackendIPAddress("11.1.1.4")
        .Attach()
    .WithExistingPublicIPAddress(publicIpAddress)
    .Create();
```

#### Create a Web App

You can create a Web App instance by using another `define() … create()` method chain.

```csharp
var webApp = azure.WebApps.Define(appName)
    .WithRegion(Region.USWest)
    .WithNewResourceGroup(rgName)
    .WithNewFreeAppServicePlan()
    .Create();
```

#### Create a SQL Database

You can create a SQL server instance by using another `define() … create()` method chain.

```csharp
var sqlServer = azure.SqlServers.Define(sqlServerName)
    .WithRegion(Region.USEast)
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
    .Create();
```

# Sample Code #

You can find plenty of sample code that illustrates management scenarios (80+ end-to-end scenarios) for Azure Virtual Machines, Virtual Machine Scale Sets, Managed Disks, Active Directory Azure Container Service and Registry, Storage, Networking, Resource Manager, SQL Database, Cosmos DB, App Service (Web Apps on Windows and Linux), Functions, Service Bus, Key Vault, Redis, CDN and Batch … 

<table>
  <tr>
    <th>Service</th>
    <th>Management Scenario</th>
  </tr>
  <tr>
    <td>Virtual Machines</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-vm">Manage virtual machines</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-vm-async">Manage virtual machines asynchronously</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-availability-sets"> Manage availability set</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-list-vm-images">List virtual machine images</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-using-vm-extensions">Manage virtual machines using VM extensions</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-list-vm-extension-images">List virtual machine extension images</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-create-virtual-machines-from-generalized-image-or-specialized-vhd">Create virtual machines from generalized image or specialized VHD</a></li>
<li><a href="https://github.com/Azure-Samples/managed-disk-dotnet-create-virtual-machine-using-custom-image">Create virtual machine using custom image from virtual machine</a></li>
<li><a href="https://github.com/Azure-Samples/managed-disk-dotnet-create-virtual-machine-using-custom-image-from-VHD">Create virtual machine using custom image from VHD</a></li>
<li><a href="https://github.com/Azure-Samples/managed-disk-dotnet-create-virtual-machine-using-specialized-disk-from-VHD">Create virtual machine by importing a specialized operating system disk VHD</a></li>
<li><a href="https://github.com/Azure-Samples/managed-disk-dotnet-create-virtual-machine-using-specialized-disk-from-snapshot">Create virtual machine using specialized VHD from snapshot</a></li>
<li><a href="https://github.com/Azure-Samples/managed-disk-dotnet-convert-existing-virtual-machines-to-use-managed-disks">Convert virtual machines to use managed disks</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-with-unmanaged-disks">Manage virtual machine with unmanaged disks</a></li>
<li><a href="https://github.com/Azure-Samples/aad-dotnet-manage-resources-from-vm-with-msi">Manage Azure resources from a virtual machine with managed service identity (MSI)</a></li></ul></td>
</ul>
</td>
  </tr>
  <tr>
    <td>Virtual Machines - parallel execution</td>
    <td><ul style="list-style-type:circle">
<li><a href="http://github.com/azure-samples/compute-dotnet-manage-virtual-machines-in-parallel">Create multiple virtual machines in parallel</a></li>
<li><a href="http://github.com/azure-samples/compute-dotnet-manage-virtual-machines-with-network-in-parallel">Create multiple virtual machines with network in parallel</a></li>
<li><a href="http://github.com/azure-samples/compute-dotnet-create-virtual-machines-across-regions-in-parallel">Create multiple virtual machines across regions in parallel</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Virtual Machine Scale Sets</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-scale-sets">Manage virtual machine scale sets (behind an Internet facing load balancer)</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-scale-sets-async">Manage virtual machine scale sets (behind an Internet facing load balancer) asynchronously</a></li>
<li><a href="https://github.com/Azure-Samples/compute-dotnet-manage-virtual-machine-scale-set-with-unmanaged-disks">Manage virtual machine scale sets with unmanaged disks</a></li>
</ul></td>
  </tr>
<tr>
    <td>Active Directory</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/aad-dotnet-manage-service-principals">Manage service principals using Java</a></li>
<li><a href="https://github.com/Azure-Samples/aad-dotnet-manage-users-groups-and-roles">Manage users and groups and manage their roles</a></li>
<li><a href="https://github.com/Azure-Samples/aad-dotnet-manage-passwords">Manage passwords</li>
</ul></td>
  </tr>
<tr>
    <td>Container Service and Container Registry</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/acr-dotnet-manage-azure-container-registry">Manage container registry</a></li>
<!-- <li><a href="https://github.com/Azure-Samples/acs-dotnet-deploy-image-from-acr-to-kubernetes">Deploy an image from container registry to Kubernetes cluster</a></li>
<li><a href="https://github.com/Azure-Samples/acs-dotnet-deploy-image-from-acr-to-swarm">Deploy an image from container registry to Swarm cluster</li>
<li><a href="https://github.com/Azure-Samples/acs-dotnet-deploy-image-from-docker-hub-to-kubernetes">Deploy an image from Docker hub to Kubernetes cluster</a></li>
<li><a href="https://github.com/Azure-Samples/acs-dotnet-deploy-image-from-docker-hub-to-swarm">Deploy an image from Docker hub to Swarm cluster</li> -->
<li><a href="https://github.com/Azure-Samples/acs-dotnet-manage-azure-container-service">Manage container service</li>
</ul></td>
  </tr>
  <tr>
    <td>Storage</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/storage-dotnet-manage-storage-accounts">Manage storage accounts</a></li>
<li><a href="https://github.com/Azure-Samples/storage-dotnet-manage-storage-accounts-async">Manage storage accounts asynchronously</a></li>
</ul></td>
  </tr>
  <tr>
    <td>Networking</td>
    <td><ul style="list-style-type:circle">

<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-virtual-network">Manage virtual network</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-virtual-network-async">Manage virtual network asynchronously</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-network-interface">Manage network interface</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-network-security-group">Manage network security group</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-ip-address">Manage IP address</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-internet-facing-load-balancers">Manage Internet facing load balancers</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-manage-internal-load-balancers">Manage internal load balancers</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-use-new-watcher">Use net watcher</a></li>
<li><a href="https://github.com/Azure-Samples/network-dotnet-create-simple-internet-facing-load-balancer">Create simple Internet facing load balancer</a></li>
</ul>
</td>
  </tr>

  <tr>
    <td>Networking - DNS</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/dns-dotnet-host-and-manage-your-domains">Host and manage domains</a></li>
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
    <td>App Service - Web Apps on <b>Windows</b></td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-web-apps">Manage Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-web-apps-with-custom-domains">Manage Web apps with custom domains</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-configure-deployment-sources-for-web-apps">Configure deployment sources for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-configure-deployment-sources-for-web-apps-async">Configure deployment sources for Web apps asynchronously</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-staging-and-production-slots-for-web-apps">Manage staging and production slots for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-scale-web-apps">Scale Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-storage-connections-for-web-apps">Manage storage connections for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-data-connections-for-web-apps">Manage data connections (such as SQL database and Redis cache) for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-authentication-for-web-apps">Manage authentication for Web apps</a></li>
</ul></td>
  </tr>

  <tr>
    <td>App Service - Web Apps on <b>Linux</b></td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-web-apps-on-linux">Manage Web apps</a></li>
<!-- <li><a href="https://github.com/Azure-Samples/app-service-dotnet-deploy-image-from-acr-to-linux">Deploy a container image from Azure Container Registry to Linux containers</a></li> -->
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-web-apps-on-linux-with-custom-domains">Manage Web apps with custom domains</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-configure-deployment-sources-for-web-apps-on-linux">Configure deployment sources for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-scale-web-apps-on-linux">Scale Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-storage-connections-for-web-apps-on-linux">Manage storage connections for Web apps</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-data-connections-for-web-apps-on-linux">Manage data connections (such as SQL database and Redis cache) for Web apps</a></li>
</ul></td>
  </tr>
  
  <tr>
    <td>Functions</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-functions">Manage functions</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-functions-with-custom-domains">Manage functions with custom domains</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-configure-deployment-sources-for-functions">Configure deployment sources for functions</a></li>
<li><a href="https://github.com/Azure-Samples/app-service-dotnet-manage-authentication-for-functions">Manage authentication for functions</a></li>
</ul></td>
  </tr>

<tr>
    <td>Cosmos DB</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/cosmosdb-dotnet-create-documentdb-and-configure-for-high-availability">Create a DocumentDB and configure it for high availability</a></li>
<li><a href="https://github.com/Azure-Samples/cosmosdb-dotnet-create-documentdb-and-configure-for-eventual-consistency">Create a DocumentDB and configure it with eventual consistency</a></li>
<li><a href="https://github.com/Azure-Samples/cosmosdb-dotnet-create-documentdb-and-configure-firewall">Create a DocumentDB, configure it for high availability and create a firewall to limit access from an approved set of IP addresses</li>
<li><a href="https://github.com/Azure-Samples/cosmosdb-dotnet-create-documentdb-and-get-mongodb-connection-string">Create a DocumentDB and get MongoDB connection string</li>
</ul></td>
  </tr>

  <tr>
    <td>Service Bus</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/service-bus-dotnet-manage-queue-with-basic-features">Manage queues with basic features</a></li>
<li><a href="https://github.com/Azure-Samples/service-bus-dotnet-manage-publish-subscribe-with-basic-features">Manage publish-subscribe with basic features</a></li>
<li><a href="https://github.com/Azure-Samples/service-bus-dotnet-manage-with-claims-based-authorization">Manage queues and publish-subcribe with cliams based authorization</a></li>
<li><a href="https://github.com/Azure-Samples/service-bus-dotnet-manage-publish-subscribe-with-advanced-features">Manage publish-subscribe with advanced features - sessions, dead-lettering, de-duplication and auto-deletion of idle entries</a></li>
<li><a href="https://github.com/Azure-Samples/service-bus-dotnet-manage-queue-with-advanced-features">Manage queues with advanced features - sessions, dead-lettering, de-duplication and auto-deletion of idle entries</a></li>
</ul></td>
  </tr>

  <tr>
    <td>Resource Groups</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/resources-dotnet-manage-resource-group">Manage resource groups</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-manage-resource">Manage resources</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-deploy-using-arm-template">Deploy resources with ARM templates</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-deploy-using-arm-template-with-progress">Deploy resources with ARM templates (with progress)</a></li>
<li><a href="https://github.com/Azure-Samples/resources-dotnet-deploy-virtual-machine-with-managed-disks-using-arm-template">Deploy a virtual machine with managed disks using an ARM template</a></li>
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
  <tr>
    <td>Search</td>
    <td><ul style="list-style-type:circle">
<li><a href="https://github.com/Azure-Samples/search-dotnet-manage-search-service">Manage Azure search</a></li>
</ul></td>
  </tr>  
</table>




# Download #

**1.2** release builds are available on NuGet:

|Azure Management Library                     | Package name                                        | Stable (1.2 release) |
|---------------------------------------------|-----------------------------------------------------|------------------------|
|Azure Management Client (wrapper package)    | `Microsoft.Azure.Management.Fluent`                 | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Fluent/) |
|App Service (Web Apps and Functions)         | `Microsoft.Azure.Management.AppService.Fluent`      | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.AppService.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.AppService.Fluent/) |
|Batch                                        | `Microsoft.Azure.Management.Batch.Fluent`           | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Batch.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Batch.Fluent/) |
|CDN                                          | `Microsoft.Azure.Management.Cdn.Fluent`             | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Cdn.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Cdn.Fluent/) |
|Virtual Machines, Virtual Machine Scale Sets, Azure Container Services| `Microsoft.Azure.Management.Compute.Fluent`         | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Compute.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Compute.Fluent/) |
|Container Registry                           | `Microsoft.Azure.Management.ContainerRegistry.Fluent`| [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.ContainerRegistry.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.ContainerRegistry.Fluent/) |
|Cosmos DB                                    | `Microsoft.Azure.Management.CosmosDB.Fluent`        | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.CosmosDB.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.CosmosDB.Fluent/) |
|DNS                                          | `Microsoft.Azure.Management.Dns.Fluent`             | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Dns.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Dns.Fluent/) |
|Graph RBAC                                   | `Microsoft.Azure.Management.Graph.RBAC.Fluent`      | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Graph.RBAC.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Graph.RBAC.Fluent/) |
|Key Vault                                    | `Microsoft.Azure.Management.KeyVault.Fluent`        | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.KeyVault.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.KeyVault.Fluent/) |
|Networking                                   | `Microsoft.Azure.Management.Network.Fluent`         | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Network.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Network.Fluent/) |
|Redis Cache                                  | `Microsoft.Azure.Management.Redis.Fluent`           | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Redis.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Redis.Fluent/) |
|Resource Manager                             | `Microsoft.Azure.Management.ResourceManager.Fluent` | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.ResourceManager.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.ResourceManager.Fluent/) |
|Search                                       | `Microsoft.Azure.Management.Search.Fluent`          | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Search.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Search.Fluent/) |
|Service Bus                                  | `Microsoft.Azure.Management.ServiceBus.Fluent`      | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.ServiceBus.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.ServiceBus.Fluent/) |
|SQL Database                                 | `Microsoft.Azure.Management.Sql.Fluent`             | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Sql.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Sql.Fluent/) |
|Storage                                      | `Microsoft.Azure.Management.Storage.Fluent`         | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.Storage.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.Storage.Fluent/) |
|Traffic Manager                              | `Microsoft.Azure.Management.TrafficManager.Fluent`  | [![NuGet](https://img.shields.io/nuget/v/Microsoft.Azure.Management.TrafficManager.Fluent.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Microsoft.Azure.Management.TrafficManager.Fluent/) |

---

# Pre-requisites

- [.NET Core](https://www.microsoft.com/net/core) 
- Azure Service Principal - see [how to create authentication info](./AUTH.md).

# Help

If you are migrating your code to 1.2, you can use these notes for [preparing your code for 1.2 from 1.1](./notes/prepare-for-1.2.md).

If you encounter any bugs with these libraries, please file issues via [Issues](https://github.com/Azure/azure-sdk-for-net/issues) and tag them [Fluent](https://github.com/Azure/azure-sdk-for-net/labels/Fluent) or checkout [StackOverflow for Azure Management Libraries for .NET](http://stackoverflow.com/questions/tagged/azure-sdk).

To enable Http message tracing in your code please check [this article](https://github.com/Azure/autorest/blob/master/docs/client/tracing.md#tracing).

# Contribute Code

If you would like to become an active contributor to this project please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](http://azure.github.io/guidelines.html).

1. Fork it
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create new Pull Request

# More Information
* [https://azure.microsoft.com/en-us/develop/net/](https://azure.microsoft.com/en-us/develop/net/)
* If you don't have a Microsoft Azure subscription you can get a FREE trial account [here](http://go.microsoft.com/fwlink/?LinkId=330212).

**Previous Releases and Corresponding Repo Branches**

| Version           | SHA1                                                                                      | Remarks                                               |
|-------------------|-------------------------------------------------------------------------------------------|-------------------------------------------------------|
| 1.2               | [1.2](https://github.com/Azure/azure-sdk-for-net/tree/Fluent-v1.2)                | Tagged release for 1.2 version of Azure management libraries |
| 1.1               | [1.1](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.1)                | Tagged release for 1.1 version of Azure management libraries |
| 1.0               | [1.0](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.0.0-stable)           | Tagged release for 1.0 version of Azure management libraries |
| 1.0.0-beta5       | [1.0.0-beta5](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.0.0-beta5)           | Tagged release for 1.0.0-beta5 version of Azure management libraries |
| 1.0.0-beta4       | [1.0.0-beta4](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.0.0-beta4)           | Tagged release for 1.0.0-beta4 version of Azure management libraries |
| 1.0.0-beta3       | [1.0.0-beta3](https://github.com/Azure/azure-sdk-for-net/releases/tag/Fluent-v1.0.0-beta3)           | Tagged release for 1.0.0-beta3 version of Azure management libraries |
| AutoRest       | [AutoRest](https://github.com/selvasingh/azure-sdk-for-net/tree/AutoRest)               | Main branch for AutoRest generated raw clients |

---

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
