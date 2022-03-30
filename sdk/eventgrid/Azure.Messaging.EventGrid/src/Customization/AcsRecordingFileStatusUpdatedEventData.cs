// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using BackCompat = Azure.Messaging.EventGrid.Models;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Schema of the Data property of an EventGridEvent for a Microsoft.Communication.RecordingFileStatusUpdated event. </summary>
    public partial class AcsRecordingFileStatusUpdatedEventData
    {
        /// <summary> The recording content type- AudioVideo, or Audio. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BackCompat.RecordingContentType? RecordingContentType
        {
            get
            {
                if (ContentType != null && _recordingContentType == null)
                {
                    _recordingContentType = new BackCompat.RecordingContentType(ContentType.Value.ToString());
                }

                return _recordingContentType;
            }
        }
        private BackCompat.RecordingContentType? _recordingContentType;
        /// <summary> The recording  channel type - Mixed, Unmixed. </summary>

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BackCompat.RecordingChannelType? RecordingChannelType
        {
            get
            {
                if (ChannelType != null && _recordingChannelType == null)
                {
                    _recordingChannelType = new BackCompat.RecordingChannelType(ChannelType.Value.ToString());
                }

                return _recordingChannelType;
            }
        }
        private BackCompat.RecordingChannelType? _recordingChannelType;

        /// <summary> The recording format type - Mp4, Mp3, Wav. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BackCompat.RecordingFormatType? RecordingFormatType
        {
            get
            {
                if (FormatType != null && _recordingFormatType == null)
                {
                    _recordingFormatType = new BackCompat.RecordingFormatType(FormatType.Value.ToString());
                }

                return _recordingFormatType;
            }
        }
        private BackCompat.RecordingFormatType? _recordingFormatType;
    }
}
