// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    public partial class UsageMetricProperties
    {
        // TypeSpec emits output-only metrics with a parameterless constructor; retain the shipped
        // constructor so callers can continue creating usage metrics with both counts.
        /// <summary> Initializes a new instance of <see cref="UsageMetricProperties"/>. </summary>
        /// <param name="monthlyFirmwareUploadCount"> The number of firmware analysis jobs submitted in the current month. </param>
        /// <param name="totalFirmwareCount"> The total number of firmwares in the workspace. </param>
        public UsageMetricProperties(long monthlyFirmwareUploadCount, long totalFirmwareCount)
        {
            MonthlyFirmwareUploadCount = monthlyFirmwareUploadCount;
            TotalFirmwareCount = totalFirmwareCount;
        }
    }
}
