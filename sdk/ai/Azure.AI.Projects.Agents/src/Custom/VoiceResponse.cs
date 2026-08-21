// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

public partial class VoiceResponse
{
    /// <summary> The unique id of the response. </summary>
    public new string Id { get; }

    /// <summary> The id of the conversation this response belongs to. </summary>
    public new string ConversationId { get; }
}
