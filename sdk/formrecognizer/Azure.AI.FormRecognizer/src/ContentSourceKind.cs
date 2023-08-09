// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary> Training data source kind. </summary>
    public readonly partial struct ContentSourceKind : IEquatable<ContentSourceKind>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContentSourceKind"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ContentSourceKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AzureBlobValue = "azureBlob";
        private const string AzureBlobFileListValue = "azureBlobFileList";

        /// <summary> Data matrix code, as defined in ISO/IEC 16022:2006. </summary>
        public static ContentSourceKind Blob { get; } = new ContentSourceKind(AzureBlobValue);
        /// <summary> MaxiCode, as defined in ISO/IEC 16023:2000. </summary>
        public static ContentSourceKind BlobFileList { get; } = new ContentSourceKind(AzureBlobFileListValue);
        /// <summary> Determines if two <see cref="ContentSourceKind"/> values are the same. </summary>
        public static bool operator ==(ContentSourceKind left, ContentSourceKind right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ContentSourceKind"/> values are not the same. </summary>
        public static bool operator !=(ContentSourceKind left, ContentSourceKind right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ContentSourceKind"/>. </summary>
        public static implicit operator ContentSourceKind(string value) => new ContentSourceKind(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ContentSourceKind other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ContentSourceKind other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
