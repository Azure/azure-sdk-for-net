// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Account
{
    [CodeGenClient("AccountsClient")]
    public partial class PurviewAccountClient
    {
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of PurviewAccountClient. </summary>
        /// <param name="endpoint"> The account endpoint of your Purview account. Example: https://{accountName}.purview.azure.com/account/. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PurviewAccountClient(Uri endpoint, TokenCredential credential, PurviewAccountClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PurviewAccountClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _tokenCredential = credential;
            var authPolicy = new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _restClient = new AccountsRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version);
        }

        /// <summary>
        /// Gets a service client for interacting with a collection.
        /// </summary>
        /// <param name="collectionName">The name of the collection to use.</param>
        /// <returns>A service client for interacting with a collection.</returns>
        public virtual PurviewCollection GetCollectionClient(string collectionName)
        {
            if (string.IsNullOrEmpty(collectionName))
            {
                throw new ArgumentNullException(nameof(collectionName));
            }

            return new PurviewCollection(Pipeline, _tokenCredential, _endpoint, collectionName, _apiVersion, _clientDiagnostics);
        }

        /// <summary>
        /// Gets a service client for interacting with a resource set rule.
        /// </summary>
        /// <returns>A service client for interacting with a resource set rule.</returns>
        public virtual PurviewResourceSetRule GetResourceSetRuleClient()
        {
            return new PurviewResourceSetRule(Pipeline, _tokenCredential, _endpoint, _apiVersion, _clientDiagnostics);
        }
    }
}
