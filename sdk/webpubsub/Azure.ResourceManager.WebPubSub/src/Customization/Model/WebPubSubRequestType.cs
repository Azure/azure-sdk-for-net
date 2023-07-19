// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

[assembly: CodeGenSuppressType("WebPubSubRequestType")]

namespace Azure.ResourceManager.WebPubSub.Models
{
    /// <summary> Allowed request types. The value can be one or more of: ClientConnection, ServerConnection, RESTAPI. </summary>
    public readonly partial struct WebPubSubRequestType : IEquatable<WebPubSubRequestType>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="WebPubSubRequestType"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public WebPubSubRequestType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ClientConnectionValue = "ClientConnection";
        private const string ServerConnectionValue = "ServerConnection";
        private const string RestApiValue = "RESTAPI";
        private const string TraceValue = "Trace";

        /// <summary> ClientConnection. </summary>
        public static WebPubSubRequestType ClientConnection { get; } = new WebPubSubRequestType(ClientConnectionValue);
        /// <summary> ServerConnection. </summary>
        public static WebPubSubRequestType ServerConnection { get; } = new WebPubSubRequestType(ServerConnectionValue);
        /// <summary> RESTAPI. </summary>
        public static WebPubSubRequestType RestApi { get; } = new WebPubSubRequestType(RestApiValue);
        /// <summary> Trace. </summary>
        public static WebPubSubRequestType Trace { get; } = new WebPubSubRequestType(TraceValue);
        /// <summary> Determines if two <see cref="WebPubSubRequestType"/> values are the same. </summary>
        public static bool operator ==(WebPubSubRequestType left, WebPubSubRequestType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="WebPubSubRequestType"/> values are not the same. </summary>
        public static bool operator !=(WebPubSubRequestType left, WebPubSubRequestType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="WebPubSubRequestType"/>. </summary>
        public static implicit operator WebPubSubRequestType(string value) => new WebPubSubRequestType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is WebPubSubRequestType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(WebPubSubRequestType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
