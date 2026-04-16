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

public partial class MessageTextFilePathAnnotation : MessageTextAnnotation
{
    /// <inheritdoc cref="InternalMessageTextFilePathDetails.FileId"/>
    public string FileId => InternalDetails.FileId;

    internal InternalMessageTextFilePathDetails InternalDetails { get; }

    /// <summary> Initializes a new instance of <see cref="MessageTextFilePathAnnotation"/>. </summary>
    /// <param name="text"> The textual content associated with this text annotation item. </param>
    /// <param name="internalDetails"> A URL for the file that's generated when the agent used the code_interpreter tool to generate a file. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="internalDetails"/> is null. </exception>
    internal MessageTextFilePathAnnotation(string text, InternalMessageTextFilePathDetails internalDetails) : base(text)
    {
        Argument.AssertNotNull(text, nameof(text));
        Argument.AssertNotNull(internalDetails, nameof(internalDetails));

        Type = "file_path";
        InternalDetails = internalDetails;
    }
}
