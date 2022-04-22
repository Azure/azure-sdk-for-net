// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Catalog
{
    [CodeGenClient("PurviewRelationshipClient")]
    [CodeGenSuppress("PurviewRelationships", typeof(Uri), typeof(TokenCredential), typeof(PurviewCatalogClientOptions))]
    public partial class PurviewRelationships
    {
        internal PurviewRelationships(HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, Uri endpoint)
        {
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
            _endpoint = endpoint;
        }
    }
}
