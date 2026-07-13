// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Consumption.Models
{
    // This type was renamed to ConsumptionCreditSummaryData and moved to the root namespace.
    // Stub retained for source/binary-compatibility with the shipped v1.1.0 surface only;
    // every member throws NotSupportedException at runtime. The serialization interfaces
    // are declared (as in v1.1.0) but no longer have a real implementation - they are part
    // of the v1.1.0 public surface and are required by ApiCompat to remain on the type.
    /// <summary> Obsolete. Use <see cref="ConsumptionCreditSummaryData"/> instead. </summary>
    [Obsolete("This type is obsolete. Use ConsumptionCreditSummaryData instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ConsumptionCreditSummary : ResourceData, IJsonModel<ConsumptionCreditSummary>, IPersistableModel<ConsumptionCreditSummary>
    {
        private const string ObsoleteMessage = "This type is obsolete. Use ConsumptionCreditSummaryData instead.";

        /// <summary> Initializes a new instance of <see cref="ConsumptionCreditSummary"/>. </summary>
        public ConsumptionCreditSummary()
        {
            throw new NotSupportedException(ObsoleteMessage);
        }

        /// <summary> Summary of balances associated with this credit summary. </summary>
        public CreditBalanceSummary BalanceSummary => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> Pending credit adjustments. </summary>
        public ConsumptionAmount PendingCreditAdjustments => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> Expired credit. </summary>
        public ConsumptionAmount ExpiredCredit => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> Pending eligible charges. </summary>
        public ConsumptionAmount PendingEligibleCharges => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> The credit currency. </summary>
        public string CreditCurrency => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> The billing currency. </summary>
        public string BillingCurrency => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> Credit's reseller. </summary>
        public ConsumptionReseller Reseller => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> eTag of the resource. To handle concurrent update scenario, this field will be used to determine whether the user is updating the latest version or not. </summary>
        public ETag? ETag
        {
            get => throw new NotSupportedException(ObsoleteMessage);
            set => throw new NotSupportedException(ObsoleteMessage);
        }

        ConsumptionCreditSummary IJsonModel<ConsumptionCreditSummary>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException(ObsoleteMessage);
        void IJsonModel<ConsumptionCreditSummary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException(ObsoleteMessage);
        ConsumptionCreditSummary IPersistableModel<ConsumptionCreditSummary>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException(ObsoleteMessage);
        string IPersistableModel<ConsumptionCreditSummary>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException(ObsoleteMessage);
        BinaryData IPersistableModel<ConsumptionCreditSummary>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException(ObsoleteMessage);
    }
}
