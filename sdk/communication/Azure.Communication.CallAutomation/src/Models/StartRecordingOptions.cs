// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Start Recording operation.
    /// </summary>
    public class StartRecordingOptions
    {
        /// <summary>
        /// Parameters for the Start Recording operation.
        /// </summary>
        /// <param name="callLocator"> . </param>
        public StartRecordingOptions(CallLocator callLocator)
        {
            CallLocator = callLocator ?? throw new ArgumentNullException(nameof(callLocator));
        }

        /// <summary>
        /// The callLocator.
        /// </summary>
        internal CallLocator CallLocator { get; }

        /// <summary>
        /// The callLocator.
        /// </summary>
        public Uri RecordingStateCallbackUri { get; set; }

        /// <summary>
        /// The recording channel.
        /// </summary>
        public RecordingChannel RecordingChannel { get; set; }

        /// <summary>
        /// The recording content.
        /// </summary>
        public RecordingContent RecordingContent { get; set; }

        /// <summary>
        /// The recording format.
        /// </summary>
        public RecordingFormat RecordingFormat { get; set; }

        /// <summary>
        /// The pause on start option.
        /// </summary>
        public bool PauseOnStart { get; set; }

        /// <summary>
        /// The sequential order in which audio channels are assigned to participants in the unmixed recording.
        /// When 'recordingChannelType' is set to 'unmixed' and `audioChannelParticipantOrdering is not specified,
        /// the audio channel to participant mapping will be automatically assigned based on the order in which participant
        /// first audio was detected.  Channel to participant mapping details can be found in the metadata of the recording.
        /// </summary>
        public IList<CommunicationIdentifier> AudioChannelParticipantOrdering { get; } =
            new List<CommunicationIdentifier>();

        /// <summary>
        /// The channel affinity of call recording
        /// When &apos;recordingChannelType&apos; is set to &apos;unmixed&apos;, if channelAffinity is not specified, &apos;channel&apos; will be automatically assigned.
        /// Channel-Participant mapping details can be found in the metadata of the recording.
        /// ///
        /// </summary>
        public IList<ChannelAffinity> ChannelAffinity { get; set; }

        /// <summary> (Optional) Used to specify external storage for call recording. </summary>
        public ExternalStorage ExternalStorage { get; set; }
    }
}
