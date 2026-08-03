// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class VoiceValidationTests
{
    [Test]
    public void NormalizeVoiceNormalizesSupportedAlias()
    {
        var normalized = VoiceValidation.NormalizeVoice(new Dictionary<string, object?>
        {
            ["type"] = "azure-platform",
            ["name"] = "en-US-Ava:DragonHDLatestNeural",
            ["rate"] = "+10%",
        });

        Assert.That(normalized!["type"], Is.EqualTo("azure-standard"));
    }

    [Test]
    public void NormalizeVoiceRejectsBooleanTemperature()
    {
        Assert.Throws<ArgumentException>(() => VoiceValidation.NormalizeVoice(
            new Dictionary<string, object?> { ["temperature"] = true }));
    }

    [Test]
    public void NormalizeVoiceRejectsOutOfRangeTemperature()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => VoiceValidation.NormalizeVoice(
            new Dictionary<string, object?> { ["temperature"] = 1.1 }));
    }

    [Test]
    public void NormalizeVoiceRejectsPatchWithOnlyUnknownFields()
    {
        Assert.Throws<ArgumentException>(() => VoiceValidation.NormalizeVoice(
            new Dictionary<string, object?> { ["future_field"] = "value" }));
    }
}
