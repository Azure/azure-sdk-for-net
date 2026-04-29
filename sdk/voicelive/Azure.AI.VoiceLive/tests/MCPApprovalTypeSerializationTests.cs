// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Tests that RequireApprovalOption serializes correctly for MCP approval workflows.
    /// Regression test for: BinaryData.FromObjectAsJson(MCPApprovalType.Never) was producing "{}"
    /// instead of "never", causing silent approval behavior changes on the wire.
    /// </summary>
    public class MCPApprovalTypeSerializationTests
    {
        [Test]
        public void RequireApproval_Never_SerializesToNeverString()
        {
            var option = new RequireApprovalOption(MCPApprovalType.Never);
            var data = ModelReaderWriter.Write(option, new ModelReaderWriterOptions("J"));
            Assert.AreEqual("\"never\"", data.ToString());
        }

        [Test]
        public void RequireApproval_Always_SerializesToAlwaysString()
        {
            var option = new RequireApprovalOption(MCPApprovalType.Always);
            var data = ModelReaderWriter.Write(option, new ModelReaderWriterOptions("J"));
            Assert.AreEqual("\"always\"", data.ToString());
        }

        [Test]
        public void RequireApproval_ImplicitConversion_Works()
        {
            RequireApprovalOption option = MCPApprovalType.Never;
            Assert.IsNotNull(option);
            Assert.AreEqual(MCPApprovalType.Never, option.ApprovalType);
        }

        [Test]
        public void RequireApproval_PerTool_SerializesToObject()
        {
            var option = new RequireApprovalOption(
                alwaysRequireApproval: new List<string> { "dangerous_tool" },
                neverRequireApproval: new List<string> { "safe_tool" });

            var data = ModelReaderWriter.Write(option, new ModelReaderWriterOptions("J"));
            var json = data.ToString();

            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            Assert.AreEqual(JsonValueKind.Object, root.ValueKind);
            Assert.IsTrue(root.TryGetProperty("always", out var always));
            Assert.AreEqual("dangerous_tool", always[0].GetString());
            Assert.IsTrue(root.TryGetProperty("never", out var never));
            Assert.AreEqual("safe_tool", never[0].GetString());
        }

        [Test]
        public void RequireApproval_RoundTrips_StringValue()
        {
            var original = new RequireApprovalOption(MCPApprovalType.Never);
            var data = ModelReaderWriter.Write(original, new ModelReaderWriterOptions("J"));
            var deserialized = RequireApprovalOption.FromBinaryData(data);
            Assert.AreEqual(MCPApprovalType.Never, deserialized.ApprovalType);
        }

        [Test]
        public void RequireApproval_RoundTrips_PerToolValue()
        {
            var original = new RequireApprovalOption(
                alwaysRequireApproval: new List<string> { "tool1" },
                neverRequireApproval: new List<string> { "tool2" });

            var data = ModelReaderWriter.Write(original, new ModelReaderWriterOptions("J"));
            var deserialized = RequireApprovalOption.FromBinaryData(data);

            Assert.IsNull(deserialized.ApprovalType);
            Assert.AreEqual(1, deserialized.AlwaysRequireApproval.Count);
            Assert.AreEqual("tool1", deserialized.AlwaysRequireApproval[0]);
            Assert.AreEqual(1, deserialized.NeverRequireApproval.Count);
            Assert.AreEqual("tool2", deserialized.NeverRequireApproval[0]);
        }

        [Test]
        public void RequireApproval_AssignDirectlyOnServer_Works()
        {
            var server = new VoiceLiveMcpServerDefinition("test-server", "https://example.com/mcp")
            {
                RequireApproval = MCPApprovalType.Never
            };

            Assert.AreEqual(MCPApprovalType.Never, server.RequireApproval.ApprovalType);
        }
    }
}
