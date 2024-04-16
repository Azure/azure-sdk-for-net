// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

public partial class WhisperAudioTranscription
{
    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task TranscribeAudio()
    {
        string endpoint = "https://myaccount.openai.azure.com/";
        var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

        #region Snippet:TranscribeAudio
        using Stream audioStreamFromFile = File.OpenRead("myAudioFile.mp3");

        var transcriptionOptions = new AudioTranscriptionOptions()
        {
            DeploymentName = "my-whisper-deployment", // whisper-1 as model name for non-Azure OpenAI
            AudioData = BinaryData.FromStream(audioStreamFromFile),
            Filename = "test.mp3",
            ResponseFormat = AudioTranscriptionFormat.Verbose,
        };

        Response<AudioTranscription> transcriptionResponse
            = await client.GetAudioTranscriptionAsync(transcriptionOptions);
        AudioTranscription transcription = transcriptionResponse.Value;

        // When using Simple, SRT, or VTT formats, only transcription.Text will be populated
        Console.WriteLine($"Transcription ({transcription.Duration.Value.TotalSeconds}s):");
        Console.WriteLine(transcription.Text);
        #endregion
    }

    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task TranslateAudio()
    {
        string endpoint = "https://myaccount.openai.azure.com/";
        var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

        #region Snippet:TranslateAudio
        using Stream audioStreamFromFile = File.OpenRead("mySpanishAudioFile.mp3");

        var translationOptions = new AudioTranslationOptions()
        {
            DeploymentName = "my-whisper-deployment", // whisper-1 as model name for non-Azure OpenAI
            AudioData = BinaryData.FromStream(audioStreamFromFile),
            ResponseFormat = AudioTranslationFormat.Verbose,
        };

        Response<AudioTranslation> translationResponse = await client.GetAudioTranslationAsync(translationOptions);
        AudioTranslation translation = translationResponse.Value;

        // When using Simple, SRT, or VTT formats, only translation.Text will be populated
        Console.WriteLine($"Translation ({translation.Duration.Value.TotalSeconds}s):");
        // .Text will be translated to English (ISO-639-1 "en")
        Console.WriteLine(translation.Text);
        #endregion
    }

    public AudioTranscriptionOptions GetOptionsWithTimestamps()
    {
        Stream audioDataStream = null;
        #region Snippet:RequestAudioTimestamps
        // To request timestamps for segments and/or words, specify the Verbose response format and provide the desired
        // combination of enum flags for the available timestamp granularities. If not otherwise specified, segments
        // will be provided. Note that words, unlike segments, will introduce additional processing latency to compute.
        AudioTranscriptionOptions optionsForTimestamps = new()
        {
            DeploymentName = "my-whisper-deployment",
            AudioData = BinaryData.FromStream(audioDataStream),
            Filename = "hello-world.mp3",
            ResponseFormat = AudioTranscriptionFormat.Verbose,
            TimestampGranularityFlags = AudioTimestampGranularity.Word | AudioTimestampGranularity.Segment,
        };
        #endregion
        return optionsForTimestamps;
    }
}
