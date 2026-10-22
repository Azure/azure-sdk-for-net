// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP001
#pragma warning disable AAIP002
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Tests.Samples;

[NonParallelizable]
[LiveOnly]
public class Sample_VoiceAgent_WebSocketAudio : SamplesBase
{
    public Sample_VoiceAgent_WebSocketAudio(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [AsyncOnly]
    public async Task VoiceAgentWebSocketAudioAsync()
    {
        #region Snippet:Sample_VoiceAgent_WebSocketAudio_Create
#if SNIPPET
        string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
        string speechPath = Environment.GetEnvironmentVariable("VOICE_SAMPLE_AUDIO_PATH");
#else
        string projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string modelDeploymentName = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME;
        string speechPath = Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory,
            "..", "..", "..", "..", "..", "sdk", "openai", "Azure.AI.OpenAI", "tests", "Assets",
            "whats_the_weather_pcm16_24khz_mono.wav"));
#endif
        using Stream speechFile = File.OpenRead(speechPath);
        byte[] speech = ReadPcmWave(speechFile);
        const int audioSampleRate = 24000;
        string agentName = $"voice-audio-sample-{Guid.NewGuid():N}".Substring(0, 40);
        AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());

        VoiceAgentDefinition definition = new()
        {
            ModelType = VoiceModelType.SelfDeployed,
            Model = modelDeploymentName,
            Instructions = "Identify the subject of the spoken question in one English sentence. " +
                "You cannot access live information; do not invent facts or promise a lookup.",
            Audio = new VoiceAgentAudioConfig
            {
                Input = new VoiceAgentAudioInputConfig
                {
                    Format = new RealtimePcmAudioFormat { Rate = audioSampleRate },
                    TurnDetection = null
                },
                Output = new VoiceAgentAudioOutputConfig
                {
                    Format = new RealtimePcmAudioFormat { Rate = audioSampleRate }
                }
            }
        };
        definition.OutputModalities.Add(VoiceOutputModality.Audio);
        ClientResult<ProjectsAgentVersion> createResult = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(definition));
        ProjectsAgentVersion agentVersion = createResult;
        Console.WriteLine($"Created voice agent {agentName} version {agentVersion.Version}: HTTP {createResult.GetRawResponse().Status}");
        #endregion
        try
        {
            #region Snippet:Sample_VoiceAgent_WebSocketAudio_Stream
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
            ProjectsRealtimeSessionClientOptions options = new()
            {
                Transport = VoiceAgentTransport.Websocket
            };
            using ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)
                await projectClient.ProjectsRealtimeClient.StartSessionAsync(
                    agentName, intent: null, options: options, cancellationToken: timeout.Token);
            long inputAudioBytes = 0;
            const int chunkBytes = 960;
            for (int offset = 0; offset < speech.Length; offset += chunkBytes)
            {
                int count = Math.Min(chunkBytes, speech.Length - offset);
                await session.SendInputAudioAsync(BinaryData.FromBytes(speech.AsMemory(offset, count)), timeout.Token);
                inputAudioBytes += count;
                await Task.Delay(TimeSpan.FromMilliseconds(20), timeout.Token);
            }
            await session.CommitPendingAudioAsync(timeout.Token);
            await session.StartResponseAsync(
                new RealtimeResponseOptions { ToolChoice = RealtimeDefaultToolChoice.None }, timeout.Token);

            long outputAudioBytes = 0;
            string transcript = string.Empty;
            bool sawCompletedResponse = false;
            await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
            {
                Console.WriteLine($"Received event: {update.Kind}");
                if (update is RealtimeServerUpdateResponseOutputAudioDelta audioDelta)
                {
                    outputAudioBytes += audioDelta.Delta.ToArray().Length;
                }
                else if (update is RealtimeServerUpdateResponseOutputAudioTranscriptDone transcriptDone)
                {
                    transcript = transcriptDone.Transcript;
                }
                else if (update is RealtimeServerUpdateResponseDone doneUpdate)
                {
                    Console.WriteLine($"Response status: {doneUpdate.Response.Status}");
                    sawCompletedResponse = doneUpdate.Response.Status == RealtimeResponseStatus.Completed;
                    break;
                }
            }

            const int channels = 1;
            int bytesPerSecond = audioSampleRate * channels * sizeof(short);
            Console.WriteLine($"Input audio sent: {inputAudioBytes} bytes ({inputAudioBytes / 1024.0:F1} KB), " +
                $"{inputAudioBytes / (double)bytesPerSecond:F2}s PCM16 / {audioSampleRate} Hz / {channels} channel");
            Console.WriteLine($"Output audio received: {outputAudioBytes} bytes ({outputAudioBytes / 1024.0:F1} KB), " +
                $"{outputAudioBytes / (double)bytesPerSecond:F2}s PCM16 / {audioSampleRate} Hz / {channels} channel");
            Console.WriteLine($"Total audio transferred: {inputAudioBytes + outputAudioBytes} bytes " +
                $"({(inputAudioBytes + outputAudioBytes) / 1024.0:F1} KB)");
            Console.WriteLine($"Output transcript: {transcript}");
            if (!sawCompletedResponse || inputAudioBytes == 0 || outputAudioBytes == 0)
            {
                throw new InvalidOperationException("The voice agent did not complete an audio exchange.");
            }
            #endregion
#if !SNIPPET
            Assert.That(transcript, Does.Contain("weather").IgnoreCase.Or.Contain("forecast").IgnoreCase.Or.Contain("conditions").IgnoreCase);
#endif
        }
        finally
        {
            #region Snippet:Sample_VoiceAgent_WebSocketAudio_Cleanup
            ClientResult deleteResult = await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(
                agentName: agentName, agentVersion: agentVersion.Version);
            Console.WriteLine($"Deleted voice agent {agentName} version {agentVersion.Version}: HTTP {deleteResult.GetRawResponse().Status}");
            #endregion
        }
    }

    private static byte[] ReadPcmWave(Stream stream)
    {
        using BinaryReader reader = new(stream, Encoding.ASCII, leaveOpen: true);
        if (new string(reader.ReadChars(4)) != "RIFF")
        {
            throw new InvalidDataException("Use a mono PCM16LE/24 kHz WAV recording.");
        }
        reader.ReadUInt32();
        if (new string(reader.ReadChars(4)) != "WAVE")
        {
            throw new InvalidDataException("The recording is not a WAV file.");
        }
        bool pcm = false;
        while (stream.Position + 8 <= stream.Length)
        {
            string chunk = new(reader.ReadChars(4));
            uint length = reader.ReadUInt32();
            long end = stream.Position + length;
            if (end > stream.Length)
            {
                throw new EndOfStreamException("The WAV recording is truncated.");
            }
            if (chunk == "fmt ")
            {
                ushort format = reader.ReadUInt16();
                ushort channels = reader.ReadUInt16();
                uint rate = reader.ReadUInt32();
                reader.ReadUInt32();
                reader.ReadUInt16();
                pcm = format == 1 && channels == 1 && rate == 24000 && reader.ReadUInt16() == 16;
            }
            else if (chunk == "data")
            {
                if (!pcm || length == 0 || length % 2 != 0 || length > int.MaxValue)
                {
                    throw new InvalidDataException("Use nonempty mono PCM16LE/24 kHz speech.");
                }
                return reader.ReadBytes((int)length);
            }
            stream.Position = end + (length & 1);
        }
        throw new InvalidDataException("No PCM audio was found in the recording.");
    }
}
