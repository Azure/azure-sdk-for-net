// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using System.Linq;

namespace Azure.Maps.Search.Models
{
    /// <summary> Initializes a new instance of BatchRequest. </summary>
    internal partial class BatchRequest<T> where T: IQueryRepresentable
    {
        /// <summary> Initializes a new instance of BatchRequest. </summary>
        internal BatchRequest(IList<BatchRequestItem<T>> batchItems)
        {
            BatchItems = batchItems;
        }

        /// <summary> The list of queries to process. </summary>
        internal IList<BatchRequestItem<T>> BatchItems { get; }

        internal BatchRequestInternal internalRepresentation(SearchClient client) => new BatchRequestInternal(this.BatchItems.Select(item => new BatchRequestItemInternal(client, item.Query)));

        internal static BatchRequest<T> withQueries(IEnumerable<T> queries)
        {
            return new BatchRequest<T>(queries.Select(item => new BatchRequestItem<T>(item)).ToList());
        }
    }
}
