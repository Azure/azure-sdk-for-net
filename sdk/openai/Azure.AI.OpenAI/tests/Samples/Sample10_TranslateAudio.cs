// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples
{
    public partial class AudioSamples
    {
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
    }
}
