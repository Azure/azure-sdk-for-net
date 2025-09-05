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

public partial class MessageImageFileContent
{
    /// <inheritdoc cref="InternalMessageImageFileDetails.InternalDetails"/>
    public string FileId => InternalDetails.InternalDetails;

    internal InternalMessageImageFileDetails InternalDetails { get; }

    /// <summary> Initializes a new instance of <see cref="MessageImageFileContent"/>. </summary>
    /// <param name="internalDetails"> The image file for this thread message content item. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalDetails"/> is null. </exception>
    internal MessageImageFileContent(InternalMessageImageFileDetails internalDetails)
    {
        Argument.AssertNotNull(internalDetails, nameof(internalDetails));

        Type = "image_file";
        InternalDetails = internalDetails;
    }
}
