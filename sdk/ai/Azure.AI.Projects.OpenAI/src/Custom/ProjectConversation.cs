// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("ProjectConversation")]
public partial class ProjectConversation
{
    [CodeGenMember("Object")]
    private string Object { get; } = "conversation";

    [CodeGenMember("Metadata")]
    public IDictionary<string, string> Metadata { get; }

    public static implicit operator string(ProjectConversation conversation) => conversation.Id;
}
