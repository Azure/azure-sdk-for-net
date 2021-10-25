// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Purview.Scanning
{
    public partial class PurviewScanningServiceClient
    {
        /// <summary />
        public virtual PurviewDataSourceClient GetDataSourceClient(string dataSourceName) => new PurviewDataSourceClient(_endpoint, dataSourceName, Pipeline, _apiVersion);

        /// <summary />
        public virtual PurviewClassificationRuleClient GetClassificationRuleClient(string classificationRuleName) => new PurviewClassificationRuleClient(_endpoint, classificationRuleName, Pipeline, _apiVersion);
    }
}
