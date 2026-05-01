// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
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

public class Sample_EvaluationsAgent : EvaluationSampleBase
{
    #region Snippet:Sample_CreateData_EvaluationsAgent
    private static BinaryData GetEvaluationConfig(string modelDeploymentName)
    {
        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "violence_detection",
                evaluator_name = "builtin.violence",
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
                name = "Agent Response Evaluation",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
    }
    #endregion
    #region Snippet:Sample_CreateDataSource_EvaluationsAgent
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
    public async Task EvaluationsAgentExampleAsync()
    {
        #region Snippet:Sample_CreateClients_EvaluationsAgent
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
        #region Snippet:Sample_CreateAgent_EvaluationsAgent_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that answers general questions",
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "evalAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateResponse_EvaluationsAgent_Async
        ResponseItem request = ResponseItem.CreateUserMessageItem("What is the size of France in square miles?");
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: agentVersion.Name, version: agentVersion.Version));
        ResponseResult response = await responseClient.CreateResponseAsync([request]);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_CreateEvaluationObject_EvaluationsAgent_Async
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetEvaluationConfig(modelDeploymentName));
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsAgent_Async
        using BinaryContent runDataContent = BinaryContent.Create(GetRunData(agentVersion.Name, response.Id, evaluationId));
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsAgent_Async
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
        #region Snippet:Sample_ParseEvaluations_EvaluationsAgent_Async
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
        #region Snippet:Sample_Cleanup_EvaluationsAgent_Async
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EvaluationsAgentExampleSync()
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
        #region Snippet:Sample_CreateAgent_EvaluationsAgent_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that answers general questions",
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "evalAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateResponse_EvaluationsAgent_Sync
        ResponseItem request = ResponseItem.CreateUserMessageItem("What is the size of France in square miles?");
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: agentVersion.Name, version: agentVersion.Version));
        ResponseResult response = responseClient.CreateResponse([request]);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_CreateEvaluationObject_EvaluationsAgent_Sync
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetEvaluationConfig(modelDeploymentName));
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsAgent_Sync
        using BinaryContent runDataContent = BinaryContent.Create(GetRunData(agentVersion.Name, response.Id, evaluationId));
        ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsAgent_Sync
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
        #region Snippet:Sample_ParseEvaluations_EvaluationsAgent_Sync
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
        #region Snippet:Sample_Cleanup_EvaluationsAgent_Sync
        evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_EvaluationsAgent(bool isAsync) : base(isAsync)
    {
    }
}
