// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewDataSourceClient
    {
        internal PurviewDataSourceClient(Uri endpoint, string dataSourceName, HttpPipeline pipeline, string apiVersion) {
            this.endpoint = endpoint;
            this.dataSourceName= dataSourceName;
            this.Pipeline = pipeline;
            this.apiVersion = apiVersion;
        }

        /// <summary />
        public PurviewScanClient GetScanClient(string scanName) => new PurviewScanClient(endpoint, dataSourceName, scanName, Pipeline, apiVersion);
    }
}
