// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Messaging.WebPubSub.Chat.Tests
{
    public class WebPubSubChatTestEnvironment : TestEnvironment
    {
        public string ConnectionString => GetRecordedVariable("WPS_CHAT_CONNECTION_STRING", options => options.HasSecretConnectionStringParameter("accessKey", SanitizedValue.Base64));

        public string Endpoint => GetRecordedVariable("WPS_CHAT_ENDPOINT");
    }
}
