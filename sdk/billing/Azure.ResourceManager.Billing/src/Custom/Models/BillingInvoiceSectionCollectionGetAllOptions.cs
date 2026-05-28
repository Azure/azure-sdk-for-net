// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591
namespace Azure.ResourceManager.Billing.Models
{
    // Restored from GA 1.2.2 surface: aggregates the OData-style query options for
    // Collection.GetAll(...). The new TypeSpec generator emits individual parameters,
    // so this Options class is provided here only as a Custom partial to preserve the
    // GA call-site shape.
    public partial class BillingInvoiceSectionCollectionGetAllOptions
    {
        public BillingInvoiceSectionCollectionGetAllOptions() { }

        public bool? Count { get; set; }
        public string Filter { get; set; }
        public bool? IncludeDeleted { get; set; }
        public string OrderBy { get; set; }
        public string Search { get; set; }
        public long? Skip { get; set; }
        public long? Top { get; set; }
    }
}
