// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.AI.Inference.Tests.Samples
{
    internal class Sample12_ChatCompletionsWithAudioInput
    {
        public void SampleAudioInput()
        {
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

            // Can pass in a file pointer to a path on disk, converts to "input_audio".
            string audioFilePath = "Data\\audio.mp3";
            ChatMessageAudioContentItem audioContentItem = new ChatMessageAudioContentItem(audioFilePath, AudioContentFormat.Mp3);

            // Can pass in a stream, converts to "input_audio".
            Stream fileStream = File.OpenRead(audioFilePath);
            audioContentItem = new ChatMessageAudioContentItem(fileStream, AudioContentFormat.Mp3);

            // Can pass in bytes, converts to "input_audio".
            BinaryData bytes = new BinaryData(File.ReadAllBytes(audioFilePath));
            audioContentItem = new ChatMessageAudioContentItem(bytes, AudioContentFormat.Mp3);

            // Can pass in a URL pointer to an audio file, converts to "audio_url".
            audioContentItem = new ChatMessageAudioContentItem(new Uri("https://example.com/image.jpg"));

            // Can pass in a URL containing a base64-encoded string and the audio format, converts to "audio_url".
            string base64AudioData = Convert.ToBase64String(bytes.ToArray());
            audioContentItem = new ChatMessageAudioContentItem(new Uri($"data:audio/mp3;base64,{base64AudioData}"));

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("Translate this audio for me"),
                        audioContentItem),
                },
            };

            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Content);
        }
    }
}
