// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Tests.Samples;

public static class Sample_VoiceAgent_Live_Conversations
{
    #region Snippet:Sample_VoiceAgent_Live_Conversations_ReadAsync
    public static async Task ReadAsync(
        BetaVoiceAgentsLiveConversations client, string agentName, string conversationId, string outputDirectory,
        bool deleteConversation = false, CancellationToken cancellationToken = default)
    {
        ValidateArguments(client, agentName, conversationId, outputDirectory, cancellationToken);
        await foreach (VoiceAgentLiveConversation listed in client.GetLiveAgentConversationsAsync(
            agentName, limit: 2, order: AgentListOrder.Ascending, cancellationToken: cancellationToken))
        {
            ReportConversation(listed);
        }

        ClientResult<VoiceAgentLiveConversation> conversation = await client.GetLiveAgentConversationAsync(
            agentName, conversationId, cancellationToken);
        ReportStatus("GET conversation", conversation);
        ValidateConversation(conversation.Value, conversationId);

        VoiceAgentLiveConversationItem speechItem = null;
        await foreach (VoiceAgentLiveConversationItem item in client.GetLiveAgentConversationItemsAsync(
            agentName, conversationId, limit: 2, order: AgentListOrder.Ascending, cancellationToken: cancellationToken))
        {
            ReportItem(item);
            if (speechItem == null && IsSpeechItem(item))
            {
                speechItem = item;
            }
        }
        string itemId = RequireSpeechItem(speechItem);

        ClientResult<VoiceAgentLiveConversationItem> retrievedItem = await client.GetLiveAgentConversationItemAsync(
            agentName, conversationId, itemId, cancellationToken);
        ReportStatus("GET item", retrievedItem);
        ValidateRetrievedItem(retrievedItem.Value, itemId);

        ClientResult<VoiceAudioItem> segment = await client.GetLiveAgentConversationAudioItemAsync(
            agentName, conversationId, itemId, cancellationToken);
        ReportStatus("GET item audio metadata", segment);
        ValidateSegment(segment.Value, conversationId, itemId);

        ClientResult<BinaryData> segmentContent = await client.GetLiveAgentConversationAudioItemContentAsync(
            agentName, conversationId, itemId, cancellationToken);
        ReportStatus("GET item audio content", segmentContent);
        await SaveAudioAsync(outputDirectory, "segment.wav", segmentContent.Value, cancellationToken);

        ClientResult<VoiceRecording> recording = await client.GetLiveAgentConversationAudioAsync(
            agentName, conversationId, cancellationToken);
        ReportStatus("GET recording metadata", recording);
        ValidateRecording(recording.Value, conversationId);

        ClientResult<BinaryData> recordingContent = await client.GetLiveAgentConversationAudioContentAsync(
            agentName, conversationId, cancellationToken);
        ReportStatus("GET recording content", recordingContent);
        await SaveAudioAsync(outputDirectory, "conversation.wav", recordingContent.Value, cancellationToken);

        if (deleteConversation)
        {
            ClientResult deleted = await client.DeleteLiveAgentConversationAsync(agentName, conversationId, cancellationToken);
            ReportStatus("DELETE conversation", deleted);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_Conversations_Read
    public static void Read(
        BetaVoiceAgentsLiveConversations client, string agentName, string conversationId, string outputDirectory,
        bool deleteConversation = false, CancellationToken cancellationToken = default)
    {
        ValidateArguments(client, agentName, conversationId, outputDirectory, cancellationToken);
        foreach (VoiceAgentLiveConversation listed in client.GetLiveAgentConversations(
            agentName, limit: 2, order: AgentListOrder.Ascending, cancellationToken: cancellationToken))
        {
            ReportConversation(listed);
        }

        ClientResult<VoiceAgentLiveConversation> conversation = client.GetLiveAgentConversation(
            agentName, conversationId, cancellationToken);
        ReportStatus("GET conversation", conversation);
        ValidateConversation(conversation.Value, conversationId);

        VoiceAgentLiveConversationItem speechItem = null;
        foreach (VoiceAgentLiveConversationItem item in client.GetLiveAgentConversationItems(
            agentName, conversationId, limit: 2, order: AgentListOrder.Ascending, cancellationToken: cancellationToken))
        {
            ReportItem(item);
            if (speechItem == null && IsSpeechItem(item))
            {
                speechItem = item;
            }
        }
        string itemId = RequireSpeechItem(speechItem);

        ClientResult<VoiceAgentLiveConversationItem> retrievedItem = client.GetLiveAgentConversationItem(
            agentName, conversationId, itemId, cancellationToken);
        ReportStatus("GET item", retrievedItem);
        ValidateRetrievedItem(retrievedItem.Value, itemId);

        ClientResult<VoiceAudioItem> segment = client.GetLiveAgentConversationAudioItem(
            agentName, conversationId, itemId, cancellationToken);
        ReportStatus("GET item audio metadata", segment);
        ValidateSegment(segment.Value, conversationId, itemId);

        ClientResult<BinaryData> segmentContent = client.GetLiveAgentConversationAudioItemContent(
            agentName, conversationId, itemId, cancellationToken);
        ReportStatus("GET item audio content", segmentContent);
        SaveAudio(outputDirectory, "segment.wav", segmentContent.Value, cancellationToken);

        ClientResult<VoiceRecording> recording = client.GetLiveAgentConversationAudio(
            agentName, conversationId, cancellationToken);
        ReportStatus("GET recording metadata", recording);
        ValidateRecording(recording.Value, conversationId);

        ClientResult<BinaryData> recordingContent = client.GetLiveAgentConversationAudioContent(
            agentName, conversationId, cancellationToken);
        ReportStatus("GET recording content", recordingContent);
        SaveAudio(outputDirectory, "conversation.wav", recordingContent.Value, cancellationToken);

        if (deleteConversation)
        {
            ClientResult deleted = client.DeleteLiveAgentConversation(agentName, conversationId, cancellationToken);
            ReportStatus("DELETE conversation", deleted);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_Conversations_ReadProtocolAsync
    public static async Task ReadProtocolAsync(
        BetaVoiceAgentsLiveConversations client, string agentName, string conversationId, string outputDirectory,
        bool deleteConversation = false, CancellationToken cancellationToken = default)
    {
        ValidateArguments(client, agentName, conversationId, outputDirectory, cancellationToken);
        RequestOptions options = new() { CancellationToken = cancellationToken };
        await foreach (ClientResult page in client.GetLiveAgentConversationsAsync(
            agentName, 2, "asc", null, null, options).GetRawPagesAsync())
        {
            ReportStatus("GET conversations page", page);
            foreach (VoiceAgentLiveConversation listed in ReadPage<VoiceAgentLiveConversation>(page))
            {
                ReportConversation(listed);
            }
        }

        ClientResult conversation = await client.GetLiveAgentConversationAsync(agentName, conversationId, options);
        ReportStatus("GET conversation", conversation);
        ValidateConversation(ReadModel<VoiceAgentLiveConversation>(conversation), conversationId);

        VoiceAgentLiveConversationItem speechItem = null;
        await foreach (ClientResult page in client.GetLiveAgentConversationItemsAsync(
            agentName, conversationId, 2, "asc", null, null, options).GetRawPagesAsync())
        {
            ReportStatus("GET items page", page);
            foreach (VoiceAgentLiveConversationItem item in ReadPage<VoiceAgentLiveConversationItem>(page))
            {
                ReportItem(item);
                if (speechItem == null && IsSpeechItem(item))
                {
                    speechItem = item;
                }
            }
        }
        string itemId = RequireSpeechItem(speechItem);

        ClientResult retrievedItem = await client.GetLiveAgentConversationItemAsync(agentName, conversationId, itemId, options);
        ReportStatus("GET item", retrievedItem);
        ValidateRetrievedItem(ReadModel<VoiceAgentLiveConversationItem>(retrievedItem), itemId);

        ClientResult segment = await client.GetLiveAgentConversationAudioItemAsync(agentName, conversationId, itemId, options);
        ReportStatus("GET item audio metadata", segment);
        ValidateSegment(ReadModel<VoiceAudioItem>(segment), conversationId, itemId);

        ClientResult segmentContent = await client.GetLiveAgentConversationAudioItemContentAsync(agentName, conversationId, itemId, options);
        ReportStatus("GET item audio content", segmentContent);
        await SaveAudioAsync(outputDirectory, "segment.wav", segmentContent.GetRawResponse().Content, cancellationToken);

        ClientResult recording = await client.GetLiveAgentConversationAudioAsync(agentName, conversationId, options);
        ReportStatus("GET recording metadata", recording);
        ValidateRecording(ReadModel<VoiceRecording>(recording), conversationId);

        ClientResult recordingContent = await client.GetLiveAgentConversationAudioContentAsync(agentName, conversationId, options);
        ReportStatus("GET recording content", recordingContent);
        await SaveAudioAsync(outputDirectory, "conversation.wav", recordingContent.GetRawResponse().Content, cancellationToken);

        if (deleteConversation)
        {
            ClientResult deleted = await client.DeleteLiveAgentConversationAsync(agentName, conversationId, options);
            ReportStatus("DELETE conversation", deleted);
        }
    }
    #endregion

    #region Snippet:Sample_VoiceAgent_Live_Conversations_ReadProtocol
    public static void ReadProtocol(
        BetaVoiceAgentsLiveConversations client, string agentName, string conversationId, string outputDirectory,
        bool deleteConversation = false, CancellationToken cancellationToken = default)
    {
        ValidateArguments(client, agentName, conversationId, outputDirectory, cancellationToken);
        RequestOptions options = new() { CancellationToken = cancellationToken };
        foreach (ClientResult page in client.GetLiveAgentConversations(
            agentName, 2, "asc", null, null, options).GetRawPages())
        {
            ReportStatus("GET conversations page", page);
            foreach (VoiceAgentLiveConversation listed in ReadPage<VoiceAgentLiveConversation>(page))
            {
                ReportConversation(listed);
            }
        }

        ClientResult conversation = client.GetLiveAgentConversation(agentName, conversationId, options);
        ReportStatus("GET conversation", conversation);
        ValidateConversation(ReadModel<VoiceAgentLiveConversation>(conversation), conversationId);

        VoiceAgentLiveConversationItem speechItem = null;
        foreach (ClientResult page in client.GetLiveAgentConversationItems(
            agentName, conversationId, 2, "asc", null, null, options).GetRawPages())
        {
            ReportStatus("GET items page", page);
            foreach (VoiceAgentLiveConversationItem item in ReadPage<VoiceAgentLiveConversationItem>(page))
            {
                ReportItem(item);
                if (speechItem == null && IsSpeechItem(item))
                {
                    speechItem = item;
                }
            }
        }
        string itemId = RequireSpeechItem(speechItem);

        ClientResult retrievedItem = client.GetLiveAgentConversationItem(agentName, conversationId, itemId, options);
        ReportStatus("GET item", retrievedItem);
        ValidateRetrievedItem(ReadModel<VoiceAgentLiveConversationItem>(retrievedItem), itemId);

        ClientResult segment = client.GetLiveAgentConversationAudioItem(agentName, conversationId, itemId, options);
        ReportStatus("GET item audio metadata", segment);
        ValidateSegment(ReadModel<VoiceAudioItem>(segment), conversationId, itemId);

        ClientResult segmentContent = client.GetLiveAgentConversationAudioItemContent(agentName, conversationId, itemId, options);
        ReportStatus("GET item audio content", segmentContent);
        SaveAudio(outputDirectory, "segment.wav", segmentContent.GetRawResponse().Content, cancellationToken);

        ClientResult recording = client.GetLiveAgentConversationAudio(agentName, conversationId, options);
        ReportStatus("GET recording metadata", recording);
        ValidateRecording(ReadModel<VoiceRecording>(recording), conversationId);

        ClientResult recordingContent = client.GetLiveAgentConversationAudioContent(agentName, conversationId, options);
        ReportStatus("GET recording content", recordingContent);
        SaveAudio(outputDirectory, "conversation.wav", recordingContent.GetRawResponse().Content, cancellationToken);

        if (deleteConversation)
        {
            ClientResult deleted = client.DeleteLiveAgentConversation(agentName, conversationId, options);
            ReportStatus("DELETE conversation", deleted);
        }
    }
    #endregion

    private static void ValidateArguments(
        BetaVoiceAgentsLiveConversations client, string agentName, string conversationId, string outputDirectory,
        CancellationToken cancellationToken)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }
        if (string.IsNullOrWhiteSpace(agentName))
        {
            throw new ArgumentException("Use the name of the agent that stored the Live conversation.", nameof(agentName));
        }
        if (string.IsNullOrWhiteSpace(conversationId))
        {
            throw new ArgumentException("Use the conversation_id returned by the stored Live session.", nameof(conversationId));
        }
        if (string.IsNullOrWhiteSpace(outputDirectory))
        {
            throw new ArgumentException("Supply a local directory for the audio downloads.", nameof(outputDirectory));
        }
        cancellationToken.ThrowIfCancellationRequested();
    }

    private static void ReportStatus(string operation, ClientResult result)
        => Console.WriteLine($"{operation}: HTTP {result.GetRawResponse().Status}");

    private static void ReportConversation(VoiceAgentLiveConversation conversation)
    {
        if (conversation == null || string.IsNullOrWhiteSpace(conversation.Id))
        {
            throw new InvalidOperationException("The stored Live conversation response must include a nonempty id.");
        }
        Console.WriteLine($"Conversation {conversation.Id}: {conversation.Status}");
    }

    private static void ValidateConversation(VoiceAgentLiveConversation conversation, string conversationId)
    {
        ReportConversation(conversation);
        if (!string.Equals(conversation.Id, conversationId, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("The returned Live conversation id does not match the requested conversation.");
        }
        if (conversation.Status != VoiceConversationStatus.Completed)
        {
            throw new InvalidOperationException(
                $"Live conversation status is '{conversation.Status}'. This sample requires completed persistence finalization; " +
                "close the stored session and wait until it is completed before downloading audio. Failed persistence must be investigated.");
        }
    }

    private static bool IsSpeechItem(VoiceAgentLiveConversationItem item)
        => item is VoiceAgentLiveInputConversationItem || item is VoiceAgentLiveOutputConversationItem;

    private static void ReportItem(VoiceAgentLiveConversationItem item)
    {
        if (item == null || string.IsNullOrWhiteSpace(item.Id))
        {
            throw new InvalidOperationException("A stored Live item must include a nonempty id.");
        }
        Console.WriteLine($"Stored item {item.Id}: {(IsSpeechItem(item) ? "speech" : "non-speech")}");
    }

    private static string RequireSpeechItem(VoiceAgentLiveConversationItem item)
    {
        if (item == null)
        {
            throw new InvalidOperationException(
                "No stored input or output speech item was found. Use Store=true, send actual speech, close the Live session, " +
                "and wait for persistence finalization. Delegation and unknown items are not audio segments.");
        }
        return item.Id;
    }

    private static void ValidateRetrievedItem(VoiceAgentLiveConversationItem item, string itemId)
    {
        ReportItem(item);
        if (!IsSpeechItem(item) || !string.Equals(item.Id, itemId, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("The retrieved Live item must be the selected input or output speech item.");
        }
    }

    private static void ValidateSegment(VoiceAudioItem segment, string conversationId, string itemId)
    {
        if (segment == null || !string.Equals(segment.ConversationId, conversationId, StringComparison.Ordinal) ||
            !string.Equals(segment.ItemId, itemId, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Audio metadata must identify the requested Live conversation and speech item.");
        }
        RequireManagedStorage(segment.BlobUri);
        Console.WriteLine($"Segment: {segment.Format}, {segment.SampleRate} Hz, {segment.Channels} channel(s).");
    }

    private static void ValidateRecording(VoiceRecording recording, string conversationId)
    {
        if (recording == null || !string.Equals(recording.ConversationId, conversationId, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Recording metadata must identify the requested Live conversation.");
        }
        RequireManagedStorage(recording.BlobUri);
        Console.WriteLine($"Recording: {recording.Format}, {recording.SampleRate} Hz, {recording.Channels} channel(s).");
    }

    private static void RequireManagedStorage(Uri blobUri)
    {
        if (blobUri != null)
        {
            throw new NotSupportedException(
                "This sample downloads from Foundry-managed storage only. BYOS metadata contains BlobUri without a SAS token; " +
                "download from your own storage using your own credentials instead. The sample does not log or follow that URI.");
        }
    }

    private static T ReadModel<T>(ClientResult result)
        => ModelReaderWriter.Read<T>(result.GetRawResponse().Content, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);

    private static IEnumerable<T> ReadPage<T>(ClientResult result)
    {
        using JsonDocument document = JsonDocument.Parse(result.GetRawResponse().Content);
        if (!document.RootElement.TryGetProperty("data", out JsonElement data) || data.ValueKind != JsonValueKind.Array)
        {
            throw new JsonException("A Live history page must contain a data array.");
        }
        foreach (JsonElement element in data.EnumerateArray())
        {
            yield return ModelReaderWriter.Read<T>(BinaryData.FromString(element.GetRawText()),
                ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        }
    }

    private static byte[] RequireAudioBytes(BinaryData content)
    {
        byte[] bytes = content?.ToArray();
        if (bytes == null || bytes.Length == 0)
        {
            throw new InvalidOperationException("The Live audio content download was empty; no recording was saved.");
        }
        return bytes;
    }

    private static void SaveAudio(string outputDirectory, string fileName, BinaryData content, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        byte[] bytes = RequireAudioBytes(content);
        Directory.CreateDirectory(outputDirectory);
        File.WriteAllBytes(Path.Combine(outputDirectory, fileName), bytes);
        Console.WriteLine($"Saved {fileName}: {bytes.Length} bytes.");
    }

    private static async Task SaveAudioAsync(
        string outputDirectory, string fileName, BinaryData content, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        byte[] bytes = RequireAudioBytes(content);
        Directory.CreateDirectory(outputDirectory);
        using (FileStream file = new(Path.Combine(outputDirectory, fileName), FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
        {
            await file.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
        }
        Console.WriteLine($"Saved {fileName}: {bytes.Length} bytes.");
    }
}
