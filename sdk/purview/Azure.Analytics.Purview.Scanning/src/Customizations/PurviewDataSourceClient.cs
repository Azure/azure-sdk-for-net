// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewDataSourceClient
    {
        internal PurviewDataSourceClient(Uri endpoint, string dataSourceName, HttpPipeline pipeline, string apiVersion) {
            _endpoint = endpoint;
            _dataSourceName= dataSourceName;
            _pipeline = pipeline;
            _apiVersion = apiVersion;
        }

        /// <summary />
        public virtual PurviewScanClient GetScanClient(string scanName) => new PurviewScanClient(_endpoint, _dataSourceName, scanName, Pipeline, _apiVersion);
    }
}
