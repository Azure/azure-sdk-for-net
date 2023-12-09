// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.OpenAI;

public partial class ChatMessageImageContentItem : ChatMessageContentItem
{
    // CUSTOM CODE NOTE:
    //   This addition allows the direct use of a Uri with the content item constructor rather than needing an
    //   intervening instantiation of the Image URL type.

    /// <summary> Initializes a new instance of ChatMessageImageContentItem using default detail. </summary>
    /// <param name="imageUri"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUri"/> is null. </exception>
    public ChatMessageImageContentItem(Uri imageUri)
        : this(new ChatMessageImageUrl(imageUri))
    { }

    /// <summary> Initializes a new instance of ChatMessageImageContentItem. </summary>
    /// <param name="imageUri"> An internet location, which must be accessible to the model,from which the image may be retrieved. </param>
    /// <param name="detailLevel"> The image detail level the model should use when evaluating the image. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="imageUri"/> is null. </exception>
    public ChatMessageImageContentItem(Uri imageUri, ChatMessageImageDetailLevel detailLevel)
        : this(imageUri)
    {
        ImageUrl.Detail = detailLevel;
    }
}
