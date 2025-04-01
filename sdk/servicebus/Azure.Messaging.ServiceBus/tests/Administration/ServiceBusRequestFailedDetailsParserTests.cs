// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Administration
{
    [TestFixture]
    public class ServiceBusRequestFailedDetailsParserTests
    {
        [Test]
        public void ZeroLengthStreamReturnsDefaultErrorDetails()
        {
            var response = new MockResponse(401);
            response.SetIsError(true);
            response.SetContent(Array.Empty<byte>());

            var parser = new ServiceBusRequestFailedDetailsParser();
            parser.TryParse(response, out var error, out var data);

            Assert.AreSame(default(ResponseError), error);
        }

        [Test]
        public void NonSeekingStreamReturnsDefaultErrorDetails()
        {
            var mockStream = new Mock<Stream>();
            var response = new MockResponse(401) { ContentStream = mockStream.Object };

            mockStream
                .Setup(stream => stream.CanSeek)
                .Returns(false);

            mockStream
                .Setup(stream => stream.Length)
                .Returns(1);

            response.SetIsError(true);

            var parser = new ServiceBusRequestFailedDetailsParser();
            parser.TryParse(response, out var error, out var data);

            Assert.AreSame(default(ResponseError), error);
        }

        [Test]
        public void XmlBodyReturnsErrorDetails()
        {
            var subcCode = "40100";
            var message = $"SubCode={subcCode}. Failed to authenticate";

            var errorContent =
                @$"<?xml version=""1.0"" encoding=""UTF-8""?>
                <Error>
                  <Code>401</Code>
                  <Detail>{message}</Detail>
                </Error>";

            var response = new MockResponse(401);
            response.SetIsError(true);
            response.SetContent(errorContent);

            var parser = new ServiceBusRequestFailedDetailsParser();
            parser.TryParse(response, out var error, out var data);

            Assert.NotNull(error);
            Assert.AreNotSame(error, default(ResponseError));
            Assert.AreEqual(subcCode, error.Code);
            Assert.AreEqual(message, error.Message);
        }
    }
}
