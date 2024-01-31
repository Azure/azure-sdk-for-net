// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The location containing data to train Document Models and Document Classifiers.
    /// Supported content sources are:
    /// <list type="bullet">
    ///   <item><description><see cref="BlobContentSource"/></description></item>
    ///   <item><description><see cref="BlobFileListContentSource"/></description></item>
    /// </list>
    /// </summary>
    public abstract class DocumentContentSource
    {
        internal DocumentContentSource(DocumentContentSourceKind kind)
        {
            Kind = kind;
        }

        /// <summary>
        /// The source kind.
        /// </summary>
        public DocumentContentSourceKind Kind { get; }
    }
}
