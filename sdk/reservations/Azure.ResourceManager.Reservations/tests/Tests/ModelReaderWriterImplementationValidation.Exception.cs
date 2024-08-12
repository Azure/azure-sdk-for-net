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
                "Azure.ResourceManager.Reservations.Models.SubscriptionResourceGetCatalogOptions",
                "Azure.ResourceManager.Reservations.Models.TenantResourceGetReservationDetailsOptions",
            };
        }
    }
}
