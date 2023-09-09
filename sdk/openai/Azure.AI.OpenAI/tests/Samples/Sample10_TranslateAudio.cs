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
        public async Task TranslateAudio()
        {
            string endpoint = "https://myaccount.openai.azure.com/";
            var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

            #region Snippet:TranslateAudio
            using Stream audioStreamFromFile = File.OpenRead("mySpanishAudioFile.mp3");
            BinaryData audioFileData = BinaryData.FromStream(audioStreamFromFile);

            var translationOptions = new AudioTranslationOptions()
            {
                AudioData = BinaryData.FromStream(audioStreamFromFile),
                ResponseFormat = AudioTranscriptionFormat.VerboseJson,
            };

            Response<AudioTranscription> translationResponse = await client.GetAudioTranslationAsync(
                deploymentId: "my-whisper-deployment", // whisper-1 as model name for non-Azure OpenAI
                translationOptions);
            AudioTranscription transcription = translationResponse.Value;

            // When using Text, Vtt, Json formats, only .Text will be populated
            Console.WriteLine($"Transcription ({transcription.Duration.Value.TotalSeconds}s):");
            // .Text will be translated to English (ISO-639-1 "en")
            Console.WriteLine(transcription.Text);
            #endregion
        }
    }
}
