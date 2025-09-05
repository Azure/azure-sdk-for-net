# Azure Projects client library for .NET

Azure.Projects is an set of libraries and tools for rapid application development on Azure.
If you cannot get an app running in 10 minutes, let us know that we failed!

These libraries and tools make it easier to start building an application, by:
- Relying on opinionated defaults whenever possible.
- Using the Azure.Provisioning libraries for provisioning resources in code (in C#).
- Exposing simplified APIs for the most commonly used Azure services.

At the same time, Azure.Projects supports break-glass scenarios where, if needed, you can override the defaults, use powerful tools (like bicep, azd), or the full featured Azure SDK libraries. 
In other words, Azure.Projects provides smart, simplified APIs but will never block you from using the full power of the Azure platform, if you choose to. 

## Getting started

### Prerequisites

* You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).
* You must have [.NET 8](https://dotnet.microsoft.com/download) (or higher) installed
* You must have [Azure Developer CLI](https://learn.microsoft.com/azure/developer/azure-developer-cli/install-azd) (azd) installed
* You must be logged into Azure Developer CLI (`azd auth login`)

### Walkthrough

#### Create a console application

In a command line window type

```dotnetcli
mkdir cmdemo
cd cmdemo
dotnet new console
```

#### Install Required Packages

```dotnetcli
dotnet add package Azure.Projects --prerelease
dotnet add package Azure.Projects.Provisioning --prerelease
dotnet add package Azure.Projects.AI --prerelease
```

#### Write, Provision, and Run the Application

Open `Program.cs` file and change the code to the following
```csharp
using Azure.AI.OpenAI;
using Azure.Projects;
using Azure.Projects.Tooling;
using OpenAI.Chat;

ProjectInfrastructure infrastructure = new();
infrastructure.AddFeature(new OpenAIChatFeature("gpt-35-turbo", "0125"));

if (args.Length > 0 && args[0] == "-bicep")
{
    Azd.Init(infrastructure);
    return;
}

ProjectClient project = new();
ChatClient chat = project.GetOpenAIChatClient();
Console.WriteLine(chat.CompleteChat("list all noble gasses.").AsText());

```

You can now provision Azure resources for this application by executing the following three commands.

```dotnetcli
dotnet run -bicep
azd init
azd provision
```
The first command created a folder called `infra` with several bicep files in it. The files will be used by azd to provision Azure resources. 
The second command sets initializes the project as an azd project. Select 'create minimal project' when asked to choose a template, and type 'demo' as the environment name. 
The last command actually provisions resources described by the bicep files. When provisioning finishes, you should see something like the following in the console output
```dotnetcli
 (✓) Done: Resource group: cm125957681369428 (627ms)
```
You can now run the app

```dotnetcli
dotnet run
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

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
