// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Azure.AI.Agents.Tests;

public class AgentsTestBase : RecordedTestBase<AIAgentsTestEnvironment>
{
    #region Enumertions
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
        AzureFunction,
        BingGrounding,
        MCP,
        OpenAPI,
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
        {ToolType.BingGrounding, "How does wikipedia explain Euler's Identity?" },
        {ToolType.OpenAPI, "What's the weather in Seattle?"},
        {ToolType.DeepResearch, "Research the current state of studies on orca intelligence and orca language, " +
            "including what is currently known about orcas' cognitive capabilities, " +
            "communication systems and problem-solving reflected in recent publications in top their scientific " +
            "journals like Science, Nature and PNAS."},
        {ToolType.AzureAISearch, "What is the temperature rating of the cozynights sleeping bag?"},
        {ToolType.ConnectedAgent, "What is the Microsoft stock price?"},
        {ToolType.FileSearch,  "Can you give me the documented codes for 'banana' and 'orange'?"},
        {ToolType.AzureFunction, "What is the most prevalent element in the universe? What would foo say?"},
        {ToolType.BrowserAutomation, "Your goal is to report the percent of Microsoft year-to-date stock price change. " +
                    "To do that, go to the website finance.yahoo.com. " +
                    "At the top of the page, you will find a search bar." +
                    "Enter the value 'MSFT', to get information about the Microsoft stock price." +
                    "At the top of the resulting page you will see a default chart of Microsoft stock price." +
                    "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it."},
        {ToolType.MicrosoftFabric, "What are top 3 weather events with largest revenue loss?"},
        {ToolType.Sharepoint, "Hello, summarize the key points of the first document in the list."},
        {ToolType.CodeInterpreter,  "Can you give me the documented codes for 'banana' and 'orange'?"},
    };

    public Dictionary<ToolType, string> ToolInstructions = new()
    {
        {ToolType.None, "You are a prompt agent."},
        {ToolType.BingGrounding, "You are helpful agent."},
        {ToolType.FunctionCall, "You are helpful agent. Use the provided functions to help answer questions."},
        {ToolType.OpenAPI, "You are helpful agent."},
        {ToolType.DeepResearch, "You are a helpful agent that assists in researching scientific topics."},
        {ToolType.AzureAISearch, "You are a helpful agent that can search for information using Azure AI Search."},
        {ToolType.ConnectedAgent, "You are a helpful assistant, and use the connected agents to get stock prices."},
        {ToolType.FileSearch,  "You are helpful agent."},
        {ToolType.BrowserAutomation, "You are an Agent helping with browser automation tasks. " +
                            "You can answer questions, provide information, and assist with various tasks " +
                            "related to web browsing using the Browser Automation tool available to you." },
        {ToolType.MicrosoftFabric, "You are helpful agent."},
        {ToolType.Sharepoint, "You are helpful agent."},
        {ToolType.CodeInterpreter, "You are helpful agent."},
    };

    public Dictionary<ToolType, string> ExpectedOutput = new()
    {
        {ToolType.CodeInterpreter, "673457"},
        {ToolType.FileSearch, "673457"},
        {ToolType.FunctionCall, "emerald"},
    };
    #endregion
    protected OpenAIClientOptions TestOpenAIClientOptions
    {
        get
        {
            OpenAIClientOptions options = new();
            options.AddPolicy(GetDumpPolicy(), PipelinePosition.BeforeTransport);

            if (Mode != RecordedTestMode.Live && Recording != null)
            {
                // Set up proxy transport for recording/playback
                options.Transport = new AgentsProxyTransport(Recording);

                // Configure retry policy for faster playback
                if (Mode == RecordedTestMode.Playback)
                {
                    options.RetryPolicy = new TestClientRetryPolicy(TimeSpan.FromMilliseconds(10));
                }
            }
            return options;
        }
    }

    protected const string AGENT_NAME = "cs_e2e_tests_client";
    protected const string AGENT_NAME2 = "cs_e2e_tests_client2";
    protected const string VECTOR_STORE = "cs_e2e_tests_vector_store";
    protected const string STREAMING_CONSTRAINT = "The test framework does not support iteration of stream in Sync mode.";
    private readonly List<string> _conversationIDs = [];
    private readonly List<string> _memoryStoreIDs = [];
    private ProjectOpenAIConversationClient _conversations = null;
    private MemoryStoreClient _stores = null;

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
        // TestDiagnostics = false;
    }

    protected AIProjectClient GetTestProjectClient()
    {
        return new(new Uri(TestEnvironment.PROJECT_ENDPOINT), new DefaultAzureCredential());
    }

    protected AgentClient GetTestClient()
    {
        AgentClientOptions options = new AgentClientOptions();
        options.AddPolicy(GetDumpPolicy(), PipelinePosition.BeforeTransport);

        if (Mode != RecordedTestMode.Live && Recording != null)
        {
            // Set up proxy transport for recording/playback
            options.Transport = new AgentsProxyTransport(Recording);

            // Configure retry policy for faster playback
            if (Mode == RecordedTestMode.Playback)
            {
                options.RetryPolicy = new TestClientRetryPolicy(TimeSpan.FromMilliseconds(10));
            }
        }
        AuthenticationTokenProvider provider = TestEnvironment.Credential;
        // For local testing if you are using non default account
        // add USE_CLI_CREDENTIAL into the .runsettings and set it to true,
        // also provide the PATH variable.
        // This path should allow launching az command.
        var cli = System.Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL");
        if (!string.IsNullOrEmpty(cli) && string.Compare(cli, "true", StringComparison.OrdinalIgnoreCase) == 0 && Mode != RecordedTestMode.Playback)
        {
            provider = new AzureCliCredential();
        }

        Uri connectionString = new(TestEnvironment.PROJECT_ENDPOINT);
        return CreateProxyFromClient(new AgentClient(connectionString, provider, InstrumentClientOptions(options)));
    }

    protected OpenAIClient GetTestOpenAIClientFrom(AgentClient client, OpenAIClientOptions options = null)
    {
        options ??= new();
        options.AddPolicy(AgentsTestBase.GetDumpPolicy(), PipelinePosition.BeforeTransport);
        options = InstrumentClientOptions(options);
        OpenAIClient unproxiedClient = client.GetOpenAIClient(options);
        return CreateProxyFromClient(unproxiedClient);
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

    protected async Task<AgentConversation> CreateConversation(AgentClient client, ProjectConversationCreationOptions options = null)
    {
        AgentConversation conversation = await client.OpenAI.Conversations.CreateAgentConversationAsync(options).ConfigureAwait(false);
        _conversationIDs.Add(conversation.Id);
        return conversation;
    }

    protected async Task<MemoryStore> CreateMemoryStore(AgentClient client)
    {
        _stores ??= client.GetMemoryStoreClient();
        MemoryStoreDefaultDefinition memoryStoreDefinition = new(
            chatModel: TestEnvironment.MODELDEPLOYMENTNAME,
            embeddingModel: TestEnvironment.EMBEDDINGMODELDEPLOYMENTNAME
        );
        MemoryStore memoryStore = await _stores.CreateMemoryStoreAsync(
            name: "jokeMemory",
            definition: memoryStoreDefinition,
            description: "Memory store for test."
        );
        _memoryStoreIDs.Add(memoryStore.Id);
        return memoryStore;
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

    /// <summary>
    /// Get the AgentDefinition, containing tool of a certain type.
    /// </summary>
    /// <param name="toolType"></param>
    /// <returns></returns>
    protected async Task<AgentDefinition> GetAgentToolDefinition(ToolType toolType, OpenAIClient oaiClient)
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
            // OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
            // OpenAIFile uploadedFile = fileClient.UploadFile(filePath: filePath, purpose: FileUploadPurpose.Assistants);
            // Console.WriteLine(uploadedFile.id)
            ToolType.CodeInterpreter => ResponseTool.CreateCodeInterpreterTool(
                    new CodeInterpreterToolContainer(
                        CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration(
                            fileIds: [TestEnvironment.OPENAI_FILE_ID]
                        )
                    )
                ),
            ToolType.FileSearch => ResponseTool.CreateFileSearchTool(vectorStoreIds: [(await GetVectorStore(oaiClient)).Id]),
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
            _ => throw new InvalidOperationException($"Unknown tool type {toolType}")
        };
        return new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME)
        {
            Instructions = ToolInstructions[toolType],
            Tools = { tool },
        };
    }
    #endregion
    #region Cleanup
    [TearDown]
    public virtual void Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        Uri connectionString = new(TestEnvironment.PROJECT_ENDPOINT);
        AgentClientOptions opts = new();
        AgentClient client = new(endpoint: connectionString, tokenProvider: TestEnvironment.Credential, options: opts);
        // Remove conversations.
        if (_conversations is not null)
        {
            foreach (string id in _conversationIDs)
            {
                try
                {
                    _conversations.DeleteConversation(conversationId: id);
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
            foreach (string name in _memoryStoreIDs)
            {
                try
                {
                    _stores.DeleteMemoryStore(name: name);
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
        OpenAIClient oaiClient = client.GetOpenAIClient();
        VectorStoreClient oaiVctStoreClient = oaiClient.GetVectorStoreClient();
        foreach (VectorStore vct in oaiVctStoreClient.GetVectorStores().Where(x => (x.Name ?? "").Equals(VECTOR_STORE)))
        {
            oaiVctStoreClient.DeleteVectorStore(vectorStoreId: vct.Id);
        }
        // Remove Agents.
        foreach (AgentVersion ag in client.GetAgentVersions(agentName: AGENT_NAME))
        {
            client.DeleteAgentVersion(agentName: ag.Name, agentVersion: ag.Version);
        }
        foreach (AgentVersion ag in client.GetAgentVersions(agentName: AGENT_NAME2))
        {
            client.DeleteAgentVersion(agentName: ag.Name, agentVersion: ag.Version);
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
