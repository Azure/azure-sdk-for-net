// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Internal;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Chat;

[Experimental("AOAI001")]
public static partial class AzureChatExtensions
{
    [Experimental("AOAI001")]
    public static void AddDataSource(this ChatCompletionOptions options, ChatDataSource dataSource)
    {
        ChangeTrackingList<ChatDataSource> dataSources = options.GetInternalDataSources();
        dataSources.Add(dataSource);

        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);

        writer.WriteStartArray();
        foreach (ChatDataSource listedDataSource in dataSources)
        {
            ((IJsonModel<ChatDataSource>)listedDataSource).Write(writer, ModelSerializationExtensions.WireOptions);
        }
        writer.WriteEndArray();

        writer.Flush();
        stream.Position = 0;

        options.Patch.Set("$.data_sources"u8, BinaryData.FromStream(stream));
    }

    [Experimental("AOAI001")]
    public static IReadOnlyList<ChatDataSource> GetDataSources(this ChatCompletionOptions options)
    {
        return options.GetInternalDataSources();
    }

    private static ChangeTrackingList<ChatDataSource> GetInternalDataSources(this ChatCompletionOptions options)
    {
        ChangeTrackingList<ChatDataSource> dataSources = new();
        if (options.Patch.GetBytesOrDefaultEx("$.data_sources"u8) is BinaryData dataSourceListBytes)
        {
            using JsonDocument listDocument = JsonDocument.Parse(dataSourceListBytes);
            if (listDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement dataSourceElement in listDocument.RootElement.EnumerateArray())
                {
                    ChatDataSource dataSource = ChatDataSource.DeserializeChatDataSource(dataSourceElement, ModelSerializationExtensions.WireOptions);
                    dataSources.Add(dataSource);
                }
            }
        }
        return dataSources;
    }

    [Experimental("AOAI001")]
    public static void SetNewMaxCompletionTokensPropertyEnabled(this ChatCompletionOptions options, bool newPropertyEnabled = true)
        => options.SetMaxTokenPatchValues(newPropertyEnabled);

    internal static void SetMaxTokenPatchValues(this ChatCompletionOptions options, bool? newPropertyRequested = null)
    {
        bool newPropertyInUse = options.Patch.Contains(NewMaxTokenJsonPath.Span) && !options.Patch.IsRemoved(NewMaxTokenJsonPath.Span);
        bool useNewProperty = newPropertyRequested ?? newPropertyInUse;

        ReadOnlySpan<byte> selectedPath = useNewProperty ? NewMaxTokenJsonPath.Span : OldMaxTokenJsonPath.Span;
        ReadOnlySpan<byte> deselectedPath = useNewProperty ? OldMaxTokenJsonPath.Span : NewMaxTokenJsonPath.Span;

        BinaryData valueBytes = options.MaxOutputTokenCount is null
            ? null
            : BinaryData.FromString(options.MaxOutputTokenCount.ToString());

        if (valueBytes is null)
        {
            options.Patch.Remove(selectedPath);
        }
        else
        {
            options.Patch.Set(selectedPath, valueBytes);
        }
        options.Patch.Remove(deselectedPath);
    }

    [Experimental("AOAI001")]
    public static RequestContentFilterResult GetRequestContentFilterResult(this ChatCompletion chatCompletion)
    {
        return chatCompletion.Patch.GetDeserializedInstanceList(
            "$.prompt_filter_results"u8,
            RequestContentFilterResult.DeserializeRequestContentFilterResult)?
                .FirstOrDefault();
    }

    [Experimental("AOAI001")]
    public static ResponseContentFilterResult GetResponseContentFilterResult(this ChatCompletion chatCompletion)
    {
        return chatCompletion?.Choices?.FirstOrDefault()?.Patch.GetDeserializedInstance(
            "$.content_filter_results"u8,
            ResponseContentFilterResult.DeserializeResponseContentFilterResult);
    }

    [Experimental("AOAI001")]
    public static ChatMessageContext GetMessageContext(this ChatCompletion chatCompletion)
    {
        return chatCompletion?.Choices?.FirstOrDefault()?.Message?.Patch.GetDeserializedInstance(
            "$.context"u8,
            ChatMessageContext.DeserializeChatMessageContext);
    }

    [Experimental("AOAI001")]
    public static ChatMessageContext GetMessageContext(this StreamingChatCompletionUpdate chatUpdate)
    {
        return chatUpdate?.Choices?.FirstOrDefault()?.Delta?.Patch.GetDeserializedInstance(
            "$.context"u8,
            ChatMessageContext.DeserializeChatMessageContext);
    }

    [Experimental("AOAI001")]
    public static RequestContentFilterResult GetRequestContentFilterResult(this StreamingChatCompletionUpdate chatUpdate)
    {
        return chatUpdate?.Patch.GetDeserializedInstanceList(
            "$.prompt_filter_results"u8,
            RequestContentFilterResult.DeserializeContentFilterResultForPrompt)?
                .FirstOrDefault();
    }

    [Experimental("AOAI001")]
    public static ResponseContentFilterResult GetResponseContentFilterResult(this StreamingChatCompletionUpdate chatUpdate)
    {
        return chatUpdate?.Choices?.FirstOrDefault()?.Patch.GetDeserializedInstance(
            "$.content_filter_results"u8,
            ResponseContentFilterResult.DeserializeResponseContentFilterResult);
    }

    [Experimental("AOAI001")]
    public static void SetUserSecurityContext(this ChatCompletionOptions options, UserSecurityContext userSecurityContext)
    {
        BinaryData contextBytes = ((IJsonModel<UserSecurityContext>)userSecurityContext).Write(ModelSerializationExtensions.WireOptions);
        options.Patch.Set("$.user_security_context"u8, contextBytes);
    }

    [Experimental("AOAI001")]
    public static UserSecurityContext GetUserSecurityContext(this ChatCompletionOptions options)
    {
        return options.Patch.GetDeserializedInstance(
            "$.user_security_context"u8,
            UserSecurityContext.DeserializeUserSecurityContext);
    }

    [Experimental("AOAI001")]
    public static string GetMessageReasoningContent(this ChatCompletion chatCompletion)
    {
        if (chatCompletion?.Choices?.FirstOrDefault()?.Message?.Patch.GetBytesOrDefaultEx("$.reasoning_content"u8)
            is BinaryData reasoningContentBytes)
        {
            Utf8JsonReader reader = new(reasoningContentBytes);
            reader.Read();
            return reader.GetString();
        }
        return null;
    }

    internal static ReadOnlyMemory<byte> NewMaxTokenJsonPath { get; } = "$.max_completion_tokens"u8.ToArray();
    internal static ReadOnlyMemory<byte> OldMaxTokenJsonPath { get; } = "$.max_tokens"u8.ToArray();
}
