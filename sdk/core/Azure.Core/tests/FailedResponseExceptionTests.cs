// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class FailedResponseExceptionTests
    {
        private static readonly string s_nl = Environment.NewLine;

        [Test]
        public async Task FormatsResponse()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header: Value" + s_nl +
                "x-ms-requestId: 123" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));

            RequestFailedException exception = await response.CreateRequestFailedExceptionAsync();
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public async Task FormatsResponseContentForTextContentTypes()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Content:" + s_nl +
                "{\"errorCode\": 1}" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: text/json" + s_nl +
                "x-ms-requestId: 123" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));
            response.SetContent("{\"errorCode\": 1}");

            RequestFailedException exception = await response.CreateRequestFailedExceptionAsync();
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public async Task DoesntFormatsResponseContentForNonTextContentTypes()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Content-Type: binary" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Content-Type", "binary"));
            response.SetContent("{\"errorCode\": 1}");

            RequestFailedException exception = await response.CreateRequestFailedExceptionAsync();
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public async Task IncludesErrorCodeInMessageIfAvailable()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                "ErrorCode: CUSTOM CODE" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header: Value" + s_nl +
                "x-ms-requestId: 123" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));

            RequestFailedException exception = await response.CreateRequestFailedExceptionAsync(null, errorCode: "CUSTOM CODE");
            Assert.AreEqual(formattedResponse, exception.Message);
        }

    }
}
