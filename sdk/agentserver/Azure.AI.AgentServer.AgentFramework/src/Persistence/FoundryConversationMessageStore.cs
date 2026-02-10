// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Core.Responses.Conversations;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework.Persistence;

/// <summary>
/// Loads and converts Foundry conversation items into chat messages.
/// </summary>
internal sealed class FoundryConversationMessageStore
{
    private static readonly JsonSerializerOptions Json = JsonExtensions.DefaultJsonSerializerOptions;
    private readonly ConversationItemsClient _client;
    private readonly string _conversationId;
    private readonly SemaphoreSlim _fetchLock = new(1, 1);
    private List<ChatMessage>? _cachedMessages;
    private bool _isHydrated;

    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryConversationMessageStore"/> class.
    /// </summary>
    /// <param name="client">Conversation items client.</param>
    /// <param name="conversationId">Conversation ID.</param>
    public FoundryConversationMessageStore(ConversationItemsClient client, string conversationId)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _conversationId = conversationId ?? throw new ArgumentNullException(nameof(conversationId));
    }

    /// <summary>
    /// Gets the hydrated conversation messages.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Hydrated chat messages in chronological order.</returns>
    public async Task<IReadOnlyList<ChatMessage>> GetMessagesAsync(CancellationToken cancellationToken = default)
    {
        if (_isHydrated)
        {
            return _cachedMessages ?? [];
        }

        await _fetchLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_isHydrated)
            {
                return _cachedMessages ?? [];
            }

            try
            {
                var items = await _client.ListItemsAsync(_conversationId, cancellationToken).ConfigureAwait(false);
                _cachedMessages = ConvertItemsToMessages(items);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch
            {
                // Graceful degradation: continue execution without historical messages.
                _cachedMessages = [];
            }

            _isHydrated = true;
            return _cachedMessages;
        }
        finally
        {
            _fetchLock.Release();
        }
    }

    private static List<ChatMessage> ConvertItemsToMessages(IReadOnlyList<ItemResource> items)
    {
        var messages = new List<ChatMessage>(items.Count);
        foreach (var item in items)
        {
            var message = item switch
            {
                ResponsesMessageItemResource messageItem => ConvertResponseMessage(messageItem),
                FunctionToolCallItemResource functionCallItem => CreateFunctionCallMessage(functionCallItem),
                FunctionToolCallOutputItemResource functionOutputItem => CreateFunctionOutputMessage(functionOutputItem),
                _ => null
            };

            if (message != null)
            {
                messages.Add(message);
            }
        }

        return messages;
    }

    private static ChatMessage? ConvertResponseMessage(ResponsesMessageItemResource messageItem)
    {
        var role = messageItem.Role switch
        {
            ResponsesMessageRole.Assistant => ChatRole.Assistant,
            ResponsesMessageRole.System => ChatRole.System,
            ResponsesMessageRole.Developer => ChatRole.System,
            _ => ChatRole.User
        };

        var textContents = GetTextContents(messageItem).ToList();
        if (textContents.Count == 0)
        {
            return null;
        }

        return new ChatMessage(role, textContents);
    }

    private static ChatMessage CreateFunctionCallMessage(FunctionToolCallItemResource functionCallItem)
    {
        var arguments = ParseFunctionArguments(functionCallItem.Arguments);
        return new ChatMessage(
            ChatRole.Assistant,
            [
                new FunctionCallContent(functionCallItem.CallId, functionCallItem.Name, arguments)
            ]);
    }

    private static ChatMessage CreateFunctionOutputMessage(FunctionToolCallOutputItemResource functionOutputItem)
    {
        return new ChatMessage(
            ChatRole.Tool,
            [
                new FunctionResultContent(functionOutputItem.CallId, functionOutputItem.Output)
            ]);
    }

    private static IEnumerable<AIContent> GetTextContents(ResponsesMessageItemResource messageItem)
    {
        var contents = messageItem switch
        {
            ResponsesAssistantMessageItemResource assistantMessage => assistantMessage.Content,
            ResponsesSystemMessageItemResource systemMessage => systemMessage.Content,
            ResponsesUserMessageItemResource userMessage => userMessage.Content,
            ResponsesDeveloperMessageItemResource developerMessage => developerMessage.Content,
            _ => []
        };

        foreach (var content in contents)
        {
            string? text = content switch
            {
                ItemContentInputText inputText => inputText.Text,
                ItemContentOutputText outputText => outputText.Text,
                _ => null
            };

            if (!string.IsNullOrWhiteSpace(text))
            {
                yield return new TextContent(text);
            }
        }
    }

    private static IDictionary<string, object?> ParseFunctionArguments(string arguments)
    {
        if (string.IsNullOrWhiteSpace(arguments))
        {
            return new Dictionary<string, object?>();
        }

        try
        {
            var dictionaryArguments = JsonSerializer.Deserialize<Dictionary<string, object?>>(arguments, Json);
            if (dictionaryArguments != null)
            {
                return dictionaryArguments;
            }

            var fallbackValue = JsonSerializer.Deserialize<object>(arguments, Json);
            return new Dictionary<string, object?>
            {
                ["value"] = fallbackValue
            };
        }
        catch (JsonException)
        {
            return new Dictionary<string, object?>
            {
                ["value"] = arguments
            };
        }
    }
}
