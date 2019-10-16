// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RecordSessionTests
    {
        [TestCase("{\"json\":\"value\"}", "application/json")]
        [TestCase("invalid json", "application/json")]
        [TestCase("{ \"json\": \"value\" }", "unknown")]
        [TestCase("multi\rline", "application/xml")]
        [TestCase("multi\r\nline", "application/xml")]
        [TestCase("multi\n\rline\n", "application/xml")]
        [TestCase("", "")]
        public void CanRoundtripSessionRecord(string body, string contentType)
        {
            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);

            var session = new RecordSession();
            session.Variables["a"] = "value a";
            session.Variables["b"] = "value b";

            RecordEntry recordEntry = new RecordEntry();
            recordEntry.RequestHeaders.Add("Content-Type", new[] { contentType });
            recordEntry.RequestHeaders.Add("Other-Header", new[] { "multi", "value" });
            recordEntry.RequestBody = bodyBytes;
            recordEntry.RequestUri = "url";
            recordEntry.RequestMethod = RequestMethod.Delete;

            recordEntry.ResponseHeaders.Add("Content-Type", new[] { contentType });
            recordEntry.ResponseHeaders.Add("Other-Response-Header", new[] { "multi", "value" });

            recordEntry.ResponseBody = bodyBytes;
            recordEntry.StatusCode = 202;

            session.Entries.Add(recordEntry);

            var arrayBufferWriter = new ArrayBufferWriter<byte>();
            using var jsonWriter = new Utf8JsonWriter(arrayBufferWriter);
            session.Serialize(jsonWriter);
            jsonWriter.Flush();

            TestContext.Out.WriteLine(Encoding.UTF8.GetString(arrayBufferWriter.WrittenMemory.ToArray()));

            var document = JsonDocument.Parse(arrayBufferWriter.WrittenMemory);
            var deserializedSession = RecordSession.Deserialize(document.RootElement);

            Assert.AreEqual("value a", deserializedSession.Variables["a"]);
            Assert.AreEqual("value b", deserializedSession.Variables["b"]);

            RecordEntry deserializedRecord = deserializedSession.Entries.Single();

            Assert.AreEqual(RequestMethod.Delete, recordEntry.RequestMethod);
            Assert.AreEqual("url", recordEntry.RequestUri);
            Assert.AreEqual(202, recordEntry.StatusCode);

            CollectionAssert.AreEqual(new[] { contentType }, deserializedRecord.RequestHeaders["content-type"]);
            CollectionAssert.AreEqual(new[] { "multi", "value" }, deserializedRecord.RequestHeaders["other-header"]);

            CollectionAssert.AreEqual(new[] { contentType }, deserializedRecord.ResponseHeaders["content-type"]);
            CollectionAssert.AreEqual(new[] { "multi", "value" }, deserializedRecord.ResponseHeaders["other-response-header"]);

            CollectionAssert.AreEqual(bodyBytes, deserializedRecord.RequestBody);
            CollectionAssert.AreEqual(bodyBytes, deserializedRecord.ResponseBody);
        }

        [Test]
        public void RecordMatcherThrowsExceptionsWithDetails()
        {
            var matcher = new RecordMatcher(new RecordedTestSanitizer());

            MockRequest mockRequest = new MockRequest
            {
                Method = RequestMethod.Head
            };
            mockRequest.Uri.Reset(new Uri("http://localhost"));
            mockRequest.Headers.Add("Some-Header", "Random value");
            mockRequest.Headers.Add("Some-Other-Header", "V");

            RecordEntry[] entries = new[]
            {
                new RecordEntry()
                {
                    RequestUri = "http://remote-host",
                    RequestMethod = RequestMethod.Put,
                    RequestHeaders =
                    {
                        { "Some-Header", new[] { "Non-Random value"}},
                        { "Extra-Header", new[] { "Extra-Value" }}
                    }
                }
            };

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => matcher.FindMatch(mockRequest, entries));
            Assert.AreEqual(
                "Unable to find a record for the request HEAD http://localhost/" + Environment.NewLine +
                "Method doesn't match, request <HEAD> record <PUT>" + Environment.NewLine +
                "Uri doesn't match:" + Environment.NewLine +
                "    request <http://localhost/>" + Environment.NewLine +
                "    record  <http://remote-host>" + Environment.NewLine +
                "Header differences:" + Environment.NewLine +
                "    <Some-Header> values differ, request <Random value>, record <Non-Random value>" + Environment.NewLine +
                "    <Some-Other-Header> is absent in record, value <V>" + Environment.NewLine +
                "    <Extra-Header> is absent in request, value <Extra-Value>" + Environment.NewLine,
                exception.Message);
        }

        [Test]
        public void RecordMatcherIgnoresIgnoredHeaders()
        {
            var matcher = new RecordMatcher(new RecordedTestSanitizer());

            MockRequest mockRequest = new MockRequest
            {
                Method = RequestMethod.Put
            };
            mockRequest.Uri.Reset(new Uri("http://localhost"));

            RecordEntry[] entries = new[]
            {
                new RecordEntry()
                {
                    RequestUri = "http://localhost",
                    RequestMethod = RequestMethod.Put,
                    RequestHeaders =
                    {
                        { "Request-Id", new[] { "Non-Random value"}},
                    }
                }
            };

            Assert.NotNull(matcher.FindMatch(mockRequest, entries));
        }

        [Test]
        public void RecordMatcherThrowsExceptionsWhenNoRecordsLeft()
        {
            var matcher = new RecordMatcher(new RecordedTestSanitizer());

            MockRequest mockRequest = new MockRequest
            {
                Method = RequestMethod.Head
            };
            mockRequest.Uri.Reset(new Uri("http://localhost"));
            mockRequest.Headers.Add("Some-Header", "Random value");
            mockRequest.Headers.Add("Some-Other-Header", "V");

            RecordEntry[] entries = { };

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => matcher.FindMatch(mockRequest, entries));
            Assert.AreEqual(
                "Unable to find a record for the request HEAD http://localhost/" + Environment.NewLine +
                "No records to match." + Environment.NewLine,
                exception.Message);
        }
    }
}
