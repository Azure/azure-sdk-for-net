// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Chat.Notifications.Models;
using Azure.Core;
//using Microsoft.Trouter;

namespace Azure.Communication.Chat.Notifications
{
    internal class CommunicationListener//: TrouterListener
    {
        private SyncAsyncEventHandler<ChatMessageReceivedEvent> _eventHandler;

        /// <summary>
        /// Implementation of TrouterListener
        /// </summary>
        /// <param name="eventHandler"></param>
        public CommunicationListener(SyncAsyncEventHandler<ChatMessageReceivedEvent> eventHandler)
        {
            _eventHandler = eventHandler;
        }

//        public override Task<TrouterResponse> ProcessRequestAsync(TrouterRequest request, CancellationToken cancellationToken = default)
//        {
//            ChatMessageReceivedEvent s = null;
//            if (request.Body != null)
//            {
//                var str = request.Body.ToString();
//                s = request.Body.ToObjectFromJson<ChatMessageReceivedEvent>();
//            }
//            _eventHandler(s);
//#pragma warning disable CA1303 // Do not pass literals as localized parameters
//            Console.WriteLine("this works");

//            Console.WriteLine("*******");
//#pragma warning restore CA1303 // Do not pass literals as localized parameters
//            // Avoid this trouter response return and may be have a void method
//            return Task.FromResult(new TrouterResponse { Body = new BinaryData("") });
//        }
    }
}
