// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Consumption.Models;

namespace Azure.ResourceManager.Consumption
{
    // The newly generated code has two additional parameters; use custom code to add them back to the original.
    public partial class BillingAccountConsumptionResource
    {
        /// <summary>
        /// List of transactions for reserved instances on billing account scope. Note: The refund transactions are posted along with its purchase transaction (i.e. in the purchase billing month). For example, The refund is requested in May 2021. This refund transaction will have event date as May 2021 but the billing month as April 2020 when the reservation purchase was made.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/providers/Microsoft.Consumption/reservationTransactions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ReservationTransactions_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> Filter reservation transactions by date range. The properties/EventDate for start date and end date. The filter supports 'le' and  'ge'. Note: API returns data for the entire start date's and end date's billing month. For example, filter properties/eventDate+ge+2020-01-01+AND+properties/eventDate+le+2020-12-29 will include data for the entire December 2020 month (i.e. will contain records for dates December 30 and 31). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ConsumptionReservationTransaction"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionReservationTransaction> GetReservationTransactionsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            return GetReservationTransactionsAsync(filter, useMarkupIfPartner: default, previewMarkupPercentage: default, cancellationToken);
        }

        /// <summary>
        /// List of transactions for reserved instances on billing account scope. Note: The refund transactions are posted along with its purchase transaction (i.e. in the purchase billing month). For example, The refund is requested in May 2021. This refund transaction will have event date as May 2021 but the billing month as April 2020 when the reservation purchase was made.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/providers/Microsoft.Consumption/reservationTransactions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ReservationTransactions_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-10-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> Filter reservation transactions by date range. The properties/EventDate for start date and end date. The filter supports 'le' and  'ge'. Note: API returns data for the entire start date's and end date's billing month. For example, filter properties/eventDate+ge+2020-01-01+AND+properties/eventDate+le+2020-12-29 will include data for the entire December 2020 month (i.e. will contain records for dates December 30 and 31). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ConsumptionReservationTransaction"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionReservationTransaction> GetReservationTransactions(string filter, CancellationToken cancellationToken = default)
        {
            return GetReservationTransactions(filter, useMarkupIfPartner: default, previewMarkupPercentage: default, cancellationToken);
        }
    }
}
