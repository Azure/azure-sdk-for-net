// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class FileSearchToolResource
    {
        /// <summary> Initializes a new instance of the <see cref="FileSearchToolResource"/> class. </summary>
        /// <param name="vectorStoreIds"> The identifiers of previously created vector stores. </param>
        /// <param name="vectorStores"> The vector store configurations for the resource. </param>
        public FileSearchToolResource(
            IList<string> vectorStoreIds,
            IList<VectorStoreConfigurations> vectorStores
        )
        {
            VectorStoreIds = vectorStoreIds;
            if (vectorStores == null)
                VectorStores = new ChangeTrackingList<VectorStoreConfigurations>();
            else
                VectorStores = vectorStores;
        }
    }
}
