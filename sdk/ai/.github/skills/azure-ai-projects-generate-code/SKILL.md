---
name: generate-code-cs
description: "Generate the code from typespec for C#. Parameter: C# SDK repository root location <cs_root>."
---

# Basic information
The C# repository root location is provided by <cs_root>. C# source codes of interest are located in <cs_root>/sdk/ai/Azure.AI.Projects, <cs_root>/sdk/ai/Azure.AI.Projects.Agents and <cs_root>/sdk/ai/Azure.AI.Extensions.OpenAI. Each folder contains subfolder `src`, which contains all the source codes. The `src/Generated` folder contains generated code; the folder `Custom` contains the code customizations. Please review the `references/customization.md` for more information on code customization. The typespec repository, used for code generation is located at https://github.com/Azure/azure-rest-api-specs.git. Please use the branch provided by user, if it is not provided use `feature/foundry-release`.

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

If the EPERM error has happened, run the next code and make sure it passes:

```powershell
cd ../Azure.AI.Extensions.OpenAI
npm exec --prefix <cs_root>\eng\common/tsp-client --no -- tsp-client update --no-prompt --output-dir<cs_root>\sdk\ai\Azure.AI.Projects.Agents\src/../
```

```bash
cd ../Azure.AI.Extensions.OpenAI
npm exec --prefix <cs_root>\eng\common/tsp-client --no -- tsp-client update --no-prompt --output-dir<cs_root>\sdk\ai\Azure.AI.Projects.Agents\src/../
```

4. Generate code using the script below.

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

1. For each package, check that it compiles without errors (replace <package> by `Azure.AI.Projects`, `Azure.AI.Extensions.OpenAI` or `Azure.AI.Projects.Agents`):

```powershell
cd <cs_root>/sdk/ai/<package>
dotnet build /t:GenerateCode
```

```bash
cd <cs_root>/sdk/ai/<package>
dotnet build /t:GenerateCode
```

2. If there are any errors, customize the code so that it compiles.
3. `Azure.AI.Projects.Agents` package after code generation may get new tool classes, inherited from `Tool`. The same classes will be generated in `Azure.AI.Extensions.OpenAI` projects. If that is the case, add into the file `<cs_root>/sdk/ai/Azure.AI.Extensions.OpenAI/src/Custom.CodeGenStubs.Tools.cs` entries to rename the generated tool classes and their parameters so that they have `Responses` prefix. For example, if the class `FabricIQPreviewTool` was added, add the next entries:

```C#
[CodeGenType("FabricIQPreviewTool")] public partial class ResponsesFabricIQPreviewTool { }
[CodeGenType("FabricIQPreviewToolParameters")] public partial class ResponsesFabricIQPreviewToolParameters { }
```

Order the entries in the file alphabetically; do not remove the entries already present.
4. Make sure that all projects build without errors by running `dotnet build` inside the project folder.
5. Update the API-view by running the script (replace <package> by `Azure.AI.Projects`, `Azure.AI.Extensions.OpenAI` or `Azure.AI.Projects.Agents`):

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
2. If there were significant changes in the code, please provide the samples as explained below.

A C# sample consists of two parts: the source code in the folder <cs_root>/sdk/ai/<package_name>/tests/Samples and corresponding .md files go to <cs_root>/sdk/ai/<package_name>/Samples.
The C# file should demonstrate both sync and async API when appropriate. See the example below:

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

The code needs to be logically split into blocks, whose usage should be explained in .md file. Each block is marked in the source code as follows:

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

If the code block has sync and async counterpart, please create code block for each of them. Provide the short explanation for each code block. Please make sure that there is one-to-one consistency between C# regions and .md file code blocks.
To make sure that it is so, call the script (replace <package> by `Azure.AI.Projects`, `Azure.AI.Extensions.OpenAI` or `Azure.AI.Projects.Agents`):

```powershell
cd <cs_root>
eng\scripts\Update-Snippets.ps1 ai\<package>
```

```bash
cd <cs_root>
eng\scripts\Update-Snippets.ps1 ai\<package>
```

# Updating changelog
Get the differences by running

```powershell
cd <cs_root>
git diff
```

```bash
cd <cs_root>
git diff
```

Figure out, which classes are public facing and based on that populate the latest section of `Release History`. Append the found changes to the `### Features Added`, `### Breaking Changes`, `### Bugs Fixed` or `### Other Changes` section. It is also possible to add `### Sample Updates` section or append data to it. Do not modify the header, denoting version and release date, for example `## 2.1.0-beta.2 (Unreleased)`.

# [Optional] Create a pull request

1. Prompt user if the PR is required. If it is not, go to the section "Package generation".
2. Get the user's github alias by running `gh api user --jq .login`.
3. Stash the changes and make sure to use the latest main branch.
    ```powershell
    git stash
    git checkout main
    git pull origin main
    ```

    ```bash
    git stash
    git checkout main
    git pull origin main
    ```
4. Create a branch and apply stashed changes; replace \<user_alias\> by user github alias from step 2. Replace \<commit\> by the commit hash from the typespec.

    ```bash
    git checkout -b <user_alias>/code_generation_<commit>
    git stash apply
    ```

    ```powershell
    git checkout -b <user_alias>/code_generation_<commit>
    git stash apply
    ```
5. Add all new files by running `git add` and modified files by `git add -u`.
6. Commit changes with the short summary of added features as a comment `git commit -m "new features"`
7. Create a pull request by calling `gh pr create --title "<title>" --body "<changelog>"`; replace \<title\> and \<changelog\> by short PR title and the changes from the changelog, we have generated in "Updating changelog" section.

# [Optional] Create an alpha package release

1. Prompt user if alpha package release is required. If it is not, go to the section "Package generation".
2. Check the next prerequisites:
   * azure-cli must be installed and present in the path (please check by running `az az pipelines show --id 7296 --organization https://dev.azure.com/azure-sdk/ --project internal`).
   * User needs to have a permission to access (check by running `curl https://dev.azure.com/azure-sdk/internal/_artifacts/feed/azure-sdk-for-net-pr`)
3. Run the pipeline `az pipelines run --id 7296 --organization https://dev.azure.com/azure-sdk/ --project internal --branch nirovins/fix_pipelines --variables "SetDevVersion=true" --open`; replace the \<branch\> by the branch from "Create a pull request" section.

# Package generation
After everything is ready, please generate the packages for all \<package\> i.e. (replace \<package\> by `Azure.AI.Projects`, `Azure.AI.Extensions.OpenAI` or `Azure.AI.Projects.Agents`).


```powershell
cd <cs_root>/sdk/ai/<package>
dotnet pack
```

```bash
cd <cs_root>/sdk/ai/<package>
dotnet pack
```

Provide the location of each package in the summary and provide the simple instruction on installation.
If the alpha package was released to Azure (in section "Create an alpha package release"), please add to the instructions command to add a new NuGet repository to the project. `dotnet nuget add source https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json`
