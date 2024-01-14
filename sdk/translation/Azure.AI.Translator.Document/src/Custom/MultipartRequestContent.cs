// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    public partial class DocumentContent
    {
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
        internal BinaryData Document { get; }
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
        internal IList<BinaryData> Glossary { get; }

        internal MultipartFormDataContent MultipartFormDataContent { get; }

        /// <summary> Initializes a new instance of <see cref="DocumentContent"/>. </summary>
        /// <param name="documentData"> Document content. </param>
        /// <param name="documentName"> Document file name with extension. </param>
        /// <param name="documentContentType"> Document content type. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="documentData"/> is null. </exception>
        public DocumentContent(BinaryData documentData, string documentName, string documentContentType)
        {
            Argument.AssertNotNull(documentData, nameof(documentData));
            Argument.AssertNotNull(documentName, nameof(documentName));
            Argument.AssertNotNull(documentContentType, nameof(documentContentType));
            this.MultipartFormDataContent = new MultipartFormDataContent();
            var headers = new Dictionary<string, string>()
            {
                {"Content-Type", documentContentType }
            };
            this.MultipartFormDataContent.Add(RequestContent.Create(documentData), "document", documentName, headers);
        }

        /// <summary>
        /// Add glossary file
        /// </summary>
        /// <param name="glossaryData"> Glossary content. </param>
        /// <param name="glossaryName"> Glossary file name with extension. </param>
        /// <param name="glossaryContentType"> Glossary content type. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="glossaryData"/> is null. </exception>
        public void AddGlossary(BinaryData glossaryData, string glossaryName, string glossaryContentType)
        {
            Argument.AssertNotNull(glossaryData, nameof(glossaryData));
            Argument.AssertNotNull(glossaryName, nameof(glossaryName));
            Argument.AssertNotNull(glossaryContentType, nameof(glossaryContentType));
            var headers = new Dictionary<string, string>()
            {
                {"Content-Type", glossaryContentType }
            };
            this.MultipartFormDataContent.Add(RequestContent.Create(glossaryData), "glossary", glossaryName, headers);
        }
    }
}
