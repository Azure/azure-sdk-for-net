// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public void CanRoundtripSessionRecord(string body, string contentType)
        {
            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);

            var session = new RecordSession();
            session.Variables["a"] = "value a";
            session.Variables["b"] = "value b";

            RecordEntry recordEntry = new RecordEntry();
            recordEntry.RequestHeaders.Add("Content-Type", new [] { contentType });
            recordEntry.RequestHeaders.Add("Other-Header", new [] { "multi", "value" });
            recordEntry.RequestBody = bodyBytes;
            recordEntry.RequestUri = "url";
            recordEntry.RequestMethod = RequestMethod.Delete;

            recordEntry.ResponseHeaders.Add("Content-Type", new [] { contentType });
            recordEntry.ResponseHeaders.Add("Other-Response-Header", new [] { "multi", "value" });

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

            CollectionAssert.AreEqual(new [] { contentType }, deserializedRecord.RequestHeaders["content-type"]);
            CollectionAssert.AreEqual(new [] { "multi", "value" }, deserializedRecord.RequestHeaders["other-header"]);

            CollectionAssert.AreEqual(new [] { contentType }, deserializedRecord.ResponseHeaders["content-type"]);
            CollectionAssert.AreEqual(new [] { "multi", "value" }, deserializedRecord.ResponseHeaders["other-response-header"]);

            CollectionAssert.AreEqual(bodyBytes, deserializedRecord.RequestBody);
            CollectionAssert.AreEqual(bodyBytes, deserializedRecord.ResponseBody);
        }
    }
}
