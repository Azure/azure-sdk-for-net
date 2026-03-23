// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Internal implementation of <see cref="IPayloadValidator"/> that delegates
/// to the generated <see cref="CreateResponsePayloadValidator"/>.
/// </summary>
internal sealed class PayloadValidator : IPayloadValidator
{
    /// <inheritdoc/>
    public ValidationResult Validate(JsonElement element)
    {
        return CreateResponsePayloadValidator.Validate(element);
    }
}
