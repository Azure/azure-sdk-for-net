// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

public class ClientPayloadSanitizerTests
{
    [Test]
    public void SanitizeForClient_StripsReservedInternalMetadataKeys()
    {
        var payload = JsonNode.Parse("""
        {
          "metadata": { "user": "keep", "_internal_metadata": "secret" },
          "output": [ { "id": "x", "internal_metadata": { "trace": "1" } } ]
        }
        """)!;

        var sanitized = ClientPayloadSanitizer.SanitizeForClient(payload, SharedJsonOptions.Instance)!.AsObject();

        Assert.Multiple(() =>
        {
            var metadata = sanitized["metadata"]!.AsObject();
            Assert.That(metadata.ContainsKey("user"), Is.True);
            Assert.That(metadata.ContainsKey("_internal_metadata"), Is.False);

            var outputItem = sanitized["output"]!.AsArray()[0]!.AsObject();
            Assert.That(outputItem.ContainsKey("internal_metadata"), Is.False);
        });
    }
}
