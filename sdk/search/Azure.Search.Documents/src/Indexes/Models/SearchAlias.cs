// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SearchAlias
    {
        [CodeGenMember("ETag")]
        private readonly string _etag;

        /// <summary>
        /// The <see cref="Azure.ETag"/> of the <see cref="SearchAlias"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? null : new ETag(_etag);
        }

        /// <summary> Initializes a new instance of SearchAlias. </summary>
        /// <param name="name"> The name of the alias. </param>
        /// <param name="index"> The name of the index this alias maps to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="index"/> is null. </exception>
        public SearchAlias(string name, string index)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Indexes = (index != null) ? new List<string> { index } : throw new ArgumentNullException(nameof(index));
        }
    }
}
