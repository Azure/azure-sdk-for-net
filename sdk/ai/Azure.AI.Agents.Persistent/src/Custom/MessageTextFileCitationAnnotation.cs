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

public partial class MessageTextFileCitationAnnotation
{
    /// <inheritdoc cref="InternalMessageTextFileCitationDetails.FileId"/>
    public string FileId => InternalDetails.FileId;

    /// <inheritdoc cref="InternalMessageTextFileCitationDetails.Quote"/>
    public string Quote => InternalDetails.Quote;

    internal InternalMessageTextFileCitationDetails InternalDetails { get; }

    /// <summary> Initializes a new instance of <see cref="MessageTextFileCitationAnnotation"/>. </summary>
    /// <param name="text"> The textual content associated with this text annotation item. </param>
    /// <param name="internalDetails">
    /// A citation within the message that points to a specific quote from a specific file.
    /// Generated when the agent uses the "file_search" tool to search files.
    /// </param>
    /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="internalDetails"/> is null. </exception>
    internal MessageTextFileCitationAnnotation(string text, InternalMessageTextFileCitationDetails internalDetails) : base(text)
    {
        Argument.AssertNotNull(text, nameof(text));
        Argument.AssertNotNull(internalDetails, nameof(internalDetails));

        Type = "file_citation";
        InternalDetails = internalDetails;
    }
}
