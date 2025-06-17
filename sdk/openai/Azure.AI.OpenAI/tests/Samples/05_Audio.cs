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
        public async Task TranscribeAudioAsync()
        {
            AzureOpenAIClient azureClient = new(
                new Uri("https://your-azure-openai-resource.com"),
                new DefaultAzureCredential());

            AudioClient chatClient = azureClient.GetAudioClient("whisper");

            string fileName = "batman.wav";
            string audioFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Samples", "Resources", fileName);
            var transcriptionResult = await chatClient.TranscribeAudioAsync(audioFilePath);

            Console.WriteLine(transcriptionResult.Value.Text.ToString());
        }
    }
}
