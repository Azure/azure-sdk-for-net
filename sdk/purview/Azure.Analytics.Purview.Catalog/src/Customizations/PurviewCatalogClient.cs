// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Purview.Catalog
{
    public partial class PurviewCatalogClient
    {
        /// <summary>
        /// Provides access to operations which interact with entities in the catalog.
        /// </summary>
        public PurviewEntities Entities => GetPurviewEntitiesClient();

        /// <summary>
        /// Provides access to operations which interact with glossaries in the catalog.
        /// </summary>
        public PurviewGlossaries Glossaries => GetPurviewGlossariesClient();

        /// <summary>
        /// Provides access to operations which interact with glossaries in the catalog.
        /// </summary>
        public PurviewRelationships Relationships => GetPurviewRelationshipsClient();

        /// <summary>
        /// Provides access to operations which interact with types in the catalog.
        /// </summary>
        public PurviewTypes Types => GetPurviewTypesClient();

        /// <summary>
        /// Provides access to operations which interact with collections in the catalog.
        /// </summary>
        public PurviewCollections Collections => GetPurviewCollectionsClient();

        /// <summary>
        /// Provides access to operations which interact with lineages in the catalog.
        /// </summary>
        public PurviewLineages Lineages => GetPurviewLineagesClient();
    }
}
