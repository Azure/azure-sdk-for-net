// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class IndexerListResult
    {
        /// <summary>
        /// Gets the indexers in the Search service.
        /// </summary>
        [JsonIgnore]
        public IList<Indexer> Indexers
        {
            get { return this.Value; }
        }
    }
}
