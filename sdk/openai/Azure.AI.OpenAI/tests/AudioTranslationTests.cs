// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

public class AudioTranslationTests : OpenAITestBase
{
    public AudioTranslationTests(bool isAsync)
        : base(isAsync) // , RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure, "json")]
    [TestCase(OpenAIClientServiceTarget.Azure, null)]
    [TestCase(OpenAIClientServiceTarget.Azure, "verbose_json")]
    [TestCase(OpenAIClientServiceTarget.Azure, "srt")]
    [TestCase(OpenAIClientServiceTarget.Azure, "vtt")]
    [TestCase(OpenAIClientServiceTarget.NonAzure, "json")]
    [TestCase(OpenAIClientServiceTarget.NonAzure, null)]
    [TestCase(OpenAIClientServiceTarget.NonAzure, "verbose_json")]
    [TestCase(OpenAIClientServiceTarget.NonAzure, "srt")]
    [TestCase(OpenAIClientServiceTarget.NonAzure, "vtt")]
    public async Task TranslationWorksWithFormat(
    OpenAIClientServiceTarget serviceTarget,
    string translationFormat)
    {
        OpenAIClient client = GetDevelopmentTestClient(
            serviceTarget,
            "AOAI_WHISPER_RESOURCE_URL",
            "AOAI_WHISPER_RESOURCE_API_KEY");
        string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(
            serviceTarget,
            OpenAIClientScenario.AudioTranscription);

        using Stream audioFileStream = GetTestAudioInputStream();

        var requestOptions = new AudioTranslationOptions()
        {
            DeploymentName = deploymentOrModelName,
            AudioData = BinaryData.FromStream(audioFileStream),
            Temperature = (float)0.25,
        };

        if (translationFormat != null && !string.IsNullOrEmpty(translationFormat.ToString()))
        {
            requestOptions.ResponseFormat = translationFormat switch
            {
                "json" => AudioTranslationFormat.Simple,
                "verbose_json" => AudioTranslationFormat.Verbose,
                "srt" => AudioTranslationFormat.Srt,
                "vtt" => AudioTranslationFormat.Vtt,
                _ => throw new ArgumentException($"Unknown response format provided to test: {translationFormat}"),
            };
        }

        Response<AudioTranslation> response = await client.GetAudioTranslationAsync(requestOptions);

        string text = response.Value.Text;
        Assert.That(text, Is.Not.Null.Or.Empty);

        bool onlyTextExpected = translationFormat switch
        {
            null => true,
            "json" => true,
            "verbose_json" => false,
            "srt" => true,
            "vtt" => true,
            _ => throw new ArgumentException($"Unknown response format provided to test: {translationFormat}"),
        };

        if (onlyTextExpected)
        {
            Assert.That(response.Value.Duration, Is.Null);
            Assert.That(response.Value.Language, Is.Null);
            Assert.That(response.Value.Segments, Is.Null.Or.Empty);
        }
        else
        {
            Assert.That(response.Value.Duration, Is.GreaterThan(TimeSpan.FromSeconds(0)));
            Assert.That(response.Value.Language, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Segments, Is.Not.Null.Or.Empty);
            AudioTranslationSegment firstSegment = response.Value.Segments[0];
            Assert.That(firstSegment, Is.Not.Null);
            Assert.That(firstSegment.Id, Is.EqualTo(0));
            Assert.That(firstSegment.Start, Is.GreaterThanOrEqualTo(TimeSpan.FromSeconds(0)));
            Assert.That(firstSegment.End, Is.GreaterThan(firstSegment.Start));
            Assert.That(firstSegment.Tokens, Is.Not.Null.Or.Empty);
        }
    }
}
