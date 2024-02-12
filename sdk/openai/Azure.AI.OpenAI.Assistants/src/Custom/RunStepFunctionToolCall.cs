// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI.Assistants;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * These changes facilitate the merging of superficial types introduced by the underlying REST wire format. The goal
 * is to avoid having types that contain nothing meaningful beyond a property to another type.
 */

public partial class RunStepFunctionToolCall
{
    /// <inheritdoc cref="InternalRunStepFunctionToolCallDetails.Name"/>
    public string Name => InternalDetails.Name;

    /// <inheritdoc cref="InternalRunStepFunctionToolCallDetails.Arguments"/>
    public string Arguments => InternalDetails.Arguments;

    /// <inheritdoc cref="InternalRunStepFunctionToolCallDetails.Output"/>
    public string Output => InternalDetails.Output;

    internal InternalRunStepFunctionToolCallDetails InternalDetails { get; }
}
