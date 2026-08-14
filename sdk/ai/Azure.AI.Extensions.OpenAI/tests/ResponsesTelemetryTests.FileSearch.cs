// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;

namespace Azure.AI.Extensions.OpenAI.Tests;

public partial class ResponsesTelemetryTests
{
    private const string FileSearchAgentName = "filesearch-telemetry-agent";
    private const string FileSearchPrompt = "Can you give me the documented codes for 'banana' and 'orange'?";
    private const string FileSearchFileContent = "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.";

    #region File Search Helpers

    /// <summary>
    /// Uploads a temp file, creates a vector store, and returns the IDs needed for cleanup.
    /// </summary>
    private async Task<(string VectorStoreId, string FileId)> CreateFileSearchResourcesAsync(AIProjectClient projectClient)
    {
        string filePath = Path.Combine(Path.GetTempPath(), $"telemetry-test-filesearch-{Guid.NewGuid():N}.txt");

        OpenAIFile uploadedFile;
        try
        {
            File.WriteAllText(filePath, FileSearchFileContent);
            OpenAIFileClient fileClient = projectClient.ProjectOpenAIClient.GetOpenAIFileClient();
            uploadedFile = await fileClient.UploadFileAsync(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        }
        finally
        {
            File.Delete(filePath);
        }

        VectorStoreClient vectorStoreClient = projectClient.ProjectOpenAIClient.GetVectorStoreClient();
        VectorStore vectorStore = await vectorStoreClient.CreateVectorStoreAsync(new VectorStoreCreationOptions
        {
            Name = "TelemetryTestStore",
            FileIds = { uploadedFile.Id }
        });

        return (vectorStore.Id, uploadedFile.Id);
    }

    /// <summary>
    /// Creates an agent with a file search tool and returns the agent version.
    /// </summary>
    private async Task<ProjectsAgentVersion> CreateFileSearchAgentAsync(AIProjectClient projectClient, string agentName, string vectorStoreId)
    {
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can help fetch data from files you know about.",
            Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStoreId]) }
        };

        return await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName,
            new ProjectsAgentVersionCreationOptions(agentDefinition));
    }

    /// <summary>
    /// Cleans up file search resources (agent, vector store, file).
    /// </summary>
    private async Task CleanupFileSearchResourcesAsync(
        AIProjectClient projectClient,
        string agentName,
        string vectorStoreId,
        string fileId)
    {
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentName: agentName);
        await projectClient.ProjectOpenAIClient.GetVectorStoreClient().DeleteVectorStoreAsync(vectorStoreId);
        await projectClient.ProjectOpenAIClient.GetOpenAIFileClient().DeleteFileAsync(fileId);
    }

    /// <summary>
    /// Runs the file search non-streaming flow and returns the completed response.
    /// </summary>
    private async Task<ResponseResult> RunFileSearchNonStreamingAsync(ProjectResponsesClient client)
    {
        ResponseResult response = await client.CreateResponseAsync(FileSearchPrompt);
        return await WaitForRun(client, response);
    }

    /// <summary>
    /// Runs the file search streaming flow and returns the completed response.
    /// </summary>
    private async Task<ResponseResult> RunFileSearchStreamingAsync(ProjectResponsesClient client)
    {
        ResponseResult completedResponse = null;
        await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(FileSearchPrompt))
        {
            if (update is StreamingResponseCompletedUpdate completed)
            {
                completedResponse = completed.Response;
            }
        }
        Assert.That(completedResponse, Is.Not.Null, "Streaming should produce a completed response");
        return completedResponse;
    }

    /// <summary>
    /// Validates the span for a file search invocation.
    /// </summary>
    private void ValidateFileSearchSpan(
        string agentName,
        object agentVersion,
        bool contentRecordingEnabled)
    {
        _exporter.ForceFlush();

        var span = _exporter.GetExportedActivities()
            .FirstOrDefault(s => s.DisplayName == $"invoke_agent {agentName}");
        Assert.That(span, Is.Not.Null, $"Expected span 'invoke_agent {agentName}'");

        GenAiTraceVerifier.ValidateSpanAttributes(
            span,
            GetExpectedAgentAttributes(agentName, agentVersion),
            allowUnexpected: false);

        // --- Input messages ---
        string inputMessages = span.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(inputMessages, Does.Contain("\"role\":\"user\""));
        if (contentRecordingEnabled)
        {
            Assert.That(inputMessages, Does.Contain("\"content\":\"" + FileSearchPrompt + "\""));
        }
        else
        {
            Assert.That(inputMessages, Does.Not.Contain(FileSearchPrompt));
            Assert.That(inputMessages, Does.Contain("\"type\":\"text\""));
        }

        // --- Output messages ---
        string outputMessages = span.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages, Does.Contain("\"role\":\"assistant\""));

        // File search should produce a tool_call with file_search_call type
        Assert.That(outputMessages, Does.Contain("\"type\":\"tool_call\""));
        Assert.That(outputMessages, Does.Contain("\"type\":\"file_search_call\""));
        // The tool call id is always present (safe, non-PII metadata)
        Assert.That(outputMessages, Does.Contain("\"id\":"));

        if (contentRecordingEnabled)
        {
            // --- Tool call details ---
            // File search queries and status should be present
            Assert.That(outputMessages, Does.Contain("\"queries\":"));
            Assert.That(outputMessages, Does.Contain("\"status\":\"completed\""));

            // --- Assistant text response ---
            // The response should reference the known code for 'banana' (673457)
            // and indicate 'orange' is not found.
            Assert.That(outputMessages, Does.Contain("\"type\":\"text\",\"content\":"));
            Assert.That(outputMessages, Does.Contain("673457"));
            Assert.That(outputMessages, Does.Contain("\"finish_reason\":\"completed\""));
        }
        else
        {
            // --- Tool call details ---
            // Queries and status must be absent when content recording is off
            Assert.That(outputMessages, Does.Not.Contain("\"queries\":"));
            Assert.That(outputMessages, Does.Not.Contain("\"status\":"));

            // --- Assistant text response ---
            // The text part should have no content field and no actual response text
            Assert.That(outputMessages, Does.Not.Contain("\"type\":\"text\",\"content\":"));
            Assert.That(outputMessages, Does.Not.Contain("673457"));
            // But finish_reason is always emitted (non-PII metadata)
            Assert.That(outputMessages, Does.Contain("\"finish_reason\":\"completed\""));
        }
    }

    /// <summary>
    /// Shared implementation for all file search telemetry test variants.
    /// </summary>
    private async Task RunFileSearchTelemetryTestAsync(bool contentRecordingEnabled, bool streaming)
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, contentRecordingEnabled ? "true" : "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var agentName = $"{FileSearchAgentName}-{(streaming ? "stream" : "nonstream")}-{(contentRecordingEnabled ? "on" : "off")}";

        var (vectorStoreId, fileId) = await CreateFileSearchResourcesAsync(projectClient);
        ProjectsAgentVersion agentVersion = await CreateFileSearchAgentAsync(projectClient, agentName, vectorStoreId);

        try
        {
            AgentReference agentRef = new(agentVersion.Name, agentVersion.Version);
            ProjectResponsesClient client = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentRef);

            if (streaming)
            {
                await RunFileSearchStreamingAsync(client);
            }
            else
            {
                await RunFileSearchNonStreamingAsync(client);
            }

            ValidateFileSearchSpan(agentName, agentVersion.Version, contentRecordingEnabled);
        }
        finally
        {
            await CleanupFileSearchResourcesAsync(projectClient, agentName, vectorStoreId, fileId);
        }
    }

    #endregion

    #region File Search Non-streaming tests

    [RecordedTest]
    [Ignore("File upload multipart body contains machine-specific temp path, causing recording playback mismatch across environments.")]
    public async Task TestFileSearchWithContentRecordingEnabled()
    {
        await RunFileSearchTelemetryTestAsync(contentRecordingEnabled: true, streaming: false);
    }

    [RecordedTest]
    [Ignore("File upload multipart body contains machine-specific temp path, causing recording playback mismatch across environments.")]
    public async Task TestFileSearchWithContentRecordingDisabled()
    {
        await RunFileSearchTelemetryTestAsync(contentRecordingEnabled: false, streaming: false);
    }

    #endregion

    #region File Search Streaming tests

    [RecordedTest]
    [Ignore("File upload multipart body contains machine-specific temp path, causing recording playback mismatch across environments.")]
    public async Task TestFileSearchStreamingWithContentRecordingEnabled()
    {
        await RunFileSearchTelemetryTestAsync(contentRecordingEnabled: true, streaming: true);
    }

    [RecordedTest]
    [Ignore("File upload multipart body contains machine-specific temp path, causing recording playback mismatch across environments.")]
    public async Task TestFileSearchStreamingWithContentRecordingDisabled()
    {
        await RunFileSearchTelemetryTestAsync(contentRecordingEnabled: false, streaming: true);
    }

    #endregion
}
