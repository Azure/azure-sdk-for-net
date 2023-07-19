// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Schema of the Data property of an EventGridEvent for a Microsoft.Communication.RecordingFileStatusUpdated event. </summary>
    public partial class AcsRecordingFileStatusUpdatedEventData
    {
        /// <summary> The recording content type- AudioVideo, or Audio. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecordingContentType? RecordingContentType
        {
            get
            {
                // ContentType is read-only so we can safely cache the value
                if (ContentType != null && _recordingContentType == null)
                {
                    _recordingContentType = new RecordingContentType(ContentType.Value.ToString());
                }

                return _recordingContentType;
            }
        }
        private RecordingContentType? _recordingContentType;
        /// <summary> The recording  channel type - Mixed, Unmixed. </summary>

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecordingChannelType? RecordingChannelType
        {
            get
            {
                // ChannelType is read-only so we can safely cache the value
                if (ChannelType != null && _recordingChannelType == null)
                {
                    _recordingChannelType = new RecordingChannelType(ChannelType.Value.ToString());
                }

                return _recordingChannelType;
            }
        }
        private RecordingChannelType? _recordingChannelType;

        /// <summary> The recording format type - Mp4, Mp3, Wav. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RecordingFormatType? RecordingFormatType
        {
            get
            {
                // FormatType is read-only so we can safely cache the value
                if (FormatType != null && _recordingFormatType == null)
                {
                    _recordingFormatType = new RecordingFormatType(FormatType.Value.ToString());
                }

                return _recordingFormatType;
            }
        }
        private RecordingFormatType? _recordingFormatType;
    }
}
