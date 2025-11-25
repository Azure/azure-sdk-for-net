// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.OpenAI.Internal;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Chat;

[Experimental("AOAI001")]
public static partial class AzureChatExtensions
{
    [Experimental("AOAI001")]
    public static void AddDataSource(this ChatCompletionOptions options, ChatDataSource dataSource)
    {
        JsonArray doc;
        if (options.Patch.Contains("$.data_sources"u8) && options.Patch.TryGetJson("$.data_sources"u8, out ReadOnlyMemory<byte> jsonBytes))
        {
            using var stream = new MemoryStream();
            stream.Write(jsonBytes.ToArray(), 0, jsonBytes.Length);
            string json = Encoding.UTF8.GetString(stream.ToArray());
            doc = JsonObject.Parse(json).AsArray();
        }
        else
        {
            doc = new();
        }
        using var objectStream = new MemoryStream();
        using BinaryContent contentBytes = BinaryContent.Create(dataSource, ModelSerializationExtensions.WireOptions);
        contentBytes.WriteTo(objectStream);
        string newJson = Encoding.UTF8.GetString(objectStream.ToArray());
        doc.Add(JsonObject.Parse(newJson));
        options.Patch.Set("$.data_sources"u8, BinaryData.FromString(doc.ToJsonString()));
    }

    [Experimental("AOAI001")]
    public static IReadOnlyList<ChatDataSource> GetDataSources(this ChatCompletionOptions options)
    {
        if (options.Patch.Contains("$.data_sources"u8) && options.Patch.TryGetJson("$.data_sources"u8, out ReadOnlyMemory<byte> mem))
        {
            using JsonDocument doc = JsonDocument.Parse(mem);
            List<ChatDataSource> chats = [];
            foreach (JsonElement dataSource in doc.RootElement.EnumerateArray())
            {
                chats.Add(ChatDataSource.DeserializeChatDataSource(dataSource, ModelSerializationExtensions.WireOptions));
            }
            return chats;
        }
        return null;
    }

    [Experimental("AOAI001")]
    public static void SetNewMaxCompletionTokensPropertyEnabled(this ChatCompletionOptions options, bool newPropertyEnabled = true)
    {
        if (newPropertyEnabled)
        {
            // Blocking serialization of max_tokens via dictionary acts as a signal to skip pre-serialization fixup
            AdditionalPropertyHelpers.SetEmptySentinelValue(patch: ref options.Patch, path: "$.max_tokens"u8);
        }
        else
        {
            if (options.Patch.Contains("$.max_tokens"u8) && !options.Patch.IsRemoved("$.max_tokens"u8))
            {
                options.Patch.Remove("$.max_tokens"u8);
            }
        }
    }

    [Experimental("AOAI001")]
    public static RequestContentFilterResult GetRequestContentFilterResult(this ChatCompletion chatCompletion)
    {
        if (chatCompletion.Patch.Contains("$.prompt_filter_results"u8) && chatCompletion.Patch.TryGetJson("$.prompt_filter_results"u8, out ReadOnlyMemory<byte> mem))
        {
            using JsonDocument doc = JsonDocument.Parse(mem);
            return RequestContentFilterResult.DeserializeRequestContentFilterResult(doc.RootElement.EnumerateArray().First(), ModelSerializationExtensions.WireOptions);
        }
        return null;
    }

    [Experimental("AOAI001")]
    public static ResponseContentFilterResult GetResponseContentFilterResult(this ChatCompletion chatCompletion)
    {
        if ((chatCompletion.Choices?[0]?.Patch.Contains("$.content_filter_results"u8) ?? false) &&
            (chatCompletion.Choices?[0]?.Patch.TryGetJson("$.content_filter_results"u8, out ReadOnlyMemory<byte> mem) ?? false))
        {
            using JsonDocument doc = JsonDocument.Parse(mem);
            return ResponseContentFilterResult.DeserializeResponseContentFilterResult(doc.RootElement, ModelSerializationExtensions.WireOptions);
        }
        return null;
    }

    [Experimental("AOAI001")]
    public static ChatMessageContext GetMessageContext(this ChatCompletion chatCompletion)
    {
        if ((chatCompletion.Choices?[0]?.Message?.Patch.Contains("$.context"u8) ?? false) &&
            (chatCompletion.Choices?[0]?.Message?.Patch.TryGetJson("$.context"u8, out ReadOnlyMemory<byte> mem) ?? false))
        {
            using JsonDocument doc = JsonDocument.Parse(mem);
            return ChatMessageContext.DeserializeChatMessageContext(doc.RootElement, ModelSerializationExtensions.WireOptions);
        }
        return null;
    }

    [Experimental("AOAI001")]
    public static ChatMessageContext GetMessageContext(this StreamingChatCompletionUpdate chatUpdate)
    {
        if (chatUpdate.Choices?.Count > 0 && chatUpdate.Choices[0].Delta.Patch.Contains("$.context"u8) && chatUpdate.Choices[0].Delta.Patch.TryGetJson("$.context"u8, out ReadOnlyMemory<byte> mem))
        {
            using JsonDocument doc = JsonDocument.Parse(mem);
            return ChatMessageContext.DeserializeChatMessageContext(doc.RootElement, ModelSerializationExtensions.WireOptions);
        }
        return null;
    }

    [Experimental("AOAI001")]
    public static RequestContentFilterResult GetRequestContentFilterResult(this StreamingChatCompletionUpdate chatUpdate)
    {
        if (chatUpdate.Patch.Contains("$.prompt_filter_results"u8) && chatUpdate.Patch.TryGetJson("$.prompt_filter_results"u8, out ReadOnlyMemory<byte> mem))
        {
            using JsonDocument doc = JsonDocument.Parse(mem);
            return RequestContentFilterResult.DeserializeRequestContentFilterResult(doc.RootElement.EnumerateArray().First(), ModelSerializationExtensions.WireOptions);
        }
        return null;
    }

    [Experimental("AOAI001")]
    public static ResponseContentFilterResult GetResponseContentFilterResult(this StreamingChatCompletionUpdate chatUpdate)
    {
        if ((chatUpdate?.Choices?.ElementAtOrDefault(0)?.Patch.Contains("$.content_filter_results"u8) ?? false) && (chatUpdate?.Choices?.ElementAtOrDefault(0)?.Patch.TryGetJson("$.content_filter_results"u8, out ReadOnlyMemory<byte> mem) ?? false))
        {
            using JsonDocument doc = JsonDocument.Parse(mem);
            return ResponseContentFilterResult.DeserializeResponseContentFilterResult(doc.RootElement, ModelSerializationExtensions.WireOptions);
        }
        return null;
    }

    [Experimental("AOAI001")]
    public static void SetUserSecurityContext(this ChatCompletionOptions options, UserSecurityContext userSecurityContext)
    {
        using BinaryContent contentBytes = BinaryContent.Create(userSecurityContext, ModelSerializationExtensions.WireOptions);
        using var stream = new MemoryStream();
        contentBytes.WriteTo(stream);
        BinaryData bin = new(stream.ToArray());
        options.Patch.Set("$.user_security_context"u8, bin);
    }

    [Experimental("AOAI001")]
    public static UserSecurityContext GetUserSecurityContext(this ChatCompletionOptions options)
    {
        if (options.Patch.Contains("$.user_security_context"u8) && options.Patch.TryGetJson("$.user_security_context"u8, out ReadOnlyMemory<byte> mem))
        {
            using JsonDocument doc = JsonDocument.Parse(mem);
            return UserSecurityContext.DeserializeUserSecurityContext(doc.RootElement, ModelSerializationExtensions.WireOptions);
        }
        return null;
    }

    [Experimental("AOAI001")]
    public static string GetMessageReasoningContent(this ChatCompletion chatCompletion)
    {
        if ((chatCompletion?.Choices?.FirstOrDefault()?.Message?.Patch.Contains("$.reasoning_content"u8) ?? false) &&
            (chatCompletion?.Choices?.FirstOrDefault()?.Message?.Patch.TryGetValue("$.reasoning_content"u8, out string retrievedReasoningContent) ?? false))
        {
            return retrievedReasoningContent;
        }
        return null;
    }
}
