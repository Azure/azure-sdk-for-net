// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("LocalShellToolCallOutputItemResource")]
public partial class LocalShellToolCallOutputAgentResponseItem
{
    /// <summary> Gets the Status. </summary>
    [CodeGenMember("Status")]
    public LocalShellAgentToolCallStatus Status { get; }
}
