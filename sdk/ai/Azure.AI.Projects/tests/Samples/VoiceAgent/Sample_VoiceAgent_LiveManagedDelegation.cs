// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using OpenAI.Responses;

#pragma warning disable AAIP001, AAIP002, OPENAI001

namespace Azure.AI.Projects.Tests.Samples;

public static class Sample_VoiceAgent_LiveManagedDelegation
{
    #region Snippet:Sample_VoiceAgent_LiveManagedDelegation
    public static async Task RunAsync(
        string projectEndpoint, string liveDeployment,
        string managedAgentName, string managedAgentVersion,
        string speechPcmPath, string expectedCommentary,
        CancellationToken cancellationToken)
    {
        using CancellationTokenSource timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeout.CancelAfter(TimeSpan.FromMinutes(3));
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        ProjectsAgentVersion backend = await project.AgentAdministrationClient.GetAgentVersionAsync(
            managedAgentName, managedAgentVersion, timeout.Token);
        if (backend.Definition is not DeclarativeAgentDefinition prompt || prompt.Tools.Count != 0)
        {
            throw new InvalidOperationException("Use an isolated, tool-free managed agent for this sample.");
        }

        ProjectResponsesClient reference = project.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
            new(name: managedAgentName, version: managedAgentVersion));
        var result = await reference.CreateResponseAsync(
            new[] { ResponseItem.CreateUserMessageItem("What's the weather like in San Francisco, California?") },
            cancellationToken: timeout.Token);
        Console.WriteLine("Reference commentary: " +
            ReadManagedCommentary(result.Value.GetOutputText(), expectedCommentary));

        VoiceAgentLiveDefinition definition = new(liveDeployment)
        {
            Instructions = "All weather requests in this session are demonstrations, not requests for real weather. " +
                "Delegate to the configured Foundry agent and repeat its verification marker verbatim. " +
                "Never replace the supplied result with generic facts.",
            Store = false,
            Audio = new LiveInitialSessionAudioParam
            {
                Format = new LiveSessionAudioFormatPCMParam(LiveSessionAudioFormatPCMParamRate._24000)
            },
            Delegation = new VoiceAgentLiveManagedAgentDelegation(managedAgentName)
            {
                AgentVersion = managedAgentVersion
            }
        };
        string agentName = "voice-" + Guid.NewGuid().ToString("N");
        try
        {
            await project.AgentAdministrationClient.CreateAgentVersionAsync(
                agentName, new ProjectsAgentVersionCreationOptions(definition),
                foundryFeatures: "VoiceAgents=V1Preview", cancellationToken: timeout.Token);
            using ProjectsLiveSessionClient session = await project.ProjectsLiveClient.StartSessionAsync(
                agentName, new ProjectsLiveSessionClientOptions { Store = false }, timeout.Token);
            if (session.SessionStarted.Session.Delegation is not VoiceAgentLiveManagedAgentDelegation owner ||
                owner.AgentName != managedAgentName || owner.AgentVersion != managedAgentVersion)
            {
                throw new InvalidOperationException("The session did not resolve the pinned managed agent.");
            }

            Task receive = ReceiveResultAsync(session, expectedCommentary, timeout.Token);
            await SendSpeechAsync(session, speechPcmPath, receive, timeout.Token);
            await session.CloseAsync(timeout.Token);
            await receive;
            if (session.SessionClosed == null)
            {
                throw new InvalidOperationException("The service did not confirm native session closure.");
            }
        }
        finally
        {
            using CancellationTokenSource cleanup = new(TimeSpan.FromSeconds(30));
            try
            {
                await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cleanup.Token);
            }
            catch (ClientResultException error) when (error.Status == 404)
            {
                Console.WriteLine($"Temporary agent {agentName} is already absent.");
            }
            try
            {
                await project.AgentAdministrationClient.GetAgentAsync(agentName, cleanup.Token);
                throw new InvalidOperationException($"Temporary agent {agentName} still exists after cleanup.");
            }
            catch (ClientResultException error) when (error.Status == 404)
            {
                Console.WriteLine($"Verified temporary agent {agentName} is absent: HTTP 404.");
            }
        }
    }
    #endregion

    private static async Task ReceiveResultAsync(
        ProjectsLiveSessionClient session, string expectedCommentary, CancellationToken cancellationToken)
    {
        bool delegated = false;
        long audioBytes = 0;
        StringBuilder transcript = new();
        await foreach (LiveServerEvent update in session.ReceiveEventsAsync(cancellationToken))
        {
            if (update is LiveServerEventLiveErrorEvent error)
            {
                throw new InvalidOperationException($"Live service error ({error.Error.Code}): {error.Error.Message}");
            }
            if (update is LiveServerEventLiveDelegationCreated created)
            {
                if (created.Delegation.Target != VoiceAgentLiveDelegationTarget.FoundryManagedAgent)
                {
                    throw new InvalidOperationException("The service delegated to an unexpected target.");
                }
                delegated = true;
            }
            else if (update is LiveServerEventLiveOutputTranscriptDelta text)
            {
                transcript.Append(text.Delta);
            }
            else if (update is LiveOutputAudioDelta audio)
            {
                audioBytes += Convert.FromBase64String(audio.Delta).LongLength;
            }
            if (delegated && audioBytes > 0 &&
                transcript.ToString().IndexOf(expectedCommentary, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine($"Managed result: {transcript}; received {audioBytes} audio bytes.");
                return;
            }
        }
        throw new InvalidDataException("The session ended before speaking the managed agent's result.");
    }

    private static async Task SendSpeechAsync(
        ProjectsLiveSessionClient session, string path, Task receive, CancellationToken cancellationToken)
    {
        byte[] speech = File.ReadAllBytes(path);
        if (speech.Length == 0 || speech.Length > 60 * 48000 || speech.Length % 2 != 0 ||
            (speech.Length >= 4 && Encoding.ASCII.GetString(speech, 0, 4) == "RIFF"))
        {
            throw new InvalidDataException("Use nonempty raw mono PCM16LE/24 kHz speech, without a WAV header.");
        }
        const int chunkBytes = 960;
        byte[] silence = new byte[chunkBytes];
        long sentBytes = 0;
        for (int offset = 0, trailing = 0; offset < speech.Length || trailing < 400 ||
            (!receive.IsCompleted && trailing < 1900);)
        {
            if (receive.IsFaulted)
            {
                await receive;
            }
            int count = Math.Min(chunkBytes, speech.Length - offset);
            BinaryData audio = count > 0
                ? BinaryData.FromBytes(speech.AsMemory(offset, count))
                : BinaryData.FromBytes(silence);
            await session.SendInputAudioAsync(audio, cancellationToken);
            sentBytes += audio.ToMemory().Length;
            offset += count;
            if (count == 0)
            {
                trailing++;
            }
            await Task.Delay(TimeSpan.FromMilliseconds(20), cancellationToken);
        }
        Console.WriteLine($"Sent {sentBytes} raw input-audio bytes.");
    }

    internal static string ReadManagedCommentary(string responseText, string expectedCommentary)
    {
        if (string.IsNullOrWhiteSpace(responseText) || string.IsNullOrWhiteSpace(expectedCommentary))
        {
            throw new ArgumentException("A managed response and expected marker are required.");
        }
        const string thinkingTag = "[thinking]";
        const string commentaryTag = "\n[commentary]";
        string text = responseText.Replace("\r\n", "\n").Replace('\r', '\n');
        int start = text.IndexOf(commentaryTag, StringComparison.Ordinal);
        if (!text.StartsWith(thinkingTag, StringComparison.Ordinal) || start <= thinkingTag.Length ||
            text.IndexOf("\n[thinking]", StringComparison.Ordinal) >= 0 ||
            text.IndexOf(commentaryTag, start + 1, StringComparison.Ordinal) >= 0)
        {
            throw new InvalidOperationException("Put [thinking] and [commentary] headers on separate lines, in that order.");
        }
        string commentary = text.Substring(start + commentaryTag.Length).Trim();
        if (text.Substring(thinkingTag.Length, start - thinkingTag.Length).Trim().Length == 0 ||
            commentary.Length == 0 || commentary.IndexOf(expectedCommentary, StringComparison.OrdinalIgnoreCase) < 0)
        {
            throw new InvalidOperationException("Return nonempty sections with the expected marker in commentary.");
        }
        return commentary;
    }
}
