// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    public abstract partial class VectorSearchVectorizer
    {
        /// <summary> The name to associate with this particular vectorization method. </summary>
        public string VectorizerName { get; }
    }
}
