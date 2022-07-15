// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.CallingServer.Models
{
    /// <summary> The PlaySource. </summary>
    public class PlaySource
    {
        /// <summary> Initializes a new instance of PlaySourceInternal. </summary>
        /// <param name="sourceType"> Defines the type of the play source. </param>
        /// <param name="playSourceId"> Defines the identifier to be used for caching related media. </param>
        public PlaySource(PlaySourceType sourceType, string playSourceId = default)
        {
            SourceType = sourceType;
            PlaySourceId = playSourceId;
        }

        /// <summary> Defines the type of the play source. </summary>
        public PlaySourceType SourceType { get; set; }
        /// <summary> Defines the identifier to be used for caching related media. </summary>
        public string PlaySourceId { get; set; }
    }
}
