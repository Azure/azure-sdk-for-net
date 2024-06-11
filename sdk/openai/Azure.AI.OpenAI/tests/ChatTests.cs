// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Chat;
using Azure.AI.OpenAI.Tests.Utils.Pipeline;
using Azure.Core;
using Azure.Core.TestFramework;
using OpenAI.Chat;

namespace Azure.AI.OpenAI.Tests;

public partial class ChatTests : AoaiTestBase<ChatClient>
{
    private static readonly DateTimeOffset UNIX_EPOCH =
#if NETFRAMEWORK
            DateTimeOffset.Parse("1970-01-01T00:00:00.0000000+00:00");
#else
            DateTimeOffset.UnixEpoch;
#endif

    public ChatTests(bool isAsync) : base(isAsync)
    { }

    #region General tests

    [TestCase]
    [Category("Smoke")]
    public async Task DefaultUserAgentStringWorks()
    {
        using MockPipeline pipeline = new(req => new CapturedResponse()
        {
            Content = BinaryData.FromString("{}"),
            Headers = new Dictionary<string, IReadOnlyList<string>>()
            {
                ["Content-Type"] = ["application/json"],
            }
        });

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

        ChatClient client = InstrumentClient(topLevel.GetChatClient(model));

        await client.CompleteChatAsync([new UserChatMessage("Hello")]);

        Assert.That(pipeline.Requests, Is.Not.Empty);

        var request = pipeline.Requests[0];
        Assert.That(request.Method, Is.EqualTo(HttpMethod.Post));
        Assert.That(request.Uri.GetLeftPart(UriPartial.Authority), Is.EqualTo(endpoint.GetLeftPart(UriPartial.Authority)));
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
            AllowPartialResult = true,
            QueryType = DataSourceQueryType.Simple,
            OutputContextFlags = DataSourceOutputContextFlags.AllRetrievedDocuments | DataSourceOutputContextFlags.Citations,
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
        options.AddDataSource(new ElasticsearchChatDataSource()
        {
            Authentication = DataSourceAuthentication.FromAccessToken("foo-token"),
            Endpoint = new Uri("https://my-elasticsearch.com"),
            IndexName = "my-index-name",
            InScope = true,
        });

        IReadOnlyList<AzureChatDataSource> sourcesFromOptions = options.GetDataSources();
        Assert.That(sourcesFromOptions, Has.Count.EqualTo(1));
        Assert.That(sourcesFromOptions[0], Is.InstanceOf<ElasticsearchChatDataSource>());
        Assert.That((sourcesFromOptions[0] as ElasticsearchChatDataSource).IndexName, Is.EqualTo("my-index-name"));

        options.AddDataSource(new AzureCosmosDBChatDataSource()
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
        Assert.That(sourcesFromOptions[1], Is.InstanceOf<AzureCosmosDBChatDataSource>());
    }

    [RecordedTest]
    public async Task ChatCompletionBadKeyGivesHelpfulError()
    {
        Uri endpoint = TestConfig.GetEndpointFor<ChatClient>();
        string modelName = TestConfig.GetDeploymentNameFor<ChatClient>();
        string mockKey = "not-a-valid-key-and-should-still-be-sanitized";

        AzureOpenAIClient topLevel = new AzureOpenAIClient(endpoint, new ApiKeyCredential(mockKey));
        ChatClient chatClient = InstrumentClient(topLevel.GetChatClient(modelName));

        try
        {
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

    [Test]
    [Category("Smoke")]
    public async Task DefaultAzureCredentialWorks()
    {
        ChatClient chatClient = GetTestClient<TokenCredential>();
        ChatCompletion chatCompletion = await chatClient.CompleteChatAsync([ChatMessage.CreateUserMessage("Hello, world!")]);
        Assert.That(chatCompletion, Is.Not.Null);
        Assert.That(chatCompletion.Content, Is.Not.Null.Or.Empty);
        Assert.That(chatCompletion.Content[0].Text, Is.Not.Null.Or.Empty);
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
        Assert.That(response.Usage.InputTokens, Is.GreaterThan(10));
        Assert.That(response.Usage.OutputTokens, Is.GreaterThan(10));
        Assert.That(response.Usage.TotalTokens, Is.GreaterThan(20));
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
        Assert.That(content.Text, Does.Contain("Fahrenheit").Or.Contain("Celsius").Or.Contain("�F").Or.Contain("�C"));
    }

    [RecordedTest]
    public async Task ChatCompletionWithTextFormat()
    {
        ChatClient client = GetTestClient();
        ChatCompletionOptions options = new()
        {
            ResponseFormat = ChatResponseFormat.Text
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
        Console.WriteLine($"--- RESPONSE ---");
        ChatCompletion chatCompletion = chatCompletionResult;
        ContentFilterResultForPrompt promptFilterResult = chatCompletion.GetContentFilterResultForPrompt();
        Assert.That(promptFilterResult, Is.Not.Null);
        Assert.That(promptFilterResult.Sexual?.Filtered, Is.False);
        Assert.That(promptFilterResult.Sexual?.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
        ContentFilterResultForResponse responseFilterResult = chatCompletion.GetContentFilterResultForResponse();
        Assert.That(responseFilterResult, Is.Not.Null);
        Assert.That(responseFilterResult.Hate?.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
        Assert.That(responseFilterResult.ProtectedMaterialCode, Is.Null);
    }

    [RecordedTest]
    public async Task SearchExtensionWorks()
    {
        var searchConfig = TestConfig.GetConfig("search", "index");
        string searchIndex = searchConfig.GetValueOrDefault<string>("index");

        AzureSearchChatDataSource source = new()
        {
            Endpoint = searchConfig.Endpoint,
            Authentication = DataSourceAuthentication.FromApiKey(searchConfig.Key),
            IndexName = searchIndex,
            AllowPartialResult = true,
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

        AzureChatMessageContext context = chatCompletion.GetAzureMessageContext();
        Assert.IsNotNull(context);
        Assert.That(context.Intent, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations, Has.Count.GreaterThan(0));
        Assert.That(context.Citations[0].Filepath, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0].Content, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0].ChunkId, Is.Not.Null.Or.Empty);
        Assert.That(context.Citations[0].Title, Is.Not.Null.Or.Empty);
    }

    #endregion

    #region Streaming chat completion tests

    [RecordedTest]
    public async Task ChatCompletionBadKeyGivesHelpfulErrorStreaming()
    {
        // TODO FIXME:
        // Sadly the CompleteChatStreamingAsync doesn't return a Task and the test framework code relies on this delta to
        // enable automatic async and sync version testing. For now, disable instrumenting the client

        Uri endpoint = TestConfig.GetEndpointFor<ChatClient>();
        string modelName = TestConfig.GetDeploymentNameFor<ChatClient>();
        string mockKey = "not-a-valid-key-and-should-still-be-sanitized";

        AzureOpenAIClient topLevel = new AzureOpenAIClient(endpoint, new ApiKeyCredential(mockKey));
        // TODO FIXME This should be wrapped with in an InstrumentClient call
        ChatClient chatClient = topLevel.GetChatClient(modelName);
        var messages = new[] { new UserChatMessage("oops, this won't work with that key!") };

        try
        {
            AsyncResultCollection<StreamingChatCompletionUpdate> result = SyncOrAsync(chatClient,
                c => c.CompleteChatStreaming(messages),
                c => c.CompleteChatStreamingAsync(messages));

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

        ChatClient chatClient = GetTestClient();

        ChatMessage[] messages =
        [
            new SystemChatMessage("You are a curmudgeon"),
            new UserChatMessage("Hello, assitant!")
        ];
        ChatCompletionOptions options = new()
        {
            MaxTokens = 512,
            IncludeLogProbabilities = true,
            TopLogProbabilityCount = 1,
        };

        AsyncResultCollection<StreamingChatCompletionUpdate> streamingResults = SyncOrAsync(chatClient,
                c => c.CompleteChatStreaming(messages, options),
                c => c.CompleteChatStreamingAsync(messages, options));
        Assert.That(streamingResults, Is.Not.Null);

        await foreach (StreamingChatCompletionUpdate update in streamingResults)
        {
            ValidateUpdate(update, builder, ref foundPromptFilter, ref foundResponseFilter);
        }

        string allText = builder.ToString();
        Assert.That(allText, Is.Not.Null.Or.Empty);

        Assert.That(foundPromptFilter, Is.True);
        Assert.That(foundResponseFilter, Is.True);
    }

    [RecordedTest]
    public async Task SearchExtensionWorksStreaming()
    {
        StringBuilder builder = new();
        bool foundPromptFilter = false;
        bool foundResponseFilter = false;
        List<AzureChatMessageContext> contexts = new();

        var searchConfig = TestConfig.GetConfig("search", "index");
        string searchIndex = searchConfig.GetValueOrDefault<string>("index");

        AzureSearchChatDataSource source = new()
        {
            Endpoint = searchConfig.Endpoint,
            Authentication = DataSourceAuthentication.FromApiKey(searchConfig.Key),
            IndexName = searchIndex,
            AllowPartialResult = true,
            QueryType = DataSourceQueryType.Simple,
        };

        ChatCompletionOptions options = new();
        options.AddDataSource(source);

        ChatMessage[] messages = [new UserChatMessage("What does the term 'PR complete' mean?")];

        ChatClient client = GetTestClient();

        AsyncResultCollection<StreamingChatCompletionUpdate> chatUpdates = SyncOrAsync(client,
            c => c.CompleteChatStreaming(messages, options),
            c => c.CompleteChatStreamingAsync(messages, options));
        Assert.IsNotNull(chatUpdates);

        await foreach (StreamingChatCompletionUpdate update in chatUpdates)
        {
            ValidateUpdate(update, builder, ref foundPromptFilter, ref foundResponseFilter);

            AzureChatMessageContext context = update.GetAzureMessageContext();
            if (context != null)
            {
                contexts.Add(context);
            }
        }

        string allText = builder.ToString();
        Assert.That(allText, Is.Not.Null.Or.Empty);

        // TODO FIXME: When using data sources, the service does not appear to return request nor response filtering information
        //Assert.That(foundPromptFilter, Is.True);
        //Assert.That(foundResponseFilter, Is.True);

        Assert.That(contexts, Has.Count.EqualTo(1));
        Assert.That(contexts[0].Intent, Is.Not.Null.Or.Empty);
        Assert.That(contexts[0].Citations, Has.Count.GreaterThan(0));
        Assert.That(contexts[0].Citations[0].Content, Is.Not.Null.Or.Empty);
        Assert.That(contexts[0].Citations[0].Filepath, Is.Not.Null.Or.Empty);
        Assert.That(contexts[0].Citations[0].ChunkId, Is.Not.Null.Or.Empty);
        Assert.That(contexts[0].Citations[0].Title, Is.Not.Null.Or.Empty);
    }

    #endregion

    #region Helper methods

    private void ValidateUpdate(StreamingChatCompletionUpdate update, StringBuilder builder, ref bool foundPromptFilter, ref bool foundResponseFilter)
    {
        if (update.CreatedAt == UNIX_EPOCH)
        {
            // This is the first message that usually contains the service's request content filtering
            ContentFilterResultForPrompt promptFilter = update.GetContentFilterResultForPrompt();
            if (promptFilter?.SelfHarm != null)
            {
                Assert.That(promptFilter.SelfHarm.Filtered, Is.False);
                Assert.That(promptFilter.SelfHarm.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
                foundPromptFilter = true;
            }
        }
        else
        {
            Assert.That(update.Id, Is.Not.Null.Or.Empty);
            Assert.That(update.CreatedAt, Is.GreaterThan(new DateTimeOffset(2024, 01, 01, 00, 00, 00, TimeSpan.Zero)));
            Assert.That(update.FinishReason, Is.Null.Or.EqualTo(ChatFinishReason.Stop));
            if (update.Usage != null)
            {
                Assert.That(update.Usage.InputTokens, Is.GreaterThanOrEqualTo(0));
                Assert.That(update.Usage.OutputTokens, Is.GreaterThanOrEqualTo(0));
                Assert.That(update.Usage.TotalTokens, Is.GreaterThanOrEqualTo(0));
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
                ContentFilterResultForResponse responseFilter = update.GetContentFilterResultForResponse();
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
