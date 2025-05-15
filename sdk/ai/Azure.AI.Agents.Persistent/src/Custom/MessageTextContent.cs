// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent;

/*
 * CUSTOM CODE DESCRIPTION:
 *
 * These changes facilitate the merging of superficial types introduced by the underlying REST wire format. The goal
 * is to avoid having types that contain nothing meaningful beyond a property to another type.
 */

public partial class MessageTextContent
{
    /// <inheritdoc cref="InternalMessageTextDetails.Text"/>
    public string Text => InternalDetails.Text;

    /// <inheritdoc cref="InternalMessageTextDetails.Annotations"/>
    public IReadOnlyList<MessageTextAnnotation> Annotations => (IReadOnlyList<MessageTextAnnotation>)InternalDetails.Annotations;

    internal InternalMessageTextDetails InternalDetails { get; }

    /// <summary> Initializes a new instance of <see cref="MessageTextContent"/>. </summary>
    /// <param name="internalDetails"> The text and associated annotations for this thread message content item. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="internalDetails"/> is null. </exception>
    internal MessageTextContent(InternalMessageTextDetails internalDetails)
    {
        Argument.AssertNotNull(internalDetails, nameof(internalDetails));

        Type = "text";
        InternalDetails = internalDetails;
    }
}
