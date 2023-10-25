// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
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

            var transcriptionOptions = new AudioTranscriptionOptions()
            {
                AudioData = BinaryData.FromStream(audioStreamFromFile),
                ResponseFormat = AudioTranscriptionFormat.Verbose,
            };

            Response<AudioTranscription> transcriptionResponse = await client.GetAudioTranscriptionAsync(
                deploymentId: "my-whisper-deployment", // whisper-1 as model name for non-Azure OpenAI
                transcriptionOptions);
            AudioTranscription transcription = transcriptionResponse.Value;

            // When using Simple, SRT, or VTT formats, only transcription.Text will be populated
            Console.WriteLine($"Transcription ({transcription.Duration.Value.TotalSeconds}s):");
            Console.WriteLine(transcription.Text);
            #endregion
        }
    }
}
