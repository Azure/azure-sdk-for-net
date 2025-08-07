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
                "Azure.ResourceManager.Monitor.Models.ArmResourceGetMonitorMetricBaselinesOptions",
                "Azure.ResourceManager.Monitor.Models.ArmResourceGetMonitorMetricsOptions",
                "Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsOptions",
                "Azure.ResourceManager.Monitor.Models.SubscriptionResourceGetMonitorMetricsWithPostOptions",
            };
        }
    }
}
