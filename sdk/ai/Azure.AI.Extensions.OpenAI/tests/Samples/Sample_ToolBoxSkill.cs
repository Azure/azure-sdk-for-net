// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        DefaultAzureCredential credential = new();
        AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: credential);
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        ProjectAgentSkills skillsClient = projectClient.AgentAdministrationClient.GetAgentSkills();
        #endregion
        try
        {
            toolboxClient.DeleteToolbox(name: "mySkillToolbox");
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
        ToolboxVersion toolBox = await toolboxClient.CreateToolboxVersionAsync(
            name: "mySkillToolbox",
            tools: [new ToolboxSearchPreviewToolboxTool()],
            skills: [reference],
            description: "Toolbox exposing a shipping-cost skill."
        );
        Console.WriteLine($"Created toolbox {toolBox.Name}, v. {toolBox.Version}.");
        ResponseTool skillTool = ResponseTool.CreateMcpTool(
            serverLabel: "skill-toolbox",
            serverUri: new Uri($"{projectEndpoint}/toolboxes/{toolBox.Name}/versions/{toolBox.Version}/mcp?api-version=v1"),
            authorizationToken: credential.GetToken(new(scopes: ["https://ai.azure.com/.default"])).Token,
            headers: new Dictionary<string, string>() {
                { "Foundry-Features", "Toolboxes=V1Preview" }
            }
        );
        #endregion
        #region Snippet:Sample_CreateAgent_ToolBoxSkill_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "Answer the user using the `shipping-cost-skill` instructions " +
                "available in your context. Do not call `tool_search`; the " +
                "skill rules are already part of your knowledge. Apply the " +
                "skill's formula exactly as given and state the formula in " +
                "your answer.",
            Tools = { skillTool }
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Created Agent {agentVersion.Name}, v. {agentVersion.Version}.");
        #endregion
        #region Snippet:Sample_GetResponseFromAgent_ToolBoxSkill_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

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
                    if (string.Equals(mcpToolCall.ServerLabel, "skill-toolbox"))
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
                else if (responseItem is McpToolDefinitionListItem listItem)
                {
                    Console.WriteLine("Found tools:");
                    foreach (McpToolDefinition tool in listItem.ToolDefinitions)
                    {
                        Console.WriteLine($"    {tool.Name}");
                    }
                }
            }
        }
        Console.WriteLine(latestResponse.GetOutputText());
        #endregion
        #region Snippet:DeleteToolBoxSkill_ToolBoxSkill_Async
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
        await toolboxClient.DeleteToolboxAsync(name: toolBox.Name);
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
        DefaultAzureCredential credential = new();
        AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: credential);
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        ProjectAgentSkills skillsClient = projectClient.AgentAdministrationClient.GetAgentSkills();
        try
        {
            toolboxClient.DeleteToolbox(name: "mySkillToolbox");
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
        ToolboxVersion toolBox = toolboxClient.CreateToolboxVersion(
            name: "mySkillToolbox",
            tools: [new ToolboxSearchPreviewToolboxTool()],
            skills: [reference],
            description: "Toolbox exposing a shipping-cost skill."
        );
        Console.WriteLine($"Created toolbox {toolBox.Name}, v. {toolBox.Version}.");
        ResponseTool skillTool = ResponseTool.CreateMcpTool(
            serverLabel: "skill-toolbox",
            serverUri: new Uri($"{projectEndpoint}/toolboxes/{toolBox.Name}/versions/{toolBox.Version}/mcp?api-version=v1"),
            authorizationToken: credential.GetToken(new(scopes: ["https://ai.azure.com/.default"])).Token,
            headers: new Dictionary<string, string>() {
                { "Foundry-Features", "Toolboxes=V1Preview" }
            }
        );
        #endregion
        #region Snippet:Sample_CreateAgent_ToolBoxSkill_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "Answer the user using the `shipping-cost-skill` instructions " +
                "available in your context. Do not call `tool_search`; the " +
                "skill rules are already part of your knowledge. Apply the " +
                "skill's formula exactly as given and state the formula in " +
                "your answer.",
            Tools = { skillTool }
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Created Agent {agentVersion.Name}, v. {agentVersion.Version}.");
        #endregion
        #region Snippet:Sample_GetResponseFromAgent_ToolBoxSkill_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

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
                    if (string.Equals(mcpToolCall.ServerLabel, "skill-toolbox"))
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
                else if (responseItem is McpToolDefinitionListItem listItem)
                {
                    Console.WriteLine("Found tools:");
                    foreach (McpToolDefinition tool in listItem.ToolDefinitions)
                    {
                        Console.WriteLine($"    {tool.Name}");
                    }
                }
            }
        }
        Console.WriteLine(latestResponse.GetOutputText());
        #endregion
        #region Snippet:DeleteToolBoxSkill_ToolBoxSkill_Sync
        projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
        toolboxClient.DeleteToolbox(name: toolBox.Name);
        skillsClient.DeleteSkill(name: skill.Name);
        #endregion
    }

    public Sample_ToolBoxSkill(bool isAsync) : base(isAsync)
    { }
}
