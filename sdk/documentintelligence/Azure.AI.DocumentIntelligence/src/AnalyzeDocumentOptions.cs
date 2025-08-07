// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.DocumentIntelligence
{
    public partial class AnalyzeDocumentOptions
    {
        // CUSTOM CODE NOTE: since either UriSource or BytesSource must be specified
        // when building this object, we're hiding its parameterless constructor, adding
        // custom constructors, and making both properties readonly.

        /// <summary>
        /// Initializes a new instance of <see cref="AnalyzeDocumentOptions"/>.
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="uriSource"> Document URL to analyze. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="uriSource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        public AnalyzeDocumentOptions(string modelId, Uri uriSource) : this(modelId)
        {
            Argument.AssertNotNull(uriSource, nameof(uriSource));

            UriSource = uriSource;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AnalyzeDocumentOptions"/>.
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="bytesSource">
        /// Bytes of the document to analyze.
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="bytesSource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        public AnalyzeDocumentOptions(string modelId, BinaryData bytesSource) : this(modelId)
        {
            Argument.AssertNotNull(bytesSource, nameof(bytesSource));

            BytesSource = bytesSource;
        }

        private AnalyzeDocumentOptions(string modelId) : this()
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            ModelId = modelId;
        }

        internal AnalyzeDocumentOptions()
        {
            Features = new ChangeTrackingList<DocumentAnalysisFeature>();
            QueryFields = new ChangeTrackingList<string>();
            Output = new ChangeTrackingList<AnalyzeOutputOption>();
        }

        /// <summary> Unique document model name. </summary>
        public string ModelId { get; }

        /// <summary> Document URL to analyze. </summary>
        public Uri UriSource { get; }

        /// <summary>
        /// Bytes of the document to analyze.
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData BytesSource { get; }

        /// <summary>
        /// 1-based page numbers to analyze.  Ex. "1-3,5,7-9".
        /// </summary>
        public string Pages { get; set; }

        /// <summary>
        /// Locale hint for text recognition and document analysis.  Value may contain only
        /// the language code (ex. "en", "fr") or BCP 47 language tag (ex. "en-US").
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// List of optional analysis features.
        /// </summary>
        public ICollection<DocumentAnalysisFeature> Features { get; }

        /// <summary>
        /// List of additional fields to extract.  Ex. "NumberOfGuests,StoreNumber".
        /// </summary>
        public ICollection<string> QueryFields { get; }

        /// <summary>
        /// Format of the analyze result top-level content.
        /// </summary>
        public DocumentContentFormat? OutputContentFormat { get; set; }

        /// <summary>
        /// Additional outputs to generate during analysis.
        /// </summary>
        public ICollection<AnalyzeOutputOption> Output { get; }
    }
}
