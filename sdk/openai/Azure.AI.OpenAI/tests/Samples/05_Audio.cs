using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using OpenAI.Audio;

namespace Azure.AI.OpenAI.Tests.Samples
{
    public partial class AzureOpenAISamples
    {
        public void TranscribeAudio()
        {
            AzureOpenAIClient azureClient = new(
                new Uri("https://your-azure-openai-resource.com"),
                new DefaultAzureCredential());

            AudioClient chatClient = azureClient.GetAudioClient("whisper");

            string fileName = "batman.wav";
            string audioFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName);
            var transcriptionResult = chatClient.TranscribeAudio(audioFilePath);
            Console.WriteLine(transcriptionResult.Value.Text.ToString());
        }
        public async Task TranscribeAudioAsync()
        {
            AzureOpenAIClient azureClient = new(
                new Uri("https://your-azure-openai-resource.com"),
                new DefaultAzureCredential());

            AudioClient chatClient = azureClient.GetAudioClient("whisper");
            AudioTranscriptionOptions transcriptionOptions = new AudioTranscriptionOptions
            {
                Language = "en", // Specify the language if needed
                ResponseFormat = AudioTranscriptionFormat.Simple, // Specify the response format
                Temperature = 0.1f // Set temperature for transcription
            };

            string fileName = "batman.wav";
            string audioFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName);
            var transcriptionResult = await chatClient.TranscribeAudioAsync(audioFilePath, transcriptionOptions);
            Console.WriteLine(transcriptionResult.Value.Text.ToString());
        }
    }
}
