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
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
#pragma warning disable CA1303
    internal class CommunicationSignalingClient
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
       // private TrouterClient _trouterClient;
        private bool _isRealTimeNotificationsStarted = true;
        private CommunicationTokenCredential _tokenCredential;

        internal CommunicationSignalingClient(CommunicationTokenCredential tokenCredential)
        {
            _tokenCredential = tokenCredential;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Start()
        {
            CreateTrouterService();
            //await _trouterClient.StartAsync().ConfigureAwait(false);
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
            //await _trouterClient.StopAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///
        /// </summary>
#pragma warning disable CA1822 // Mark members as static
        private void CreateTrouterService()
#pragma warning restore CA1822 // Mark members as static
        {
            //_trouterClient = new TrouterClient(new TestSkypetokenCredential(_tokenCredential.GetToken().Token), CreateTrouterClientOptions());
        }

        //private static TrouterClientOptions CreateTrouterClientOptions()
        //{
        //    var options = new TrouterClientOptions
        //    {
        //        ApplicationName = "Microsoft.Trouter.Tests",
        //        TrouterHostName = "go.trouter.skype.com",
        //        RegistrarHostName = "edge.skype.com/registrar/prod/v2/registrations",
        //        RegistrationOptions = new RegistrationOptions
        //        {
        //            EndpointId = "trouter_test",
        //            PlatformId = "SPOOL",
        //            PnhAppId = "AcsWeb",
        //            PnhTemplate = "AcsWeb_Chat_1.5",
        //        }
        //    };

        //    return options;
        //}
#pragma warning disable CA1822 // Mark members as static
        public void on(ChatEventType chatEventType, SyncAsyncEventHandler<ChatMessageReceivedEvent> eventHandler)
        {
            if (chatEventType.ToString() == ChatEventType.ChatMessageReceived.ToString())
            {
                var listener = new CommunicationListener(chatEventType, eventHandler);
                Console.WriteLine("Registering event handler");
                //_trouterClient.RegisterListener("/chatMessageReceived", listener);
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
    //    internal class TrouterClient
    //#pragma warning restore SA1402 // File may only contain a single type
    //    {
    //        private readonly string _chatEventType = "";
    //        internal async Task StartAsync()
    //        {
    //            await Console.Out.WriteLineAsync(_chatEventType).ConfigureAwait(false);
    //        }
    //    }

//    internal sealed class TestSkypetokenCredential : SkypetokenCredential
//    {
//        private string _token;

//        public TestSkypetokenCredential(string token)
//        {
//            _token = token;
//        }

//#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
//        public override async Task<Skypetoken> GetTokenAsync(CancellationToken cancellationToken = default)
//#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
//        {
//            return new Skypetoken(_token);
//        }
//    }
}
