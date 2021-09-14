// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewScanClient
    {
        internal PurviewScanClient(Uri endpoint, string dataSourceName, string scanName, HttpPipeline pipeline, string apiVersion) {
            this.endpoint = endpoint;
            this.dataSourceName= dataSourceName;
            this.scanName = scanName;
            this._pipeline = pipeline;
            this.apiVersion = apiVersion;
        }
    }
}
