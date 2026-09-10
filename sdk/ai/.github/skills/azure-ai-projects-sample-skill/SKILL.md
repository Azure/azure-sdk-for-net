---
name: translate-a-sample
description: "Translate the Azure SDK sample from python to C# and generate markdownn file for the sample. Parameters: <cs_root> C# SDK repository root; <python_root> python SDK repository root; <package_name> Package name: one of Azure.AI.Projects, Azure.AI.Projects.Agents or Azure.AI.Extensions.OpenAI; <sample_name> The name of sample file in Python SDK repository."
---

# Basic information.
This skill require four inputs: <python_root> (repository root for python) and <cs_root> (repository root for C#), <package_name>  and <sample_name> the sample to be processed. the C# package name. All the consequent paths are given relatively to the repository root. Python package is located in <python_root>/sdk/ai/azure-ai-projects, C# project is located in <cs_root>/sdk/ai/<package_name>. All python samples are located in <python_root>/sdk/ai/azure-ai-projects/samples, they are organized by folders according to their topic. In most cases the sample has sync and async implementation. For example, `feature.py` and `feature_async.py` are demonstrating sync and async features. C# sample consists of two parts: the source code in the folder <cs_root>/sdk/ai/<package_name>/tests/Samples and corresponding .md files go to <cs_root>/sdk/ai/<package_name>/Samples.

# Instruction
Please analyze the sample provided sample in <sample_name> and generate the sample and .md file in C#. The C# file should demonstrate both sync and async API when appropriate. See the example below:

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

If the code block has sync and async counterpart, please create code block for each of them. Provide the short explanation for each code block. 
To make sure that it is the case, please run the script below. If there are errors, please iterate over it until the script will complete without errors.

```powershell
cd <cs_root>
eng\scripts\Update-Snippets.ps1 ai\<package>
```

```bash
cd <cs_root>
eng\scripts\Update-Snippets.ps1 ai\<package>
```
