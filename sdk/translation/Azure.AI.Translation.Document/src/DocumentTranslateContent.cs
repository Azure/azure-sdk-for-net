// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;
namespace Azure.AI.Translation.Document
{
    [CodeGenSuppress("ToMultipartFormContent")]
    public partial class DocumentTranslateContent
    {
        /// <summary> Document to be translated in the form. </summary>
        [CodeGenMember("Document")]
        public MultipartFormFileData MultipartDocument { get; }

        /// <summary> Glossary-translation memory will be used during translation in the form. </summary>
        [CodeGenMember("Glossary")]
        public IList<MultipartFormFileData> MultipartGlossary { get; }

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
    }
}
