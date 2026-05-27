// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

public class Sample_EvaluationsWithDataSetID : EvaluationSampleBase
{
    #region Snippet:Sample_GetFile_EvaluationsWithDataSetID
    private static string GetFile([CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(dirName, "data", "sample_data_evaluation.jsonl");
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task EvaluationsExampleAsync()
    {
        #region Snippet:Sample_CreateClients_EvaluationsWithDataSetID
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var connectionName = System.Environment.GetEnvironmentVariable("STORAGE_CONNECTION_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var connectionName = TestEnvironment.STORAGECONNECTIONNAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #endregion
        #region Snippet:Sample_CreateData_EvaluationsWithDataSetID
        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "violence",
                evaluator_name = "builtin.violence",
                data_mapping = new { query = "{{item.query}}", response = "{{item.response}}"},
                initialization_parameters = new { deployment_name = modelDeploymentName },
            },
            new {
                type = "azure_ai_evaluator",
                name = "f1",
                evaluator_name = "builtin.f1_score"
            },
            new {
                type = "azure_ai_evaluator",
                name = "coherence",
                evaluator_name = "builtin.coherence",
                data_mapping = new { query = "{{item.query}}", response = "{{item.response}}"},
                initialization_parameters = new { deployment_name = modelDeploymentName},
            },
        ];
        object dataSourceConfig = new
        {
            type = "custom",
            item_schema = new
            {
                type = "object",
                properties = new
                {
                    query = new { type = "string" },
                    response = new { type = "string" },
                    context = new { type = "string" },
                    ground_truth = new { type = "string" },
                },
                required = new { }
            },
            include_sample_schema = true
        };
        BinaryData evaluationData = BinaryData.FromObjectAsJson(
            new
            {
                name = "Label model test with dataset ID",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
        #endregion
        #region Snippet:Sample_CreateEvaluationObject_EvaluationsWithDataSetID_Async
        using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_UploadDataset_EvaluationsWithDataSetID_Async
        FileDataset fileDataset = await projectClient.Datasets.UploadFileAsync(
            name: $"SampleEvaluationDataset-{Guid.NewGuid().ToString("N").Substring(0, 8)}",
            version: "1",
            filePath: GetFile(),
            connectionName: connectionName
        );
        Console.WriteLine($"Uploaded new dataset {fileDataset.Name} version {fileDataset.Version}");
        #endregion
        #region Snippet:Sample_CreateDataSource_EvaluationsWithDataSetID
        object dataSource = new
        {
            type = "jsonl",
            source = new
            {
                type = "file_id",
                id = fileDataset.Id
            },
        };
        object runMetadata = new
        {
            team = "evaluator-experimentation",
            scenario = "dataset-with-id",
        };
        BinaryData runData = BinaryData.FromObjectAsJson(
            new
            {
                eval_id = evaluationId,
                name = $"Evaluation Run for dataset {fileDataset.Name}",
                metadata = runMetadata,
                data_source = dataSource
            }
        );
        using BinaryContent runDataContent = BinaryContent.Create(runData);
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsWithDataSetID_Async
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsWithDataSetID_Async
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
        #region Snippet:Sample_ParseEvaluations_EvaluationsWithDataSetID_Async
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
        #region Snippet:Sample_Cleanup_EvaluationsWithDataSetID_Async
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EvaluationsExampleSync()
    {
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var connectionName = System.Environment.GetEnvironmentVariable("STORAGE_CONNECTION_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var connectionName = TestEnvironment.STORAGECONNECTIONNAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "violence",
                evaluator_name = "builtin.violence",
                data_mapping = new { query = "{{item.query}}", response = "{{item.response}}"},
                initialization_parameters = new { deployment_name = modelDeploymentName },
            },
            new {
                type = "azure_ai_evaluator",
                name = "f1",
                evaluator_name = "builtin.f1_score"
            },
            new {
                type = "azure_ai_evaluator",
                name = "coherence",
                evaluator_name = "builtin.coherence",
                data_mapping = new { query = "{{item.query}}", response = "{{item.response}}"},
                initialization_parameters = new { deployment_name = modelDeploymentName},
            },
        ];
        object dataSourceConfig = new
        {
            type = "custom",
            item_schema = new
            {
                type = "object",
                properties = new
                {
                    query = new { type = "string" },
                    response = new { type = "string" },
                    context = new { type = "string" },
                    ground_truth = new { type = "string" },
                },
                required = new { }
            },
            include_sample_schema = true
        };
        BinaryData evaluationData = BinaryData.FromObjectAsJson(
            new
            {
                name = "Label model test with dataset ID",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
        #region Snippet:Sample_CreateEvaluationObject_EvaluationsWithDataSetID_Sync
        using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_UploadDataset_EvaluationsWithDataSetID_Sync
        FileDataset fileDataset = projectClient.Datasets.UploadFile(
            name: $"SampleEvaluationDataset-{Guid.NewGuid().ToString("N").Substring(0, 8)}",
            version: "1",
            filePath: GetFile(),
            connectionName: connectionName
        );
        Console.WriteLine($"Uploaded new dataset {fileDataset.Name} version {fileDataset.Version}");
        #endregion
        object dataSource = new
        {
            type = "jsonl",
            source = new
            {
                type = "file_id",
                id = fileDataset.Id
            },
        };
        object runMetadata = new
        {
            team = "evaluator-experimentation",
            scenario = "dataset-with-id",
        };
        BinaryData runData = BinaryData.FromObjectAsJson(
            new
            {
                eval_id = evaluationId,
                name = $"Evaluation Run for dataset {fileDataset.Name}",
                metadata = runMetadata,
                data_source = dataSource
            }
        );
        using BinaryContent runDataContent = BinaryContent.Create(runData);
        #region Snippet:Sample_CreateRun_EvaluationsWithDataSetID_Sync
        ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsWithDataSetID_Sync
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
        #region Snippet:Sample_ParseEvaluations_EvaluationsWithDataSetID_Sync
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
        #region Snippet:Sample_Cleanup_EvaluationsWithDataSetID_Sync
        evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        #endregion
    }

    public Sample_EvaluationsWithDataSetID(bool isAsync) : base(isAsync)
    {
    }
}
