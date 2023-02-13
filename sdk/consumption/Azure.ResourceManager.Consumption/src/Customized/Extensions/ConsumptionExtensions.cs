// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Consumption.Models;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Consumption
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Consumption. </summary>
    [CodeGenSuppress("GetBalanceAsync", typeof(TenantResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetBalance", typeof(TenantResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetBalanceAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetBalance", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationSummariesAsync", typeof(TenantResource), typeof(string), typeof(ReservationSummaryDataGrain), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationSummaries", typeof(TenantResource), typeof(string), typeof(ReservationSummaryDataGrain), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationSummariesAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(ReservationSummaryDataGrain), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationSummaries", typeof(TenantResource), typeof(string), typeof(string), typeof(ReservationSummaryDataGrain), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationDetailsAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationDetails", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationDetailsAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationDetails", typeof(TenantResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationTransactionsAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationTransactions", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationTransactionsAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationTransactions", typeof(TenantResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEventsAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEvents", typeof(TenantResource), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEventsAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEvents", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLotsByBillingProfileAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLotsByBillingProfile", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLotsAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLots", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLotsAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLots", typeof(TenantResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCreditAsync", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCredit", typeof(TenantResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetPriceSheetAsync", typeof(SubscriptionResource), typeof(string), typeof(string), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetPriceSheet", typeof(SubscriptionResource), typeof(string), typeof(string), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetAggregatedCostWithBillingPeriodAsync", typeof(ManagementGroupResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAggregatedCostWithBillingPeriod", typeof(ManagementGroupResource), typeof(string), typeof(CancellationToken))]
    public static partial class ConsumptionExtensions
    {
        #region BillingAccountConsumptionResource
        /// <summary>
        /// Gets an object representing a <see cref="BillingAccountConsumptionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BillingAccountConsumptionResource.CreateResourceIdentifier" /> to create a <see cref="BillingAccountConsumptionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="BillingAccountConsumptionResource" /> object. </returns>
        public static BillingAccountConsumptionResource GetBillingAccountConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                BillingAccountConsumptionResource.ValidateResourceId(id);
                return new BillingAccountConsumptionResource(client, id);
            }
            );
        }
        #endregion

        #region BillingProfileConsumptionResource
        /// <summary>
        /// Gets an object representing a <see cref="BillingProfileConsumptionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BillingProfileConsumptionResource.CreateResourceIdentifier" /> to create a <see cref="BillingProfileConsumptionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="BillingProfileConsumptionResource" /> object. </returns>
        public static BillingProfileConsumptionResource GetBillingProfileConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                BillingProfileConsumptionResource.ValidateResourceId(id);
                return new BillingProfileConsumptionResource(client, id);
            }
            );
        }
        #endregion

        #region TenantBillingPeriodConsumptionResource
        /// <summary>
        /// Gets an object representing a <see cref="TenantBillingPeriodConsumptionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="TenantBillingPeriodConsumptionResource.CreateResourceIdentifier" /> to create a <see cref="TenantBillingPeriodConsumptionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="TenantBillingPeriodConsumptionResource" /> object. </returns>
        public static TenantBillingPeriodConsumptionResource GetTenantBillingPeriodConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                TenantBillingPeriodConsumptionResource.ValidateResourceId(id);
                return new TenantBillingPeriodConsumptionResource(client, id);
            }
            );
        }
        #endregion

        #region SubscriptionBillingPeriodConsumptionResource
        /// <summary>
        /// Gets an object representing a <see cref="SubscriptionBillingPeriodConsumptionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SubscriptionBillingPeriodConsumptionResource.CreateResourceIdentifier" /> to create a <see cref="SubscriptionBillingPeriodConsumptionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SubscriptionBillingPeriodConsumptionResource" /> object. </returns>
        public static SubscriptionBillingPeriodConsumptionResource GetSubscriptionBillingPeriodConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SubscriptionBillingPeriodConsumptionResource.ValidateResourceId(id);
                return new SubscriptionBillingPeriodConsumptionResource(client, id);
            }
            );
        }
        #endregion

        #region ManagementGroupBillingPeriodConsumptionResource
        /// <summary>
        /// Gets an object representing a <see cref="ManagementGroupBillingPeriodConsumptionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ManagementGroupBillingPeriodConsumptionResource.CreateResourceIdentifier" /> to create a <see cref="ManagementGroupBillingPeriodConsumptionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ManagementGroupBillingPeriodConsumptionResource" /> object. </returns>
        public static ManagementGroupBillingPeriodConsumptionResource GetManagementGroupBillingPeriodConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ManagementGroupBillingPeriodConsumptionResource.ValidateResourceId(id);
                return new ManagementGroupBillingPeriodConsumptionResource(client, id);
            }
            );
        }
        #endregion

        #region BillingCustomerConsumptionResource
        /// <summary>
        /// Gets an object representing a <see cref="BillingCustomerConsumptionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="BillingCustomerConsumptionResource.CreateResourceIdentifier" /> to create a <see cref="BillingCustomerConsumptionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="BillingCustomerConsumptionResource" /> object. </returns>
        public static BillingCustomerConsumptionResource GetBillingCustomerConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                BillingCustomerConsumptionResource.ValidateResourceId(id);
                return new BillingCustomerConsumptionResource(client, id);
            }
            );
        }
        #endregion

        #region ReservationConsumptionResource
        /// <summary>
        /// Gets an object representing a <see cref="ReservationConsumptionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ReservationConsumptionResource.CreateResourceIdentifier" /> to create a <see cref="ReservationConsumptionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ReservationConsumptionResource" /> object. </returns>
        public static ReservationConsumptionResource GetReservationConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ReservationConsumptionResource.ValidateResourceId(id);
                return new ReservationConsumptionResource(client, id);
            }
            );
        }
        #endregion

        #region ReservationOrderConsumptionResource
        /// <summary>
        /// Gets an object representing a <see cref="ReservationOrderConsumptionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ReservationOrderConsumptionResource.CreateResourceIdentifier" /> to create a <see cref="ReservationOrderConsumptionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ReservationOrderConsumptionResource" /> object. </returns>
        public static ReservationOrderConsumptionResource GetReservationOrderConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ReservationOrderConsumptionResource.ValidateResourceId(id);
                return new ReservationOrderConsumptionResource(client, id);
            }
            );
        }
        #endregion
    }
}
