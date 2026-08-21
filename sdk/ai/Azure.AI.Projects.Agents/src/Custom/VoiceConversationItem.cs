// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Projects.Agents;

/// <summary> An item in a persisted voice-agent conversation. </summary>
[CodeGenSuppress("VoiceConversationItem")]
public abstract partial class VoiceConversationItem
{
    private protected VoiceConversationItem()
    {
    }
}
