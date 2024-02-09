// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.OpenAI.Assistants;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * These additions simply allow easy comparison between tool calls and tool definitions.
 */

public partial class FunctionToolDefinition
{
    public static bool operator ==(FunctionToolDefinition functionToolDefinition, RunStepFunctionToolCall functionToolCall)
        => functionToolDefinition.Name == functionToolDefinition.Name;

    public static bool operator !=(FunctionToolDefinition functionToolDefinition, RunStepFunctionToolCall functionToolCall)
        => functionToolDefinition.Name != functionToolDefinition.Name;

    public static bool operator ==(RunStepFunctionToolCall functionToolCall, FunctionToolDefinition functionToolDefinition)
    => functionToolCall.Name == functionToolDefinition.Name;

    public static bool operator !=(RunStepFunctionToolCall functionToolCall, FunctionToolDefinition functionToolDefinition)
        => functionToolCall.Name != functionToolDefinition.Name;

    public static bool operator ==(FunctionToolDefinition functionToolDefinition, RequiredFunctionToolCall functionToolCall)
    => functionToolDefinition.Name == functionToolDefinition.Name;

    public static bool operator !=(FunctionToolDefinition functionToolDefinition, RequiredFunctionToolCall functionToolCall)
        => functionToolDefinition.Name != functionToolDefinition.Name;

    public static bool operator ==(RequiredFunctionToolCall functionToolCall, FunctionToolDefinition functionToolDefinition)
    => functionToolCall.Name == functionToolDefinition.Name;

    public static bool operator !=(RequiredFunctionToolCall functionToolCall, FunctionToolDefinition functionToolDefinition)
        => functionToolCall.Name != functionToolDefinition.Name;

    /// <inheritdoc/>
    public override bool Equals(object obj)
        => ReferenceEquals(this, obj) ? true : ReferenceEquals(obj, null) ? false : throw new NotImplementedException();

    /// <inheritdoc/>
    public override int GetHashCode() => InternalFunction.GetHashCode();
}
