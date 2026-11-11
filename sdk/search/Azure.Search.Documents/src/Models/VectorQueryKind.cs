// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Models
{
    /// <summary> The kind of vector query being performed. </summary>
    internal readonly partial struct VectorQueryKind
    {
        private const string ImageUrlValue = "imageUrl";
        private const string ImageBinaryValue = "imageBinary";

        /// <summary> Initializes a new instance of <see cref="VectorQueryKind"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public VectorQueryKind(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            _value = value;
        }

        /// <summary> Vector query where an url that represents an image value that needs to be vectorized is provided. </summary>
        public static VectorQueryKind ImageUrl { get; } = new VectorQueryKind(ImageUrlValue);

        /// <summary> Vector query where a base 64 encoded binary of an image that needs to be vectorized is provided. </summary>
        public static VectorQueryKind ImageBinary { get; } = new VectorQueryKind(ImageBinaryValue);
    }
}
