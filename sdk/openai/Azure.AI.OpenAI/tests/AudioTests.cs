// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Threading.Tasks;
using OpenAI.Audio;
using OpenAI.TestFramework;

namespace Azure.AI.OpenAI.Tests;

public class AudioTests(bool isAsync) : AoaiTestBase<AudioClient>(isAsync)
{
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<AudioClient>());

    [RecordedTest]
    public async Task TranscriptionWorks()
    {
        AudioClient audioClient = GetTestClient();
        AudioTranscription transcription = await audioClient.TranscribeAudioAsync(Assets.HelloWorld.RelativePath);
        Assert.That(transcription?.Text, Is.Not.Null.Or.Empty);
    }

    [RecordedTest]
    public async Task TranslationWorks()
    {
        AudioClient audioClient = GetTestClient();
        AudioTranslation translation = await audioClient.TranslateAudioAsync(Assets.WhisperFrenchDescription.RelativePath);
        Assert.That(translation?.Text, Is.Not.Null.Or.Empty);
    }

#if !AZURE_OPENAI_GA
    [RecordedTest]
    public async Task TextToSpeechWorks()
    {
        AudioClient audioClient = GetTestClient("tts");
        BinaryData ttsData = await audioClient.GenerateSpeechAsync(
            "hello, world!",
            GeneratedSpeechVoice.Alloy);
        Assert.That(ttsData, Is.Not.Null);
    }
#else
    [Test]
    public void VersionNotSupportedTextToSpeechThrows()
    {
        AudioClient audioClient = GetTestClient("tts");
        Assert.ThrowsAsync<InvalidOperationException>(async ()
            => await audioClient.GenerateSpeechAsync("hello, world!", GeneratedSpeechVoice.Alloy));
    }
#endif

    [RecordedTest]
    [TestCase("json")]
    [TestCase("verbose_json")]
    [TestCase("srt")]
    [TestCase("vtt")]
    [TestCase(null)]
    public async Task TranscriptionWorksWithFormat(string responseFormat)
    {
        AudioClient client = GetTestClient();

        var audioInfo = Assets.HelloWorld;
        using Stream audioFileStream = File.OpenRead(audioInfo.RelativePath);
        AudioTranscriptionOptions options = new()
        {
            Temperature = 0.25f,
            ResponseFormat = responseFormat switch
            {
                "text" => AudioTranscriptionFormat.Text,
                "json" => AudioTranscriptionFormat.Simple,
                "verbose_json" => AudioTranscriptionFormat.Verbose,
                "srt" => AudioTranscriptionFormat.Srt,
                "vtt" => AudioTranscriptionFormat.Vtt,
                _ => (AudioTranscriptionFormat?)null
            }
        };

        AudioTranscription transcription = await client.TranscribeAudioAsync(
            audioFileStream, audioInfo.Name, options);

        Assert.That(transcription, Is.Not.Null);
        Assert.That(transcription.Text, Is.Not.Null.Or.Empty);

        if (options.ResponseFormat == AudioTranscriptionFormat.Simple)
        {
            Assert.That(transcription.Duration, Is.Null);
            Assert.That(transcription.Language, Is.Null);
            Assert.That(transcription.Segments, Is.Null.Or.Empty);
        }
        else if (options.ResponseFormat == AudioTranscriptionFormat.Verbose)
        {
            Assert.That(transcription.Duration, Is.GreaterThan(TimeSpan.FromSeconds(0)));
            Assert.That(transcription.Language, Is.Not.Null.Or.Empty);
            Assert.That(transcription.Segments, Is.Not.Null.Or.Empty);

            TranscribedSegment firstSegment = transcription.Segments[0];
            Assert.That(firstSegment, Is.Not.Null);
            Assert.That(firstSegment.Id, Is.EqualTo(0));
            Assert.That(firstSegment.StartTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(0)));
            Assert.That(firstSegment.EndTime, Is.GreaterThan(firstSegment.StartTime));
            Assert.That(firstSegment.Text, Is.Not.Null.Or.Empty);
        }
    }

    [RecordedTest]
    [TestCase(AudioTimestampGranularities.Default)]
    [TestCase(AudioTimestampGranularities.Word)]
    [TestCase(AudioTimestampGranularities.Segment)]
    [TestCase(AudioTimestampGranularities.Word | AudioTimestampGranularities.Segment)]
    public async Task TranscriptionTimestampGranularitiesWork(AudioTimestampGranularities granularityFlags)
    {
        AudioClient client = GetTestClient();
        var audioInfo = Assets.HelloWorld;
        using Stream audioFileStream = File.OpenRead(audioInfo.RelativePath);
        AudioTranscriptionOptions options = new()
        {
            TimestampGranularities = granularityFlags,
            ResponseFormat = AudioTranscriptionFormat.Verbose,
        };
        ClientResult<AudioTranscription> transcriptionResult = await client.TranscribeAudioAsync(
            audioFileStream,
            audioInfo.Name,
            options);
        PipelineResponse response = transcriptionResult.GetRawResponse();
        Assert.That(response, Is.Not.Null);
        AudioTranscription transcription = transcriptionResult.Value;
        Assert.That(transcription.Text, Is.Not.Null.Or.Empty);
        Assert.That(
            transcription.Words?.Count > 0,
            Is.EqualTo(granularityFlags.HasFlag(AudioTimestampGranularities.Word)),
            "Word-level information should appear (and only appear) when requested");
        Assert.That(
            transcription.Segments?.Count > 0,
            Is.EqualTo(granularityFlags.HasFlag(AudioTimestampGranularities.Segment) || granularityFlags == AudioTimestampGranularities.Default),
            "Segment-level information should appear (and only appear) when requested or when no flags were provided");
    }

    [RecordedTest]
    [TestCase("json")]
    [TestCase("verbose")]
    [TestCase("srt")]
    [TestCase("vtt")]
    [TestCase(null)]
    public async Task TranslationWorksWithFormat(string responseFormat)
    {
        AudioClient client = GetTestClient();

        var audioInfo = Assets.WhisperFrenchDescription;
        using Stream audioFileStream = File.OpenRead(audioInfo.RelativePath);
        AudioTranslationOptions options = new()
        {
            ResponseFormat = responseFormat switch
            {
                "text" => AudioTranslationFormat.Text,
                "json" => AudioTranslationFormat.Simple,
                "verbose_json" => AudioTranslationFormat.Verbose,
                "srt" => AudioTranslationFormat.Srt,
                "vtt" => AudioTranslationFormat.Vtt,
                _ => (AudioTranslationFormat?)null
            }
        };

        AudioTranslation translation = await client.TranslateAudioAsync(
            audioFileStream, audioInfo.Name, options);

        Assert.That(translation, Is.Not.Null);
        Assert.That(translation.Text, Is.Not.Null.Or.Empty);

        if (options.ResponseFormat == AudioTranslationFormat.Simple)
        {
            Assert.That(translation.Duration, Is.Null);
            Assert.That(translation.Language, Is.Null);
            Assert.That(translation.Segments, Is.Null.Or.Empty);
        }
        else if (options.ResponseFormat == AudioTranslationFormat.Verbose)
        {
            Assert.That(translation.Duration, Is.GreaterThan(TimeSpan.FromSeconds(0)));
            Assert.That(translation.Language, Is.Not.Null.Or.Empty);
            Assert.That(translation.Segments, Is.Not.Null.Or.Empty);

            TranscribedSegment firstSegment = translation.Segments[0];
            Assert.That(firstSegment, Is.Not.Null);
            Assert.That(firstSegment.Id, Is.EqualTo(0));
            Assert.That(firstSegment.StartTime, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(0)));
            Assert.That(firstSegment.EndTime, Is.GreaterThan(firstSegment.StartTime));
            Assert.That(firstSegment.Text, Is.Not.Null.Or.Empty);
        }
    }
}
