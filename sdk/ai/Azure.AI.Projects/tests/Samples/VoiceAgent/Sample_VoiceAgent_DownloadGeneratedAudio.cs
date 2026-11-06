// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests.Samples;

public static class Sample_VoiceAgent_DownloadGeneratedAudio
{
    #region Snippet:Sample_VoiceAgent_DownloadGeneratedAudio
    public static async Task DownloadAsync(
        BetaVoiceAgentsConversations conversations,
        string agentName, string conversationId, string itemId,
        string outputPath, CancellationToken cancellationToken)
    {
        // Use the persisted Foundry message ID, not a native Realtime event item ID.
        VoiceGeneratedAudioItem metadata = await conversations.GetAgentConversationGeneratedAudioItemAsync(
            agentName, conversationId, itemId, cancellationToken);
        if (metadata.ConversationId != conversationId || metadata.ItemId != itemId ||
            metadata.DurationMs is null || metadata.DurationMs <= TimeSpan.Zero)
        {
            throw new InvalidOperationException("No generated audio artifact was returned for this item.");
        }
        if (metadata.BlobUri != null)
        {
            throw new NotSupportedException("This item uses customer storage. Download it with your storage credentials.");
        }

        BinaryData audio = await conversations.GetAgentConversationGeneratedAudioItemContentAsync(
            agentName, conversationId, itemId, cancellationToken);
        byte[] bytes = audio.ToArray();
        using FileStream file = new(outputPath, FileMode.CreateNew, FileAccess.Write);
        await file.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
        Console.WriteLine($"Saved generated audio: {bytes.Length} WAV bytes; duration {metadata.DurationMs}.");
    }
    #endregion
}
