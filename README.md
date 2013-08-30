# Windows Azure SDK for .NET 4, Windows 8, and Windows Phone 8 (2.1.0.0)

The Windows Azure SDK for .NET allows you to build Windows Azure applications 
that take advantage of scalable cloud computing resources.

Please note that Windows 8 and Windows Phone 8 libraries are CTP (Community
Technology Preview) releases.

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
- Media

    > Available in separate [Media Services repository](http://github.com/WindowsAzure/azure-sdk-for-media-services/tree/master/src/net/Client)

# Getting Started

## Download & Install

### Via Git

To get the source code of the SDK via git just type:

```bash
git clone git://github.com/WindowsAzure/azure-sdk-for-net.git
cd azure-sdk-for-net
```

### Via NuGet

To get the binaries of this library as distributed by Microsoft, ready for use
within your project you can also have them installed by the .NET package manager [http://www.nuget.org/](NuGet).

`Install-Package WindowsAzure.Storage`

## Target Frameworks

- .NET Framework 3.5: At this time the majority of the Windows Azure SDK for .NET supports primarily the desktop .NET Framework 3.5 and above.
- Windows 8 for Windows Store and Windows RT app development: Storage Client Libraries are available for Windows Store applications.

## Requirements

- Windows Azure Subscription: To call Windows Azure services, you need to first [create an account](https://account.windowsazure.com/Home/Index). Free trial subscriptions are available.
- Hosting: To host your .NET code in Windows Azure, you additionally need to download the full Windows Azure SDK for .NET - which includes packaging,
    emulation, and deployment tools, or use Windows Azure Web Sites to deploy ASP.NET web applications.

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

# Need Help?
Be sure to check out the Windows Azure [Developer Forums on MSDN](http://go.microsoft.com/fwlink/?LinkId=234489) if you have trouble with the provided code or use 
StackOverflow.

# Feedback

For feedback related specificically to these open source client libraries, please use the Issues section of the repository.

For general suggestions about Windows Azure please use our [UserVoice forum](http://www.mygreatwindowsazureidea.com/forums/34192-windows-azure-feature-voting).

# Learn More

- [Windows Azure .NET Developer Center](http://www.windowsazure.com/en-us/develop/net/)
- [Windows Azure SDK Reference for .NET - MSDN](http://msdn.microsoft.com/en-us/library/dd179380.aspx)
