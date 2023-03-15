// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Chat.Notifications.Models;
using Azure.Core;

namespace Azure.Communication.Chat.Notifications
{
    internal class CommunicationListener
    {
        private ChatEventType _eventType;
        private RealTimeNotificationEventHandler _realTimeNotificationEventHandler;

        /// <summary>
        /// Implementation of TrouterListener
        /// </summary>
        /// <param name="chatEventType"></param>
        /// <param name="realTimeNotificationEventHandler"></param>
        public CommunicationListener(ChatEventType chatEventType, RealTimeNotificationEventHandler realTimeNotificationEventHandler)
        {
            _eventType = chatEventType;
            _realTimeNotificationEventHandler = realTimeNotificationEventHandler;
        }

        //public override async Task<TrouterResponse> ProcessRequestAsync(TrouterRequest request, CancellationToken cancellationToken = default)
        //{
        //    // call the event handler here
        //    await _realTimeNotificationEventHandler.InvokeChatMessageReceivedEvent(new ChatMessageReceivedEvent(false)).ConfigureAwait(false);

        //    // may be this should change
        //    return (new TrouterResponse());
        //}
    }
}
