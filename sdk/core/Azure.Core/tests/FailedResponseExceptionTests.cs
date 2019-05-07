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
                "Status: 210" + _nl +
                "ReasonPhrase: Reason" + _nl +
                _nl +
                "Headers:" + _nl +
                "Custom-Header: Value" + _nl +
                "x-ms-requestId: 123" + _nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));

            var exception = await RequestFailedException.CreateAsync(response);
            Assert.AreEqual("Request failed with status code 210", exception.Message);
            Assert.AreEqual(formattedResponse, exception.Response);
            Assert.AreEqual("Azure.RequestFailedException: " + exception.Message + _nl + exception.Response, exception.ToString());
        }

        [Test]
        public async Task FormatsResponseContentForTextContentTypes()
        {
            var formattedResponse =
                "Status: 210" + _nl +
                "ReasonPhrase: Reason" + _nl +
                _nl +
                "Headers:" + _nl +
                "Content-Type: text/json" + _nl +
                "x-ms-requestId: 123" + _nl +
                _nl +
                "Content:" + _nl +
                "{\"errorCode\": 1}" + _nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Content-Type", "text/json"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));
            response.SetContent("{\"errorCode\": 1}");

            var exception = await RequestFailedException.CreateAsync(response);
            Assert.AreEqual("Request failed with status code 210", exception.Message);
            Assert.AreEqual(formattedResponse, exception.Response);
            Assert.AreEqual("Azure.RequestFailedException: " + exception.Message + _nl + exception.Response, exception.ToString());
        }

        [Test]
        public async Task DoesntFormatsResponseContentForNonTextContentTypes()
        {
            var formattedResponse =
                "Status: 210" + _nl +
                "ReasonPhrase: Reason" + _nl +
                _nl +
                "Headers:" + _nl +
                "Content-Type: binary" + _nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Content-Type", "binary"));
            response.SetContent("{\"errorCode\": 1}");

            var exception = await RequestFailedException.CreateAsync(response);
            Assert.AreEqual("Request failed with status code 210", exception.Message);
            Assert.AreEqual(formattedResponse, exception.Response);
            Assert.AreEqual("Azure.RequestFailedException: " + exception.Message + _nl + exception.Response, exception.ToString());
        }
    }
}
