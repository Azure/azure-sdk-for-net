// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
     /// The CallingServer Event Base.
     /// </summary>
    public abstract class CallingServerEventBase
    {
        /// <summary> Gets the Event type. </summary>
        [CodeGenMember("Type")]
        public AcsEventType EventType { get; set; }
    }
}
