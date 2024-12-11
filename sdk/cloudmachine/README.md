# Azure CloudMachine client library for .NET

Write Azure apps in 5 minutes

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.CloudMachine.All --prerelease
```

### Authenticate the Client

### Prerequisites

* You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).
* You must have .NET 8 (or higher) installed
* You must have Azure CLI (az) installed
* You must have Azure Developer CLI (azd) installed
* You must have npm installed
* You must be logged into Azure CLI and Azure Developer CLI

## Key concepts

Write Azure apps in 5 minutes using simplified opinionated APIs and declarative resource provisioning.

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
#### Use Azure Developer CLI to provision CloudMachine

Open `Program.cs` file and add the following two lines of code to the top of the file
```csharp
using Azure.CloudMachine;

if (CloudMachineInfrastructure.Configure(args)) return;
```
The `CloudMachineInfrastructure.Configure` call allows running the app with a `-bicep` switch, which will generate bicep files required to provision CloudMachine resources in Azure. Let's generate these bicep files now.
```dotnetcli
dotnet run -bicep
```
As you can see, a folder called `infra` was created with several bicep files in it. Let's now initialize the project.
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
And if you go to your Azure portal, or execute the following az command, you can see the resource group created. The resource group will contain resources such as Storage, ServiceBus, and EventGrid.
```dotnetcli
az resource list --resource-group <resource_group_from_command_line> --output table
```

#### Use CDK to add resources to the CloudMachine

Since we are writing an AI application, we need to provision Azure OpenAI resources. To do this, add the follwoing class to the end of the `Program.cs` file:
```csharp
class AssistantService {
    internal static void Configure(CloudMachineInfrastructure cm) {
        cm.AddFeature(new OpenAIFeature() { Chat = new AIModel("gpt-4o-mini", "2024-07-18") });
    }
}
```
Then change the configuration call at the beginning of the file to:
```csharp
if (CloudMachineInfrastructure.Configure(args, AssistantService.Configure)) return;
```
Now regenerate the bicep files and re-provision
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
Lastly, create an instance of the service and call the `Chat` method when the user navigates to the root URL:
```csharp
var service = new AssistantService();
app.MapGet("/", async () => await service.Chat("List all noble gases"));
```
The full program should now look like the following:
```csharp
using Azure.CloudMachine;
using Azure.CloudMachine.OpenAI;
using OpenAI.Chat;

if (CloudMachineInfrastructure.Configure(args, AssistantService.Configure)) return;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var service = new AssistantService();
app.MapGet("/", async () => await service.Chat("List all noble gases"));

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
and navigate to the URL printed in the console.

#### Use TDK to expose Web APIs and generate TypeSpec
First, let's define an API we want to expose. We will do it using a C# interface. Add the following interface to the end of `Program.cs`:
```csharp
interface IAssistantService {
    Task<string> Chat(string message);
}
```
Make sure that the `AssistantService` class implements the interface:
```csharp
class AssistantService : IAssistantService
```
Expose the service methods as web APIs by adding the following line after the existing `var service = new AssistantService();` line:
```csharp
app.Map(service);
```
Lastly, add the ability to generate TypeSpec for the new API by adding a new statement to the `Configure` method
```csharp
cm.AddEndpoints<IAssistantService>();
```
Your program shoud now look like the following:
```csharp
using Azure.CloudMachine;
using Azure.CloudMachine.OpenAI;
using OpenAI.Chat;

if (CloudMachineInfrastructure.Configure(args, AssistantService.Configure)) return;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var service = new AssistantService();
app.Map(service);
app.MapGet("/", async () => await service.Chat("List all noble gases"));

app.Run();

class AssistantService : IAssistantService {
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
        cm.AddEndpoints<IAssistantService>();
    }
}

interface IAssistantService {
    Task<string> Chat(string message);
}
```
You can now start the application and browse to the /chat endpoint [TBD on how to pass the parameter]

But what's more interesting, you can run the app with the -tsp switch to generate TypeSpec for the endpoint:
```dotnetcli
dotnet run -tsp
```
This will create a `tsp` directory, `AssistantService.tsp` file, with the following contents:
```tsp
import "@typespec/http";
import "@typespec/rest";
import "@azure-tools/typespec-client-generator-core";

@service({
  title: "AssistantService",
})

namespace AssistantService;

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ClientGenerator.Core;

@client interface AssistantServiceClient {
  @get @route("chat") Chat(@body message: string) : {
    @statusCode statusCode: 200;
    @body response : string;
  };
}
```
#### Generate client libraries from TypeSpec
Let's now generate and build a C# client library from the `AssistantService.tsp` file:
```dotnetcli
cd ..
npm install @typespec/http-client-csharp
tsp compile .\server\tsp\AssistantService.tsp --emit "@typespec/http-client-csharp"
dotnet build tsp-output\@typespec\http-client-csharp\src\AssistantService.csproj
```
You can also generate libraries for other languages, e.g.
```dotnetcli
npm install @typespec/http-client-python
tsp compile .\server\tsp\AssistantService.tsp --emit "@typespec/http-client-python"
```

#### Create command line client app for the service
```dotnetcli
mkdir cmdclient
cd cmdclient
dotnet new console
dotnet add reference ..\tsp-output\@typespec\http-client-csharp\src\AssistantService.csproj
```
And change the `Program.cs` file to the following, replacing the client URI with the URI in your server's launchsettings.json file ('cmdemo\server\Properties' folder)

```csharp
using AssistantService;

var client = new AssistantServiceClient(new Uri("http://localhost:5121/"));

while(true){
    string message = Console.ReadLine();
    var completion = client.Chat(message);
    Console.WriteLine(completion);
}
```
Now start the server
```dotnetcli
start cmd
cd..
cd server
dotnet run
```
Go back to the client project command window and start the client:
```dotnetcli
dotnet run
```
You can use the simple command line app to ask Azure OpenAI some questions.

## Examples

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/