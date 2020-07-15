// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class FailedResponseExceptionTests
    {
        private static readonly string s_nl = Environment.NewLine;
        private static ClientDiagnostics ClientDiagnostics = new ClientDiagnostics(new TestClientOption());

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

            RequestFailedException exception = await ClientDiagnostics.CreateRequestFailedExceptionAsync(response);
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public async Task HeadersAreSanitized()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header-2: REDACTED" + s_nl +
                "x-ms-requestId-2: REDACTED" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header-2", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId-2", "123"));

            RequestFailedException exception = await ClientDiagnostics.CreateRequestFailedExceptionAsync(response);
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

            RequestFailedException exception = await ClientDiagnostics.CreateRequestFailedExceptionAsync(response);
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

            RequestFailedException exception = await ClientDiagnostics.CreateRequestFailedExceptionAsync(response);
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

            RequestFailedException exception = await ClientDiagnostics.CreateRequestFailedExceptionAsync(response, errorCode: "CUSTOM CODE");
            Assert.AreEqual(formattedResponse, exception.Message);
        }

        [Test]
        public async Task IncludesAdditionalInformationIfAvailable()
        {
            var formattedResponse =
                "Service request failed." + s_nl +
                "Status: 210 (Reason)" + s_nl +
                s_nl +
                "Additional Information:" + s_nl +
                "a: a-value" + s_nl +
                "b: b-value" + s_nl +
                s_nl +
                "Headers:" + s_nl +
                "Custom-Header: Value" + s_nl +
                "x-ms-requestId: 123" + s_nl;

            var response = new MockResponse(210, "Reason");
            response.AddHeader(new HttpHeader("Custom-Header", "Value"));
            response.AddHeader(new HttpHeader("x-ms-requestId", "123"));

            RequestFailedException exception = await ClientDiagnostics.CreateRequestFailedExceptionAsync(response, additionalInfo: new Dictionary<string, string>()
            {
                {"a", "a-value"},
                {"b", "b-value"},
            });

            Assert.AreEqual(formattedResponse, exception.Message);
            Assert.AreEqual("a-value", exception.Data["a"]);
            Assert.AreEqual("b-value", exception.Data["b"]);
        }

        [Test]
        public async Task IncludesInnerException()
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

            var innerException = new Exception();
            RequestFailedException exception = await ClientDiagnostics.CreateRequestFailedExceptionAsync(response, innerException: innerException);
            Assert.AreEqual(formattedResponse, exception.Message);
            Assert.AreEqual(innerException, exception.InnerException);
        }

        [Test]
        public void RequestFailedExceptionIsSerializeable()
        {
            var dataContractSerializer = new DataContractSerializer(typeof(RequestFailedException));
            var exception = new RequestFailedException(201, "Message", "Error", null);
            RequestFailedException deserialized;
            using var memoryStream = new MemoryStream();
            dataContractSerializer.WriteObject(memoryStream, exception);
            memoryStream.Position = 0;
            deserialized = (RequestFailedException) dataContractSerializer.ReadObject(memoryStream);

            Assert.AreEqual(exception.Message, deserialized.Message);
            Assert.AreEqual(exception.Status, deserialized.Status);
            Assert.AreEqual(exception.ErrorCode, deserialized.ErrorCode);
        }

        private class TestClientOption : ClientOptions
        {
            public TestClientOption()
            {
                Diagnostics.LoggedHeaderNames.Add("x-ms-requestId");
                Diagnostics.LoggedHeaderNames.Add("Content-Type");
                Diagnostics.LoggedHeaderNames.Add("Custom-Header");
                Diagnostics.LoggedHeaderNames.Add("x-ms-requestId");
                Diagnostics.LoggedHeaderNames.Add("Headers");
            }
        }
    }
}
