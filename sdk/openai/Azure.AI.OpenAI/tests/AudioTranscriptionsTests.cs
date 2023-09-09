// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

public class AudioTranscriptionsTest : OpenAITestBase
{
    public AudioTranscriptionsTest(bool isAsync)
        : base(isAsync) // , RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure, "json")]
    [TestCase(OpenAIClientServiceTarget.Azure, null)]
    [TestCase(OpenAIClientServiceTarget.Azure, "verbose_json")]
    [TestCase(OpenAIClientServiceTarget.Azure, "text")]
    [TestCase(OpenAIClientServiceTarget.NonAzure, "json")]
    [TestCase(OpenAIClientServiceTarget.NonAzure, null)]
    [TestCase(OpenAIClientServiceTarget.NonAzure, "verbose_json")]
    [TestCase(OpenAIClientServiceTarget.NonAzure, "text")]
    public async Task TranscriptionWorksWithFormat(
        OpenAIClientServiceTarget serviceTarget,
        string transcriptionFormat)
    {
        OpenAIClient client = GetDevelopmentTestClient(
            serviceTarget,
            "AOAI_WHISPER_RESOURCE_URL",
            "AOAI_WHISPER_RESOURCE_API_KEY");
        string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(
            serviceTarget,
            OpenAIClientScenario.AudioTranscription);

        string audioFilePath = GetTestAudioInputPath();
        using Stream audioFileStream = File.OpenRead(audioFilePath);

        var requestOptions = new AudioTranscriptionOptions()
        {
            AudioData = BinaryData.FromStream(audioFileStream),
            Temperature = (float)0.25,
        };

        if (transcriptionFormat != null && !string.IsNullOrEmpty(transcriptionFormat.ToString()))
        {
            requestOptions.ResponseFormat = transcriptionFormat;
        }

        Response<AudioTranscription> response = await client.GetAudioTranscriptionAsync(
            deploymentOrModelName,
            requestOptions);

        string text = response.Value.Text;
        Assert.That(text, Is.Not.Null.Or.Empty);

        if (transcriptionFormat == null
            || transcriptionFormat == AudioTranscriptionFormat.SimpleJson
            || transcriptionFormat == AudioTranscriptionFormat.PlainText)
        {
            Assert.That(response.Value.Duration, Is.Null);
            Assert.That(response.Value.Language, Is.Null);
            Assert.That(response.Value.Segments, Is.Not.Null.Or.Empty);
        }

        if (transcriptionFormat != null && transcriptionFormat == AudioTranscriptionFormat.VerboseJson)
        {
            Assert.That(response.Value.Duration, Is.GreaterThan(TimeSpan.FromSeconds(0)));
            Assert.That(response.Value.Language, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Segments, Is.Not.Null.Or.Empty);
            AudioTranscriptionSegment firstSegment = response.Value.Segments[0];
            Assert.That(firstSegment, Is.Not.Null);
            Assert.That(firstSegment.Id, Is.EqualTo(0));
            Assert.That(firstSegment.Start, Is.GreaterThanOrEqualTo(0));
            Assert.That(firstSegment.End, Is.GreaterThan(firstSegment.Start));
            Assert.That(firstSegment.Tokens, Is.Not.Null.Or.Empty);
        }
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure, "json")]
    [TestCase(OpenAIClientServiceTarget.Azure, null)]
    [TestCase(OpenAIClientServiceTarget.Azure, "verbose_json")]
    [TestCase(OpenAIClientServiceTarget.Azure, "text")]
    [TestCase(OpenAIClientServiceTarget.NonAzure, "json")]
    [TestCase(OpenAIClientServiceTarget.NonAzure, null)]
    [TestCase(OpenAIClientServiceTarget.NonAzure, "verbose_json")]
    [TestCase(OpenAIClientServiceTarget.NonAzure, "text")]
    public async Task TranslationWorksWithFormat(
    OpenAIClientServiceTarget serviceTarget,
    string transcriptionFormat)
    {
        OpenAIClient client = GetDevelopmentTestClient(
            serviceTarget,
            "AOAI_WHISPER_RESOURCE_URL",
            "AOAI_WHISPER_RESOURCE_API_KEY");
        string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(
            serviceTarget,
            OpenAIClientScenario.AudioTranscription);

        string audioFilePath = GetTestAudioInputPath();
        using Stream audioFileStream = File.OpenRead(audioFilePath);

        var requestOptions = new AudioTranslationOptions()
        {
            AudioData = BinaryData.FromStream(audioFileStream),
            Temperature = (float)0.25,
        };

        if (transcriptionFormat != null && !string.IsNullOrEmpty(transcriptionFormat.ToString()))
        {
            requestOptions.ResponseFormat = transcriptionFormat;
        }

        Response<AudioTranscription> response = await client.GetAudioTranslationAsync(
            deploymentOrModelName,
            requestOptions);

        string text = response.Value.Text;
        Assert.That(text, Is.Not.Null.Or.Empty);

        if (transcriptionFormat == null
            || transcriptionFormat == AudioTranscriptionFormat.SimpleJson
            || transcriptionFormat == AudioTranscriptionFormat.PlainText)
        {
            Assert.That(response.Value.Duration, Is.EqualTo(default(TimeSpan)));
            Assert.That(response.Value.Language, Is.Null);
            Assert.That(response.Value.Segments, Is.Null.Or.Empty);
        }

        if (transcriptionFormat != null && transcriptionFormat == AudioTranscriptionFormat.VerboseJson)
        {
            Assert.That(response.Value.Duration, Is.GreaterThan(TimeSpan.FromSeconds(0)));
            Assert.That(response.Value.Language, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Segments, Is.Not.Null.Or.Empty);
            AudioTranscriptionSegment firstSegment = response.Value.Segments[0];
            Assert.That(firstSegment, Is.Not.Null);
            Assert.That(firstSegment.Id, Is.EqualTo(0));
            Assert.That(firstSegment.Start, Is.GreaterThanOrEqualTo(0));
            Assert.That(firstSegment.End, Is.GreaterThan(firstSegment.Start));
            Assert.That(firstSegment.Tokens, Is.Not.Null.Or.Empty);
        }
    }
}
