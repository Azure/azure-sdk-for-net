// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json;
using NUnit.Framework;
using OpenAI.Realtime;

namespace Azure.AI.Projects.Agents.Tests;
#pragma warning disable AAIP001
#pragma warning disable AAIP002, OPENAI002
public class VoiceAgentUnitTests
{
    [Test]
    public void SemanticVadEagernessSerializesAsTheOpenAIStringValue(
        [Values("auto", "low", "medium", "high", "future_eagerness")] string eagerness,
        [Values("J", "W")] string format)
    {
        VoiceAgentSemanticVadTurnDetection detection = new()
        {
            Eagerness = new RealtimeSemanticVadEagernessLevel(eagerness),
            CreateResponse = true
        };

        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(
            detection, new ModelReaderWriterOptions(format), AzureAIProjectsAgentsContext.Default));

        Assert.That(document.RootElement.GetProperty("type").GetString(), Is.EqualTo("semantic_vad"));
        Assert.That(document.RootElement.GetProperty("eagerness").GetString(), Is.EqualTo(eagerness));
        Assert.That(document.RootElement.GetProperty("create_response").GetBoolean(), Is.True);
    }

    [Test]
    public void SemanticVadEagernessDeserializesFromTheOpenAIStringValue(
        [Values("auto", "low", "medium", "high", "future_eagerness")] string eagerness,
        [Values("J", "W")] string format)
    {
        VoiceAgentSemanticVadTurnDetection detection = ModelReaderWriter.Read<VoiceAgentSemanticVadTurnDetection>(
            BinaryData.FromString($$"""{"type":"semantic_vad","eagerness":"{{eagerness}}","create_response":true}"""),
            new ModelReaderWriterOptions(format), AzureAIProjectsAgentsContext.Default);

        Assert.That(detection.Eagerness?.ToString(), Is.EqualTo(eagerness));
        Assert.That(detection.CreateResponse, Is.True);
    }

    [Test]
    public void SemanticVadEagernessRemainsOptional([Values("J", "W")] string format)
    {
        ModelReaderWriterOptions options = new(format);
        VoiceAgentSemanticVadTurnDetection detection = ModelReaderWriter.Read<VoiceAgentSemanticVadTurnDetection>(
            BinaryData.FromString("""{"type":"semantic_vad","eagerness":null}"""), options, AzureAIProjectsAgentsContext.Default);
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(
            detection, options, AzureAIProjectsAgentsContext.Default));

        Assert.That(detection.Eagerness, Is.Null);
        Assert.That(document.RootElement.TryGetProperty("eagerness", out _), Is.False);
    }

    [TestCase("completed")]
    [TestCase("in_progress")]
    [TestCase("failed")]
    [TestCase("cancelled")]
    [TestCase("future_status")]
    public void PersistedRealtimeResponseStatusDeserializesThroughTheTypedSdk(string status)
    {
        BinaryData data = BinaryData.FromString($$"""
            {"id":"response","object":"realtime.response","status":"{{status}}",
             "conversation_id":"conversation","output":[]}
            """);

        VoiceResult response = ModelReaderWriter.Read<VoiceResult>(
            data, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);

        Assert.That(response.Status?.ToString(), Is.EqualTo(status));
        Assert.That(response.Id, Is.EqualTo("response"));
        using JsonDocument written = JsonDocument.Parse(ModelReaderWriter.Write(
            response, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default));
        Assert.That(written.RootElement.GetProperty("status").GetString(), Is.EqualTo(status));
    }

    [TestCase("audio")]
    [TestCase("text")]
    [TestCase("future_modality")]
    public void PersistedRealtimeResponseModalitiesRoundTripThroughTheTypedSdk(string modality)
    {
        BinaryData data = BinaryData.FromString($$"""
            {"id":"response","object":"realtime.response","status":"completed",
             "conversation_id":"conversation","output":[],"output_modalities":["{{modality}}"]}
            """);

        VoiceResult response = ModelReaderWriter.Read<VoiceResult>(
            data, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);

        Assert.That(response.OutputModalities[0].ToString(), Is.EqualTo(modality));
        using JsonDocument written = JsonDocument.Parse(ModelReaderWriter.Write(
            response, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default));
        Assert.That(written.RootElement.GetProperty("output_modalities")[0].GetString(), Is.EqualTo(modality));
    }

    [TestCase("""{"id":"response"}""")]
    [TestCase("""{"id":"response","status":null,"output_modalities":null}""")]
    public void PersistedRealtimeResponseOptionalEnumsRemainOptional(string json)
    {
        VoiceResult response = ModelReaderWriter.Read<VoiceResult>(
            BinaryData.FromString(json), ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);

        Assert.That(response.Status, Is.Null);
        Assert.That(response.OutputModalities, Is.Empty);
    }

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
