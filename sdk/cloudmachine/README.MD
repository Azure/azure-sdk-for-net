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
select template, choose 'yes' when asked 'Continue initializing an app here?', choose the 'minimal' template, and use 'cmserver' as the environment name

Once the initialization completes, let's provision the resources. Select `eastus` as the region
```dotnetcli
azd provision
```
When provisioning finishes, you should see something like the following in the console output
```dotnetcli
 (✓) Done: Resource group: cm125957681369428 (627ms)
```
And if you go to your Azure portal, you will see the resource group created. The resource group will have server resources such us Storage, ServiceBus, and EventGrid. 

Since we are writing an AI application, we need to add Azure OpenAI resource. To do this, change the CloudMachine configuration call to the following:
```csharp
if (CloudMachineInfrastructure.Configure(args, (cm) => {
    cm.AddFeature(new OpenAIFeature() {
        Chat = new AIModel("gpt-35-turbo", "0125")
    });
})) return;
```
And now regenerate new bicep with the new Azure OpenAI resources, and re-provision
```dotnetcli
dotnet run -bicep
azd provision
```
