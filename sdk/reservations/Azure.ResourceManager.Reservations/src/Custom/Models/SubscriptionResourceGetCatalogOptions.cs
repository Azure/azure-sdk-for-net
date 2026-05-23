// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    // Justification: GA exposed an options-bag overload for SubscriptionResource.GetCatalog
    // (SubscriptionResourceGetCatalogOptions). The new TypeSpec generator emits long-form
    // parameters; this type and overloads preserve the GA options-bag surface.
    public partial class SubscriptionResourceGetCatalogOptions
    {
        public SubscriptionResourceGetCatalogOptions()
        {
        }

        public string ReservedResourceType { get; set; }
        public AzureLocation? Location { get; set; }
        public string PublisherId { get; set; }
        public string OfferId { get; set; }
        public string PlanId { get; set; }
        public string Filter { get; set; }
        public float? Skip { get; set; }
        public float? Take { get; set; }
    }
}
