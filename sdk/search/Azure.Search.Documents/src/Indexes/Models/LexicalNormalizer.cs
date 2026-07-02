// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class LexicalNormalizer
    {
        /// <summary> Initializes a new instance of <see cref="LexicalNormalizer"/>. </summary>
        /// <param name="name"> The name of the normalizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. It cannot end in '.microsoft' nor '.lucene', nor be named 'asciifolding', 'standard', 'lowercase', 'uppercase', or 'elision'. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public LexicalNormalizer(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }
    }
}
