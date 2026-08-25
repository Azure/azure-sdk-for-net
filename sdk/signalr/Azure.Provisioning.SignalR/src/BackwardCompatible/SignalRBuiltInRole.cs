// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.SignalR;

/// <summary> Built-in SignalR roles. </summary>
public readonly struct SignalRBuiltInRole(string value) : IEquatable<SignalRBuiltInRole>
{
    private readonly string _value = value ?? throw new ArgumentNullException(nameof(value));

    /// <summary> Read SignalR Service access keys. </summary>
    public static SignalRBuiltInRole SignalRAccessKeyReader { get; } = new(SignalRAccessKeyReaderValue);
    internal const string SignalRAccessKeyReaderValue = "04165923-9d83-45d5-8227-78b77b0a687e";

    /// <summary> Access SignalR Service with Microsoft Entra authentication. </summary>
    public static SignalRBuiltInRole SignalRAppServer { get; } = new(SignalRAppServerValue);
    internal const string SignalRAppServerValue = "420fcaa2-552c-430f-98ca-3264be4806c7";

    /// <summary> Full access to Azure SignalR Service REST APIs. </summary>
    public static SignalRBuiltInRole SignalRRestApiOwner { get; } = new(SignalRRestApiOwnerValue);
    internal const string SignalRRestApiOwnerValue = "fd53cd77-2268-407a-8f46-7e7863d0f521";

    /// <summary> Read-only access to Azure SignalR Service REST APIs. </summary>
    public static SignalRBuiltInRole SignalRRestApiReader { get; } = new(SignalRRestApiReaderValue);
    internal const string SignalRRestApiReaderValue = "ddde6b66-c0df-4114-a159-3618637b3035";

    /// <summary> Full access to Azure SignalR Service REST APIs. </summary>
    public static SignalRBuiltInRole SignalRServiceOwner { get; } = new(SignalRServiceOwnerValue);
    internal const string SignalRServiceOwnerValue = "7e4f1700-ea5a-4f59-8f37-079cfe29dce3";

    /// <summary> Create, read, update, and delete SignalR service resources. </summary>
    public static SignalRBuiltInRole SignalRContributor { get; } = new(SignalRContributorValue);
    internal const string SignalRContributorValue = "8cf5e20a-e4b2-4e9d-b3a1-5ceb692c2761";

    /// <summary> Gets the built-in role name for a role value. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static string GetBuiltInRoleName(SignalRBuiltInRole value) =>
        value._value switch
        {
            SignalRAccessKeyReaderValue => nameof(SignalRAccessKeyReader),
            SignalRAppServerValue => nameof(SignalRAppServer),
            SignalRRestApiOwnerValue => nameof(SignalRRestApiOwner),
            SignalRRestApiReaderValue => nameof(SignalRRestApiReader),
            SignalRServiceOwnerValue => nameof(SignalRServiceOwner),
            SignalRContributorValue => nameof(SignalRContributor),
            _ => value._value
        };

    /// <summary> Determines whether two role values are equal. </summary>
    public static bool operator ==(SignalRBuiltInRole left, SignalRBuiltInRole right) => left.Equals(right);

    /// <summary> Determines whether two role values are different. </summary>
    public static bool operator !=(SignalRBuiltInRole left, SignalRBuiltInRole right) => !left.Equals(right);

    /// <summary> Converts a string to a SignalR built-in role. </summary>
    public static implicit operator SignalRBuiltInRole(string value) => new(value);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => obj is SignalRBuiltInRole other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SignalRBuiltInRole other) => string.Equals(_value, other._value, StringComparison.Ordinal);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value?.GetHashCode() ?? 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}
