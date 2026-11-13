// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;
#pragma warning disable AAIP001

// Client-side normalization (AzureAIExtensions.NormalizeAgentResponse and friends) decides whether an
// already-materialized item/tool still needs re-dispatch by reading its "type" discriminator (exposed as
// ResponseItem.Kind / ResponseTool.Kind) and matching it against this package's known-Azure dispatch tables.
// That gate relies on two facts about the referenced OpenAI library, neither enforced at compile time:
//   1. When OpenAI cannot strongly type a discriminator it still preserves the original value in Kind.
//   2. OpenAI does not itself materialize Azure-specific kinds as our concrete Azure subtypes.
// If an OpenAI package bump broke either, normalization would silently degrade. These canary tests pin both
// invariants so a regression fails loudly and must be part of the mandatory suite for any OpenAI version bump.
[Category("Smoke")]
[Parallelizable(ParallelScope.All)]
public class NormalizationDiscriminatorInvariantTests
{
    // A representative Azure item and tool discriminator; the full sets are exercised by the deserialization tests.
    private static readonly string AzureItemDiscriminator = ResponseItemKind.BingGroundingCall.ToString();
    private static readonly string AzureToolDiscriminator = ResponseToolKind.BingGrounding.ToString();

    [Test]
    public void OpenAIPreservesUnrecognizedItemDiscriminatorInKind()
    {
        ResponseItem item = ModelReaderWriter.Read<ResponseItem>(
            BinaryData.FromString($$"""{ "type": "{{AzureItemDiscriminator}}" }"""),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);

        Assert.That(item, Is.Not.InstanceOf<BingGroundingToolCall>(),
            "Invariant broken: OpenAI now types this Azure item kind itself; revisit the normalization gate.");
        Assert.That(item.Kind.ToString(), Is.EqualTo(AzureItemDiscriminator),
            "Invariant broken: OpenAI no longer preserves the discriminator in ResponseItem.Kind, so item normalization can no longer detect what to re-dispatch.");
    }

    [Test]
    public void OpenAIPreservesUnrecognizedToolDiscriminatorInKind()
    {
        ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(
            BinaryData.FromString($$"""{ "type": "{{AzureToolDiscriminator}}" }"""),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);

        Assert.That(tool, Is.Not.InstanceOf<BingGroundingTool>(),
            "Invariant broken: OpenAI now types this Azure tool kind itself; revisit the normalization gate.");
        Assert.That(tool.Kind.ToString(), Is.EqualTo(AzureToolDiscriminator),
            "Invariant broken: OpenAI no longer preserves the discriminator in ResponseTool.Kind, so tool normalization can no longer detect what to re-dispatch.");
    }

    // A discriminator neither OpenAI nor this package recognizes must not be treated as normalizable, and must be
    // left untouched by normalization (no spurious re-dispatch).
    [Test]
    public void UnknownDiscriminatorIsNotNormalized()
    {
        ResponseResult response = ModelReaderWriter.Read<ResponseResult>(
            BinaryData.FromString("""
            {
              "id": "resp_1", "object": "response", "created_at": 0,
              "status": "completed", "model": "gpt-4o",
              "output": [ { "type": "__deliberately_unrecognized_kind__" } ]
            }
            """),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default);

        Type before = response.OutputItems[0].GetType();

        AzureAIExtensions.NormalizeAgentResponse(response);

        Assert.That(response.OutputItems[0].GetType(), Is.EqualTo(before),
            "A discriminator this package does not know should not be altered by normalization.");
    }
}
#pragma warning restore AAIP001
