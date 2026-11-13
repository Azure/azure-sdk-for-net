// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Indexes.Models
{
    public abstract partial class VectorSearchVectorizer
    {
        /// <summary> Initializes a new instance of <see cref="VectorSearchVectorizer"/>. </summary>
        /// <param name="vectorizerName"> The name to associate with this particular vectorization method. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorizerName"/> is null. </exception>
        protected VectorSearchVectorizer(string vectorizerName)
        {
            Argument.AssertNotNull(vectorizerName, nameof(vectorizerName));

            VectorizerName = vectorizerName;
        }

        /// <summary> The name to associate with this particular vectorization method. </summary>
        public string VectorizerName { get; }
    }
}
