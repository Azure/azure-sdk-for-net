// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Search.Documents.Tests.Samples
{
    /// <summary>
    /// Defines how the indexer should process embedded images or image files.
    /// </summary>
    public readonly partial struct ImageAction : IEquatable<ImageAction>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="ImageAction"/> values are the same. </summary>
        public ImageAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NoneValue = "none";
        private const string GenerateNormalizedImagesValue = "generateNormalizedImages";
        private const string GenerateNormalizedImagePerPageValue = "generateNormalizedImagePerPage";

        /// <summary>
        /// Ignore embedded images or image files in the data set. This is the default.
        /// </summary>
        public static ImageAction None { get; } = new ImageAction(NoneValue);

        /// <summary>
        /// Extract text from images (for example, the word "stop" from a traffic Stop sign), and embed it as part of the content field.
        /// During image analysis, the indexer creates an array of normalized images as part of document cracking, and embeds the generated information into the content field.
        /// This action requires calling <see cref="IndexingParametersExtensions.SetBlobExtractionMode"/> with <see cref="BlobExtractionMode.ContentAndMetadata"/>.
        /// </summary>
        public static ImageAction GenerateNormalizedImages { get; } = new ImageAction(GenerateNormalizedImagesValue);

        /// <summary>
        /// PDF files will be treated differently in that instead of extracting embedded images, each page will be rendered as an image and normalized accordingly.
        /// Non-PDF file types will be treated the same as if <see cref="GenerateNormalizedImages"/> was set.
        /// </summary>
        public static ImageAction GenerateNormalizedImagePerPage { get; } = new ImageAction(GenerateNormalizedImagePerPageValue);

        /// <summary> Determines if two <see cref="ImageAction"/> values are the same. </summary>
        public static bool operator ==(ImageAction left, ImageAction right) => left.Equals(right);

        /// <summary> Determines if two <see cref="ImageAction"/> values are not the same. </summary>
        public static bool operator !=(ImageAction left, ImageAction right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="ImageAction"/>. </summary>
        public static implicit operator ImageAction(string value) => new ImageAction(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ImageAction other && Equals(other);

        /// <inheritdoc />
        public bool Equals(ImageAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
