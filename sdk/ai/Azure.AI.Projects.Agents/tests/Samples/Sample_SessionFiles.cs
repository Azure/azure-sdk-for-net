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
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgentAndSession_SessionFiles_Async
        ProjectsAgentVersion agentVersion = await agentsClient.GetAgentVersionAsync(
            agentName: hostedAgentName,
            agentVersion: hostedAgentVersion);
        string sessionId = Guid.NewGuid().ToString("N");
        ProjectAgentSession session = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
            agentSessionId: sessionId,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        AgentSessionFiles sessionClient = agentsClient.GetAgentSessionFiles(agentVersion.Name, session.AgentSessionId);
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
        SessionFileWriteResponse writeResponse = await sessionClient.UploadAsync(
                sessionStoragePath: filePath,
                localPath: filePath
            );
        Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
        File.Delete(filePath);
        filePath = "sample_file_for_upload2.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'grape' uses the code 111222, while the word 'mango' uses the code 222111.");
        writeResponse = await sessionClient.UploadAsync(
            sessionStoragePath: $"{filePath}",
            localPath: filePath
        );
        Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
        File.Delete(filePath);
        #endregion
        #region Snippet:Sample_List_SessionFiles_Async
        AsyncCollectionResult<SessionDirectoryEntry> response = sessionClient.GetAllAsync(sessionStoragePath: ".");
        Console.WriteLine($"The path contains the next files:");
        await foreach (SessionDirectoryEntry entry in response)
        {
            Console.WriteLine($"    - {entry.Name}, size {entry.SizeInBytes}");
        }
        #endregion

        #region Snippet:Sample_Download_SessionFiles_Async
        filePath = "saved.txt";
        await sessionClient.DownloadAsync(
            sessionStoragePath: "sample_file_for_upload1.txt",
            localPath: filePath
        );
        Console.WriteLine($"Download file contents: {File.ReadAllText(filePath)}");
        File.Delete(filePath);
        #endregion

        #region Snippet:Sample_DeleteFiles_SessionFiles_Async
        await sessionClient.DeleteAsync(localPath: "sample_file_for_upload1.txt");
        await sessionClient.DeleteAsync(localPath: "sample_file_for_upload2.txt");
        await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
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
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateAgentAndSession_SessionFiles_Sync
        ProjectsAgentVersion agentVersion = agentsClient.GetAgentVersion(
            agentName: hostedAgentName,
            agentVersion: hostedAgentVersion);
        string sessionId = Guid.NewGuid().ToString();
        ProjectAgentSession session = agentsClient.CreateSession(
            agentName: agentVersion.Name,
            agentSessionId: sessionId,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        AgentSessionFiles sessionClient = agentsClient.GetAgentSessionFiles(agentVersion.Name, session.AgentSessionId);
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

        SessionFileWriteResponse writeResponse = sessionClient.Upload(
            sessionStoragePath: filePath,
            localPath: filePath
        );
        Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
        File.Delete(filePath);
        filePath = "sample_file_for_upload2.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'grape' uses the code 111222, while the word 'mango' uses the code 222111.");
        writeResponse = sessionClient.Upload(
            sessionStoragePath: filePath,
            localPath: filePath
        );
        Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
        File.Delete(filePath);
        #endregion
        #region Snippet:Sample_List_SessionFiles_Sync
        CollectionResult<SessionDirectoryEntry> response = sessionClient.GetAll(sessionStoragePath: ".");
        Console.WriteLine($"The path contains the next files:");
        foreach (SessionDirectoryEntry entry in response)
        {
            Console.WriteLine($"    - {entry.Name}, size {entry.SizeInBytes}");
        }
        #endregion

        #region Snippet:Sample_Download_SessionFiles_Sync
        filePath = "saved.txt";
        sessionClient.Download(
            sessionStoragePath: "sample_file_for_upload1.txt",
            localPath: filePath
        );
        Console.WriteLine($"Download file contents: {File.ReadAllText(filePath)}");
        File.Delete(filePath);
        #endregion

        #region Snippet:Sample_DeleteFiles_SessionFiles_Sync
        sessionClient.Delete(localPath: "sample_file_for_upload1.txt");
        sessionClient.Delete(localPath: "sample_file_for_upload2.txt");
        agentsClient.DeleteSession(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
        #endregion
    }

    public Sample_SessionFiles(bool isAsync) : base(isAsync)
    { }
}
