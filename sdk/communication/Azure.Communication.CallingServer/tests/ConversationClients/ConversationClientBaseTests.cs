// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.CallingServer.Tests.ConversationClients
{
    public class ConversationClientBaseTests
    {
        private const string dummyAccessKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9+eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ+SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV+adQssw5c=";
        public  ConversationClient CreateMockConversationClient(int statusCode, object? content = null, HttpHeader[]? httpHeaders = null)
        {
            var uri = new Uri("https://acs.dummyresource.com");
            var communicationTokenCredential =
                new AzureKeyCredential(dummyAccessKey);
            var mockResponse = new MockResponse(statusCode);
            if (content != null)
            {
                if (content.GetType() == typeof(string))
                    mockResponse.SetContent((string)content);
                else if (content.GetType() == typeof(byte[]))
                    mockResponse.SetContent((byte[])content);
            }

            if (httpHeaders != null)
            {
                for (int i = 0; i < httpHeaders.Length; i++)
                {
                    mockResponse.AddHeader(httpHeaders[i]);
                }
            }

            var callClientOptions = new CallClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            var convClient = new ConversationClient(uri, communicationTokenCredential, callClientOptions);
            return convClient;
        }

        public ConversationClient CreateMockConversationClient(MockResponse[] mockResponses)
        {
            var uri = new Uri("https://acs.dummyresource.com");
            var communicationTokenCredential =
                new AzureKeyCredential(dummyAccessKey);

            var callClientOptions = new CallClientOptions
            {
                Transport = new MockTransport(mockResponses)
            };

            var convClient = new ConversationClient(uri, communicationTokenCredential, callClientOptions);
            return convClient;
        }
    }
}
