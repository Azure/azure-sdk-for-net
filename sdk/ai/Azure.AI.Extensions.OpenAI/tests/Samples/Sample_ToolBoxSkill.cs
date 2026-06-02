// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Authorization;
using Azure.ResourceManager.Authorization.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

# pragma warning disable AAIP001
public class Sample_ToolBoxSkill : ProjectsOpenAITestBase
{
    #region Snippet:Sample_RoleID_ToolBoxSkill
    private static readonly string AZURE_AI_USER_ROLE_DEFINITION_GUID = "53ca6127-db72-4b80-b1b0-d745d6d5456d";
    #endregion
    #region Snippet:Sample_GetPath_ToolBoxSkill
    protected static string GetDirectory(string path, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine([dirName, path]);
    }
    #endregion

    #region Snippet:Sample_CodeAgentMetadata_ToolBoxSkill
    private static CreateAgentVersionFromCodeMetadata GetAgentMetadata(ResponseTool toolboxMCP)
    {
        HostedAgentDefinition agentDefinition = new(
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            Versions = { new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0") },
            CodeConfiguration = new(
                runtime: "python_3_14",
                entryPoint: ["python", "main.py"],
                dependencyResolution: CodeDependencyResolution.RemoteBuild
            ),
            Tools = { toolboxMCP.AsAgentTool() }
        };
        CreateAgentVersionFromCodeMetadata metadata = new(agentDefinition);
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
        var subscriptionId = System.Environment.GetEnvironmentVariable("SUBSCRIPTION_ID");
        var resourceGroupId = System.Environment.GetEnvironmentVariable("RESOURCE_GROUP_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var subscriptionId = TestEnvironment.SUBSCRIPTION_ID;
        var resourceGroupId = TestEnvironment.RESOURCE_GROUP_NAME;
#endif
        DefaultAzureCredential credential = new();
        AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: credential);
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        ProjectAgentSkills skillsClient = projectClient.AgentAdministrationClient.GetAgentSkills();
        #endregion
        try
        {
            toolboxClient.DeleteToolbox(name: "myToolbox");
        }
        catch { }
        #region Snippet:Sample_CreateToolbox_ToolBoxSkill_Async
        AgentsSkill skillFromFile = await skillsClient.CreateSkillVersionFromFilesAsync("roll-dice", GetDirectory(Path.Combine(["Assets", "roll-dice"])));
        ToolboxSkillReference reference = new(skillFromFile.Name)
        {
            Version = skillFromFile.LatestVersion
        };
        ToolboxSearchPreviewTool searchTool = new()
        {
            Name = "ToolBoxSkill",
            Description = "The toolbox with the skill."
        };
        ProjectsAgentTool mcp = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        ToolboxVersion toolBox = await toolboxClient.CreateToolboxVersionAsync(
            name: "myToolbox",
            tools: [mcp],
            skills: [reference],
            description: "Example toolbox created by the azure-ai-projects sample."
        );
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
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionFromCodeAsync(
            agentName: "myCodeSkillAgent",
            filePath: GetDirectory(Path.Combine(["Assets", "AgentsCode"])),
            metadata: GetAgentMetadata(skillTool)
        );
        #endregion
        #region Snippet:Sample_FindResourceId_ToolBoxSkill_Async
        string accountName = (new Regex(@"(?<=https://)([^.]+)(?=\.services\.ai\.azure\.com)")).Match(projectEndpoint).Value;
        //string projectName = (new Regex(@"(?<=/projects/)([^/]+)(?=[/?]|$)")).Match(projectEndpoint).Value;
        ArmClient armClient = new(credential);
        SubscriptionResource subscription = armClient.GetSubscriptionResource(new($"/subscriptions/{subscriptionId}"));
        ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
        ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resourceGroupId);
        ResourceIdentifier accountId = default;
        await foreach (GenericResource res in resourceGroup.GetGenericResourcesAsync())
        {
            if (res.Data.Name == accountName)
            {
                accountId = res.Data.Id;
                break;
            }
        }
        if (accountId is null)
        {
            throw new InvalidOperationException($"The account {accountName} was not found in resource group {resourceGroupId}.");
        }
        #endregion
        #region Snippet:Sample_AssignRole_ToolBoxSkill_Async
        RoleAssignmentCollection roleAssignment = armClient.GetRoleAssignments(accountId);
        ResourceIdentifier aiUserRoleId = new($"/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/roleDefinitions/{AZURE_AI_USER_ROLE_DEFINITION_GUID}");
        // Calculate uuid5
        string uuid5Hash;
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] input = Encoding.UTF8.GetBytes("6ba7b811-9dad-11d1-80b4-00c04fd430c8" + $"{accountId}|{agentVersion.InstanceIdentity}|{AZURE_AI_USER_ROLE_DEFINITION_GUID}");
            byte[] uuid5 = sha1.ComputeHash( input );
            StringBuilder sbHash = new();
            foreach (byte b in uuid5)
            {
                sbHash.Append(b.ToString("x2"));
            }
            uuid5Hash = sbHash.ToString();
        }
        //roleAssignment.Any(x => x.Id && x.)
        RoleAssignmentCreateOrUpdateContent roleContent = new(aiUserRoleId, new Guid(uuid5Hash))
        {
            PrincipalType = RoleManagementPrincipalType.ServicePrincipal
        };

        #endregion
        #region Snippet:Sample_WaitForDeployment_ToolBoxSkill_Async
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            await Task.Delay(500);
            agentVersion = await projectClient.AgentAdministrationClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        #endregion
        #region Snippet:Sample_GetResponseFromAgent_ToolBoxSkill_Async
        try
        {
            ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
            ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");

            Console.WriteLine(response.GetOutputText());
        }
        catch (ClientResultException e)
        {
            MatchCollection session = Regex.Matches(e.Message, "'[^']+'");
            if (e.Status == 424 && e.Message.IndexOf("session_not_ready", StringComparison.OrdinalIgnoreCase) != -1 && session.Count > 0)
            {
                SessionLogEvent logEvent = await projectClient.AgentAdministrationClient.GetSessionLogStreamAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version, sessionId: session[0].Value.Trim('\''));
                Console.WriteLine(logEvent.Data);
            }
            await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
            throw;
        }
        #endregion
        #region Snippet:DeleteToolBoxSkill_ToolBoxSkill_Async
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
        #endregion
    }

    public Sample_ToolBoxSkill(bool isAsync) : base(isAsync)
    { }
}
