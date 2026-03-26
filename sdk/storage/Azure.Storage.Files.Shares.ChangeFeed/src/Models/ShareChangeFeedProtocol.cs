// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    public readonly struct ShareChangeFeedProtocol : IEquatable<ShareChangeFeedProtocol>
    {
        private readonly string _value;

        public ShareChangeFeedProtocol(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        public static ShareChangeFeedProtocol Smb { get; } = new ShareChangeFeedProtocol("SMB");
        public static ShareChangeFeedProtocol Rest { get; } = new ShareChangeFeedProtocol("REST");

        public static implicit operator ShareChangeFeedProtocol(string value) => new ShareChangeFeedProtocol(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ShareChangeFeedProtocol other && Equals(other);
        public bool Equals(ShareChangeFeedProtocol other) => string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
        public static bool operator ==(ShareChangeFeedProtocol left, ShareChangeFeedProtocol right) => left.Equals(right);
        public static bool operator !=(ShareChangeFeedProtocol left, ShareChangeFeedProtocol right) => !left.Equals(right);
    }
}
