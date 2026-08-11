// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Azure.AI.OpenAI.Internal;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Chat;

/// <summary> Provides Azure-specific extension methods for chat completion types, including On Your Data, content filtering, and user security context support. </summary>
[Experimental("AOAI001")]
public static partial class AzureChatExtensions
{
    /// <summary> Adds a data source to the chat completion options for use with the Azure On Your Data feature. </summary>
    /// <param name="options"> The <see cref="ChatCompletionOptions"/> to add the data source to. </param>
    /// <param name="dataSource"> The <see cref="ChatDataSource"/> to add. </param>
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

    /// <summary> Gets the list of data sources configured on the chat completion options. </summary>
    /// <param name="options"> The <see cref="ChatCompletionOptions"/> to retrieve data sources from. </param>
    /// <returns> A read-only list of configured <see cref="ChatDataSource"/> instances. </returns>
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

    /// <summary> Sets whether the newer <c>max_completion_tokens</c> property should be used instead of the legacy <c>max_tokens</c> property when serializing the request. </summary>
    /// <param name="options"> The <see cref="ChatCompletionOptions"/> to configure. </param>
    /// <param name="newPropertyEnabled"> <c>true</c> to use the newer property; <c>false</c> to use the legacy property. </param>
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

    /// <summary> Gets the content filter result applied to the prompt of a chat completion. </summary>
    /// <param name="chatCompletion"> The <see cref="ChatCompletion"/> to retrieve the filter result from. </param>
    /// <returns> The <see cref="RequestContentFilterResult"/>, or <c>null</c> if no filter result is available. </returns>
    [Experimental("AOAI001")]
    public static RequestContentFilterResult GetRequestContentFilterResult(this ChatCompletion chatCompletion)
    {
        return chatCompletion.Patch.GetDeserializedInstanceList(
            "$.prompt_filter_results"u8,
            RequestContentFilterResult.DeserializeRequestContentFilterResult)?
                .FirstOrDefault();
    }

    /// <summary> Gets the content filter result applied to the response of a chat completion. </summary>
    /// <param name="chatCompletion"> The <see cref="ChatCompletion"/> to retrieve the filter result from. </param>
    /// <returns> The <see cref="ResponseContentFilterResult"/>, or <c>null</c> if no filter result is available. </returns>
    [Experimental("AOAI001")]
    public static ResponseContentFilterResult GetResponseContentFilterResult(this ChatCompletion chatCompletion)
    {
        return chatCompletion?.Choices?.FirstOrDefault()?.Patch.GetDeserializedInstance(
            "$.content_filter_results"u8,
            ResponseContentFilterResult.DeserializeResponseContentFilterResult);
    }

    /// <summary> Gets the On Your Data message context from a non-streaming chat completion, including citations and intent. </summary>
    /// <param name="chatCompletion"> The <see cref="ChatCompletion"/> to retrieve the context from. </param>
    /// <returns> The <see cref="ChatMessageContext"/>, or <c>null</c> if no context is available. </returns>
    [Experimental("AOAI001")]
    public static ChatMessageContext GetMessageContext(this ChatCompletion chatCompletion)
    {
        return chatCompletion?.Choices?.FirstOrDefault()?.Message?.Patch.GetDeserializedInstance(
            "$.context"u8,
            ChatMessageContext.DeserializeChatMessageContext);
    }

    /// <summary> Gets the On Your Data message context from a streaming chat completion update, including citations and intent. </summary>
    /// <param name="chatUpdate"> The <see cref="StreamingChatCompletionUpdate"/> to retrieve the context from. </param>
    /// <returns> The <see cref="ChatMessageContext"/>, or <c>null</c> if no context is available. </returns>
    [Experimental("AOAI001")]
    public static ChatMessageContext GetMessageContext(this StreamingChatCompletionUpdate chatUpdate)
    {
        return chatUpdate?.Choices?.FirstOrDefault()?.Delta?.Patch.GetDeserializedInstance(
            "$.context"u8,
            ChatMessageContext.DeserializeChatMessageContext);
    }

    /// <summary> Gets the content filter result applied to the prompt of a streaming chat completion update. </summary>
    /// <param name="chatUpdate"> The <see cref="StreamingChatCompletionUpdate"/> to retrieve the filter result from. </param>
    /// <returns> The <see cref="RequestContentFilterResult"/>, or <c>null</c> if no filter result is available. </returns>
    [Experimental("AOAI001")]
    public static RequestContentFilterResult GetRequestContentFilterResult(this StreamingChatCompletionUpdate chatUpdate)
    {
        return chatUpdate?.Patch.GetDeserializedInstanceList(
            "$.prompt_filter_results"u8,
            RequestContentFilterResult.DeserializeContentFilterResultForPrompt)?
                .FirstOrDefault();
    }

    /// <summary> Gets the content filter result applied to the response of a streaming chat completion update. </summary>
    /// <param name="chatUpdate"> The <see cref="StreamingChatCompletionUpdate"/> to retrieve the filter result from. </param>
    /// <returns> The <see cref="ResponseContentFilterResult"/>, or <c>null</c> if no filter result is available. </returns>
    [Experimental("AOAI001")]
    public static ResponseContentFilterResult GetResponseContentFilterResult(this StreamingChatCompletionUpdate chatUpdate)
    {
        return chatUpdate?.Choices?.FirstOrDefault()?.Patch.GetDeserializedInstance(
            "$.content_filter_results"u8,
            ResponseContentFilterResult.DeserializeResponseContentFilterResult);
    }

    /// <summary> Sets the user security context on chat completion options for threat protection scenarios. </summary>
    /// <param name="options"> The <see cref="ChatCompletionOptions"/> to set the security context on. </param>
    /// <param name="userSecurityContext"> The <see cref="UserSecurityContext"/> describing the end user and application. </param>
    [Experimental("AOAI001")]
    public static void SetUserSecurityContext(this ChatCompletionOptions options, UserSecurityContext userSecurityContext)
    {
        BinaryData contextBytes = ((IJsonModel<UserSecurityContext>)userSecurityContext).Write(ModelSerializationExtensions.WireOptions);
        options.Patch.Set("$.user_security_context"u8, contextBytes);
    }

    /// <summary> Gets the user security context previously set on chat completion options. </summary>
    /// <param name="options"> The <see cref="ChatCompletionOptions"/> to retrieve the security context from. </param>
    /// <returns> The <see cref="UserSecurityContext"/>, or <c>null</c> if none has been set. </returns>
    [Experimental("AOAI001")]
    public static UserSecurityContext GetUserSecurityContext(this ChatCompletionOptions options)
    {
        return options.Patch.GetDeserializedInstance(
            "$.user_security_context"u8,
            UserSecurityContext.DeserializeUserSecurityContext);
    }

    /// <summary> Gets the reasoning content from the first choice message in a chat completion, when available from supported models. </summary>
    /// <param name="chatCompletion"> The <see cref="ChatCompletion"/> to retrieve reasoning content from. </param>
    /// <returns> The reasoning content string, or <c>null</c> if none is present. </returns>
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
