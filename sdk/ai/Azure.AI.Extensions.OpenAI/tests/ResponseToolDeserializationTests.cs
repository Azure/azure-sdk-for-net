// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;
#pragma warning disable AAIP001

[Category("Smoke")]
[Parallelizable(ParallelScope.All)]
public class ResponseToolDeserializationTests
{
    // Maps each Azure-specific ResponseTool discriminator ("type") to the concrete subtype that
    // deserialization should materialize. Tool definitions echoed back on a response flow through
    // OpenAI's closed DeserializeResponseTool switch, which buckets Azure kinds into an opaque
    // unknown-tool fallback. Base-class dispatch through ModelReaderWriter.Read<ResponseTool> with
    // the Azure context must instead resolve these strongly-typed subtypes; otherwise the typed
    // tool surface (e.g. BingGroundingTool) is silently lost.
    private static IEnumerable<TestCaseData> AzureResponseToolKinds()
    {
        yield return Case(ResponseToolKind.A2APreview, typeof(A2APreviewTool));
        yield return Case(ResponseToolKind.AzureAISearch, typeof(AzureAISearchTool));
        yield return Case(ResponseToolKind.AzureFunction, typeof(AzureFunctionTool));
        yield return Case(ResponseToolKind.BingCustomSearchPreview, typeof(BingCustomSearchPreviewTool));
        yield return Case(ResponseToolKind.BingGrounding, typeof(BingGroundingTool));
        yield return Case(ResponseToolKind.BrowserAutomation, typeof(BrowserAutomationTool));
#pragma warning disable CS0618 // Preserve deserialization coverage for the legacy browser automation tool.
        yield return Case(ResponseToolKind.BrowserAutomationPreview, typeof(BrowserAutomationPreviewTool));
#pragma warning restore CS0618
        yield return Case(ResponseToolKind.CaptureStructuredOutputs, typeof(CaptureStructuredOutputsTool));
        yield return Case(ResponseToolKind.FabricIQPreview, typeof(FabricIQPreviewTool));
        yield return Case(ResponseToolKind.MemorySearchPreview, typeof(MemorySearchPreviewTool));
        yield return Case(ResponseToolKind.FabricDataAgentPreview, typeof(MicrosoftFabricPreviewTool));
        yield return Case(ResponseToolKind.OpenAPI, typeof(OpenApiTool));
        yield return Case(ResponseToolKind.SharePointGroundingPreview, typeof(SharePointPreviewTool));
        yield return Case(ResponseToolKind.WorkIQPreview, typeof(WorkIQPreviewTool));
        yield return Case(ResponseToolKind.WebIQPreview, typeof(WebIQPreviewTool));
        yield return Case(ResponseToolKind.GitHubCopilotToolsetPreviewValue, typeof(GitHubCopilotToolsetPreview));
        yield return Case(ResponseToolKind.MicrosoftCopilotToolsetPreview, typeof(MicrosoftCopilotToolsetPreview));

        static TestCaseData Case(ResponseToolKind discriminator, Type expectedType)
            => new TestCaseData(discriminator, expectedType).SetName($"{{m}}({discriminator} => {expectedType.Name})");
    }

    [TestCaseSource(nameof(AzureResponseToolKinds))]
    public void ReadResponseToolMaterializesAzureSubtype(ResponseToolKind discriminator, Type expectedType)
    {
        string json = $$"""{ "type": "{{discriminator}}" }""";

        BinaryData data = BinaryData.FromString(json);
        ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(
            data,
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);

        Assert.That(tool, Is.InstanceOf(expectedType), $"'{discriminator}' should deserialize to {expectedType.Name} but was {tool?.GetType().Name}.");
        ResponseTool roundtripTool = ModelReaderWriter.Read<ResponseTool>(data, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        Assert.That(roundtripTool, Is.TypeOf(expectedType));
    }

    [Test]
    [TestCaseSource(nameof(AzureResponseToolKinds))]
    public void FactoryMetadataSurvivesJsonSerialization(ResponseToolKind discriminator, Type expectedType)
    {
        BinaryData data = CreateWithMetadata(discriminator);
        ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(
            data,
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);
        Assert.That(tool, Is.InstanceOf(expectedType), $"'{discriminator}' should deserialize to {expectedType.Name} but was {tool?.GetType().Name}.");
    }

    #region helpers
    protected static string GetCityNicknameForTest(string location) => location switch
    {
        "Seattle, WA" => "The Emerald City",
        _ => throw new NotImplementedException(),
    };

    private static AzureFunctionTool GetFunctionTool()
    {
        AzureFunctionDefinitionFunction functionDefinition = new(
            name: "foo",
            parameters: BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        query = new
                        {
                            Type = "string",
                            Description = "The question to ask.",
                        }
                    }
                },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
            )
        )
        {
            Description = "Get answers from the foo bot.",
        };
        return new AzureFunctionTool(
            new AzureFunctionDefinition(
                function: functionDefinition,
                inputBinding: new AzureFunctionBinding(
                    new AzureFunctionStorageQueue(queueServiceEndpoint: "sample-queue", queueName: "azure-function-foo-input")),
                outputBinding: new AzureFunctionBinding(
                    new AzureFunctionStorageQueue(queueServiceEndpoint: "sample-queue", queueName: "azure-function-tool-output"))
                )
            );
    }

    /// <summary>
    /// Get the serialized tool of a certain type.
    /// </summary>
    /// <param name="toolType">The tool type.</param>
    /// <returns>The tool serialized a s a binary data.</returns>
    protected static BinaryData CreateWithMetadata(ResponseToolKind toolType)
    {
        string sample_connectioin = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.CognitiveServices/accounts/sample-account/projects/sample-project/connections/sample-connection";
        ResponseTool tool = toolType.ToString() switch
        {
            "memory_search_preview" => new MemorySearchPreviewTool(memoryStoreName: "memory-store", scope: "sampl-scope"),
            "azure_ai_search" => new AzureAISearchTool(new AzureAISearchToolOptions(indexes: [
                new()
                {
                    ProjectConnectionId = "sample-connection",
                    IndexName = "sample_index",
                    TopK = 5,
                    Filter = "category eq 'sleeping bag'",
                    QueryType = AzureAISearchQueryKind.Simple
                }
            ])),
            "bing_grounding" => new BingGroundingTool(new BingGroundingSearchToolOptions(
                searchConfigurations: [new BingGroundingSearchOptions(projectConnectionId: sample_connectioin)]
            )),
            "bing_custom_search_preview" => new BingCustomSearchPreviewTool(new BingCustomSearchToolOptions(
                searchConfigurations: [new BingCustomSearchOptions(projectConnectionId: sample_connectioin, instanceName: "sample-instance")]
            )),
            "sharepoint_grounding_preview" => new SharePointPreviewTool(new()
            {
                ProjectConnections = { new ToolProjectConnection(projectConnectionId: sample_connectioin) }
            }),
            "browser_automation" => new BrowserAutomationTool(
            new BrowserAutomationToolOptions(
                new BrowserAutomationToolConnectionOptions("browser-automation")
            )),
#pragma warning disable CS0618 // Preserve deserialization coverage for the legacy browser automation tool.
            "browser_automation_preview" => new BrowserAutomationPreviewTool(
            new BrowserAutomationToolOptions(
                new BrowserAutomationToolConnectionOptions("browser-automation-preview")
            )),
#pragma warning restore CS0618
            "fabric_iq_preview" => new FabricIQPreviewTool(projectConnectionId: sample_connectioin)
            {
                RequireApproval = new McpToolCallApprovalPolicy(DefaultMcpToolCallApprovalPolicy.NeverRequireApproval),
            },
            "fabric_dataagent_preview" => new MicrosoftFabricPreviewTool(new()
            {
                ProjectConnections = { new ToolProjectConnection(projectConnectionId: sample_connectioin) }
            }),
            "a2a_preview" => new A2APreviewTool()
            {
                ProjectConnectionId = sample_connectioin
            },
            "azure_function" => GetFunctionTool(),
            "web_iq_preview" => new WebIQPreviewTool(projectConnectionId: sample_connectioin)
            {
                RequireApproval = new WebIQPreviewToolRequireApprovalChoice(DefaultMcpToolCallApprovalPolicy.NeverRequireApproval),
            },
            "work_iq_preview" => new WorkIQPreviewTool(sample_connectioin),
            "openapi" => new OpenApiTool(new(
                name: "get_weather",
                specification: BinaryData.FromString("{}"),
                authentication: new OpenApiAnonymousAuthenticationDetails()
            )
            {
                Description = "Open API function."
            }),
            "microsoft_copilot_toolset_preview" => new MicrosoftCopilotToolsetPreview(
                defaultConfig: new(enabled: false),
                configs: [new MicrosoftCopilotToolsetConfig(name: MicrosoftCopilotBuiltInTool.FilesystemWrite)]
                ),
            "github_copilot_toolset_preview" => new GitHubCopilotToolsetPreview(
                defaultConfig: new(enabled: true),
                configs: [new GitHubCopilotToolsetConfig(name: GitHubCopilotBuiltInTool.Web)]
                ),
            "capture_structured_outputs" => new CaptureStructuredOutputsTool(new StructuredOutputDefinition(
                name: "struct",
                description: "Struct description",
                schema: new Dictionary<string, BinaryData>
                {
                    { "spec", BinaryData.FromString("{\"foo\": \"bar\"}") }
                },
                isStrict: false
             )),
            _ => throw new InvalidOperationException($"Unknown tool type {toolType}")
        };

        return ModelReaderWriter.Write(tool, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
    }

    #endregion
}
#pragma warning restore AAIP001
