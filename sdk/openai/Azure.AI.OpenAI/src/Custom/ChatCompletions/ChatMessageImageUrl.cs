// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI;

public partial class ChatMessageImageUrl
{
    // CUSTOM CODE NODE
    // To support DataUris and since System.Uri does not support DataUris with a content size > 64k
    // We will add a string field that allows for a already serialized DataUri

    /// <summary> Initializes a new instance of <see cref="ChatMessageImageUrl"/>. </summary>
    /// <param name="dataUri"> The DataUri of the image. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="dataUri"/> is null. </exception>
    public ChatMessageImageUrl(string dataUri)
    {
        Argument.AssertNotNull(dataUri, nameof(dataUri));

        DataUri = dataUri;
    }

    /// <summary> Initializes a new instance of <see cref="ChatMessageImageUrl"/>. </summary>
    /// <param name="dataUri"> The DataUri of the image. </param>
    /// <param name="detail">
    /// The evaluation quality setting to use, which controls relative prioritization of speed, token consumption, and
    /// accuracy.
    /// </param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    internal ChatMessageImageUrl(string dataUri, ChatMessageImageDetailLevel? detail, IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        DataUri = dataUri;
        Detail = detail;
        _serializedAdditionalRawData = serializedAdditionalRawData;
    }

    /// <summary> The DataUri of the image. </summary>
    public string DataUri { get; }
}
