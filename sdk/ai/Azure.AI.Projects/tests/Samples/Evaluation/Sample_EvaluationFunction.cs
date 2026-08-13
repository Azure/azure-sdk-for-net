// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

public class Sample_EvaluationsFunction : EvaluationSampleBase
{
    #region Snippet:Sample_FunctionTool_EvaluationsFunction_Async
    private static string GetHoroscope(string sign) => $"{sign}: Next Tuesday you will befriend a baby otter.";

    private static readonly FunctionTool horoscopeTool = ResponseTool.CreateFunctionTool(
        functionName: "GetHoroscope",
        functionDescription: "Get today's horoscope for an astrological sign.",
        functionParameters: BinaryData.FromObjectAsJson(
             new
             {
                 Type = "object",
                 Properties = new
                 {
                     sign = new
                     {
                         Type = "string",
                         Description = "An astrological sign like Taurus or Aquarius",
                     },
                 },
                 Required = new[] { "sign" },
                 AdditionalProperties = false,
             },
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
        ),
        strictModeEnabled: true
    );
    #endregion
    # region Snippet:Sample_Resolver_EvaluationsFunction
    private static FunctionCallOutputResponseItem GetResolvedToolOutput(FunctionCallResponseItem item)
    {
        using JsonDocument argumentsJson = JsonDocument.Parse(item.FunctionArguments);
        if (string.Equals(item.FunctionName, horoscopeTool.FunctionName))
        {
            string sign = argumentsJson.RootElement.GetProperty("sign").GetString();
            return ResponseItem.CreateFunctionCallOutputItem(item.CallId, GetHoroscope(sign));
        }
        return null;
    }
    #endregion

    #region Snippet:Sample_CreateData_EvaluationsFunction
    private static BinaryData GetEvaluationConfig(string modelDeploymentName)
    {
        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "tool_call_accuracy",
                evaluator_name = "builtin.tool_call_accuracy",
                initialization_parameters = new { deployment_name = modelDeploymentName },
            },
        ];
        object dataSourceConfig = new
        {
            type = "azure_ai_source",
            scenario = "responses"
        };
        return BinaryData.FromObjectAsJson(
            new
            {
                name = "Agent Evaluation",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
    }
    #endregion
    #region Snippet:Sample_CreateDataSource_EvaluationsFunction
    private static BinaryData GetRunData(string agentName, string responseId, string evaluationId)
    {
        object dataSource = new
        {
            type = "azure_ai_responses",
            item_generation_params = new
            {
                type = "response_retrieval",
                data_mapping = new { response_id = "{{item.resp_id}}" },
                source = new
                {
                    type = "file_content",
                    content = new[]
                    {
                        new
                        {
                            item = new { resp_id =  responseId}
                        }
                    }
                }
            },
        };
        return BinaryData.FromObjectAsJson(
            new
            {
                eval_id = evaluationId,
                name = $"Evaluation Run for Agent {agentName}",
                data_source = dataSource
            }
        );
    }
    #endregion
    [Test]
    [AsyncOnly]
    public async Task EvaluationsFunctionExampleAsync()
    {
        #region Snippet:Sample_CreateClients_EvaluationsFunction
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #endregion
        #region Snippet:Sample_CreateAgent_EvaluationsFunction_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that can use function tools.",
            Tools = { horoscopeTool }
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "evalAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateResponse_EvaluationsFunction_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseItem request = ResponseItem.CreateUserMessageItem("What is my horoscope? I am an Aquarius.");
        List<ResponseItem> inputItems = [request];
        bool funcionCalled = false;
        string previousResponseId = null;
        ResponseResult response;
        do
        {
            response = await responseClient.CreateResponseAsync(
                inputItems: inputItems,
                previousResponseId: previousResponseId
            );
            previousResponseId = response.Id;
            inputItems.Clear();
            funcionCalled = false;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                inputItems.Add(responseItem);
                if (responseItem is FunctionCallResponseItem functionToolCall)
                {
                    Console.WriteLine($"Calling {functionToolCall.FunctionName}...");
                    inputItems.Add(GetResolvedToolOutput(functionToolCall));
                    funcionCalled = true;
                }
            }
        } while (funcionCalled);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_CreateEvaluationObject_EvaluationsFunction_Async
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetEvaluationConfig(modelDeploymentName));
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsFunction_Async
        using BinaryContent runDataContent = BinaryContent.Create(GetRunData(agentVersion.Name, response.Id, evaluationId));
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsFunction_Async
        while (runStatus != "failed" && runStatus != "completed")
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatus = ParseClientResult(run, ["status"])["status"];
            Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
        }
        if (runStatus == "failed")
        {
            throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
        }
        #endregion
        #region Snippet:Sample_ParseEvaluations_EvaluationsFunction_Async
        Console.WriteLine("Evaluation run completed successfully!");
        Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
        List<string> evaluationResults = await GetResultsListAsync(client: evaluationClient, evaluationId: evaluationId, evaluationRunId: runId);
        Console.WriteLine($"OUTPUT ITEMS (Total: {evaluationResults.Count})");
        Console.WriteLine($"------------------------------------------------------------");
        foreach (string result in evaluationResults)
        {
            Console.WriteLine(result);
        }
        Console.WriteLine($"------------------------------------------------------------");
        #endregion
        #region Snippet:Sample_Cleanup_EvaluationsFunction_Async
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EvaluationsFunctionExampleSync()
    {
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #region Snippet:Sample_CreateAgent_EvaluationsFunction_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that can use function tools.",
            Tools = { horoscopeTool }
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "evalAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateResponse_EvaluationsFunction_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseItem request = ResponseItem.CreateUserMessageItem("What is my horoscope? I am an Aquarius.");
        List<ResponseItem> inputItems = [request];
        bool funcionCalled = false;
        string previousResponseId = null;
        ResponseResult response;
        do
        {
            response = responseClient.CreateResponse(
                inputItems: inputItems,
                previousResponseId: previousResponseId
            );
            previousResponseId = response.Id;
            inputItems.Clear();
            funcionCalled = false;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                inputItems.Add(responseItem);
                if (responseItem is FunctionCallResponseItem functionToolCall)
                {
                    Console.WriteLine($"Calling {functionToolCall.FunctionName}...");
                    inputItems.Add(GetResolvedToolOutput(functionToolCall));
                    funcionCalled = true;
                }
            }
        } while (funcionCalled);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_CreateEvaluationObject_EvaluationsFunction_Sync
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetEvaluationConfig(modelDeploymentName));
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsFunction_Sync
        using BinaryContent runDataContent = BinaryContent.Create(GetRunData(agentVersion.Name, response.Id, evaluationId));
        ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsFunction_Sync
        while (runStatus != "failed" && runStatus != "completed")
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = evaluationClient.GetEvaluationRun(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatus = ParseClientResult(run, ["status"])["status"];
            Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
        }
        if (runStatus == "failed")
        {
            throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
        }
        #endregion
        #region Snippet:Sample_ParseEvaluations_EvaluationsFunction_Sync
        Console.WriteLine("Evaluation run completed successfully!");
        Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
        List<string> evaluationResults = GetResultsList(client: evaluationClient, evaluationId: evaluationId, evaluationRunId: runId);
        Console.WriteLine($"OUTPUT ITEMS (Total: {evaluationResults.Count})");
        Console.WriteLine($"------------------------------------------------------------");
        foreach (string result in evaluationResults)
        {
            Console.WriteLine(result);
        }
        Console.WriteLine($"------------------------------------------------------------");
        #endregion
        #region Snippet:Sample_Cleanup_EvaluationsFunction_Sync
        evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_EvaluationsFunction(bool isAsync) : base(isAsync)
    {
    }
}
