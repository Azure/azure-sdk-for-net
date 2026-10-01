// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Extensions.OpenAI;

public partial class ProjectConversation
{
    private string Object { get; } = "conversation";

    /// <summary> Gets the conversation metadata. </summary>
    public IDictionary<string, string> Metadata { get; }

    /// <summary> Gets the conversation identifier. </summary>
    public static implicit operator string(ProjectConversation conversation) => conversation.Id;
}
