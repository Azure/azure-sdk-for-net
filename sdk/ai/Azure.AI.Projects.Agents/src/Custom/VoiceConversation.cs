// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Agents;

public partial class VoiceConversation
{
    /// <summary> The terminal error that prevented persistence finalization. Present only when `status` is `failed`. </summary>
    internal FoundryOpenAIError LastError { get; }
}
