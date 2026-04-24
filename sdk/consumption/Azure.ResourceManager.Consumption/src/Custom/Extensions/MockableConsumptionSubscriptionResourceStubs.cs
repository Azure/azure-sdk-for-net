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
