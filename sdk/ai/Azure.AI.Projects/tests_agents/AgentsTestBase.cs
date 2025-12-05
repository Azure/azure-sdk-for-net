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

using Azure.AI.Projects;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;
using OpenAI.VectorStores;
using Azure.AI.Projects.Tests.Utils;

namespace Azure.AI.Projects.Tests;
#pragma warning disable OPENAICUA001

public class AgentsTestBase : RecordedTestBase<AIAgentsTestEnvironment>
{
    #region Enumerations
    public enum ToolType
    {
        None,
        CodeInterpreter,
        FileSearch,
        FunctionCall,
        ComputerUse,
        ImageGeneration,
        WebSearch,
        AzureAISearch,
        Memory,
        AzureFunction,
        BingGrounding,
        BingGroundingCustom,
        MCP,
        MCPConnection,
        OpenAPI,
        OpenAPIConnection,
        A2A,
        BrowserAutomation,
        MicrosoftFabric,
        Sharepoint,
        ConnectedAgent,
        DeepResearch,
    }

    public Dictionary<ToolType, string> ToolPrompts = new()
    {
        {ToolType.None, "Hello, tell me a joke."},
        {ToolType.FunctionCall, "What is the nickname for Seattle, WA?" },
        {ToolType.ComputerUse, "I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete." },
        {ToolType.ImageGeneration, "Generate an image of Microsoft logo."},
        {ToolType.WebSearch, "Use web search to describe what is special about this place?"},
        {ToolType.Memory, "What is user's favorite animal?"},
        {ToolType.BingGrounding, "How does wikipedia explain Euler's Identity?" },
        {ToolType.BingGroundingCustom, "How many medals did the USA win in the 2024 summer olympics?"},
        {ToolType.OpenAPI, "Use the OpenAPI tool to print out, what is the weather in Seattle, WA today."},
        {ToolType.OpenAPIConnection, "Recommend me 5 top hotels in paris, France."},
        {ToolType.DeepResearch, "Research the current state of studies on orca intelligence and orca language, " +
            "including what is currently known about orcas' cognitive capabilities, " +
            "communication systems and problem-solving reflected in recent publications in top their scientific " +
            "journals like Science, Nature and PNAS."},
        {ToolType.AzureAISearch, "What is the temperature rating of the cozynights sleeping bag?"},
        {ToolType.ConnectedAgent, "What is the Microsoft stock price?"},
        {ToolType.FileSearch,  "Can you give me the documented codes for 'banana' and 'orange'?"},
        {ToolType.AzureFunction, "What is the most prevalent element in the universe? What would foo say?"},
        {ToolType.BrowserAutomation, "Your goal is to report the percent of Microsoft year-to-date stock price change.\n" +
                "To do that, go to the website finance.yahoo.com.\n" +
                "At the top of the page, you will find a search bar.\n" +
                "Enter the value 'MSFT', to get information about the Microsoft stock price.\n" +
                "At the top of the resulting page you will see a default chart of Microsoft stock price.\n" +
                "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it."},
        {ToolType.MicrosoftFabric, "What are top 3 weather events with largest revenue loss?"},
        {ToolType.Sharepoint, "Hello, summarize the key points of the first document in the list."},
        {ToolType.CodeInterpreter,  "Can you give me the documented codes for 'banana' and 'orange'?"},
        {ToolType.MCP, "Please summarize the Azure REST API specifications Readme"},
        {ToolType.MCPConnection, "How many follower on github do I have?"},
    };

    public Dictionary<ToolType, string> ToolInstructions = new()
    {
        {ToolType.None, "You are a prompt agent."},
        {ToolType.BingGrounding, "You are helpful agent."},
        {ToolType.BingGroundingCustom, "You are helpful agent."},
        {ToolType.ImageGeneration, "Generate images based on user prompts"},
        {ToolType.WebSearch, "You are a helpful assistant that can search the web"},
        {ToolType.Memory, "You are a prompt agent capable to access memorized conversation."},
        {ToolType.FunctionCall, "You are helpful agent. Use the provided functions to help answer questions."},
        {ToolType.ComputerUse, "You are a computer automation assistant.\n\n" +
                               "Be direct and efficient. When you reach the search results page, read and describe the actual search result titles and descriptions you can see." },
        {ToolType.OpenAPI, "You are a helpful assistant."},
        {ToolType.OpenAPIConnection, "You are a helpful assistant."},
        {ToolType.DeepResearch, "You are a helpful agent that assists in researching scientific topics."},
        {ToolType.AzureAISearch, "You are a helpful assistant. You must always provide citations for answers using the tool and render them as: `\u3010message_idx:search_idx\u2020source\u3011`."},
        {ToolType.ConnectedAgent, "You are a helpful assistant, and use the connected agents to get stock prices."},
        {ToolType.FileSearch,  "You are helpful agent."},
        {ToolType.BrowserAutomation, "You are an Agent helping with browser automation tasks.\n" +
            "You can answer questions, provide information, and assist with various tasks\n" +
            "related to web browsing using the Browser Automation tool available to you." },
        {ToolType.MicrosoftFabric, "You are helpful agent."},
        {ToolType.Sharepoint, "You are helpful agent."},
        {ToolType.CodeInterpreter, "You are helpful agent."},
        {ToolType.MCP, "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks."},
        {ToolType.MCPConnection, "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks."},
    };

    public Dictionary<ToolType, string> ExpectedOutput = new()
    {
        {ToolType.CodeInterpreter, "673457"},
        {ToolType.FileSearch, "673457"},
        {ToolType.FunctionCall, "emerald"},
        {ToolType.WebSearch, "centralia" },
        {ToolType.Memory, "plagiarus"},
        {ToolType.AzureAISearch, "60"},
        {ToolType.BingGroundingCustom, "40.+gold.+44 silver.+42.+bronze"},
    };

    public Dictionary<ToolType, string> ExpectedAnnotationTitle = new()
    {
        {ToolType.AzureAISearch, "product_info_7.md"},
        {ToolType.BingGrounding, "Wikipedia"},
        {ToolType.BingGroundingCustom, "Wikipedia"},
    };

    public Dictionary<ToolType, Type> ExpectedUpdateTypes = new()
    {
        {ToolType.FileSearch, typeof(StreamingResponseFileSearchCallCompletedUpdate) },
        {ToolType.MCP, typeof(StreamingResponseMcpCallCompletedUpdate)},
        {ToolType.MCPConnection, typeof(StreamingResponseMcpCallCompletedUpdate)},
        {ToolType.FunctionCall, typeof(StreamingResponseFunctionCallArgumentsDoneUpdate)},
    };

    public Dictionary<ToolType, Type> ExpectedAnnotations = new()
    {
        {ToolType.FileSearch, typeof(FileCitationMessageAnnotation) },
        {ToolType.AzureAISearch, typeof(UriCitationMessageAnnotation) },
        {ToolType.BingGrounding, typeof(UriCitationMessageAnnotation) },
        {ToolType.BingGroundingCustom, typeof(UriCitationMessageAnnotation) },
    };

    public Dictionary<ToolType, string> ExpectedItems = new()
    {
        {ToolType.FileSearch, "file_search_call" },
        {ToolType.WebSearch, "web_search_call" },
        {ToolType.ImageGeneration, "image_generation_call"},
        {ToolType.CodeInterpreter, "code_interpreter_call"},
        {ToolType.OpenAPI, "openapi_call"},
        {ToolType.OpenAPIConnection, "openapi_call"},
        {ToolType.BrowserAutomation, "browser_automation_preview_call"},
    };
    #endregion

    protected const string AGENT_NAME = "cs-e2e-tests-client";
    protected const string AGENT_NAME2 = "cs-e2e-tests-client2";
    protected const string VECTOR_STORE = "cs-e2e-tests-vector-store";
    protected const string STREAMING_CONSTRAINT = "The test framework does not support iteration of stream in Sync mode.";
    private readonly List<string> _conversationIDs = [];
    private readonly List<string> _memoryStoreNames = [];
    private ProjectConversationsClient _conversations = null;
    private AIProjectMemoryStoresOperations _stores = null;
    protected readonly string MEMORY_STORE_SCOPE = "user_123";

    private static RecordedTestMode? GetRecordedTestMode() => Environment.GetEnvironmentVariable("AZURE_TEST_MODE") switch
        {
            "Playback" => RecordedTestMode.Playback,
            "Live" => RecordedTestMode.Live,
            "Record" => RecordedTestMode.Record,
            _ => null
        };

    public AgentsTestBase(bool isAsync) : this(isAsync: isAsync, testMode: GetRecordedTestMode()) { }

    public AgentsTestBase(bool isAsync, RecordedTestMode? testMode = null) : base(isAsync, testMode)
    {
        ProjectsTestSanitizers.ApplySanitizers(this);
        // Icrease Test timeout because ComputerUse tool test can take a little
        // more then 10 sec (default).
        TestTimeoutInSeconds = 20;
    }

    protected AIProjectClientOptions CreateTestProjectClientOptions(bool instrument = true, Dictionary<string, string> headers = null)
        => GetConfiguredOptions(new AIProjectClientOptions(), instrument, headers);

    protected ProjectOpenAIClientOptions CreateTestProjectOpenAIClientOptions(Uri endpoint = null, string apiVersion = null, bool instrument = true)
    => GetConfiguredOptions(
        new ProjectOpenAIClientOptions()
        {
            Endpoint = endpoint,
            ApiVersion = apiVersion,
        },
        instrument);

    private T GetConfiguredOptions<T>(T options, bool instrument, Dictionary<string, string> headers = null)
        where T : ClientPipelineOptions
    {
        options.AddPolicy(GetDumpPolicy(), PipelinePosition.BeforeTransport);
        options.NetworkTimeout = TimeSpan.FromMinutes(5);
        if (headers is not null && headers.Count > 0)
        {
            options.AddPolicy(new HeaderTestPolicy(headers), PipelinePosition.PerCall);
        }
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
            }),
            PipelinePosition.PerCall);

        return instrument ? InstrumentClientOptions(options) : options;
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

    protected AIProjectClient GetTestProjectClient(Dictionary<string, string> headers=default)
    {
        AIProjectClientOptions projectClientOptions = CreateTestProjectClientOptions(headers: headers);
        AuthenticationTokenProvider provider = TestEnvironment.Credential;
        return CreateProxyFromClient(new AIProjectClient(new(TestEnvironment.PROJECT_ENDPOINT), GetTestTokenProvider(), projectClientOptions));
    }

    protected async Task<OpenAIResponse> WaitForRun(OpenAIResponseClient responses, OpenAIResponse response, int waitTime=500)
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
        HashSet<string> expectedHash = [..expected];
        HashSet<string> observedHash = [..observed];
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

    protected void IgnoreSampleMayBe()
    {
        if (Mode != RecordedTestMode.Live)
        {
            Assert.Ignore("Samples represented as tests only for validation of compilation.");
        }
    }

    protected static string GetTestFile(string fileName, [CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(new string[] { dirName, "TestData", fileName });
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

    #region ToolHelper
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

    protected static string GetCityNicknameForTest(string location) => location switch
    {
        "Seattle, WA" => "The Emerald City",
        _ => throw new NotImplementedException(),
    };

    private async Task<MemoryStore> CreateMemoryStore(AIProjectClient projectClient)
    {
        try
        {
            await projectClient.MemoryStores.DeleteMemoryStoreAsync(name: "test-memory-store");
        }
        catch { }
        MemoryStoreDefaultDefinition memoryDefinitions = new(TestEnvironment.MODELDEPLOYMENTNAME, TestEnvironment.EMBEDDINGMODELDEPLOYMENTNAME);
        memoryDefinitions.Options = new(true, true);
        MemoryStore store = await projectClient.MemoryStores.CreateMemoryStoreAsync(name: "test-memory-store", definition: memoryDefinitions, description: "Test memory store.");
        ResponseItem userItem = ResponseItem.CreateUserMessageItem("My favorite animal is Plagiarus praepotens.");
        int pollingInterval = Mode != RecordedTestMode.Playback ? 500 : 0;
        MemoryUpdateResult updateResult = await projectClient.MemoryStores.WaitForMemoriesUpdateAsync(
            memoryStoreName: store.Name,
            options: new MemoryUpdateOptions(MEMORY_STORE_SCOPE)
            {
                Items = { userItem },
                UpdateDelay = 0,
            },
            pollingInterval: pollingInterval);
        Assert.That(updateResult.Status, Is.EqualTo(MemoryStoreUpdateStatus.Completed), $"Unexpected memory store update status: {updateResult.Status}, error details: {updateResult.ErrorDetails}.");
        _memoryStoreNames.Add(store.Name);
        return store;
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

    private McpTool GetProjectConnectedMCPTool()
    {
        McpTool tool = ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://api.githubcopilot.com/mcp"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
        ));
        tool.ProjectConnectionId = TestEnvironment.MCP_PROJECT_CONNECTION_NAME;
        return tool;
    }

    private async Task<OpenAPIAgentTool> GetOpenAPITool(AIProjectClient projectClient, bool withConnection)
    {
        OpenAPIAuthenticationDetails auth;
        string filePath;
        if (withConnection)
        {
            AIProjectConnection tripadvisorConnection = await projectClient.Connections.GetConnectionAsync("tripadvisor");
            auth = new OpenAPIProjectConnectionAuthenticationDetails(new OpenAPIProjectConnectionSecurityScheme(
                projectConnectionId: tripadvisorConnection.Id
            ));
            filePath = GetTestFile(fileName: "tripadvisor_openapi.json");
        }
        else
        {
            auth = new OpenAPIAnonymousAuthenticationDetails();
            filePath = GetTestFile(fileName: "weather_openapi.json");
        }
        OpenAPIFunctionDefinition functionDefinition = new OpenAPIFunctionDefinition(
            name: withConnection ? "tripadvisor" : "get_weather",
            spec: BinaryData.FromBytes(BinaryData.FromBytes(File.ReadAllBytes(filePath))),
            auth: auth
        );
        functionDefinition.Description = withConnection ? "Trip Advisor API to get travel information." : "Retrieve weather information for a location.";
        return new(functionDefinition);
    }

    /// <summary>
    /// Get the AgentDefinition, containing tool of a certain type.
    /// </summary>
    /// <param name="toolType"></param>
    /// <returns></returns>
    protected async Task<AgentDefinition> GetAgentToolDefinition(ToolType toolType, AIProjectClient projectClient, string model = default)
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
            ToolType.FileSearch => ResponseTool.CreateFileSearchTool(vectorStoreIds: [(await GetVectorStore(projectClient.OpenAI)).Id]),
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
            ToolType.Memory => new MemorySearchTool(memoryStoreName: (await CreateMemoryStore(projectClient)).Name, scope: MEMORY_STORE_SCOPE),
            ToolType.AzureAISearch => new AzureAISearchAgentTool(new AzureAISearchToolOptions(indexes: [GetAISearchIndex()])),
            ToolType.BingGrounding => new BingGroundingAgentTool(new BingGroundingSearchToolOptions(
                searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: projectClient.Connections.GetConnection(connectionName: TestEnvironment.BING_CONNECTION_NAME).Id)]
            )),
            ToolType.BingGroundingCustom => new BingCustomSearchAgentTool(new BingCustomSearchToolParameters(
                searchConfigurations: [new BingCustomSearchConfiguration(projectConnectionId: projectClient.Connections.GetConnection(connectionName: TestEnvironment.CUSTOM_BING_CONNECTION_NAME).Id, instanceName: TestEnvironment.BING_CUSTOM_SEARCH_INSTANCE_NAME)]
            )),
            ToolType.MCP => ResponseTool.CreateMcpTool(
                serverLabel: "api-specs",
                serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
                toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
            )),
            ToolType.MCPConnection => GetProjectConnectedMCPTool(),
            ToolType.OpenAPI => await GetOpenAPITool(projectClient, false),
            ToolType.OpenAPIConnection => await GetOpenAPITool(projectClient, true),
            ToolType.BrowserAutomation => new BrowserAutomationAgentTool(
            new BrowserAutomationToolParameters(
                new BrowserAutomationToolConnectionParameters((await projectClient.Connections.GetConnectionAsync(TestEnvironment.PLAYWRIGHT_CONNECTION_NAME)).Value.Id)
            )),
            _ => throw new InvalidOperationException($"Unknown tool type {toolType}")
        };
        return new PromptAgentDefinition(model ?? TestEnvironment.MODELDEPLOYMENTNAME)
        {
            Instructions = ToolInstructions[toolType],
            Tools = { tool },
        };
    }
    #endregion
    #region Cleanup
    [TearDown]
    public async virtual Task Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        Uri connectionString = new(TestEnvironment.PROJECT_ENDPOINT);
        AIProjectClient projectClient = new(connectionString, TestEnvironment.Credential);

        // Remove conversations.
        if (_conversations is not null)
        {
            foreach (string id in _conversationIDs)
            {
                try
                {
                    await _conversations.DeleteConversationAsync(conversationId: id);
                }
                catch (RequestFailedException ex)
                {
                    // Throw only if it is the error other then "Not found."
                    if (ex.Status != 404)
                        throw;
                }
            }
        }
        if (_stores != null)
        {
            foreach (string name in _memoryStoreNames)
            {
                try
                {
                    await _stores.DeleteMemoryStoreAsync(name: name);
                }
                catch (RequestFailedException ex)
                {
                    // Throw only if it is the error other then "Not found."
                    if (ex.Status != 404)
                        throw;
                }
            }
        }
        // Remove Vector stores
        VectorStoreClient oaiVctStoreClient = projectClient.OpenAI.GetVectorStoreClient();
        foreach (VectorStore vct in oaiVctStoreClient.GetVectorStores().Where(x => (x.Name ?? "").Equals(VECTOR_STORE)))
        {
            oaiVctStoreClient.DeleteVectorStore(vectorStoreId: vct.Id);
        }
        // Remove Agents.
        foreach (AgentVersion ag in projectClient.Agents.GetAgentVersions(agentName: AGENT_NAME))
        {
            projectClient.Agents.DeleteAgentVersion(agentName: ag.Name, agentVersion: ag.Version);
        }
        foreach (AgentVersion ag in projectClient.Agents.GetAgentVersions(agentName: AGENT_NAME2))
        {
            projectClient.Agents.DeleteAgentVersion(agentName: ag.Name, agentVersion: ag.Version);
        }
    }
    #endregion
    #region Debug Method
    internal static PipelinePolicy GetDumpPolicy()
    {
        return new TestPipelinePolicy((message) =>
        {
            if (message.Request is not null && message.Response is null)
            {
                Console.WriteLine($"--- New request ---");
                IEnumerable<string> headerPairs = message?.Request?.Headers?.Select(header => $"{header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
                string headers = string.Join(",", headerPairs);
                Console.WriteLine($"Headers: {headers}");
                Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
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
                        Console.WriteLine(requestDump);
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
                IEnumerable<string> headerPairs = message?.Response?.Headers?.Select(header => $"{header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
                string headers = string.Join(",", headerPairs);
                Console.WriteLine($"Response headers: {headers}");
                if (message.BufferResponse)
                {
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
    #endregion
}
