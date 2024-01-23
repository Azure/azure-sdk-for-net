// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.TestFramework
{
    public sealed partial class ModelReaderWriterImplementationValidation
    {
        public ModelReaderWriterImplementationValidation()
        {
            ExceptionList = new[]
            {
                "Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCollectionGetAllOptions",
                "Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions",
                "Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCollectionGetAllOptions",
                "Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionResourceGetAccountsOptions"
            };
        }
    }
}
