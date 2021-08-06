// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.ConfidentialLedger
{
    [CodeGenSuppress("ConfidentialLedgerIdentityServiceClient", typeof(Uri), typeof(TokenCredential), typeof(ConfidentialLedgerClientOptions))]
    public partial class ConfidentialLedgerIdentityServiceClient
    {
        /// <summary> Initializes a new instance of ConfidentialLedgerIdentityServiceClient. </summary>
        /// <param name="identityServiceUri"> The Identity Service URL, for example https://identity.accledger.azure.com. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public ConfidentialLedgerIdentityServiceClient(Uri identityServiceUri, ConfidentialLedgerClientOptions options = null)
        {
            if (identityServiceUri == null)
            {
                throw new ArgumentNullException(nameof(identityServiceUri));
            }

            // TODO: properly generate the client without a credential.
            _tokenCredential = null;
            if (_tokenCredential != null)
            {
                // Do nothing.
            }
            options ??= new ConfidentialLedgerClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            this.identityServiceUri = identityServiceUri;
            apiVersion = options.Version;
        }
    }
}
