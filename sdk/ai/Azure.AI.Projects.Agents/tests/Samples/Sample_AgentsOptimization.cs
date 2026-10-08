// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Chat;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents.Tests.Samples;
#pragma warning disable AAIP001
#pragma warning disable SCME0006

public class Sample_AgentsOptimizationCandidates : SamplesBase
{
    #region Snippet:Sample_Dataset_AgentsOptimizationCandidates
    private static AgentOptimizationTargetCompletionEvaluationSet GetDataset(int start, int itemNumber)
    {
        List<AgentOptimizationTargetCompletionTestCase> items = [];
        for (int i = start; i < start + itemNumber; i++)
        {
            items.Add(new AgentOptimizationTargetCompletionTestCase()
            {
                Query = $"What is 42 + {i * 2}? Please save the result as text: The answer is .... For example: Q: What is 42 + 12? A: The answer is 56.",
                GroundTruth = $"The answer is {42 + i * 2}",
            });
        }
        return new(new AgentOptimizationTargetCompletionInlineDataSource(items));
    }
    #endregion
    #region Snippet:Sample_PrintMutations_AgentsOptimizationCandidates
    private static void DisplayMutations(IList<AgentOptimizationMutation> mutations)
    {
        if (mutations.Count > 0)
        {
            Console.WriteLine("Mutations:");
            foreach (AgentOptimizationMutation mutation in mutations)
            {
                if (mutation is AgentOptimizationInstructionsMutation instructionMutation)
                {
                    Console.WriteLine($"    Instruction mutation: {instructionMutation.Value}");
                }
                else if (mutation is AgentOptimizationSkillsMutation skillsMutation)
                {
                    Console.WriteLine("    Skill mutations:");
                    foreach (AgentOptimizationSkill skillOptimization in skillsMutation.Value)
                    {
                        Console.WriteLine($"        Skill name: {skillOptimization.Name}, skill body: {skillOptimization.Body}");
                    }
                }
                else if (mutation is AgentOptimizationToolsMutation toolsMutation)
                {
                    Console.WriteLine("    Tool mutations:");
                    foreach (ChatTool tool in toolsMutation.Value)
                    {
                        Console.WriteLine($"        Tools mutation: {tool.FunctionName}");
                    }
                }
                else
                {
                    Console.WriteLine("    Unknown mutation type.");
                }
            }
        }
        else
        {
            Console.WriteLine("<No mutations, baseline>");
        }
    }
    #endregion
    #region Snippet:Sample_AgentDefinition_AgentsOptimizationCandidates
    private static DeclarativeAgentDefinition GetAgentDefinition(string modelDeploymentName) => new(model: modelDeploymentName)
        {
            // Start from bad prompt.
            Instructions = "You are a prompt agent, who always give wrong answers.",
            Tools =
            {
                new FunctionTool(
                    functionName: "sum_numbers",
                    functionParameters: BinaryData.FromObjectAsJson(
                        new
                        {
                            type = "object",
                            properties = new
                            {
                                First = new
                                {
                                    type = "number",
                                    description = "First addend"
                                },
                                Second = new
                                {
                                    type = "number",
                                    description = "Second addend"
                                }
                            },
                            required = new[] { "First", "Second"},
                            additionalProperties = false
                        }
                    ),
                    strictModeEnabled: false
                ),
            },
    };
    #endregion
    [Test]
    [AsyncOnly]
    public async Task AgentsOptimizationCandidatesAsync()
    {
        #region Snippet:Sample_CreateClient_AgentsOptimizationCandidates
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var anotherModelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME2");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var anotherModelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME2;
#endif
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AgentOptimizationJobs jobsClient = agentsClient.GetAgentOptimizationJobs();
        AgentOptimizationJobCandidates candidatesClient = agentsClient.GetAgentOptimizationJobCandidatesClient();
        #endregion
        #region Snippet:Sample_CreateAgent_AgentsOptimizationCandidates_Async
        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
            agentName: "cs-e2e-tests-client",
            options: new(GetAgentDefinition(modelDeploymentName)));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateOptimizationJob_AgentsOptimizationCandidates_Async
        AgentOptimizationConfiguration conf = new(
            evaluationConfiguration: new(
                trainingSet: GetDataset(0, 7),
                evaluators: [new AgentOptimizationEvaluator(name: "builtin.meteor_score")],
                evaluationModel: new(modelDeploymentName)
            )
            {
                ValidationSet = GetDataset(7, 3),
            },
            candidateSearchConfiguration: new()
            {
                MaxCandidates = 3,
            },
            agentOptimizationSpace: new()
            {
                TargetAttributes = { TargetAttribute.Skills, TargetAttribute.Instructions, TargetAttribute.Model },
                ModelSearchSpace = { modelDeploymentName, anotherModelDeploymentName }
            }
        );
        AgentOptimizationJob job = new()
        {
            OptimizationConfiguration = conf,
            DisplayName = "Sample agent optimization",
            TargetConfiguration = new AgentOptimizationFoundryAgentTargetConfiguration(name: agentVersion.Name)
            {
                Version = agentVersion.Version,
            },
            OptimizationModelConfiguration = new(modelDeploymentName)
        };
        OperationResult jobOperation = await jobsClient.CreateAsync(waitUntilCompleted: true, job: job, operationId: null, cancellationToken: default);
        AgentOptimizationJob submittedJob = AgentOptimizationJob.FromClientResult(await jobOperation.UpdateStatusAsync());
        Console.WriteLine($"Submitted optimization job: {submittedJob.Id}");
        #endregion
        #region Snippet:Sample_GetOptimizationJob_AgentsOptimizationCandidates_Async
        int reportedWarnings = 0;
        if (submittedJob.Status == AgentsJobStatus.Failed)
        {
            throw new InvalidOperationException($"The job {submittedJob.Id} has failed.");
        }
        if (submittedJob.Warnings.Count > reportedWarnings)
        {
            Console.WriteLine($"    {submittedJob.Id}: {submittedJob.Status}");
            for (int i = reportedWarnings; i < submittedJob.Warnings.Count; i++)
            {
                Console.WriteLine($"    Warning in job {submittedJob.Id}: {submittedJob.Warnings[i]}");
            }
        }
        #endregion
        #region Snippet:Sample_ListCandidates_AgentsOptimizationCandidates
        await foreach (AgentOptimizationCandidate candidate in candidatesClient.GetCandidatesAsync(jobId: submittedJob.Id, expand: [AgentOptimizationCandidateExpand.Mutations]))
        {
            Console.WriteLine("======================================================");
            if (candidate.Status == AgentOptimizationCandidateStatus.Failed)
            {
                Console.WriteLine($"The candidate {candidate.CandidateId} has failed.");
            }
            else
            {
                Console.WriteLine($"Candidate ID: {candidate.CandidateId}, Candidate name: {candidate.Name ?? "<no name>"}, Candidate evaluation ID:  {candidate.Evaluation.EvalId}, Score: {candidate.Evaluation.Score}.");
                if (candidate.Output is AgentOptimizationAgentCandidateOutput agentOutput)
                {
                    DisplayMutations(agentOutput.Mutations);
                }
                else if (candidate.Output != null)
                {
                    throw new InvalidOperationException($"The candidate {candidate.CandidateId} has unexpected output: {candidate.Output.Type}");
                }
            }
            Console.WriteLine("======================================================");
        }
        #endregion
        #region Snippet:Sample_Delete_AgentsOptimizationCandidates_Async
        await jobsClient.DeleteAsync(jobId: submittedJob.Id, cancellationToken: default);
        Console.WriteLine($"Deleted job {submittedJob.Id}.");
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentsOptimizationCandidatesSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var anotherModelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME2");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var anotherModelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME2;
#endif
        AgentAdministrationClientOptions opts = new();
        opts.AddPolicy(GetDumpPolicy(), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: opts);
        AgentOptimizationJobs jobsClient = agentsClient.GetAgentOptimizationJobs();
        AgentOptimizationJobCandidates candidatesClient = agentsClient.GetAgentOptimizationJobCandidatesClient();

        #region Snippet:Sample_CreateAgent_AgentsOptimizationCandidates_Sync
        ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersion(
            agentName: "myAgent1",
            options: new(GetAgentDefinition(modelDeploymentName)));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateOptimizationJob_AgentsOptimizationCandidates_Sync
        AgentOptimizationConfiguration conf = new(
            evaluationConfiguration: new(
                trainingSet: GetDataset(0, 7),
                evaluators: [new AgentOptimizationEvaluator(name: "builtin.meteor_score")],
                evaluationModel: new(modelDeploymentName)
            )
            {
                ValidationSet = GetDataset(7, 3),
            },
            candidateSearchConfiguration: new()
            {
                MaxCandidates = 3,
            },
            agentOptimizationSpace: new()
            {
                TargetAttributes = { TargetAttribute.Instructions,  TargetAttribute.Tools, TargetAttribute.Model },
                ModelSearchSpace = { modelDeploymentName, anotherModelDeploymentName }
            }
        );
        AgentOptimizationJob job = new()
        {
            OptimizationConfiguration = conf,
            DisplayName = "Sample agent optimization",
            TargetConfiguration = new AgentOptimizationFoundryAgentTargetConfiguration(name: agentVersion.Name)
            {
                Version = agentVersion.Version,
            },
            OptimizationModelConfiguration = new(modelDeploymentName)
        };
        OperationResult jobOperation = jobsClient.Create(waitUntilCompleted: true, job: job, operationId: null, cancellationToken: default);
        AgentOptimizationJob submittedJob = AgentOptimizationJob.FromClientResult(jobOperation.UpdateStatus());
        Console.WriteLine($"Submitted optimization job: {submittedJob.Id}");
        #endregion
        #region Snippet:Sample_GetOptimizationJob_AgentsOptimizationCandidates_Sync
        int reportedWarnings = 0;
        if (submittedJob.Status == AgentsJobStatus.Failed)
        {
            throw new InvalidOperationException($"The job {submittedJob.Id} has failed.");
        }
        if (submittedJob.Warnings.Count > reportedWarnings)
        {
            Console.WriteLine($"    {submittedJob.Id}: {submittedJob.Status}");
            for (int i = reportedWarnings; i < submittedJob.Warnings.Count; i++)
            {
                Console.WriteLine($"    Warning in job {submittedJob.Id}: {submittedJob.Warnings[i]}");
            }
        }
        #endregion
        foreach (AgentOptimizationCandidate candidate in candidatesClient.GetCandidates(jobId: submittedJob.Id, expand: [AgentOptimizationCandidateExpand.Mutations]))
        {
            Console.WriteLine("======================================================");
            if (candidate.Status == AgentOptimizationCandidateStatus.Failed)
            {
                Console.WriteLine($"The candidate {candidate.CandidateId} has failed.");
            }
            else
            {
                Console.WriteLine($"Candidate ID: {candidate.CandidateId}, Candidate name: {candidate.Name ?? "<no name>"}, Candidate evaluation ID:  {candidate.Evaluation.EvalId}, Score: {candidate.Evaluation.Score}.");
                if (candidate.Output is AgentOptimizationAgentCandidateOutput agentOutput)
                {
                    DisplayMutations(agentOutput.Mutations);
                }
                else if (candidate.Output != null)
                {
                    throw new InvalidOperationException($"The candidate {candidate.CandidateId} has unexpected output: {candidate.Output.Type}");
                }
            }
            Console.WriteLine("======================================================");
        }
        #region Snippet:Sample_Delete_AgentsOptimizationCandidates_Sync
        jobsClient.Delete(jobId: submittedJob.Id, cancellationToken: default);
        Console.WriteLine($"Deleted job {submittedJob.Id}.");
        agentsClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
    }

    public Sample_AgentsOptimizationCandidates(bool isAsync) : base(isAsync)
    { }
}
