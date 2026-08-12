// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
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
    public void NormalizeVoiceRejectsStringTemperature()
    {
        Assert.Throws<ArgumentException>(() => VoiceValidation.NormalizeVoice(
            new Dictionary<string, object?> { ["temperature"] = "0.5" }));
    }

    [Test]
    public void NormalizeVoiceAcceptsJsonElementNumberAndArray()
    {
        using var document = JsonDocument.Parse("""
            {"temperature":0.5,"prefer_locales":["en-US","fr-FR"]}
            """);
        var normalized = VoiceValidation.NormalizeVoice(new Dictionary<string, object?>
        {
            ["temperature"] = document.RootElement.GetProperty("temperature"),
            ["prefer_locales"] = document.RootElement.GetProperty("prefer_locales"),
        });

        Assert.Multiple(() =>
        {
            Assert.That(normalized!["temperature"], Is.EqualTo(0.5d).Within(1e-9));
            Assert.That(normalized["prefer_locales"], Is.EqualTo(new[] { "en-US", "fr-FR" }));
        });
    }

    [Test]
    public void NormalizeVoiceEnumeratesPreferredLocalesOnce()
    {
        var locales = new SingleUseEnumerable<string>(new[] { "en-US", "fr-FR" });

        var normalized = VoiceValidation.NormalizeVoice(new Dictionary<string, object?>
        {
            ["prefer_locales"] = locales,
        });

        Assert.That(normalized!["prefer_locales"], Is.EqualTo(new[] { "en-US", "fr-FR" }));
        Assert.That(locales.EnumerationCount, Is.EqualTo(1));
    }

    [Test]
    public void NormalizeVoiceRejectsPatchWithOnlyUnknownFields()
    {
        Assert.Throws<ArgumentException>(() => VoiceValidation.NormalizeVoice(
            new Dictionary<string, object?> { ["future_field"] = "value" }));
    }

    private sealed class SingleUseEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _values;

        public SingleUseEnumerable(IEnumerable<T> values)
        {
            _values = values;
        }

        public int EnumerationCount { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            EnumerationCount++;
            if (EnumerationCount > 1)
            {
                throw new InvalidOperationException("The sequence was enumerated more than once.");
            }

            return _values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
