// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class ServiceBusTestBase
    {
        protected static string ConnString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONN_STRING", EnvironmentVariableTarget.Machine);
        protected static string TenantId = Environment.GetEnvironmentVariable("TENANT_ID", EnvironmentVariableTarget.Machine);
        protected static string ClientId = Environment.GetEnvironmentVariable("CLIENT_ID", EnvironmentVariableTarget.Machine);
        protected static string ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET", EnvironmentVariableTarget.Machine);
        protected const string QueueName = "josh";
        protected const string SessionQueueName = "joshsession";
        protected const string TopicName = "joshtopic";
        protected const string Endpoint = "jolovservicebus.servicebus.windows.net";

        protected IEnumerable<ServiceBusMessage> GetMessages(int count, string sessionId = null, string partitionKey = null)
        {
            var messages = new List<ServiceBusMessage>();
            for (int i = 0; i < count; i++)
            {
                messages.Add(GetMessage(sessionId, partitionKey));
            }
            return messages;
        }

        protected ServiceBusMessage GetMessage(string sessionId = null, string partitionKey = null)
        {
            var msg = new ServiceBusMessage(GetRandomBuffer(100))
            {
                Label = $"test-{Guid.NewGuid()}",
                MessageId = Guid.NewGuid().ToString()
            };
            if (sessionId != null)
            {
                msg.SessionId = sessionId;
            }
            if (partitionKey != null)
            {
                msg.PartitionKey = partitionKey;
            }
            return msg;
        }

        protected byte[] GetRandomBuffer(long size)
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
    }
}
