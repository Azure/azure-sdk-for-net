// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// #nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_Evaluations : SamplesBase<AIProjectsTestEnvironment>
{
//    [Test]
//    [SyncOnly]
//    public void EvaluationsExampleSync()
//    {
//        #region Snippet:AI_Projects_EvaluationsExampleSync
//#if SNIPPET
//        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
//        var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
//#else
//        var endpoint = TestEnvironment.PROJECTENDPOINT;
//        var datasetName = TestEnvironment.DATASETNAME;
//#endif
//        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

//        // TODO: Uncomment once datasets are supported, will need to replace UploadFileAndCreate with new function name
//        //Console.WriteLine("Upload a single file and create a new Dataset to reference the file. Here we explicitly specify the dataset version.");
//        //DatasetVersion dataset = projectClient.GetDatasetsClient().UploadFileAndCreate(
//        //        name: datasetName,
//        //        version: "1",
//        //        filePath: "./sample_folder/sample_data_evaluation.jsonl"
//        //        );
//        //Console.WriteLine(dataset);

//        Console.WriteLine("Create an evaluation");

//        var evaluatorConfig = new EvaluatorConfiguration(
//            id: EvaluatorIDs.Relevance // TODO: Update this to use the correct evaluator ID
//        );
//        evaluatorConfig.InitParams.Add("deployment_name", BinaryData.FromObjectAsJson("gpt-4o"));

//        Evaluation evaluation = new Evaluation(
//            data: new InputDataset("<dataset_id>"), // TODO: Update this to use the correct dataset ID
//            evaluators: new Dictionary<string, EvaluatorConfiguration> { { "relevance", evaluatorConfig } }
//        );
//        evaluation.DisplayName = "Sample Evaluation";
//        evaluation.Description = "Sample evaluation for testing"; // TODO: Make optional once bug 4115256 is fixed

//        Console.WriteLine("Create the evaluation run");
//        Evaluation evaluationResponse = projectClient.Evaluations.Create(evaluation: evaluation);
//        Console.WriteLine(evaluationResponse);

//        Console.WriteLine("Get evaluation");
//        Evaluation getEvaluationResponse = projectClient.Evaluations.Get(evaluationResponse.Name);
//        Console.WriteLine(getEvaluationResponse);

//        Console.WriteLine("List evaluations");
//        foreach (var eval in projectClient.Evaluations.GetAll())
//        {
//            Console.WriteLine(eval);
//        }
//        #endregion
//    }

//    [Test]
//    [AsyncOnly]
//    public async Task EvaluationsExampleAsync()
//    {
//        #region Snippet:AI_Projects_EvaluationsExampleAsync
//#if SNIPPET
//        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
//        var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
//#else
//        var endpoint = TestEnvironment.PROJECTENDPOINT;
//        var datasetName = TestEnvironment.DATASETNAME;
//#endif
//        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

//        // TODO: Uncomment once datasets are supported, will need to replace UploadFileAndCreate with new function name
//        //Console.WriteLine("Upload a single file and create a new Dataset to reference the file. Here we explicitly specify the dataset version.");
//        //DatasetVersion dataset = projectClient.GetDatasetsClient().UploadFileAndCreate(
//        //        name: datasetName,
//        //        version: "1",
//        //        filePath: "./sample_folder/sample_data_evaluation.jsonl"
//        //        );
//        //Console.WriteLine(dataset);

//        Console.WriteLine("Create an evaluation");

//        var evaluatorConfig = new EvaluatorConfiguration(
//            id: EvaluatorIDs.Relevance // TODO: Update this to use the correct evaluator ID
//        );
//        evaluatorConfig.InitParams.Add("deploymentName", BinaryData.FromObjectAsJson("gpt-4o"));

//        Evaluation evaluation = new Evaluation(
//            data: new InputDataset("<dataset_id>"), // TODO: Update this to use the correct dataset ID
//            evaluators: new Dictionary<string, EvaluatorConfiguration> { { "relevance", evaluatorConfig } }
//        );
//        evaluation.DisplayName = "Sample Evaluation";
//        evaluation.Description = "Sample evaluation for testing"; // TODO: Make optional once bug 4115256 is fixed

//        Console.WriteLine("Create the evaluation run");
//        Evaluation evaluationResponse = await projectClient.Evaluations.CreateAsync(evaluation: evaluation);
//        Console.WriteLine(evaluationResponse);

//        Console.WriteLine("Get evaluation");
//        Evaluation getEvaluationResponse = await projectClient.Evaluations.GetAsync(evaluationResponse.Name);
//        Console.WriteLine(getEvaluationResponse);

//        Console.WriteLine("List evaluations");
//        await foreach (var eval in projectClient.Evaluations.GetAllAsync())
//        {
//            Console.WriteLine(eval);
//        }
//        #endregion
//    }
}
