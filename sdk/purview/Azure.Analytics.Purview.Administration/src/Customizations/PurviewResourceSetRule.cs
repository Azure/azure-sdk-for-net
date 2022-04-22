// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Administration
{
    [CodeGenClient("ResourceSetRulesClient")]
    [CodeGenSuppress("PurviewResourceSetRule", typeof(Uri), typeof(TokenCredential), typeof(PurviewAccountClientOptions))]
    public partial class PurviewResourceSetRule
    {
        internal PurviewResourceSetRule(HttpPipeline pipeline, TokenCredential tokenCredential, Uri endpoint, ClientDiagnostics clientDiagnostics)
        {
            _pipeline = pipeline;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _clientDiagnostics = clientDiagnostics;
        }
    }
}
