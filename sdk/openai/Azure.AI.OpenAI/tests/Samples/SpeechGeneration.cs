// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

public partial class SpeechGeneration
{
    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task GenerateSpeech()
    {
        string endpoint = "https://myaccount.openai.azure.com/";
        OpenAIClient client = new(new Uri(endpoint), new DefaultAzureCredential());
        const bool usingAzure = true;

        #region Snippet:SpeechGeneration
        SpeechGenerationOptions speechOptions = new()
        {
            Input = "Hello World",
            DeploymentName = usingAzure ? "my-azure-openai-tts-deployment" : "tts-1",
            Voice = SpeechVoice.Alloy,
            ResponseFormat = SpeechGenerationResponseFormat.Mp3,
            Speed = 1.0f
        };

        Response<BinaryData> response = await client.GenerateSpeechFromTextAsync(speechOptions);
        File.WriteAllBytes("myAudioFile.mp3", response.Value.ToArray());
        #endregion
    }
}
