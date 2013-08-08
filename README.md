# Windows Azure SDK for Windows 8 and .NET 4 (2.0.6.1)

This SDK allows you to build Windows Azure applications that take advantage of
Azure scalable cloud computing resources: table and blob storage, messaging through
Service Bus, distributed caching through cache.

For documentation please see the [http://www.windowsazure.com/en-us/develop/net/](Windows Azure .NET Developer Center).

# Features

- Tables
    - Create/Delete Tables
    - Query/Create/Read/Update/Delete Entities
- BLOBs
    - Create/Read/Update/Delete BLOBs
- Queues
    - Create/Delete Queues
    - Insert/Peek Queue Messages
    - Advanced Queue Operations
- Media

    > Available in separate [http://github.com/WindowsAzure/azure-sdk-for-media-services/tree/master/src/net/Client](Media Services repository)

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
- Windows Store / Windows RT: Storage Client Libraries are available for Windows Store applications.

## Requirements

- Windows Azure Subscription: To use this SDK to call Windows Azure services, you need to first create an account.
- Hosting: To host your .NET code in Windows Azure, you additionally need to download the full Windows Azure SDK for .NET - which includes packaging,
    emulation, and deployment tools, or use Windows Azure Web Sites to deploy ASP.NET web applications.

## Dependencies

This version depends on three libraries (collectively referred to as ODataLib), which are resolved through the ODataLib (version 5.2.0) packages available through NuGet and not the WCF Data Services installer which currently contains 5.0.0 versions.  

The ODataLib libraries can be downloaded directly or referenced by your code project through NuGet.  

The specific ODataLib packages are:

- http://nuget.org/packages/Microsoft.Data.OData/5.2.0
- http://nuget.org/packages/Microsoft.Data.Edm/5.2.0
- http://nuget.org/packages/System.Spatial/5.2.0

## Code Samples

> Note:
> How-Tos focused around accomplishing specific tasks are available on the [http://www.windowsazure.com/en-us/develop/net/](Windows Azure .NET Developer Center).

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
var storageAccount = 
    CloudStorageAccount.DevelopmentStorageAccount;
var tableClient = storageAccount.CreateCloudTableClient();
```

Now, to create a table entity using the client:

```csharp
CloudTable peopleTable = tableClient.GetTableReference("people");
peopleTable.Create();
```

# Need Help?
Be sure to check out the Windows Azure [http://go.microsoft.com/fwlink/?LinkId=234489](Developer Forums on MSDN) if you have trouble with the provided code or use 
StackOverflow.

# Feedback

For feedback related specificically to this SDK, please use the Issues section of the repository.

For general suggestions about Windows Azure please use our [http://www.mygreatwindowsazureidea.com/forums/34192-windows-azure-feature-voting](UserVoice forum).

# Learn More

- [http://www.windowsazure.com/en-us/develop/net/](Windows Azure .NET Developer Center)
- [http://msdn.microsoft.com/en-us/library/dd179380.aspx](Windows Azure SDK Reference for .NET - MSDN)
