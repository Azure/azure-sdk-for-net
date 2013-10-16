# Windows Azure SDK for .NET 4, Windows 8, and Windows Phone 8 (2.1.0.0)

The Windows Azure SDK for .NET allows you to build Windows Azure applications 
that take advantage of scalable cloud computing resources.

This repository contains the open source subset of the .NET SDK. For documentation of the 
complete SDK, please see the [Windows Azure .NET Developer Center](http://www.windowsazure.com/en-us/develop/net/).

# Features

- Tables
    - Create/Delete Tables
    - Query/Create/Read/Update/Delete Entities
- Blobs
    - Create/Read/Update/Delete Blobs
- Queues
    - Create/Delete Queues
    - Insert/Peek Queue Messages
    - Advanced Queue Operations
- Management Libraries
	- Compute
 	- Infrastructure
	- Storage 
	- Virtual Networks
- Media

    > Available in separate [Media Services repository](http://github.com/WindowsAzure/azure-sdk-for-media-services/tree/master/src/net/Client)

# Getting started

The complete Windows Azure SDK can be downloaded from the [Windows Azure Downloads Page](http://www.windowsazure.com/en-us/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes. 

## Target Frameworks

- .NET Framework 4.0: As of October 2013, the Windows Azure SDK for .NET (v2.2) supports primarily the desktop .NET Framework 4 release and above. For earlier .NET versions, SDK v2.1 is still supported.
- Windows 8 for Windows Store app development: Storage Client Libraries are available for Windows Store applications.
 
## Requirements

- Windows Azure Subscription: To call Windows Azure services, you need to first [create an account](https://account.windowsazure.com/Home/Index). Free trial subscriptions are available.
- Hosting: To host your .NET code in Windows Azure, you additionally need to download the full Windows Azure SDK for .NET - which includes packaging,
    emulation, and deployment tools, or use Windows Azure Web Sites to deploy ASP.NET web applications.

## Need Help?
Be sure to check out the Windows Azure [Developer Forums on MSDN](http://go.microsoft.com/fwlink/?LinkId=234489) if you have trouble with the provided code or use StackOverflow.

## Collaborate & Contribute

We gladly accept community contributions.

- Issues: Please report bugs using the Issues section of GitHub
- Forums: Interact with the development teams on StackOverflow or the Windows Azure Forums
- Source Code Contributions: Please follow the [contribution guidelines for Windows Azure open source](http://windowsazure.github.io/guidelines.html) that details information on onboarding as a contributor 

For general suggestions about Windows Azure please use our [UserVoice forum](http://www.mygreatwindowsazureidea.com/forums/34192-windows-azure-feature-voting).

# Storage Client Library for .NET 4, Windows 8, and Windows Phone 8 (2.1.0.0)

The Storage Client Library ships with the Windows Azure SDK for .NET and also on NuGet. You'll find the latest version and hotfixes on NuGet via the `WindowsAzure.Storage` package. You can [read about the 2.1 release on the storage team blog post](http://blogs.msdn.com/b/windowsazurestorage/archive/2013/09/07/announcing-storage-client-library-2-1-rtm.aspx).

Please note that Windows 8 and Windows Phone 8 libraries are CTP (Community
Technology Preview) releases.

## Download & Install

### Via Git

To get the source code of the SDK via git just type:

```bash
git clone git://github.com/WindowsAzure/azure-sdk-for-net.git
cd azure-sdk-for-net
```

### Via NuGet

To get the binaries of this library as distributed by Microsoft, ready for use
within your project you can also have them installed by the .NET package manager [NuGet](http://www.nuget.org/).

`Install-Package WindowsAzure.Storage`

## Dependencies

### OData

This version depends on three libraries (collectively referred to as ODataLib), which are resolved through the ODataLib (version 5.2.0) packages available through NuGet and not the WCF Data Services installer which currently contains 5.0.0 versions.

The ODataLib libraries can be downloaded directly or referenced by your code project through NuGet.  

The specific ODataLib packages are:

- [Microsoft.Data.OData](http://nuget.org/packages/Microsoft.Data.OData/)
- [Microsoft.Data.Edm](http://nuget.org/packages/Microsoft.Data.Edm/)
- [System.Spatial](http://nuget.org/packages/System.Spatial)

### Test Dependencies

FiddlerCore is required by:

- Test\Unit\FaultInjection\HttpMangler
- Test\Unit\FaultInjection\XStoreMangler
- Test\Unit\DotNet40

This dependency is not included and must be downloaded from [http://www.fiddler2.com/Fiddler/Core/](http://www.fiddler2.com/Fiddler/Core/).

Once installed:

- Copy `FiddlerCore.dll` `\azure-sdk-for-net\microsoft-azure-api\Services\Storage\Test\Unit\FaultInjection\Dependencies\DotNet2`
- Copy `FiddlerCore4.dll` to `azure-sdk-for-net\microsoft-azure-api\Services\Storage\Test\Unit\FaultInjection\Dependencies\DotNet4`

## Code Samples

> Note:
> How-Tos focused around accomplishing specific tasks are available on the [http://www.windowsazure.com/en-us/develop/net/](Windows Azure .NET Developer Center).

### Creating a Table

First, include the classes you need (in this case we'll include the Storage and Table
and further demonstrate creating a table):

```csharp
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
```

To perform an operation on any Windows Azure resource you will first instantiate
a *client* which allows performing actions on it. The resource is known as an 
*entity*. To do so for Table you also have to authenticate your request:

```csharp
var storageAccount = CloudStorageAccount.Parse(
    CloudConfigurationManager.GetSetting("StorageConnectionString"));
var tableClient = storageAccount.CreateCloudTableClient();
```

Now, to create a table entity using the client:

```csharp
CloudTable peopleTable = tableClient.GetTableReference("people");
peopleTable.Create();
```

# Windows Azure Management Libraries

Automate, configure and command your Windows Azure deployments, infrastructure and accounts with the Windows Azure Management Libraries.

> *Preview:* At this time the Windows Azure Management Libraries are in the preview state as the teams gather feedback and prepare for the initial release. Please enjoy using the libraries and source in any capacity, but understand that there may be breaking changes with the 1.0 release.

## Download & Install

### Via Git

To get the source code of the SDK via git just type:

```bash
git clone git://github.com/WindowsAzure/azure-sdk-for-net.git
cd azure-sdk-for-net\libraries
```

### Via NuGet

Official binaries are distributed by Microsoft and available using the .NET package manager [NuGet](http://www.nuget.org/).

To get all of the management libraries setup in your project:

`Install-Package Microsoft.WindowsAzure.Management.Libraries -IncludePrerelease`

> You can also install just the management library for a service of interest. To deploy a virtual machine to the cloud, the `Microsoft.WindowsAzure.Management.Compute` package can be used, for example.

# Learn More

- [Windows Azure .NET Developer Center](http://www.windowsazure.com/en-us/develop/net/)
- [Windows Azure SDK Reference for .NET - MSDN](http://msdn.microsoft.com/en-us/library/dd179380.aspx)
