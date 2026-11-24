// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    public partial class UsageMetricProperties
    {
        /// <summary> Initializes a new instance of <see cref="UsageMetricProperties"/>. </summary>
        /// <param name="monthlyFirmwareUploadCount"> The number of firmware analysis jobs that have been submitted in the current month. </param>
        /// <param name="totalFirmwareCount"> The total number of firmwares that are in the workspace. </param>
        public UsageMetricProperties(long monthlyFirmwareUploadCount, long totalFirmwareCount)
        {
            MonthlyFirmwareUploadCount = monthlyFirmwareUploadCount;
            TotalFirmwareCount = totalFirmwareCount;
        }
    }
}
