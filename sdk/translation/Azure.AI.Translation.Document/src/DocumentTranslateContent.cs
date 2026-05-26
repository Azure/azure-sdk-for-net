// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;
namespace Azure.AI.Translation.Document
{
    [CodeGenType("DocumentTranslateContent")]
    [CodeGenSuppress("Document")]
    [CodeGenSuppress("Glossary")]
    [CodeGenSuppress("DocumentTranslateContent", typeof(BinaryData))]
    [CodeGenSuppress("DocumentTranslateContent", typeof(BinaryData), typeof(IList<BinaryData>), typeof(IDictionary<string, BinaryData>))]
    public partial class DocumentTranslateContent
    {
        /// <summary> Initializes a new instance of <see cref="DocumentTranslateContent"/> for deserialization. </summary>
        internal DocumentTranslateContent()
        {
        }

        /// <summary> Document to be translated in the form. </summary>
        public MultipartFormFileData MultipartDocument { get; }

        /// <summary> Glossary-translation memory will be used during translation in the form. </summary>
        public IList<MultipartFormFileData> MultipartGlossary { get; }

        /// <summary> Initializes a new instance of <see cref="DocumentTranslateContent"/>. </summary>
        /// <param name="document"> Document to be translated in the form. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="document"/> is null. </exception>
        public DocumentTranslateContent(MultipartFormFileData document)
        {
            Argument.AssertNotNull(document, nameof(document));

            MultipartDocument = document;
            MultipartGlossary = new ChangeTrackingList<MultipartFormFileData>();
        }

        /// <summary> Initializes a new instance of <see cref="DocumentTranslateContent"/>. </summary>
        /// <param name="document"> Document to be translated in the form. </param>
        /// <param name="glossaries"> List of glossaries to be used during translation in the form. </param>
        public DocumentTranslateContent(MultipartFormFileData document, IList<MultipartFormFileData> glossaries)
        {
            Argument.AssertNotNull(document, nameof(document));
            MultipartDocument = document;

            foreach (MultipartFormFileData glossary in glossaries)
            {
                Argument.AssertNotNull(glossary, nameof(glossary));
            }
            MultipartGlossary = glossaries;
        }

        /// <summary> Initializes a new instance of <see cref="DocumentTranslateContent"/>. </summary>
        /// <param name="document"> Document to be translated in the form. </param>
        /// <param name="glossary"> Glossary-translation memory will be used during translation in the form. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DocumentTranslateContent(MultipartFormFileData document, IList<MultipartFormFileData> glossary, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            MultipartDocument = document;
            MultipartGlossary = glossary;
            _additionalBinaryDataProperties = serializedAdditionalRawData;
        }
    }
}
