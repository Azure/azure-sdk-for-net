// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.CallingServer.Tests
{
    public class TestBase
    {
        protected const string dummyAccessKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9+eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ+SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV+adQssw5c=";

        protected const string connectionString = "endpoint=https://contoso.azure.com/;accesskey=ZHVtbXlhY2Nlc3NrZXk=";

        protected const string CreateOrJoinCallPayload = "{" +
                                                 "\"callConnectionId\": \"cad9df7b-f3ac-4c53-96f7-c76e7437b3c1\"" +
                                                 "}";

        internal CallingServerClient CreateMockCallingServerClient(int responseCode, object? responseContent = null, HttpHeader[]? httpHeaders = null)
        {
            var mockResponse = new MockResponse(responseCode);

            if (responseContent != null)
            {
                if (responseContent.GetType() == typeof(string))
                    mockResponse.SetContent((string)responseContent);
                else if (responseContent.GetType() == typeof(byte[]))
                    mockResponse.SetContent((byte[])responseContent);
            }

            if (httpHeaders != null)
            {
                for (int i = 0; i < httpHeaders.Length; i++)
                {
                    mockResponse.AddHeader(httpHeaders[i]);
                }
            }

            var callingServerClientOptions = new CallingServerClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            return new CallingServerClient(connectionString, callingServerClientOptions);
        }

        internal CallingServerClient CreateMockCallingServerClient(MockResponse[] mockResponses)
        {
            var uri = new Uri("https://acs.dummyresource.com");
            var communicationTokenCredential =
                new AzureKeyCredential(dummyAccessKey);

            var callingServerClientOptions = new CallingServerClientOptions
            {
                Transport = new MockTransport(mockResponses)
            };

            var callingserverClient = new CallingServerClient(uri, communicationTokenCredential, callingServerClientOptions);
            return callingserverClient;
        }
    }
}
