// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Schema of common properties of all chat thread events. </summary>
    public partial class AcsMessageEventData
    {
        [CodeGenMember("Error")]
        internal AcsMessageChannelEventError ErrorInternal { get; }

        /// <summary>
        /// Gets the channel event error.
        /// </summary>
        public ResponseError Error
        {
            get
            {
                if (_error == null)
                {
                    _error = new ResponseError(ErrorInternal.ChannelCode, ErrorInternal.ChannelMessage);
                }
                return _error;
            }
        }
        private ResponseError _error;
    }
}
