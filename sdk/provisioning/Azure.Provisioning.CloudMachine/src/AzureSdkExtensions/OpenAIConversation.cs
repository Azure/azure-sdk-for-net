// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenAI.Chat;
using static Azure.Provisioning.CloudMachine.OpenAI.EmbeddingKnowledgebase;

namespace Azure.Provisioning.CloudMachine.OpenAI;

/// <summary>
/// Represents a conversation with the OpenAI chat model, incorporating a knowledgebase of embeddings data.
/// </summary>
public class OpenAIConversation
{
    private readonly ChatClient _client;
    private readonly Prompt _prompt;
    private readonly Dictionary<string, ChatTool> _tools = new();
    private readonly EmbeddingKnowledgebase _knowledgebase;
    private readonly ChatCompletionOptions _options = new ChatCompletionOptions();

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenAIConversation"/> class.
    /// </summary>
    /// <param name="client">The ChatClient.</param>
    /// <param name="tools">Any ChatTools to be used by the conversation.</param>
    /// <param name="knowledgebase">The knowledgebase.</param>
    internal OpenAIConversation(ChatClient client, IEnumerable<ChatTool> tools, EmbeddingKnowledgebase knowledgebase)
    {
        foreach (var tool in tools)
        {
            _options.Tools.Add(tool);
            _tools.Add(tool.FunctionName, tool);
        }
        _client = client;
        _knowledgebase = knowledgebase;
        _prompt = new Prompt();
        _prompt.AddTools(tools);
    }

    /// <summary>
    /// Sends a message to the OpenAI chat model and returns the response, incorporating any relevant knowledge from the <see cref="EmbeddingKnowledgebase"/>.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public string Say(string message)
    {
        List<Fact> facts = _knowledgebase.FindRelevantFacts(message);
        _prompt.AddFacts(facts);
        _prompt.AddUserMessage(message);
        var response = CallOpenAI();
        return response;
    }

    private string CallOpenAI()
    {
        bool requiresAction;
        do
        {
            requiresAction = false;
            var completion = _client.CompleteChat(_prompt.Messages).Value;
            switch (completion.FinishReason)
            {
                case ChatFinishReason.ToolCalls:
                    // TODO: Implement tool calls
                    requiresAction = true;
                    break;
                case ChatFinishReason.Length:
                    return "Incomplete model output due to MaxTokens parameter or token limit exceeded.";
                case ChatFinishReason.ContentFilter:
                    return "Omitted content due to a content filter flag.";
                case ChatFinishReason.Stop:
                    _prompt.AddAssistantMessage(new AssistantChatMessage(completion));
                    break;
                default:
                    throw new NotImplementedException("Unknown finish reason.");
            }
            return _prompt.GetSayResult();
        } while (requiresAction);
    }

    internal class Prompt
    {
        internal readonly List<UserChatMessage> userChatMessages = new();
        internal readonly List<SystemChatMessage> systemChatMessages = new();
        internal readonly List<AssistantChatMessage> assistantChatMessages = new();
        internal readonly List<ToolChatMessage> toolChatMessages = new();
        internal readonly List<ChatCompletion> chatCompletions = new();
        internal readonly List<ChatTool> _tools = new();
        internal readonly List<int> _factsAlreadyInPrompt = new List<int>();

        public Prompt()
        { }

        public IEnumerable<ChatMessage> Messages
        {
            get
            {
                foreach (var message in systemChatMessages)
                {
                    yield return message;
                }
                foreach (var message in userChatMessages)
                {
                    yield return message;
                }
                foreach (var message in assistantChatMessages)
                {
                    yield return message;
                }
                foreach (var message in toolChatMessages)
                {
                    yield return message;
                }
            }
        }

        //public ChatCompletionOptions Current => _prompt;
        public void AddTools(IEnumerable<ChatTool> tools)
        {
            foreach (var tool in tools)
            {
                _tools.Add(tool);
            }
        }
        public void AddFacts(IEnumerable<Fact> facts)
        {
            var sb = new StringBuilder();
            foreach (var fact in facts)
            {
                if (_factsAlreadyInPrompt.Contains(fact.Id))
                    continue;
                sb.AppendLine(fact.Text);
                _factsAlreadyInPrompt.Add(fact.Id);
            }
            if (sb.Length > 0)
            {
                systemChatMessages.Add(ChatMessage.CreateSystemMessage(sb.ToString()));
            }
        }
        public void AddUserMessage(string message)
        {
            userChatMessages.Add(ChatMessage.CreateUserMessage(message));
        }
        public void AddAssistantMessage(string message)
        {
            assistantChatMessages.Add(ChatMessage.CreateAssistantMessage(message));
        }
        public void AddAssistantMessage(AssistantChatMessage message)
        {
            assistantChatMessages.Add(message);
        }
        public void AddToolMessage(ToolChatMessage message)
        {
            toolChatMessages.Add(message);
        }

        internal string GetSayResult()
        {
            var result = string.Join("\n", assistantChatMessages.Select(m => m.Content[0].Text));
            assistantChatMessages.Clear();
            userChatMessages.Clear();
            systemChatMessages.Clear();
            return result;
        }
    }
}
