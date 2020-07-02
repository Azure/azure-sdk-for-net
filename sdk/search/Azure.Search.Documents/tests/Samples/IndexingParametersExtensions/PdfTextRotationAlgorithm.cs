// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Search.Documents.Tests.Samples
{
    /// <summary>
    /// Defines how the indexer should rotate PDFs.
    /// </summary>
    public readonly partial struct PdfTextRotationAlgorithm : IEquatable<PdfTextRotationAlgorithm>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="PdfTextRotationAlgorithm"/> values are the same. </summary>
        public PdfTextRotationAlgorithm(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "none";
        private const string DetectAnglesValue = "detectAngles";

        /// <summary>
        /// Do not rotate PDFs. This is the default.
        /// </summary>
        public static PdfTextRotationAlgorithm None { get; } = new PdfTextRotationAlgorithm(NoneValue);

        /// <summary>
        /// May help produce better and more readable text extraction from PDF files that have rotated text within them.
        /// Note that there may be a small performance speed impact when this parameter is used.
        /// This parameter only applies to PDF files, and only to PDFs with embedded text.
        /// If the rotated text appears within an embedded image in the PDF, this parameter does not apply.
        /// </summary>
        public static PdfTextRotationAlgorithm DetectAngles { get; } = new PdfTextRotationAlgorithm(DetectAnglesValue);

        /// <summary> Determines if two <see cref="PdfTextRotationAlgorithm"/> values are the same. </summary>
        public static bool operator ==(PdfTextRotationAlgorithm left, PdfTextRotationAlgorithm right) => left.Equals(right);

        /// <summary> Determines if two <see cref="PdfTextRotationAlgorithm"/> values are not the same. </summary>
        public static bool operator !=(PdfTextRotationAlgorithm left, PdfTextRotationAlgorithm right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="PdfTextRotationAlgorithm"/>. </summary>
        public static implicit operator PdfTextRotationAlgorithm(string value) => new PdfTextRotationAlgorithm(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is PdfTextRotationAlgorithm other && Equals(other);

        /// <inheritdoc />
        public bool Equals(PdfTextRotationAlgorithm other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
