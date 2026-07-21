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
public class ResponseResultOutputNormalizationTests
{
    // A ResponseResult whose "output" array carries an Azure-specific item kind. When
    // OpenAI deserializes this it cannot recognize the discriminator, so the item lands
    // as its opaque internal unknown type. NormalizeAgentOutputItems is the client-side
    // bridge that re-dispatches those items into their strongly-typed Azure subtypes,
    // which is what removes the need for callers to invoke AsAgentResponseItem() on the
    // response output themselves.
    private static string ResponseJsonWith(string itemType) => $$"""
    {
      "id": "resp_1",
      "object": "response",
      "created_at": 0,
      "status": "completed",
      "model": "gpt-4o",
      "output": [ { "type": "{{itemType}}" } ]
    }
    """;

    [Test]
    public void NormalizeAgentOutputItemsMaterializesAzureSubtype()
    {
        ResponseResult response = ModelReaderWriter.Read<ResponseResult>(
            BinaryData.FromString(ResponseJsonWith("bing_grounding_call")),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);

        // Baseline: OpenAI's own deserialization does not surface the Azure subtype.
        Assert.That(response.OutputItems, Has.Count.EqualTo(1));
        Assert.That(response.OutputItems[0], Is.Not.InstanceOf<BingGroundingToolCall>(),
            "Precondition: nested Azure items should be opaque before normalization.");

        AzureAIExtensions.NormalizeAgentOutputItems(response);

        Assert.That(response.OutputItems[0], Is.InstanceOf<BingGroundingToolCall>(),
            "After normalization the output item should be the strongly-typed Azure subtype.");
    }

    [Test]
    public void NormalizeAgentOutputItemsLeavesRecognizedItemsUnchanged()
    {
        ResponseResult response = ModelReaderWriter.Read<ResponseResult>(
            BinaryData.FromString(ResponseJsonWith("message")),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);

        Type before = response.OutputItems[0].GetType();

        Assert.DoesNotThrow(() => AzureAIExtensions.NormalizeAgentOutputItems(response));

        Assert.That(response.OutputItems[0].GetType(), Is.EqualTo(before),
            "Items OpenAI already recognizes should not be altered by normalization.");
    }

    [Test]
    public void NormalizeAgentOutputItemsToleratesNull()
    {
        Assert.DoesNotThrow(() => AzureAIExtensions.NormalizeAgentOutputItems(null));
    }
}
#pragma warning restore AAIP001
