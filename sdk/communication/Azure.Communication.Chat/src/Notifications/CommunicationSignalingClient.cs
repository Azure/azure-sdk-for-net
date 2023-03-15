// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Chat.Notifications.Models;

namespace Azure.Communication.Chat.Notifications
{
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    internal class CommunicationSignalingClient
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private TrouterClient _trouterClient;
        private bool _isRealTimeNotificationsStarted;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            await _trouterClient.StartAsync().ConfigureAwait(false);
            _isRealTimeNotificationsStarted = true;
            CreateTrouterService();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task Stop()
        {
            if (!_isRealTimeNotificationsStarted)
            {
                return;
            }
            await _trouterClient.StartAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///
        /// </summary>
        private void CreateTrouterService()
        {
            _trouterClient = new TrouterClient();
        }
#pragma warning disable CA1822 // Mark members as static
        public void on(ChatEventType chatEventType, RealTimeNotificationEventHandler realTimeNotificationEventHandler)
        {
            if (chatEventType == ChatEventType.ChatMessageReceived)
            {
                var listener = new CommunicationListener(chatEventType, realTimeNotificationEventHandler);

                //_trouterClient.RegisterListener("", listener);
            }
        }

        public void off(ChatEventType chatEventType)
#pragma warning restore CA1822 // Mark members as static
        {
            //_trouterClient.UnregisterListener(null);
            Console.WriteLine(chatEventType);
            //_trouterClient.UnregisterListener(realTimeNotificationEventHandler);
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class TrouterClient
#pragma warning restore SA1402 // File may only contain a single type
    {
        private readonly string _chatEventType = "";
        internal async Task StartAsync()
        {
            await Console.Out.WriteLineAsync(_chatEventType).ConfigureAwait(false);
        }
    }
}
