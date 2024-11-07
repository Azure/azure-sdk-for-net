# Azure CloudMachine

Write Azure apps in 5 minutes

## Getting started

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).
> You must have .NET 8 (or higher) installed
> You must have Azure CLI installed
> You must have npm installed

### Walkthrough

Create project

```dotnetcli
mkdir cmdemo
cd cmdemo
mkdir server
cd server
dotnet new web
```

Add Azure.CloudMachine.All package
```dotnetcli
dotnet add package Azure.CloudMachine.All --prerelease
```

Open Program.cs file and add the following two lines of code to the top of the file
```csharp
using Azure.Provisioning.CloudMachine;

if (CloudMachineInfrastructure.Configure(args)) return;
```
The `CloudMachineInfrastructure.Configure` call allows running the app with `-bicep` switch, which generate bicep files required to provision resources in Azure. Let's generate these bicep files now. 
```dotnetcli
dotnet run -bicep
```
As you can see, a folder called `infra` was created and it should have several bicep files in it. Let's now initialize the project for azd.
```dotnetcli
azd init
```
select template
choose 'yes' when asked 'Continue initializing an app here? This will also initialize a new git repository in 'D:\git\cmdemo\server'. (y/N)'
choose 'minimal' template 
use 'cmserver' as the environment name
```dotnetcli
azd init
```
And now let's provision the resources. Select `eastus` as the region
```dotnetcli
azd provision
```
