// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Catalog
{
    [CodeGenClient("PurviewCollectionClient")]
    [CodeGenSuppress("PurviewCollections", typeof(Uri), typeof(TokenCredential), typeof(PurviewCatalogClientOptions))]
    public partial class PurviewCollections
    {
        internal PurviewCollections(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, Uri endpoint, string apiVersion)
        {
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
            this._endpoint = endpoint;
            this._apiVersion = apiVersion;
        }
    }
}
