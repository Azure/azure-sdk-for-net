// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

public class SpeechGenerationTests : OpenAITestBase
{
    public SpeechGenerationTests(bool isAsync)
        : base(Scenario.SpeechGeneration, isAsync) // , RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(Service.Azure)]
    [TestCase(Service.NonAzure)]
    public async Task GenerateSpeechFromText(Service serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

        SpeechGenerationOptions requestOptions = new()
        {
            DeploymentName = deploymentOrModelName,
            Input = "Hello World",
            Voice = SpeechVoice.Alloy,
            ResponseFormat = SpeechGenerationResponseFormat.Mp3,
        };

        Response<BinaryData> response = await client.GenerateSpeechFromTextAsync(requestOptions);

        Assert.That(response?.Value, Is.Not.Null);
        Assert.That(response.Value, Is.InstanceOf<BinaryData>());

        byte[] byteArray = response.Value.ToArray();
        Assert.That(byteArray, Is.Not.Empty);
    }
}
