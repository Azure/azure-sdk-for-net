// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Indexes.Models
{
    public abstract partial class VectorSearchAlgorithmConfiguration
    {
        internal VectorSearchAlgorithmConfiguration() { }

        /// <summary> Initializes a new instance of <see cref="VectorSearchAlgorithmConfiguration"/>. </summary>
        /// <param name="name"> The name to associate with this particular configuration. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        protected VectorSearchAlgorithmConfiguration(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }
    }
}
