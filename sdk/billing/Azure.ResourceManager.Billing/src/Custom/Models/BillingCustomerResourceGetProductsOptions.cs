// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#pragma warning disable CS1591
namespace Azure.ResourceManager.Billing.Models
{
    /// <summary>
    /// Back-compat aggregate restored from GA 1.2.2: groups the query options for the
    /// corresponding method. The new MPG generator emits individual parameters; this
    /// type is preserved here only so GA call-sites that pass an aggregate continue to compile.
    /// </summary>
    public partial class BillingCustomerResourceGetProductsOptions
    {
        public BillingCustomerResourceGetProductsOptions() { }
        public bool? Count { get; set; }
        public string Filter { get; set; }
        public string OrderBy { get; set; }
        public string Search { get; set; }
        public long? Skip { get; set; }
        public long? Top { get; set; }
    }
}