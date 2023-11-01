// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary> Representation of a single embeddings relatedness comparison. </summary>
    public partial class EmbeddingItem
    {
        // CUSTOM CODE NOTE: The change of the Embedding property to ReadOnlyMemory<float>
        // results in the constructor below being generated twice and thus a build error.
        // We're adding it here verbatim as custom code to work around this issue.

        /// <summary> Initializes a new instance of EmbeddingItem. </summary>
        /// <param name="embedding">
        /// List of embeddings value for the input prompt. These represent a measurement of the
        /// vector-based relatedness of the provided input.
        /// </param>
        /// <param name="index"> Index of the prompt to which the EmbeddingItem corresponds. </param>
        internal EmbeddingItem(ReadOnlyMemory<float> embedding, int index)
        {
            Embedding = embedding;
            Index = index;
        }

        // CUSTOM CODE NOTE: We want to represent embeddings as ReadOnlyMemory<float> instead
        // of IReadOnlyList<float>.
        public ReadOnlyMemory<float> Embedding { get; }
    }
}
