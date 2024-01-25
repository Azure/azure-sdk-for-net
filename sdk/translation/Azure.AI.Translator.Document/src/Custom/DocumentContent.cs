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
        /// <summary> Initializes a new instance of <see cref="DocumentContent"/>. </summary>
        /// <param name="document"> Document to be translated in the form. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="document"/> is null. </exception>
        public DocumentContent(MultipartFormFileData document)
        {
            Argument.AssertNotNull(document, nameof(document));

            Document = document;
            Glossary = new ChangeTrackingList<MultipartFormFileData>();
        }

        /// <summary>
        /// Document to be translated in the form
        /// <para>
        /// To assign a <see cref="MultipartFormFileData"/> to this property.
        /// The <see cref="MultipartFormFileData"/> will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>new MultipartFormFileData("test", BinaryData.FromBytes(new byte[] { 1, 2, 3 }), "text/html")</term>
        /// <description>Creates a file with name of "test", payload of "AQID" and content type of "text/html".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public MultipartFormFileData Document { get; }

        /// <summary>
        /// Glossary / translation memory will be used during translation in the form.
        /// <para>
        /// To assign a <see cref="MultipartFormFileData"/> to the element of this property.
        /// The <see cref="MultipartFormFileData"/> will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>new MultipartFormFileData("test", BinaryData.FromBytes(new byte[] { 1, 2, 3 }), "text/html")</term>
        /// <description>Creates a file with name of "test", payload of "AQID" and content type of "text/html".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public IList<MultipartFormFileData> Glossary { get; }
    }
}
