using Azure.CloudMachine.OpenAI;
using OpenAI.Chat;
using System.Buffers.Binary;
using System.Buffers;
using System.Text;

internal class ChatPrompt
{
    private readonly StringBuilder _contentText = new();
    private int _lastSerializedIndex = 0; // Index of the last serialized message
    private List<ChatMessage> _messages = new();

    internal IEnumerable<ChatMessage> Messages => _messages;

    public void Add(ChatMessage message) => _messages.Add(message);
    public void Add(IEnumerable<VectorbaseEntry> related) => _messages.Add(related);
    public void Add(ChatCompletion completion) => _messages.Add(completion);

    public void AddRange(IEnumerable<ToolChatMessage> toolResults) => _messages.AddRange(toolResults);

    public void Trim()
    {
        int totalCount = _messages.Count;
        if (totalCount < 2)
            return;

        // Calculate half of the current messages to remove
        int toRemove = totalCount / 2;

        // Create a new list with the same capacity
        var trimmedMessages = new List<ChatMessage>(_messages.Capacity);

        // First pass: Remove non-system messages (oldest first)
        for (int i = 0; i < _messages.Count; i++)
        {
            var msg = _messages[i];
            if (toRemove > 0 && !(msg is SystemChatMessage))
            {
                toRemove--;
                continue;
            }
            trimmedMessages.Add(msg);
        }

        // Second pass: If still need to remove, remove system messages (oldest first)
        if (toRemove > 0)
        {
            var finalMessages = new List<ChatMessage>(_messages.Capacity);
            for (int i = 0; i < trimmedMessages.Count; i++)
            {
                var msg = trimmedMessages[i];
                if (toRemove > 0 && msg is SystemChatMessage)
                {
                    toRemove--;
                    continue;
                }
                finalMessages.Add(msg);
            }
            trimmedMessages = finalMessages;
        }

        // Swap the message lists
        _messages = trimmedMessages;
        _lastSerializedIndex = 0;
        _contentText.Clear();
    }

    /// <summary>
    /// Gets the serialized content of the prompt.
    /// Assumes the buffer is dirty if _lastSerializedIndex is not equal to the number of messages.
    /// </summary>
    /// <returns>The content as a string.</returns>
    public string GetContent()
    {
        // Check if there are new messages to serialize
        if (_lastSerializedIndex < _messages.Count)
        {
            // Append new messages starting from _lastSerializedIndex
            for (int i = _lastSerializedIndex; i < _messages.Count; i++)
            {
                ChatMessage message = _messages[i];
                _contentText.Append(message.Content.AsText());
            }

            _lastSerializedIndex = _messages.Count;
        }

        return _contentText.ToString();
    }

    internal static ChatPrompt Deserialize(byte[] promptBytes)
    {
        var prompt = new ChatPrompt();

        using var ms = new MemoryStream(promptBytes);
        using var reader = new BinaryReader(ms);

        // Read the number of messages
        int messageCount = reader.ReadInt32();

        // Deserialize each message
        for (int i = 0; i < messageCount; i++)
        {
            // Read the message type
            MessageType messageType = (MessageType)reader.ReadByte();

            // Read the message content
            string content = reader.ReadString();

            // Create the appropriate message
            ChatMessage message = CreateMessageInstance(messageType, content);

            // Add the message to the prompt
            prompt._messages.Add(message);
        }

        // Reset serialization indices
        prompt._lastSerializedIndex = 0;
        prompt._contentText.Clear();

        return prompt;
    }

    internal void Serialize(IBufferWriter<byte> writer)
        {
            // Write the number of messages (int32)
            int messageCount = _messages.Count;
            const int intSize = sizeof(int);
            Span<byte> span = writer.GetSpan(intSize);
            BinaryPrimitives.WriteInt32LittleEndian(span, messageCount);
            writer.Advance(intSize);

            // Serialize each message
            foreach (var message in _messages)
            {
                // Write the message type (byte)
                MessageType messageType = GetMessageType(message);
                span = writer.GetSpan(1);
                span[0] = (byte)messageType;
                writer.Advance(1);

                // Write the message content length (int32) and content bytes
                string content = message.Content.AsText();
                int contentByteCount = Encoding.UTF8.GetByteCount(content);

                // Write content length (int32)
                span = writer.GetSpan(intSize);
                BinaryPrimitives.WriteInt32LittleEndian(span, contentByteCount);
                writer.Advance(intSize);

                // Write content bytes directly to the span
                span = writer.GetSpan(contentByteCount);
                Encoding.UTF8.GetBytes(content, span);
                writer.Advance(contentByteCount);
            }
        }

    // Helper method to determine message type
    private static MessageType GetMessageType(ChatMessage message)
    {
        return message switch
        {
            SystemChatMessage => MessageType.System,
            UserChatMessage => MessageType.User,
            AssistantChatMessage => MessageType.Assistant,
            ToolChatMessage => MessageType.Tool,
            _ => throw new InvalidOperationException($"Unsupported message type: {message.GetType()}")
        };
    }

    // Helper method to create message instances based on type
    private static ChatMessage CreateMessageInstance(MessageType messageType, string content)
    {
        return messageType switch
        {
            MessageType.System => new SystemChatMessage(content),
            MessageType.User => new UserChatMessage(content),
            MessageType.Assistant => new AssistantChatMessage(content),
            MessageType.Tool => new ToolChatMessage(content),
            _ => throw new InvalidOperationException($"Unsupported message type: {messageType}")
        };
    }

    // Enum to represent message types
    private enum MessageType : byte
    {
        System = 1,
        User = 2,
        Assistant = 3,
        Tool = 4
    }
}

internal static class Extensions
{
    public static async Task<ChatCompletion> CompleteChatAsync(this ChatClient client, ChatPrompt prompt)
    {
        ChatCompletion completion = await client.CompleteChatAsync(prompt.Messages);
        return completion;
    }
}
