// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

public static class RunStepDetailsUpdateExtensions
{
    /// <summary>
    /// Gets a value indicating whether this <see cref="RunStepToolCall"/> instance represents a call to a <c>browser</c> tool.
    /// </summary>
    /// <param name="baseUpdate"> The base update. </param>
    /// <returns> True if the tool call represents a browser tool call, false otherwise. </returns>
    [Experimental("AOAI001")]
    public static bool IsBingSearchKind(this RunStepDetailsUpdate baseUpdate)
    {
        return baseUpdate?._toolCall?.Type == "browser";
    }
}
