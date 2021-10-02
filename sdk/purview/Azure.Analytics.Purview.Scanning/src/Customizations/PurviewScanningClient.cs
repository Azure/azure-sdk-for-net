// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewScanningServiceClient
    {
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> Initializes a new instance of PurviewScanningServiceClient. </summary>
        /// <param name="endpoint"> The scanning endpoint of your purview account. Example: https://{accountName}.scan.purview.azure.com. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PurviewScanningServiceClient(Uri endpoint, TokenCredential credential, PurviewScanningServiceClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PurviewScanningServiceClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _tokenCredential = credential;
            var authPolicy = new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy }, new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
            _restClient = new PurviewScanningServiceRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version);
        }

        /// <summary />
        public PurviewDataSourceClient GetDataSourceClient(string dataSourceName) => new PurviewDataSourceClient(_endpoint, dataSourceName, Pipeline, _apiVersion);

        /// <summary />
        public PurviewClassificationRuleClient GetClassificationRuleClient(string classificationRuleName) => new PurviewClassificationRuleClient(_endpoint, classificationRuleName, Pipeline, _apiVersion);
    }
}
