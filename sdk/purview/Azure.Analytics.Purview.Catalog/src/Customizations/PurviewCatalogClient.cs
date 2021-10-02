// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Catalog
{
    public partial class PurviewCatalogClient
    {
        private PurviewEntities _purviewEntities;
        private PurviewGlossaries _purviewGlossaries;
        private PurviewRelationships _purviewRelationships;
        private PurviewTypes _purviewTypes;
        private Uri _endpoint;
        private string _apiVersion;

        /// <summary> Initializes a new instance of PurviewCatalogClient. </summary>
        /// <param name="endpoint"> The catalog endpoint of your Purview account. Example: https://{accountName}.catalog.purview.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PurviewCatalogClient(Uri endpoint, TokenCredential credential, PurviewCatalogClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PurviewCatalogClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _tokenCredential = credential;
            var authPolicy = new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _restClient = new PurviewCatalogRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version);
        }

        /// <summary>
        /// Provides access to operations which interact with entities in the catalog.
        /// </summary>
        public PurviewEntities Entities { get => _purviewEntities ??= new PurviewEntities(Pipeline, _clientDiagnostics, _endpoint); }

        /// <summary>
        /// Provides access to operations which interact with glossaries in the catalog.
        /// </summary>
        public PurviewGlossaries Glossaries { get => _purviewGlossaries ??= new PurviewGlossaries(Pipeline, _clientDiagnostics, _endpoint, _apiVersion); }

        /// <summary>
        /// Provides access to operations which interact with glossaries in the catalog.
        /// </summary>
        public PurviewRelationships Relationships { get => _purviewRelationships ??= new PurviewRelationships(Pipeline, _clientDiagnostics, _endpoint); }

        /// <summary>
        /// Provides access to operations which interact with types in the catalog.
        /// </summary>
        public PurviewTypes Types { get => _purviewTypes ??= new PurviewTypes(Pipeline, _clientDiagnostics, _endpoint, _apiVersion); }
    }
}
