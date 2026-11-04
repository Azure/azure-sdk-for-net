// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.AI.AgentServer.Responses.Tests.Helpers;
using NUnit.Framework;
using OpenAI.Responses;

#pragma warning disable SCME0001

namespace Azure.AI.AgentServer.Responses.Tests.Interop;

public class StreamingResponseUpdateExtensionsTests
{
    [Test]
    public void OutputIndex_Missing_IsNull()
    {
        var update = OpenAIJson.Read<StreamingResponseUpdate>("{\"type\":\"response.custom_event\",\"sequence_number\":1}");

        Assert.That(update.OutputIndex, Is.Null);
    }

    [Test]
    public void OutputIndex_Present_IsRead()
    {
        var update = OpenAIJson.Read<StreamingResponseUpdate>("{\"type\":\"response.custom_event\",\"sequence_number\":1,\"output_index\":3}");

        Assert.That(update.OutputIndex, Is.EqualTo(3));
    }

    [Test]
    public void OutputIndex_SetThenClear_RoundTrips()
    {
        var update = OpenAIJson.Read<StreamingResponseUpdate>("{\"type\":\"response.custom_event\",\"sequence_number\":1}");

        update.OutputIndex = 0;
        Assert.That(update.OutputIndex, Is.EqualTo(0));

        update.OutputIndex = null;
        Assert.That(update.OutputIndex, Is.Null);
    }
}
