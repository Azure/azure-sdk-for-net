// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using Azure.Messaging.ServiceBus.Producer;
using Azure.Messaging.ServiceBus;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using System.Net;
using Azure.Messaging.ServiceBus.Consumer;

namespace Microsoft.Azure.Template.Tests
{
    public class UnitTest1
    {
        private const string connString = "Endpoint=sb://jolovservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8DpESoih0l9howBiNh24DeNt3TEF9CMtrgx/8zica9I=";

        [Test]
        public async Task Ctor_ConnString()
        {
            var sender = new ServiceBusSenderClient(connString, "josh");
            await sender.SendAsync(GetMessage());
        }

        [Test]
        public async Task Ctor_Token()
        {
            ClientSecretCredential credential = new ClientSecretCredential("72f988bf-86f1-41af-91ab-2d7cd011db47", "1cd5e275-c1e0-4fd1-b71d-ceb4028b473b", "C-.xTBnWPCSKwvY1lE:RzrhWzqA2P_38");

            var sender = new ServiceBusSenderClient("jolovservicebus.servicebus.windows.net", "josh", credential);
            await sender.SendAsync(GetMessage());
        }

        [Test]
        public async Task Ctor_Connection_Topic()
        {
            var conn = new ServiceBusConnection(connString, "joshtopic");
            var options = new ServiceBusSenderClientOptions
            {
                RetryOptions = new ServiceBusRetryOptions(),
                ConnectionOptions = new ServiceBusConnectionOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets,
                    Proxy = new WebProxy("localHost")
                }
            };
            options.RetryOptions.Mode = ServiceBusRetryMode.Exponential;
            var sender = new ServiceBusSenderClient(conn, options);

            await sender.SendAsync(GetMessage());
        }

        private ServiceBusMessage GetMessage(string text = "hello")
        {
            return new ServiceBusMessage(Encoding.UTF8.GetBytes(text))
            {
                Label = $"test-{Guid.NewGuid()}"
            };
        }

        [Test]
        public async Task Send_Session()
        {
            var conn = new ServiceBusConnection(connString, "joshtopic");
            var options = new ServiceBusSenderClientOptions
            {
                RetryOptions = new ServiceBusRetryOptions(),
                ConnectionOptions = new ServiceBusConnectionOptions()
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets,
                    Proxy = new WebProxy("localHost")
                }
            };
            options.RetryOptions.Mode = ServiceBusRetryMode.Exponential;
            var sender = new ServiceBusSenderClient(conn, options);
            var message = GetMessage();
            message.SessionId = "1";
            await sender.SendAsync(message);
        }

        [Test]
        public async Task Receive()
        {
            var receiver = new ServiceBusReceiverClient(connString, "josh");
            var msgs = receiver.ReceiveMessagesAsync(true);
            await foreach (var msg in msgs)
            {
                Console.WriteLine(msg);
            }
        }
    }
}
