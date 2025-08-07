// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.OpenAI.Assistants;

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
}
