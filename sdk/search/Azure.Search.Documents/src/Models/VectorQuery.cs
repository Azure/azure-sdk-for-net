// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    public partial class VectorQuery : VectorizableQuery
    {
        /// <summary> Initializes a new instance of VectorQuery. </summary>
        /// <param name="vector"> The vector representation of a search query. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vector"/> is null. </exception>
        public VectorQuery(IReadOnlyList<float> vector)
        {
            Argument.AssertNotNull(vector, nameof(vector));

            Vector = vector.ToList();
            Kind = VectorQueryKind.Vector;
        }

        /// <summary> Initializes a new instance of VectorQuery. </summary>
        /// <param name="vector"> The vector representation of a search query. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vector"/> is null. </exception>
        private VectorQuery(IEnumerable<float> vector)
        {
            Argument.AssertNotNull(vector, nameof(vector));

            Vector = vector.ToList();
            Kind = VectorQueryKind.Vector;
        }

        /// <summary> The vector representation of a search query. </summary>
        public IReadOnlyList<float> Vector { get; set; }
    }
}
