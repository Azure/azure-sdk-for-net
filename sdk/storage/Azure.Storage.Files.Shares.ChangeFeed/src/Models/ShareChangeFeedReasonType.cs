// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Identifies the type of operation that triggered an Azure Files Change Feed event.
    /// This is an extensible enum that supports both well-known values (e.g., <see cref="SmbCreate"/>,
    /// <see cref="RestDelete"/>) and custom string values for forward compatibility.
    /// </summary>
    public readonly struct ShareChangeFeedReasonType : IEquatable<ShareChangeFeedReasonType>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedReasonType"/> with a custom string value.
        /// </summary>
        /// <param name="value">The reason type string.</param>
        public ShareChangeFeedReasonType(string value) { _value = value ?? throw new ArgumentNullException(nameof(value)); }

        /// <summary> A file or directory was created via SMB. </summary>
        public static ShareChangeFeedReasonType SmbCreate { get; } = new ShareChangeFeedReasonType("SmbCreate");
        /// <summary> A file or directory was renamed via SMB. </summary>
        public static ShareChangeFeedReasonType SmbRename { get; } = new ShareChangeFeedReasonType("SmbRename");
        /// <summary> A file or directory was deleted via SMB. </summary>
        public static ShareChangeFeedReasonType SmbDelete { get; } = new ShareChangeFeedReasonType("SmbDelete");
        /// <summary> A file was written to via SMB. </summary>
        public static ShareChangeFeedReasonType SmbWrite { get; } = new ShareChangeFeedReasonType("SmbWrite");
        /// <summary> File or directory metadata/attributes were set. </summary>
        public static ShareChangeFeedReasonType SetInfo { get; } = new ShareChangeFeedReasonType("SetInfo");
        /// <summary> Security information (ACLs) was set on a file or directory. </summary>
        public static ShareChangeFeedReasonType SetSecurityInfo { get; } = new ShareChangeFeedReasonType("SetSecurityInfo");
        /// <summary> A file was extended (size increased) via SMB. </summary>
        public static ShareChangeFeedReasonType SmbExtend { get; } = new ShareChangeFeedReasonType("SmbExtend");
        /// <summary> A file was created with truncation via SMB. </summary>
        public static ShareChangeFeedReasonType SmbCreateTruncate { get; } = new ShareChangeFeedReasonType("SmbCreateTruncate");
        /// <summary> A file or directory was created via REST API. </summary>
        public static ShareChangeFeedReasonType RestCreate { get; } = new ShareChangeFeedReasonType("RestCreate");
        /// <summary> A file or directory was renamed via REST API. </summary>
        public static ShareChangeFeedReasonType RestRename { get; } = new ShareChangeFeedReasonType("RestRename");
        /// <summary> A file or directory was deleted via REST API. </summary>
        public static ShareChangeFeedReasonType RestDelete { get; } = new ShareChangeFeedReasonType("RestDelete");
        /// <summary> A file was written to via REST API. </summary>
        public static ShareChangeFeedReasonType RestWrite { get; } = new ShareChangeFeedReasonType("RestWrite");
        /// <summary> File or directory metadata/attributes were set via REST API. </summary>
        public static ShareChangeFeedReasonType RestSetInfo { get; } = new ShareChangeFeedReasonType("RestSetInfo");
        /// <summary> Security information (ACLs) was set via REST API. </summary>
        public static ShareChangeFeedReasonType RestSetSecurityInfo { get; } = new ShareChangeFeedReasonType("RestSetSecurityInfo");
        /// <summary> A file was copied synchronously. </summary>
        public static ShareChangeFeedReasonType SyncCopyFile { get; } = new ShareChangeFeedReasonType("SyncCopyFile");
        /// <summary> A file was copied asynchronously. </summary>
        public static ShareChangeFeedReasonType AsyncCopyFile { get; } = new ShareChangeFeedReasonType("AsyncCopyFile");
        /// <summary> A control event emitted by the change feed system. </summary>
        public static ShareChangeFeedReasonType ControlEvent { get; } = new ShareChangeFeedReasonType("ControlEvent");
        /// <summary> A file was created with truncation via REST API. </summary>
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
