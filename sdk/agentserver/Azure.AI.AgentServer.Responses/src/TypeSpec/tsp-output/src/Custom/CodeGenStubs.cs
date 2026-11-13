// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Customization stub that maps the generated <c>ConversationParam2</c> to <see cref="ConversationParam"/>.
/// </summary>
// Internal: no public member exposes it; OpenAI's ResponseConversationOptions is the public type.
[CodeGenType("ConversationParam2")]
internal partial class ConversationParam { }

// Internal: the emitter keeps these public only because its own OutputItemMessage /
// OutputItemReasoningItem reference them; the SDK aliases those to OpenAI's
// MessageResponseItem / ReasoningResponseItem, so no public member exposes them.
internal abstract partial class MessageContent { }

internal partial class SummaryTextContent { }
