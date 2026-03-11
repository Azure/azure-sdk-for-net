// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// Details of the message to send.
    /// </summary>
    public abstract partial class NotificationContent
    {
        /// <summary> Initializes a new instance of <see cref="NotificationContent"/>. </summary>
        /// <param name="channelRegistrationId"> The Channel Registration ID for the Business Identifier. </param>
        /// <param name="to"> The native external platform user identifiers of the recipient. </param>
        protected NotificationContent(Guid channelRegistrationId, IEnumerable<string> to)
            : this(channelRegistrationId, to, default(CommunicationMessageKind))
        {
        }
    }
}
