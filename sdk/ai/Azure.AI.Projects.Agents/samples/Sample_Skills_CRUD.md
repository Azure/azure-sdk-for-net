# Sample for skills Administration (create, retrieve, update and delete) in Azure.AI.Projects.Agents

In this example we will demonstrate how to create, update and delete [skills](https://learn.microsoft.com/agent-framework/agents/skills).
To use skills, we need to provide the `Foundry-Features` header in our REST requests. It can be done using `PipelinePolicy`.

```C# Snippet:Sample_Agents_ExperimentalHeader
internal class FeaturePolicy(string feature) : PipelinePolicy
{
    private const string _FEATURE_HEADER = "Foundry-Features";

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
```

We also need to ignore the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

1. First, we need to create `AgentSkills` client and read the environment variables, which will be used in the next steps. We also will add the experimental header policy to the client.

```C# Snippet:Sample_CreateClient_SkillsCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AgentAdministrationClientOptions options = new();
options.AddPolicy(new FeaturePolicy("Skills=V1Preview"), PipelinePosition.PerCall);
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
```

2. Skills can be created dynamically or loaded from the directory. To get the path to the directories, located at the sources folder we will define `GetDirectory` method.

```C# Snippet:Sample_GetDirectory_SkillsCRUD
protected static string GetDirectory(string fileName, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return Path.Combine([dirName, fileName]);
}
```

3. Use the client to create two `AgentsSkill` objects.

Synchronous sample:
```C# Snippet:Sample_CreateSkill_SkillsCRUD_Sync
AgentsSkill skillFromFile = skillsClient.CreateSkillFromPackage(GetDirectory("roll-dice"));
Console.WriteLine($"Created skillfrom directory {skillFromFile.Name}, Id: {skillFromFile.SkillId}");
AgentsSkill simpleSkill = skillsClient.CreateSkill(name: "simpleSkill", description: "Calculates the sum of two numbers.", instructions: """
    To calculate the sum  run
    bash:
    echo $((<first> + <second>))
    powershell:
    (<first> + <second>)
    Replace <first> and <second> by the actual summation arguments.
""");
Console.WriteLine($"Created skill {simpleSkill.Name}: {simpleSkill.Description}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateSkill_SkillsCRUD_Async
AgentsSkill skillFromFile = await skillsClient.CreateSkillFromPackageAsync(GetDirectory("roll-dice"));
Console.WriteLine($"Created skillfrom directory {skillFromFile.Name}, Id: {skillFromFile.SkillId}");
AgentsSkill simpleSkill = await skillsClient.CreateSkillAsync(name: "simpleSkill", description: "Calculates the sum of two numbers.", instructions: """
    To calculate the sum  run
    bash:
    echo $((<first> + <second>))
    powershell:
    (<first> + <second>)
    Replace <first> and <second> by the actual summation arguments.
""");
Console.WriteLine($"Created skill {simpleSkill.Name}: {simpleSkill.Description}");
```

4. Retrieve the `AgentsSkill` object.

Synchronous sample:
```C# Snippet:Sample_GetSkill_SkillsCRUD_Sync
AgentsSkill skill = skillsClient.GetSkill(name: skillFromFile.Name);
Console.WriteLine($"Retrieved skill: {skill.Name}, Id: {skill.Description}");
```

Asynchronous sample:
```C# Snippet:Sample_GetSkill_SkillsCRUD_Async
AgentsSkill skill = await skillsClient.GetSkillAsync(name: skillFromFile.Name);
Console.WriteLine($"Retrieved skill: {skill.Name}, Id: {skill.Description}");
```

5. Download the skill.

Synchronous sample:
```C# Snippet:Sample_DownloadSkill_SkillsCRUD_Sync
string savePath = Path.GetFullPath("saved_skill");
skillsClient.DownloadSkill(skillFromFile.Name, savePath);
Console.WriteLine($"The skill was saved to the path {savePath}.");
```

Asynchronous sample:
```C# Snippet:Sample_DownloadSkill_SkillsCRUD_Async
string savePath = Path.GetFullPath("saved_skill");
await skillsClient.DownloadSkillAsync(skillFromFile.Name, savePath);
Console.WriteLine($"The skill was saved to the path {savePath}.");
```

6. To update skills, we can use `UpdateSkillAsync` or `UpdateSkill` methods.

Synchronous sample:
```C# Snippet:Sample_UpdateToolbox_SkillsCRUD_Sync
skill = skillsClient.UpdateSkill(name: "simpleSkill", description: "Calculates the product of two numbers.", instructions: """
    To calculate the sum  run
    bash:
    echo $((<first> * <second>))
    powershell
    (<first> * <second>)
    Replace <first> and <second> by the actual summation arguments.
""");
Console.WriteLine($"The skill {skill.Name} now has the following description: {skill.Description}");
```

Asynchronous sample:
```C# Snippet:Sample_UpdateToolbox_SkillsCRUD_Async
skill = await skillsClient.UpdateSkillAsync(name: "simpleSkill", description: "Calculates the product of two numbers.", instructions: """
    To calculate the sum  run
    bash:
    echo $((<first> * <second>))
    powershell:
    (<first> * <second>)
    Replace <first> and <second> by the actual summation arguments.
""");
Console.WriteLine($"The skill {skill.Name} now has the following description: {skill.Description}");
```

7. List all the skills.

Synchronous sample:
```C# Snippet:Sample_ListSkills_SkillsCRUD_Sync
List<AgentsSkill> skills = [.. skillsClient.GetSkills()];
Console.WriteLine($"Found {skills.Count} skills.");
foreach (AgentsSkill item in skills)
{
    Console.WriteLine($"  - {item.SkillId} ({item.Name})");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListSkills_SkillsCRUD_Async
List<AgentsSkill> skills = await skillsClient.GetSkillsAsync().ToListAsync();
Console.WriteLine($"Found {skills.Count} skills.");
foreach (AgentsSkill item in skills)
{
    Console.WriteLine($"  - {item.SkillId} ({item.Name})");
}
```

8. Finally, remove skills we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteSkills_SkillsCRUD_Sync
skillsClient.DeleteSkill(skillFromFile.Name);
skillsClient.DeleteSkill(simpleSkill.Name);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteSkills_SkillsCRUD_Async
await skillsClient.DeleteSkillAsync(skillFromFile.Name);
await skillsClient.DeleteSkillAsync(simpleSkill.Name);
```
