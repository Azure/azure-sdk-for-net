// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

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
        var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        var hostedAgentVersion = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_VERSION");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var hostedAgentName = TestEnvironment.HOSTED_AGENT_NAME;
        var hostedAgentVersion = TestEnvironment.HOSTED_AGENT_VERSION;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview,AgentEndpoints=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        AgentSessionFiles sessionClient = agentsClient.GetAgentSessionFiles();
        #endregion
        #region Snippet:Sample_CreateAgentAndSession_SessionFiles_Async
        ProjectsAgentVersion agentVersion = await agentsClient.GetAgentVersionAsync(
            agentName: hostedAgentName,
            agentVersion: hostedAgentVersion);
        string sessionKey = Guid.NewGuid().ToString("N");
        string sessionId = Guid.NewGuid().ToString("N");
        ProjectAgentSession session = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
            agentSessionId: sessionId,
            isolationKey: sessionKey,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        while (session.Status != AgentSessionStatus.Failed && session.Status != AgentSessionStatus.Active)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            session = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
        }
        #endregion
        #region Snippet:Sample_Upload_SessionFiles_Async
        string filePath = "sample_file_for_upload1.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        SessionFileWriteResponse writeResponse = await sessionClient.UploadSessionFileAsync(
                agentName: agentVersion.Name,
                sessionId: session.AgentSessionId,
                sessionStoragePath: filePath,
                localPath: filePath
            );
        Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
        File.Delete(filePath);
        filePath = "sample_file_for_upload2.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'grape' uses the code 111222, while the word 'mango' uses the code 222111.");
        writeResponse = await sessionClient.UploadSessionFileAsync(
            agentName: agentVersion.Name,
            sessionId: session.AgentSessionId,
            sessionStoragePath: $"{filePath}",
            localPath: filePath
        );
        Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
        File.Delete(filePath);
        #endregion
        #region Snippet:Sample_List_SessionFiles_Async
        SessionDirectoryListResponse response = await sessionClient.GetSessionFilesAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, sessionStoragePath: ".");
        Console.WriteLine($"The path {response.Path} contains the next files:");
        foreach (SessionDirectoryEntry entry in response.Entries)
        {
            Console.WriteLine($"    - {entry.Name}, size {entry.Size}");
        }
        #endregion

        #region Snippet:Sample_Download_SessionFiles_Async
        filePath = "saved.txt";
        await sessionClient.DownloadSessionFileAsync(
            agentName: agentVersion.Name,
            sessionId: session.AgentSessionId,
            sessionStoragePath: "sample_file_for_upload1.txt",
            localPath: filePath
        );
        Console.WriteLine($"Download file contents: {File.ReadAllText(filePath)}");
        File.Delete(filePath);
        #endregion

        #region Snippet:Sample_DeleteFiles_SessionFiles_Async
        await sessionClient.DeleteSessionFileAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, path: "sample_file_for_upload1.txt");
        await sessionClient.DeleteSessionFileAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, path: "sample_file_for_upload2.txt");
        await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, isolationKey: sessionKey);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void SessionFilesSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        var hostedAgentVersion = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_VERSION");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var hostedAgentName = TestEnvironment.HOSTED_AGENT_NAME;
        var hostedAgentVersion = TestEnvironment.HOSTED_AGENT_VERSION;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview"), PipelinePosition.PerCall);
        options.AddPolicy(GetDumpPolicy(), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        AgentSessionFiles sessionClient = agentsClient.GetAgentSessionFiles();
        #region Snippet:Sample_CreateAgentAndSession_SessionFiles_Sync
        ProjectsAgentVersion agentVersion = agentsClient.GetAgentVersion(
            agentName: hostedAgentName,
            agentVersion: hostedAgentVersion);
        string sessionKey = Guid.NewGuid().ToString();
        string sessionId = Guid.NewGuid().ToString();
        ProjectAgentSession session = agentsClient.CreateSession(
            agentName: agentVersion.Name,
            agentSessionId: sessionId,
            isolationKey: sessionKey,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        while (session.Status != AgentSessionStatus.Failed && session.Status != AgentSessionStatus.Active)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            session = agentsClient.GetSession(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
        }
        #endregion
        #region Snippet:Sample_Upload_SessionFiles_Sync
        string filePath = "sample_file_for_upload1.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");

        SessionFileWriteResponse writeResponse = sessionClient.UploadSessionFile(
            agentName: agentVersion.Name,
            sessionId: session.AgentSessionId,
            sessionStoragePath: filePath,
            localPath: filePath
        );
        Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
        File.Delete(filePath);
        filePath = "sample_file_for_upload2.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'grape' uses the code 111222, while the word 'mango' uses the code 222111.");
        writeResponse = sessionClient.UploadSessionFile(
            agentName: agentVersion.Name,
            sessionId: session.AgentSessionId,
            sessionStoragePath: filePath,
            localPath: filePath
        );
        Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
        File.Delete(filePath);
        #endregion
        #region Snippet:Sample_List_SessionFiles_Sync
        SessionDirectoryListResponse response = sessionClient.GetSessionFiles(agentName: agentVersion.Name, sessionId: session.AgentSessionId, sessionStoragePath: ".");
        Console.WriteLine($"The path {response.Path} contains the next files:");
        foreach (SessionDirectoryEntry entry in response.Entries)
        {
            Console.WriteLine($"    - {entry.Name}, size {entry.Size}");
        }
        #endregion

        #region Snippet:Sample_Download_SessionFiles_Sync
        filePath = "saved.txt";
        sessionClient.DownloadSessionFile(
            agentName: agentVersion.Name,
            sessionId: session.AgentSessionId,
            sessionStoragePath: "sample_file_for_upload1.txt",
            localPath: filePath
        );
        Console.WriteLine($"Download file contents: {File.ReadAllText(filePath)}");
        File.Delete(filePath);
        #endregion

        #region Snippet:Sample_DeleteFiles_SessionFiles_Sync
        sessionClient.DeleteSessionFile(agentName: agentVersion.Name, sessionId: session.AgentSessionId, path: "sample_file_for_upload1.txt");
        sessionClient.DeleteSessionFile(agentName: agentVersion.Name, sessionId: session.AgentSessionId, path: "sample_file_for_upload2.txt");
        agentsClient.DeleteSession(agentName: agentVersion.Name, sessionId: session.AgentSessionId, isolationKey: sessionKey);
        #endregion
    }

    public Sample_SessionFiles(bool isAsync) : base(isAsync)
    { }
}
