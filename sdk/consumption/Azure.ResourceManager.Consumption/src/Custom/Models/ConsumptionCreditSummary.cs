// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure;

namespace Azure.ResourceManager.Consumption.Models
{
    // This type was renamed to ConsumptionCreditSummaryData and moved to the root namespace.
    // Stub retained for backward compatibility; explicitly implements IJsonModel<ConsumptionCreditSummary>
    // so ApiCompat against the shipped v1.1.0 interface list still passes.
    [Obsolete("This type is obsolete. Use ConsumptionCreditSummaryData instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ConsumptionCreditSummary : ConsumptionCreditSummaryData, IJsonModel<ConsumptionCreditSummary>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ETag? ETag
        {
            get => throw new NotSupportedException("This type is obsolete.");
            set => throw new NotSupportedException("This type is obsolete.");
        }

        void IJsonModel<ConsumptionCreditSummary>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<ConsumptionCreditSummaryData>)this).Write(writer, options);

        ConsumptionCreditSummary IJsonModel<ConsumptionCreditSummary>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete.");

        ConsumptionCreditSummary IPersistableModel<ConsumptionCreditSummary>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete.");

        BinaryData IPersistableModel<ConsumptionCreditSummary>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<ConsumptionCreditSummaryData>)this).Write(options);

        string IPersistableModel<ConsumptionCreditSummary>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<ConsumptionCreditSummaryData>)this).GetFormatFromOptions(options);
    }
}
