// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Support.Models
{
    // Backward-compatible ContentType property returning TranscriptContentType, needed for ApiCompat with old API surface
    public partial class ChatTranscriptMessageProperties
    {
        /// <summary> Content type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TranscriptContentType? ContentType => TranscriptContentType != null ? new TranscriptContentType(TranscriptContentType) : null;
    }
}
