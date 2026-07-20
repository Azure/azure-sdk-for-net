// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Validators;

/// <summary>
/// Custom validation rules for <see cref="ItemValidator"/>.
/// When the "type" discriminator is missing, defaults to "message" validation.
/// This is a server-side convenience — the OpenAPI spec requires "type", but
/// this SDK treats it as optional and falls back to message semantics.
/// </summary>
internal static partial class ItemValidator
{
    static partial void ResolveDefaultDiscriminator(JsonElement element, ref string? defaultType)
    {
        // When "type" is absent, treat the item as a message.
        defaultType = "message";
    }
}
