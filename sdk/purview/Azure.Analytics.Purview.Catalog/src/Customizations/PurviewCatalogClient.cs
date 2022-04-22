// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Purview.Catalog
{
    public partial class PurviewCatalogClient
    {
        private PurviewEntities purviewEntities;
        private PurviewGlossaries purviewGlossaries;
        private PurviewRelationships purviewRelationships;
        private PurviewTypes purviewTypes;
        private PurviewCollections purviewCollections;
        private PurviewLineages purviewLineages;

        /// <summary>
        /// Provides access to operations which interact with entities in the catalog.
        /// </summary>
        public PurviewEntities Entities { get => purviewEntities ??= new PurviewEntities(Pipeline, _clientDiagnostics, _endpoint); }

        /// <summary>
        /// Provides access to operations which interact with glossaries in the catalog.
        /// </summary>
        public PurviewGlossaries Glossaries { get => purviewGlossaries ??= new PurviewGlossaries(Pipeline, _clientDiagnostics, _endpoint, _apiVersion); }

        /// <summary>
        /// Provides access to operations which interact with glossaries in the catalog.
        /// </summary>
        public PurviewRelationships Relationships { get => purviewRelationships ??= new PurviewRelationships(Pipeline, _clientDiagnostics, _endpoint); }

        /// <summary>
        /// Provides access to operations which interact with types in the catalog.
        /// </summary>
        public PurviewTypes Types { get => purviewTypes ??= new PurviewTypes(Pipeline, _clientDiagnostics, _endpoint, _apiVersion); }

        /// <summary>
        /// Provides access to operations which interact with collections in the catalog.
        /// </summary>
        public PurviewCollections Collections { get => purviewCollections ??= new PurviewCollections(Pipeline, _clientDiagnostics, _endpoint, _apiVersion); }

        /// <summary>
        /// Provides access to operations which interact with lineages in the catalog.
        /// </summary>
        public PurviewLineages Lineages { get => purviewLineages ??= new PurviewLineages(Pipeline, _clientDiagnostics, _endpoint, _apiVersion); }
    }
}
