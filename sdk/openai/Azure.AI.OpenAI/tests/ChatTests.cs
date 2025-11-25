// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Chat;
using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI.Chat;
using OpenAI.TestFramework;
using OpenAI.TestFramework.Mocks;
using OpenAI.TestFramework.Utils;

namespace Azure.AI.OpenAI.Tests;
#pragma warning disable AOAI001
#pragma warning disable SCME0001
public partial class ChatTests : AoaiTestBase<ChatClient>
{
    public ChatTests(bool isAsync) : base(isAsync)
    { }

    #region General tests

    [Test]
    [Category("Smoke")]
    public async Task DefaultUserAgentStringWorks()
    {
        using MockHttpMessageHandler pipeline = new(MockHttpMessageHandler.ReturnEmptyJson);

        Uri endpoint = new Uri("https://www.bing.com/");
        string apiKey = "not-a-real-one";
        string model = "ignore";

        AzureOpenAIClient topLevel = new(
            endpoint,
            new ApiKeyCredential(apiKey),
            new AzureOpenAIClientOptions()
            {
                Transport = pipeline.Transport
            });

        ChatClient client = WrapClient(topLevel.GetChatClient(model));

        await client.CompleteChatAsync([new UserChatMessage("Hello")]);

        Assert.That(pipeline.Requests, Is.Not.Empty);

        var request = pipeline.Requests[0];
        Assert.That(request.Method, Is.EqualTo(HttpMethod.Post));
        Assert.That(request.Uri?.GetLeftPart(UriPartial.Authority), Is.EqualTo(endpoint.GetLeftPart(UriPartial.Authority)));
        Assert.That(request.Headers.GetValueOrDefault("api-key")?.FirstOrDefault(), Is.EqualTo(apiKey));
        Assert.That(request.Headers.GetValueOrDefault("User-Agent")?.FirstOrDefault(), Does.Contain("azsdk-net-AI.OpenAI/"));
        Assert.That(request.Content, Is.Not.Null);
        var jsonString = request.Content.ToString();
        Assert.That(jsonString, Is.Not.Null.Or.Empty);
        Assert.That(jsonString, Does.Contain("\"messages\"").And.Contain("\"model\"").And.Contain(model));
    }

    [Test]
    [Category("Smoke")]
    public void DataSourceSerializationWorks()
    {
        AzureSearchChatDataSource source = new()
        {
            Endpoint = new Uri("https://some-search-resource.azure.com"),
            Authentication = DataSourceAuthentication.FromApiKey("test-api-key"),
            IndexName = "index-name-here",
            FieldMappings = new()
            {
                ContentFieldNames = { "hello" },
                TitleFieldName = "hi",
            },
            AllowPartialResults = true,
            QueryType = DataSourceQueryType.Simple,
            OutputContexts = DataSourceOutputContexts.AllRetrievedDocuments | DataSourceOutputContexts.Citations,
            VectorizationSource = DataSourceVectorizer.FromEndpoint(
                new Uri("https://my-embedding.com"),
                DataSourceAuthentication.FromApiKey("embedding-api-key")),
        };
        dynamic serialized = ModelReaderWriter.Write(source).ToDynamicFromJson();
        Assert.That(serialized?.type?.ToString(), Is.EqualTo("azure_search"));
        Assert.That(serialized?.parameters?.authentication?.type?.ToString(), Is.EqualTo("api_key"));
        Assert.That(serialized?.parameters?.authentication?.key?.ToString(), Does.Contain("test"));
        Assert.That(serialized?.parameters?.index_name?.ToString(), Is.EqualTo("index-name-here"));
        Assert.That(serialized?.parameters?.fields_mapping?.content_fields?[0]?.ToString(), Is.EqualTo("hello"));
        Assert.That(serialized?.parameters?.fields_mapping?.title_field?.ToString(), Is.EqualTo("hi"));
        Assert.That(bool.TryParse(serialized?.parameters?.allow_partial_result?.ToString(), out bool parsed) && parsed == true);
        Assert.That(serialized?.parameters?.query_type?.ToString(), Is.EqualTo("simple"));
        Assert.That(serialized?.parameters?.include_contexts?[0]?.ToString(), Is.EqualTo("citations"));
        Assert.That(serialized?.parameters?.include_contexts?[1]?.ToString(), Is.EqualTo("all_retrieved_documents"));
        Assert.That(serialized?.parameters?.embedding_dependency?.type?.ToString(), Is.EqualTo("endpoint"));

        ChatCompletionOptions options = new();
#if !AZURE_OPENAI_GA
        options.AddDataSource(new ElasticsearchChatDataSource()
        {
            Authentication = DataSourceAuthentication.FromAccessToken("foo-token"),
            Endpoint = new Uri("https://my-elasticsearch.com"),
            IndexName = "my-index-name",
            InScope = true,
        });

        IReadOnlyList<ChatDataSource> sourcesFromOptions = options.GetDataSources();
        Assert.That(sourcesFromOptions, Has.Count.EqualTo(1));
        Assert.That(sourcesFromOptions[0], Is.InstanceOf<ElasticsearchChatDataSource>());
        Assert.That(((ElasticsearchChatDataSource)sourcesFromOptions[0]).IndexName, Is.EqualTo("my-index-name"));
#else
        options.AddDataSource(new AzureSearchChatDataSource()
        {
            Endpoint = new("https://test-endpoint.test"),
            Authentication = DataSourceAuthentication.FromApiKey("foo-api-key"),
            IndexName = "my-index-name",
        });

        IReadOnlyList<ChatDataSource> sourcesFromOptions = options.GetDataSources();
        Assert.That(sourcesFromOptions, Has.Count.EqualTo(1));
        Assert.That(sourcesFromOptions[0], Is.InstanceOf<AzureSearchChatDataSource>());
        Assert.That(((AzureSearchChatDataSource)sourcesFromOptions[0]).IndexName, Is.EqualTo("my-index-name"));
#endif

        options.AddDataSource(new CosmosChatDataSource()
        {
            Authentication = DataSourceAuthentication.FromApiKey("api-key"),
            ContainerName = "my-container-name",
            DatabaseName = "my_database_name",
            FieldMappings = new()
            {
                ContentFieldNames = { "hello", "world" },
            },
            IndexName = "my-index-name",
            VectorizationSource = DataSourceVectorizer.FromDeploymentName("my-deployment"),
        });
        sourcesFromOptions = options.GetDataSources();
        Assert.That(sourcesFromOptions, Has.Count.EqualTo(2));
        Assert.That(sourcesFromOptions[1], Is.InstanceOf<CosmosChatDataSource>());
    }

    [Test]
    [Category("Smoke")]
    public async Task MaxTokensSerializationConfigurationWorks()
    {
        using MockHttpMessageHandler pipeline = new(MockHttpMessageHandler.ReturnEmptyJson);

        Uri endpoint = new Uri("https://www.bing.com/");
        string apiKey = "not-a-real-one";
        string model = "ignore";

        AzureOpenAIClient topLevel = new(
            endpoint,
            new ApiKeyCredential(apiKey),
            new AzureOpenAIClientOptions()
            {
                Transport = pipeline.Transport
            });

        ChatClient client = topLevel.GetChatClient(model);

        ChatCompletionOptions options = new();
        bool GetSerializedOptionsContains(string value)
        {
            BinaryData serialized = ModelReaderWriter.Write(options);
            return serialized.ToString().Contains(value);
        }
        async Task AssertExpectedSerializationAsync(bool hasOldMaxTokens, bool hasNewMaxCompletionTokens, bool isSentilel=false)
        {
            _ = await client.CompleteChatAsync(["Just mocking, no call here"], options);
            if (isSentilel)
            {
                Assert.True(GetSerializedOptionsContains("max_tokens"));
                Assert.True(GetSerializedOptionsContains("__EMPTY__"));
            }
            else
            {
                Assert.That(GetSerializedOptionsContains("max_tokens"), Is.EqualTo(hasOldMaxTokens));
            }
            Assert.That(GetSerializedOptionsContains("max_completion_tokens"), Is.EqualTo(hasNewMaxCompletionTokens));
        }

        await AssertExpectedSerializationAsync(false, false);
        await AssertExpectedSerializationAsync(false, false);

        options.MaxOutputTokenCount = 42;
        await AssertExpectedSerializationAsync(true, false);
        await AssertExpectedSerializationAsync(true, false);
        options.MaxOutputTokenCount = null;
        await AssertExpectedSerializationAsync(false, false);
        options.MaxOutputTokenCount = 42;
        await AssertExpectedSerializationAsync(true, false);

        options.SetNewMaxCompletionTokensPropertyEnabled();
        await AssertExpectedSerializationAsync(false, true, true);
        await AssertExpectedSerializationAsync(false, true, true);
        options.MaxOutputTokenCount = null;
        await AssertExpectedSerializationAsync(false, false, true);
        options.MaxOutputTokenCount = 42;
        await AssertExpectedSerializationAsync(false, true, true);

        options.SetNewMaxCompletionTokensPropertyEnabled(false);
        await AssertExpectedSerializationAsync(true, false);
        await AssertExpectedSerializationAsync(true, false);
        options.MaxOutputTokenCount = null;
        await AssertExpectedSerializationAsync(false, false);
        options.MaxOutputTokenCount = 42;
        await AssertExpectedSerializationAsync(true, false);
    }

    [RecordedTest]
    public async Task ChatCompletionBadKeyGivesHelpfulError()
    {
        string mockKey = "not-a-valid-key-and-should-still-be-sanitized";

        try
        {
            ChatClient chatClient = GetTestClient(keyCredential: new ApiKeyCredential(mockKey));
            _ = await chatClient.CompleteChatAsync([new UserChatMessage("oops, this won't work with that key!")]);
            Assert.Fail("No exception was thrown");
        }
        catch (Exception thrownException)
        {
            Assert.That(thrownException, Is.InstanceOf<ClientResultException>());
            Assert.That(thrownException.Message, Does.Contain("invalid subscription key"));
            Assert.That(thrownException.Message, Does.Not.Contain(mockKey));
        }
    }

    [RecordedTest]
    public async Task DefaultAzureCredentialWorks()
    {
        ChatClient chatClient = GetTestClient(tokenCredential: this.TestEnvironment.Credential);
        ChatCompletion chatCompletion = await chatClient.CompleteChatAsync([ChatMessage.CreateUserMessage("Hello, world!")]);
        Assert.That(chatCompletion, Is.Not.Null);
        Assert.That(chatCompletion.Content, Is.Not.Null.Or.Empty);
        Assert.That(chatCompletion.Content[0].Text, Is.Not.Null.Or.Empty);
    }

    [RecordedTest]
    [Ignore("Delay behavior not emulated by recordings, and needs to be run manually with some time in between iterations due to service throttling behavior")]
    [Category("Live")]
    [TestCase("x-ms-retry-after-ms", "1000", 1000)]
    [TestCase("retry-after-ms", "1400", 1400)]
    [TestCase("Retry-After", "1", 1000)]
    [TestCase("Retry-After", "1.5", 1500)]
    [TestCase("retry-after-ms", "200", 200)]
    [TestCase("x-fake-test-retry-header", "1400", 800)]
    public async Task RateLimitedRetryWorks(string headerName, string headerValue, double expectedDelayMilliseconds)
    {
        const string responseClass = "HttpClientTransportResponse";
        const string responseField = "_httpResponse";
        IConfiguration testConfig = TestConfig.GetConfig("rate_limited_chat")!;
        Assert.That(testConfig, Is.Not.Null);

        int failureCount = 0;
        string? clientRequestId = null;

        TestPipelinePolicy replaceHeadersPolicy = new(
            requestAction: (request) =>
            {
                clientRequestId ??= request.Headers.GetFirstOrDefault("x-ms-client-request-id");
            },
            responseAction: (response) =>
            {
                if (response.Status != 200)
                {
                    failureCount++;

                    Type httpPipelineResponseType = typeof(HttpClientPipelineTransport).GetNestedType(responseClass, BindingFlags.NonPublic)
                        ?? throw new InvalidOperationException($"Could not the expected {responseClass} inner non public class");
                    FieldInfo httpResponseField = httpPipelineResponseType.GetField(responseField, BindingFlags.Instance | BindingFlags.NonPublic)
                        ?? throw new InvalidOperationException($"Could not find the expected {responseClass}.{responseField} field)");
                    HttpResponseMessage httpResponse = httpResponseField.GetValue(response) as HttpResponseMessage
                        ?? throw new InvalidOperationException($"Could note determine the HttpResponseMessage to modify");

                    httpResponse.Headers.Remove("x-ms-retry-after-ms");
                    httpResponse.Headers.Remove("retry-after-ms");
                    httpResponse.Headers.Remove("Retry-After");
                    httpResponse.Headers.TryAddWithoutValidation(headerName, headerValue);
                }
            });

        TestClientOptions options = new();
        options.AddPolicy(replaceHeadersPolicy, PipelinePosition.PerTry);

        ChatClient client = GetTestClient(testConfig, options);

        BinaryContent requestContent = BinaryContent.Create(BinaryData.FromString($$"""
            {
              "model": "{{testConfig.Deployment}}",
              "messages": [
                { "role": "user", "content": "Write three haikus about tropical fruit." }
              ]
            }
            """));
        RequestOptions noThrowOptions = new() { ErrorOptions = ClientErrorBehaviors.NoThrow };

        TimeSpan? observed200Delay = null;
        TimeSpan? observed429Delay = null;

        for (int i = 0; i < 4 && !observed429Delay.HasValue; i++)
        {
            Stopwatch requestWatch = Stopwatch.StartNew();
            ClientResult protocolResult = await client.CompleteChatAsync(requestContent, noThrowOptions);
            PipelineResponse response = protocolResult.GetRawResponse();
            bool responseHasRequestId = response.Headers.TryGetValue("x-ms-client-request-id", out string? requestIdFromResponse);
            Assert.That(responseHasRequestId, Is.True);
            Assert.That(requestIdFromResponse, Is.EqualTo(clientRequestId));
            switch (response.Status)
            {
                case 200:
                    observed200Delay = requestWatch.Elapsed;
                    break;
                case 429:
                    observed429Delay = requestWatch.Elapsed;
                    break;
                default:
                    Assert.Fail();
                    break;
            }
            clientRequestId = null;
        }

        Assert.That(observed200Delay.HasValue, Is.True);
        Assert.That(observed429Delay.HasValue, Is.True);
        Assert.That(failureCount, Is.EqualTo(4));
        Assert.That(observed429Delay!.Value.TotalMilliseconds, Is.GreaterThan(expectedDelayMilliseconds));
        Assert.That(observed429Delay!.Value.TotalMilliseconds, Is.LessThan(3 * expectedDelayMilliseconds + 2 * observed200Delay!.Value.TotalMilliseconds));
    }

#endregion

    #region Regular chat completions tests

    [RecordedTest]
    public async Task ChatCompletion()
    {
        ChatClient chatClient = GetTestClient();
        ClientResult<ChatCompletion> chatCompletion = await chatClient.CompleteChatAsync([new UserChatMessage("hello, world!")]);
        Assert.That(chatCompletion, Is.Not.Null);
        Assert.That(chatCompletion.Value, Is.Not.Null);
        Assert.That(chatCompletion.Value, Is.InstanceOf<ChatCompletion>());
        Assert.That(chatCompletion.Value.Content, Is.Not.Null.Or.Empty);
    }

    [RecordedTest]
    public async Task ChatCompletionWithHistoryAndLogProbabilities()
    {
        ChatClient client = GetTestClient();

        ChatCompletion response = await client.CompleteChatAsync(
            [
                new SystemChatMessage("You are a helpful assistant."),
                new UserChatMessage("I am baking a pizza, can you help me?"),
                new AssistantChatMessage("Of course, I'd be happy to help! What do you need assistance with? Do you need a recipe, cooking time and temperature suggestions, topping ideas, or something else?"),
                new UserChatMessage("What temperature should I bake at?")
            ],
            new ChatCompletionOptions()
            {
                IncludeLogProbabilities = true,
                TopLogProbabilityCount = 3
            });

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Id, Is.Not.Null.Or.Empty);
        Assert.That(response.CreatedAt, Is.GreaterThan(new DateTimeOffset(2024, 01, 01, 00, 00, 00, TimeSpan.Zero)));
        Assert.That(response.FinishReason, Is.Not.Null.Or.Empty);
        Assert.That(response.Content, Is.Not.Null.Or.Empty);
        Assert.That(response.Content.Count, Is.EqualTo(1));
        Assert.That(response.Usage, Is.Not.Null);
        Assert.That(response.Usage.InputTokenCount, Is.GreaterThan(10));
        Assert.That(response.Usage.OutputTokenCount, Is.GreaterThan(10));
        Assert.That(response.Usage.TotalTokenCount, Is.GreaterThan(20));
        Assert.That(response.ContentTokenLogProbabilities, Is.Not.Null.Or.Empty);
        foreach (var logProb in response.ContentTokenLogProbabilities)
        {
            Assert.That(logProb, Is.Not.Null);
            Assert.That(logProb.TopLogProbabilities, Is.Not.Null.Or.Empty);
            Assert.That(logProb.TopLogProbabilities.Count, Is.EqualTo(3));
        }

        ChatMessageContentPart content = response.Content[0];
        Assert.That(content.Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
        Assert.That(content.Text, Is.Not.Null.Or.Empty);
        Assert.That(content.Text, Does
            .Contain("Fahrenheit")
            .Or.Contain("Celsius")
            .Or.Contain("�F")
            .Or.Contain("�C")
            .Or.Contain("oven"));
    }

    [RecordedTest]
    public async Task ChatCompletionWithTextFormat()
    {
        ChatClient client = GetTestClient();
        ChatCompletionOptions options = new()
        {
            ResponseFormat = ChatResponseFormat.CreateTextFormat(),
        };

        ChatCompletion response = await client.CompleteChatAsync([new UserChatMessage("Give me a random number")], options);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Content, Is.Not.Null.Or.Empty);
        Assert.That(response.Content[0].Text, Is.Not.Null.Or.Empty);
    }

    [RecordedTest]
    public async Task ChatCompletionContentFilter()
    {
        ChatClient client = GetTestClient();
        ClientResult<ChatCompletion> chatCompletionResult = await client.CompleteChatAsync([ChatMessage.CreateUserMessage("Hello, world!")]);
        ChatCompletion chatCompletion = chatCompletionResult;
        RequestContentFilterResult promptFilterResult = chatCompletion.GetRequestContentFilterResult();
        Assert.That(promptFilterResult, Is.Not.Null);
        Assert.That(promptFilterResult.Sexual?.Filtered, Is.False);
        Assert.That(promptFilterResult.Sexual?.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
        ResponseContentFilterResult responseFilterResult = chatCompletion.GetResponseContentFilterResult();
        Assert.That(responseFilterResult, Is.Not.Null);
        Assert.That(responseFilterResult.Hate?.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
        if (responseFilterResult.ProtectedMaterialCode is not null)
        {
            Assert.That(responseFilterResult.ProtectedMaterialCode.Detected, Is.False);
            Assert.That(responseFilterResult.ProtectedMaterialCode.Filtered, Is.False);
        }
        if (responseFilterResult.ProtectedMaterialText is not null)
        {
            Assert.That(responseFilterResult.ProtectedMaterialText.Detected, Is.False);
            Assert.That(responseFilterResult.ProtectedMaterialText.Filtered, Is.False);
        }
    }

    [RecordedTest]
    public async Task SearchExtensionWorks()
    {
        var searchConfig = TestConfig.GetConfig("search")!;
        Assert.That(searchConfig, Is.Not.Null);
        string searchIndex = searchConfig.GetValueOrThrow<string>("index");

        AzureSearchChatDataSource source = new()
        {
            Endpoint = searchConfig.Endpoint,
            Authentication = DataSourceAuthentication.FromApiKey(searchConfig.Key),
            IndexName = searchIndex,
            AllowPartialResults = true,
            QueryType = DataSourceQueryType.Simple,
        };
        ChatCompletionOptions options = new();
        options.AddDataSource(source);

        ChatClient client = GetTestClient();

        ClientResult<ChatCompletion> chatCompletionResult = await client.CompleteChatAsync(
            [new UserChatMessage("What does the term 'PR complete' mean?")],
            options);
        Assert.That(chatCompletionResult, Is.Not.Null);

        ChatCompletion chatCompletion = chatCompletionResult.Value;
        Assert.That(chatCompletion, Is.Not.Null);
        Assert.That(chatCompletion.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
        Assert.That(chatCompletion.Content, Is.Not.Null.Or.Empty);

        var content = chatCompletion.Content[0];
        Assert.That(content.Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
        Assert.That(content.Text, Is.Not.Null.Or.Empty);

        ChatMessageContext context = chatCompletion.GetMessageContext();
        Assert.IsNotNull(context);
        Assert.That(context.Intent, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations, Has.Count.GreaterThan(0));
        Assert.That(context.Citations[0].FilePath, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0].Content, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0].ChunkId, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0].Title, Is.Not.Null.Or.Empty);
    }

    [RecordedTest]
    public async Task StructuredOutputsWork()
    {
        ChatClient client = GetTestClient();
        IEnumerable<ChatMessage> messages = [
            new UserChatMessage("What's heavier, a pound of feathers or sixteen ounces of steel?")
        ];
        ChatCompletionOptions options = new ChatCompletionOptions()
        {
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                "test_schema",
                BinaryData.FromString("""
                    {
                      "type": "object",
                      "properties": {
                        "answer": {
                          "type": "string"
                        },
                        "steps": {
                          "type": "array",
                          "items": {
                            "type": "string"
                          }
                        }
                      },
                      "required": [
                        "answer",
                        "steps"
                      ],
                      "additionalProperties": false
                    }
                    """),
                "a single final answer with a supporting collection of steps",
                jsonSchemaIsStrict: true)
        };
        ChatCompletion completion = await client.CompleteChatAsync(messages, options)!;
        Assert.That(completion, Is.Not.Null);
        Assert.That(completion.Refusal, Is.Null.Or.Empty);
        Assert.That(completion.Content?.Count, Is.EqualTo(1));
        JsonDocument contentDocument = null!;
        Assert.DoesNotThrow(() => contentDocument = JsonDocument.Parse(completion!.Content![0].Text));
        Assert.IsTrue(contentDocument.RootElement.TryGetProperty("answer", out JsonElement answerProperty));
        Assert.IsTrue(answerProperty.ValueKind == JsonValueKind.String);
        Assert.IsTrue(contentDocument.RootElement.TryGetProperty("steps", out JsonElement stepsProperty));
        Assert.IsTrue(stepsProperty.ValueKind == JsonValueKind.Array);
    }

    [RecordedTest]
    public async Task UserSecurityContextWorks()
    {
        ChatClient client = GetTestClient();

        string userId = Guid.NewGuid().ToString();
        string sourceIP = "123.456.78.9";
        UserSecurityContext userSecurityContext = new()
        {
            EndUserId = userId,
            SourceIP = sourceIP,
        };

        ChatCompletionOptions options = new();
        options.SetUserSecurityContext(userSecurityContext);

        UserSecurityContext retrievedUserSecurityContext = options.GetUserSecurityContext();
        Assert.That(retrievedUserSecurityContext, Is.Not.Null);
        Assert.That(retrievedUserSecurityContext.EndUserId, Is.EqualTo(userId));
        Assert.That(retrievedUserSecurityContext.SourceIP, Is.EqualTo(sourceIP));

        ChatCompletion completion = await client.CompleteChatAsync([ChatMessage.CreateUserMessage("Hello, world!")]);
        Assert.That(completion, Is.Not.Null);
    }

    [RecordedTest]
    [TestCase("chat", false)]
    [TestCase("chat_o1", true)]
    [TestCase("chat_o3-mini", true)]
    public async Task MaxOutputTokensWorksAcrossModels(string testConfigName, bool useNewProperty)
    {
        IConfiguration testConfig = TestConfig.GetConfig(testConfigName)!;
        ChatClient client = GetTestClient(testConfig);

        ChatCompletionOptions options = new()
        {
            MaxOutputTokenCount = 16,
        };

        if (useNewProperty)
        {
            options.SetNewMaxCompletionTokensPropertyEnabled();
        }
        ChatCompletion completion = await client.CompleteChatAsync(
            ["Hello, world! Please write a funny haiku to greet me."],
            options);
        Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.Length));

        string serializedOptionsAfterUse = ModelReaderWriter.Write(options).ToString();

        Assert.That(serializedOptionsAfterUse, Does.Contain("max_tokens"));
        if (useNewProperty)
        {
            Assert.That(serializedOptionsAfterUse, Does.Contain("max_completion_tokens"));
            Assert.That(serializedOptionsAfterUse, Does.Contain("__EMPTY__"));
        }
        else
        {
            Assert.That(serializedOptionsAfterUse, Does.Not.Contain("max_completion_tokens"));
            Assert.That(serializedOptionsAfterUse, Does.Not.Contain("__EMPTY__"));
        }
    }
    #endregion

    #region Streaming chat completion tests

    [RecordedTest]
    public async Task ChatCompletionBadKeyGivesHelpfulErrorStreaming()
    {
        string mockKey = "not-a-valid-key-and-should-still-be-sanitized";

        try
        {
            ChatClient chatClient = GetTestClient(keyCredential: new ApiKeyCredential(mockKey));
            var messages = new[] { new UserChatMessage("oops, this won't work with that key!") };

            AsyncCollectionResult<StreamingChatCompletionUpdate> result = chatClient.CompleteChatStreamingAsync(messages);
            await foreach (StreamingChatCompletionUpdate update in result)
            {
                Assert.Fail("No exception was thrown");
            }

            Assert.Fail("No exception was thrown");
        }
        catch (Exception thrownException)
        {
            Assert.That(thrownException, Is.InstanceOf<ClientResultException>());
            Assert.That(thrownException.Message, Does.Contain("invalid subscription key"));
            Assert.That(thrownException.Message, Does.Not.Contain(mockKey));
        }
    }

    [RecordedTest]
    public async Task ChatCompletionStreaming()
    {
        StringBuilder builder = new();
        bool foundPromptFilter = false;
        bool foundResponseFilter = false;
        ChatTokenUsage? usage = null;

        ChatClient chatClient = GetTestClient();

        ChatMessage[] messages =
        [
            new SystemChatMessage("You are a curmudgeon"),
            new UserChatMessage("Hello, assistant!")
        ];
        ChatCompletionOptions options = new()
        {
            MaxOutputTokenCount = 512,
            IncludeLogProbabilities = true,
            TopLogProbabilityCount = 1,
        };

        AsyncCollectionResult<StreamingChatCompletionUpdate> streamingResults = chatClient.CompleteChatStreamingAsync(messages, options);
        Assert.That(streamingResults, Is.Not.Null);

        await foreach (StreamingChatCompletionUpdate update in streamingResults)
        {
            ValidateUpdate(update, builder, ref foundPromptFilter, ref foundResponseFilter, ref usage);
        }

        string allText = builder.ToString();
        Assert.That(allText, Is.Not.Null.Or.Empty);

        Assert.That(usage, Is.Not.Null);

        Assert.That(foundPromptFilter, Is.True);
        Assert.That(foundResponseFilter, Is.True);
    }

    [RecordedTest]
    public async Task SearchExtensionWorksStreaming()
    {
        StringBuilder builder = new();
        bool foundPromptFilter = false;
        bool foundResponseFilter = false;
        ChatTokenUsage? usage = null;
        List<ChatMessageContext> contexts = new();

        var searchConfig = TestConfig.GetConfig("search")!;
        Assert.That(searchConfig, Is.Not.Null);
        string searchIndex = searchConfig.GetValueOrThrow<string>("index");

        AzureSearchChatDataSource source = new()
        {
            Endpoint = searchConfig.Endpoint,
            Authentication = DataSourceAuthentication.FromApiKey(searchConfig.Key),
            IndexName = searchIndex,
            AllowPartialResults = true,
            QueryType = DataSourceQueryType.Simple,
        };

        ChatCompletionOptions options = new();
        options.AddDataSource(source);

        ChatMessage[] messages = [new UserChatMessage("What does the term 'PR complete' mean?")];

        ChatClient client = GetTestClient();

        AsyncCollectionResult<StreamingChatCompletionUpdate> chatUpdates = client.CompleteChatStreamingAsync(messages, options);
        Assert.IsNotNull(chatUpdates);

        await foreach (StreamingChatCompletionUpdate update in chatUpdates)
        {
            ValidateUpdate(update, builder, ref foundPromptFilter, ref foundResponseFilter, ref usage);

            ChatMessageContext context = update.GetMessageContext();
            if (context != null)
            {
                contexts.Add(context);
            }
        }

        string allText = builder.ToString();
        Assert.That(allText, Is.Not.Null.Or.Empty);

        // Assert.That(usage, Is.Not.Null);

        // TODO FIXME: When using data sources, the service does not appear to return request nor response filtering information
        //Assert.That(foundPromptFilter, Is.True);
        //Assert.That(foundResponseFilter, Is.True);

        Assert.That(contexts, Has.Count.EqualTo(1));
        Assert.That(contexts[0].Intent, Is.Not.Null.Or.Empty);
        Assert.That(contexts[0].Citations, Has.Count.GreaterThan(0));
        Assert.That(contexts[0].Citations[0].Content, Is.Not.Null.Or.Empty);
        Assert.That(contexts[0].Citations[0].FilePath, Is.Not.Null.Or.Empty);
        Assert.That(contexts[0].Citations[0].ChunkId, Is.Not.Null.Or.Empty);
        Assert.That(contexts[0].Citations[0].Title, Is.Not.Null.Or.Empty);
    }

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task AsyncContentFilterWorksStreaming(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        // Precondition: the target deployment is configured with an async content filter that includes a
        // custom blocklist that will filter variations of the word 'banana.'

        ChatClient client = GetTestClient(
            TestConfig.GetConfig("chat_with_async_filter"),
            GetTestClientOptions(version));

        StringBuilder contentBuilder = new();

        List<RequestContentFilterResult> promptFilterResults = [];
        List<ResponseContentFilterResult> responseFilterResults = [];

        await foreach (StreamingChatCompletionUpdate chatUpdate
            in client.CompleteChatStreamingAsync(
            [
                "Hello, assistant! What popular kinds of fruit are yellow and grow on trees?"
            ]))
        {
            foreach (ChatMessageContentPart contentPart in chatUpdate.ContentUpdate)
            {
                contentBuilder.Append(contentPart.Text);
            }

            RequestContentFilterResult promptFilterResult = chatUpdate.GetRequestContentFilterResult();
            ResponseContentFilterResult responseFilterResult = chatUpdate.GetResponseContentFilterResult();

            if (promptFilterResult is not null)
            {
                promptFilterResults.Add(promptFilterResult);
            }
            if (responseFilterResult is not null)
            {
                responseFilterResults.Add(responseFilterResult);
            }
        }

        string fullContent = contentBuilder.ToString();
        Assert.That(fullContent.ToLowerInvariant(), Does.Contain("banana"));

        Assert.That(promptFilterResults, Has.Count.GreaterThan(0));
        Assert.That(responseFilterResults, Has.Count.GreaterThan(0));

        Assert.That(responseFilterResults.Any(filterResult
            => filterResult.CustomBlocklists?.BlocklistFilterStatuses?
                .TryGetValue("TestBlocklistNoBanana", out bool filtered) == true
                    && filtered));
    }

    #endregion

    [RecordedTest]
    public async Task ChatWithO1Works()
    {
        IConfiguration testConfig = TestConfig.GetConfig("chat_o1")!;

        ChatClient client = GetTestClient(testConfig);

        ChatCompletion completion = await client.CompleteChatAsync([ChatMessage.CreateUserMessage("Hello, world!")]);
        Assert.That(completion, Is.Not.Null);
    }

    [RecordedTest]
    public async Task DefaultHeadersAndQueryParametersWork()
    {
        IConfiguration testConfig = TestConfig.GetConfig("chat")!;
        Assert.That(testConfig, Is.Not.Null);

        PipelineRequestHeaders? observedHeaders = null;
        Uri? observedRequestUri = null;

        TestPipelinePolicy captureRequestDetailsPolicy = new(
            requestAction: (request) =>
            {
                observedHeaders = request.Headers;
                observedRequestUri = request.Uri;
            },
            responseAction: null);

        TestClientOptions options = new()
        {
            DefaultHeaders =
            {
                ["test_header_key"] = "test_header_value",
            },
            DefaultQueryParameters =
            {
                ["test_query_parameter_key"] = "test_query_parameter_value",
            },
            DisableClientWrapping = true,
        };
        options.AddPolicy(captureRequestDetailsPolicy, PipelinePosition.PerTry);

        ChatClient client = GetTestClient(testConfig, options);

        _ = await client.CompleteChatAsync("Hello, world!");

        Assert.That(observedHeaders?.TryGetValue("test_header_key", out string? observedHeaderValue) == true && observedHeaderValue == "test_header_value");
        Assert.That(observedRequestUri?.AbsoluteUri, Does.Contain("test_query_parameter_key=test_query_parameter_value"));
    }

#if NET
    [RecordedTest]
    public async Task PredictedOutputsWork()
    {
        ChatClient client = GetTestClient();

        foreach (ChatOutputPrediction predictionVariant in new List<ChatOutputPrediction>(
            [
                // Plain string
                ChatOutputPrediction.CreateStaticContentPrediction("""
                    {
                      "feature_name": "test_feature",
                      "enabled": true
                    }
                    """.ReplaceLineEndings("\n")),
                // One content part
                ChatOutputPrediction.CreateStaticContentPrediction(
                [
                    ChatMessageContentPart.CreateTextPart("""
                    {
                      "feature_name": "test_feature",
                      "enabled": true
                    }
                    """.ReplaceLineEndings("\n")),
                ]),
                // Several content parts
                ChatOutputPrediction.CreateStaticContentPrediction(
                    [
                        "{\n",
                        "  \"feature_name\": \"test_feature\",\n",
                        "  \"enabled\": true\n",
                        "}",
                    ]),
            ]))
        {
            ChatCompletionOptions options = new()
            {
                OutputPrediction = predictionVariant,
            };

            ChatMessage message = ChatMessage.CreateUserMessage("""
            Modify the following input to enable the feature. Only respond with the JSON and include no other text. Do not enclose in markdown backticks or any other additional annotations.

            {
              "feature_name": "test_feature",
              "enabled": false
            }
            """.ReplaceLineEndings("\n"));

            ChatCompletion completion = await client.CompleteChatAsync([message], options);

            Assert.That(completion.Usage.OutputTokenDetails.AcceptedPredictionTokenCount, Is.GreaterThan(0));
        }
    }
#endif

    #region Helper methods

    private TestClientOptions GetTestClientOptions(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        return version is null ? new TestClientOptions() : new TestClientOptions(version.Value);
    }

    private void ValidateUpdate(StreamingChatCompletionUpdate update, StringBuilder builder, ref bool foundPromptFilter, ref bool foundResponseFilter, ref ChatTokenUsage? usage)
    {
        if (update.CreatedAt == UNIX_EPOCH)
        {
            // This is the first message that usually contains the service's request content filtering
            RequestContentFilterResult promptFilter = update.GetRequestContentFilterResult();
            if (promptFilter?.SelfHarm != null)
            {
                Assert.That(promptFilter.SelfHarm.Filtered, Is.False);
                Assert.That(promptFilter.SelfHarm.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
                foundPromptFilter = true;
            }
        }
        else
        {
            Assert.That(update.CompletionId, Is.Not.Null.Or.Empty);
            Assert.That(update.CreatedAt, Is.GreaterThan(new DateTimeOffset(2024, 01, 01, 00, 00, 00, TimeSpan.Zero)));
            Assert.That(update.FinishReason, Is.Null.Or.EqualTo(ChatFinishReason.Stop));
            if (update.Usage != null)
            {
                Assert.That(usage, Is.Null);
                usage = update.Usage;
                Assert.That(update.Usage.InputTokenCount, Is.GreaterThanOrEqualTo(0));
                Assert.That(update.Usage.OutputTokenCount, Is.GreaterThanOrEqualTo(0));
                Assert.That(update.Usage.TotalTokenCount, Is.GreaterThanOrEqualTo(0));
            }

            Assert.That(update.Model, Is.Not.Null);
            Assert.That(update.Role, Is.Null.Or.EqualTo(ChatMessageRole.Assistant));
            Assert.That(update.ContentUpdate, Is.Not.Null);

            Assert.That(update.ContentTokenLogProbabilities, Is.Not.Null);
            foreach (var logProb in update.ContentTokenLogProbabilities)
            {
                Assert.That(logProb.TopLogProbabilities, Is.Not.Null);
                Assert.That(logProb.TopLogProbabilities.Count, Is.EqualTo(1));
            }

            foreach (ChatMessageContentPart part in update.ContentUpdate)
            {
                Assert.That(part.Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
                Assert.That(part.Text, Is.Not.Null);

                builder.Append(part.Text);
            }

            if (!foundResponseFilter)
            {
                ResponseContentFilterResult responseFilter = update.GetResponseContentFilterResult();
                if (responseFilter?.Violence != null)
                {
                    Assert.That(responseFilter.Violence.Filtered, Is.False);
                    Assert.That(responseFilter.Violence.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
                    foundResponseFilter = true;
                }
            }
        }

        #endregion
    }
}
