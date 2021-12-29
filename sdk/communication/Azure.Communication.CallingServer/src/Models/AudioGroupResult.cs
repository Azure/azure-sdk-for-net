// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer.Models
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary> The call connection properties. </summary>
    public class AudioGroupResult
    {
        /// <summary> Initializes a new instance of AudioRoutingGroupResult. </summary>
        /// <param name="audioGroupResultInternal">The audio routing group result internal.</param>
        internal AudioGroupResult(AudioGroupResultInternal audioGroupResultInternal)
        {
            AudioRoutingMode = audioGroupResultInternal.AudioRoutingMode;
            Targets = audioGroupResultInternal.Targets.Select(t => CommunicationIdentifierSerializer.Deserialize(t));
        }

        /// <summary> The audio routing mode. </summary>
        public AudioRoutingMode? AudioRoutingMode { get; }

        /// <summary> The target identities that would be receivers in the audio routing group. </summary>
        public IEnumerable<CommunicationIdentifier> Targets { get; }
    }
}
