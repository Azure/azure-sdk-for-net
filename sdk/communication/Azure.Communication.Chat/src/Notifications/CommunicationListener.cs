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
        private SyncAsyncEventHandler<ChatMessageReceivedEvent> _eventHandler;

        /// <summary>
        /// Implementation of TrouterListener
        /// </summary>
        /// <param name="chatEventType"></param>
        /// <param name="eventHandler"></param>
        public CommunicationListener(ChatEventType chatEventType, SyncAsyncEventHandler<ChatMessageReceivedEvent> eventHandler)
        {
            _eventType = chatEventType;
            _eventHandler = eventHandler;
        }

        private void ProcessRequest()
        {
            var s = new ChatMessageReceivedEvent(false);

            _eventHandler(s);
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
