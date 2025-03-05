// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
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
            set => Fields = InternalSearchExtensions.CommaSplit(value);
        }
    }
}
