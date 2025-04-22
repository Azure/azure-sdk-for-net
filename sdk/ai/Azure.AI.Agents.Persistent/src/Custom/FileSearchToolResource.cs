// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class FileSearchToolResource
    {
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
