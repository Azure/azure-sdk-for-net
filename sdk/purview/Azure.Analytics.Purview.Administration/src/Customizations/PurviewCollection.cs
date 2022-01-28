// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Administration
{
    [CodeGenClient("CollectionsClient")]
    [CodeGenSuppress("PurviewCollection", new Type[] { typeof(Uri), typeof(string), typeof(TokenCredential), typeof(PurviewAccountClientOptions)})]
    public partial class PurviewCollection
    {
        internal PurviewCollection(HttpPipeline pipeline, TokenCredential tokenCredential, Uri endpoint, string collectionName, ClientDiagnostics clientDiagnostics)
        {
            _pipeline = pipeline;
            _tokenCredential = tokenCredential;
            _endpoint = endpoint;
            _collectionName = collectionName;
            _clientDiagnostics = clientDiagnostics;
        }
    }
}
