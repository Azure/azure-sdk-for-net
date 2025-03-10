# Azure Projects client library for .NET

Write Azure apps in 5 minutes

## Getting started

### Install the packages

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Projects --prerelease
dotnet add package Azure.Projects.Provisioning --prerelease
dotnet add package Azure.Projects.OpenAI --prerelease
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

Add `Azure.Projects.All` package
```dotnetcli
dotnet add package Azure.Projects.Provisioning --prerelease
dotnet add package Azure.Projects.OpenAI --prerelease
```
#### Use Azure Developer CLI to provision Projects

Open `Program.cs` file and add the following two lines of code to the top of the file
```csharp
using Azure.Projects;

ProjectInfrastructure infrastructure = new();
if (infrastructure.TryExecuteCommand(args)) return;
```

The `TryExecuteCommand` call allows running the app with a `-init` switch, which will generate bicep files required to provision project resources in Azure. Let's generate these bicep files now.
```dotnetcli
dotnet run -bicep
```
As you can see, a folder called `infra` was created with several bicep files in it. Let's now initialize the project.

```dotnetcli
azd init
```
type 'demo' as the environment name, and then let's provision the resources (select `eastus` as the region):
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

#### Use CDK to add resources to the Project

Since we are writing an AI application, we need to provision Azure OpenAI resources. To do this, add the following line of code right below where the infrastructure instance is created:
```csharp
infrastructure.AddFeature(new OpenAIModelFeature("gpt-4o-mini", "2024-07-18"));
```
Now regenerate the bicep files and re-provision
```dotnetcli
dotnet run -bicep
azd provision
```

#### Add ProjectClient to ASP.NET DI Container
You will be using `ProjectClient` to access resources provisioned in the cloud machine. Let's add such client to the DI container such that it is avaliable to ASP.NET handlers
```dotnetcli
builder.AddAzureProjectClient(infrastructure);
```
#### Call ProjectClient APIs

You are now ready to call Azure OpenAI service from the app. To do this, change the line of code that maps the application root to the following:

```csharp
app.MapGet("/", (ProjectClient client) => client.GetOpenAIChatClient().CompleteChat("list all noble gases").AsText());
```

The full program should now look like the following:
```csharp
using Azure.Projects;
using Azure.Projects.OpenAI;

ProjectInfrastructure infrastructure = new();
infrastructure.AddFeature(new OpenAIModelFeature("gpt-4o-mini", "2024-07-18"));
if (infrastructure.TryExecuteCommand(args)) return;

var builder = WebApplication.CreateBuilder(args);
builder.AddAzureProjectClient(infrastructure);

var app = builder.Build();

app.MapGet("/", (ProjectClient client) => client.GetOpenAIChatClient().CompleteChat("list all noble gases").AsText());

app.Run();
```

You can now start the application
```dotnetcli
dotnet run
```
and navigate to the URL printed in the console.

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