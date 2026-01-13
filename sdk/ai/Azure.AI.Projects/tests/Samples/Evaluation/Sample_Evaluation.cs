// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// #nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample_Evaluations : SamplesBase
{
    private static (string Id, string Name) ParseEvaluationResult(ClientResult result)
    {
        string Id = default;
        string Name = default;
        Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
        JsonDocument document = JsonDocument.ParseValue(ref reader);
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            if (prop.NameEquals("name"u8))
            {
                Name = prop.Value.GetString();
            }
            else if (prop.NameEquals("id"u8))
            {
                Id = prop.Value.GetString();
            }
            if (!(string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Name)))
                break;
        }
        return (Id, Name);
    }

    private static Dictionary<string, string> ParseClientResult(ClientResult result, HashSet<string> expectedProperties)
    {
        Dictionary<string, string> results = [];
        Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
        JsonDocument document = JsonDocument.ParseValue(ref reader);
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            foreach (string key in expectedProperties)
            {
                if (prop.NameEquals(Encoding.UTF8.GetBytes(key)))
                {
                    results[key] = prop.Value.GetString();
                }
            }
        }
        return results;
    }

    [Test]
    [AsyncOnly]
    public async Task EvaluationsExampleAsync()
    {
        #region Snippet:Sampple_CreateClients_Evaluations
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.OpenAI.GetEvaluationClient();
        #endregion
        #region Snippet:Sample_CreateAgent_Evaluations_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "evalAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:
        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "violence_detection",
                evaluator_name = "builtin.violence",
                data_mapping = new { query = "{{item.query}}", response = "{{sample.output_text}}"}
            },
            new {
                type = "azure_ai_evaluator",
                name = "fluency",
                evaluator_name = "builtin.fluency",
                initialization_parameters = new { deployment_name = modelDeploymentName},
                data_mapping = new { query = "{{item.query}}", response = "{{sample.output_text}}"}
            },
            new {
                type = "azure_ai_evaluator",
                name = "task_adherence",
                evaluator_name = "builtin.task_adherence",
                initialization_parameters = new { deployment_name = modelDeploymentName},
                data_mapping = new { query = "{{item.query}}", response = "{{sample.output_items}}"}
            },
        ];
        object dataSourceConfig = new {
            type = "custom",
            item_schema = new
            {
                type = "object",
                properties = new
                {
                    query = new
                    {
                        type = "string"
                    }
                },
                required = new[] { "query" }
            },
            include_sample_schema = true
        };
        BinaryData evaluationData = BinaryData.FromObjectAsJson(
            new
            {
                name = "Agent Evaluation",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
        #endregion
        #region Sample_CreateEvaluationObject_Evaluations_Async
        using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        (string Name, string Id) = ParseEvaluationResult(evaluation);
        Console.WriteLine($"Evaluation created (id: {Id}, name: {Name})");
        #endregion
        #region Sample_CreateEvaluationObject_Evaluations_Async
        object dataSource = new
        {
            type = "azure_ai_target_completions",
            source = new
            {
                type = "file_content",
                content = new[] {
                    new { item = new { query = "What is the capital of France?" } },
                    new { item = new { query = "How do I reverse a string in Python? "} },
                }
            },
            input_messages = new
            {
                type = "template",
                template = new[] {
                    new {
                        type = "message",
                        role = "user",
                        content = new { type = "input_text", text = "{{item.query}}" }
                    }
                }
            },
            target = new
            {
                type = "azure_ai_agent",
                name = agentVersion.Name,
                // Version is optional. Defaults to latest version if not specified.
                version = agentVersion.Version,
            }
        };
        BinaryData runData = BinaryData.FromObjectAsJson(
            new
            {
                eval_id = Id,
                name = $"Evaluation Run for Agent {agentVersion.Name}",
                data_source = dataSource
            }
        );
        using BinaryContent runDataContent = BinaryContent.Create(runData);
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: Id, content: runDataContent);
        #endregion
        #region Snippet:Sample_WaitForRun_Evaluations_Async
        evaluationClient
        #endregion
    }

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
    //        //AIProjectDataset dataset = projectClient.GetDatasetsClient().UploadFileAndCreate(
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

    public Sample_Evaluations(bool isAsync) : base(isAsync)
    {
    }
}
