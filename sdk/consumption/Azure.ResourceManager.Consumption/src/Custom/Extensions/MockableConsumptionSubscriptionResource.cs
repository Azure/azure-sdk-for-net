// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Consumption.Models;

namespace Azure.ResourceManager.Consumption.Mocking
{
    /// <summary>
    /// Backward-compat stubs on the generated <see cref="MockableConsumptionSubscriptionResource"/>
    /// partial class. The shipped v1.1.0 SDK exposed <c>GetPriceSheet</c> on the subscription scope;
    /// the TypeSpec migration moved this to a dedicated <c>PriceSheet</c> resource. These overloads
    /// throw <see cref="NotSupportedException"/> and are hidden from IntelliSense — kept solely for
    /// ApiCompat against the shipped surface.
    /// </summary>
    public partial class MockableConsumptionSubscriptionResource
    {
        /// <summary> Obsolete. Use <c>GetPriceSheetResult</c>/<c>GetPriceSheetResultAsync</c> on the generated surface instead. </summary>
        /// <param name="expand"> Optional expand expression. </param>
        /// <param name="skipToken"> Optional pagination skip-token. </param>
        /// <param name="top"> Optional maximum number of records to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetPriceSheetResult/GetPriceSheetResultAsync on the generated surface instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PriceSheetResult> GetPriceSheet(string expand = null, string skipToken = null, int? top = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetPriceSheetResource or GetPriceSheetResultResource instead.");

        /// <summary> Obsolete. Use <c>GetPriceSheetResult</c>/<c>GetPriceSheetResultAsync</c> on the generated surface instead. </summary>
        /// <param name="expand"> Optional expand expression. </param>
        /// <param name="skipToken"> Optional pagination skip-token. </param>
        /// <param name="top"> Optional maximum number of records to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetPriceSheetResult/GetPriceSheetResultAsync on the generated surface instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PriceSheetResult>> GetPriceSheetAsync(string expand = null, string skipToken = null, int? top = default, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use GetPriceSheetResource or GetPriceSheetResultResource instead.");
    }
}
