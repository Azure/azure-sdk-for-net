// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Communication.Messages.Tests
{
    public class MessagesLiveTestBase : RecordedTestBase<MessagesTestEnvironment>
    {
        public MessagesLiveTestBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
        }

        protected NotificationMessagesClient CreateInstrumentedNotificationMessagesClient()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new NotificationMessagesClient(connectionString, InstrumentClientOptions(new CommunicationMessagesClientOptions()));

            return InstrumentClient(client);
        }

        protected NotificationMessagesClient CreateInstrumentedNotificationMessagesClientWithAzureKeyCredential()
        {
            var endpoint = TestEnvironment.LiveTestDynamicEndpoint;
            var accessKey = TestEnvironment.LiveTestDynamicAccessKey;
            var client = new NotificationMessagesClient(endpoint, new AzureKeyCredential(accessKey), InstrumentClientOptions(new CommunicationMessagesClientOptions()));

            return InstrumentClient(client);
        }

        protected MessageTemplateClient CreateInstrumentedMessageTemplateClient()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new MessageTemplateClient(connectionString, InstrumentClientOptions(new CommunicationMessagesClientOptions()));

            return InstrumentClient(client);
        }

        protected MessageTemplateClient CreateInstrumentedMessageTemplateClientWithAzureKeyCredential()
        {
            var endpoint = TestEnvironment.LiveTestDynamicEndpoint;
            var accessKey = TestEnvironment.LiveTestDynamicAccessKey;

            var client = new MessageTemplateClient(endpoint, new AzureKeyCredential(accessKey), InstrumentClientOptions(new CommunicationMessagesClientOptions()));

            return InstrumentClient(client);
        }
    }
}
