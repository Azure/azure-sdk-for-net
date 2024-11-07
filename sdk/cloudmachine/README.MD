# Azure CloudMachine

Write Azure apps in 5 minutes

## Getting started

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).
> You must have .NET 8 (or higher) installed
> You must have Azure CLI installed
> You must have Azure Developer CLI installed
> You must have npm installed
> You must be logged into Azure CLI and Azure Developer CLI

### Walkthrough

#### Create Server Project

In a command line window type
```dotnetcli
mkdir cmdemo
cd cmdemo
mkdir server
cd server
dotnet new web
```

Add `Azure.CloudMachine.All` package
```dotnetcli
dotnet add package Azure.CloudMachine.All --prerelease
```
#### Use Azure Dev CLI to provision CloudMachine

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
And if you go to your Azure portal, or execute the following az cli command to see the resource group created. The resource group will have server resources such us Storage, ServiceBus, and EventGrid. 
```dotnetcli
az resource list --resource-group <resource_group_from_command_line> --output table
```

#### Use CDK to add resources to the CloudMachine

Since we are writing an AI application, we need to provision Azure OpenAI resources. To do this, add the follwoing class to the end of the Program.cs file:
```csharp
class AssistantService {
    internal static void Configure(CloudMachineInfrastructure cm) {
        cm.AddFeature(new OpenAIFeature() { Chat = new AIModel("gpt-4o-mini", "2024-07-18") });
    }
}
```
And change the infrastructure configuration call att he begining of the file to:
```csharp
if (CloudMachineInfrastructure.Configure(args, AssistantService.Configure)) return;
```
And now regenerate new bicep with the new Azure OpenAI resources, and re-provision
```dotnetcli
dotnet run -bicep
azd provision
```

#### Call CloudMachine APIs

You are now ready to call Azure OpenAI service from the app. To do this, add `CloudMachineClient` field and a `Chat` method to `AssistantService`:
```csharp
class AssistantService {
    CloudMachineClient cm = new CloudMachineClient();

    public async Task<string> Chat(string message) {
        var client = cm.GetOpenAIChatClient();
        ChatCompletion completion = await client.CompleteChatAsync(message);
        return completion.Content[0].Text;
    } 
}
```
Lastly, create an instance of the service and call the `Chat` method when the app users browses the app:
```csharp
var service = new AssistantService();
app.MapGet("/", async () => {
    return await service.Chat("List all noble gases");
});
```
The full program should look like following:
```csharp
using Azure.CloudMachine;
using Azure.CloudMachine.OpenAI;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CloudMachine.OpenAI;
using OpenAI.Chat;

if (CloudMachineInfrastructure.Configure(args, AssistantService.Configure)) return;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var service = new AssistantService();
app.MapGet("/", async () => {
    return await service.Chat("List all noble gases");
});

app.Run();

class AssistantService {
    CloudMachineClient cm = new CloudMachineClient();

    public async Task<string> Chat(string message) {
        var client = cm.GetOpenAIChatClient();
        ChatCompletion completion = await client.CompleteChatAsync(message);
        return completion.Content[0].Text;
    } 

    internal static void Configure(CloudMachineInfrastructure cm) {
        cm.AddFeature(new OpenAIFeature() {
            Chat = new AIModel("gpt-4o-mini", "2024-07-18")
        });
    }
}
```
You can now start the application
```dotnetcli
dotnet run
```
and browse to the URI printed in the console.
