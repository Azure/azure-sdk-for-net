﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RecordSessionTests
    {
        [TestCase("{\"json\":\"value\"}", "application/json")]
        [TestCase("{\"json\":\"\\\"value\\\"\"}", "application/json")]
        [TestCase("{\"json\":{\"json\":\"value\"}}", "application/json")]
        [TestCase("{\"json\"\n:\"value\"}", "application/json")]
        [TestCase("{\"json\" :\"value\"}", "application/json")]
        [TestCase("[\"json\", \"value\"]", "application/json")]
        [TestCase("[{\"json\":\"value\"}, {\"json\":\"value\"}]", "application/json")]
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
            recordEntry.Request.Headers.Add("Content-Type", new[] { contentType });
            recordEntry.Request.Headers.Add("Other-Header", new[] { "multi", "value" });
            recordEntry.Request.Body = bodyBytes;
            recordEntry.RequestUri = "url";
            recordEntry.RequestMethod = RequestMethod.Delete;

            recordEntry.Response.Headers.Add("Content-Type", new[] { contentType });
            recordEntry.Response.Headers.Add("Other-Response-Header", new[] { "multi", "value" });

            recordEntry.Response.Body = bodyBytes;
            recordEntry.StatusCode = 202;

            session.Entries.Add(recordEntry);

            var arrayBufferWriter = new ArrayBufferWriter<byte>();
            using var jsonWriter = new Utf8JsonWriter(arrayBufferWriter, new JsonWriterOptions()
            {
                Indented = true
            });
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

            CollectionAssert.AreEqual(new[] { contentType }, deserializedRecord.Request.Headers["content-type"]);
            CollectionAssert.AreEqual(new[] { "multi", "value" }, deserializedRecord.Request.Headers["other-header"]);

            CollectionAssert.AreEqual(new[] { contentType }, deserializedRecord.Response.Headers["content-type"]);
            CollectionAssert.AreEqual(new[] { "multi", "value" }, deserializedRecord.Response.Headers["other-response-header"]);

            CollectionAssert.AreEqual(bodyBytes, deserializedRecord.Request.Body);
            CollectionAssert.AreEqual(bodyBytes, deserializedRecord.Response.Body);
        }

        [Test]
        public void RecordMatcherThrowsExceptionsWithDetails()
        {
            var matcher = new RecordMatcher();

            var requestEntry = new RecordEntry()
            {
                RequestUri = "http://localhost/",
                RequestMethod = RequestMethod.Head,
                Request =
                {
                    Headers =
                    {
                        {"Content-Length", new[] {"41"}},
                        {"Some-Header", new[] {"Random value"}},
                        {"Some-Other-Header", new[] {"V"}}
                    },
                    Body = Encoding.UTF8.GetBytes("This is request body, it's nice and long.")
                }
            };

            RecordEntry[] entries = new[]
            {
                new RecordEntry()
                {
                    RequestUri = "http://remote-host",
                    RequestMethod = RequestMethod.Put,
                    Request =
                    {
                        Headers =
                            {
                                { "Content-Length", new[] { "41"}},
                                { "Some-Header", new[] { "Non-Random value"}},
                                { "Extra-Header", new[] { "Extra-Value" }}
                            },
                        Body = Encoding.UTF8.GetBytes("This is request body, it's nice and long but it also doesn't match.")
                    }
                }
            };

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => matcher.FindMatch(requestEntry, entries));
            Assert.AreEqual(
                "Unable to find a record for the request HEAD http://localhost/" + Environment.NewLine +
                "Method doesn't match, request <HEAD> record <PUT>" + Environment.NewLine +
                "Uri doesn't match:" + Environment.NewLine +
                "    request <http://localhost/>" + Environment.NewLine +
                "    record  <http://remote-host>" + Environment.NewLine +
                "Header differences:" + Environment.NewLine +
                "    <Some-Header> values differ, request <Random value>, record <Non-Random value>" + Environment.NewLine +
                "    <Some-Other-Header> is absent in record, value <V>" + Environment.NewLine +
                "    <Extra-Header> is absent in request, value <Extra-Value>" + Environment.NewLine +
                "Body differences:" + Environment.NewLine +
                "Request and response bodies do not match at index 40:" + Environment.NewLine +
                "     request: \"e and long.\"" + Environment.NewLine +
                "     record:  \"e and long but it also doesn't\"" + Environment.NewLine,
                exception.Message);
        }

        [Test]
        public void RecordMatcherIgnoresIgnoredHeaders()
        {
            var matcher = new RecordMatcher();

            var mockRequest = new RecordEntry()
            {
                RequestUri = "http://localhost",
                RequestMethod = RequestMethod.Put,
            };

            RecordEntry[] entries = new[]
            {
                new RecordEntry()
                {
                    RequestUri = "http://localhost",
                    RequestMethod = RequestMethod.Put,
                    Request =
                    {
                        Headers =
                        {
                            { "Request-Id", new[] { "Non-Random value"}},
                        }
                    }
                }
            };

            Assert.NotNull(matcher.FindMatch(mockRequest, entries));
        }

        [Test]
        public void RecordMatcherThrowsExceptionsWhenNoRecordsLeft()
        {
            var matcher = new RecordMatcher();

            var mockRequest = new RecordEntry()
            {
                RequestUri = "http://localhost/",
                RequestMethod = RequestMethod.Head
            };

            RecordEntry[] entries = { };

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => matcher.FindMatch(mockRequest, entries));
            Assert.AreEqual(
                "Unable to find a record for the request HEAD http://localhost/" + Environment.NewLine +
                "No records to match." + Environment.NewLine,
                exception.Message);
        }

        [Test]
        public void RecordingSessionSanitizeSanitizesVariables()
        {
            var sanitizer = new TestSanitizer();
            var session = new RecordSession();
            session.Variables["A"] = "secret";
            session.Variables["B"] = "Totally not a secret";

            session.Sanitize(sanitizer);

            Assert.AreEqual("SANITIZED", session.Variables["A"]);
            Assert.AreEqual("Totally not a SANITIZED", session.Variables["B"]);
        }

        [TestCase("*", "invalid json", "invalid json")]
        [TestCase("$..secret",
                "{\"secret\":\"I should be sanitized\",\"level\":{\"key\":\"value\",\"secret\":\"I should be sanitized\"}}",
                "{\"secret\":\"Sanitized\",\"level\":{\"key\":\"value\",\"secret\":\"Sanitized\"}}")]
        public void RecordingSessionSanitizeTextBody(string jsonPath, string body, string expected)
        {
            var sanitizer = new RecordedTestSanitizer();
            sanitizer.JsonPathSanitizers.Add(jsonPath);

            string response = sanitizer.SanitizeTextBody(default, body);

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void RecordingSessionSanitizeTextBodyMultipleValues()
        {
            var sanitizer = new RecordedTestSanitizer();
            sanitizer.JsonPathSanitizers.Add("$..secret");
            sanitizer.JsonPathSanitizers.Add("$..topSecret");

            var body = "{\"secret\":\"I should be sanitized\",\"key\":\"value\",\"topSecret\":\"I should be sanitized\"}";
            var expected = "{\"secret\":\"Sanitized\",\"key\":\"value\",\"topSecret\":\"Sanitized\"}";

            string response = sanitizer.SanitizeTextBody(default, body);

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void SavingRecordingSanitizesValues()
        {
            var tempFile = Path.GetTempFileName();
            var sanitizer = new TestSanitizer();
            TestRecording recording = new TestRecording(RecordedTestMode.Record, tempFile, sanitizer, new RecordMatcher());

            recording.SetVariable("A", "secret");
            recording.Dispose(true);

            var text = File.ReadAllText(tempFile);

            StringAssert.DoesNotContain("secret", text);
        }

        [Theory]
        [TestCase("Content-Type")]
        [TestCase("Accept")]
        [TestCase("Random-Header")]
        public void SpecialHeadersNormalizedForMatching(string name)
        {
            // Use HttpClientTransport as it does header normalization
            var originalRequest = new HttpClientTransport().CreateRequest();
            originalRequest.Method = RequestMethod.Get;
            originalRequest.Uri.Reset(new Uri("http://localhost"));
            originalRequest.Headers.Add(name, "application/json;odata=nometadata");
            originalRequest.Headers.Add("Date", "This should be ignored");

            var playbackRequest = new MockTransport().CreateRequest();
            playbackRequest.Method = RequestMethod.Get;
            playbackRequest.Uri.Reset(new Uri("http://localhost"));
            playbackRequest.Headers.Add(name, "application/json;odata=nometadata");
            playbackRequest.Headers.Add("Date", "It doesn't match");

            var matcher = new RecordMatcher();
            var requestEntry = RecordTransport.CreateEntry(originalRequest, null);
            var entry = RecordTransport.CreateEntry(originalRequest, new MockResponse(200));

            Assert.NotNull(matcher.FindMatch(requestEntry, new[] { entry }));
        }

        [Test]
        public void DisableRequestBodyRecordingMakesRequestBodyNull()
        {
            var tempFile = Path.GetTempFileName();
            TestRecording recording = new TestRecording(RecordedTestMode.Record, tempFile, new TestSanitizer(), new RecordMatcher());
            HttpPipelineTransport transport = recording.CreateTransport(Mock.Of<HttpPipelineTransport>());

            var body = "A nice and long body.";

            var request = new MockRequest();
            request.Content = RequestContent.Create(Encoding.UTF8.GetBytes(body));
            request.Headers.Add("Content-Type", "text/json");

            HttpMessage message = new HttpMessage(request, null);
            message.Response = new MockResponse(200);

            using (recording.DisableRequestBodyRecording())
            {
                transport.Process(message);
            }

            recording.Dispose(true);
            var text = File.ReadAllText(tempFile);

            StringAssert.DoesNotContain(body, text);
            StringAssert.Contains($"\"RequestBody\": null", text);
        }

        [Test]
        public void RecordSessionLookupSkipsRequestBodyWhenFilterIsOn()
        {
            var request = new MockRequest();
            request.Uri.Reset(new Uri("https://mockuri.com"));
            request.Content = RequestContent.Create(Encoding.UTF8.GetBytes("A nice and long body."));
            request.Headers.Add("Content-Type", "text/json");

            HttpMessage message = new HttpMessage(request, null);
            message.Response = new MockResponse(200);

            var session = new RecordSession();
            var recordTransport = new RecordTransport(session, Mock.Of<HttpPipelineTransport>(), entry => EntryRecordModel.RecordWithoutRequestBody, Mock.Of<Random>());

            recordTransport.Process(message);

            request.Content = RequestContent.Create(Encoding.UTF8.GetBytes("A bad and longer body"));

            var skipRequestBody = true;
            var playbackTransport = new PlaybackTransport(session, new RecordMatcher(), new RecordedTestSanitizer(), Mock.Of<Random>(), entry => skipRequestBody);

            playbackTransport.Process(message);

            skipRequestBody = false;
            Assert.Throws<InvalidOperationException>(() => playbackTransport.Process(message));
        }

        private class TestSanitizer : RecordedTestSanitizer
        {
            public override string SanitizeVariable(string variableName, string environmentVariableValue)
            {
                return environmentVariableValue.Replace("secret", "SANITIZED");
            }
        }
    }
}
