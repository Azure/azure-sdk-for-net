---
name: generate-code-cs
description: "Generate the code from typespec for C#. Parameter: C# SDK repository root location <cs_root>."
---

# Basic information
The C# repository root location is provided by <cs_root>. C# source codes of interest are located in <cs_root>/sdk/ai/Azure.AI.Projects, <cs_root>/sdk/ai/Azure.AI.Projects.Agents and <cs_root>/sdk/ai/Azure.AI.Extensions.OpenAI. Each folder contains subfolder `src`, which contains all the source codes. In the `src/Generated` there is a generated code; the folder `Custom` contains the code customizations. Please review the `references/customization.md` for more information on code customization.  The typespec repository, used for code generation is located at https://github.com/Azure/azure-rest-api-specs.git. Please use the branch provided by user, if it is not provided use `feature/foundry-release`. 

# Updating the code
1. Take the latest commit hash from this branch and set it in `commit` field in three files: <cs_root>/sdk/ai/Azure.AI.Projects.Agents/tsp-location.yaml, <cs_root>/sdk/ai/Azure.AI.Projects/tsp-location.yaml and <cs_root>/sdk/ai/Azure.AI.Extensions.OpenAI/tsp-location.yaml.
2. After the files are modified, remove the directory <cs_root>\eng\common\tsp-client\node_modules if present.
3. Generate code for the first package. This command may fail with EPERM error.

```powershell
cd <cs_root>/sdk/ai/Azure.AI.Projects.Agents
dotnet build /t:GenerateCode
```

```bash
cd <cs_root>/sdk/ai/Azure.AI.Projects.Agents
dotnet build /t:GenerateCode
```

If the EPERM error has happened, run the next code and make sure it pass:

```powershell
cd ../Azure.AI.Extensions.OpenAI
npm exec --prefix <cs_root>\eng\common/tsp-client --no -- tsp-client update --no-prompt --output-dir<cs_root>\sdk\ai\Azure.AI.Projects.Agents\src/../
```

```bash
cd ../Azure.AI.Extensions.OpenAI
npm exec --prefix <cs_root>\eng\common/tsp-client --no -- tsp-client update --no-prompt --output-dir<cs_root>\sdk\ai\Azure.AI.Projects.Agents\src/../
```

4. Generate code using script below.

```powershell
cd ../Azure.AI.Extensions.OpenAI
npm exec --prefix <cs_root>\eng\common/tsp-client --no -- tsp-client update --no-prompt --output-dir<cs_root>\sdk\ai\Azure.AI.Extensions.OpenAI\src/../
cd ../Azure.AI.Projects
npm exec --prefix <cs_root>\eng\common/tsp-client --no -- tsp-client update --no-prompt --output-dir<cs_root>\sdk\ai\Azure.AI.Projects\src/../
```

```bash
cd <cs_root>/sdk/ai/Azure.AI.Projects.Agents
dotnet build /t:GenerateCode
cd ../Azure.AI.Extensions.OpenAI
npm exec --prefix <cs_root>\eng\common/tsp-client --no -- tsp-client update --no-prompt --output-dir<cs_root>\sdk\ai\Azure.AI.Extensions.OpenAI\src/../
cd ../Azure.AI.Projects
npm exec --prefix <cs_root>\eng\common/tsp-client --no -- tsp-client update --no-prompt --output-dir<cs_root>\sdk\ai\Azure.AI.Projects\src/../
```

# Post processing

1. For each of package check that it compiles without errors (replace <package> by `Azure.AI.Projects`, `Azure.AI.Extensions.OpenAI` or `Azure.AI.Projects.Agents`):

```powershell
cd <cs_root>/sdk/ai/<package>
dotnet build /t:GenerateCode
```

```bash
cd <cs_root>/sdk/ai/<package>
dotnet build /t:GenerateCode
```

2. If there are any errors, Customize the code so that it compiles.
3. `Azure.AI.Projects.Agents` package after code generation may get new tool classes, inherited from `Tool`. The same classes will be generated in `Azure.AI.Extensions.OpenAI` projects. If that is the case, add inyto the file `<cs_root>/sdk/ai/Azure.AI.Extensions.OpenAI/src/Custom.CodeGenStubs.Tools.cs` entries to rename the generated tool classes and their parameters so that they have `Responses` prefix. For example, if the class `FabricIQPreviewTool` was added add the next entries:

```C#
[CodeGenType("FabricIQPreviewTool")] public partial class ResponsesFabricIQPreviewTool { }
[CodeGenType("FabricIQPreviewToolParameters")] public partial class ResponsesFabricIQPreviewToolParameters { }
```

Order the entried in the file alphabetically; do not remove the entries already present.
4. Update the API-view by running the script (replace <package> by `Azure.AI.Projects`, `Azure.AI.Extensions.OpenAI` or `Azure.AI.Projects.Agents`):

```powershell
cd <cs_root>
eng\scripts\Export-API.ps1 ai\<package>
```

```bash
cd <cs_root>
eng\scripts\Export-API.ps1 ai\<package>
```


# Sample generation
1. Provide the summary of changes.
2. If there were significant changes in the code please provide the samples as explained below.

C# sample consists of two parts: the source code in the folder <cs_root>/sdk/ai/<package_name>/tests/Samples and corresponding .md files go to <cs_root>/sdk/ai/<package_name>/Samples.
The C# file should demonstrate both sync and async API when sappropriate. See the example below:

## Asynchronous Sample
```C#
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion1 = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myAgent1",
    options: new(agentDefinition));
```

## Synchronous Sample
```C#
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion1 = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myAgent1",
    options: new(agentDefinition));
```

The code needs tro be logically split into blocks, which usage should be explained in .md file. Each blocks is marked in the source code as follows:

```C#
#region Snippet:Sample_FunctionFoo_MySampl_Async
public async Task Foo()
{
    await Task.Delay(1000);
    Console.WriteLine("Hello world!")
} 
#endregion
```

These blocks will be rendered in the .md file code block based on the region name (it will be done by automation):
```C# Snippet:Sample_FunctionFoo_MySampl_Async
public async Task Foo()
{
    await Task.Delay(1000);
    Console.WriteLine("Hello world!")
}
```

If the code block has sync and async counterpart, please create code block for each of them. Provide the short explanation for each code block. Please make sure that there is one-to-one consistence between C# regions are and .md file code blocks.
To make cure that it is so, call the script (replace <package> by `Azure.AI.Projects`, `Azure.AI.Extensions.OpenAI` or `Azure.AI.Projects.Agents`):

```powershell
cd <cs_root>
eng\scripts\Update-Snippets.ps1 ai\<package>
```

```bash
cd <cs_root>
eng\scripts\Update-Snippets.ps1 ai\<package>
```

# Package generation
After everything ready, please generate the packages for all <package> i.e. (replace <package> by `Azure.AI.Projects`, `Azure.AI.Extensions.OpenAI` or `Azure.AI.Projects.Agents`).


```powershell
cd <cs_root>/sdk/ai/<package>
dotnet pack
```

```bash
cd <cs_root>/sdk/ai/<package>
dotnet pack
```

Provide the location of each package in the summary and provide the simple instruction on installation.
