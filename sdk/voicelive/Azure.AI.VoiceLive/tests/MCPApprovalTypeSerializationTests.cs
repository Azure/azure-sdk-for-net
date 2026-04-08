// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Tests that MCPApprovalType serializes correctly via BinaryData.FromObjectAsJson.
    /// Regression test for: BinaryData.FromObjectAsJson(MCPApprovalType.Never) was producing "{}"
    /// instead of "never", causing silent approval behavior changes on the wire.
    /// </summary>
    public class MCPApprovalTypeSerializationTests
    {
        [Test]
        public void FromObjectAsJson_Never_SerializesToNeverString()
        {
            BinaryData data = BinaryData.FromObjectAsJson(MCPApprovalType.Never);
            string json = data.ToString();
            Assert.AreEqual("\"never\"", json);
        }

        [Test]
        public void FromObjectAsJson_Always_SerializesToAlwaysString()
        {
            BinaryData data = BinaryData.FromObjectAsJson(MCPApprovalType.Always);
            string json = data.ToString();
            Assert.AreEqual("\"always\"", json);
        }

        [Test]
        public void JsonSerializer_RoundTrips_Correctly()
        {
            string serialized = JsonSerializer.Serialize(MCPApprovalType.Never);
            Assert.AreEqual("\"never\"", serialized);

            MCPApprovalType deserialized = JsonSerializer.Deserialize<MCPApprovalType>(serialized);
            Assert.AreEqual(MCPApprovalType.Never, deserialized);
        }

        [Test]
        public void FromObjectAsJson_CustomValue_SerializesCorrectly()
        {
            var custom = new MCPApprovalType("custom_value");
            BinaryData data = BinaryData.FromObjectAsJson(custom);
            Assert.AreEqual("\"custom_value\"", data.ToString());
        }

        [Test]
        public void RequireApproval_WithFromObjectAsJson_ProducesCorrectWireFormat()
        {
            var server = new VoiceLiveMcpServerDefinition("test-server", "https://example.com/mcp")
            {
                RequireApproval = BinaryData.FromObjectAsJson(MCPApprovalType.Never)
            };

            // Verify the BinaryData contains the correct JSON string value
            Assert.AreEqual("\"never\"", server.RequireApproval.ToString());
        }
    }
}
