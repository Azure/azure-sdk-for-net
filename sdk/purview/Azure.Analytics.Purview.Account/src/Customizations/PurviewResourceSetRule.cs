// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Account
{
    [CodeGenClient("ResourceSetRulesClient")]
    [CodeGenSuppress("PurviewResourceSetRule", typeof(Uri), typeof(TokenCredential), typeof(PurviewAccountClientOptions))]
    public partial class PurviewResourceSetRule
    {
        internal PurviewResourceSetRule(HttpPipeline pipeline, TokenCredential tokenCredential, Uri endpoint, string apiVersion, ClientDiagnostics clientDiagnostics)
        {
            _pipeline = pipeline;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
            _clientDiagnostics = clientDiagnostics;
        }
    }
}
