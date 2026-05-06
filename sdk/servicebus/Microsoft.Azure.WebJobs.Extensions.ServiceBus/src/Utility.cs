// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    internal class Utility
    {
        /// <summary>
        /// Returns processor count for a worker, for consumption plan always returns 1
        /// </summary>
        /// <returns></returns>
        public static int GetProcessorCount()
        {
            string skuValue = Environment.GetEnvironmentVariable(Constants.AzureWebsiteSku);
            return string.Equals(skuValue, Constants.DynamicSku, StringComparison.OrdinalIgnoreCase) || string.Equals(skuValue, Constants.FlexConsumptionSku, StringComparison.OrdinalIgnoreCase)
                ? 1 : Environment.ProcessorCount;
        }
    }
}
