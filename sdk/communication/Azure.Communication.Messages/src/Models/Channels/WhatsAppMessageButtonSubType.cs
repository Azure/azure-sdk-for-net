// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Communication.Messages.Models.Channels
{
    /// <summary>
    /// The WhatsApp button sub type.
    /// This type is provided for backward compatibility; use <see cref="Azure.Communication.Messages.WhatsAppMessageButtonSubType"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use Azure.Communication.Messages.WhatsAppMessageButtonSubType instead.")]
    [SuppressMessage("Design", "CA1067:Override Object.Equals(object) when implementing IEquatable<T>", Justification = "Wrapper type delegates to inner struct")]
    public readonly struct WhatsAppMessageButtonSubType : IEquatable<WhatsAppMessageButtonSubType>
    {
        private readonly Azure.Communication.Messages.WhatsAppMessageButtonSubType _innerValue;

        /// <summary> Initializes a new instance of <see cref="WhatsAppMessageButtonSubType"/>. </summary>
        /// <param name="value"> The value. </param>
        public WhatsAppMessageButtonSubType(string value)
        {
            _innerValue = new Azure.Communication.Messages.WhatsAppMessageButtonSubType(value);
        }

        private WhatsAppMessageButtonSubType(Azure.Communication.Messages.WhatsAppMessageButtonSubType inner)
        {
            _innerValue = inner;
        }

        /// <summary> The WhatsApp button sub type is quick reply. </summary>
        public static WhatsAppMessageButtonSubType QuickReply { get; } = new WhatsAppMessageButtonSubType(Azure.Communication.Messages.WhatsAppMessageButtonSubType.QuickReply);

        /// <summary> The WhatsApp button sub type is url. </summary>
        public static WhatsAppMessageButtonSubType Url { get; } = new WhatsAppMessageButtonSubType(Azure.Communication.Messages.WhatsAppMessageButtonSubType.Url);

        /// <summary> Determines if two <see cref="WhatsAppMessageButtonSubType"/> values are the same. </summary>
        public static bool operator ==(WhatsAppMessageButtonSubType left, WhatsAppMessageButtonSubType right) => left.Equals(right);

        /// <summary> Determines if two <see cref="WhatsAppMessageButtonSubType"/> values are not the same. </summary>
        public static bool operator !=(WhatsAppMessageButtonSubType left, WhatsAppMessageButtonSubType right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="WhatsAppMessageButtonSubType"/>. </summary>
        public static implicit operator WhatsAppMessageButtonSubType(string value) => new WhatsAppMessageButtonSubType(value);

        /// <summary> Converts to the underlying struct. </summary>
        public static implicit operator Azure.Communication.Messages.WhatsAppMessageButtonSubType(WhatsAppMessageButtonSubType value) => value._innerValue;

        /// <summary> Converts from the underlying struct. </summary>
        public static implicit operator WhatsAppMessageButtonSubType(Azure.Communication.Messages.WhatsAppMessageButtonSubType value) => new WhatsAppMessageButtonSubType(value);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is WhatsAppMessageButtonSubType other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(WhatsAppMessageButtonSubType other) => _innerValue.Equals(other._innerValue);

        /// <inheritdoc/>
        public override int GetHashCode() => _innerValue.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => _innerValue.ToString();
    }
}
