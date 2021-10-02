// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewScanClient
    {
        internal PurviewScanClient(Uri endpoint, string dataSourceName, string scanName, HttpPipeline pipeline, string apiVersion)
        {
            _pipeline = pipeline;
            _clientDiagnostics = new ClientDiagnostics(new PurviewScanningServiceClientOptions());
            _restClient = new PurviewScanRestClient(_clientDiagnostics, pipeline, endpoint, dataSourceName, scanName, apiVersion);
        }
    }
}
