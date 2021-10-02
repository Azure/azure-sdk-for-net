// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewDataSourceClient
    {
        private readonly Uri _endpoint;
        private readonly string _dataSourceName;
        private readonly string _apiVersion;

        internal PurviewDataSourceClient(Uri endpoint, string dataSourceName, HttpPipeline pipeline, string apiVersion) {
            _endpoint = endpoint;
            _dataSourceName = dataSourceName;
            _pipeline = pipeline;
            _apiVersion = apiVersion;

            _clientDiagnostics = new ClientDiagnostics(new PurviewScanningServiceClientOptions());
            _restClient = new PurviewDataSourceRestClient(_clientDiagnostics, pipeline, endpoint, dataSourceName, apiVersion);
        }

        /// <summary />
        public PurviewScanClient GetScanClient(string scanName) => new PurviewScanClient(_endpoint, _dataSourceName, scanName, Pipeline, _apiVersion);
    }
}
