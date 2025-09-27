using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI.Realtime;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests;

#nullable disable
#pragma warning disable OPENAI002

[TestFixture(true)]
[TestFixture(false)]
public class RealtimeTests : RealtimeTestFixtureBase
{
    public RealtimeTests(bool isAsync) : base(isAsync) { }

#if AZURE_OPENAI_GA
    [Test]
    [Category("Smoke")]
    public void VersionNotSupportedThrows()
    {
        Assert.Throws<InvalidOperationException>(() => GetTestClient());
    }
#elif !NET
    [Test]
    public void ThrowsOnOldNetFramework()
    {
        _ = Assert.ThrowsAsync<PlatformNotSupportedException>(async () =>
        {
            RealtimeClient client = GetTestClient();
            using RealtimeSession session = await client.StartConversationSessionAsync(GetTestDeployment(), new RealtimeSessionOptions(), CancellationToken);
        });
    }
#else
    [Test]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
    [TestCase(null)]
    public async Task CanConfigureSession(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        RealtimeClient client = GetTestClient(GetTestClientOptions(version));
        using RealtimeSession session = await client.StartConversationSessionAsync(GetTestDeployment(), new RealtimeSessionOptions(), CancellationToken);

        ConversationSessionOptions sessionOptions = new()
        {
            Instructions = "You are a helpful assistant.",
            TurnDetectionOptions = TurnDetectionOptions.CreateDisabledTurnDetectionOptions(),
            OutputAudioFormat = RealtimeAudioFormat.G711Ulaw,
            MaxOutputTokens = 2048,
        };

        await session.ConfigureConversationSessionAsync(sessionOptions, CancellationToken);
        ConversationResponseOptions responseOverrideOptions = new()
        {
            ContentModalities = RealtimeContentModalities.Text,
        };
        if (!client.GetType().IsSubclassOf(typeof(RealtimeClient)))
        {
            responseOverrideOptions.MaxOutputTokens = ConversationMaxTokensChoice.CreateInfiniteMaxTokensChoice();
        }
        await session.AddItemAsync(
            RealtimeItem.CreateUserMessage(["Hello, assistant! Tell me a joke."]),
            CancellationToken);
        await session.StartResponseAsync(responseOverrideOptions, CancellationToken);

        List<RealtimeUpdate> receivedUpdates = [];

        await foreach (RealtimeUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            receivedUpdates.Add(update);

            if (update is RealtimeErrorUpdate errorUpdate)
            {
                Assert.That(errorUpdate.Kind, Is.EqualTo(RealtimeUpdateKind.Error));
                Assert.Fail($"Error: {ModelReaderWriter.Write(errorUpdate)}");
            }
            else if ((update is OutputDeltaUpdate deltaUpdate && deltaUpdate.AudioBytes is not null)
                || update is OutputAudioFinishedUpdate)
            {
                Assert.Fail($"Audio content streaming unexpected after configuring response-level text-only modalities");
            }
            else if (update is ConversationSessionConfiguredUpdate sessionConfiguredUpdate)
            {
                Assert.That(sessionConfiguredUpdate.OutputAudioFormat == sessionOptions.OutputAudioFormat);
                Assert.That(sessionConfiguredUpdate.TurnDetectionOptions.Kind, Is.EqualTo(TurnDetectionKind.Disabled));
                Assert.That(sessionConfiguredUpdate.MaxOutputTokens.NumericValue, Is.EqualTo(sessionOptions.MaxOutputTokens.NumericValue));
            }
            else if (update is ResponseFinishedUpdate)
            {
                break;
            }
        }

        List<T> GetReceivedUpdates<T>() where T : RealtimeUpdate
            => receivedUpdates.Select(update => update as T)
                .Where(update => update is not null)
                .ToList();

        Assert.That(GetReceivedUpdates<ConversationSessionStartedUpdate>(), Has.Count.EqualTo(1));
        Assert.That(GetReceivedUpdates<ResponseStartedUpdate>(), Has.Count.EqualTo(1));
        Assert.That(GetReceivedUpdates<ResponseFinishedUpdate>(), Has.Count.EqualTo(1));
        Assert.That(GetReceivedUpdates<OutputStreamingStartedUpdate>(), Has.Count.EqualTo(1));
        Assert.That(GetReceivedUpdates<OutputStreamingFinishedUpdate>(), Has.Count.EqualTo(1));
    }

    [Test]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
    [TestCase(null)]
    public async Task TextOnlyWorks(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        TestClientOptions options = GetTestClientOptions(version);
        options.DisableClientWrapping = true;
        options.DefaultHeaders.Add("test_header_key", "test_header_value");
        options.DefaultQueryParameters.Add("test_query_parameter_key", "test_query_parameter_value");

        RealtimeClient client = GetTestClient(options);
        using RealtimeSession session = await client.StartConversationSessionAsync(GetTestDeployment(), new RealtimeSessionOptions(), CancellationToken);
        await session.AddItemAsync(
            RealtimeItem.CreateUserMessage(["Hello, world!"]),
            cancellationToken: CancellationToken);
        await session.StartResponseAsync(CancellationToken);

        StringBuilder responseBuilder = new();
        bool gotResponseDone = false;
        bool gotRateLimits = false;

        await foreach (RealtimeUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is ConversationSessionStartedUpdate sessionStartedUpdate)
            {
                Assert.That(sessionStartedUpdate.SessionId, Is.Not.Null.And.Not.Empty);
            }
            if (update is OutputDeltaUpdate deltaUpdate)
            {
                responseBuilder.Append(deltaUpdate.AudioTranscript);
            }

            if (update is ItemCreatedUpdate itemCreatedUpdate)
            {
                if (itemCreatedUpdate.MessageRole == ConversationMessageRole.Assistant)
                {
                    // The assistant-created item should be streamed and should not have content yet when acknowledged
                    Assert.That(itemCreatedUpdate.MessageContentParts, Has.Count.EqualTo(0));
                }
                else if (itemCreatedUpdate.MessageRole == ConversationMessageRole.User)
                {
                    // When acknowledging an item added by the client (user), the text should already be there
                    Assert.That(itemCreatedUpdate.MessageContentParts, Has.Count.EqualTo(1));
                    Assert.That(itemCreatedUpdate.MessageContentParts[0].Text, Is.EqualTo("Hello, world!"));
                }
                else
                {
                    Assert.Fail($"Test didn't expect an acknowledged item with role: {itemCreatedUpdate.MessageRole}");
                }
            }

            if (update is ResponseFinishedUpdate responseFinishedUpdate)
            {
                Assert.That(responseFinishedUpdate.CreatedItems, Has.Count.GreaterThan(0));
                gotResponseDone = true;
                break;
            }

            if (update is RateLimitsUpdate rateLimitsUpdate)
            {
                // Errata (2025-01-22): no rate limit items being reported
                // {"type":"rate_limits.updated","event_id":"event_AscnhKHfFTapqAeiQfE60","rate_limits":[]}

                //Assert.That(rateLimitsUpdate.AllDetails, Has.Count.EqualTo(2));
                //Assert.That(rateLimitsUpdate.TokenDetails, Is.Not.Null);
                //Assert.That(rateLimitsUpdate.TokenDetails.Name, Is.EqualTo("tokens"));
                //Assert.That(rateLimitsUpdate.TokenDetails.MaximumCount, Is.GreaterThan(0));
                //Assert.That(rateLimitsUpdate.TokenDetails.RemainingCount, Is.GreaterThan(0));
                //Assert.That(rateLimitsUpdate.TokenDetails.RemainingCount, Is.LessThan(rateLimitsUpdate.TokenDetails.MaximumCount));
                //Assert.That(rateLimitsUpdate.TokenDetails.TimeUntilReset, Is.GreaterThan(TimeSpan.Zero));
                //Assert.That(rateLimitsUpdate.RequestDetails, Is.Not.Null);
                gotRateLimits = true;
            }
        }

        Assert.That(responseBuilder.ToString(), Is.Not.Null.Or.Empty);
        Assert.That(gotResponseDone, Is.True);

        if (!client.GetType().IsSubclassOf(typeof(RealtimeClient)))
        {
            // Temporarily assume that subclients don't support rate limit commands
            Assert.That(gotRateLimits, Is.True);
        }
    }

    [Test]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
    [TestCase(null)]
    public async Task ItemManipulationWorks(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        RealtimeClient client = GetTestClient(GetTestClientOptions(version));
        using RealtimeSession session = await client.StartConversationSessionAsync(GetTestDeployment(), new RealtimeSessionOptions(), CancellationToken);

        await session.ConfigureConversationSessionAsync(
            new ConversationSessionOptions()
            {
                TurnDetectionOptions = TurnDetectionOptions.CreateDisabledTurnDetectionOptions(),
                ContentModalities = RealtimeContentModalities.Text,
            },
            CancellationToken);

        await session.AddItemAsync(
            RealtimeItem.CreateUserMessage(["The first special word you know about is 'aardvark'."]),
            CancellationToken);
        await session.AddItemAsync(
            RealtimeItem.CreateUserMessage(["The next special word you know about is 'banana'."]),
            CancellationToken);
        await session.AddItemAsync(
            RealtimeItem.CreateUserMessage(["The next special word you know about is 'coconut'."]),
            CancellationToken);

        bool gotSessionStarted = false;
        bool gotSessionConfigured = false;
        bool gotResponseFinished = false;

        await foreach (RealtimeUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is ConversationSessionStartedUpdate)
            {
                gotSessionStarted = true;
            }

            if (update is ConversationSessionConfiguredUpdate sessionConfiguredUpdate)
            {
                Assert.That(sessionConfiguredUpdate.TurnDetectionOptions.Kind, Is.EqualTo(TurnDetectionKind.Disabled));
                Assert.That(sessionConfiguredUpdate.ContentModalities.HasFlag(RealtimeContentModalities.Text), Is.True);
                Assert.That(sessionConfiguredUpdate.ContentModalities.HasFlag(RealtimeContentModalities.Audio), Is.False);
                gotSessionConfigured = true;
            }

            if (update is ItemCreatedUpdate itemCreatedUpdate)
            {
                if (itemCreatedUpdate.MessageContentParts.Count > 0
                    && itemCreatedUpdate.MessageContentParts[0].Text.Contains("banana"))
                {
                    await session.DeleteItemAsync(itemCreatedUpdate.ItemId, CancellationToken);
                    await session.AddItemAsync(
                        RealtimeItem.CreateUserMessage(["What's the second special word you know about?"]),
                        CancellationToken);
                    await session.StartResponseAsync(CancellationToken);
                }
            }

            if (update is ResponseFinishedUpdate responseFinishedUpdate)
            {
                Assert.That(responseFinishedUpdate.CreatedItems.Count, Is.EqualTo(1));
                Assert.That(responseFinishedUpdate.CreatedItems[0].MessageContentParts.Count, Is.EqualTo(1));
                Assert.That(responseFinishedUpdate.CreatedItems[0].MessageContentParts[0].Text, Does.Contain("coconut"));
                Assert.That(responseFinishedUpdate.CreatedItems[0].MessageContentParts[0].Text, Does.Not.Contain("banana"));
                gotResponseFinished = true;
                break;
            }
        }

        Assert.That(gotSessionStarted, Is.True);
        if (!client.GetType().IsSubclassOf(typeof(RealtimeClient)))
        {
            Assert.That(gotSessionConfigured, Is.True);
        }
        Assert.That(gotResponseFinished, Is.True);
    }

    [Test]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
    [TestCase(null)]
    public async Task AudioWithToolsWorks(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        RealtimeClient client = GetTestClient(GetTestClientOptions(version));
        using RealtimeSession session = await client.StartConversationSessionAsync(GetTestDeployment(), new RealtimeSessionOptions(), CancellationToken);

        ConversationFunctionTool getWeatherTool = new("get_weather_for_location")
        {
            Description = "gets the weather for a location",
            Parameters = BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                "location": {
                    "type": "string",
                    "description": "The city and state e.g. San Francisco, CA"
                },
                "unit": {
                    "type": "string",
                    "enum": [
                    "c",
                    "f"
                    ]
                }
                },
                "required": [
                "location",
                "unit"
                ]
            }
            """)
        };

        ConversationSessionOptions options = new()
        {
            Instructions = "Call provided tools if appropriate for the user's input.",
            Voice = ConversationVoice.Alloy,
            Tools = { getWeatherTool },
            InputTranscriptionOptions = new InputTranscriptionOptions()
            {
                Model = "whisper-1"
            },
        };

        await session.ConfigureConversationSessionAsync(options, CancellationToken);

        string audioFilePath = Directory.EnumerateFiles("Assets")
            .First(path => path.Contains("whats_the_weather_pcm16_24khz_mono.wav"));
        using Stream audioStream = File.OpenRead(audioFilePath);
        _ = session.SendInputAudioAsync(audioStream, CancellationToken);

        string userTranscript = null;

        await foreach (RealtimeUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is ConversationSessionStartedUpdate sessionStartedUpdate)
            {
                Assert.That(sessionStartedUpdate.SessionId, Is.Not.Null.And.Not.Empty);
                Assert.That(sessionStartedUpdate.Model, Is.Not.Null.And.Not.Empty);
                Assert.That(sessionStartedUpdate.ContentModalities.HasFlag(RealtimeContentModalities.Text));
                Assert.That(sessionStartedUpdate.ContentModalities.HasFlag(RealtimeContentModalities.Audio));
                Assert.That(sessionStartedUpdate.Voice.ToString(), Is.Not.Null.And.Not.Empty);
                Assert.That(sessionStartedUpdate.Temperature, Is.GreaterThan(0));
            }

            if (update is InputAudioTranscriptionFinishedUpdate inputTranscriptionCompletedUpdate)
            {
                userTranscript = inputTranscriptionCompletedUpdate.Transcript;
            }

            if (update is OutputStreamingFinishedUpdate itemFinishedUpdate
                && itemFinishedUpdate.FunctionCallId is not null)
            {
                Assert.That(itemFinishedUpdate.FunctionName, Is.EqualTo(getWeatherTool.Name));

                RealtimeItem functionResponse = RealtimeItem.CreateFunctionCallOutput(
                    itemFinishedUpdate.FunctionCallId,
                    "71 degrees Fahrenheit, sunny");
                await session.AddItemAsync(functionResponse, CancellationToken);
            }

            if (update is ResponseFinishedUpdate turnFinishedUpdate)
            {
                if (turnFinishedUpdate.CreatedItems.Any(item => !string.IsNullOrEmpty(item.FunctionCallId)))
                {
                    await session.StartResponseAsync(CancellationToken);
                }
                else
                {
                    break;
                }
            }
        }

        Assert.That(userTranscript, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
    [TestCase(null)]
    public async Task CanDisableVoiceActivityDetection(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        RealtimeClient client = GetTestClient(GetTestClientOptions(version));
        using RealtimeSession session = await client.StartConversationSessionAsync(GetTestDeployment(), new RealtimeSessionOptions(), CancellationToken);

        await session.ConfigureConversationSessionAsync(
            new()
            {
                TurnDetectionOptions = TurnDetectionOptions.CreateDisabledTurnDetectionOptions(),
            },
            CancellationToken);

        const string folderName = "Assets";
        const string fileName = "whats_the_weather_pcm16_24khz_mono.wav";
#if NET6_0_OR_GREATER
        using Stream audioStream = File.OpenRead(Path.Join(folderName, fileName));
#else
        using Stream audioStream = File.OpenRead($"{folderName}\\{fileName}");
#endif
        await session.SendInputAudioAsync(audioStream, CancellationToken);

        await session.AddItemAsync(RealtimeItem.CreateUserMessage(["Hello, assistant!"]), CancellationToken);

        await foreach (RealtimeUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is RealtimeErrorUpdate errorUpdate)
            {
                Assert.Fail($"Error received: {ModelReaderWriter.Write(errorUpdate)}");
            }

            if (update is InputAudioSpeechStartedUpdate
                or InputAudioSpeechFinishedUpdate
                or InputAudioTranscriptionDeltaUpdate
                or InputAudioTranscriptionFinishedUpdate
                or InputAudioTranscriptionFailedUpdate
                or ResponseStartedUpdate
                or ResponseFinishedUpdate)
            {
                Assert.Fail($"Shouldn't receive any VAD events or response creation!");
            }

            if (update is ItemCreatedUpdate itemCreatedUpdate
                && itemCreatedUpdate.MessageRole == ConversationMessageRole.User)
            {
                break;
            }
        }
    }

    [Test]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
    [TestCase(null)]
    public async Task CanUseManualVadTurnDetection(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        RealtimeClient client = GetTestClient(GetTestClientOptions(version));
        using RealtimeSession session = await client.StartConversationSessionAsync(GetTestDeployment(), new RealtimeSessionOptions(), CancellationToken);

        await session.ConfigureConversationSessionAsync(
            new()
            {
                InputTranscriptionOptions = new InputTranscriptionOptions()
                {
                    Model = "whisper-1",
                },
                TurnDetectionOptions = TurnDetectionOptions.CreateServerVoiceActivityTurnDetectionOptions(
                    enableAutomaticResponseCreation: false),
            },
            CancellationToken);

        const string folderName = "Assets";
        const string fileName = "whats_the_weather_pcm16_24khz_mono.wav";
#if NET6_0_OR_GREATER
        using Stream audioStream = File.OpenRead(Path.Join(folderName, fileName));
#else
        using Stream audioStream = File.OpenRead($"{folderName}\\{fileName}");
#endif
        await session.SendInputAudioAsync(audioStream, CancellationToken);

        bool gotInputTranscriptionCompleted = false;
        bool responseExpected = false;
        bool gotResponseStarted = false;
        bool gotResponseFinished = false;

        await foreach (RealtimeUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is RealtimeErrorUpdate errorUpdate)
            {
                Assert.Fail($"Error received: {ModelReaderWriter.Write(errorUpdate)}");
            }

            if (update is InputAudioTranscriptionFinishedUpdate inputTranscriptionFinishedUpdate)
            {
                Assert.That(gotInputTranscriptionCompleted, Is.False);
                Assert.That(inputTranscriptionFinishedUpdate.Transcript, Is.Not.Null.And.Not.Empty);
                gotInputTranscriptionCompleted = true;
                await Task.Delay(TimeSpan.FromMilliseconds(500), CancellationToken);
                await session.StartResponseAsync(CancellationToken);
                responseExpected = true;
            }

            if (update is ResponseStartedUpdate responseStartedUpdate)
            {
                Assert.That(responseExpected, Is.True);
                Assert.That(gotInputTranscriptionCompleted, Is.True);
                Assert.That(gotResponseFinished, Is.False);
                gotResponseStarted = true;
            }

            if (update is ResponseFinishedUpdate responseFinishedUpdate)
            {
                Assert.That(responseExpected, Is.True);
                Assert.That(gotInputTranscriptionCompleted, Is.True);
                Assert.That(gotResponseStarted, Is.True);
                Assert.That(gotResponseFinished, Is.False);
                gotResponseFinished = true;
                break;
            }
        }

        Assert.IsTrue(gotInputTranscriptionCompleted);
        Assert.IsTrue(gotResponseStarted);
        Assert.IsTrue(gotResponseFinished);
    }

    [Test]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
    [TestCase(null)]
    public async Task BadCommandProvidesError(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        RealtimeClient client = GetTestClient(GetTestClientOptions(version));
        using RealtimeSession session = await client.StartConversationSessionAsync(GetTestDeployment(), new RealtimeSessionOptions(), CancellationToken);

        await session.SendCommandAsync(
            BinaryData.FromString("""
                {
                  "type": "update_conversation_config2",
                  "event_id": "event_fabricated_1234abcd"
                }
                """),
            CancellationOptions);

        bool gotErrorUpdate = false;

        await foreach (RealtimeUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is RealtimeErrorUpdate errorUpdate)
            {
                Assert.That(errorUpdate.ErrorEventId, Is.EqualTo("event_fabricated_1234abcd"));
                gotErrorUpdate = true;
                break;
            }
        }

        Assert.That(gotErrorUpdate, Is.True);
    }

    [Test]
    [TestCase(null)]
    [Ignore("Transcription intent not yet supported on AOAI")]
    public async Task TranscriptionWorks(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        RealtimeClient client = GetTestClient(GetTestClientOptions(version));
        using RealtimeSession session = await client.StartTranscriptionSessionAsync(new RealtimeSessionOptions(), CancellationToken);

        TranscriptionSessionOptions options = new()
        {
            InputAudioFormat = RealtimeAudioFormat.Pcm16,
            TurnDetectionOptions = TurnDetectionOptions.CreateServerVoiceActivityTurnDetectionOptions(),
            InputNoiseReductionOptions = InputNoiseReductionOptions.CreateNearFieldOptions(),
            InputTranscriptionOptions = new()
            {
                Model = "whisper-1",
            },
        };
        await session.ConfigureTranscriptionSessionAsync(options, CancellationToken);

        string audioFilePath = Directory.EnumerateFiles("Assets")
            .First(path => path.Contains("whats_the_weather_pcm16_24khz_mono.wav"));
        using Stream audioStream = File.OpenRead(audioFilePath);
        _ = session.SendInputAudioAsync(audioStream, CancellationToken);

        await foreach (RealtimeUpdate update in session.ReceiveUpdatesAsync(CancellationToken))
        {
            if (update is InputAudioTranscriptionFinishedUpdate transcriptionFinishedUpdate)
            {
                break;
            }
        }
    }

#endif // "else" to AZURE_OPENAI_GA, !NET
}
