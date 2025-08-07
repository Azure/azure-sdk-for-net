// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.Agents.Persistent;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * These changes facilitate the merging of superficial types introduced by the underlying REST wire format. The goal
 * is to avoid having types that contain nothing meaningful beyond a property to another type.
 */

public partial class RequiredFunctionToolCall : RequiredToolCall
{
    /// <inheritdoc cref="InternalRequiredFunctionToolCallDetails.Name"/>
    public string Name => InternalDetails.Name;

    /// <inheritdoc cref="InternalRequiredFunctionToolCallDetails.Arguments"/>
    public string Arguments => InternalDetails.Arguments;

    internal InternalRequiredFunctionToolCallDetails InternalDetails { get; }
}
