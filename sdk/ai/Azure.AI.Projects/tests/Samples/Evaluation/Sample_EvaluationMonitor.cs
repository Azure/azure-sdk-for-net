// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

public class Sample_EvaluationsMonitor : EvaluationSampleBase
{
    #region Snippet:Sample_CreateData_EvaluationsMonitor
    private static BinaryData GetEvaluationCriteria(string[] names, string modelDeploymentName)
    {
        object[] testingCriteria = new object[names.Length];
        for (int i = 0; i < names.Length; i++)
        {
            testingCriteria[i] = new
            {
                type = "azure_ai_evaluator",
                name = names[i],
                evaluator_name = $"builtin.{names[i]}",
                data_mapping = new { query = "{{query}}", response = "{{response}}", tool_definitions = "{{tool_definitions}}" },
                initialization_parameters = new { deployment_name = modelDeploymentName },
            };
        }
        object dataSourceConfig = new
        {
            type = "azure_ai_source",
            scenario = "traces"
        };
        return BinaryData.FromObjectAsJson(
            new
            {
                name = "Trace Evaluation",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
    }
    #endregion
    #region Snippet:Sample_GetTraceIDsFromAppInsights_EvaluationsMonitor_Async
    private static async Task<List<string>> GetOperationIdsAsync(string applicationInsightsId, string agentID, int traceQueryHours, DateTimeOffset endTime)
    {
        List<string> results = [];
        string query = "dependencies\n" +
               "| extend agent_id = tostring(customDimensions[\"gen_ai.agent.id\"])\n" +
               $"| where agent_id == \"{agentID}\"\n" +
               "| distinct operation_Id";
        LogsQueryClient client = new(new DefaultAzureCredential());
        LogsQueryTimeRange range = new(
            duration: new TimeSpan(hours: traceQueryHours, minutes: 0, seconds: 0),
            end: endTime
        );
        Response<LogsQueryResult> response = await client.QueryResourceAsync(resourceId: new(applicationInsightsId), query: query, timeRange: range);
        if (response.GetRawResponse().IsError)
        {
            throw new InvalidOperationException($"The application insights query returned an error: {Encoding.UTF8.GetString(response.GetRawResponse().Content.ToArray())}");
        }
        foreach (LogsTable table in response.Value.AllTables)
        {
            foreach (LogsTableRow tableRow in table.Rows)
            {
                results.Add(tableRow.GetString(0));
            }
        }
        if (results.Count == 0)
        {
            throw new InvalidOperationException("The query returned no results.");
        }
        return results;
    }
    #endregion
    #region Snippet:Sample_GetTraceIDsFromAppInsights_EvaluationsMonitor_Sync
    private static List<string> GetOperationIds(string applicationInsightsId, string agentID, int traceQueryHours, DateTimeOffset endTime)
    {
        List<string> results = [];
        string query = "dependencies\n" +
               "| extend agent_id = tostring(customDimensions[\"gen_ai.agent.id\"])\n" +
               $"| where agent_id == \"{agentID}\"\n" +
               "| distinct operation_Id";
        LogsQueryClient client = new(new DefaultAzureCredential());
        LogsQueryTimeRange range = new(
            duration: new TimeSpan(hours: traceQueryHours, minutes: 0, seconds: 0),
            end: endTime
        );
        Response<LogsQueryResult> response = client.QueryResource(resourceId: new(applicationInsightsId), query: query, timeRange: range);
        if (response.GetRawResponse().IsError)
        {
            throw new InvalidOperationException($"The application insights query returned an error: {Encoding.UTF8.GetString(response.GetRawResponse().Content.ToArray())}");
        }
        foreach (LogsTable table in response.Value.AllTables)
        {
            foreach (LogsTableRow tableRow in table.Rows)
            {
                results.Add(tableRow.GetString(0));
            }
        }
        if (results.Count == 0)
        {
            throw new InvalidOperationException("The query returned no results.");
        }
        return results;
    }
    #endregion
    [Test]
    [AsyncOnly]
    public async Task EvaluationsMonitorExampleAsync()
    {
        #region Snippet:Sample_CreateClients_EvaluationsMonitor
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var applicationInsightsResourceId = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_RESOURCE_ID");
        var agentId = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_ID");
        var lookbackHours = int.Parse(System.Environment.GetEnvironmentVariable("TRACE_LOOKBACK_HOURS"));
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var applicationInsightsResourceId = TestEnvironment.APPLICATIONINSIGHTS_RESOURCE_ID;
        var agentId = TestEnvironment.FOUNDRY_AGENT_ID;
        var lookbackHours = int.Parse(TestEnvironment.TRACE_LOOKBACK_HOURS);
#endif
        DateTimeOffset endTime = DateTimeOffset.Now;
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #endregion
        #region Snippet:Sample_GetTraceIDs_EvaluationsMonitor_Async
        List<string> traceIDs = await GetOperationIdsAsync(applicationInsightsResourceId, agentId, lookbackHours, endTime);
        Console.WriteLine($"Found {traceIDs.Count} operation IDs:");
        foreach (string id in traceIDs)
        {
            Console.WriteLine($"    {id}");
        }
        #endregion
        #region Snippet:Sample_CreateEvaluationObject_EvaluationsMonitor_Async
        using BinaryContent evaluationCriteria = BinaryContent.Create(GetEvaluationCriteria(["intent_resolution", "task_adherence"], modelDeploymentName));
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationCriteria);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_CreateDataSource_EvaluationsMonitor
        object dataSource = new
        {
            type = "azure_ai_traces",
            trace_ids = traceIDs,
            lookback_hours = lookbackHours
        };
        BinaryData runData = BinaryData.FromObjectAsJson(
            new
            {
                eval_id = evaluationId,
                name = $"agent_trace_eval_{endTime:O}",
                data_source = dataSource,
                metadata = new
                {
                    agent_id = agentId,
                    start_time = endTime.AddHours(-lookbackHours).ToString("O"),
                    end_time = endTime.ToString("O"),
                }
            }
        );
        using BinaryContent runDataContent = BinaryContent.Create(runData);
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsMonitor_Async
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsMonitor_Async
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
        #region Snippet:Sample_ParseEvaluations_EvaluationsMonitor_Async
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
        #region Snippet:Sample_Cleanup_EvaluationsMonitor_Async
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EvaluationsMonitorExampleSync()
    {
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var applicationInsightsResourceId = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_RESOURCE_ID");
        var agentId = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_ID");
        var lookbackHours = int.Parse(System.Environment.GetEnvironmentVariable("TRACE_LOOKBACK_HOURS"));
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var applicationInsightsResourceId = TestEnvironment.APPLICATIONINSIGHTS_RESOURCE_ID;
        var agentId = TestEnvironment.FOUNDRY_AGENT_ID;
        var lookbackHours = int.Parse(TestEnvironment.TRACE_LOOKBACK_HOURS);
#endif
        DateTimeOffset endTime = DateTimeOffset.Now;
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #region Snippet:Sample_GetTraceIDs_EvaluationsMonitor_Sync
        List<string> traceIDs = GetOperationIds(applicationInsightsResourceId, agentId, lookbackHours, endTime);
        Console.WriteLine($"Found {traceIDs.Count} operation IDs:");
        foreach (string id in traceIDs)
        {
            Console.WriteLine($"    {id}");
        }
        #endregion
        #region Snippet:Sample_CreateEvaluationObject_EvaluationsMonitor_Sync
        using BinaryContent evaluationCriteria = BinaryContent.Create(GetEvaluationCriteria(["intent_resolution", "task_adherence"], modelDeploymentName));
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationCriteria);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        object dataSource = new
        {
            type = "azure_ai_traces",
            trace_ids = traceIDs,
            lookback_hours = lookbackHours
        };
        BinaryData runData = BinaryData.FromObjectAsJson(
            new
            {
                eval_id = evaluationId,
                name = $"agent_trace_eval_{endTime:O}",
                data_source = dataSource,
                metadata = new
                {
                    agent_id = agentId,
                    start_time = endTime.AddHours(-lookbackHours).ToString("O"),
                    end_time = endTime.ToString("O"),
                }
            }
        );
        using BinaryContent runDataContent = BinaryContent.Create(runData);
        #region Snippet:Sample_CreateRun_EvaluationsMonitor_Sync
        ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsMonitor_Sync
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
        #region Snippet:Sample_ParseEvaluations_EvaluationsMonitor_Sync
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
        #region Snippet:Sample_Cleanup_EvaluationsMonitor_Sync
        evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        #endregion
    }

    public Sample_EvaluationsMonitor(bool isAsync) : base(isAsync)
    {
    }
}
