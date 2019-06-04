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
        private static readonly string _nl = Environment.NewLine;

        [Test]
        public async Task FormatsResponse()
        {
            var formattedResponse =
                "Service request failed." + _nl +
                "Status: 210 (Reason)" + _nl +
                _nl +
                "Headers:" + _nl +
                "Custom-Header: Value" + _nl +
                "x-ms-requestId: 123" + _nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));

            var exception = await response.CreateRequestFailedExceptionAsync();
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public async Task FormatsResponseContentForTextContentTypes()
        {
            var formattedResponse =
                "Service request failed." + _nl +
                "Status: 210 (Reason)" + _nl +
                _nl +
                "Content:" + _nl +
                "{\"errorCode\": 1}" + _nl +
                _nl +
                "Headers:" + _nl +
                "Content-Type: text/json" + _nl +
                "x-ms-requestId: 123" + _nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));
            response.SetContent("{\"errorCode\": 1}");

            var exception = await response.CreateRequestFailedExceptionAsync();
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public async Task DoesntFormatsResponseContentForNonTextContentTypes()
        {
            var formattedResponse =
                "Service request failed." + _nl +
                "Status: 210 (Reason)" + _nl +
                _nl +
                "Headers:" + _nl +
                "Content-Type: binary" + _nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Content-Type", "binary"));
            response.SetContent("{\"errorCode\": 1}");

            var exception = await response.CreateRequestFailedExceptionAsync();
            Assert.AreEqual(formattedResponse, exception.Message);
        }
    }
}
