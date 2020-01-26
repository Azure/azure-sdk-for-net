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
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Microsoft.Azure.Template.Tests
{
    public class UnitTest1
    {
        private const string connString = "Endpoint=sb://jolovservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8DpESoih0l9howBiNh24DeNt3TEF9CMtrgx/8zica9I=";

        [Test]
        public async Task Send_ConnString()
        {
            var sender = new ServiceBusSenderClient(connString, "josh");
            await sender.SendAsync(GetMessages(10));
        }

        [Test]
        public async Task Send_Token()
        {
            ClientSecretCredential credential = new ClientSecretCredential("72f988bf-86f1-41af-91ab-2d7cd011db47", "1cd5e275-c1e0-4fd1-b71d-ceb4028b473b", "C-.xTBnWPCSKwvY1lE:RzrhWzqA2P_38");

            var sender = new ServiceBusSenderClient("jolovservicebus.servicebus.windows.net", "josh", credential);
            await sender.SendAsync(GetMessage());
        }

        [Test]
        public async Task Send_Connection_Topic()
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

        [Test]
        public async Task Send_Topic_Session()
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
            var sender = new ServiceBusSenderClient(connString, "josh");
            await sender.SendAsync(GetMessages(10));

            var receiver = new ServiceBusReceiverClient(connString, "josh");
            var msgs = await receiver.ReceiveAsync(0, 10);
            int ct = 0;
            foreach (ServiceBusMessage msg in msgs)
            {
                var text = Encoding.Default.GetString(msg.Body);
                TestContext.Progress.WriteLine($"#{++ct} - {msg.Label}: {text}");
            }
        }

        [Test]
        public async Task Peek()
        {
            var sender = new ServiceBusSenderClient(connString, "josh");
            await sender.SendAsync(GetMessages(10));

            var receiver = new ServiceBusReceiverClient(connString, "josh");
            var msgs = await receiver.PeekAsync(1, 10);
            int ct = 0;
            foreach (ServiceBusMessage msg in msgs)
            {
                var text = Encoding.Default.GetString(msg.Body);
                TestContext.Progress.WriteLine($"#{++ct} - {msg.Label}: {text}");
            }
        }


        private ServiceBusMessage GetMessage()
        {
            return new ServiceBusMessage(GetRandomBuffer(100))
            {
                Label = $"test-{Guid.NewGuid()}"
            };
        }

        private byte[] GetRandomBuffer(long size)
        {
            var chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

            var csp = new RNGCryptoServiceProvider();
            var bytes = new byte[4];
            csp.GetBytes(bytes);
            var random = new Random(BitConverter.ToInt32(bytes, 0));
            var buffer = new byte[size];
            random.NextBytes(buffer);
            var text = new byte[size];
            for (int i = 0; i < size; i++)
            {
                var idx = buffer[i] % chars.Length;
                text[i] = (byte)chars[idx];
            }
            return text;
        }

        private IEnumerable<ServiceBusMessage> GetMessages(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return GetMessage();
            }
        }
    }
}
