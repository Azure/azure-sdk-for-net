// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects;

/// <summary> The transport used for a voice-agent realtime connection. </summary>
[Experimental("AAIP002")]
public readonly partial struct ProjectsRealtimeTransport : IEquatable<ProjectsRealtimeTransport>
{
    private readonly string _value;
    private const string WebsocketValue = "websocket";
    private const string WebrtcValue = "webrtc";

    /// <summary> Initializes a new instance of <see cref="ProjectsRealtimeTransport"/>. </summary>
    /// <param name="value"> The value. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
    public ProjectsRealtimeTransport(string value)
    {
        Argument.AssertNotNull(value, nameof(value));
        _value = value;
    }

    /// <summary> Signaling and audio are exchanged as JSON events over the WebSocket. This is the default. </summary>
    public static ProjectsRealtimeTransport Websocket { get; } = new ProjectsRealtimeTransport(WebsocketValue);

    /// <summary> WebRTC: the WebSocket carries only SDP signaling; media and the data channel are peer-to-peer. </summary>
    public static ProjectsRealtimeTransport Webrtc { get; } = new ProjectsRealtimeTransport(WebrtcValue);

    /// <summary> Determines if two <see cref="ProjectsRealtimeTransport"/> values are the same. </summary>
    /// <param name="left"> The left value to compare. </param>
    /// <param name="right"> The right value to compare. </param>
    public static bool operator ==(ProjectsRealtimeTransport left, ProjectsRealtimeTransport right) => left.Equals(right);

    /// <summary> Determines if two <see cref="ProjectsRealtimeTransport"/> values are not the same. </summary>
    /// <param name="left"> The left value to compare. </param>
    /// <param name="right"> The right value to compare. </param>
    public static bool operator !=(ProjectsRealtimeTransport left, ProjectsRealtimeTransport right) => !left.Equals(right);

    /// <summary> Converts a string to a <see cref="ProjectsRealtimeTransport"/>. </summary>
    /// <param name="value"> The value. </param>
    public static implicit operator ProjectsRealtimeTransport(string value) => new ProjectsRealtimeTransport(value);

    /// <summary> Converts a string to a <see cref="ProjectsRealtimeTransport"/>. </summary>
    /// <param name="value"> The value. </param>
    public static implicit operator ProjectsRealtimeTransport?(string value) => value == null ? null : new ProjectsRealtimeTransport(value);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => obj is ProjectsRealtimeTransport other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ProjectsRealtimeTransport other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}
