// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core;
using Castle.Components.DictionaryAdapter;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.AI.Inference.Tests;
public class ExtensionsTest
{
    #region MockConnectionProvider
    private class MockConnectionProvider : ConnectionProvider
    {
        private static readonly ClientConnection s_defaultChat = new("DefaultChat", "https://www.microsoft.com", "12345");
        private static readonly ClientConnection s_defaultEmbed = new("DefaultEmbedding", "https://ms.portal.azure.com", "12345");

        private readonly Dictionary<string, ClientConnection> _defaults = new()
        {
            { typeof(ChatCompletionsClient).FullName!, s_defaultChat},
            { typeof(EmbeddingsClient).FullName!, s_defaultEmbed}
        };

        private readonly List<ClientConnection> _all = [
            s_defaultChat,
            new ClientConnection("Chat", "https://portal.azure.com", "12345"),
            new ClientConnection("BadChat", "BadURL", "12345"),
            s_defaultEmbed,
            new ClientConnection("Embedding", "https://live.com", "12345"),
            new ClientConnection("BadEmbedding", "www.microsoft.com", "12345"),
        ];

        public override ClientConnection GetConnection(string connectionId)
        {
            return _defaults[connectionId];
        }
        public override IEnumerable<ClientConnection> GetAllConnections()
        {
            return _all;
        }
    }
    #endregion

    [Test]
    public void TestGetDefaultConnectionChat()
    {
        // We have to create MockConnectionProvider because the connection
        // after it was first time obtained, next time will be taken by type from
        // cache.
        MockConnectionProvider _mockProvider = new();
        ChatCompletionsClient client = _mockProvider.GetChatCompletionsClient();
        AssertChatUriCorrect(client, "https://www.microsoft.com");
    }

    [Test]
    public void TestGetDefaultConnectionEmbedding()
    {
        // We have to create MockConnectionProvider because the connection
        // after it was first time obtained, next time will be taken by type from
        // cache.
        MockConnectionProvider _mockProvider = new();
        EmbeddingsClient client = _mockProvider.GetEmbeddingsClient();
        AssertEmbeddingUriCorrect(client, "https://ms.portal.azure.com");
    }

    [Test]
    public void TestGetNamedConnectionChat()
    {
        // We have to create MockConnectionProvider because the connection
        // after it was first time obtained, next time will be taken by type from
        // cache.
        MockConnectionProvider _mockProvider = new();
        ChatCompletionsClient client = _mockProvider.GetChatCompletionsClient("Chat");
        AssertChatUriCorrect(client, "https://portal.azure.com");
    }

    [Test]
    public void TestGetNamedConnectionEmbedding()
    {
        // We have to create MockConnectionProvider because the connection
        // after it was first time obtained, next time will be taken by type from
        // cache.
        MockConnectionProvider _mockProvider = new();
        EmbeddingsClient client = _mockProvider.GetEmbeddingsClient("Embedding");
        AssertEmbeddingUriCorrect(client, "https://live.com");
    }

    [Test]
    public void TestInvalidNameChatThrows()
    {
        // We have to create MockConnectionProvider because the connection
        // after it was first time obtained, next time will be taken by type from
        // cache.
        MockConnectionProvider _mockProvider = new();
        Assert.Throws<InvalidOperationException>(
            delegate { _mockProvider.GetChatCompletionsClient("DoesNotExist"); },
            message: "No connections with name DoesNotExist were found."
        );
    }

    [Test]
    public void TestInvalidNameEmbedThrows()
    {
        // We have to create MockConnectionProvider because the connection
        // after it was first time obtained, next time will be taken by type from
        // cache.
        MockConnectionProvider _mockProvider = new();
        Assert.Throws<InvalidOperationException>(
            delegate { _mockProvider.GetEmbeddingsClient("DoesNotExist"); },
            message: "No connections with name DoesNotExist were found."
        );
    }

    [Test]
    public void TestInvalidUriChatThrows()
    {
        // We have to create MockConnectionProvider because the connection
        // after it was first time obtained, next time will be taken by type from
        // cache.
        MockConnectionProvider _mockProvider = new();
        Assert.Throws<InvalidOperationException>(
            delegate { _mockProvider.GetChatCompletionsClient("BadChat"); },
            message: "Invalid URI."
        );
    }

    [Test]
    public void TestInvalidUriEmbedThrows()
    {
        // We have to create MockConnectionProvider because the connection
        // after it was first time obtained, next time will be taken by type from
        // cache.
        MockConnectionProvider _mockProvider = new();
        Assert.Throws<InvalidOperationException>(
            delegate { _mockProvider.GetEmbeddingsClient("BadEmbedding"); },
            message: "Invalid URI."
        );
    }

    #region Helpers
    private static void AssertChatUriCorrect(ChatCompletionsClient client, string uri)
    {
        var requestOptions = new ChatCompletionsOptions()
        {
            Messages =
            {
                new ChatRequestSystemMessage("You are a helpful assistant."),
                new ChatRequestUserMessage("What is the capital of France?"),
            },
            Model = "gpt-4"
        };
        RequestContent content = requestOptions.ToRequestContent();
        RequestContext context = ChatCompletionsClient.FromCancellationToken();
        HttpMessage msg = client.CreateCompleteRequest(content, null, context);
        Assert.That(
            msg.Request.Uri.ToString().StartsWith(uri),
            $"Uri was expected to start from {uri} but was {msg.Request.Uri.ToString()}"
        );
    }

    private static void AssertEmbeddingUriCorrect(EmbeddingsClient client, string uri)
    {
        var input = new List<string> { "King", "Queen", "Jack", "Page" };
        var requestOptions = new EmbeddingsOptions(input);
        RequestContent content = requestOptions.ToRequestContent();
        RequestContext context = ChatCompletionsClient.FromCancellationToken();
        HttpMessage msg = client.CreateEmbedRequest(content, null, context);
        Assert.That(
            msg.Request.Uri.ToString().StartsWith(uri),
            $"Uri was expected to start from {uri} but was {msg.Request.Uri.ToString()}"
        );
    }
    #endregion
}
