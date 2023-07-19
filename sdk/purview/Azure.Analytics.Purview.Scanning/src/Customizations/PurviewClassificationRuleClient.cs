// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewClassificationRuleClient
    {
        internal PurviewClassificationRuleClient(Uri endpoint, string classificationRuleName, HttpPipeline pipeline, string apiVersion) {
            _endpoint = endpoint;
            _pipeline = pipeline;
            _classificationRuleName = classificationRuleName;
            _apiVersion = apiVersion;
        }
    }
}
