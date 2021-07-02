// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewScanningServiceClient
    {
        /// <summary />
        public PurviewDataSourceClient GetDataSourceClient(string dataSourceName) => new PurviewDataSourceClient(endpoint, dataSourceName, Pipeline, apiVersion);

        /// <summary />
        public PurviewClassificationRuleClient GetClassificationRuleClient(string classificationRuleName) => new PurviewClassificationRuleClient(endpoint, classificationRuleName, Pipeline, apiVersion);
    }
}
