// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallingServerTestBase
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
                if (responseContent is string responseContentString)
                {
                    mockResponse.SetContent(responseContentString);
                }
                else if (responseContent is byte[] responseContentObjectArr)
                {
                    mockResponse.SetContent(responseContentObjectArr);
                }
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
            var callingServerClientOptions = new CallingServerClientOptions
            {
                Transport = new MockTransport(mockResponses)
            };

            return new CallingServerClient(connectionString, callingServerClientOptions);
        }
    }
}
