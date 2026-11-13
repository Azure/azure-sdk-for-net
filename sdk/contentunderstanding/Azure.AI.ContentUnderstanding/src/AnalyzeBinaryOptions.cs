// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Options for binary analysis operations, including the analyzer and binary input.
    /// </summary>
    public class AnalyzeBinaryOptions
    {
        /// <summary> Initializes a new instance of <see cref="AnalyzeBinaryOptions"/>. </summary>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="binaryInput"> The binary content to analyze. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="binaryInput"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string. </exception>
        public AnalyzeBinaryOptions(string analyzerId, BinaryData binaryInput)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(binaryInput, nameof(binaryInput));

            AnalyzerId = analyzerId;
            BinaryInput = binaryInput;
        }

        /// <summary> Gets the unique identifier of the analyzer. </summary>
        public string AnalyzerId { get; }

        /// <summary> Gets the binary content to analyze. </summary>
        public BinaryData BinaryInput { get; }

        /// <summary>
        /// Gets or sets the range of the input to analyze.
        /// </summary>
        public ContentRange? ContentRange { get; set; }

        /// <summary>
        /// Gets or sets whether input exceeding the service's processable-unit limit should be
        /// truncated and returned as a partial result with a warning instead of failing.
        /// When omitted, the analyzer's configured value applies.
        /// </summary>
        public bool? AllowInputTruncation { get; set; }

        /// <summary>
        /// Gets or sets the request content type. When not set, BinaryData.MediaType
        /// is used if available; otherwise <c>application/octet-stream</c> is used.
        /// </summary>
        public string? ContentType { get; set; }

        /// <summary>
        /// Gets or sets the location where the data may be processed.
        /// </summary>
        public ProcessingLocation? ProcessingLocation { get; set; }
    }
}
