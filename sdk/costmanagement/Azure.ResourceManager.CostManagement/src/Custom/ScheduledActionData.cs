// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement
{
    /// <summary> Backward-compat: expose Status as nullable. </summary>
    public partial class ScheduledActionData
    {
        /// <summary> Status of the scheduled action. </summary>
        public ScheduledActionStatus? Status
        {
            get => Properties is null ? default(ScheduledActionStatus?) : Properties.Status;
            set
            {
                if (Properties is null)
                {
                    Properties = new ScheduledActionProperties();
                }
                Properties.Status = value ?? default;
            }
        }
    }
}
