// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Inference;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Microsoft.Extensions.AI;

public class AzureAIInferenceChatClientTests
{
    [RecordedTest]
    public void AsIChatClient_InvalidArgs_Throws()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => ((ChatCompletionsClient)null!).AsIChatClient("model"));
        Assert.That(ex!.ParamName, Is.EqualTo("chatCompletionsClient"));

        ChatCompletionsClient client = new(new("http://somewhere"), new AzureKeyCredential("key"));
        var ex2 = Assert.Throws<ArgumentException>(() => client.AsIChatClient("   "));
        Assert.That(ex2!.ParamName, Is.EqualTo("defaultModelId"));
    }

    [RecordedTest]
    public void NullModel_Throws()
    {
        ChatCompletionsClient client = new(new("http://localhost/some/endpoint"), new AzureKeyCredential("key"));
        IChatClient chatClient = client.AsIChatClient(modelId: null);

        Assert.ThrowsAsync<InvalidOperationException>(() => chatClient.GetResponseAsync("hello"));
        Assert.ThrowsAsync<InvalidOperationException>(() => chatClient.GetStreamingResponseAsync("hello").GetAsyncEnumerator().MoveNextAsync().AsTask());

        Assert.ThrowsAsync<InvalidOperationException>(() => chatClient.GetResponseAsync("hello", new ChatOptions { ModelId = null }));
        Assert.ThrowsAsync<InvalidOperationException>(() => chatClient.GetStreamingResponseAsync("hello", new ChatOptions { ModelId = null }).GetAsyncEnumerator().MoveNextAsync().AsTask());
    }

    [RecordedTest]
    public void AsIChatClient_ProducesExpectedMetadata()
    {
        Uri endpoint = new("http://localhost/some/endpoint");
        string model = "amazingModel";

        ChatCompletionsClient client = new(endpoint, new AzureKeyCredential("key"));

        IChatClient chatClient = client.AsIChatClient(model);
        var metadata = chatClient.GetService<ChatClientMetadata>();
        Assert.That(metadata?.ProviderName, Is.EqualTo("az.ai.inference"));
        Assert.That(metadata?.ProviderUri, Is.EqualTo(endpoint));
        Assert.That(metadata?.DefaultModelId, Is.EqualTo(model));
    }

    [RecordedTest]
    public void GetService_SuccessfullyReturnsUnderlyingClient()
    {
        ChatCompletionsClient client = new(new("http://localhost"), new AzureKeyCredential("key"));
        IChatClient chatClient = client.AsIChatClient("model");

        Assert.That(chatClient.GetService<IChatClient>(), Is.SameAs(chatClient));
        Assert.That(chatClient.GetService<ChatCompletionsClient>(), Is.SameAs(client));

        using IChatClient pipeline = chatClient
            .AsBuilder()
            .UseFunctionInvocation()
            .UseOpenTelemetry()
            .UseDistributedCache(new MemoryDistributedCache(Options.Options.Create(new MemoryDistributedCacheOptions())))
            .Build();

        Assert.That(pipeline.GetService<FunctionInvokingChatClient>(), Is.Not.Null);
        Assert.That(pipeline.GetService<DistributedCachingChatClient>(), Is.Not.Null);
        Assert.That(pipeline.GetService<CachingChatClient>(), Is.Not.Null);
        Assert.That(pipeline.GetService<OpenTelemetryChatClient>(), Is.Not.Null);
        Assert.That(pipeline.GetService<object>(), Is.Not.Null);

        Assert.That(pipeline.GetService<ChatCompletionsClient>(), Is.SameAs(client));
        Assert.That(pipeline.GetService<IChatClient>(), Is.InstanceOf<FunctionInvokingChatClient>());

        Assert.That(pipeline.GetService<ChatCompletionsClient>("key"), Is.Null);
        Assert.That(pipeline.GetService<string>("key"), Is.Null);
    }

    private const string BasicInputNonStreaming = """
        {
            "messages": [{"role":"user", "content":"hello"}],
            "max_tokens":10,
            "temperature":0.5,
            "model":"gpt-4o-mini"
        }
        """;

    private const string BasicOutputNonStreaming = """
        {
            "id": "chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI",
            "object": "chat.completion",
            "created": 1727888631,
            "model": "gpt-4o-mini-2024-07-18",
            "choices": [
            {
                "index": 0,
                "message": {
                "role": "assistant",
                "content": "Hello! How can I assist you today?",
                "refusal": null
                },
                "logprobs": null,
                "finish_reason": "stop"
            }
            ],
            "usage": {
            "prompt_tokens": 8,
            "completion_tokens": 9,
            "total_tokens": 17,
            "prompt_tokens_details": {
                "cached_tokens": 0
            },
            "completion_tokens_details": {
                "reasoning_tokens": 0
            }
            },
            "system_fingerprint": "fp_f85bea6784"
        }
        """;

    [RecordedTest]
    [TestCase(false)]
    [TestCase(true)]
    public async Task BasicRequestResponse_NonStreaming(bool multiContent)
    {
        using VerbatimHttpHandler handler = new(BasicInputNonStreaming, BasicOutputNonStreaming);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        List<ChatMessage> messages = multiContent ?
            [new ChatMessage(ChatRole.User, "hello".Select(c => (AIContent)new TextContent(c.ToString())).ToList())] :
            [new ChatMessage(ChatRole.User, "hello")];

        var response = await client.GetResponseAsync(messages, new()
        {
            MaxOutputTokens = 10,
            Temperature = 0.5f,
        });
        Assert.That(response, Is.Not.Null);

        Assert.That(response.ResponseId, Is.EqualTo("chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI"));
        Assert.That(response.Text, Is.EqualTo("Hello! How can I assist you today?"));
        Assert.That(response.Messages.Single().Contents, Has.Count.EqualTo(1));
        Assert.That(response.Messages.Single().Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(response.Messages.Single().MessageId, Is.EqualTo("chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI"));
        Assert.That(response.ModelId, Is.EqualTo("gpt-4o-mini-2024-07-18"));
        Assert.That(response.CreatedAt, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(1_727_888_631)));
        Assert.That(response.FinishReason, Is.EqualTo(ChatFinishReason.Stop));

        Assert.That(response.Usage, Is.Not.Null);
        Assert.That(response.Usage!.InputTokenCount, Is.EqualTo(8));
        Assert.That(response.Usage.OutputTokenCount, Is.EqualTo(9));
        Assert.That(response.Usage.TotalTokenCount, Is.EqualTo(17));
    }

    private const string BasicInputStreaming = """
        {
            "messages": [{"role":"user", "content":"hello"}],
            "max_tokens":20,
            "temperature":0.5,
            "stream":true,
            "model":"gpt-4o-mini"}
        """;

    private const string BasicOutputStreaming = """
        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"role":"assistant","content":"","refusal":null},"logprobs":null,"finish_reason":null}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"content":"Hello"},"logprobs":null,"finish_reason":null}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"content":"!"},"logprobs":null,"finish_reason":null}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"content":" How"},"logprobs":null,"finish_reason":null}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"content":" can"},"logprobs":null,"finish_reason":null}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"content":" I"},"logprobs":null,"finish_reason":null}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"content":" assist"},"logprobs":null,"finish_reason":null}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"content":" you"},"logprobs":null,"finish_reason":null}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"content":" today"},"logprobs":null,"finish_reason":null}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"content":"?"},"logprobs":null,"finish_reason":null}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{},"logprobs":null,"finish_reason":"stop"}],"usage":null}

        data: {"id":"chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK","object":"chat.completion.chunk","created":1727889370,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[],"usage":{"prompt_tokens":8,"completion_tokens":9,"total_tokens":17,"prompt_tokens_details":{"cached_tokens":0},"completion_tokens_details":{"reasoning_tokens":0}}}

        data: [DONE]

        """;

    [RecordedTest]
    [TestCase(false)]
    [TestCase(true)]
    public async Task BasicRequestResponse_Streaming(bool multiContent)
    {
        using VerbatimHttpHandler handler = new(BasicInputStreaming, BasicOutputStreaming);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        List<ChatMessage> messages = multiContent ?
            [new ChatMessage(ChatRole.User, "hello".Select(c => (AIContent)new TextContent(c.ToString())).ToList())] :
            [new ChatMessage(ChatRole.User, "hello")];

        List<ChatResponseUpdate> updates = [];
        await foreach (var update in client.GetStreamingResponseAsync(messages, new()
        {
            MaxOutputTokens = 20,
            Temperature = 0.5f,
        }))
        {
            updates.Add(update);
        }

        Assert.That(string.Concat(updates.Select(u => u.Text)), Is.EqualTo("Hello! How can I assist you today?"));

        var createdAt = DateTimeOffset.FromUnixTimeSeconds(1_727_889_370);
        Assert.That(updates.Count, Is.EqualTo(12));
        for (int i = 0; i < updates.Count; i++)
        {
            Assert.That(updates[i].ResponseId, Is.EqualTo("chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK"));
            Assert.That(updates[i].MessageId, Is.EqualTo("chatcmpl-ADxFKtX6xIwdWRN42QvBj2u1RZpCK"));
            Assert.That(updates[i].CreatedAt, Is.EqualTo(createdAt));
            Assert.That(updates[i].ModelId, Is.EqualTo("gpt-4o-mini-2024-07-18"));
            Assert.That(updates[i].Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(updates[i].Contents.Count, Is.EqualTo(i is < 10 or 11 ? 1 : 0));
            Assert.That(updates[i].FinishReason, Is.EqualTo(i < 10 ? null : ChatFinishReason.Stop));
        }
    }

    [RecordedTest]
    public async Task IChatClient_WithNullModel_ChatOptions_WithNotNullModel_NonStreaming()
    {
        using VerbatimHttpHandler handler = new(BasicInputNonStreaming, BasicOutputNonStreaming);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, modelId: null!);

        var response = await client.GetResponseAsync("hello", new ChatOptions
        {
            ModelId = "gpt-4o-mini",
            MaxOutputTokens = 10,
            Temperature = 0.5f,
        });
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Text, Is.EqualTo("Hello! How can I assist you today?"));
    }

    [RecordedTest]
    public async Task IChatClient_WithNullModel_ChatOptions_WithNotNullModel_Streaming()
    {
        using VerbatimHttpHandler handler = new(BasicInputStreaming, BasicOutputStreaming);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, modelId: null!);

        string responseText = string.Empty;
        await foreach (var update in client.GetStreamingResponseAsync("hello", new ChatOptions
        {
            ModelId = "gpt-4o-mini",
            MaxOutputTokens = 20,
            Temperature = 0.5f,
        }))
        {
            responseText += update.Text;
        }

        Assert.That(responseText, Is.EqualTo("Hello! How can I assist you today?"));
    }

    [RecordedTest]
    public async Task ChatOptions_DoNotOverwrite_NotNullPropertiesInRawRepresentation_NonStreaming()
    {
        const string Input = """
            {
              "messages":[{"role":"user","content":"hello"}],
              "model":"gpt-4o-mini",
              "frequency_penalty":0.75,
              "max_tokens":10,
              "top_p":0.5,
              "presence_penalty":0.5,
              "temperature":0.5,
              "seed":42,
              "stop":["hello","world"],
              "response_format":{"type":"text"},
              "tools":[
                  {"type":"function","function":{"name":"GetPersonAge","description":"Gets the age of the specified person.","parameters":{"type":"object","required":["personName"],"properties":{"personName":{"description":"The person whose age is being requested","type":"string"}}}}},
                  {"type":"function","function":{"name":"GetPersonAge","description":"Gets the age of the specified person.","parameters":{"type": "object","required": ["personName"],"properties": {"personName": {"description": "The person whose age is being requested","type": "string"}}}}}
                ],
              "tool_choice":"auto",
              "additional_property_from_raw_representation":42,
              "additional_property_from_MEAI_options":42
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI",
              "object": "chat.completion",
              "choices": [
                {
                  "message": {
                    "role": "assistant",
                    "content": "Hello! How can I assist you today?"
                  }
                }
              ]
            }
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, modelId: null!);
        AIFunction tool = AIFunctionFactory.Create(([System.ComponentModel.Description("The person whose age is being requested")] string personName) => 42, "GetPersonAge", "Gets the age of the specified person.");

        ChatOptions chatOptions = new ChatOptions
        {
            RawRepresentationFactory = (c) =>
            {
                ChatCompletionsOptions azureAIOptions = new()
                {
                    Model = "gpt-4o-mini",
                    FrequencyPenalty = 0.75f,
                    MaxTokens = 10,
                    NucleusSamplingFactor = 0.5f,
                    PresencePenalty = 0.5f,
                    Temperature = 0.5f,
                    Seed = 42,
                    ToolChoice = ChatCompletionsToolChoice.Auto,
                    ResponseFormat = ChatCompletionsResponseFormat.CreateTextFormat()
                };
                azureAIOptions.StopSequences.Add("hello");
                azureAIOptions.Tools.Add(ToAzureAIChatTool(tool));
                azureAIOptions.AdditionalProperties["additional_property_from_raw_representation"] = new BinaryData("42");
                return azureAIOptions;
            },
            ModelId = null,
            FrequencyPenalty = 0.125f,
            MaxOutputTokens = 1,
            TopP = 0.125f,
            PresencePenalty = 0.125f,
            Temperature = 0.125f,
            Seed = 1,
            StopSequences = ["world"],
            Tools = [tool],
            ToolMode = ChatToolMode.None,
            ResponseFormat = ChatResponseFormat.Json,
            AdditionalProperties = new AdditionalPropertiesDictionary
            {
                ["additional_property_from_MEAI_options"] = 42
            }
        };

        var response = await client.GetResponseAsync("hello", chatOptions);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Text, Is.EqualTo("Hello! How can I assist you today?"));
    }

    [RecordedTest]
    public async Task ChatOptions_DoNotOverwrite_NotNullPropertiesInRawRepresentation_Streaming()
    {
        const string Input = """
            {
              "messages":[{"role":"user","content":"hello"}],
              "model":"gpt-4o-mini",
              "frequency_penalty":0.75,
              "max_tokens":10,
              "top_p":0.5,
              "presence_penalty":0.5,
              "temperature":0.5,
              "seed":42,
              "stop":["hello","world"],
              "response_format":{"type":"text"},
              "tools":[
                  {"type":"function","function":{"name":"GetPersonAge","description":"Gets the age of the specified person.","parameters":{"type":"object","required":["personName"],"properties":{"personName":{"description":"The person whose age is being requested","type":"string"}}}}},
                  {"type":"function","function":{"name":"GetPersonAge","description":"Gets the age of the specified person.","parameters":{"type": "object","required": ["personName"],"properties": {"personName": {"description": "The person whose age is being requested","type": "string"}}}}}
                ],
              "tool_choice":"auto",
              "additional_property_from_raw_representation":42,
              "additional_property_from_MEAI_options":42,
              "stream":true
            }
            """;

        const string Output = """
            data: {"id":"chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI","object":"chat.completion.chunk","choices":[{"delta":{"role":"assistant","content":"Hello! "}}]}
            
            data: {"id":"chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI","object":"chat.completion.chunk","choices":[{"delta":{"content":"How can I assist you today?"}}]}
            
            data: {"id":"chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI","object":"chat.completion.chunk","choices":[{"delta":{},"finish_reason":"stop"}]}
            
            data: [DONE]
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, modelId: null!);
        AIFunction tool = AIFunctionFactory.Create(([System.ComponentModel.Description("The person whose age is being requested")] string personName) => 42, "GetPersonAge", "Gets the age of the specified person.");

        ChatOptions chatOptions = new ChatOptions
        {
            RawRepresentationFactory = (c) =>
            {
                ChatCompletionsOptions azureAIOptions = new()
                {
                    Model = "gpt-4o-mini",
                    FrequencyPenalty = 0.75f,
                    MaxTokens = 10,
                    NucleusSamplingFactor = 0.5f,
                    PresencePenalty = 0.5f,
                    Temperature = 0.5f,
                    Seed = 42,
                    ToolChoice = ChatCompletionsToolChoice.Auto,
                    ResponseFormat = ChatCompletionsResponseFormat.CreateTextFormat()
                };
                azureAIOptions.StopSequences.Add("hello");
                azureAIOptions.Tools.Add(ToAzureAIChatTool(tool));
                azureAIOptions.AdditionalProperties["additional_property_from_raw_representation"] = new BinaryData("42");
                return azureAIOptions;
            },
            ModelId = null,
            FrequencyPenalty = 0.125f,
            MaxOutputTokens = 1,
            TopP = 0.125f,
            PresencePenalty = 0.125f,
            Temperature = 0.125f,
            Seed = 1,
            StopSequences = ["world"],
            Tools = [tool],
            ToolMode = ChatToolMode.None,
            ResponseFormat = ChatResponseFormat.Json,
            AdditionalProperties = new AdditionalPropertiesDictionary
            {
                ["additional_property_from_MEAI_options"] = 42
            }
        };

        string responseText = string.Empty;
        await foreach (var update in client.GetStreamingResponseAsync("hello", chatOptions))
        {
            responseText += update.Text;
        }

        Assert.That(responseText, Is.EqualTo("Hello! How can I assist you today?"));
    }

    [RecordedTest]
    public async Task ChatOptions_Overwrite_NullPropertiesInRawRepresentation_NonStreaming()
    {
        const string Input = """
            {
              "messages":[{"role":"user","content":"hello"}],
              "model":"gpt-4o-mini",
              "frequency_penalty":0.125,
              "max_tokens":1,
              "top_p":0.125,
              "presence_penalty":0.125,
              "temperature":0.125,
              "seed":1,
              "stop":["world"],
              "response_format":{"type":"json_object"},
              "tools":[
                  {"type":"function","function":{"name":"GetPersonAge","description":"Gets the age of the specified person.","parameters":{"type":"object","required":["personName"],"properties":{"personName":{"description":"The person whose age is being requested","type":"string"}}}}}
                ],
              "tool_choice":"none"
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI",
              "object": "chat.completion",
              "choices": [
                {
                  "message": {
                    "role": "assistant",
                    "content": "Hello! How can I assist you today?"
                  }
                }
              ]
            }
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, modelId: null!);
        AIFunction tool = AIFunctionFactory.Create(([System.ComponentModel.Description("The person whose age is being requested")] string personName) => 42, "GetPersonAge", "Gets the age of the specified person.");

        ChatOptions chatOptions = new ChatOptions
        {
            RawRepresentationFactory = (c) =>
            {
                ChatCompletionsOptions azureAIOptions = new();
                Assert.That(azureAIOptions.Messages, Is.Empty);
                Assert.That(azureAIOptions.Model, Is.Null);
                Assert.That(azureAIOptions.FrequencyPenalty, Is.Null);
                Assert.That(azureAIOptions.MaxTokens, Is.Null);
                Assert.That(azureAIOptions.NucleusSamplingFactor, Is.Null);
                Assert.That(azureAIOptions.PresencePenalty, Is.Null);
                Assert.That(azureAIOptions.Temperature, Is.Null);
                Assert.That(azureAIOptions.Seed, Is.Null);
                Assert.That(azureAIOptions.StopSequences, Is.Empty);
                Assert.That(azureAIOptions.Tools, Is.Empty);
                Assert.That(azureAIOptions.ToolChoice, Is.Null);
                Assert.That(azureAIOptions.ResponseFormat, Is.Null);
                return azureAIOptions;
            },
            ModelId = "gpt-4o-mini",
            FrequencyPenalty = 0.125f,
            MaxOutputTokens = 1,
            TopP = 0.125f,
            PresencePenalty = 0.125f,
            Temperature = 0.125f,
            Seed = 1,
            StopSequences = ["world"],
            Tools = [tool],
            ToolMode = ChatToolMode.None,
            ResponseFormat = ChatResponseFormat.Json
        };

        var response = await client.GetResponseAsync("hello", chatOptions);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Text, Is.EqualTo("Hello! How can I assist you today?"));
    }

    [RecordedTest]
    public async Task ChatOptions_Overwrite_NullPropertiesInRawRepresentation_Streaming()
    {
        const string Input = """
            {
              "messages":[{"role":"user","content":"hello"}],
              "model":"gpt-4o-mini",
              "frequency_penalty":0.125,
              "max_tokens":1,
              "top_p":0.125,
              "presence_penalty":0.125,
              "temperature":0.125,
              "seed":1,
              "stop":["world"],
              "response_format":{"type":"json_object"},
              "tools":[
                  {"type":"function","function":{"name":"GetPersonAge","description":"Gets the age of the specified person.","parameters":{"type":"object","required":["personName"],"properties":{"personName":{"description":"The person whose age is being requested","type":"string"}}}}}
                ],
              "tool_choice":"none",
              "stream":true
            }
            """;

        const string Output = """
            data: {"id":"chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI","object":"chat.completion.chunk","choices":[{"delta":{"role":"assistant","content":"Hello! "}}]}
            
            data: {"id":"chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI","object":"chat.completion.chunk","choices":[{"delta":{"content":"How can I assist you today?"}}]}
            
            data: {"id":"chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI","object":"chat.completion.chunk","choices":[{"delta":{},"finish_reason":"stop"}]}
            
            data: [DONE]
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, modelId: null!);
        AIFunction tool = AIFunctionFactory.Create(([System.ComponentModel.Description("The person whose age is being requested")] string personName) => 42, "GetPersonAge", "Gets the age of the specified person.");

        ChatOptions chatOptions = new ChatOptions
        {
            RawRepresentationFactory = (c) =>
            {
                ChatCompletionsOptions azureAIOptions = new();
                Assert.That(azureAIOptions.Messages, Is.Empty);
                Assert.That(azureAIOptions.Model, Is.Null);
                Assert.That(azureAIOptions.FrequencyPenalty, Is.Null);
                Assert.That(azureAIOptions.MaxTokens, Is.Null);
                Assert.That(azureAIOptions.NucleusSamplingFactor, Is.Null);
                Assert.That(azureAIOptions.PresencePenalty, Is.Null);
                Assert.That(azureAIOptions.Temperature, Is.Null);
                Assert.That(azureAIOptions.Seed, Is.Null);
                Assert.That(azureAIOptions.StopSequences, Is.Empty);
                Assert.That(azureAIOptions.Tools, Is.Empty);
                Assert.That(azureAIOptions.ToolChoice, Is.Null);
                Assert.That(azureAIOptions.ResponseFormat, Is.Null);
                return azureAIOptions;
            },
            ModelId = "gpt-4o-mini",
            FrequencyPenalty = 0.125f,
            MaxOutputTokens = 1,
            TopP = 0.125f,
            PresencePenalty = 0.125f,
            Temperature = 0.125f,
            Seed = 1,
            StopSequences = ["world"],
            Tools = [tool],
            ToolMode = ChatToolMode.None,
            ResponseFormat = ChatResponseFormat.Json
        };

        string responseText = string.Empty;
        await foreach (var update in client.GetStreamingResponseAsync("hello", chatOptions))
        {
            responseText += update.Text;
        }

        Assert.That(responseText, Is.EqualTo("Hello! How can I assist you today?"));
    }

    /// <summary>Converts an Extensions function to an AzureAI chat tool.</summary>
    private static ChatCompletionsToolDefinition ToAzureAIChatTool(AIFunction aiFunction)
    {
        // Map to an intermediate model so that redundant properties are skipped.
        var tool = JsonSerializer.Deserialize<AzureAIChatToolJson>(aiFunction.JsonSchema)!;
        var functionParameters = BinaryData.FromBytes(JsonSerializer.SerializeToUtf8Bytes(tool));
        return new(new FunctionDefinition(aiFunction.Name)
        {
            Description = aiFunction.Description,
            Parameters = functionParameters,
        });
    }

    /// <summary>Used to create the JSON payload for an AzureAI chat tool description.</summary>
    private sealed class AzureAIChatToolJson
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "object";

        [JsonPropertyName("required")]
        public List<string> Required { get; set; } = [];

        [JsonPropertyName("properties")]
        public Dictionary<string, JsonElement> Properties { get; set; } = [];
    }

    [RecordedTest]
    public async Task AdditionalOptions_NonStreaming()
    {
        const string Input = """
            {
                "messages":[{"role":"user", "content":"hello"}],
                "max_tokens":10,
                "temperature":0.5,
                "top_p":0.5,
                "stop":["yes","no"],
                "presence_penalty":0.5,
                "frequency_penalty":0.75,
                "seed":42,
                "model":"gpt-4o-mini",
                "top_k":40,
                "something_else":"value1",
                "and_something_further":123
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI",
              "object": "chat.completion",
              "choices": [
                {
                  "message": {
                    "role": "assistant",
                    "content": "Hello! How can I assist you today?"
                  }
                }
              ]
            }
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        Assert.That(await client.GetResponseAsync("hello", new()
        {
            MaxOutputTokens = 10,
            Temperature = 0.5f,
            TopP = 0.5f,
            TopK = 40,
            FrequencyPenalty = 0.75f,
            PresencePenalty = 0.5f,
            Seed = 42,
            StopSequences = ["yes", "no"],
            RawRepresentationFactory = (c) =>
            {
                ChatCompletionsOptions azureAIOptions = new();
                azureAIOptions.AdditionalProperties.Add("something_else", new BinaryData(JsonSerializer.SerializeToUtf8Bytes("value1", typeof(object))));
                azureAIOptions.AdditionalProperties.Add("and_something_further", new BinaryData(JsonSerializer.SerializeToUtf8Bytes(123, typeof(object))));
                return azureAIOptions;
            },
        }), Is.Not.Null);
    }

    [RecordedTest]
    public async Task TopK_DoNotOverwrite_NonStreaming()
    {
        const string Input = """
            {
                "messages":[{"role":"user", "content":"hello"}],
                "max_tokens":10,
                "temperature":0.5,
                "top_p":0.5,
                "stop":["yes","no"],
                "presence_penalty":0.5,
                "frequency_penalty":0.75,
                "seed":42,
                "model":"gpt-4o-mini",
                "top_k":40,
                "something_else":"value1",
                "and_something_further":123
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI",
              "object": "chat.completion",
              "choices": [
                {
                  "message": {
                    "role": "assistant",
                    "content": "Hello! How can I assist you today?"
                  }
                }
              ]
            }
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        Assert.That(await client.GetResponseAsync("hello", new()
        {
            MaxOutputTokens = 10,
            Temperature = 0.5f,
            TopP = 0.5f,
            TopK = 20, // will be ignored because the raw representation already specifies it.
            FrequencyPenalty = 0.75f,
            PresencePenalty = 0.5f,
            Seed = 42,
            StopSequences = ["yes", "no"],
            RawRepresentationFactory = (c) =>
            {
                ChatCompletionsOptions azureAIOptions = new();
                azureAIOptions.AdditionalProperties.Add("top_k", new BinaryData(JsonSerializer.SerializeToUtf8Bytes(40, typeof(object))));
                azureAIOptions.AdditionalProperties.Add("something_else", new BinaryData(JsonSerializer.SerializeToUtf8Bytes("value1", typeof(object))));
                azureAIOptions.AdditionalProperties.Add("and_something_further", new BinaryData(JsonSerializer.SerializeToUtf8Bytes(123, typeof(object))));
                return azureAIOptions;
            },
        }), Is.Not.Null);
    }

    [RecordedTest]
    public async Task ResponseFormat_Text_NonStreaming()
    {
        const string Input = """
            {
                "messages":[{"role":"user", "content":"hello"}],
                "model":"gpt-4o-mini",
                "response_format":{"type":"text"}
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI",
              "object": "chat.completion",
              "choices": [
                {
                  "message": {
                    "role": "assistant",
                    "content": "Hello! How can I assist you today?"
                  }
                }
              ]
            }
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        Assert.That(await client.GetResponseAsync("hello", new()
        {
            ResponseFormat = ChatResponseFormat.Text,
        }), Is.Not.Null);
    }

    [RecordedTest]
    public async Task ResponseFormat_Json_NonStreaming()
    {
        const string Input = """
            {
                "messages":[{"role":"user", "content":"hello"}],
                "model":"gpt-4o-mini",
                "response_format":{"type":"json_object"}
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI",
              "object": "chat.completion",
              "choices": [
                {
                  "message": {
                    "role": "assistant",
                    "content": "Hello! How can I assist you today?"
                  }
                }
              ]
            }
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        Assert.That(await client.GetResponseAsync("hello", new()
        {
            ResponseFormat = ChatResponseFormat.Json,
        }), Is.Not.Null);
    }

    [RecordedTest]
    public async Task ResponseFormat_JsonSchema_NonStreaming()
    {
        const string Input = """
            {
                "messages":[{"role":"user", "content":"hello"}],
                "model":"gpt-4o-mini",
                "response_format":
                {
                    "type":"json_schema",
                    "json_schema":
                    {
                        "name": "DescribedObject",
                        "schema":
                        {
                            "type":"object",
                            "properties":
                            {
                                "description":
                                {
                                    "type":"string"
                                }
                            },
                            "required":["description"],
                            "additionalProperties":false
                         },
                         "description":"An object with a description"
                    }
                }
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADx3PvAnCwJg0woha4pYsBTi3ZpOI",
              "object": "chat.completion",
              "choices": [
                {
                  "message": {
                    "role": "assistant",
                    "content": "Hello! How can I assist you today?"
                  }
                }
              ]
            }
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        Assert.That(await client.GetResponseAsync("hello", new()
        {
            ResponseFormat = ChatResponseFormat.ForJsonSchema(JsonSerializer.Deserialize<JsonElement>("""
                {
                  "type": "object",
                  "properties": {
                    "description": {
                      "type": "string"
                    }
                  },
                  "required": ["description"]
                }
                """), "DescribedObject", "An object with a description"),
        }), Is.Not.Null);
    }

    [RecordedTest]
    public async Task MultipleMessages_NonStreaming()
    {
        const string Input = """
            {
                "messages": [
                    {
                        "role": "system",
                        "content": "You are a really nice friend."
                    },
                    {
                        "role": "user",
                        "content": "hello!"
                    },
                    {
                        "role": "assistant",
                        "content": "hi, how are you?"
                    },
                    {
                        "role": "user",
                        "content": "i\u0027m good. how are you?"
                    },
                    {
                        "role": "assistant",
                        "content": "",
                        "tool_calls": [{"id":"abcd123","type":"function","function":{"name":"GetMood","arguments":"null"}}]
                    },
                    {
                        "role": "tool",
                        "content": "happy",
                        "tool_call_id": "abcd123"
                    }
                ],
                "temperature": 0.25,
                "stop": [
                    "great"
                ],
                "presence_penalty": 0.5,
                "frequency_penalty": 0.75,
                "seed": 42,
                "model": "gpt-4o-mini"
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADyV17bXeSm5rzUx3n46O7m3M0o3P",
              "object": "chat.completion",
              "created": 1727894187,
              "model": "gpt-4o-mini-2024-07-18",
              "choices": [
                {
                  "index": 0,
                  "message": {
                    "role": "assistant",
                    "content": "I'm doing well, thank you! What's on your mind today?",
                    "refusal": null
                  },
                  "logprobs": null,
                  "finish_reason": "stop"
                }
              ],
              "usage": {
                "prompt_tokens": 42,
                "completion_tokens": 15,
                "total_tokens": 57,
                "prompt_tokens_details": {
                  "cached_tokens": 0
                },
                "completion_tokens_details": {
                  "reasoning_tokens": 0
                }
              },
              "system_fingerprint": "fp_f85bea6784"
            }
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        List<ChatMessage> messages =
        [
            new(ChatRole.System, "You are a really nice friend."),
            new(ChatRole.User, "hello!"),
            new(ChatRole.Assistant, "hi, how are you?"),
            new(ChatRole.User, "i'm good. how are you?"),
            new(ChatRole.Assistant, [new FunctionCallContent("abcd123", "GetMood")]),
            new(ChatRole.Tool, [new FunctionResultContent("abcd123", "happy")]),
        ];

        var response = await client.GetResponseAsync(messages, new()
        {
            Temperature = 0.25f,
            FrequencyPenalty = 0.75f,
            PresencePenalty = 0.5f,
            StopSequences = ["great"],
            Seed = 42,
        });
        Assert.That(response, Is.Not.Null);

        Assert.That(response.ResponseId, Is.EqualTo("chatcmpl-ADyV17bXeSm5rzUx3n46O7m3M0o3P"));
        Assert.That(response.Text, Is.EqualTo("I'm doing well, thank you! What's on your mind today?"));
        Assert.That(response.Messages.Single().Contents, Has.Count.EqualTo(1));
        Assert.That(response.Messages.Single().Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(response.Messages.Single().MessageId, Is.EqualTo("chatcmpl-ADyV17bXeSm5rzUx3n46O7m3M0o3P"));
        Assert.That(response.ModelId, Is.EqualTo("gpt-4o-mini-2024-07-18"));
        Assert.That(response.CreatedAt, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(1_727_894_187)));
        Assert.That(response.FinishReason, Is.EqualTo(ChatFinishReason.Stop));

        Assert.That(response.Usage, Is.Not.Null);
        Assert.That(response.Usage!.InputTokenCount, Is.EqualTo(42));
        Assert.That(response.Usage.OutputTokenCount, Is.EqualTo(15));
        Assert.That(response.Usage.TotalTokenCount, Is.EqualTo(57));
    }

    [RecordedTest]
    public async Task MultipleContent_NonStreaming()
    {
        const string Input = """
            {
                "messages":
                [
                    {
                        "role": "user",
                        "content":
                        [
                            {
                                "type": "text",
                                "text": "Describe this picture."
                            },
                            {
                                "type": "image_url",
                                "image_url":
                                {
                                    "url": "http://dot.net/someimage.png"
                                }
                            }
                        ]
                    }
                ],
                "model": "gpt-4o-mini"
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADyV17bXeSm5rzUx3n46O7m3M0o3P",
              "object": "chat.completion",
              "choices": [
                {
                  "message": {
                    "role": "assistant",
                    "content": "A picture of a dog."
                  }
                }
              ]
            }
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        Assert.That(await client.GetResponseAsync([new(ChatRole.User,
        [
            new TextContent("Describe this picture."),
            new UriContent("http://dot.net/someimage.png", mediaType: "image/*"),
        ])]), Is.Not.Null);
    }

    [RecordedTest]
    public async Task NullAssistantText_ContentEmpty_NonStreaming()
    {
        const string Input = """
            {
                "messages": [
                    {
                        "role": "assistant",
                        "content": ""
                    },
                    {
                        "role": "user",
                        "content": "hello!"
                    }
                ],
                "model": "gpt-4o-mini"
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADyV17bXeSm5rzUx3n46O7m3M0o3P",
              "object": "chat.completion",
              "created": 1727894187,
              "model": "gpt-4o-mini-2024-07-18",
              "choices": [
                {
                  "index": 0,
                  "message": {
                    "role": "assistant",
                    "content": "Hello.",
                    "refusal": null
                  },
                  "logprobs": null,
                  "finish_reason": "stop"
                }
              ],
              "usage": {
                "prompt_tokens": 42,
                "completion_tokens": 15,
                "total_tokens": 57,
                "prompt_tokens_details": {
                  "cached_tokens": 0
                },
                "completion_tokens_details": {
                  "reasoning_tokens": 0
                }
              },
              "system_fingerprint": "fp_f85bea6784"
            }
            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        List<ChatMessage> messages =
        [
            new(ChatRole.Assistant, (string?)null),
            new(ChatRole.User, "hello!"),
        ];

        var response = await client.GetResponseAsync(messages);
        Assert.That(response, Is.Not.Null);

        Assert.That(response.ResponseId, Is.EqualTo("chatcmpl-ADyV17bXeSm5rzUx3n46O7m3M0o3P"));
        Assert.That(response.Text, Is.EqualTo("Hello."));
        Assert.That(response.Messages.Single().Contents, Has.Count.EqualTo(1));
        Assert.That(response.Messages.Single().Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(response.ModelId, Is.EqualTo("gpt-4o-mini-2024-07-18"));
        Assert.That(response.CreatedAt, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(1_727_894_187)));
        Assert.That(response.FinishReason, Is.EqualTo(ChatFinishReason.Stop));

        Assert.That(response.Usage, Is.Not.Null);
        Assert.That(response.Usage!.InputTokenCount, Is.EqualTo(42));
        Assert.That(response.Usage.OutputTokenCount, Is.EqualTo(15));
        Assert.That(response.Usage.TotalTokenCount, Is.EqualTo(57));
    }

    public static IEnumerable<object[]> FunctionCallContent_NonStreaming_MemberData()
    {
        yield return new object[] { ChatToolMode.Auto };
        yield return new object[] { ChatToolMode.None };
        yield return new object[] { ChatToolMode.RequireAny };
        yield return new object[] { ChatToolMode.RequireSpecific("GetPersonAge") };
    }

    [RecordedTest]
    [TestCaseSource(nameof(FunctionCallContent_NonStreaming_MemberData))]
    public async Task FunctionCallContent_NonStreaming(ChatToolMode mode)
    {
        string input = $$"""
            {
                "messages": [
                    {
                        "role": "user",
                        "content": "How old is Alice?"
                    }
                ],
                "model": "gpt-4o-mini",
                "tools": [
                    {
                        "type": "function",
                        "function": {
                            "name": "GetPersonAge",
                            "description": "Gets the age of the specified person.",
                            "parameters": {
                                "type": "object",
                                "required": ["personName"],
                                "properties": {
                                    "personName": {
                                        "description": "The person whose age is being requested",
                                        "type": "string"
                                    }
                                }
                            }
                        }
                    }
                ],
                "tool_choice": {{(
                    mode is NoneChatToolMode ? "\"none\"" :
                    mode is AutoChatToolMode ? "\"auto\"" :
                    mode is RequiredChatToolMode { RequiredFunctionName: not null } f ? "{\"type\":\"function\",\"function\":{\"name\":\"GetPersonAge\"}}" :
                    "\"required\""
                    )}}
            }
            """;

        const string Output = """
            {
              "id": "chatcmpl-ADydKhrSKEBWJ8gy0KCIU74rN3Hmk",
              "object": "chat.completion",
              "created": 1727894702,
              "model": "gpt-4o-mini-2024-07-18",
              "choices": [
                {
                  "index": 0,
                  "message": {
                    "role": "assistant",
                    "content": null,
                    "tool_calls": [
                      {
                        "id": "call_8qbINM045wlmKZt9bVJgwAym",
                        "type": "function",
                        "function": {
                          "name": "GetPersonAge",
                          "arguments": "{\"personName\":\"Alice\"}"
                        }
                      }
                    ],
                    "refusal": null
                  },
                  "logprobs": null,
                  "finish_reason": "tool_calls"
                }
              ],
              "usage": {
                "prompt_tokens": 61,
                "completion_tokens": 16,
                "total_tokens": 77,
                "prompt_tokens_details": {
                  "cached_tokens": 0
                },
                "completion_tokens_details": {
                  "reasoning_tokens": 0
                }
              },
              "system_fingerprint": "fp_f85bea6784"
            }
            """;

        using VerbatimHttpHandler handler = new(input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        var response = await client.GetResponseAsync("How old is Alice?", new()
        {
            Tools = [AIFunctionFactory.Create(([System.ComponentModel.Description("The person whose age is being requested")] string personName) => 42, "GetPersonAge", "Gets the age of the specified person.")],
            ToolMode = mode,
        });
        Assert.That(response, Is.Not.Null);

        Assert.That(response.Text, Is.Empty);
        Assert.That(response.ModelId, Is.EqualTo("gpt-4o-mini-2024-07-18"));
        Assert.That(response.Messages.Single().Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(response.CreatedAt, Is.EqualTo(DateTimeOffset.FromUnixTimeSeconds(1_727_894_702)));
        Assert.That(response.FinishReason, Is.EqualTo(ChatFinishReason.ToolCalls));
        Assert.That(response.Usage, Is.Not.Null);
        Assert.That(response.Usage!.InputTokenCount, Is.EqualTo(61));
        Assert.That(response.Usage.OutputTokenCount, Is.EqualTo(16));
        Assert.That(response.Usage.TotalTokenCount, Is.EqualTo(77));

        Assert.That(response.Messages.Single().Contents, Has.Count.EqualTo(1));

        var aiContent = response.Messages.Single().Contents[0];
        Assert.That(aiContent, Is.InstanceOf<FunctionCallContent>());
        var fcc = (FunctionCallContent)aiContent;
        Assert.That(fcc.Name, Is.EqualTo("GetPersonAge"));
        AssertExtensions.EqualFunctionCallParameters(new Dictionary<string, object?> { ["personName"] = "Alice" }, fcc.Arguments);
    }

    [RecordedTest]
    public async Task FunctionCallContent_Streaming()
    {
        const string Input = """
            {
                "messages": [
                    {
                        "role": "user",
                        "content": "How old is Alice?"
                    }
                ],
                "stream": true,
                "model": "gpt-4o-mini",
                "tools": [
                    {
                        "type": "function",
                        "function": {
                            "name": "GetPersonAge",
                            "description": "Gets the age of the specified person.",
                            "parameters": {
                                "type": "object",
                                "required": ["personName"],
                                "properties": {
                                    "personName": {
                                        "description": "The person whose age is being requested",
                                        "type": "string"
                                    }
                                }
                            }
                        }
                    }
                ],
                "tool_choice": "auto"
            }
            """;

        const string Output = """
            data: {"id":"chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl","object":"chat.completion.chunk","created":1727895263,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"role":"assistant","content":null,"tool_calls":[{"index":0,"id":"call_F9ZaqPWo69u0urxAhVt8meDW","type":"function","function":{"name":"GetPersonAge","arguments":""}}],"refusal":null},"logprobs":null,"finish_reason":null}],"usage":null}

            data: {"id":"chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl","object":"chat.completion.chunk","created":1727895263,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"tool_calls":[{"index":0,"function":{"arguments":"{\""}}]},"logprobs":null,"finish_reason":null}],"usage":null}

            data: {"id":"chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl","object":"chat.completion.chunk","created":1727895263,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"tool_calls":[{"index":0,"function":{"arguments":"person"}}]},"logprobs":null,"finish_reason":null}],"usage":null}

            data: {"id":"chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl","object":"chat.completion.chunk","created":1727895263,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"tool_calls":[{"index":0,"function":{"arguments":"Name"}}]},"logprobs":null,"finish_reason":null}],"usage":null}

            data: {"id":"chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl","object":"chat.completion.chunk","created":1727895263,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"tool_calls":[{"index":0,"function":{"arguments":"\":\""}}]},"logprobs":null,"finish_reason":null}],"usage":null}

            data: {"id":"chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl","object":"chat.completion.chunk","created":1727895263,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"tool_calls":[{"index":0,"function":{"arguments":"Alice"}}]},"logprobs":null,"finish_reason":null}],"usage":null}

            data: {"id":"chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl","object":"chat.completion.chunk","created":1727895263,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{"tool_calls":[{"index":0,"function":{"arguments":"\"}"}}]},"logprobs":null,"finish_reason":null}],"usage":null}

            data: {"id":"chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl","object":"chat.completion.chunk","created":1727895263,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[{"index":0,"delta":{},"logprobs":null,"finish_reason":"tool_calls"}],"usage":null}

            data: {"id":"chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl","object":"chat.completion.chunk","created":1727895263,"model":"gpt-4o-mini-2024-07-18","system_fingerprint":"fp_f85bea6784","choices":[],"usage":{"prompt_tokens":61,"completion_tokens":16,"total_tokens":77,"prompt_tokens_details":{"cached_tokens":0},"completion_tokens_details":{"reasoning_tokens":0}}}

            data: [DONE]

            """;

        using VerbatimHttpHandler handler = new(Input, Output);
        using HttpClient httpClient = new(handler);
        using IChatClient client = CreateChatClient(httpClient, "gpt-4o-mini");

        List<ChatResponseUpdate> updates = [];
        await foreach (var update in client.GetStreamingResponseAsync("How old is Alice?", new()
        {
            Tools = [AIFunctionFactory.Create(([System.ComponentModel.Description("The person whose age is being requested")] string personName) => 42, "GetPersonAge", "Gets the age of the specified person.")],
        }))
        {
            updates.Add(update);
        }

        Assert.That(string.Concat(updates.Select(u => u.Text)), Is.EqualTo(""));

        var createdAt = DateTimeOffset.FromUnixTimeSeconds(1_727_895_263);
        Assert.That(updates.Count, Is.EqualTo(10));
        for (int i = 0; i < updates.Count; i++)
        {
            Assert.That(updates[i].ResponseId, Is.EqualTo("chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl"));
            Assert.That(updates[i].MessageId, Is.EqualTo("chatcmpl-ADymNiWWeqCJqHNFXiI1QtRcLuXcl"));
            Assert.That(updates[i].CreatedAt, Is.EqualTo(createdAt));
            Assert.That(updates[i].ModelId, Is.EqualTo("gpt-4o-mini-2024-07-18"));
            Assert.That(updates[i].Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(updates[i].FinishReason, Is.EqualTo(i < 7 ? null : ChatFinishReason.ToolCalls));
        }

        Assert.That(updates[updates.Count - 1].Contents.Count, Is.EqualTo(1));
        var aiContent = updates[updates.Count - 1].Contents[0];
        Assert.That(aiContent, Is.InstanceOf<FunctionCallContent>());
        var fcc = (FunctionCallContent)aiContent;

        Assert.That(fcc.CallId, Is.EqualTo("call_F9ZaqPWo69u0urxAhVt8meDW"));
        Assert.That(fcc.Name, Is.EqualTo("GetPersonAge"));
        AssertExtensions.EqualFunctionCallParameters(new Dictionary<string, object?> { ["personName"] = "Alice" }, fcc.Arguments);
    }

    private static IChatClient CreateChatClient(HttpClient httpClient, string modelId) =>
        new ChatCompletionsClient(
            new("http://somewhere"),
            new AzureKeyCredential("key"),
            new AzureAIInferenceClientOptions { Transport = new HttpClientTransport(httpClient) })
            .AsIChatClient(modelId);

    private static class AssertExtensions
    {
        /// <summary>
        /// Asserts that the two function call parameters are equal, up to JSON equivalence.
        /// </summary>
        public static void EqualFunctionCallParameters(
            IDictionary<string, object?>? expected,
            IDictionary<string, object?>? actual,
            JsonSerializerOptions? options = null)
        {
            if (expected is null || actual is null)
            {
                Assert.That(actual, Is.EqualTo(expected));
                return;
            }

            foreach (var expectedEntry in expected)
            {
                if (!actual.TryGetValue(expectedEntry.Key, out object? actualValue))
                {
                    throw new AssertionException($"Expected parameter '{expectedEntry.Key}' not found in actual value.");
                }

                AreJsonEquivalentValues(expectedEntry.Value, actualValue, options, propertyName: expectedEntry.Key);
            }

            if (expected.Count != actual.Count)
            {
                var extraParameters = actual
                    .Where(e => !expected.ContainsKey(e.Key))
                    .Select(e => $"'{e.Key}'")
                    .First();

                throw new AssertionException($"Actual value contains additional parameters {string.Join(", ", extraParameters)} not found in expected value.");
            }
        }

        private static void AreJsonEquivalentValues(object? expected, object? actual, JsonSerializerOptions? options, string? propertyName = null)
        {
            options ??= AIJsonUtilities.DefaultOptions;
            JsonElement expectedElement = NormalizeToElement(expected, options);
            JsonElement actualElement = NormalizeToElement(actual, options);
            if (!JsonNode.DeepEquals(
                JsonSerializer.SerializeToNode(expectedElement, AIJsonUtilities.DefaultOptions),
                JsonSerializer.SerializeToNode(actualElement, AIJsonUtilities.DefaultOptions)))
            {
                string message = propertyName is null
                    ? $"Function result does not match expected JSON.\r\nExpected: {expectedElement.GetRawText()}\r\nActual:   {actualElement.GetRawText()}"
                    : $"Parameter '{propertyName}' does not match expected JSON.\r\nExpected: {expectedElement.GetRawText()}\r\nActual:   {actualElement.GetRawText()}";

                throw new AssertionException(message);
            }

            static JsonElement NormalizeToElement(object? value, JsonSerializerOptions options)
                => value is JsonElement e ? e : JsonSerializer.SerializeToElement(value, options);
        }
    }
}
