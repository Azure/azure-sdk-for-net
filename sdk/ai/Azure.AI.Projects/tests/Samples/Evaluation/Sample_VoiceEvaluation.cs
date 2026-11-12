// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

[LiveOnly]
public class Sample_VoiceEvaluation : EvaluationSampleBase
{
    public Sample_VoiceEvaluation(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [AsyncOnly]
    public async Task RecordedConversationAsync()
    {
        #region Snippet:Sample_VoiceEvaluation_Recorded
        string endpoint = GetRequiredVariable("FOUNDRY_PROJECT_ENDPOINT");
        string judge = GetRequiredVariable("FOUNDRY_MODEL_NAME");
        string datasetId = GetOptionalVariable("FOUNDRY_DATASET_ID");
        AIProjectClient project = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient client = project.ProjectOpenAIClient.GetEvaluationClient();

        BinaryData definition = CreateDefinition(judge,
            ["task_completion", "groundedness", "customer_satisfaction", "coherence"]);
        await WithRecordedDatasetAsync(project.Datasets,
            id => RunEvaluationAsync(client, definition, CreateRecordedRun(id)), datasetId);
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task VoiceAgentSimulationAsync()
    {
        #region Snippet:Sample_VoiceEvaluation_Simulation
        string endpoint = GetRequiredVariable("FOUNDRY_PROJECT_ENDPOINT");
        string judge = GetRequiredVariable("FOUNDRY_MODEL_NAME");
        string agentName = GetOptionalVariable("FOUNDRY_AGENT_NAME");
        string agentVersion = GetOptionalVariable("FOUNDRY_AGENT_VERSION");
        string simulatorModel = GetOptionalVariable("FOUNDRY_SIMULATOR_MODEL_NAME", "gpt-4.1");
        string simulatorVoice = GetOptionalVariable("FOUNDRY_SIMULATOR_VOICE", "en-US-AvaNeural");
        string voiceModel = GetOptionalVariable("FOUNDRY_VOICE_MODEL_NAME", "gpt-realtime");
        string voiceModelType = GetOptionalVariable("FOUNDRY_VOICE_MODEL_TYPE", "managed");
        AIProjectClient project = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient client = project.ProjectOpenAIClient.GetEvaluationClient();

        BinaryData definition = CreateDefinition(judge, ["task_completion"]);
        await WithVoiceAgentAsync(project.AgentAdministrationClient,
            (name, version) => RunEvaluationAsync(client, definition,
                CreateSimulationRun(name, version, simulatorModel, simulatorVoice)),
            agentName, agentVersion, voiceModel, voiceModelType);
        #endregion
    }

    #region Snippet:Sample_VoiceEvaluation_Upload
    internal static async Task WithRecordedDatasetAsync(
        AIProjectDatasetsOperations datasets, Func<string, Task> evaluate, string datasetId = null)
    {
        if (!string.IsNullOrWhiteSpace(datasetId))
        {
            await evaluate(datasetId);
            return;
        }

        string name = $"voice-evaluation-{Guid.NewGuid():N}";
        string audioName = $"{name}-audio";
        string directory = Path.Combine(Environment.CurrentDirectory, name);
        Directory.CreateDirectory(directory);
        bool audioCreated = false;
        bool datasetCreated = false;
        try
        {
            string recordings = Path.Combine(directory, "recordings");
            Directory.CreateDirectory(recordings);
            File.Copy(Path.Combine(AppContext.BaseDirectory, "TestData", "VoiceEvaluation", "conversation.wav"),
                Path.Combine(recordings, "conversation.wav"));
            FolderDataset audio = await datasets.UploadFolderAsync(audioName, "1", recordings);
            audioCreated = true;
            // UploadFolder flattens filenames and returns the last blob's URI. Register
            // the containing folder so asset_file_path is relative to that folder.
            using BinaryContent folder = BinaryContent.Create(new FolderDataset(new Uri(audio.DataUri, ".")));
            await datasets.CreateOrUpdateAsync(audioName, "1", folder);
            string jsonl = Path.Combine(directory, "conversations.jsonl");
            await File.WriteAllTextAsync(jsonl, JsonSerializer.Serialize(new
            {
                messages = new[]
                {
                    new { role = "user", content = "When do you close?" },
                    new { role = "assistant", content = "We close at nine PM." }
                },
                conversation_artifacts = new
                {
                    audio = new { asset_id = audio.Id.Replace("/data/", "/datasets/"), asset_file_path = "conversation.wav" }
                }
            }) + Environment.NewLine);
            FileDataset dataset = await datasets.UploadFileAsync(name, "1", jsonl);
            datasetCreated = true;
            await evaluate(dataset.Id);
        }
        finally
        {
            try
            {
                if (datasetCreated)
                {
                    await datasets.DeleteAsync(name, "1");
                }
            }
            finally
            {
                try
                {
                    if (audioCreated)
                    {
                        await datasets.DeleteAsync(audioName, "1");
                    }
                }
                finally
                {
                    Directory.Delete(directory, recursive: true);
                }
            }
        }
    }
    #endregion

    #region Snippet:Sample_VoiceEvaluation_Agent
    internal static async Task WithVoiceAgentAsync(
        AgentAdministrationClient agents, Func<string, string, Task> evaluate,
        string agentName = null, string agentVersion = null,
        string voiceModel = "gpt-realtime", string voiceModelType = "managed")
    {
        if (!string.IsNullOrWhiteSpace(agentName))
        {
            if (string.IsNullOrWhiteSpace(agentVersion))
            {
                ProjectsAgentRecord existing = await agents.GetAgentAsync(agentName);
                agentVersion = existing.GetLatestVersion().Version;
            }
            await evaluate(agentName, agentVersion);
            return;
        }

        agentName = $"voice-evaluation-{Guid.NewGuid():N}";
        VoiceAgentDefinition definition = new()
        {
            ModelType = new VoiceModelType(voiceModelType),
            Model = voiceModel,
            Instructions = "You are a store assistant. The Springfield, Illinois store closes at nine PM every day. Ask for the location if needed. Answer briefly.",
            Audio = new VoiceAgentAudioConfig
            {
                Output = new VoiceAgentAudioOutputConfig
                {
                    Voice = "en-US-AvaNeural",
                    VoiceType = VoiceType.AzureStandard
                }
            },
            Store = true
        };
        definition.OutputModalities.Add(VoiceOutputModality.Audio);
        ProjectsAgentVersion created = await agents.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(definition));
        try
        {
            await evaluate(agentName, created.Version);
        }
        finally
        {
            await agents.DeleteAgentVersionAsync(agentName, created.Version);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceEvaluation_Definition
    internal static BinaryData CreateDefinition(string judge, string[] metrics)
    {
        return BinaryData.FromObjectAsJson(new
        {
            name = "Voice conversation evaluation",
            data_source_config = new
            {
                type = "custom",
                item_schema = new
                {
                    type = "object",
                    properties = new
                    {
                        messages = new { type = "array" },
                        conversation_artifacts = new { type = "object" }
                    },
                    required = new[] { "conversation_artifacts" }
                },
                include_sample_schema = false
            },
            testing_criteria = metrics.Select(metric => new
            {
                type = "azure_ai_evaluator",
                name = metric,
                evaluator_name = $"builtin.{metric}_audio",
                evaluator_version = "1",
                initialization_parameters = new { deployment_name = judge }
            }).ToArray()
        });
    }
    #endregion

    #region Snippet:Sample_VoiceEvaluation_RecordedRun
    internal static BinaryData CreateRecordedRun(string datasetId)
    {
        return BinaryData.FromObjectAsJson(new
        {
            name = "Recorded audio conversation evaluation run",
            evaluation_level = "conversation",
            data_source = new
            {
                type = "jsonl",
                source = new { type = "file_id", id = datasetId }
            }
        });
    }
    #endregion

    #region Snippet:Sample_VoiceEvaluation_SimulationRun
    internal static BinaryData CreateSimulationRun(
        string agentName, string agentVersion, string simulatorModel, string simulatorVoice)
    {
        return BinaryData.FromObjectAsJson(new
        {
            name = "Voice agent simulation evaluation run",
            evaluation_level = "conversation",
            data_source = new
            {
                type = "azure_ai_user_conversation_simulation",
                source = new
                {
                    type = "inline_user_conversation_simulation",
                    test_cases = new[]
                    {
                        new
                        {
                            test_case_id = "store_hours",
                            test_case_description = "Ask when the store closes today. If asked for a location, say Springfield, Illinois. Do not invent a closing time."
                        }
                    }
                },
                target = new { type = "azure_ai_agent", name = agentName, version = agentVersion },
                model_configuration = new
                {
                    model = simulatorModel,
                    voice_model = new { type = "azure-standard", name = simulatorVoice }
                },
                default_simulation_configuration = new
                {
                    max_num_turns = 3,
                    conversation_repetitions = 1,
                    enable_conversation_dataset_generation = true
                }
            }
        });
    }
    #endregion

    #region Snippet:Sample_VoiceEvaluation_Run
    internal static async Task<IReadOnlyList<string>> RunEvaluationAsync(
        EvaluationClient client, BinaryData definition, BinaryData runData,
        CancellationToken cancellationToken = default,
        Func<CancellationToken, Task> pollingDelay = null)
    {
        using CancellationTokenSource timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeout.CancelAfter(TimeSpan.FromMinutes(10));
        RequestOptions options = new() { CancellationToken = timeout.Token };
        using BinaryContent definitionContent = BinaryContent.Create(definition);
        ClientResult evaluation = await client.CreateEvaluationAsync(definitionContent, options);
        string evaluationId = ParseClientResult(evaluation, ["id"])["id"];
        string runId = null;
        string status = null;
        try
        {
            using BinaryContent runContent = BinaryContent.Create(runData);
            ClientResult run = await client.CreateEvaluationRunAsync(evaluationId, runContent, options);
            runId = ParseClientResult(run, ["id"])["id"];
            status = ParseClientResult(run, ["status"])["status"];
            Console.WriteLine($"Evaluation: {evaluationId}, run: {runId}");
            while (status is not ("completed" or "failed" or "canceled" or "cancelled"))
            {
                await (pollingDelay?.Invoke(timeout.Token) ?? Task.Delay(TimeSpan.FromSeconds(5), timeout.Token));
                run = await client.GetEvaluationRunAsync(evaluationId, runId, options);
                status = ParseClientResult(run, ["status"])["status"];
            }
            if (status != "completed")
            {
                throw new InvalidOperationException($"Evaluation run {status}: {GetErrorMessageOrEmpty(run)}");
            }
            IReadOnlyList<string> results = await GetResultsListAsync(client, evaluationId, runId, timeout.Token);
            foreach (string item in results)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(GetResultsCounts(run));
            using JsonDocument document = JsonDocument.Parse(run.GetRawResponse().Content);
            JsonElement counts = document.RootElement.GetProperty("result_counts");
            if (counts.GetProperty("errored").GetInt32() > 0 || counts.GetProperty("total").GetInt32() == 0)
            {
                throw new InvalidOperationException("The evaluation has execution errors or produced no items.");
            }
            return results;
        }
        finally
        {
            try
            {
                if (runId != null && status is not ("completed" or "failed" or "canceled" or "cancelled"))
                {
                    // Foundry's cancellation route differs from the OpenAI SDK's route.
                    using PipelineMessage cancel = client.Pipeline.CreateMessage();
                    cancel.Request.Method = "POST";
                    cancel.Request.Uri = new Uri(
                        $"{client.Endpoint.AbsoluteUri.TrimEnd('/')}/evals/{Uri.EscapeDataString(evaluationId)}/runs/{Uri.EscapeDataString(runId)}/cancel");
                    await client.Pipeline.SendAsync(cancel);
                    if (cancel.Response.IsError)
                    {
                        throw new ClientResultException(cancel.Response);
                    }
                }
            }
            finally
            {
                await client.DeleteEvaluationAsync(evaluationId, new RequestOptions());
            }
        }
    }
    #endregion

    #region Snippet:Sample_VoiceEvaluation_Environment
    private static string GetOptionalVariable(string name, string defaultValue = null) =>
        Environment.GetEnvironmentVariable(name) is string value && !string.IsNullOrWhiteSpace(value)
            ? value
            : defaultValue;

    private static string GetRequiredVariable(string name) =>
        Environment.GetEnvironmentVariable(name) is string value && !string.IsNullOrWhiteSpace(value)
            ? value
            : throw new InvalidOperationException($"Set {name} before running this sample.");
    #endregion
}
