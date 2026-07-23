// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenType("ConversationResource")]
public partial class ProjectConversation
{
    [CodeGenMember("Object")]
    private string Object { get; } = "conversation";

    /// <summary> Gets the metadata attached to the conversation. </summary>
    [CodeGenMember("Metadata")]
    public IDictionary<string, string> Metadata { get; }

    /// <summary> Converts a project conversation into its conversation ID. </summary>
    /// <param name="conversation"> The project conversation to convert. </param>
    /// <returns> The conversation ID. </returns>
    public static implicit operator string(ProjectConversation conversation) => conversation.Id;
}
