// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.VoiceLive
{
    /// <summary> An audio content part for a request. </summary>
    public partial class RequestAudioContentPart : VoiceLiveContentPart
    {
        /// <summary> Initializes a new instance of <see cref="RequestAudioContentPart"/>. </summary>
        public RequestAudioContentPart() : base(ContentPartType.InputAudio)
        {
        }
    }
}
