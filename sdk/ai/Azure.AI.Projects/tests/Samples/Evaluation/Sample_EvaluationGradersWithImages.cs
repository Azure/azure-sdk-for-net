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

public class Sample_EvaluationsGradersWithImages : EvaluationSampleBase
{
    #region Snippet:Sample_CreateData_EvaluationsGradersWithImages
    private static BinaryData GetDatasetConfig(string modelDeploymentName)
    {
        object[] testingCriteria = [
            new {
                type = "score_model",
                name = "score_grader",
                model = modelDeploymentName,
                input = new object[] {
                    new { role = "system", content = "You are an expert grader. Judge how well the model response {{sample.output_text}} describes the image as well as matches the caption {{item.caption}}. Output a score of 1 if it's an excellent match with both. If it's somewhat compatible, output a score around 0.5. Otherwise, give a score of 0." },
                    new {
                        role = "user",
                        content = new
                        {
                            type = "input_image",
                            image_url = "{{item.image_url}}",
                            detail = "auto"
                        }
                    }
                },
                range = new float[] { 0.0f, 1.0f },
                pass_threshold = 0.5f
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
                    image_url = new { type = "string", description = "The URL of the image to be evaluated." },
                    caption = new { type = "string", description = "The caption describing the image." },
                },
                required = new string[] { "image_url", "caption" }
            },
            include_sample_schema = true
        };
        return BinaryData.FromObjectAsJson(
            new
            {
                name = "OpenAI graders test",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
    }
    #endregion
    #region Snippet:Sample_ImageToUri_EvaluationsGradersWithImages
    private static string GetImageDataAsUri(string fileName, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        byte[] imageData = File.ReadAllBytes(Path.Combine([dirName, fileName]));
        return $"data:image/png;base64,{Convert.ToBase64String(imageData)}";
    }
    #endregion
    #region Snippet:Sample_CreateRunDataSource_EvaluationsGradersWithImages
    public static BinaryData GetData(string evaluationId, string modelDeploymentName, string filePath)
    {
        object input_messages = new
        {
            type = "template",
            template = new object[]
            {
                new
                {
                    type = "message",
                    role = "system",
                    content = "You are an assistant that analyzes images and provides captions that accurately describe the content of the image."
                },
                new
                {
                    type = "message",
                    role = "user",
                    content = new
                    {
                        type = "input_image",
                        image_url = "{{item.image_url}}",
                        detail = "auto",
                    }
                }
            }
        };
        string imageUrl = filePath.StartsWith("data") ? GetImageDataAsUri(fileName: filePath) : GetImageDataAsUri(fileName: Path.GetFileName(filePath), pth: filePath.Substring(0, filePath.Length - Path.GetFileName(filePath).Length));
        object dataSource = new
        {
            type = "completions",
            source = new
            {
                type = "file_content",
                content = new object[] {
                    new
                    {
                        item = new
                        {
                            image_url = imageUrl,
                            caption = "industrial plants in the distance at night",
                        }
                    },
                    new
                    {
                        item = new
                        {
                            image_url = "https://ep1.pinkbike.org/p4pb6973204/p4pb6973204.jpg",
                            caption = "all shots by person and rider shots can be found on his website.",
                        }
                    },
                }
            },
            model = modelDeploymentName,
            input_messages = input_messages,
            sampling_params = new
            {
                temperature = 0.8f
            },
        };
        return BinaryData.FromObjectAsJson(
            new
            {
                eval_id = evaluationId,
                name = "Eval",
                metadata = new { team = "eval-exp", scenario = "notifications-v1" },
                data_source = dataSource
            }
        );
    }
    #endregion
    [Test]
    [AsyncOnly]
    public async Task EvaluationsGradersExampleAsync()
    {
        #region Snippet:Sample_CreateClients_EvaluationsGradersWithImages
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
        #region Snippet:Sample_CreateEvaluation_EvaluationsGradersWithImages_Async
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetDatasetConfig(modelDeploymentName));
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsGradersWithImages_Async
        using BinaryContent runDataContent = BinaryContent.Create(GetData(evaluationId, modelDeploymentName, Path.Combine("data", "sample_evaluations_score_model_grader_with_image.jpg")));
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsGradersWithImages_Async
        while (runStatus != "failed" && runStatus != "completed")
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            run = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatus = ParseClientResult(run, ["status"])["status"];
            Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
        }
        if (runStatus == "failed")
        {
            throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
        }
        #endregion
        #region Snippet:Sample_ParseResults_EvaluationsGradersWithImages_Async
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
        #region Snippet:Sample_Cleanup_EvaluationsGradersWithImages_Async
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EvaluationsGradersExampleSync()
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
        #region Snippet:Sample_CreateEvaluation_EvaluationsGradersWithImages_Sync
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetDatasetConfig(modelDeploymentName));
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsGradersWithImages_Sync
        using BinaryContent runDataContent = BinaryContent.Create(GetData(evaluationId, modelDeploymentName, Path.Combine("data", "sample_evaluations_score_model_grader_with_image.jpg")));
        ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsGradersWithImages_Sync
        while (runStatus != "failed" && runStatus != "completed")
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            run = evaluationClient.GetEvaluationRun(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatus = ParseClientResult(run, ["status"])["status"];
            Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
        }
        if (runStatus == "failed")
        {
            throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
        }
        #endregion
        #region Snippet:Sample_ParseResults_EvaluationsGradersWithImages_Sync
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
        #region Snippet:Sample_Cleanup_EvaluationsGradersWithImages_Sync
        evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        #endregion
    }

    public Sample_EvaluationsGradersWithImages(bool isAsync) : base(isAsync)
    {
    }
}
