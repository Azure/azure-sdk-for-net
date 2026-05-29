// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.AgentServer.Responses.Models;

/// <summary>
/// Customization stub that maps the generated <c>ConversationParam2</c> to <see cref="ConversationParam"/>.
/// </summary>
[CodeGenType("ConversationParam2")]
public partial class ConversationParam { }

/// <summary>
/// Customization stub that maps the generated <c>CustomToolCallResource</c> to <see cref="OutputItemCustomToolCall"/>.
/// </summary>
[CodeGenType("CustomToolCallResource")]
public partial class OutputItemCustomToolCall { }

/// <summary>
/// Customization stub that maps the generated <c>CustomToolCallOutputResource</c> to <see cref="OutputItemCustomToolCallOutput"/>.
/// </summary>

[CodeGenType("CustomToolCallOutputResource")]
public partial class OutputItemCustomToolCallOutput { }

/// <summary>
/// Customization stub that converts the generated <c>ResponseErrorCode</c> enum to an extensible
/// struct, allowing additional error codes (e.g., <c>storage_error</c>) beyond the spec-defined set.
/// </summary>
[CodeGenType("ResponseErrorCode")]
public readonly partial struct ResponseErrorCode { }
