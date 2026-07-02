// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.DataBox.Models
{
    public abstract partial class ScheduleAvailabilityContent
    {
        /// <summary> Initializes a new instance of <see cref="ScheduleAvailabilityContent"/>. </summary>
        /// <param name="storageLocation"> Location for data transfer. For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locations?api-version=2018-01-01. </param>
        protected ScheduleAvailabilityContent(AzureLocation storageLocation)
        {
            StorageLocation = storageLocation;
        }
    }
}
