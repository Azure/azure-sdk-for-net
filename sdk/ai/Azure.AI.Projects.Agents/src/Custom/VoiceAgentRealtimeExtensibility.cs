// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using OpenAI;
using OpenAI.Realtime;

// These types extend OpenAI's Realtime client-command/server-update hierarchies with strongly
// typed, Foundry-only realtime commands and updates (avatar/WebRTC signaling) that OpenAI's own
// package does not model. This relies on the extensibility added by
// https://github.com/openai/openai-dotnet/pull/1354.
#pragma warning disable OPENAI002
#pragma warning disable SCME0001 // JsonPatch is for evaluation purposes only.

namespace Azure.AI.Projects.Agents;

/// <summary> The <c>session.avatar.connect</c> realtime client command: begins avatar media (SDP) negotiation. </summary>
[Experimental("AAIP001")]
public class VoiceAgentClientCommandSessionAvatarConnect : RealtimeClientCommand
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentClientCommandSessionAvatarConnect"/>. </summary>
    /// <param name="clientSdp"> The client's SDP offer for avatar media negotiation. </param>
    public VoiceAgentClientCommandSessionAvatarConnect(string clientSdp)
        : base(new RealtimeClientCommandKind("session.avatar.connect"))
    {
        Argument.AssertNotNullOrEmpty(clientSdp, nameof(clientSdp));
        Patch.Set("$.client_sdp"u8, clientSdp);
    }

    /// <summary> Gets the client's SDP offer for avatar media negotiation. </summary>
    public string ClientSdp => Patch.GetString("$.client_sdp"u8);

    /// <summary> Writes this command's <c>type</c> discriminator and patched properties (including <see cref="ClientSdp"/>) as JSON. </summary>
    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        base.JsonModelWriteCore(writer, options);
        Patch.WriteTo(writer);
    }
}

/// <summary> The <c>rtc.call.sdp.create</c> realtime client command: begins WebRTC call signaling with an SDP offer. </summary>
[Experimental("AAIP001")]
public class VoiceAgentClientCommandRtcCallSdpCreate : RealtimeClientCommand
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentClientCommandRtcCallSdpCreate"/>. </summary>
    /// <param name="sdpOffer"> The client's SDP offer for the WebRTC connection. </param>
    /// <param name="session"> Optional raw session configuration; for an <c>/agents</c> endpoint the service rebuilds it authoritatively from the persisted agent definition. </param>
    public VoiceAgentClientCommandRtcCallSdpCreate(string sdpOffer, BinaryData session = null)
        : base(new RealtimeClientCommandKind("rtc.call.sdp.create"))
    {
        Argument.AssertNotNullOrEmpty(sdpOffer, nameof(sdpOffer));
        Patch.Set("$.sdp_offer"u8, sdpOffer);
        if (session is not null)
        {
            Patch.Set("$.session"u8, session);
        }
    }

    /// <summary> Gets the client's SDP offer for the WebRTC connection. </summary>
    public string SdpOffer => Patch.GetString("$.sdp_offer"u8);

    /// <summary> Writes this command's <c>type</c> discriminator and patched properties (including <see cref="SdpOffer"/>) as JSON. </summary>
    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        base.JsonModelWriteCore(writer, options);
        Patch.WriteTo(writer);
    }
}

/// <summary>
/// Base implementation shared by strongly-typed Voice Agents realtime server updates (for
/// example <see cref="VoiceAgentServerUpdateSessionAvatarConnecting"/>). This exists because
/// OpenAI's realtime client cannot yet automatically dispatch an unrecognized server event to a
/// caller's own subclass: without this, deserializing such an event always yields an opaque,
/// generic update instead. Callers can also derive their own subclasses of this type for events
/// not covered by the library, following the same pattern.
/// </summary>
/// <typeparam name="TSelf"> The concrete, most-derived subclass. </typeparam>
[Experimental("AAIP001")]
public abstract class VoiceAgentServerUpdateBase<TSelf> : RealtimeServerUpdate, IJsonModel<TSelf>, IPersistableModel<TSelf>
    where TSelf : VoiceAgentServerUpdateBase<TSelf>, new()
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateBase{TSelf}"/>. </summary>
    /// <param name="kind"> The event's <c>type</c> discriminator. </param>
    protected VoiceAgentServerUpdateBase(RealtimeServerUpdateKind kind) : base(kind)
    {
    }

    /// <summary> Writes this update's <c>type</c> discriminator and patched properties as JSON. </summary>
    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        base.JsonModelWriteCore(writer, options);
        Patch.WriteTo(writer);
    }

    void IJsonModel<TSelf>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    TSelf IJsonModel<TSelf>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return CreateFromElement(document.RootElement);
    }

    string IPersistableModel<TSelf>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    BinaryData IPersistableModel<TSelf>.Write(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write((TSelf)this, options, AzureAIProjectsAgentsContext.Default);

    TSelf IPersistableModel<TSelf>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data);
        return CreateFromElement(document.RootElement);
    }

    private static TSelf CreateFromElement(JsonElement element)
    {
        TSelf instance = new();
        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("type"u8))
            {
                continue; // Kind is already fixed by the parameterless constructor.
            }
            instance.Patch.Set(Encoding.UTF8.GetBytes("$." + property.Name), Encoding.UTF8.GetBytes(property.Value.GetRawText()));
        }
        return instance;
    }
}

/// <summary> The <c>session.avatar.connecting</c> realtime server update: the server's SDP answer for avatar media negotiation. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateSessionAvatarConnecting : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateSessionAvatarConnecting>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateSessionAvatarConnecting"/>. </summary>
    public VoiceAgentServerUpdateSessionAvatarConnecting() : base(new RealtimeServerUpdateKind("session.avatar.connecting"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);

    /// <summary> Gets the server's SDP answer for avatar media negotiation. </summary>
    public string ServerSdp => Patch.GetString("$.server_sdp"u8);
}

/// <summary> The <c>rtc.call.sdp.created</c> realtime server update: the SDP answer that completes WebRTC negotiation. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateRtcCallSdpCreated : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateRtcCallSdpCreated>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateRtcCallSdpCreated"/>. </summary>
    public VoiceAgentServerUpdateRtcCallSdpCreated() : base(new RealtimeServerUpdateKind("rtc.call.sdp.created"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);

    /// <summary> Gets the identifier of the established WebRTC call. </summary>
    public string RtcCallId => Patch.GetString("$.rtc_call_id"u8);

    /// <summary> Gets the server's SDP answer for the WebRTC connection. </summary>
    public string SdpAnswer => Patch.GetString("$.sdp_answer"u8);
}

// The remaining Foundry-only server events below only expose the universal event_id field.
// Their event-specific payload fields are not yet confirmed against the service contract; add
// typed properties via Patch.GetString("$.fieldName"u8) following the pattern above once known.

/// <summary> The <c>session.avatar.switch_to_speaking</c> realtime server update: the avatar transitioned to a speaking state. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateSessionAvatarSwitchToSpeaking : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateSessionAvatarSwitchToSpeaking>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateSessionAvatarSwitchToSpeaking"/>. </summary>
    public VoiceAgentServerUpdateSessionAvatarSwitchToSpeaking() : base(new RealtimeServerUpdateKind("session.avatar.switch_to_speaking"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>session.avatar.switch_to_idle</c> realtime server update: the avatar transitioned to an idle state. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateSessionAvatarSwitchToIdle : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateSessionAvatarSwitchToIdle>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateSessionAvatarSwitchToIdle"/>. </summary>
    public VoiceAgentServerUpdateSessionAvatarSwitchToIdle() : base(new RealtimeServerUpdateKind("session.avatar.switch_to_idle"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>rtc.call.error</c> realtime server update: an error occurred during WebRTC call signaling. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateRtcCallError : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateRtcCallError>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateRtcCallError"/>. </summary>
    public VoiceAgentServerUpdateRtcCallError() : base(new RealtimeServerUpdateKind("rtc.call.error"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>session.subagent.started</c> realtime server update: a subagent began handling the conversation. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateSessionSubagentStarted : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateSessionSubagentStarted>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateSessionSubagentStarted"/>. </summary>
    public VoiceAgentServerUpdateSessionSubagentStarted() : base(new RealtimeServerUpdateKind("session.subagent.started"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>session.subagent.completed</c> realtime server update: a subagent finished handling the conversation. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateSessionSubagentCompleted : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateSessionSubagentCompleted>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateSessionSubagentCompleted"/>. </summary>
    public VoiceAgentServerUpdateSessionSubagentCompleted() : base(new RealtimeServerUpdateKind("session.subagent.completed"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>session.subagent.aborted</c> realtime server update: a subagent handoff was aborted. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateSessionSubagentAborted : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateSessionSubagentAborted>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateSessionSubagentAborted"/>. </summary>
    public VoiceAgentServerUpdateSessionSubagentAborted() : base(new RealtimeServerUpdateKind("session.subagent.aborted"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>response.audio_timestamp.delta</c> realtime server update: an incremental audio timestamp alignment. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateResponseAudioTimestampDelta : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateResponseAudioTimestampDelta>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateResponseAudioTimestampDelta"/>. </summary>
    public VoiceAgentServerUpdateResponseAudioTimestampDelta() : base(new RealtimeServerUpdateKind("response.audio_timestamp.delta"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>response.audio_timestamp.done</c> realtime server update: audio timestamp alignment is complete. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateResponseAudioTimestampDone : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateResponseAudioTimestampDone>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateResponseAudioTimestampDone"/>. </summary>
    public VoiceAgentServerUpdateResponseAudioTimestampDone() : base(new RealtimeServerUpdateKind("response.audio_timestamp.done"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>response.animation_blendshapes.delta</c> realtime server update: an incremental avatar blendshape animation frame. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateResponseAnimationBlendshapesDelta : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateResponseAnimationBlendshapesDelta>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateResponseAnimationBlendshapesDelta"/>. </summary>
    public VoiceAgentServerUpdateResponseAnimationBlendshapesDelta() : base(new RealtimeServerUpdateKind("response.animation_blendshapes.delta"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>response.animation_blendshapes.done</c> realtime server update: avatar blendshape animation streaming is complete. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateResponseAnimationBlendshapesDone : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateResponseAnimationBlendshapesDone>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateResponseAnimationBlendshapesDone"/>. </summary>
    public VoiceAgentServerUpdateResponseAnimationBlendshapesDone() : base(new RealtimeServerUpdateKind("response.animation_blendshapes.done"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>response.animation_viseme.delta</c> realtime server update: an incremental avatar viseme (lip-sync) animation frame. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateResponseAnimationVisemeDelta : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateResponseAnimationVisemeDelta>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateResponseAnimationVisemeDelta"/>. </summary>
    public VoiceAgentServerUpdateResponseAnimationVisemeDelta() : base(new RealtimeServerUpdateKind("response.animation_viseme.delta"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>response.animation_viseme.done</c> realtime server update: avatar viseme (lip-sync) animation streaming is complete. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateResponseAnimationVisemeDone : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateResponseAnimationVisemeDone>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateResponseAnimationVisemeDone"/>. </summary>
    public VoiceAgentServerUpdateResponseAnimationVisemeDone() : base(new RealtimeServerUpdateKind("response.animation_viseme.done"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary> The <c>response.video.delta</c> realtime server update: an incremental avatar video frame. </summary>
[Experimental("AAIP001")]
public sealed class VoiceAgentServerUpdateResponseVideoDelta : VoiceAgentServerUpdateBase<VoiceAgentServerUpdateResponseVideoDelta>
{
    /// <summary> Initializes a new instance of <see cref="VoiceAgentServerUpdateResponseVideoDelta"/>. </summary>
    public VoiceAgentServerUpdateResponseVideoDelta() : base(new RealtimeServerUpdateKind("response.video.delta"))
    {
    }

    /// <summary> Gets the server-generated event identifier. </summary>
    public string EventId => Patch.GetString("$.event_id"u8);
}

/// <summary>
/// Extension methods bridging OpenAI's generic realtime server updates to Voice Agents' strongly-typed ones.
/// Use this when consuming updates through OpenAI's own <see cref="RealtimeSessionClient.ReceiveUpdatesAsync(System.Threading.CancellationToken)"/>
/// (or <see cref="RealtimeSessionClient.ReceiveUpdatesAsync(RequestOptions)"/>), which yields opaque
/// <see cref="RealtimeServerUpdate"/> instances for Foundry-specific events instead of the caller's own subclass.
/// </summary>
public static class RealtimeServerUpdateExtensions
{
    /// <summary>
    /// Re-interprets a generic <see cref="RealtimeServerUpdate"/> as a strongly-typed Voice Agents
    /// server update. Use this for Voice-Agents-specific events (for example
    /// <c>session.avatar.connecting</c>) that OpenAI's realtime client does not yet natively
    /// recognize: it currently returns an opaque, generic update for such events instead of the
    /// caller's own subclass, so callers must check <see cref="RealtimeServerUpdate.Kind"/> and
    /// then convert explicitly via this method.
    /// </summary>
    /// <typeparam name="T"> The target Voice Agents server update type, matching <paramref name="update"/>'s <see cref="RealtimeServerUpdate.Kind"/>. </typeparam>
    /// <param name="update"> The update to convert. </param>
    [Experimental("AAIP001")]
    public static T AsFoundryServerUpdate<T>(this RealtimeServerUpdate update)
        where T : RealtimeServerUpdate
    {
        Argument.AssertNotNull(update, nameof(update));
        BinaryData json = ModelReaderWriter.Write(update, ModelReaderWriterOptions.Json, OpenAIContext.Default);
        return ModelReaderWriter.Read<T>(json, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
    }
}

/// <summary>
/// Registers Voice Agents' realtime server-update extensibility types for AOT/trimming-compatible
/// reader/writer support. The corresponding client-command types
/// (<see cref="VoiceAgentClientCommandSessionAvatarConnect"/>, <see cref="VoiceAgentClientCommandRtcCallSdpCreate"/>)
/// are write-only (never deserialized) and intentionally omitted, since they have no parameterless
/// constructor for a generic builder to use.
/// </summary>
#pragma warning disable AAIP001 // The above types are experimental and may change in future versions.
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateSessionAvatarConnecting))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateRtcCallSdpCreated))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateSessionAvatarSwitchToSpeaking))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateSessionAvatarSwitchToIdle))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateRtcCallError))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateSessionSubagentStarted))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateSessionSubagentCompleted))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateSessionSubagentAborted))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateResponseAudioTimestampDelta))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateResponseAudioTimestampDone))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateResponseAnimationBlendshapesDelta))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateResponseAnimationBlendshapesDone))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateResponseAnimationVisemeDelta))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateResponseAnimationVisemeDone))]
[ModelReaderWriterBuildable(typeof(VoiceAgentServerUpdateResponseVideoDelta))]
#pragma warning restore AAIP001
public partial class AzureAIProjectsAgentsContext
{
}
