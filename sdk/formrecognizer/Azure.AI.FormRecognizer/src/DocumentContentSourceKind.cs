// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary> Document content source kind. </summary>
    public readonly partial struct DocumentContentSourceKind : IEquatable<DocumentContentSourceKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="DocumentContentSourceKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public DocumentContentSourceKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AzureBlobValue = "azureBlob";
        private const string AzureBlobFileListValue = "azureBlobFileList";

        /// <summary> Data matrix code, as defined in ISO/IEC 16022:2006. </summary>
        public static DocumentContentSourceKind Blob { get; } = new DocumentContentSourceKind(AzureBlobValue);
        /// <summary> MaxiCode, as defined in ISO/IEC 16023:2000. </summary>
        public static DocumentContentSourceKind BlobFileList { get; } = new DocumentContentSourceKind(AzureBlobFileListValue);
        /// <summary> Determines if two <see cref="DocumentContentSourceKind"/> values are the same. </summary>
        public static bool operator ==(DocumentContentSourceKind left, DocumentContentSourceKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="DocumentContentSourceKind"/> values are not the same. </summary>
        public static bool operator !=(DocumentContentSourceKind left, DocumentContentSourceKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="DocumentContentSourceKind"/>. </summary>
        public static implicit operator DocumentContentSourceKind(string value) => new DocumentContentSourceKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is DocumentContentSourceKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(DocumentContentSourceKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
