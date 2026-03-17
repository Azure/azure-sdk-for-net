// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// A single validation error with a JSON path and human-readable message.
/// </summary>
/// <param name="Path">The JSON path to the invalid field (e.g., <c>$.model</c>, <c>$.tools[0].type</c>).</param>
/// <param name="Message">A human-readable description of the constraint that was violated.</param>
public sealed record ValidationError(string Path, string Message);
