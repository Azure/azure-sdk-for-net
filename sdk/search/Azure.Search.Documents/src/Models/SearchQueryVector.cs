// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary> The query parameters for vector and hybrid search queries. </summary>
    public partial class SearchQueryVector
    {
        /// <summary> The vector representation of a search query. </summary>
        public IReadOnlyList<float> Value { get; set; }

        /// <summary>
        /// Vector Fields of type Collection(Edm.Single) to be included in the vector searched.
        /// </summary>
        public IList<string> Fields { get; internal set; } = new List<string>();

        /// <summary>
        /// Join Fields so it can be sent as a comma separated string.
        /// </summary>
        [CodeGenMember("Fields")]
        internal string FieldsRaw
        {
            get => Fields.CommaJoin();
            set => Fields = SearchExtensions.CommaSplit(value);
        }
    }
}
