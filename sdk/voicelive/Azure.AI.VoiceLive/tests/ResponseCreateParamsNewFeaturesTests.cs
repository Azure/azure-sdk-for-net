// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class ResponseCreateParamsNewFeaturesTests
    {
        [Test]
        public void InvokeInput_SerializesCorrectly()
        {
            var rcp = new ResponseCreateParams();
            rcp.InvokeInput["thread_id"] = System.BinaryData.FromString("\"thread-abc\"");
            rcp.InvokeInput["agent_id"] = System.BinaryData.FromString("\"agent-xyz\"");

            var json = TestUtilities.SerializeViaIJsonModel(rcp);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.TryGetProperty("invoke_input", out var ii), Is.True);
            Assert.That(ii.GetProperty("thread_id").GetString(), Is.EqualTo("thread-abc"));
            Assert.That(ii.GetProperty("agent_id").GetString(), Is.EqualTo("agent-xyz"));
        }

        [Test]
        public void InvokeInput_EmptyMap_OmittedFromJson()
        {
            var rcp = new ResponseCreateParams();
            var json = TestUtilities.SerializeViaIJsonModel(rcp);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.TryGetProperty("invoke_input", out _), Is.False);
        }

        [Test]
        public void InvokeInput_RoundTrip()
        {
            var original = new ResponseCreateParams();
            original.InvokeInput["query"] = System.BinaryData.FromString("\"hello\"");

            // Verify serialized JSON has correct TypeSpec wire key
            var json = TestUtilities.SerializeViaIJsonModel(original);
            using var serializedDoc = JsonDocument.Parse(json);
            Assert.That(serializedDoc.RootElement.TryGetProperty("invoke_input", out var ii), Is.True);
            Assert.That(ii.GetProperty("query").GetString(), Is.EqualTo("hello"));

            // Verify deserialization from known TypeSpec wire JSON
            var fromWire = TestUtilities.DeserializeViaIJsonModel(
                """{"invoke_input":{"query":"hello"}}""",
                new ResponseCreateParams());
            Assert.That(fromWire.InvokeInput.ContainsKey("query"), Is.True);
            Assert.That(fromWire.InvokeInput["query"].ToString(), Does.Contain("hello"));
        }
    }
}
