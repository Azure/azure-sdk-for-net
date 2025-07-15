using OpenAI.Realtime;
using System;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text.Json.Nodes;

namespace Azure.AI.OpenAI.Tests;

#nullable disable
#pragma warning disable OPENAI002

#if !AZURE_OPENAI_GA
[TestFixture(false)]
[Category("Smoke")]
public class RealtimeSmokeTests : RealtimeTestFixtureBase
{
    public RealtimeSmokeTests(bool isAsync) : base(isAsync)
    { }

    [Test]
    public void ItemCreation()
    {
        RealtimeItem messageItem = RealtimeItem.CreateUserMessage(["Hello, world!"]);
        Assert.That(messageItem?.MessageContentParts?.Count, Is.EqualTo(1));
        Assert.That(messageItem.MessageContentParts[0].Text, Is.EqualTo("Hello, world!"));
    }

    [Test]
    public void OptionsSerializationWorks()
    {
        ConversationSessionOptions options = new()
        {
            ContentModalities = RealtimeContentModalities.Text,
            InputAudioFormat = RealtimeAudioFormat.G711Alaw,
            InputTranscriptionOptions = new InputTranscriptionOptions()
            {
                Model = "whisper-1",
            },
            Instructions = "test instructions",
            MaxOutputTokens = 42,
            OutputAudioFormat = RealtimeAudioFormat.G711Ulaw,
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
            TurnDetectionOptions = TurnDetectionOptions.CreateServerVoiceActivityTurnDetectionOptions(
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
        Assert.That(deserializedOptions.ContentModalities.HasFlag(RealtimeContentModalities.Text));
        Assert.That(deserializedOptions.ContentModalities.HasFlag(RealtimeContentModalities.Audio), Is.False);
        Assert.That(deserializedOptions.InputAudioFormat, Is.EqualTo(RealtimeAudioFormat.G711Alaw));
        Assert.That(deserializedOptions.InputTranscriptionOptions?.Model, Is.EqualTo(InputTranscriptionModel.Whisper1));
        Assert.That(deserializedOptions.Instructions, Is.EqualTo("test instructions"));
        Assert.That(deserializedOptions.MaxOutputTokens.NumericValue, Is.EqualTo(42));
        Assert.That(deserializedOptions.OutputAudioFormat, Is.EqualTo(RealtimeAudioFormat.G711Ulaw));
        Assert.That(deserializedOptions.Tools, Has.Count.EqualTo(1));
        Assert.That(deserializedOptions.Tools[0].Kind, Is.EqualTo(ConversationToolKind.Function));
        Assert.That((deserializedOptions.Tools[0] as ConversationFunctionTool)?.Name, Is.EqualTo("test-function-tool-name"));
        Assert.That((deserializedOptions.Tools[0] as ConversationFunctionTool)?.Description, Is.EqualTo("description of test function tool"));
        Assert.That((deserializedOptions.Tools[0] as ConversationFunctionTool)?.Parameters?.ToString(), Does.Contain("properties"));
        Assert.That(deserializedOptions.ToolChoice?.Kind, Is.EqualTo(ConversationToolChoiceKind.Function));
        Assert.That(deserializedOptions.ToolChoice?.FunctionName, Is.EqualTo("test-function"));
        Assert.That(deserializedOptions.TurnDetectionOptions?.Kind, Is.EqualTo(TurnDetectionKind.ServerVoiceActivityDetection));
        Assert.That(deserializedOptions.Voice, Is.EqualTo(ConversationVoice.Echo));

        ConversationSessionOptions emptyOptions = new();
        Assert.That(emptyOptions.ContentModalities.HasFlag(RealtimeContentModalities.Audio), Is.False);
        Assert.That(ModelReaderWriter.Write(emptyOptions).ToString(), Does.Not.Contain("modal"));
        emptyOptions.ContentModalities |= RealtimeContentModalities.Audio;
        Assert.That(emptyOptions.ContentModalities.HasFlag(RealtimeContentModalities.Audio), Is.True);
        Assert.That(emptyOptions.ContentModalities.HasFlag(RealtimeContentModalities.Text), Is.False);
        Assert.That(ModelReaderWriter.Write(emptyOptions).ToString(), Does.Contain("modal"));
    }

    [Test]
    public void MaxTokensSerializationWorks()
    {
        // Implicit omission
        ConversationSessionOptions options = new() { };
        BinaryData serializedOptions = ModelReaderWriter.Write(options);
        Assert.That(serializedOptions.ToString(), Does.Not.Contain("max_response_output_tokens"));

        // Explicit omission
        options = new()
        {
            MaxOutputTokens = null
        };
        serializedOptions = ModelReaderWriter.Write(options);
        Assert.That(serializedOptions.ToString(), Does.Not.Contain("max_response_output_tokens"));

        // Explicit default (null)
        options = new()
        {
            MaxOutputTokens = ConversationMaxTokensChoice.CreateDefaultMaxTokensChoice()
        };
        serializedOptions = ModelReaderWriter.Write(options);
        Assert.That(serializedOptions.ToString(), Does.Contain(@"""max_response_output_tokens"":null"));

        // Numeric literal
        options = new()
        {
            MaxOutputTokens = 42,
        };
        serializedOptions = ModelReaderWriter.Write(options);
        Assert.That(serializedOptions.ToString(), Does.Contain(@"""max_response_output_tokens"":42"));

        // Numeric by factory
        options = new()
        {
            MaxOutputTokens = ConversationMaxTokensChoice.CreateNumericMaxTokensChoice(42)
        };
        serializedOptions = ModelReaderWriter.Write(options);
        Assert.That(serializedOptions.ToString(), Does.Contain(@"""max_response_output_tokens"":42"));
    }

    [Test]
    public void TurnDetectionSerializationWorks()
    {
        // Implicit omission
        ConversationSessionOptions sessionOptions = new();
        BinaryData serializedOptions = ModelReaderWriter.Write(sessionOptions);
        Assert.That(serializedOptions.ToString(), Does.Not.Contain("turn_detection"));

        sessionOptions = new()
        {
            TurnDetectionOptions = TurnDetectionOptions.CreateDisabledTurnDetectionOptions(),
        };
        serializedOptions = ModelReaderWriter.Write(sessionOptions);
        Assert.That(serializedOptions.ToString(), Does.Contain(@"""turn_detection"":null"));

        sessionOptions = new()
        {
            TurnDetectionOptions = TurnDetectionOptions.CreateServerVoiceActivityTurnDetectionOptions(
                detectionThreshold: 0.42f)
        };
        serializedOptions = ModelReaderWriter.Write(sessionOptions);
        JsonNode serializedNode = JsonNode.Parse(serializedOptions);
        Assert.That(serializedNode["turn_detection"]?["type"]?.GetValue<string>(), Is.EqualTo("server_vad"));
        Assert.That(serializedNode["turn_detection"]?["threshold"]?.GetValue<float>(), Is.EqualTo(0.42f));
    }

    [Test]
    public void UnknownCommandSerializationWorks()
    {
        BinaryData serializedUnknownCommand = BinaryData.FromString("""
        {
          "type": "unknown_command_type_for_test"
        }
        """);
        RealtimeUpdate deserializedUpdate = ModelReaderWriter.Read<RealtimeUpdate>(serializedUnknownCommand);
        Assert.That(deserializedUpdate, Is.Not.Null);
    }
}
#endif