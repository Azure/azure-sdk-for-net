// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// The query parameters for vector and hybrid search queries.
    /// Please note <see cref="VectorQuery"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="VectorizableTextQuery"/> and <see cref="RawVectorQuery"/>.
    /// </summary>
    public abstract partial class VectorQuery
    {
        /// <summary> Vector Fields of type Collection(Edm.Single) to be included in the vector searched. </summary>
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
