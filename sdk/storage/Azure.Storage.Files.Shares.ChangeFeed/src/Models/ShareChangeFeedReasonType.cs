// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    public readonly struct ShareChangeFeedReasonType : IEquatable<ShareChangeFeedReasonType>
    {
        private readonly string _value;

        public ShareChangeFeedReasonType(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        public static ShareChangeFeedReasonType SmbCreate { get; } = new ShareChangeFeedReasonType("SmbCreate");
        public static ShareChangeFeedReasonType SmbRename { get; } = new ShareChangeFeedReasonType("SmbRename");
        public static ShareChangeFeedReasonType SmbDelete { get; } = new ShareChangeFeedReasonType("SmbDelete");
        public static ShareChangeFeedReasonType SmbWrite { get; } = new ShareChangeFeedReasonType("SmbWrite");
        public static ShareChangeFeedReasonType SetInfo { get; } = new ShareChangeFeedReasonType("SetInfo");
        public static ShareChangeFeedReasonType SetSecurityInfo { get; } = new ShareChangeFeedReasonType("SetSecurityInfo");
        public static ShareChangeFeedReasonType SmbExtend { get; } = new ShareChangeFeedReasonType("SmbExtend");
        public static ShareChangeFeedReasonType SmbCreateTruncate { get; } = new ShareChangeFeedReasonType("SmbCreateTruncate");
        public static ShareChangeFeedReasonType RestCreate { get; } = new ShareChangeFeedReasonType("RestCreate");
        public static ShareChangeFeedReasonType RestRename { get; } = new ShareChangeFeedReasonType("RestRename");
        public static ShareChangeFeedReasonType RestDelete { get; } = new ShareChangeFeedReasonType("RestDelete");
        public static ShareChangeFeedReasonType RestWrite { get; } = new ShareChangeFeedReasonType("RestWrite");
        public static ShareChangeFeedReasonType RestSetInfo { get; } = new ShareChangeFeedReasonType("RestSetInfo");
        public static ShareChangeFeedReasonType RestSetSecurityInfo { get; } = new ShareChangeFeedReasonType("RestSetSecurityInfo");
        public static ShareChangeFeedReasonType SyncCopyFile { get; } = new ShareChangeFeedReasonType("SyncCopyFile");
        public static ShareChangeFeedReasonType AsyncCopyFile { get; } = new ShareChangeFeedReasonType("AsyncCopyFile");
        public static ShareChangeFeedReasonType ControlEvent { get; } = new ShareChangeFeedReasonType("ControlEvent");
        public static ShareChangeFeedReasonType RestCreateTruncate { get; } = new ShareChangeFeedReasonType("RestCreateTruncate");

        public static implicit operator ShareChangeFeedReasonType(string value) => new ShareChangeFeedReasonType(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ShareChangeFeedReasonType other && Equals(other);
        public bool Equals(ShareChangeFeedReasonType other) => string.Equals(_value, other._value, StringComparison.Ordinal);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
        public static bool operator ==(ShareChangeFeedReasonType left, ShareChangeFeedReasonType right) => left.Equals(right);
        public static bool operator !=(ShareChangeFeedReasonType left, ShareChangeFeedReasonType right) => !left.Equals(right);
    }
}
