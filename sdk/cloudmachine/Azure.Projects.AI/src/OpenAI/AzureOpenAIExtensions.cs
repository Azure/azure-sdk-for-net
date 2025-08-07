// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.Collections.Generic;
using System.Text;
using Azure.Projects.AI;
using OpenAI.Chat;

namespace Azure.AI.OpenAI;

/// <summary>
/// The Azure OpenAI extensions.
/// </summary>
public static partial class AzureOpenAIExtensions
{
    /// <summary>
    /// returns full text of all parts.
    /// </summary>
    /// <returns></returns>
    public static string AsText(this ClientResult<ChatCompletion> completionResult)
        => AsText(completionResult.Value);

    /// <summary>
    /// returns full text of all parts.
    /// </summary>
    /// <param name="completion"></param>
    /// <returns></returns>
    public static string AsText(this ChatCompletion completion)
        => completion.Content.AsText();

    /// <summary>
    /// returns full text of all parts.
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string AsText(this ChatMessageContent content)
    {
        StringBuilder sb = new();
        foreach (ChatMessageContentPart part in content)
        {
            switch (part.Kind)
            {
                case ChatMessageContentPartKind.Text:
                    sb.AppendLine(part.Text);
                    break;
                default:
                    sb.AppendLine($"<{part.Kind}>");
                    break;
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Trims list of chat messages.
    /// </summary>
    /// <param name="messages"></param>
    public static void Trim(this List<ChatMessage> messages)
    {
        messages.RemoveRange(0, messages.Count / 2);
    }

    /// <summary>
    /// Adds a list of vectorbase entries to the list of chat messages.
    /// </summary>
    /// <param name="messages"></param>
    /// <param name="entries"></param>
    public static void Add(this List<ChatMessage> messages, IEnumerable<VectorbaseEntry> entries)
    {
        foreach (VectorbaseEntry entry in entries)
        {
            messages.Add(ChatMessage.CreateSystemMessage(entry.Data.ToString()));
        }
    }

    /// <summary>
    /// Adds a chat completion as an AssistantChatMessage to the list of chat messages.
    /// </summary>
    /// <param name="messages"></param>
    /// <param name="completion"></param>
    public static void Add(this List<ChatMessage> messages, ChatCompletion completion)
        => messages.Add(ChatMessage.CreateAssistantMessage(completion));

    /// <summary>
    /// Adds a list of tool chat messages to the list of chat messages.
    /// </summary>
    /// <param name="messages"></param>
    /// <param name="toolCallResults"></param>
    public static void Add(this List<ChatMessage> messages, IEnumerable<ToolChatMessage> toolCallResults)
        => messages.AddRange(toolCallResults);
}
