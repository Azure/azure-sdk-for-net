// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;
using OpenAI;

namespace Azure.AI.Projects.Agents;

[CodeGenSuppress("VoiceConversationItem")]
public abstract partial class VoiceConversationItem
{
    private protected VoiceConversationItem() : base(default(RealtimeConversationItemType))
    {
    }
}
