// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Evaluation;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

public class Sample_ScheduledEvaluations : SamplesBase
{
    #region Snippet:Sample_GetFile_ScheduledEvaluations
    private static string GetFile([CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(dirName, "data", "sample_data_evaluation.jsonl");
    }
    #endregion

    #region Snippet:Sample_GetStringValues_ScheduledEvaluations
    private static Dictionary<string, string> ParseClientResult(ClientResult result, string[] expectedProperties)
    {
        Dictionary<string, string> results = [];
        Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
        JsonDocument document = JsonDocument.ParseValue(ref reader);
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            foreach (string key in expectedProperties)
            {
                if (prop.NameEquals(Encoding.UTF8.GetBytes(key)) && prop.Value.ValueKind == JsonValueKind.String)
                {
                    results[key] = prop.Value.GetString();
                }
            }
        }
        List<string> notFoundItems = expectedProperties.Where((key) => !results.ContainsKey(key)).ToList();
        if (notFoundItems.Count > 0)
        {
            StringBuilder sbNotFound = new();
            foreach (string value in notFoundItems)
            {
                sbNotFound.Append($"{value}, ");
            }
            if (sbNotFound.Length > 2)
            {
                sbNotFound.Remove(sbNotFound.Length - 2, 2);
            }
            throw new InvalidOperationException($"The next keys were not found in returned result: {sbNotFound}.");
        }
        return results;
    }
    #endregion
    #region Snippet:Sample_GetData_ScheduledEvaluations
    private static BinaryData GetDataEvaluationConfig(string modelDeploymentName)
    {
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
        return BinaryData.FromObjectAsJson(
            new
            {
                name = "Label model test with dataset ID",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
    }
    #endregion
    #region Snippet:Sample_GetRedTeamData_ScheduledEvaluations
    private static BinaryData GetRedTeamsEvaluationConfig()
    {
        object[] testingCriteria = [
                new {
                type = "azure_ai_evaluator",
                name = "Prohibited Actions",
                evaluator_name = "builtin.prohibited_actions",
                evaluator_version = "1",
            },
            new {
                type = "azure_ai_evaluator",
                name = "Task Adherence",
                evaluator_name = "builtin.task_adherence",
                evaluator_version = "1",
            },
            new {
                type = "azure_ai_evaluator",
                name = "Sensitive Data Leakage",
                evaluator_name = "builtin.sensitive_data_leakage",
                evaluator_version = "1",
            },
            new {
                type = "azure_ai_evaluator",
                name = "Self Harm",
                evaluator_name = "builtin.self_harm",
                evaluator_version = "1",
            },
            new {
                type = "azure_ai_evaluator",
                name = "Violence",
                evaluator_name = "builtin.violence",
                evaluator_version = "1",
            },
            new {
                type = "azure_ai_evaluator",
                name = "Sexual",
                evaluator_name = "builtin.sexual",
                evaluator_version = "1"
            },
            new {
                type = "azure_ai_evaluator",
                name = "Hate Unfairness",
                evaluator_name = "builtin.hate_unfairness",
                evaluator_version = "1",
            },
        ];
        object dataSourceConfig = new
        {
            type = "azure_ai_source",
            scenario = "red_team"
        };
        return BinaryData.FromObjectAsJson(
            new
            {
                name = $"Red Team Agent Safety Evaluation -{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
    }
    #endregion
    #region Snippet:Sample_CreateRunObject_ScheduledEvaluations
    private static BinaryData CreateRunObject(string evaluationId, string evaluationName, string fileDatasetId)
    {
        return BinaryData.FromObjectAsJson(new
        {
            eval_id = evaluationId,
            name = evaluationName,
            metadata = new
            {
                team = "eval-exp",
                scenario = "dataset-id-v1"
            },
            data_source = new
            {
                type = "jsonl",
                source = new
                {
                    id = fileDatasetId,
                    type = "file_id",
                }
            }
        });
    }
    #endregion
    #region Snippet:Sample_CreateRedTeamRunObject_ScheduledEvaluations
    private static BinaryData CreateRedTeamRunObject(string evaluationId, string evaluationName, EvaluationTaxonomy taxonomy)
    {
        return BinaryData.FromObjectAsJson(new
        {
            eval_id = evaluationId,
            name = evaluationName,
            metadata = new
            {
                team = "eval-exp",
                scenario = "dataset-id-v1"
            },
            data_source = new
            {
                type = "azure_ai_red_team",
                item_generation_params = new
                {
                    type = "red_team_taxonomy",
                    attack_strategies = new[] { "Flip", "Base64" },
                    num_turns = 5,
                    source = new
                    {
                        type = "file_id",
                        id = taxonomy.Id,
                        attack_strategies = new[] { "Flip", "Base64" },
                    }
                }
            }
        });
    }
    #endregion
    private static async Task ScheduleEvaluationAsync(AIProjectClient projectClient, string connectionName, string modelDeploymentName)
    {
        #region Snippet:Sample_CreateEvaluation_ScheduledEvaluations_Async
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetDataEvaluationConfig(modelDeploymentName));
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        string datasetName = $"SampleEvaluationDataset-{Guid.NewGuid().ToString("N").Substring(0, 8)}";
        FileDataset fileDataset = await projectClient.Datasets.UploadFileAsync(
            name: datasetName,
            version: "1",
            filePath: GetFile(),
            connectionName: connectionName
        );
        Console.WriteLine($"Uploaded new dataset {fileDataset.Name} version {fileDataset.Version}");
        #endregion
        #region Snippet:Sample_ScheduleEvaluation_ScheduledEvaluations_Async
        RecurrenceTrigger trigger = new(interval: 1, new DailyRecurrenceSchedule(hours: [9]));
        EvaluationScheduleTask scheduleTask = new(evalId: evaluationId, evalRun: CreateRunObject(evaluationId, evaluationName, fileDataset.Id));
        ProjectsSchedule schedule = new(enabled: true, trigger: trigger, task: scheduleTask)
        {
            DisplayName = "Dataset Evaluation Eval Run Schedule"
        };
        ProjectsSchedule scheduleResponse = await projectClient.Schedules.CreateOrUpdateAsync(id: "dataset-eval-run-schedule-9am", resource: schedule);
        while (scheduleResponse.ProvisioningStatus != ScheduleProvisioningStatus.Failed && scheduleResponse.ProvisioningStatus != ScheduleProvisioningStatus.Succeeded)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            scheduleResponse = await projectClient.Schedules.GetAsync(scheduleResponse.Id);
        }
        if (scheduleResponse.ProvisioningStatus == ScheduleProvisioningStatus.Failed)
        {
            throw new InvalidOperationException($"Failed to create a schedule.");
        }
        Console.WriteLine($"Schedule created for dataset evaluation: {scheduleResponse.Id}");
        #endregion
        #region Snippet:Sample_ListEvalSchedules_ScheduledEvaluations_Async
        AsyncCollectionResult<ScheduleRun> runs = projectClient.Schedules.GetRunsAsync(id: scheduleResponse.Id);
        await foreach (ScheduleRun run in runs)
        {
            Console.WriteLine($"Schedule ID: {run.ScheduleId}, run ID: {run.RunId}, is successful: {run.Success}, error: {(string.IsNullOrEmpty(run.Error) ? "None" : run.Error)}");
        }
        #endregion
        #region Snippet:Sample_CleanupEvalSchedules_ScheduledEvaluations_Async
        await projectClient.Schedules.DeleteAsync(id: scheduleResponse.Id);
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new());
        await projectClient.Datasets.DeleteAsync(name: datasetName, version: "1");
        #endregion
    }

    private static void ScheduleEvaluationSync(AIProjectClient projectClient, string connectionName, string modelDeploymentName)
    {
        #region Snippet:Sample_CreateEvaluation_ScheduledEvaluations_Sync
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetDataEvaluationConfig(modelDeploymentName));
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        string datasetName = $"SampleEvaluationDataset-{Guid.NewGuid().ToString("N").Substring(0, 8)}";
        FileDataset fileDataset = projectClient.Datasets.UploadFile(
            name: datasetName,
            version: "1",
            filePath: GetFile(),
            connectionName: connectionName
        );
        Console.WriteLine($"Uploaded new dataset {fileDataset.Name} version {fileDataset.Version}");
        #endregion
        #region Snippet:Sample_ScheduleEvaluation_ScheduledEvaluations_Sync
        RecurrenceTrigger trigger = new(interval: 1, new DailyRecurrenceSchedule(hours: [9]));
        EvaluationScheduleTask scheduleTask = new(evalId: evaluationId, evalRun: CreateRunObject(evaluationId, evaluationName, fileDataset.Id));
        ProjectsSchedule schedule = new(enabled: true, trigger: trigger, task: scheduleTask)
        {
            DisplayName = "Dataset Evaluation Eval Run Schedule"
        };
        ProjectsSchedule scheduleResponse = projectClient.Schedules.CreateOrUpdate(id: "dataset-eval-run-schedule-9am", resource: schedule);
        while (scheduleResponse.ProvisioningStatus != ScheduleProvisioningStatus.Failed && scheduleResponse.ProvisioningStatus != ScheduleProvisioningStatus.Succeeded)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            scheduleResponse = projectClient.Schedules.Get(scheduleResponse.Id);
        }
        if (scheduleResponse.ProvisioningStatus == ScheduleProvisioningStatus.Failed)
        {
            throw new InvalidOperationException($"Failed to create a schedule.");
        }
        Console.WriteLine($"Schedule created for dataset evaluation: {scheduleResponse.Id}");
        #endregion
        #region Snippet:Sample_ListEvalSchedules_ScheduledEvaluations_Sync
        CollectionResult<ScheduleRun> runs = projectClient.Schedules.GetRuns(id: scheduleResponse.Id);
        foreach (ScheduleRun run in runs)
        {
            Console.WriteLine($"Schedule ID: {run.ScheduleId}, run ID: {run.RunId}, is successful: {run.Success}, error: {(string.IsNullOrEmpty(run.Error) ? "None" : run.Error)}");
        }
        #endregion
        #region Snippet:Sample_CleanupEvalSchedules_ScheduledEvaluations_Sync
        projectClient.Schedules.Delete(id: scheduleResponse.Id);
        evaluationClient.DeleteEvaluation(evaluationId, new());
        projectClient.Datasets.Delete(name: datasetName, version: "1");
        #endregion
    }

    #region Snippet:Sample_GetAITarget_ScheduledEvaluations
    private static AzureAIAgentTarget GetAgentTarget(ProjectsAgentVersion agentVersion)
    {
        AzureAIAgentTarget target = new(name: agentVersion.Name)
        {
            Version = agentVersion.Version,
        };
        if (agentVersion.Definition is DeclarativeAgentDefinition agentDefinition)
        {
            foreach (ResponseTool agentTool in agentDefinition.Tools)
            {
                ToolDescription tool = new();
                ProjectsAgentTool projectTool = agentTool.AsAgentTool();
                if (projectTool is OpenAPITool openAPITool)
                {
                    tool.Name = openAPITool.FunctionDefinition.Name;
                    tool.Description = string.IsNullOrEmpty(openAPITool.FunctionDefinition.Description) ? "No description provided" : openAPITool.FunctionDefinition.Description;
                }
                else
                {
                    tool.Name = $"Tool of type {projectTool.GetType()}";
                    tool.Description = "No description provided";
                }
                target.ToolDescriptions.Add(tool);
            }
        }
        if (target.ToolDescriptions.Count == 0)
        {
            target.ToolDescriptions.Add(new()
            {
                Name = "No Tools",
                Description = "This agent does not use any tools."
            });
        }
        return target;
    }
    #endregion

    private static async Task ScheduleRedTeamsAsync(AIProjectClient projectClient, string modelDeploymentName)
    {
        #region Snippet:Sample_CreateAgentRun_ScheduledEvaluations_Async
        DeclarativeAgentDefinition agentDefinition = new(modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that answers general questions"
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(agentName: "MyAgent", options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateRedTeamEvaluationRun_ScheduledEvaluations_Async
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetRedTeamsEvaluationConfig());
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created for red teaming: {evaluationName}; id: {evaluationId}");
        #endregion
        #region Snippet:Sample_AgentTaxonomy_ScheduledEvaluations_Async
        AzureAIAgentTarget agentTarget = GetAgentTarget(agentVersion);
        AgentTaxonomyInput agentTaxonomyInput = new(target: agentTarget, riskCategories: [RiskCategory.ProhibitedActions]);
        EvaluationTaxonomy evalTaxonomyInput = new(agentTaxonomyInput)
        {
            Description = "Taxonomy for red teaming evaluation"
        };
        EvaluationTaxonomy taxonomy = await projectClient.EvaluationTaxonomies.CreateAsync(agentVersion.Name, body: evalTaxonomyInput);
        DirectoryInfo dataPath = Directory.CreateDirectory("data_folder");
        string taxonomyPath = Path.Combine(dataPath.FullName, $"taxonomy_{agentVersion.Name}.json");
        BinaryData taxonomyJson = ((IJsonModel<EvaluationTaxonomy>)taxonomy).Write(ModelReaderWriterOptions.Json);
        File.WriteAllBytes(taxonomyPath, taxonomyJson.ToArray());
        Console.WriteLine($"RedTeaming Taxonomy created for agent: {agentVersion.Name}. Taxonomy written to {taxonomyPath}");
        #endregion
        #region Snippet:Sample_ScheduleEvaluationRedTeam_ScheduledEvaluations_Async
        RecurrenceTrigger trigger = new(interval: 1, new DailyRecurrenceSchedule(hours: [9]));
        EvaluationScheduleTask scheduleTask = new(evalId: evaluationId, evalRun: CreateRedTeamRunObject(evaluationId, evaluationName, taxonomy));
        ProjectsSchedule schedule = new(enabled: true, trigger: trigger, task: scheduleTask)
        {
            DisplayName = "RedTeam Eval Run Schedule"
        };
        ProjectsSchedule scheduleResponse = await projectClient.Schedules.CreateOrUpdateAsync(id: "redteam-eval-run-schedule-9am", resource: schedule);
        while (scheduleResponse.ProvisioningStatus != ScheduleProvisioningStatus.Failed && scheduleResponse.ProvisioningStatus != ScheduleProvisioningStatus.Succeeded)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            scheduleResponse = await projectClient.Schedules.GetAsync(scheduleResponse.Id);
        }
        if (scheduleResponse.ProvisioningStatus == ScheduleProvisioningStatus.Failed)
        {
            throw new InvalidOperationException($"Failed to create a schedule.");
        }
        Console.WriteLine($"Schedule created for dataset evaluation: {scheduleResponse.Id}");
        #endregion
        #region Snippet:Sample_ListEvalSchedulesRedTeam_ScheduledEvaluations_Async
        AsyncCollectionResult<ScheduleRun> runs = projectClient.Schedules.GetRunsAsync(id: scheduleResponse.Id);
        await foreach (ScheduleRun run in runs)
        {
            Console.WriteLine($"Schedule ID: {run.ScheduleId}, run ID: {run.RunId}, is successful: {run.Success}, error: {(string.IsNullOrEmpty(run.Error) ? "None" : run.Error)}");
        }
        #endregion
        #region Snippet:Sample_CleanupRedTeams_ScheduledEvaluations_Async
        await projectClient.Schedules.DeleteAsync(id: scheduleResponse.Id);
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new());
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    private static void ScheduleRedTeamsSync(AIProjectClient projectClient, string modelDeploymentName)
    {
        #region Snippet:Sample_CreateAgentRun_ScheduledEvaluations_Sync
        DeclarativeAgentDefinition agentDefinition = new(modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that answers general questions"
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(agentName: "MyAgent", options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateRedTeamEvaluationRun_ScheduledEvaluations_Sync
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetRedTeamsEvaluationConfig());
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created for red teaming: {evaluationName}; id: {evaluationId}");
        #endregion
        #region Snippet:Sample_AgentTaxonomy_ScheduledEvaluations_Sync
        AzureAIAgentTarget agentTarget = GetAgentTarget(agentVersion);
        AgentTaxonomyInput agentTaxonomyInput = new(target: agentTarget, riskCategories: [RiskCategory.ProhibitedActions]);
        EvaluationTaxonomy evalTaxonomyInput = new(agentTaxonomyInput)
        {
            Description = "Taxonomy for red teaming evaluation"
        };
        EvaluationTaxonomy taxonomy = projectClient.EvaluationTaxonomies.Create(agentVersion.Name, body: evalTaxonomyInput);
        DirectoryInfo dataPath = Directory.CreateDirectory("data_folder");
        string taxonomyPath = Path.Combine(dataPath.FullName, $"taxonomy_{agentVersion.Name}.json");
        BinaryData taxonomyJson = ((IJsonModel<EvaluationTaxonomy>)taxonomy).Write(ModelReaderWriterOptions.Json);
        File.WriteAllBytes(taxonomyPath, taxonomyJson.ToArray());
        Console.WriteLine($"RedTeaming Taxonomy created for agent: {agentVersion.Name}. Taxonomy written to {taxonomyPath}");
        #endregion
        #region Snippet:Sample_ScheduleEvaluationRedTeam_ScheduledEvaluations_Sync
        RecurrenceTrigger trigger = new(interval: 1, new DailyRecurrenceSchedule(hours: [9]));
        EvaluationScheduleTask scheduleTask = new(evalId: evaluationId, evalRun: CreateRedTeamRunObject(evaluationId, evaluationName, taxonomy));
        ProjectsSchedule schedule = new(enabled: true, trigger: trigger, task: scheduleTask)
        {
            DisplayName = "RedTeam Eval Run Schedule"
        };
        ProjectsSchedule scheduleResponse = projectClient.Schedules.CreateOrUpdate(id: "redteam-eval-run-schedule-9am", resource: schedule);
        while (scheduleResponse.ProvisioningStatus != ScheduleProvisioningStatus.Failed && scheduleResponse.ProvisioningStatus != ScheduleProvisioningStatus.Succeeded)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            scheduleResponse = projectClient.Schedules.Get(scheduleResponse.Id);
        }
        if (scheduleResponse.ProvisioningStatus == ScheduleProvisioningStatus.Failed)
        {
            throw new InvalidOperationException($"Failed to create a schedule.");
        }
        Console.WriteLine($"Schedule created for dataset evaluation: {scheduleResponse.Id}");
        #endregion
        #region Snippet:Sample_ListEvalSchedulesRedTeam_ScheduledEvaluations_Sync
        CollectionResult<ScheduleRun> runs = projectClient.Schedules.GetRuns(id: scheduleResponse.Id);
        foreach (ScheduleRun run in runs)
        {
            Console.WriteLine($"Schedule ID: {run.ScheduleId}, run ID: {run.RunId}, is successful: {run.Success}, error: {(string.IsNullOrEmpty(run.Error) ? "None" : run.Error)}");
        }
        #endregion
        #region Snippet:Sample_CleanupRedTeams_ScheduledEvaluations_Sync
        projectClient.Schedules.Delete(id: scheduleResponse.Id);
        evaluationClient.DeleteEvaluation(evaluationId, new());
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task EvaluationsExampleAsync()
    {
        #region Snippet:Sample_CreateClients_ScheduledEvaluations
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
        #endregion
        await ScheduleEvaluationAsync(projectClient, connectionName, modelDeploymentName);
        await ScheduleRedTeamsAsync(projectClient, modelDeploymentName);
    }

    [Test]
    [SyncOnly]
    public void EvaluationsExample()
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
        ScheduleEvaluationSync(projectClient, connectionName, modelDeploymentName);
        ScheduleRedTeamsSync(projectClient, modelDeploymentName);
    }

    public Sample_ScheduledEvaluations(bool isAsync) : base(isAsync)
    {
    }
}
