// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;
#pragma warning disable AAIP001

[Category("Smoke")]
[Parallelizable(ParallelScope.All)]
public class ResponseResultToolNormalizationTests
{
    // A ResponseResult that echoes an Azure-specific tool definition in its "tools" array. When
    // OpenAI deserializes this it cannot recognize the discriminator, so the tool lands as its
    // opaque internal unknown-tool type. NormalizeAgentTools (and the combined
    // NormalizeAgentResponse) is the client-side bridge that re-dispatches those tools into their
    // strongly-typed Azure subtypes, mirroring the output-item normalization.
    private static string ResponseJsonWith(string toolType) => $$"""
    {
      "id": "resp_1",
      "object": "response",
      "created_at": 0,
      "status": "completed",
      "model": "gpt-4o",
      "output": [],
      "tools": [ { "type": "{{toolType}}" } ]
    }
    """;

    [Test]
    public void NormalizeAgentToolsMaterializesAzureSubtype()
    {
        ResponseResult response = ModelReaderWriter.Read<ResponseResult>(
            BinaryData.FromString(ResponseJsonWith(ResponseToolKind.BingGrounding.ToString())),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);

        // Baseline: OpenAI's own deserialization does not surface the Azure tool subtype.
        Assert.That(response.Tools, Has.Count.EqualTo(1));
        Assert.That(response.Tools[0], Is.Not.InstanceOf<BingGroundingTool>(),
            "Precondition: echoed Azure tools should be opaque before normalization.");

        AzureAIExtensions.NormalizeAgentTools(response);

        Assert.That(response.Tools[0], Is.InstanceOf<BingGroundingTool>(),
            "After normalization the echoed tool should be the strongly-typed Azure subtype.");
    }

    [Test]
    public void NormalizeAgentResponseTypesBothItemsAndTools()
    {
        ResponseResult response = ModelReaderWriter.Read<ResponseResult>(
            BinaryData.FromString($$"""
            {
              "id": "resp_1", "object": "response", "created_at": 0,
              "status": "completed", "model": "gpt-4o",
              "output": [ { "type": "{{ResponseItemKind.BingGroundingCall}}" } ],
              "tools": [ { "type": "{{ResponseToolKind.BingGrounding}}" } ]
            }
            """),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);

        AzureAIExtensions.NormalizeAgentResponse(response);

        Assert.That(response.OutputItems[0], Is.InstanceOf<BingGroundingToolCall>(),
            "NormalizeAgentResponse should type the output items.");
        Assert.That(response.Tools[0], Is.InstanceOf<BingGroundingTool>(),
            "NormalizeAgentResponse should type the echoed tools.");
    }

    [Test]
    public void NormalizeAgentToolsLeavesNonAzureUnknownToolsUnchanged()
    {
        // A discriminator that neither OpenAI nor the Azure dispatcher recognizes. OpenAI buckets it
        // into its opaque unknown-tool type; the Azure dispatcher's default branch round-trips it
        // back through OpenAI, so it must remain the same opaque type (no spurious normalization).
        ResponseResult response = ModelReaderWriter.Read<ResponseResult>(
            BinaryData.FromString(ResponseJsonWith("totally_unrecognized_tool_kind")),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);

        Type before = response.Tools[0].GetType();

        Assert.DoesNotThrow(() => AzureAIExtensions.NormalizeAgentTools(response));

        Assert.That(response.Tools[0].GetType(), Is.EqualTo(before),
            "Tools that are not Azure-specific should not be altered by normalization.");
    }

    [Test]
    public void NormalizeAgentToolsToleratesNull()
    {
        Assert.DoesNotThrow(() => AzureAIExtensions.NormalizeAgentTools(null));
    }
}
#pragma warning restore AAIP001
