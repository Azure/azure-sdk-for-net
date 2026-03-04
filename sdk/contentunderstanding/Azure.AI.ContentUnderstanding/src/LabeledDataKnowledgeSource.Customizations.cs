// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.ContentUnderstanding
{
    public partial class LabeledDataKnowledgeSource
    {
        /// <summary> Initializes a new instance of <see cref="LabeledDataKnowledgeSource"/>. </summary>
        /// <param name="containerUri"> The URL of the blob container containing labeled data. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerUri"/> is null. </exception>
        public LabeledDataKnowledgeSource(Uri containerUri) : base(KnowledgeSourceKind.LabeledData)
        {
            Argument.AssertNotNull(containerUri, nameof(containerUri));
            ContainerUri = containerUri;
        }
    }
}
