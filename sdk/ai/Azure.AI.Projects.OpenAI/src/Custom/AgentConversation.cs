// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("ConversationResource")]
public partial class AgentConversation
{
    [CodeGenMember("Object")]
    private string Object { get; } = "conversation";

    public static implicit operator string(AgentConversation conversation) => conversation.Id;
}
