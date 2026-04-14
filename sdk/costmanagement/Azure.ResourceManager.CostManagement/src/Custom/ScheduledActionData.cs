// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement
{
    // Backward-compat: Status was public on ScheduledActionData in v1.0.2.
    // Generator internalizes ScheduledActionProperties, so Status has no generated path — this is the only accessor.
    public partial class ScheduledActionData
    {
        /// <summary> Status of the scheduled action. </summary>
        public ScheduledActionStatus? Status
        {
            get => Properties is null ? default(ScheduledActionStatus?) : Properties.Status;
            set
            {
                if (value is null)
                    return;
                if (Properties is null)
                {
                    Properties = new ScheduledActionProperties();
                }
                Properties.Status = value.Value;
            }
        }
    }
}
