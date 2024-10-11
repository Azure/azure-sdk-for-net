using OpenAI.RealtimeConversation;
using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json.Nodes;

namespace Azure.AI.OpenAI.Tests;

#nullable disable
#pragma warning disable OPENAI002

[TestFixture(false)]
[Category("Smoke")]
public class ConversationSmokeTests : ConversationTestFixtureBase
{
    public ConversationSmokeTests(bool isAsync) : base(isAsync)
    { }

    [Test]
    public void ItemCreation()
    {
        ConversationItem messageItem = ConversationItem.CreateUserMessage(["Hello, world!"]);
        Assert.That(messageItem?.MessageContentParts?.Count, Is.EqualTo(1));
        Assert.That(messageItem.MessageContentParts[0].TextValue, Is.EqualTo("Hello, world!"));
    }

    [Test]
    public void OptionsSerializationWorks()
    {
        ConversationSessionOptions options = new()
        {
            ContentModalities = ConversationContentModalities.Text,
            InputAudioFormat = ConversationAudioFormat.G711Alaw,
            InputTranscriptionOptions = new ConversationInputTranscriptionOptions()
            {
                Model = "whisper-1",
            },
            Instructions = "test instructions",
            MaxResponseOutputTokens = 42,
            Model = "gpt-4o-realtime-preview",
            OutputAudioFormat = ConversationAudioFormat.G711Ulaw,
            Temperature = 0.42f,
            ToolChoice = ConversationToolChoice.CreateFunctionToolChoice("test-function"),
            Tools =
            {
                ConversationTool.CreateFunctionTool(
                    name: "test-function-tool-name",
                    description: "description of test function tool",
                    parameters: BinaryData.FromString("""
                        {
                          "type": "object",
                          "properties": {}
                        }
                        """)),
            },
            TurnDetectionOptions = ConversationTurnDetectionOptions.CreateServerVoiceActivityTurnDetectionOptions(
                           detectionThreshold: 0.42f,
                           prefixPaddingDuration: TimeSpan.FromMilliseconds(234),
                            silenceDuration: TimeSpan.FromMilliseconds(345)),
            Voice = ConversationVoice.Echo,
        };
        BinaryData serializedOptions = ModelReaderWriter.Write(options);
        JsonNode jsonNode = JsonNode.Parse(serializedOptions.ToString());
        Assert.That(jsonNode["modalities"]?.AsArray()?.ToList(), Has.Count.EqualTo(1));
        Assert.That(jsonNode["modalities"].AsArray().First().GetValue<string>(), Is.EqualTo("text"));
        Assert.That(jsonNode["input_audio_format"]?.GetValue<string>(), Is.EqualTo("g711_alaw"));
        Assert.That(jsonNode["input_audio_transcription"]?["model"]?.GetValue<string>(), Is.EqualTo("whisper-1"));
        Assert.That(jsonNode["instructions"]?.GetValue<string>(), Is.EqualTo("test instructions"));
        Assert.That(jsonNode["max_response_output_tokens"]?.GetValue<int>(), Is.EqualTo(42));
        Assert.That(jsonNode["model"]?.GetValue<string>(), Is.EqualTo("gpt-4o-realtime-preview"));
        Assert.That(jsonNode["output_audio_format"]?.GetValue<string>(), Is.EqualTo("g711_ulaw"));
        Assert.That(jsonNode["temperature"]?.GetValue<float>(), Is.EqualTo(0.42f));
        Assert.That(jsonNode["tools"]?.AsArray()?.ToList(), Has.Count.EqualTo(1));
        Assert.That(jsonNode["tools"].AsArray().First()["name"]?.GetValue<string>(), Is.EqualTo("test-function-tool-name"));
        Assert.That(jsonNode["tools"].AsArray().First()["description"]?.GetValue<string>(), Is.EqualTo("description of test function tool"));
        Assert.That(jsonNode["tools"].AsArray().First()["parameters"]?["type"]?.GetValue<string>(), Is.EqualTo("object"));
        Assert.That(jsonNode["tool_choice"]?["function"]?["name"]?.GetValue<string>(), Is.EqualTo("test-function"));
        Assert.That(jsonNode["turn_detection"]?["threshold"]?.GetValue<float>(), Is.EqualTo(0.42f));
        Assert.That(jsonNode["turn_detection"]?["prefix_padding_ms"]?.GetValue<int>(), Is.EqualTo(234));
        Assert.That(jsonNode["turn_detection"]?["silence_duration_ms"]?.GetValue<int>(), Is.EqualTo(345));
        Assert.That(jsonNode["voice"]?.GetValue<string>(), Is.EqualTo("echo"));
        ConversationSessionOptions deserializedOptions = ModelReaderWriter.Read<ConversationSessionOptions>(serializedOptions);
        Assert.That(deserializedOptions.ContentModalities.HasFlag(ConversationContentModalities.Text));
        Assert.That(deserializedOptions.ContentModalities.HasFlag(ConversationContentModalities.Audio), Is.False);
        Assert.That(deserializedOptions.InputAudioFormat, Is.EqualTo(ConversationAudioFormat.G711Alaw));
        Assert.That(deserializedOptions.InputTranscriptionOptions?.Model, Is.EqualTo(ConversationTranscriptionModel.Whisper1));
        Assert.That(deserializedOptions.Instructions, Is.EqualTo("test instructions"));
        Assert.That(deserializedOptions.MaxResponseOutputTokens.NumericValue, Is.EqualTo(42));
        Assert.That(deserializedOptions.Model, Is.EqualTo("gpt-4o-realtime-preview"));
        Assert.That(deserializedOptions.OutputAudioFormat, Is.EqualTo(ConversationAudioFormat.G711Ulaw));
        Assert.That(deserializedOptions.Tools, Has.Count.EqualTo(1));
        Assert.That(deserializedOptions.Tools[0].Kind, Is.EqualTo(ConversationToolKind.Function));
        Assert.That((deserializedOptions.Tools[0] as ConversationFunctionTool)?.Name, Is.EqualTo("test-function-tool-name"));
        Assert.That((deserializedOptions.Tools[0] as ConversationFunctionTool)?.Description, Is.EqualTo("description of test function tool"));
        Assert.That((deserializedOptions.Tools[0] as ConversationFunctionTool)?.Parameters?.ToString(), Does.Contain("properties"));
        Assert.That(deserializedOptions.ToolChoice?.Kind, Is.EqualTo(ConversationToolChoiceKind.Function));
        Assert.That(deserializedOptions.ToolChoice?.FunctionName, Is.EqualTo("test-function"));
        Assert.That(deserializedOptions.TurnDetectionOptions?.Kind, Is.EqualTo(ConversationTurnDetectionKind.ServerVoiceActivityDetection));
        Assert.That(deserializedOptions.Voice, Is.EqualTo(ConversationVoice.Echo));
    }
}
