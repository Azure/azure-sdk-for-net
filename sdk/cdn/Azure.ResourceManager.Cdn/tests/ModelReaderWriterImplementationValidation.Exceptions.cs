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
                "Azure.ResourceManager.Cdn.Models.ProfileResourceGetLogAnalyticsMetricsOptions",
                "Azure.ResourceManager.Cdn.Models.ProfileResourceGetLogAnalyticsRankingsOptions",
                "Azure.ResourceManager.Cdn.Models.ProfileResourceGetWafLogAnalyticsMetricsOptions",
                "Azure.ResourceManager.Cdn.Models.ProfileResourceGetWafLogAnalyticsRankingsOptions"
            };
        }
    }
}
