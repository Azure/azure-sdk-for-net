// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary> Labeled data knowledge source. </summary>
    public partial class LabeledDataKnowledgeSource
    {
        /// <summary> Initializes a new instance of <see cref="LabeledDataKnowledgeSource"/> with the specified container URL. The <c>FileListPath</c> is initialized to an empty string. </summary>
        /// <param name="containerUrl"> The URL of the blob container containing labeled data. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerUrl"/> is null. </exception>
        public LabeledDataKnowledgeSource(Uri containerUrl)
            : this(containerUrl, string.Empty) { }
    }
}
