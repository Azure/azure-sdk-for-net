// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Internal interface for validating incoming request payloads.
/// </summary>
internal interface IPayloadValidator
{
    /// <summary>
    /// Validates a parsed JSON element representing a request payload.
    /// </summary>
    /// <param name="element">The JSON element to validate.</param>
    /// <returns>A <see cref="ValidationResult"/> indicating success or failure with errors.</returns>
    ValidationResult Validate(JsonElement element);
}
