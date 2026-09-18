// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Language.Documents
{
    /// <summary> Contains an input document to be analyzed by the service. </summary>
    public partial class MultiLanguageInput
    {
        /// <summary> Initializes a new instance of <see cref="MultiLanguageInput"/>. </summary>
        /// <param name="id"> A unique, non-empty document identifier. </param>
        /// <param name="source"> The location of the input document to process. </param>
        /// <param name="target"> The location where the processed document will be stored. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="source"/> or <paramref name="target"/> is null. </exception>
        public MultiLanguageInput(string id, Uri source, Uri target)
            : this(
                id,
                new AzureBlobDocumentLocation(source?.AbsoluteUri ?? throw new ArgumentNullException(nameof(source))),
                new AzureBlobDocumentLocation(target?.AbsoluteUri ?? throw new ArgumentNullException(nameof(target))))
        {
        }
    }
}
