// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

# pragma warning disable AAIP001
public class Sample_ToolBoxSkill : ProjectsOpenAITestBase
{
    #region Snippet:Sample_GetPath_ToolBoxSkill
    protected static string GetDirectory(string path, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(dirName, path);
    }
    #endregion
    #region Snippet:Sample_CodeAgentMetadata_ToolBoxSkill
    private static AgentVersionFromCodeMetadata GetAgentMetadata(string middlewareAgentName, string toolboxName, string foundryProjectEndpoint, string modelDeploymentName)
    {
        HostedAgentDefinition agentDefinition = new(
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            Versions = { new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "2.0.0") },
            CodeConfiguration = new(
                runtime: "python_3_14",
                entryPoint: ["python", "main.py"],
                dependencyResolution: CodeDependencyResolution.RemoteBuild
            ),
            EnvironmentVariables = {
                { "AGENT_NAME", middlewareAgentName},
                { "TOOLBOX_NAME", toolboxName},
                { "FOUNDRY_PROJECT_ENDPOINT", foundryProjectEndpoint},
                { "FOUNDRY_MODEL_NAME", modelDeploymentName },
            }
        };
        AgentVersionFromCodeMetadata metadata = new(agentDefinition);
        metadata.Metadata["enableVnextExperience"] = "true";
        return metadata;
    }
    #endregion
    [Test]
    [AsyncOnly]
    public async Task ToolBoxSkillCreateAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_ToolBoxSkill
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        ProjectAgentSkills skillsClient = projectClient.AgentAdministrationClient.GetAgentSkills();
        #endregion
        try
        {
            toolboxClient.Delete(name: "mySkillToolbox");
        }
        catch { }
        try
        {
            projectClient.AgentAdministrationClient.DeleteAgent("myAgent");
        }
        catch { }
        try
        {
            skillsClient.DeleteSkill(name: "shipping-cost-skill");
        }
        catch { }
        #region Snippet:Sample_CreateToolbox_ToolBoxSkill_Async
        SkillVersion skill = await skillsClient.CreateSkillVersionAsync(
            name: "shipping-cost-skill",
            inlineContent: new SkillInlineContent(
                description: "Compute shipping cost for a package given weight and destination.",
                instructions: "You are a shipping cost calculator. When asked to compute " +
                  "shipping cost, use this formula: cost (USD) = 5 + 2 * weight_kg " +
                  "for domestic destinations, and cost (USD) = 15 + 4 * weight_kg " +
                  "for international destinations. Always state the formula you used."
            )
        );
        Console.WriteLine($"Created skill {skill.Name}, v. {skill.Version}.");
        ToolboxSkillReference reference = new(skill.Name)
        {
            Version = skill.Version
        };
        ToolboxVersion toolBox = await toolboxClient.CreateVersionAsync(
            name: "mySkillToolbox",
            tools: [new ToolboxSearchPreviewToolboxTool()],
            skills: [reference],
            description: "Toolbox exposing a shipping-cost skill."
        );
        Console.WriteLine($"Created toolbox {toolBox.Name}, v. {toolBox.Version}.");
        #endregion
        #region Snippet:Sample_CreateAgent_ToolBoxSkill_Async
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionFromCodeAsync(
            agentName: "myCodeAgentSkill",
            filePath: GetDirectory(Path.Combine(["Assets", "AgentsCodeToolbox"])),
            metadata: GetAgentMetadata(
                middlewareAgentName: "codeAgentMiddleware1",
                toolboxName: toolBox.Name,
                foundryProjectEndpoint: projectEndpoint,
                modelDeploymentName: modelDeploymentName
            )
        );
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            await Task.Delay(500);
            agentVersion = await projectClient.AgentAdministrationClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        Console.WriteLine($"Created Agent {agentVersion.Name}, v. {agentVersion.Version}.");
        Console.WriteLine($"The Agent's identity ID is {agentVersion.InstanceIdentity.ClientId}. Please use it to set \"Foundry User\" permission if needed.");
        #endregion
        #region Snippet:Sample_GetResponseFromAgent_ToolBoxSkill_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
        CreateResponseOptions nextResponseOptions = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem("Compute the shipping cost for a 3 kg package shipped domestically.") }
        };
        ResponseResult latestResponse = null;
        while (nextResponseOptions is not null)
        {
            latestResponse = await responseClient.CreateResponseAsync(nextResponseOptions);
            nextResponseOptions = null;

            foreach (ResponseItem responseItem in latestResponse.OutputItems)
            {
                if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
                {
                    nextResponseOptions = new CreateResponseOptions()
                    {
                        PreviousResponseId = latestResponse.Id,
                    };
                    if (string.Equals(mcpToolCall.ServerLabel, "agent_framework"))
                    {
                        Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                        // Automatically approve the MCP request to allow the agent to proceed
                        // In production, you might want to implement more sophisticated approval logic
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
                    }
                    else
                    {
                        Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
                    }
                }
                else if (responseItem is FunctionCallResponseItem functionCallResponse)
                {
                    Console.WriteLine($"Calling function {functionCallResponse.FunctionName} with arguments {functionCallResponse.FunctionArguments}");
                }
            }
        }
        Console.WriteLine(latestResponse.GetOutputText());
        #endregion
        #region Snippet:DeleteToolBoxSkill_ToolBoxSkill_Async
        // await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
        await toolboxClient.DeleteAsync(name: toolBox.Name);
        await skillsClient.DeleteSkillAsync(name: skill.Name);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ToolBoxSkillCreateSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        ProjectAgentSkills skillsClient = projectClient.AgentAdministrationClient.GetAgentSkills();
        try
        {
            toolboxClient.Delete(name: "mySkillToolbox");
        }
        catch { }
        try
        {
            projectClient.AgentAdministrationClient.DeleteAgent("myAgent");
        }
        catch { }
        try
        {
            skillsClient.DeleteSkill(name: "shipping-cost-skill");
        }
        catch { }
        #region Snippet:Sample_CreateToolbox_ToolBoxSkill_Sync
        SkillVersion skill = skillsClient.CreateSkillVersion(
            name: "shipping-cost-skill",
            inlineContent: new SkillInlineContent(
                description: "Compute shipping cost for a package given weight and destination.",
                instructions: "You are a shipping cost calculator. When asked to compute " +
                  "shipping cost, use this formula: cost (USD) = 5 + 2 * weight_kg " +
                  "for domestic destinations, and cost (USD) = 15 + 4 * weight_kg " +
                  "for international destinations. Always state the formula you used."
            )
        );
        Console.WriteLine($"Created skill {skill.Name}, v. {skill.Version}.");
        ToolboxSkillReference reference = new(skill.Name)
        {
            Version = skill.Version
        };
        ToolboxVersion toolBox = toolboxClient.CreateVersion(
            name: "mySkillToolbox",
            tools: [new ToolboxSearchPreviewToolboxTool()],
            skills: [reference],
            description: "Toolbox exposing a shipping-cost skill."
        );
        Console.WriteLine($"Created toolbox {toolBox.Name}, v. {toolBox.Version}.");
        #endregion
        #region Snippet:Sample_CreateAgent_ToolBoxSkill_Sync
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersionFromCode(
            agentName: "myCodeAgentSkill",
            filePath: GetDirectory(Path.Combine(["Assets", "AgentsCodeToolbox"])),
            metadata: GetAgentMetadata(
                middlewareAgentName: "codeAgentMiddleware1",
                toolboxName: toolBox.Name,
                foundryProjectEndpoint: projectEndpoint,
                modelDeploymentName: modelDeploymentName
            )
        );
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            Thread.Sleep(500);
            agentVersion = projectClient.AgentAdministrationClient.GetAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        Console.WriteLine($"Created Agent {agentVersion.Name}, v. {agentVersion.Version}.");
        Console.WriteLine($"The Agent's identity ID is {agentVersion.InstanceIdentity.ClientId}. Please use it to set \"Foundry User\" permission if needed.");
        #endregion
        #region Snippet:Sample_GetResponseFromAgent_ToolBoxSkill_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
        CreateResponseOptions nextResponseOptions = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem("Compute the shipping cost for a 3 kg package shipped domestically.") }
        };
        ResponseResult latestResponse = null;
        while (nextResponseOptions is not null)
        {
            latestResponse = responseClient.CreateResponse(nextResponseOptions);
            nextResponseOptions = null;

            foreach (ResponseItem responseItem in latestResponse.OutputItems)
            {
                if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
                {
                    nextResponseOptions = new CreateResponseOptions()
                    {
                        PreviousResponseId = latestResponse.Id,
                    };
                    if (string.Equals(mcpToolCall.ServerLabel, "agent_framework"))
                    {
                        Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                        // Automatically approve the MCP request to allow the agent to proceed
                        // In production, you might want to implement more sophisticated approval logic
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
                    }
                    else
                    {
                        Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
                    }
                }
                else if (responseItem is FunctionCallResponseItem functionCallResponse)
                {
                    Console.WriteLine($"Calling function {functionCallResponse.FunctionName} with arguments {functionCallResponse.FunctionArguments}");
                }
            }
        }
        Console.WriteLine(latestResponse.GetOutputText());
        #endregion
        #region Snippet:DeleteToolBoxSkill_ToolBoxSkill_Sync
        // projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
        toolboxClient.Delete(name: toolBox.Name);
        skillsClient.DeleteSkill(name: skill.Name);
        #endregion
    }

    public Sample_ToolBoxSkill(bool isAsync) : base(isAsync)
    { }
}
