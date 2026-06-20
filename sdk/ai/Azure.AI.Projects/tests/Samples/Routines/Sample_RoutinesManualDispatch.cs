// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using OpenAI.Responses;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using Azure.AI.Extensions.OpenAI;
using System.ClientModel.Primitives;

namespace Azure.AI.Projects.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_RoutinesManualDispatch : SamplesRoutineBase
{
    [Test]
    [AsyncOnly]
    public async Task RoutinesManualDispatchAsync()
    {
        #region Snippet:Sample_CreateClient_RoutinesManualDispatch
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string routineName = "sample-routine";
        string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string routineName = SAMPLE_ROUTINE_NAME_PREFIX;
        string agentName = TestEnvironment.HOSTED_AGENT_NAME;
#endif
        AIProjectClientOptions options = new();
        options.AddPolicy(GetDumpPolicy(), System.ClientModel.Primitives.PipelinePosition.PerCall);
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new AzureCliCredential(), options: options);
        AIProjectRoutines routinesClient = projectClient.Routines;
        #endregion
        #region Snippet:Sample_GetHostedAgent_RoutinesManualDispatch_Async
        ProjectsAgentVersion agentVersion = (await projectClient.AgentAdministrationClient.GetAgentAsync(
            agentName: agentName)).Value.GetLatestVersion();
        #endregion
        // Clean up any pre-existing routine with the same name.
        try
        { await routinesClient.DeleteRoutineAsync(routineName); } catch { }

        #region Snippet:Sample_CreateRoutine_RoutinesManualDispatch_Async
        CreateResponseOptions responseOptions = new()
        {
            InputItems = {ResponseItem.CreateUserMessageItem("Hello, Tell me a joke.") }
        };
        BinaryData responseData = ((IJsonModel<CreateResponseOptions>)responseOptions).Write(ModelReaderWriterOptions.Json);
        RoutineAction action = new InvokeAgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name,
            Input = responseData//BinaryData.FromObjectAsJson("Hello, Tell me a joke."),
        };
        ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine used by manual dispatch sampole.", enabled: true);
        routineOptions.Triggers.Add("manual", new CustomRoutineTrigger(provider: "manual", parameters: new Dictionary<string, BinaryData>()));
        ProjectsRoutine created = await routinesClient.CreateOrUpdateRoutineAsync(
            routineName: routineName,
            options: routineOptions
        );
        Console.WriteLine($"Created routine: {created.Name} enabled={created.Enabled}.");
        #endregion

        #region Snippet:Sample_WaitForTask_RoutinesManualDispatch_Async
        //=======================
        ProjectOpenAIClientOptions opts = new();
        opts.AddPolicy(GetDumpPolicy(), System.ClientModel.Primitives.PipelinePosition.PerCall);
        ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: opts);
        //ResponseResult resp = await oaiClient.CreateResponseAsync("Hello!");
        //Console.WriteLine($"====Create: {resp.GetOutputText()}");
        //resp = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: resp.Id));
        //Console.WriteLine($"====Get: {resp.GetOutputText()}");
        //=======================
        BinaryData wrongData = BinaryData.FromObjectAsJson(new
        {
            foo = "bar",
            bar = "baz"
        });
        DispatchRoutineResponse dispatch = await routinesClient.DispatchAsyncRoutineAsync(routineName: created.Name, payload: new InvokeAgentResponsesApiDispatchPayload(wrongData));
        Console.WriteLine($"Dispatched the routine. Dispatch ID {dispatch.DispatchId}, task ID: {dispatch.TaskId}.");
        int minutesWait = 10;
        Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
        RoutineRun completedRun = null;
        while (DateTime.UtcNow < deadline)
        {
            await Task.Delay(500);
            await foreach (RoutineRun run in projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name))
            {
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
        if (completedRun == null)
        {
            throw new InvalidOperationException($"The run did not complete within {minutesWait} minutes.");
        }
        if (string.Equals(completedRun.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException("The run was forcefully stopped.");
        }
        if (string.Equals(completedRun.Status, "failed", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException($"The run has failed with the error. Type: {completedRun.ErrorType} Message: {completedRun.ErrorMessage}.");
        }
        #endregion

        #region Snippet:Sample_PrintOutput_RoutinesManualDispatch_Async
        Console.WriteLine($"The response Id is {completedRun.ResponseId}");
        //ProjectOpenAIClientOptions opts = new();
        //opts.AddPolicy(GetDumpPolicy(), System.ClientModel.Primitives.PipelinePosition.PerCall);
        //ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: opts);
        ResponseResult result = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: completedRun.ResponseId));
        if (result.Error is not null)
        {
            throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
        }
        Console.WriteLine($"Response: {result.GetOutputText()}");
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesManualDispatch_Async
        await routinesClient.DeleteRoutineAsync(routineName);
        Console.WriteLine("Routine deleted");
        #endregion
    }

    public Sample_RoutinesManualDispatch(bool isAsync) : base(isAsync)
    { }
}
