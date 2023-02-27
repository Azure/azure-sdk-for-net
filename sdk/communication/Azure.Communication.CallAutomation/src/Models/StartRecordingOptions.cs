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
        public Uri RecordingStateCallbackEndpoint { get; set; }

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
        /// The sequential order in which audio channels are assigned to participants in the unmixed recording.
        /// When 'recordingChannelType' is set to 'unmixed' and `audioChannelParticipantOrdering is not specified,
        /// the audio channel to participant mapping will be automatically assigned based on the order in which participant
        /// first audio was detected.  Channel to participant mapping details can be found in the metadata of the recording.
        /// </summary>
        public IList<CommunicationIdentifier> AudioChannelParticipantOrdering { get; } =
            new List<CommunicationIdentifier>();

        /// <summary> Recording storage mode. `External` enables bring your own storage. </summary>
        public RecordingStorageType? RecordingStorageType { get; set; }

        /// <summary> The location where recording is stored, when RecordingStorageType is set to BlobStorage. </summary>
        public Uri ExternalStorageLocation { get; set; }
    }
}
