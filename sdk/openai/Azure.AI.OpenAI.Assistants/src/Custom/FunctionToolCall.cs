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

public partial class FunctionToolCall
{
    /// <inheritdoc cref="InternalFunctionToolCallDetails.Name"/>
    public string Name => InternalDetails.Name;

    /// <inheritdoc cref="InternalFunctionToolCallDetails.Arguments"/>
    public string Arguments => InternalDetails.Arguments;

    /// <inheritdoc cref="InternalFunctionToolCallDetails.Output"/>
    public string Output => InternalDetails.Output;

    internal InternalFunctionToolCallDetails InternalDetails { get; }
}
