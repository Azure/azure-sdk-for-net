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
    /// <summary> Determines whether a function tool definition matches the function tool call made by a run step. </summary>
    /// <param name="functionToolDefinition"> The function tool definition to compare. </param>
    /// <param name="functionToolCall"> The run step function tool call to compare. </param>
    /// <returns> <c>true</c> if both refer to the same function name; otherwise, <c>false</c>. </returns>
    public static bool operator ==(FunctionToolDefinition functionToolDefinition, RunStepFunctionToolCall functionToolCall)
        => functionToolDefinition.Name == functionToolCall.Name;

    /// <summary> Determines whether a function tool definition does not match the function tool call made by a run step. </summary>
    /// <param name="functionToolDefinition"> The function tool definition to compare. </param>
    /// <param name="functionToolCall"> The run step function tool call to compare. </param>
    /// <returns> <c>true</c> if the two refer to different function names; otherwise, <c>false</c>. </returns>
    public static bool operator !=(FunctionToolDefinition functionToolDefinition, RunStepFunctionToolCall functionToolCall)
        => functionToolDefinition.Name != functionToolCall.Name;

    /// <summary> Determines whether the function tool call made by a run step matches a function tool definition. </summary>
    /// <param name="functionToolCall"> The run step function tool call to compare. </param>
    /// <param name="functionToolDefinition"> The function tool definition to compare. </param>
    /// <returns> <c>true</c> if both refer to the same function name; otherwise, <c>false</c>. </returns>
    public static bool operator ==(RunStepFunctionToolCall functionToolCall, FunctionToolDefinition functionToolDefinition)
        => functionToolCall.Name == functionToolDefinition.Name;

    /// <summary> Determines whether the function tool call made by a run step does not match a function tool definition. </summary>
    /// <param name="functionToolCall"> The run step function tool call to compare. </param>
    /// <param name="functionToolDefinition"> The function tool definition to compare. </param>
    /// <returns> <c>true</c> if the two refer to different function names; otherwise, <c>false</c>. </returns>
    public static bool operator !=(RunStepFunctionToolCall functionToolCall, FunctionToolDefinition functionToolDefinition)
        => functionToolCall.Name != functionToolDefinition.Name;

    /// <summary> Determines whether a function tool definition matches a function tool call the run requires output for. </summary>
    /// <param name="functionToolDefinition"> The function tool definition to compare. </param>
    /// <param name="functionToolCall"> The required function tool call to compare. </param>
    /// <returns> <c>true</c> if both refer to the same function name; otherwise, <c>false</c>. </returns>
    public static bool operator ==(FunctionToolDefinition functionToolDefinition, RequiredFunctionToolCall functionToolCall)
        => functionToolDefinition.Name == functionToolCall.Name;

    /// <summary> Determines whether a function tool definition does not match a function tool call the run requires output for. </summary>
    /// <param name="functionToolDefinition"> The function tool definition to compare. </param>
    /// <param name="functionToolCall"> The required function tool call to compare. </param>
    /// <returns> <c>true</c> if the two refer to different function names; otherwise, <c>false</c>. </returns>
    public static bool operator !=(FunctionToolDefinition functionToolDefinition, RequiredFunctionToolCall functionToolCall)
        => functionToolDefinition.Name != functionToolCall.Name;

    /// <summary> Determines whether a function tool call the run requires output for matches a function tool definition. </summary>
    /// <param name="functionToolCall"> The required function tool call to compare. </param>
    /// <param name="functionToolDefinition"> The function tool definition to compare. </param>
    /// <returns> <c>true</c> if both refer to the same function name; otherwise, <c>false</c>. </returns>
    public static bool operator ==(RequiredFunctionToolCall functionToolCall, FunctionToolDefinition functionToolDefinition)
        => functionToolCall.Name == functionToolDefinition.Name;

    /// <summary> Determines whether a function tool call the run requires output for does not match a function tool definition. </summary>
    /// <param name="functionToolCall"> The required function tool call to compare. </param>
    /// <param name="functionToolDefinition"> The function tool definition to compare. </param>
    /// <returns> <c>true</c> if the two refer to different function names; otherwise, <c>false</c>. </returns>
    public static bool operator !=(RequiredFunctionToolCall functionToolCall, FunctionToolDefinition functionToolDefinition)
        => functionToolCall.Name != functionToolDefinition.Name;

    /// <inheritdoc/>
    public override bool Equals(object obj)
        => (obj is FunctionToolDefinition toolDefinition && Name == toolDefinition.Name)
            || (obj is RunStepFunctionToolCall runStepToolCall && Name == runStepToolCall.Name)
            || (obj is RequiredFunctionToolCall requiredToolCall && Name == requiredToolCall.Name);

    /// <inheritdoc/>
    public override int GetHashCode() => InternalFunction.GetHashCode();
}
