// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            ProtocolVersions = { new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0") },
            CodeConfiguration = new(
                runtime: "python_3_14",
                entryPoint: ["python", "main.py"],
                dependencyResolution: CodeDependencyResolution.RemoteBuild
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
        AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        try
        {
            Directory.Delete(Path.GetFullPath("./AgentCode"), recursive: true);
        }
        catch { }
        #region Snippet:Sample_CreateAgent_CodeAgent_Async
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionFromCodeAsync(
            agentName: "myCodeAgent",
            filePath: GetDirectory(Path.Combine(["Assets", "AgentsCode"])),
            metadata: GetAgentMetadata()
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
        try
        {
            ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
            ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");

            Console.WriteLine(response.GetOutputText());
        }
        catch (ClientResultException e)
        {
            MatchCollection session = Regex.Matches(e.Message, "'[^']+'");
            if (e.Status == 424 && e.Message.IndexOf("session_not_ready", StringComparison.OrdinalIgnoreCase) !=-1 && session.Count > 0)
            {
                SessionLogEvent logEvent = await projectClient.AgentAdministrationClient.GetSessionLogStreamAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version, sessionId: session[0].Value.Trim('\''));
                Console.WriteLine(logEvent.Data);
            }
            throw;
        }
        #endregion
        #region Snippet:Sample_DownloadCode_CodeAgent_Async
        string downloadPath = Path.GetFullPath("./AgentCode");
        await projectClient.AgentAdministrationClient.DownloadAgentCodeAsync(agentName: agentVersion.Name, path: downloadPath);
        Console.WriteLine($"The Agent code was downloaded to {downloadPath}");
        #endregion
        #region Snippet:DeleteCodeAgent_CodeAgent_Async
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void CodeAgentCreateSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
#endif
        AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        try
        {
            Directory.Delete(Path.GetFullPath("./AgentCode"), recursive: true);
        }
        catch { }
        #region Snippet:Sample_CreateAgent_CodeAgent_Sync
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersionFromCode(
            agentName: "myCodeAgent",
            filePath: GetDirectory(Path.Combine(["Assets", "AgentsCode"])),
            metadata: GetAgentMetadata()
        );
        #endregion
        #region Snippet:Sample_WaitForDeployment_CodeAgent_Sync
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            Thread.Sleep(500);
            agentVersion = projectClient.AgentAdministrationClient.GetAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        #endregion
        #region Snippet:Sample_GetResponseFromAgent_CodeAgent_Sync
        try
        {
            ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
            ResponseResult response = responseClient.CreateResponse("Hello, tell me a joke.");

            Console.WriteLine(response.GetOutputText());
        }
        catch (ClientResultException e)
        {
            MatchCollection session = Regex.Matches(e.Message, "'[^']+'");
            if (e.Status == 424 && e.Message.IndexOf("session_not_ready", StringComparison.OrdinalIgnoreCase) != -1 && session.Count > 0)
            {
                SessionLogEvent logEvent = projectClient.AgentAdministrationClient.GetSessionLogStream(agentName: agentVersion.Name, agentVersion: agentVersion.Version, sessionId: session[0].Value.Trim('\''));
                Console.WriteLine(logEvent.Data);
            }
            throw;
        }
        #endregion
        #region Snippet:Sample_DownloadCode_CodeAgent_Sync
        string downloadPath = Path.GetFullPath("./AgentCode");
        projectClient.AgentAdministrationClient.DownloadAgentCode(agentName: agentVersion.Name, path: downloadPath);
        Console.WriteLine($"The Agent code was downloaded to {downloadPath}");
        #endregion
        #region Snippet:DeleteCodeAgent_CodeAgent_Sync
        projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
        #endregion
    }

    public Sample_CodeAgent(bool isAsync) : base(isAsync)
    { }
}
