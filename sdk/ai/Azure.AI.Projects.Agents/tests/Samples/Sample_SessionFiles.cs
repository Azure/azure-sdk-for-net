using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_SessionFiles : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task SessionFilesAsync()
    {
        #region Snippet:Sample_CreateClient_SessionFiles
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("Toolboxes=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        AgentSessionFiles sessionClient = agentsClient.GetAgentSessionFiles();
        string toolboxName = "mcp";
        #endregion
        #region Snippet:Sample_CreateAgent_SessionFiles_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        sessionClient.UploadSessionFileAsync()
        #endregion

        #region Snippet:Sample_GetToolbox_SessionFiles_Async
        ToolboxRecord record = await toolboxClient.GetToolboxAsync(toolboxName: toolBox1.Name);
        Console.WriteLine($"The default version for a toolbox {record.Name} is {record.DefaultVersion}");
        #endregion

        #region Snippet:Sample_GetToolboxVersion_SessionFiles_Async
        ToolboxVersion toolBox = await toolboxClient.GetToolboxVersionAsync(record.Name, record.DefaultVersion);
        Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
        #endregion

        #region Snippet:Sample_UpdateToolbox_SessionFiles_Async
        string newVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
        record = await toolboxClient.UpdateToolboxAsync(toolboxName, newVersion);
        Console.WriteLine($"The default version for a toolbox {record.Name} is now {record.DefaultVersion}");
        #endregion

        #region Snippet:Sample_ListToolboxVersions_SessionFiles_Async
        List<ToolboxVersion> toolboxes = await toolboxClient.GetToolboxVersionsAsync(toolBox.Name).ToListAsync();
        Console.WriteLine($"Found {toolboxes.Count} toolbox version(s).");
        foreach (ToolboxVersion item in toolboxes)
        {
            Console.WriteLine($"  - {item.Name} ({item.Version})");
        }
        #endregion

        #region Snippet:Sample_ListToolboxes_SessionFiles_Async
        List<ToolboxRecord> records = await toolboxClient.GetToolboxesAsync().ToListAsync();
        Console.WriteLine($"Found {records.Count} toolbox(es).");
        foreach (ToolboxRecord item in records)
        {
            Console.WriteLine($"  - {item.Name} ({item.Id})");
        }
        #endregion

        #region Snippet:Sample_DeleteToolbox_SessionFiles_Async
        // We cannot delete the default version.
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_Toolboxes_CRUD(bool isAsync) : base(isAsync)
    { }
}
