// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects.Evaluation;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

public class Sample_TraceEvaluationRule : EvaluationSampleBase
{
    #region Snippet:Sample_EvaluationConfig_TraceEvaluationRule
    private static BinaryData GetTraceEvaluationConfig(string modelDeploymentName)
    {
        return BinaryData.FromObjectAsJson(
            new
            {
                name = "Trace Evaluation",
                data_source_config = new
                {
                    type = "azure_ai_source",
                    scenario = "traces"
                },
                testing_criteria = new[]
                {
                    new {
                        type = "azure_ai_evaluator",
                        name = "coherence",
                        evaluator_name = "builtin.coherence",
                        initialization_parameters = new { deployment_name = modelDeploymentName },
                        data_mapping = new { query = "{{item.query}}", response = "{{item.response}}" }
                    },
                }
            }
        );
    }
    #endregion

    #region Snippet:Sample_WaitForProvisioning_TraceEvaluationRule_Async
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
    #endregion

    #region Snippet:Sample_WaitForProvisioning_TraceEvaluationRule_Sync
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
    #endregion

    [Test]
    [AsyncOnly]
    public async Task TraceEvaluationRuleExampleAsync()
    {
        #region Snippet:Sample_CreateClients_TraceEvaluationRule
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var agentName = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var agentName = TestEnvironment.FOUNDRY_AGENT_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #endregion
        #region Snippet:Sample_CreateEvaluation_TraceEvaluationRule_Async
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetTraceEvaluationConfig(modelDeploymentName));
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
        #endregion
        #region Snippet:Sample_CreateRule_TraceEvaluationRule
        TracesEvalRunDataSource traceSource = new()
        {
            AgentName = agentName,
            MaxTraces = 10,
        };
        TraceEvaluationRuleAction traceAction = new(
            evalId: evaluationId,
            source: ModelReaderWriter.Write(traceSource, ModelReaderWriterOptions.Json));
        EvaluationRule traceRule = new(
            action: traceAction, eventType: EvaluationRuleEventType.TimerTrigger, enabled: true)
        {
            DisplayName = "My Trace Eval Rule",
            Description = "Hourly trace evaluation of agent traces.",
            Schedule = new RecurrenceTrigger(interval: 1, schedule: new HourlyRecurrenceSchedule()),
        };
        #endregion
        #region Snippet:Sample_CreateRuleOnAzure_TraceEvaluationRule_Async
        EvaluationRule createdRule = await projectClient.EvaluationRules.CreateOrUpdateAsync(
            id: "my-trace-eval-rule",
            evaluationRule: traceRule);
        Console.WriteLine($"Trace evaluation rule created (id: {createdRule.Id}, name: {createdRule.DisplayName})");
        // The rule cannot be updated or deleted until its schedule provisioning finishes.
        createdRule = await WaitForProvisioningAsync(projectClient, createdRule.Id);
        Console.WriteLine($"Provisioning status: {createdRule.ProvisioningStatus}");
        #endregion
        #region Snippet:Sample_Cleanup_TraceEvaluationRule_Async
        await projectClient.EvaluationRules.DeleteAsync(id: createdRule.Id);
        Console.WriteLine($"Trace evaluation rule deleted (id: {createdRule.Id})");
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new RequestOptions());
        #endregion
    }

    [Test]
    [SyncOnly]
    public void TraceEvaluationRuleExampleSync()
    {
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var agentName = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var agentName = TestEnvironment.FOUNDRY_AGENT_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #region Snippet:Sample_CreateEvaluation_TraceEvaluationRule_Sync
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetTraceEvaluationConfig(modelDeploymentName));
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
        #endregion
        TracesEvalRunDataSource traceSource = new()
        {
            AgentName = agentName,
            MaxTraces = 10,
        };
        TraceEvaluationRuleAction traceAction = new(
            evalId: evaluationId,
            source: ModelReaderWriter.Write(traceSource, ModelReaderWriterOptions.Json));
        EvaluationRule traceRule = new(
            action: traceAction, eventType: EvaluationRuleEventType.TimerTrigger, enabled: true)
        {
            DisplayName = "My Trace Eval Rule",
            Description = "Hourly trace evaluation of agent traces.",
            Schedule = new RecurrenceTrigger(interval: 1, schedule: new HourlyRecurrenceSchedule()),
        };
        #region Snippet:Sample_CreateRuleOnAzure_TraceEvaluationRule_Sync
        EvaluationRule createdRule = projectClient.EvaluationRules.CreateOrUpdate(
            id: "my-trace-eval-rule",
            evaluationRule: traceRule);
        Console.WriteLine($"Trace evaluation rule created (id: {createdRule.Id}, name: {createdRule.DisplayName})");
        // The rule cannot be updated or deleted until its schedule provisioning finishes.
        createdRule = WaitForProvisioning(projectClient, createdRule.Id);
        Console.WriteLine($"Provisioning status: {createdRule.ProvisioningStatus}");
        #endregion
        #region Snippet:Sample_Cleanup_TraceEvaluationRule_Sync
        projectClient.EvaluationRules.Delete(id: createdRule.Id);
        Console.WriteLine($"Trace evaluation rule deleted (id: {createdRule.Id})");
        evaluationClient.DeleteEvaluation(evaluationId, new RequestOptions());
        #endregion
    }

    public Sample_TraceEvaluationRule(bool isAsync) : base(isAsync)
    { }
}
