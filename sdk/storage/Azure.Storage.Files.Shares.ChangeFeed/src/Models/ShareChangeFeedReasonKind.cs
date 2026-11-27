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
    public readonly struct ShareChangeFeedReasonKind : IEquatable<ShareChangeFeedReasonKind>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new <see cref="ShareChangeFeedReasonKind"/> with a custom string value.
        /// </summary>
        /// <param name="value">The reason type string.</param>
        public ShareChangeFeedReasonKind(string value) { _value = value ?? throw ShareChangeFeedErrors.ArgumentNull(nameof(value)); }

        /// <summary> A file or directory was created via SMB. </summary>
        public static ShareChangeFeedReasonKind SmbCreate { get; } = new ShareChangeFeedReasonKind("SmbCreate");
        /// <summary> A file or directory was renamed via SMB. </summary>
        public static ShareChangeFeedReasonKind SmbRename { get; } = new ShareChangeFeedReasonKind("SmbRename");
        /// <summary> A file or directory was deleted via SMB. </summary>
        public static ShareChangeFeedReasonKind SmbDelete { get; } = new ShareChangeFeedReasonKind("SmbDelete");
        /// <summary> A file was written to via SMB. </summary>
        public static ShareChangeFeedReasonKind SmbWrite { get; } = new ShareChangeFeedReasonKind("SmbWrite");
        /// <summary> File or directory metadata/attributes were set. </summary>
        public static ShareChangeFeedReasonKind SetInfo { get; } = new ShareChangeFeedReasonKind("SetInfo");
        /// <summary> Security information (ACLs) was set on a file or directory. </summary>
        public static ShareChangeFeedReasonKind SetSecurityInfo { get; } = new ShareChangeFeedReasonKind("SetSecurityInfo");
        /// <summary> A file was extended (size increased) via SMB. </summary>
        public static ShareChangeFeedReasonKind SmbExtend { get; } = new ShareChangeFeedReasonKind("SmbExtend");
        /// <summary> A file was created with truncation via SMB. </summary>
        public static ShareChangeFeedReasonKind SmbCreateTruncate { get; } = new ShareChangeFeedReasonKind("SmbCreateTruncate");
        /// <summary> A file or directory was created via REST API. </summary>
        public static ShareChangeFeedReasonKind RestCreate { get; } = new ShareChangeFeedReasonKind("RestCreate");
        /// <summary> A file or directory was renamed via REST API. </summary>
        public static ShareChangeFeedReasonKind RestRename { get; } = new ShareChangeFeedReasonKind("RestRename");
        /// <summary> A file or directory was deleted via REST API. </summary>
        public static ShareChangeFeedReasonKind RestDelete { get; } = new ShareChangeFeedReasonKind("RestDelete");
        /// <summary> A file was written to via REST API. </summary>
        public static ShareChangeFeedReasonKind RestWrite { get; } = new ShareChangeFeedReasonKind("RestWrite");
        /// <summary> File or directory metadata/attributes were set via REST API. </summary>
        public static ShareChangeFeedReasonKind RestSetInfo { get; } = new ShareChangeFeedReasonKind("RestSetInfo");
        /// <summary> Security information (ACLs) was set via REST API. </summary>
        public static ShareChangeFeedReasonKind RestSetSecurityInfo { get; } = new ShareChangeFeedReasonKind("RestSetSecurityInfo");
        /// <summary> A file was copied synchronously. </summary>
        public static ShareChangeFeedReasonKind SyncCopyFile { get; } = new ShareChangeFeedReasonKind("SyncCopyFile");
        /// <summary> A file was copied asynchronously. </summary>
        public static ShareChangeFeedReasonKind AsyncCopyFile { get; } = new ShareChangeFeedReasonKind("AsyncCopyFile");
        /// <summary> A control event emitted by the change feed system. </summary>
        public static ShareChangeFeedReasonKind ControlEvent { get; } = new ShareChangeFeedReasonKind("ControlEvent");
        /// <summary> A file was created with truncation via REST API. </summary>
        public static ShareChangeFeedReasonKind RestCreateTruncate { get; } = new ShareChangeFeedReasonKind("RestCreateTruncate");
        /// <summary>
        /// A change feed reset marker. Emitted synthetically by the SDK when the service records
        /// a reset event (for example, HardFailover or classic account migration) in
        /// <c>meta/reset-latest.json</c>. Log-sequence continuity is broken at this point and the
        /// consumer must decide whether to re-baseline or continue reading past the marker.
        /// See <see cref="ShareChangeFeedResetEvent"/>.
        /// </summary>
        public static ShareChangeFeedReasonKind Reset { get; } = new ShareChangeFeedReasonKind("Reset");

        public static implicit operator ShareChangeFeedReasonKind(string value) => new ShareChangeFeedReasonKind(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ShareChangeFeedReasonKind other && Equals(other);
        public bool Equals(ShareChangeFeedReasonKind other) => string.Equals(_value, other._value, StringComparison.Ordinal);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        public override string ToString() => _value;
        public static bool operator ==(ShareChangeFeedReasonKind left, ShareChangeFeedReasonKind right) => left.Equals(right);
        public static bool operator !=(ShareChangeFeedReasonKind left, ShareChangeFeedReasonKind right) => !left.Equals(right);
    }
}
