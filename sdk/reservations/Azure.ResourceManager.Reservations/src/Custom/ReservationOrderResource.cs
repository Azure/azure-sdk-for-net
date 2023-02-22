// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Reservations
{
    /// <summary>
    /// A Class representing a ReservationOrder along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ReservationOrderResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetReservationOrderResource method.
    /// Otherwise you can get one from its parent resource <see cref="TenantResource" /> using the GetReservationOrder method.
    /// </summary>
    public partial class ReservationOrderResource
    {
        /// <summary>
        /// Return a reservation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/return</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Return_Post</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Information needed for returning reservation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release. Please use ReturnAsync(WaitUntil waitUntil, ReservationRefundContent content, CancellationToken cancellationToken = default) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ReservationRefundResult>> ReturnAsync(ReservationRefundContent content, CancellationToken cancellationToken = default)
        {
            var operation = await ReturnAsync(WaitUntil.Started, content, cancellationToken).ConfigureAwait(false);
            return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Return a reservation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/return</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Return_Post</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Information needed for returning reservation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release. Please use Return(WaitUntil waitUntil, ReservationRefundContent content, CancellationToken cancellationToken = default) instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ReservationRefundResult> Return(ReservationRefundContent content, CancellationToken cancellationToken = default)
        {
            var operation = Return(WaitUntil.Started, content, cancellationToken);
            return operation.WaitForCompletion(cancellationToken);
        }
    }
}
