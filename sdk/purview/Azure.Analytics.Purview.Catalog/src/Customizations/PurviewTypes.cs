// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Catalog
{
    [CodeGenClient("PurviewTypesClient")]
    [CodeGenSuppress("PurviewTypes", typeof(Uri), typeof(TokenCredential), typeof(PurviewCatalogClientOptions))]
    public partial class PurviewTypes
    {
        internal PurviewTypes(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, Uri endpoint, string apiVersion)
        {
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
            _endpoint = endpoint;
            _apiVersion = apiVersion;
        }
    }
}
