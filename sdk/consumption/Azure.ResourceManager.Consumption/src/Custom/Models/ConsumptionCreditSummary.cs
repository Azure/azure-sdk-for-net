// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Consumption.Models
{
    // This type was renamed to ConsumptionCreditSummaryData and moved to the root namespace.
    // Stub retained for backward compatibility; explicitly implements IJsonModel<ConsumptionCreditSummary>
    // so ApiCompat against the shipped v1.1.0 interface list still passes.
    [Obsolete("This type is obsolete. Use ConsumptionCreditSummaryData instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ConsumptionCreditSummary : ResourceData, IJsonModel<ConsumptionCreditSummary>
    {
        /// <summary> Initializes a new instance of <see cref="ConsumptionCreditSummary"/>. </summary>
        public ConsumptionCreditSummary()
        {
            throw new NotSupportedException("This type is obsolete. Use ConsumptionCreditSummaryData instead.");
        }

        /// <summary> Initializes a new instance of <see cref="ConsumptionCreditSummary"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="balanceSummary"> Summary of balances associated with this credit summary. </param>
        /// <param name="pendingCreditAdjustments"> Pending credit adjustments. </param>
        /// <param name="expiredCredit"> Expired credit. </param>
        /// <param name="pendingEligibleCharges"> Pending eligible charges. </param>
        /// <param name="creditCurrency"> The credit currency. </param>
        /// <param name="billingCurrency"> The billing currency. </param>
        /// <param name="reseller"> Credit's reseller. </param>
        /// <param name="etag"> eTag of the resource. To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ConsumptionCreditSummary(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, CreditBalanceSummary balanceSummary, ConsumptionAmount pendingCreditAdjustments, ConsumptionAmount expiredCredit, ConsumptionAmount pendingEligibleCharges, string creditCurrency, string billingCurrency, ConsumptionReseller reseller, ETag? etag, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            throw new NotSupportedException("This type is obsolete.");
        }

        /// <summary> Summary of balances associated with this credit summary. </summary>
        public CreditBalanceSummary BalanceSummary { get; }
        /// <summary> Pending credit adjustments. </summary>
        public ConsumptionAmount PendingCreditAdjustments { get; }
        /// <summary> Expired credit. </summary>
        public ConsumptionAmount ExpiredCredit { get; }
        /// <summary> Pending eligible charges. </summary>
        public ConsumptionAmount PendingEligibleCharges { get; }
        /// <summary> The credit currency. </summary>
        public string CreditCurrency { get; }
        /// <summary> The billing currency. </summary>
        public string BillingCurrency { get; }
        /// <summary> Credit's reseller. </summary>
        public ConsumptionReseller Reseller { get; }
        /// <summary> eTag of the resource. To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not. </summary>
        public ETag? ETag { get; set; }

        // All IJsonModel/IPersistableModel members throw because this type is obsolete and cannot be
        // constructed (every public ctor throws). The previous implementation cast `this` to
        // IJsonModel<ConsumptionCreditSummaryData>, which would have thrown InvalidCastException
        // because this type does not implement that interface.
        void IJsonModel<ConsumptionCreditSummary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use ConsumptionCreditSummaryData instead.");

        ConsumptionCreditSummary IJsonModel<ConsumptionCreditSummary>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use ConsumptionCreditSummaryData instead.");

        ConsumptionCreditSummary IPersistableModel<ConsumptionCreditSummary>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use ConsumptionCreditSummaryData instead.");

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use ConsumptionCreditSummaryData instead.");

        BinaryData IPersistableModel<ConsumptionCreditSummary>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use ConsumptionCreditSummaryData instead.");

        string IPersistableModel<ConsumptionCreditSummary>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use ConsumptionCreditSummaryData instead.");
    }
}
