// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewScanClient
    {
        internal PurviewScanClient(Uri endpoint, string dataSourceName, string scanName, HttpPipeline pipeline, string apiVersion) {
            _endpoint = endpoint;
            _dataSourceName= dataSourceName;
            _scanName = scanName;
            _pipeline = pipeline;
            _apiVersion = apiVersion;
        }
    }
}
