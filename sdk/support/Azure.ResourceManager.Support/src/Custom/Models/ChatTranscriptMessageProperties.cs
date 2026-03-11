// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Support.Models
{
    /// <summary> Backward-compatible ContentType property returning TranscriptContentType. </summary>
    public partial class ChatTranscriptMessageProperties
    {
        /// <summary> Content type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TranscriptContentType? ContentType => ContentTypeValue != null ? new TranscriptContentType(ContentTypeValue) : null;
    }
}
