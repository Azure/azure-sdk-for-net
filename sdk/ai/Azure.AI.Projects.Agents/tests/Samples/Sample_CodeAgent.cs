// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.Samples;
# pragma warning disable AAIP001
public class Sample_CodeAgent : SamplesBase
{
    protected static string GetDirectory(string path, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine([dirName, path]);
    }

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
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
#endif
        try
        {
            Directory.Delete(Path.GetFullPath("./AgentCode"), recursive: true);
        }
        catch { }
        #region Snippet:Sample_CodeAgentDeployment_CodeAgent_Async
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview,CodeAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionFromCodeAsync(
            agentName: "myCodeAgent",
            filePath: GetDirectory(Path.Combine(["AgentsCode"])),
            metadata: GetAgentMetadata()
        );
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            await Task.Delay(500);
            agentVersion = await agentsClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        #endregion
        string downloadPath = Path.GetFullPath("./AgentCode");
        await agentsClient.DownloadAgentCodeAsync(agentName: agentVersion.Name, path: downloadPath);
        Console.WriteLine($"The Agent code was downloaded to {downloadPath}");
        await agentsClient.DeleteAgentAsync(agentVersion.Name, force: true);
    }

    [Test]
    [SyncOnly]
    public void CodeAgentCreateSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
#endif
        try
        {
            Directory.Delete(Path.GetFullPath("./AgentCode"), recursive: true);
        }
        catch { }
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview,CodeAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersionFromCode(
            agentName: "myCodeAgent",
            filePath: GetDirectory(Path.Combine(["AgentsCode"])),
            metadata: GetAgentMetadata()
        );
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            Thread.Sleep(500);
            agentVersion = agentsClient.GetAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        string downloadPath = Path.GetFullPath("./AgentCode");
        agentsClient.DownloadAgentCode(agentName: agentVersion.Name, path: downloadPath);
        Console.WriteLine($"The Agent code was downloaded to {downloadPath}");
        agentsClient.DeleteAgent(agentVersion.Name, force: true);
    }

    public Sample_CodeAgent(bool isAsync) : base(isAsync)
    { }
}
