// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("ServiceCounters")]
    public partial class SearchServiceCounters
    {
        /// <summary> Initializes a new instance of SearchServiceCounters. </summary>
        /// <param name="aliasCounter"> Total number of aliases. </param>
        /// <param name="documentCounter"> Total number of documents across all indexes in the service. </param>
        /// <param name="indexCounter"> Total number of indexes. </param>
        /// <param name="indexerCounter"> Total number of indexers. </param>
        /// <param name="dataSourceCounter"> Total number of data sources. </param>
        /// <param name="storageSizeCounter"> Total size of used storage in bytes. </param>
        /// <param name="synonymMapCounter"> Total number of synonym maps. </param>
        /// <param name="skillsetCounter"> Total number of skillsets. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="documentCounter"/>, <paramref name="indexCounter"/>, <paramref name="indexerCounter"/>, <paramref name="dataSourceCounter"/>, <paramref name="storageSizeCounter"/>, or <paramref name="synonymMapCounter"/> is null. </exception>
        internal SearchServiceCounters(
            SearchResourceCounter aliasCounter,
            SearchResourceCounter documentCounter,
            SearchResourceCounter indexCounter,
            SearchResourceCounter indexerCounter,
            SearchResourceCounter dataSourceCounter,
            SearchResourceCounter storageSizeCounter,
            SearchResourceCounter synonymMapCounter,
            SearchResourceCounter skillsetCounter)
        {
            AliasCounter = aliasCounter;
            DocumentCounter = documentCounter ?? throw new ArgumentNullException(nameof(documentCounter));
            IndexCounter = indexCounter ?? throw new ArgumentNullException(nameof(indexCounter));
            IndexerCounter = indexerCounter ?? throw new ArgumentNullException(nameof(indexerCounter));
            DataSourceCounter = dataSourceCounter ?? throw new ArgumentNullException(nameof(dataSourceCounter));
            StorageSizeCounter = storageSizeCounter ?? throw new ArgumentNullException(nameof(storageSizeCounter));
            SynonymMapCounter = synonymMapCounter ?? throw new ArgumentNullException(nameof(synonymMapCounter));
            SkillsetCounter = skillsetCounter;
        }
    }
}
