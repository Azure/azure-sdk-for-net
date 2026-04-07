// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;
using OpenAI.VectorStores;

#pragma warning disable OPENAICUA001
#pragma warning disable AAIP001
namespace Azure.AI.Projects.Agents.Tests;

public class AgentsTestBase : RecordedTestBase<AgentsTestEnvironment>
{
    protected const string AGENT_NAME = "cs-e2e-tests-client";
    protected const string AGENT_NAME2 = "cs-e2e-tests-client2";
    protected const string VECTOR_STORE = "cs-e2e-tests-vector-store";
    protected const string TOOLBOX = "test-toolbox";
    protected readonly string MEMORY_STORE_SCOPE = "user_123";

    public AgentsTestBase(bool isAsync, RecordedTestMode? testMode = null) : base(isAsync, testMode)
    {
        // Please note that in System.ClientModel, the recording mode is taken from CLIENTMODEL_TEST_MODE
        // environment variable as opposed to AZURE_TEST_MODE in Azure.Core.
        // Allowed values are: Playback, Live, Record.
        ProjectsTestSanitizers.ApplySanitizers(this);
    }

    private AuthenticationTokenProvider GetTestTokenProvider()
    {
        // For local testing if you are using non default account
        // add USE_CLI_CREDENTIAL into the .runsettings and set it to true,
        // also provide the PATH variable.
        // This path should allow launching az command.
        if (Mode != RecordedTestMode.Playback && bool.TryParse(Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL"), out bool cliValue) && cliValue)
        {
            return new AzureCliCredential();
        }
        return TestEnvironment.Credential;
    }
    internal static PipelinePolicy GetDumpPolicy()
    {
        return new TestPipelinePolicy((message) =>
        {
            if (message.Request is not null && message.Response is null)
            {
                Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
                Console.WriteLine($"--- New request ---");
                IEnumerable<string> headerPairs = message?.Request?.Headers?.Select(header => $"\n   {header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
                string headers = string.Join("", headerPairs);
                Console.WriteLine($"Request headers:{headers}");
                if (message.Request?.Content != null)
                {
                    string contentType = "Unknown Content Type";
                    if (message.Request.Headers?.TryGetValue("Content-Type", out contentType) == true
                        && contentType == "application/json")
                    {
                        using MemoryStream stream = new();
                        message.Request.Content.WriteTo(stream, default);
                        stream.Position = 0;
                        using StreamReader reader = new(stream);
                        string requestDump = reader.ReadToEnd();
                        stream.Position = 0;
                        requestDump = Regex.Replace(requestDump, @"""data"":[\\w\\r\\n]*""[^""]*""", @"""data"":""...""");
                        // Make sure JSON string is properly formatted.
                        JsonSerializerOptions jsonOptions = new()
                        {
                            WriteIndented = true,
                        };
                        JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(requestDump);
                        Console.WriteLine("--- Begin request content ---");
                        Console.WriteLine(JsonSerializer.Serialize(jsonElement, jsonOptions));
                        Console.WriteLine("--- End request content ---");
                    }
                    else
                    {
                        string length = message.Request.Content.TryComputeLength(out long numberLength)
                            ? $"{numberLength} bytes"
                            : "unknown length";
                        Console.WriteLine($"<< Non-JSON content: {contentType} >> {length}");
                    }
                }
            }
            if (message.Response != null)
            {
                IEnumerable<string> headerPairs = message?.Response?.Headers?.Select(header => $"\n   {header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
                string headers = string.Join("", headerPairs);
                Console.WriteLine($"Response headers: {headers}");
                if (message.BufferResponse)
                {
                    message.Response.BufferContent();
                    Console.WriteLine("--- Begin response content ---");
                    Console.WriteLine(message.Response.Content?.ToString());
                    Console.WriteLine("--- End of response content ---");
                }
                else
                {
                    Console.WriteLine("--- Response (unbuffered, content not rendered) ---");
                }
            }
        });
    }
    protected static string GetTestFile(string fileName, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine([dirName, "TestData", fileName]);
    }

    protected AgentAdministrationClient GetTestClient()
    {
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(GetDumpPolicy(), PipelinePosition.BeforeTransport);
        options.AddPolicy(
            new TestPipelinePolicy(message =>
            {
                if (Mode == RecordedTestMode.Playback)
                {
                    // TODO: ...why!?
                    message.Request.Headers.Set("Authorization", "Sanitized");
                }
                else
                {
                    message.NetworkTimeout = TimeSpan.FromMinutes(5);
                }
                message.Request.Headers.Set("Foundry-Features", "MemoryStores=V1Preview,ContainerAgents=V1Preview,HostedAgents=V1Preview,WorkflowAgents=V1Preview,Evaluations=V1Preview,Schedules=V1Preview,RedTeams=V1Preview,Toolboxes=V1Preview");
            }),
            PipelinePosition.PerCall);
        return CreateProxyFromClient(new AgentAdministrationClient(new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT), GetTestTokenProvider(), InstrumentClientOptions(options)));
    }

    protected async Task<ResponseResult> WaitForRun(ResponsesClient responses, ResponseResult response, int waitTime = 500)
    {
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            if (Mode != RecordedTestMode.Playback)
                await Task.Delay(TimeSpan.FromMilliseconds(waitTime));
            response = await responses.GetResponseAsync(responseId: response.Id);
        }
        return response;
    }

    public static void AssertListEqual(string[] expected, List<string> observed)
    {
        // Assert.AreEqual(expected.Length, observed.Count, $"The length of arrays are different. Expected: {expected}, Observed: {observed.ToArray()}");
        HashSet<string> expectedHash = [.. expected];
        HashSet<string> observedHash = [.. observed];
        if (!expectedHash.SetEquals(observedHash))
        {
            Assert.Fail($"The members of arrays differ. Expected: {ToPritableString(expected)}, Observed: {ToPritableString(observed)}");
        }
    }

    private static string ToPritableString(IEnumerable<string> data)
    {
        StringBuilder sb = new();
        foreach (string val in data)
        {
            sb.Append(val);
            sb.Append(',');
            sb.Append(' ');
        }
        if (sb.Length > 2)
        {
            sb.Remove(sb.Length - 2, 2);
        }
        return sb.ToString();
    }

    protected static string GetModelType<T>(IJsonModel<T> model)
    {
        using MemoryStream memoryStream = new();
        using var writer = new Utf8JsonWriter(memoryStream, new JsonWriterOptions());
        model.Write(writer, ModelReaderWriterOptions.Json);
        writer.Flush();
        memoryStream.Position = 0;
        using JsonDocument document = JsonDocument.Parse(memoryStream);
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            if (prop.NameEquals("type"u8))
            {
                return prop.Value.ToString();
            }
        }
        return default;
    }
    #region Tools
    public enum ToolType
    {
        None,
        CodeInterpreter,
        CodeInterpreterGen,
        FileSearch,
        FunctionCall,
        ComputerUse,
        ImageGeneration,
        WebSearch,
        WebSearchPreview,
        AzureAISearch,
        Memory,
        AzureFunction,
        BingGrounding,
        BingGroundingCustom,
        MCP,
        OpenAPI,
        A2A,
        BrowserAutomation,
        MicrosoftFabric,
        Sharepoint,
        ConnectedAgent,
        DeepResearch,
        AzureFunctionTool,
    }

    private WebSearchTool GetCustomWebSearch()
    {
        WebSearchTool webSearchTool = ResponseTool.CreateWebSearchTool();
        webSearchTool.CustomSearchConfiguration = new(
            TestEnvironment.CUSTOM_BING_CONNECTION_ID,
            TestEnvironment.BING_CUSTOM_SEARCH_INSTANCE_NAME);
        return webSearchTool;
    }

    private async Task<VectorStore> GetVectorStore(OpenAIClient openAIClient)
    {
        VectorStoreClient vctStoreClient = openAIClient.GetVectorStoreClient();
        VectorStoreCreationOptions vctOptions = new()
        {
            Name = VECTOR_STORE,
            FileIds = { TestEnvironment.OPENAI_FILE_ID }
        };
        return await vctStoreClient.CreateVectorStoreAsync(
            vctOptions
        );
    }

    private AzureAISearchToolIndex GetAISearchIndex()
    {
        AzureAISearchToolIndex index = new()
        {
            ProjectConnectionId = TestEnvironment.AI_SEARCH_CONNECTION_NAME,
            IndexName = "sample_index",
            TopK = 5,
            Filter = "category eq 'sleeping bag'",
            QueryType = AzureAISearchQueryType.Simple
        };
        return index;
    }

    private AzureFunctionTool GetFunctionTool()
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
                    new AzureFunctionStorageQueue(queueServiceEndpoint: TestEnvironment.STORAGE_QUEUE_URI, queueName: "azure-function-foo-input")),
                outputBinding: new AzureFunctionBinding(
                    new AzureFunctionStorageQueue(queueServiceEndpoint: TestEnvironment.STORAGE_QUEUE_URI, queueName: "azure-function-tool-output"))
                )
            );
    }

    /// <summary>
    /// Get the AgentDefinition, containing tool of a certain type.
    /// </summary>
    /// <param name="toolType"></param>
    /// <returns></returns>
    protected ResponseTool GetAgentToolDefinition(ToolType toolType)
    {
        ResponseTool tool = toolType switch
        {
            // To run the Code interpreter and file search sample, please upload the file using code below.
            // This code cannot be run during tests as recordings are not properly handled by the file upload.
            // Upload the file.
            // string filePath = "sample_file_for_upload.txt";
            // System.IO.File.WriteAllText(
            //     path: filePath,
            //     contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
            // OpenAIFileClient fileClient = projectClient.OpenAI.GetOpenAIFileClient();
            // OpenAIFile uploadedFile = fileClient.UploadFile(filePath: filePath, purpose: FileUploadPurpose.Assistants);
            // Console.WriteLine(uploadedFile.id)
            ToolType.CodeInterpreter => ResponseTool.CreateCodeInterpreterTool(
                    new CodeInterpreterToolContainer(
                        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration(
                            fileIds: [TestEnvironment.OPENAI_FILE_ID]
                        )
                    )
                ),
            ToolType.CodeInterpreterGen => ResponseTool.CreateCodeInterpreterTool(
                    new CodeInterpreterToolContainer(
                        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration(
                            fileIds: []
                        )
                    )
                ),
            ToolType.FileSearch => ResponseTool.CreateFileSearchTool(vectorStoreIds: [TestEnvironment.OPENAI_VECTOR_STORE_ID]),
            ToolType.FunctionCall => ResponseTool.CreateFunctionTool(
                functionName: "GetCityNicknameForTest",
                functionDescription: "Gets the nickname of a city, e.g. 'LA' for 'Los Angeles, CA'.",
                functionParameters: BinaryData.FromObjectAsJson(
                    new
                    {
                        Type = "object",
                        Properties = new
                        {
                            Location = new
                            {
                                Type = "string",
                                Description = "The city and state, e.g. San Francisco, CA",
                            },
                        },
                        Required = new[] { "location" },
                    },
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
                ),
                strictModeEnabled: false
            ),
            ToolType.ComputerUse => ResponseTool.CreateComputerTool(environment: new ComputerToolEnvironment("windows"), displayWidth: 1026, displayHeight: 769),
            ToolType.ImageGeneration => ResponseTool.CreateImageGenerationTool(
                model: TestEnvironment.IMAGE_GENERATION_DEPLOYMENT_NAME,
                quality: ImageGenerationToolQuality.Low,
                size: ImageGenerationToolSize.W1024xH1024
            ),
            ToolType.WebSearch => ResponseTool.CreateWebSearchTool(WebSearchToolLocation.CreateApproximateLocation(country: "US", region: "Pennsylvania", city: "Centralia")),
            ToolType.WebSearchPreview => ResponseTool.CreateWebSearchPreviewTool(WebSearchToolLocation.CreateApproximateLocation(country: "US", region: "Pennsylvania", city: "Centralia")),
            ToolType.Memory => new MemorySearchPreviewTool(memoryStoreName: "test-memory-store", scope: MEMORY_STORE_SCOPE),
            ToolType.AzureAISearch => new AzureAISearchTool(new AzureAISearchToolOptions(indexes: [GetAISearchIndex()])),
            ToolType.BingGrounding => new BingGroundingTool(new BingGroundingSearchToolOptions(
                searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: TestEnvironment.BING_CONNECTION_ID)]
            )),
            ToolType.BingGroundingCustom => new BingCustomSearchPreviewTool(new BingCustomSearchToolOptions(
                searchConfigurations: [new BingCustomSearchConfiguration(projectConnectionId: TestEnvironment.CUSTOM_BING_CONNECTION_ID, instanceName: TestEnvironment.BING_CUSTOM_SEARCH_INSTANCE_NAME)]
            )),
            ToolType.MCP => ResponseTool.CreateMcpTool(
                serverLabel: "api-specs",
                serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
                toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
            )),
            ToolType.OpenAPI => new OpenAPITool(new OpenApiFunctionDefinition(
                name: "get_weather",
                specificationBytes: BinaryData.FromBytes(File.ReadAllBytes(GetTestFile("weather_openapi.json"))),
                authentication: new OpenAPIAnonymousAuthenticationDetails()
            )),
            ToolType.Sharepoint => new SharepointPreviewTool(new SharePointGroundingToolOptions()
            {
                ProjectConnections = { new ToolProjectConnection(projectConnectionId: TestEnvironment.SHAREPOINT_CONNECTION_ID) }
            }),
            ToolType.BrowserAutomation => new BrowserAutomationPreviewTool(
            new BrowserAutomationToolOptions(
                new BrowserAutomationToolConnectionParameters(TestEnvironment.PLAYWRIGHT_CONNECTION_ID)
            )),
            ToolType.MicrosoftFabric => new MicrosoftFabricPreviewTool(
                new FabricDataAgentToolOptions()
                {
                    ProjectConnections = { new ToolProjectConnection(projectConnectionId: TestEnvironment.FABRIC_CONNECTION_ID) }
                }
            ),
            ToolType.A2A => new A2APreviewTool()
            {
                ProjectConnectionId= TestEnvironment.A2A_CONNECTION_ID
            },
            ToolType.AzureFunction => GetFunctionTool(),
            _ => throw new InvalidOperationException($"Unknown tool type {toolType}")
        };
        return tool;
    }
    #endregion
    #region Cleanup
    [TearDown]
    public async virtual Task Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        AgentAdministrationClientOptions options = new();
        AgentAdministrationClient agentsClient = new(new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT), TestEnvironment.Credential, options);

        // Remove Agents.
        foreach (ProjectsAgentVersion ag in agentsClient.GetAgentVersions(agentName: AGENT_NAME))
        {
            agentsClient.DeleteAgentVersion(agentName: ag.Name, agentVersion: ag.Version);
        }
        foreach (ProjectsAgentVersion ag in agentsClient.GetAgentVersions(agentName: AGENT_NAME2))
        {
            agentsClient.DeleteAgentVersion(agentName: ag.Name, agentVersion: ag.Version);
        }
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();

        foreach (string name in new string[] { TOOLBOX, "mcp", "mcp1", "mcp2" })
        {
            try
            {
                await toolboxClient.DeleteToolboxAsync(name);
            }
            catch
            {
                // Nothing here.
            }
        }
    }
    #endregion
}
