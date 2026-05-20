// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

# pragma warning disable AAIP001
public class Sample_CodeAgent : ProjectsOpenAITestBase
{
    #region Snippet:Sample_GetPath_CodeAgent
    protected static string GetDirectory(string path, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine([dirName, path]);
    }
    #endregion

    #region Snippet:Sample_CodeAgentMetadata_CodeAgent
    private static CreateAgentVersionFromCodeMetadata GetAgentMetadata()
    {
        HostedAgentDefinition agentDefinition = new(
            versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0")],
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            CodeConfiguration = new(
                runtime: "python_3_11",
                entryPoint: ["python", "main.py"],
                dependencyResolution: CodeDependencyResolution.Bundled
            ),
        };
        CreateAgentVersionFromCodeMetadata metadata = new(agentDefinition);
        metadata.Metadata["enableVnextExperience"] = "true";
        return metadata;
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task CodeAgentCreateAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_CodeAgent
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        DefaultAzureCredential credential = new();
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: credential);
        #endregion

        #region Snippet:Sample_CreateAgent_CodeAgent_Async
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionFromCodeAsync(
            agentName: "myCodeAgent",
            filePath: GetDirectory(Path.Combine(["Assets", "AgentsCode"])),
            metadata: GetAgentMetadata(),
            contentType: "application/json"
        );
        #endregion
        #region Snippet:Sample_WaitForDeployment_CodeAgent_Async
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            await Task.Delay(500);
            agentVersion = await projectClient.AgentAdministrationClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        #endregion
        #region Snippet:Sample_GetResponseFromAgent_CodeAgent_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:DeleteCodeAgent_CodeAgent_Async
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name);
        #endregion
    }

    public Sample_CodeAgent(bool isAsync) : base(isAsync)
    { }
}
