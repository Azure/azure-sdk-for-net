// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

public class AudioSpeechTests : OpenAITestBase
{
    public AudioSpeechTests(bool isAsync)
        : base(Scenario.AudioSpeech, isAsync) // , RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(Service.Azure)]
    [TestCase(Service.NonAzure)]
    public async Task GetAudioSpeech(Service serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

        AudioSpeechOptions requestOptions = new(deploymentOrModelName, "Hello World", AudioSpeechVoice.Alloy)
        {
            ResponseFormat = AudioSpeechOutputFormat.Mp3,
            Speed = 0.8f
        };

        Response<BinaryData> response = await client.GetAudioSpeechAsync(requestOptions);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Value, Is.InstanceOf<BinaryData>());
        byte[] byteArray = response.Value.ToArray();
        Assert.That(byteArray, Is.Not.Empty);
    }
}
