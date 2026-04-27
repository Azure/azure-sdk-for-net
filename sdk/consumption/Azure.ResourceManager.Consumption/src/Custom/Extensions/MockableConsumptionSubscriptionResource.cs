// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Consumption.Models;

namespace Azure.ResourceManager.Consumption.Mocking
{
    // Backward-compat stubs on the generated MockableConsumptionSubscriptionResource partial class.
    // The shipped v1.1.0 SDK exposed GetPriceSheet on subscription scope; the TypeSpec migration
    // moved this to a dedicated PriceSheet resource. These overloads throw NotSupportedException
    // and are hidden from IntelliSense — kept solely for ApiCompat against the shipped surface.
    public partial class MockableConsumptionSubscriptionResource
    {
        [Obsolete("Use GetPriceSheetResult/GetPriceSheetResultAsync on the generated surface instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PriceSheetResult> GetPriceSheet(string expand = null, string skipToken = null, int? top = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetPriceSheetResource or GetPriceSheetResultResource instead.");

        [Obsolete("Use GetPriceSheetResult/GetPriceSheetResultAsync on the generated surface instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PriceSheetResult>> GetPriceSheetAsync(string expand = null, string skipToken = null, int? top = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetPriceSheetResource or GetPriceSheetResultResource instead.");
    }
}
