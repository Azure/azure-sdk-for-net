// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples
{
    public partial class StreamingChat
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task TranscribeAudio()
        {
            string endpoint = "https://myaccount.openai.azure.com/";
            var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

            #region Snippet:TranscribeAudio
            using Stream audioStreamFromFile = File.OpenRead("myAudioFile.mp3");
            BinaryData audioFileData = BinaryData.FromStream(audioStreamFromFile);

            var transcriptionOptions = new AudioTranscriptionOptions()
            {
                File = BinaryData.FromStream(audioStreamFromFile),
                ResponseFormat = AudioTranscriptionFormat.VerboseJson,
            };

            Response<AudioTranscription> transcriptionResponse = await client.GetAudioTranscriptionAsync(
                deploymentId: "my-whisper-deployment", // whisper-1 as model name for non-Azure OpenAI
                transcriptionOptions);
            AudioTranscription transcription = transcriptionResponse.Value;

            // When using Text, Vtt, Json formats, only .Text will be populated
            Console.WriteLine($"Transcription ({transcription.Duration.TotalSeconds}s):");
            Console.WriteLine(transcription.Text);
            #endregion
        }
    }
}
