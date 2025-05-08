// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Agents.Persistent;

[CodeGenSerialization(nameof(StartedAt), DeserializationValueHook = nameof(DeserializeNullableDateTimeOffset))]
[CodeGenSerialization(nameof(ExpiresAt), DeserializationValueHook = nameof(DeserializeNullableDateTimeOffset))]
[CodeGenSerialization(nameof(CompletedAt), DeserializationValueHook = nameof(DeserializeNullableDateTimeOffset))]
[CodeGenSerialization(nameof(CancelledAt), DeserializationValueHook = nameof(DeserializeNullableDateTimeOffset))]
[CodeGenSerialization(nameof(FailedAt), DeserializationValueHook = nameof(DeserializeNullableDateTimeOffset))]
public partial class ThreadRun
{
    /*
    * CUSTOM CODE DESCRIPTION:
    *
    * This change allows us to complete the customization of hiding an unnecessary "Object" discriminator.
    */
    internal string Object { get; }

    /// <summary>
    /// The list of required actions that must have their results submitted for the run to continue.
    /// </summary>
    /// <remarks>
    /// <see cref="Azure.AI.Agents.Persistent.RequiredAction"/> is the abstract base type for all required actions. Its
    /// concrete type can be one of:
    /// <list type="bullet">
    /// <item> <see cref="RequiredFunctionToolCall"/> </item>
    /// </list>
    /// </remarks>
    public IReadOnlyList<RequiredFunctionToolCall> RequiredActions =>
    RequiredAction is SubmitToolOutputsAction submitToolOutputsAction
        ? submitToolOutputsAction.ToolCalls.OfType<RequiredFunctionToolCall>().ToList()
        : new List<RequiredFunctionToolCall>();

    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * "Required but nullable" utcDateTime doesn't emit the appropriate deserialization logic by default.
     *
     */

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void DeserializeNullableDateTimeOffset(
        JsonProperty property,
        ref DateTimeOffset? targetDateTimeOffset)
        => CustomSerializationHelpers.DeserializeNullableDateTimeOffset(property, ref targetDateTimeOffset);
}
