// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_Evaluations : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void EvaluationsExampleSync()
    {
        #region Snippet:AI_Projects_EvaluationsExampleSync
#if SNIPPET
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var datasetName = Environment.GetEnvironmentVariable("DATASET_NAME") ?? "dataset-test";
        var datasetVersion = Environment.GetEnvironmentVariable("DATASET_VERSION") ?? "1.0";
        var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME") ?? "default-connection";
        var dataFile = Path.Combine(Environment.GetEnvironmentVariable("DATA_FOLDER") ?? ".", "sample_data_evaluation.jsonl");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var datasetName = TestEnvironment.DATASETNAME ?? "dataset-test";
        var datasetVersion = TestEnvironment.DATASETVERSION1 ?? "1.0";
        var dataFile = TestEnvironment.SAMPLEFILEPATH;
        var connectionName = TestEnvironment.CONNECTIONNAME;
#endif
        var projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

        Console.WriteLine("Upload a single file and create a new Dataset to reference the file. Here we explicitly specify the dataset version.");
        DatasetVersion dataset = projectClient.GetDatasetsClient().UploadFile(
               name: datasetName,
               version: "1",
               filePath: dataFile,
                connectionName: connectionName
               );
        Console.WriteLine(dataset);

        Console.WriteLine("Create an evaluation");
        Evaluations evaluations = projectClient.GetEvaluationsClient();

        var relevanceConfig = new EvaluatorConfiguration(EvaluatorIDs.Relevance);
        relevanceConfig.InitParams.Add("deployment_name", BinaryData.FromObjectAsJson(modelDeploymentName));
        relevanceConfig.DataMapping.Add("query", "${data.query}");
        relevanceConfig.DataMapping.Add("response", "${data.response}");

        var violenceConfig = new EvaluatorConfiguration(EvaluatorIDs.Violence);
        violenceConfig.InitParams.Add("azure_ai_project", BinaryData.FromObjectAsJson(endpoint));

        var bleuConfig = new EvaluatorConfiguration(EvaluatorIDs.BleuScore);

        var evaluators = new Dictionary<string, EvaluatorConfiguration>
        {
            { "relevance", relevanceConfig },
            { "violence", violenceConfig },
            { "bleu_score", bleuConfig }
        };

        Evaluation evaluation = new Evaluation(
            data: new InputDataset(dataset.Id),
            evaluators: evaluators
        )
        {
            DisplayName = "Sample Evaluation Test",
            Description = "Sample evaluation for testing"
        };

        Console.WriteLine("Create the evaluation run");
        Evaluation evaluationResponse = evaluations.Create(evaluation);
        Console.WriteLine(evaluationResponse);

        Console.WriteLine("Get evaluation");
        Evaluation getEvaluationResponse = evaluations.GetEvaluation(evaluation.DisplayName);
        Console.WriteLine(getEvaluationResponse);

        Console.WriteLine("List evaluations");
        foreach (Evaluation eval in evaluations.GetEvaluations())
        {
            Console.WriteLine(eval);
            Console.WriteLine(eval.Name);
        }
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task EvaluationsExampleAsync()
    {
        #region Snippet:AI_Projects_EvaluationsExampleAsync
#if SNIPPET
        var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var datasetName = Environment.GetEnvironmentVariable("DATASET_NAME") ?? "dataset-test";
        var datasetVersion = Environment.GetEnvironmentVariable("DATASET_VERSION") ?? "1.0";
        var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME") ?? "default-connection";
        var dataFile = Path.Combine(Environment.GetEnvironmentVariable("DATA_FOLDER") ?? ".", "sample_data_evaluation.jsonl");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var datasetName = TestEnvironment.DATASETNAME ?? "dataset-test";
        var datasetVersion = TestEnvironment.DATASETVERSION1 ?? "1.0";
        var dataFile = TestEnvironment.SAMPLEFILEPATH;
        var connectionName = TestEnvironment.CONNECTIONNAME;
#endif
        var projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

        Console.WriteLine("Upload a single file and create a new Dataset to reference the file. Here we explicitly specify the dataset version.");
        DatasetVersion dataset = await projectClient.GetDatasetsClient().UploadFileAsync(
               name: datasetName,
               version: "1",
               filePath: dataFile,
                connectionName: connectionName
               );
        Console.WriteLine(dataset);

        Console.WriteLine("Create an evaluation");
        Evaluations evaluations = projectClient.GetEvaluationsClient();

        var relevanceConfig = new EvaluatorConfiguration(EvaluatorIDs.Relevance);
        relevanceConfig.InitParams.Add("deployment_name", BinaryData.FromObjectAsJson(modelDeploymentName));
        relevanceConfig.DataMapping.Add("query", "${data.query}");
        relevanceConfig.DataMapping.Add("response", "${data.response}");

        var violenceConfig = new EvaluatorConfiguration(EvaluatorIDs.Violence);
        violenceConfig.InitParams.Add("azure_ai_project", BinaryData.FromObjectAsJson(endpoint));

        var bleuConfig = new EvaluatorConfiguration(EvaluatorIDs.BleuScore);

        var evaluators = new Dictionary<string, EvaluatorConfiguration>
        {
            { "relevance", relevanceConfig },
            { "violence", violenceConfig },
            { "bleu_score", bleuConfig }
        };

        Evaluation evaluation = new Evaluation(
            data: new InputDataset(dataset.Id),
            evaluators: evaluators
        )
        {
            DisplayName = "Sample Evaluation Test",
            Description = "Sample evaluation for testing"
        };

        Console.WriteLine("Create the evaluation run");
        Evaluation evaluationResponse = await evaluations.CreateAsync(evaluation);
        Console.WriteLine(evaluationResponse);

        Console.WriteLine("Get evaluation");
        Evaluation getEvaluationResponse = await evaluations.GetEvaluationAsync(evaluation.DisplayName);
        Console.WriteLine(getEvaluationResponse);

        Console.WriteLine("List evaluations");
        await foreach (Evaluation eval in evaluations.GetEvaluationsAsync())
        {
            Console.WriteLine(eval);
            Console.WriteLine(eval.Name);
        }
        #endregion
    }
}
