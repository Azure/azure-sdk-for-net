// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests;
#pragma warning disable AAIP001
public class VoiceAgentUnitTests
{
    [Test]
    public void RealtimeModelFactoryPreservesSoundscape()
    {
        VoiceAgentSoundscapeConfig soundscape = new();
        VoiceAgentDefinition definition = ProjectsAgentsModelFactory.VoiceAgentDefinition(
            model: "realtime-model", soundscape: soundscape);

        Assert.That(definition.Soundscape, Is.SameAs(soundscape));
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(definition));
        Assert.That(document.RootElement.GetProperty("soundscape").ValueKind, Is.EqualTo(JsonValueKind.Object));
    }

    [Test]
    public void RealtimeModelFactoryKeepsExistingParameterOrderWhenAddingFields()
    {
        string[] originalParameters =
        [
            "contentFilterConfiguration", "modelType", "model", "conversationEngine", "instructions", "greeting", "audio",
            "outputModalities", "internalMaxOutputTokens", "include", "interimResponse", "avatar", "tools", "internalToolChoice",
            "parallelToolCalls", "structuredInputs", "subagentConfig", "store"
        ];
        string[] parameters = typeof(ProjectsAgentsModelFactory)
            .GetMethod(nameof(ProjectsAgentsModelFactory.VoiceAgentDefinition))
            .GetParameters().Select(parameter => parameter.Name).ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(parameters.Take(originalParameters.Length), Is.EqualTo(originalParameters));
            Assert.That(parameters.Skip(originalParameters.Length), Does.Contain("soundscape"));
            Assert.That(parameters, Does.Not.Contain("kind").And.Not.Contain("subProtocol"));
        });
    }

    [Test]
    [TestCase(null, null, true)]
    [TestCase(null, "inf", false)]
    [TestCase(0, null, false)]
    [TestCase(42, null, false)]
    public void TestVoiceAgentMaxOutputTokens(int? outputTokens, string inf, bool isDefaultNullValue)
    {
        // Creation
        VoiceAgentMaxOutputTokens outputTokensObj = inf == null ? (isDefaultNullValue ? new(true) : new(outputTokens.Value)) : new(inf);
        Assert.That(outputTokensObj.NumericValue, Is.EqualTo(outputTokens));
        // Serialization
        BinaryData data = ModelReaderWriter.Write(outputTokensObj, ModelReaderWriterOptions.Json);
        if (string.Equals(inf, "inf"))
        {
            Assert.That(data.ToString(), Is.EqualTo("\"inf\""));
        }
        else
        {
            if (!isDefaultNullValue)
            {
                Assert.That(data.ToString(), Is.EqualTo(outputTokens.ToString()));
            }
        }
        // Deserialization
        VoiceAgentMaxOutputTokens deserialized = VoiceAgentMaxOutputTokens.FromBinaryData(data);
        Assert.That(deserialized.NumericValue, Is.EqualTo(outputTokens));
        // Equality
        Assert.That(deserialized.Equals(outputTokensObj), Is.True);
        if (string.Equals(inf, "inf"))
        {
            Assert.That(deserialized.Equals(VoiceAgentMaxOutputTokens.Infinity), Is.True);
        }
        else
        {
            Assert.That(deserialized.Equals(VoiceAgentMaxOutputTokens.Infinity), Is.False);
        }
    }
}
