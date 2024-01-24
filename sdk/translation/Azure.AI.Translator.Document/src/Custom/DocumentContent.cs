// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    /// <summary> Document Translate Request / Content. </summary>
    // [CodeGenModel("DocumentTranslateContent")]
    // [CodeGenSuppress("DocumentContent", typeof(BinaryData))]
    // [CodeGenSuppress("DocumentContent", typeof(BinaryData), typeof(IList<BinaryData>))]
    // [CodeGenSuppress("ToRequestContent")]
    public partial class DocumentContent
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DocumentContent"/>. </summary>
        /// <param name="document"> Document to be translated in the form. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="document"/> is null. </exception>
        public DocumentContent(MultipartFormFileData document)
        {
            Argument.AssertNotNull(document, nameof(document));

            Document = document;
            Glossary = new ChangeTrackingList<MultipartFormFileData>();
        }

        /// <summary> Initializes a new instance of <see cref="DocumentContent"/>. </summary>
        /// <param name="document"> Document to be translated in the form. </param>
        /// <param name="glossary"> Glossary / translation memory will be used during translation in the form. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DocumentContent(MultipartFormFileData document, IList<MultipartFormFileData> glossary, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Document = document;
            Glossary = glossary;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="DocumentContent"/> for deserialization. </summary>
        internal DocumentContent()
        {
        }

        /// <summary>
        /// Document to be translated in the form
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
        public MultipartFormFileData Document { get; }
        /// <summary>
        /// Glossary / translation memory will be used during translation in the form.
        /// <para>
        /// To assign a byte[] to the element of this property use <see cref="BinaryData.FromBytes(byte[])"/>.
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
        public IList<MultipartFormFileData> Glossary { get; }
    }
}
