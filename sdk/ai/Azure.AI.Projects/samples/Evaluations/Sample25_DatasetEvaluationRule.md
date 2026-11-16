# Sample of using a scheduled agent evaluation rule in Azure.AI.Projects.

This sample demonstrates how to create a scheduled dataset evaluation rule that targets an agent. Every day at 09:00 UTC, the rule sends a fixed set of queries to the agent and evaluates its responses. The project managed identity needs the "Foundry User" role on the project.

The `ParseClientResult` helper used below is defined in [Sample10_EvaluationsMonitor](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/samples/Evaluations/Sample10_EvaluationsMonitor.md); copy it into your sample.

## Run the sample

1. First, we need to create project client and read the environment variables which will be used in the next steps. We will also create an `EvaluationClient` to create evaluation.

```C# Snippet:Sample_CreateClients_DatasetEvaluationRule
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
```

2. Create the agent to evaluate.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_DatasetEvaluationRule_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that answers general questions",
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "MyScheduledAgent",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_DatasetEvaluationRule_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that answers general questions",
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "MyScheduledAgent",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

3. Define the evaluation. Each dataset item has a `query`, and the coherence evaluator scores the agent response in `sample.output_text`.

```C# Snippet:Sample_EvaluationConfig_DatasetEvaluationRule
private static BinaryData GetAgentEvaluationConfig(string modelDeploymentName)
{
    return BinaryData.FromObjectAsJson(
        new
        {
            name = "Scheduled Agent Evaluation",
            data_source_config = new
            {
                type = "custom",
                item_schema = new
                {
                    type = "object",
                    properties = new
                    {
                        query = new { type = "string" }
                    },
                    required = new[] { "query" }
                },
                include_sample_schema = true
            },
            testing_criteria = new[]
            {
                new {
                    type = "azure_ai_evaluator",
                    name = "coherence",
                    evaluator_name = "builtin.coherence",
                    initialization_parameters = new { deployment_name = modelDeploymentName },
                    data_mapping = new { query = "{{item.query}}", response = "{{sample.output_text}}" }
                },
            }
        }
    );
}
```

4. Create the evaluation.

Synchronous sample:
```C# Snippet:Sample_CreateEvaluation_DatasetEvaluationRule_Sync
using BinaryContent evaluationDataContent = BinaryContent.Create(GetAgentEvaluationConfig(modelDeploymentName));
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluation_DatasetEvaluationRule_Async
using BinaryContent evaluationDataContent = BinaryContent.Create(GetAgentEvaluationConfig(modelDeploymentName));
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
```

5. Define the data source. It contains the inline dataset, the message template sent to the agent and the agent target. The `type` must be set to `azure_ai_target_completions`.

```C# Snippet:Sample_DataSource_DatasetEvaluationRule
private static BinaryData GetAgentTargetDataSource(ProjectsAgentVersion agentVersion)
{
    return BinaryData.FromObjectAsJson(
        new
        {
            // The type must be set explicitly; the service rejects the data source without it.
            type = "azure_ai_target_completions",
            source = new
            {
                type = "file_content",
                content = new[] {
                    new { item = new { query = "What is the capital of France?" } },
                    new { item = new { query = "How many legs does a spider have?" } },
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
                version = agentVersion.Version,
            }
        }
    );
}
```

6. Define the rule. `DatasetEvaluationRuleAction` takes the evaluation ID and the data source. The rule is triggered by a timer, which is set to a daily `RecurrenceTrigger`.

```C# Snippet:Sample_CreateRule_DatasetEvaluationRule
DatasetEvaluationRuleAction datasetAction = new(
    evalId: evaluationId,
    source: GetAgentTargetDataSource(agentVersion));
EvaluationRule datasetRule = new(
    action: datasetAction, eventType: EvaluationRuleEventType.TimerTrigger, enabled: true)
{
    DisplayName = "My Agent Dataset Eval Rule",
    Description = "Daily evaluation of the agent against a fixed dataset.",
    Schedule = new RecurrenceTrigger(interval: 1, schedule: new DailyRecurrenceSchedule(hours: [9]))
    {
        TimeZone = "UTC",
    },
};
```

7. Schedule provisioning runs in the background, and the rule cannot be updated or deleted until it finishes. Use a helper that polls for up to five minutes and passes cancellation to each request. On timeout, it reports the rule ID and last status.

Synchronous sample:
```C# Snippet:Sample_WaitForProvisioning_DatasetEvaluationRule_Sync
private static EvaluationRule WaitForProvisioning(
    AIProjectClient projectClient,
    string ruleId,
    CancellationToken cancellationToken = default)
{
    TimeSpan timeout = TimeSpan.FromMinutes(5);
    using CancellationTokenSource timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
    timeoutCts.CancelAfter(timeout);
    string lastStatus = "unknown";
    try
    {
        EvaluationRule rule = projectClient.EvaluationRules.Get(ruleId, timeoutCts.Token);
        lastStatus = rule.ProvisioningStatus.ToString();
        while (rule.ProvisioningStatus == ScheduleProvisioningStatus.Creating
            || rule.ProvisioningStatus == ScheduleProvisioningStatus.Updating)
        {
            if (timeoutCts.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(5)))
            {
                timeoutCts.Token.ThrowIfCancellationRequested();
            }
            rule = projectClient.EvaluationRules.Get(ruleId, timeoutCts.Token);
            lastStatus = rule.ProvisioningStatus.ToString();
        }
        return rule;
    }
    catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
    {
        throw new TimeoutException(
            $"Evaluation rule '{ruleId}' provisioning timed out after {timeout}. "
            + $"Last provisioning status: {lastStatus}.");
    }
}
```

Asynchronous sample:
```C# Snippet:Sample_WaitForProvisioning_DatasetEvaluationRule_Async
private static async Task<EvaluationRule> WaitForProvisioningAsync(
    AIProjectClient projectClient,
    string ruleId,
    CancellationToken cancellationToken = default)
{
    TimeSpan timeout = TimeSpan.FromMinutes(5);
    using CancellationTokenSource timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
    timeoutCts.CancelAfter(timeout);
    string lastStatus = "unknown";
    try
    {
        EvaluationRule rule = await projectClient.EvaluationRules.GetAsync(ruleId, timeoutCts.Token);
        lastStatus = rule.ProvisioningStatus.ToString();
        while (rule.ProvisioningStatus == ScheduleProvisioningStatus.Creating
            || rule.ProvisioningStatus == ScheduleProvisioningStatus.Updating)
        {
            await Task.Delay(TimeSpan.FromSeconds(5), timeoutCts.Token);
            rule = await projectClient.EvaluationRules.GetAsync(ruleId, timeoutCts.Token);
            lastStatus = rule.ProvisioningStatus.ToString();
        }
        return rule;
    }
    catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
    {
        throw new TimeoutException(
            $"Evaluation rule '{ruleId}' provisioning timed out after {timeout}. "
            + $"Last provisioning status: {lastStatus}.");
    }
}
```

8. Create the rule and wait for provisioning to finish.

Synchronous sample:
```C# Snippet:Sample_CreateRuleOnAzure_DatasetEvaluationRule_Sync
EvaluationRule createdRule = projectClient.EvaluationRules.CreateOrUpdate(
    id: "my-dataset-eval-rule",
    evaluationRule: datasetRule);
Console.WriteLine($"Dataset evaluation rule created (id: {createdRule.Id}, name: {createdRule.DisplayName})");
// The rule cannot be updated or deleted until its schedule provisioning finishes.
createdRule = WaitForProvisioning(projectClient, createdRule.Id);
Console.WriteLine($"Provisioning status: {createdRule.ProvisioningStatus}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRuleOnAzure_DatasetEvaluationRule_Async
EvaluationRule createdRule = await projectClient.EvaluationRules.CreateOrUpdateAsync(
    id: "my-dataset-eval-rule",
    evaluationRule: datasetRule);
Console.WriteLine($"Dataset evaluation rule created (id: {createdRule.Id}, name: {createdRule.DisplayName})");
// The rule cannot be updated or deleted until its schedule provisioning finishes.
createdRule = await WaitForProvisioningAsync(projectClient, createdRule.Id);
Console.WriteLine($"Provisioning status: {createdRule.ProvisioningStatus}");
```

9. Disable the rule and wait for the update to finish.

Synchronous sample:
```C# Snippet:Sample_DisableRule_DatasetEvaluationRule_Sync
createdRule.Enabled = false;
EvaluationRule disabledRule = projectClient.EvaluationRules.CreateOrUpdate(
    id: createdRule.Id,
    evaluationRule: createdRule);
disabledRule = WaitForProvisioning(projectClient, disabledRule.Id);
Console.WriteLine($"Rule disabled (enabled: {disabledRule.Enabled}, provisioning status: {disabledRule.ProvisioningStatus})");
```

Asynchronous sample:
```C# Snippet:Sample_DisableRule_DatasetEvaluationRule_Async
createdRule.Enabled = false;
EvaluationRule disabledRule = await projectClient.EvaluationRules.CreateOrUpdateAsync(
    id: createdRule.Id,
    evaluationRule: createdRule);
disabledRule = await WaitForProvisioningAsync(projectClient, disabledRule.Id);
Console.WriteLine($"Rule disabled (enabled: {disabledRule.Enabled}, provisioning status: {disabledRule.ProvisioningStatus})");
```

10. Delete the rule, the evaluation and the agent.

Synchronous sample:
```C# Snippet:Sample_Cleanup_DatasetEvaluationRule_Sync
projectClient.EvaluationRules.Delete(id: disabledRule.Id);
Console.WriteLine($"Dataset evaluation rule deleted (id: {disabledRule.Id})");
evaluationClient.DeleteEvaluation(evaluationId, new RequestOptions());
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_DatasetEvaluationRule_Async
await projectClient.EvaluationRules.DeleteAsync(id: disabledRule.Id);
Console.WriteLine($"Dataset evaluation rule deleted (id: {disabledRule.Id})");
await evaluationClient.DeleteEvaluationAsync(evaluationId, new RequestOptions());
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
