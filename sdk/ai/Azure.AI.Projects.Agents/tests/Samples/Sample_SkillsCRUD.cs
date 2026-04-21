// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_Skills_CRUD : SamplesBase
{
    private static void DeleteSkillMaybe(ProjectAgentSkills client, string name)
    {
        try
        {
            client.DeleteSkill(name);
        }
        catch { }
    }
    #region Snippet:Sample_GetDirectory_SkillsCRUD
    protected static string GetDirectory(string fileName, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine([dirName, fileName]);
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task SkillsCRUDAsync()
    {
        #region Snippet:Sample_CreateClient_SkillsCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("Skills=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
        #endregion
        DeleteSkillMaybe(skillsClient, "roll-dice");
        DeleteSkillMaybe(skillsClient, "simpleSkill");
        #region Snippet:Sample_CreateSkill_SkillsCRUD_Async
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
        #endregion

        #region Snippet:Sample_GetSkill_SkillsCRUD_Async
        AgentsSkill skill = await skillsClient.GetSkillAsync(name: skillFromFile.Name);
        Console.WriteLine($"Retrieved skill: {skill.Name}, Id: {skill.Description}");
        #endregion
        if (Directory.Exists(Path.GetFullPath("saved_skill")))
        {
            Directory.Delete(Path.GetFullPath("saved_skill"), true);
        }
        #region Snippet:Sample_DownloadSkill_SkillsCRUD_Async
        string savePath = Path.GetFullPath("saved_skill");
        await skillsClient.DownloadSkillAsync(skillFromFile.Name, savePath);
        Console.WriteLine($"The skill was saved to the path {savePath}.");
        #endregion

        #region Snippet:Sample_UpdateToolbox_SkillsCRUD_Async
        skill = await skillsClient.UpdateSkillAsync(name: "simpleSkill", description: "Calculates the product of two numbers.", instructions: """
            To calculate the sum  run
            bash:
            echo $((<first> * <second>))
            powershell:
            (<first> * <second>)
            Replace <first> and <second> by the actual summation arguments.
        """);
        Console.WriteLine($"The skill {skill.Name} now has the following description: {skill.Description}");
        #endregion

        #region Snippet:Sample_ListSkills_SkillsCRUD_Async
        List<AgentsSkill> skills = await skillsClient.GetSkillsAsync().ToListAsync();
        Console.WriteLine($"Found {skills.Count} skills.");
        foreach (AgentsSkill item in skills)
        {
            Console.WriteLine($"  - {item.SkillId} ({item.Name})");
        }
        #endregion

        #region Snippet:Sample_DeleteSkills_SkillsCRUD_Async
        await skillsClient.DeleteSkillAsync(skillFromFile.Name);
        await skillsClient.DeleteSkillAsync(simpleSkill.Name);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void SkillsCRUDSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("Skills=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
        DeleteSkillMaybe(skillsClient, "roll-dice");
        DeleteSkillMaybe(skillsClient, "simpleSkill");
        #region Snippet:Sample_CreateSkill_SkillsCRUD_Sync
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
        #endregion

        #region Snippet:Sample_GetSkill_SkillsCRUD_Sync
        AgentsSkill skill = skillsClient.GetSkill(name: skillFromFile.Name);
        Console.WriteLine($"Retrieved skill: {skill.Name}, Id: {skill.Description}");
        #endregion
        if (Directory.Exists(Path.GetFullPath("saved_skill")))
        {
            Directory.Delete(Path.GetFullPath("saved_skill"), true);
        }
        #region Snippet:Sample_DownloadSkill_SkillsCRUD_Sync
        string savePath = Path.GetFullPath("saved_skill");
        skillsClient.DownloadSkill(skillFromFile.Name, savePath);
        Console.WriteLine($"The skill was saved to the path {savePath}.");
        #endregion

        #region Snippet:Sample_UpdateToolbox_SkillsCRUD_Sync
        skill = skillsClient.UpdateSkill(name: "simpleSkill", description: "Calculates the product of two numbers.", instructions: """
            To calculate the sum  run
            bash:
            echo $((<first> * <second>))
            powershell
            (<first> * <second>)
            Replace <first> and <second> by the actual summation arguments.
        """);
        Console.WriteLine($"The skill {skill.Name} now has the following description: {skill.Description}");
        #endregion

        #region Snippet:Sample_ListSkills_SkillsCRUD_Sync
        List<AgentsSkill> skills = [.. skillsClient.GetSkills()];
        Console.WriteLine($"Found {skills.Count} skills.");
        foreach (AgentsSkill item in skills)
        {
            Console.WriteLine($"  - {item.SkillId} ({item.Name})");
        }
        #endregion

        #region Snippet:Sample_DeleteSkills_SkillsCRUD_Sync
        skillsClient.DeleteSkill(skillFromFile.Name);
        skillsClient.DeleteSkill(simpleSkill.Name);
        #endregion
    }

    public Sample_Skills_CRUD(bool isAsync) : base(isAsync)
    { }
}
