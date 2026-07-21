// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Memory;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_CodeAgentReminderTool : ProjectsOpenAITestBase
{
    #region Snippet:Sample_GetPath_CodeAgentReminderTool
    protected static string GetDirectory(string path, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine([dirName, path]);
    }
    #endregion
    #region Snippet:Sample_SessionHeaderPolicy_CodeAgentReminderTool
    private class SessionHeaderPolicy(string agentSessionID) : PipelinePolicy
    {
        private static readonly string _SESSION_HEADER = "x-agent-session-id";
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            message.Request.Headers.Add(_SESSION_HEADER, agentSessionID);
            ProcessNext(message, pipeline, currentIndex);
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            message.Request.Headers.Add(_SESSION_HEADER, agentSessionID);
            await ProcessNextAsync(message, pipeline, currentIndex);
        }
    }
    #endregion
    #region Snippet:Sample_CheckRunResult_CodeAgentReminderTool
    protected static void CheckRunResult(RoutineRun completedRun, int minutesWait, bool runCreated)
    {
        if (completedRun == null)
        {
            if (runCreated)
            {
                throw new InvalidOperationException($"The run did not complete within {minutesWait} minutes.");
            }
            else
            {
                throw new InvalidOperationException("The run was not created.");
            }
        }
        if (string.Equals(completedRun.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException("The run was forcefully stopped.");
        }
        if (string.Equals(completedRun.Status, "failed", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException($"The run has failed with the error. Type: {completedRun.ErrorType} Message: {completedRun.ErrorMessage}.");
        }
    }
    #endregion
    #region Snippet:Sample_CodeAgentReminderToolMetadata_CodeAgentReminderTool
    private static AgentVersionFromCodeMetadata GetAgentMetadata(string middlewareAgentName, string toolboxName, string foundryProjectEndpoint, string modelDeploymentName)
    {
        HostedAgentDefinition agentDefinition = new(
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            Versions = { new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "2.0.0") },
            CodeConfiguration = new(
                runtime: "python_3_14",
                entryPoint: ["python", "main.py"],
                dependencyResolution: CodeDependencyResolution.RemoteBuild
            ),
            EnvironmentVariables = {
                { "AGENT_NAME", middlewareAgentName},
                { "TOOLBOX_NAME", toolboxName},
                { "FOUNDRY_PROJECT_ENDPOINT", foundryProjectEndpoint},
                { "FOUNDRY_MODEL_NAME", modelDeploymentName },
            }
        };
        AgentVersionFromCodeMetadata metadata = new(agentDefinition);
        metadata.Metadata["enableVnextExperience"] = "true";
        return metadata;
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task CodeAgentReminderToolCreateAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_CodeAgentReminderTool
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        #endregion
        #region Snippet:Sample_CreateToolbox_CodeAgentReminderTool_Async
        ToolboxVersion toolBox = await toolboxClient.CreateVersionAsync(
            name: "toolboxWithTheReminder",
            tools: [new ReminderPreviewToolboxTool()],
            description: "The toolbox with a reminder tool."
        );
        Console.WriteLine($"Created a toolbox {toolBox.Name} v. {toolBox.Version}.");
        #endregion
        #region Snippet:Sample_CreateAgent_CodeAgentReminderTool_Async
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionFromCodeAsync(
            agentName: "myCodeAgentReminderTool",
            filePath: GetDirectory(Path.Combine(["Assets", "AgentsCodeToolbox"])),
            metadata: GetAgentMetadata(
                middlewareAgentName: "codeAgentMiddleware1",
                toolboxName: toolBox.Name,
                foundryProjectEndpoint: projectEndpoint,
                modelDeploymentName: modelDeploymentName
            )
        );
        #endregion
        #region Snippet:Sample_WaitForDeployment_CodeAgentReminderTool_Async
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
        #region Snippet:Sample_WaitForSession_CodeAgentReminderTool_Async
        string prompt = "Please remind me to go to lunch after one minute.";
        DateTimeOffset responseTime;
        ProjectAgentSession session = await projectClient.AgentAdministrationClient.CreateSessionAsync(agentName: agentVersion.Name, versionIndicator: new VersionRefIndicator(agentVersion.Version));
        while (session.Status != AgentSessionStatus.Failed && session.Status != AgentSessionStatus.Active)
        {
            await Task.Delay(500);
            session = await projectClient.AgentAdministrationClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
        }
        if (session.Status != AgentSessionStatus.Active)
        {
            throw new InvalidOperationException($"The session creation reached a non-successful status {session.Status}.");
        }
        #endregion
        #region Snippet:Sample_GetResponseFromAgent_CodeAgentReminderTool_Async
        Console.WriteLine($"Sending prompt {prompt} in session {session.AgentSessionId}...");
        ProjectOpenAIClientOptions oaiOptions = new();
        oaiOptions.AddPolicy(new SessionHeaderPolicy(session.AgentSessionId), PipelinePosition.PerCall);
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: oaiOptions);
        ResponseResult response = await responseClient.CreateResponseAsync(prompt);
        Console.WriteLine("Response items:");
        foreach (ResponseItem item in response.OutputItems)
        {
            if (item is FunctionCallOutputResponseItem functionResponse)
            {
                Console.WriteLine($"    Function output {functionResponse.FunctionOutput}");
            }
            else if (item is FunctionCallResponseItem functionCall)
            {
                Console.WriteLine($"    Calling function {functionCall.FunctionName} with arguments {functionCall.FunctionArguments}");
            }
        }
        Console.WriteLine(response.GetOutputText());
        responseTime = response.CreatedAt;
        #endregion
        #region Snippet:Sample_GetCreatedTrigger_CodeAgentReminderTool_Async
        Console.WriteLine("Wait for a half of a second and inspect the routines.");
        await Task.Delay(500);
        ProjectsRoutine created = null;
        await foreach (ProjectsRoutine routine in projectClient.Routines.GetRoutinesAsync(order: MemoryStoreListOrder.Descending, limit: 1))
        {
            // The routine created no earlier than response and not later than one minute after response.
            if (routine.CreatedAt >= responseTime && routine.CreatedAt < responseTime.AddMinutes(1))
            {
                created = routine;
                break;
            }
            // If the latest routine was created before the response, our routine was not created.
            else if (routine.CreatedAt < responseTime)
            {
                break;
            }
        }
        if (created == null)
        {
            throw new InvalidOperationException($"The routine was not created.");
        }
        Console.WriteLine($"The last created routine is {created.Name}, assuming it was created by ReminderPreviewToolboxTool.");
        #endregion
        #region Snippet:Sample_WaitForRoutine_CodeAgentReminderTool_Async
        int minutesWait = 10;
        Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
        RoutineRun completedRun = null;
        bool runWasTriggered = false;
        while (DateTime.UtcNow < deadline)
        {
            await Task.Delay(500);
            await foreach (RoutineRun run in projectClient.Routines.GetRoutineRunsAsync(name: created.Name))
            {
                runWasTriggered = true;
                Console.WriteLine($"    - run ID {run.Id}, status: {run.Status}, trigger type: {run.TriggerType}, triggered at: {run.TriggeredAt?.ToString() ?? "<Not triggered yet>"}, ended at: {run.EndedAt?.ToString() ?? "<Not ended yet>"}");
                if (string.Equals(run.Status, "finished", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(run.Status, "failed", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(run.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
                {
                    completedRun = run;
                }
            }
            if (completedRun is not null)
            {
                break;
            }
        }
        CheckRunResult(completedRun, minutesWait, runWasTriggered);
        #endregion
        #region Snippet:Sample_OutputStatus_CodeAgentReminderTool_Async
        Console.WriteLine($"The run has completed with status {completedRun.Status}, response ID is {completedRun.ResponseId}");
        // Currently the response retrieval is not supported.
        // ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
        // ResponseResult result = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: completedRun.ResponseId));
        // if (result.Error is not null)
        // {
        //     throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
        // }
        // Console.WriteLine($"Response: {result.GetOutputText()}");
        #endregion
        #region Snippet:DeleteCodeAgentReminderTool_CodeAgentReminderTool_Async
        await toolboxClient.DeleteAsync(toolBox.Name);
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void CodeAgentReminderToolCreateSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        #region Snippet:Sample_CreateToolbox_CodeAgentReminderTool_Sync
        ToolboxVersion toolBox = toolboxClient.CreateVersion(
            name: "toolboxWithTheReminder",
            tools: [new ReminderPreviewToolboxTool()],
            description: "The toolbox with a reminder tool."
        );
        Console.WriteLine($"Created a toolbox {toolBox.Name} v. {toolBox.Version}.");
        #endregion
        #region Snippet:Sample_CreateAgent_CodeAgentReminderTool_Sync
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersionFromCode(
            agentName: "myCodeAgentReminderTool",
            filePath: GetDirectory(Path.Combine(["Assets", "AgentsCodeToolbox"])),
            metadata: GetAgentMetadata(
                middlewareAgentName: "codeAgentMiddleware1",
                toolboxName: toolBox.Name,
                foundryProjectEndpoint: projectEndpoint,
                modelDeploymentName: modelDeploymentName
            )
        );
        #endregion
        #region Snippet:Sample_WaitForDeployment_CodeAgentReminderTool_Sync
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
        #region Snippet:Sample_WaitForSession_CodeAgentReminderTool_Sync
        string prompt = "Please remind me to go to lunch after one minute.";
        DateTimeOffset responseTime;
        ProjectAgentSession session = projectClient.AgentAdministrationClient.CreateSession(agentName: agentVersion.Name, versionIndicator: new VersionRefIndicator(agentVersion.Version));
        while (session.Status != AgentSessionStatus.Failed && session.Status != AgentSessionStatus.Active)
        {
            Thread.Sleep(500);
            session = projectClient.AgentAdministrationClient.GetSession(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
        }
        if (session.Status != AgentSessionStatus.Active)
        {
            throw new InvalidOperationException($"The session creation reached a non-successful status {session.Status}.");
        }
        #endregion
        #region Snippet:Sample_GetResponseFromAgent_CodeAgentReminderTool_Sync
        Console.WriteLine($"Sending prompt {prompt} in session {session.AgentSessionId}...");
        ProjectOpenAIClientOptions oaiOptions = new();
        oaiOptions.AddPolicy(new SessionHeaderPolicy(session.AgentSessionId), PipelinePosition.PerCall);
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: oaiOptions);
        ResponseResult response = responseClient.CreateResponse(prompt);
        Console.WriteLine("Response items:");
        foreach (ResponseItem item in response.OutputItems)
        {
            if (item is FunctionCallOutputResponseItem functionResponse)
            {
                Console.WriteLine($"    Function output {functionResponse.FunctionOutput}");
            }
            else if (item is FunctionCallResponseItem functionCall)
            {
                Console.WriteLine($"    Calling function {functionCall.FunctionName} with arguments {functionCall.FunctionArguments}");
            }
        }
        Console.WriteLine(response.GetOutputText());
        responseTime = response.CreatedAt;
        #endregion
        #region Snippet:Sample_GetCreatedTrigger_CodeAgentReminderTool_Sync
        Console.WriteLine("Wait for a half of a second and inspect the routines.");
        Thread.Sleep(500);
        ProjectsRoutine created = null;
        foreach (ProjectsRoutine routine in projectClient.Routines.GetRoutines(order: MemoryStoreListOrder.Descending, limit: 1))
        {
            // The routine created no earlier than response and not later than one minute after response.
            if (routine.CreatedAt >= responseTime && routine.CreatedAt < responseTime.AddMinutes(1))
            {
                created = routine;
                break;
            }
            // If the latest routine was created before the response, our routine was not created.
            else if (routine.CreatedAt < responseTime)
            {
                break;
            }
        }
        if (created == null)
        {
            throw new InvalidOperationException($"The routine was not created.");
        }
        Console.WriteLine($"The last created routine is {created.Name}, assuming it was created by ReminderPreviewToolboxTool.");
        #endregion
        #region Snippet:Sample_WaitForRoutine_CodeAgentReminderTool_Sync
        int minutesWait = 10;
        Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
        RoutineRun completedRun = null;
        bool runWasTriggered = false;
        while (DateTime.UtcNow < deadline)
        {
            Thread.Sleep(500);
            foreach (RoutineRun run in projectClient.Routines.GetRoutineRuns(name: created.Name))
            {
                runWasTriggered = true;
                Console.WriteLine($"    - run ID {run.Id}, status: {run.Status}, trigger type: {run.TriggerType}, triggered at: {run.TriggeredAt?.ToString() ?? "<Not triggered yet>"}, ended at: {run.EndedAt?.ToString() ?? "<Not ended yet>"}");
                if (string.Equals(run.Status, "finished", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(run.Status, "failed", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(run.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
                {
                    completedRun = run;
                }
            }
            if (completedRun is not null)
            {
                break;
            }
        }
        CheckRunResult(completedRun, minutesWait, runWasTriggered);
        #endregion
        #region Snippet:Sample_OutputStatus_CodeAgentReminderTool_Sync
        Console.WriteLine($"The run has completed with status {completedRun.Status}, response ID is {completedRun.ResponseId}");
        // Currently the response retrieval is not supported.
        // ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
        // ResponseResult result = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: completedRun.ResponseId));
        // if (result.Error is not null)
        // {
        //     throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
        // }
        // Console.WriteLine($"Response: {result.GetOutputText()}");
        #endregion
        #region Snippet:DeleteCodeAgentReminderTool_CodeAgentReminderTool_Sync
        toolboxClient.Delete(toolBox.Name);
        projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
        #endregion
    }

    public Sample_CodeAgentReminderTool(bool isAsync) : base(isAsync)
    { }
}
