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
        string text = "Hello World";

        #region Snippet:SpeechGeneration
        AudioSpeechOptions speechOptions = new()
        {
            Input = text,
            DeploymentName = "my-tts-deployment", // tts-1 as model name for non-Azure OpenAI
            Voice = AudioSpeechVoice.Alloy,
            ResponseFormat = AudioSpeechOutputFormat.Mp3,
            Speed = 0.8f
        };

        Response<BinaryData> response = await client.GetAudioSpeechAsync(speechOptions);

        File.WriteAllBytes("myAudioFile.mp3", response.Value.ToArray());
        #endregion
    }
}
