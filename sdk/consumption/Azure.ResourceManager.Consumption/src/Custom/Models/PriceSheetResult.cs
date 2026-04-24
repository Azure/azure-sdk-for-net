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
    // This type was renamed to PriceSheetResultData and moved to the root namespace.
    // Stub retained for backward compatibility; explicitly implements IJsonModel<PriceSheetResult>
    // so ApiCompat against the shipped v1.1.0 interface list still passes.
    [Obsolete("This type is obsolete. Use PriceSheetResultData instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PriceSheetResult : PriceSheetResultData, IJsonModel<PriceSheetResult>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ETag? ETag
        {
            get => throw new NotSupportedException("This type is obsolete.");
        }

        void IJsonModel<PriceSheetResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<PriceSheetResultData>)this).Write(writer, options);

        PriceSheetResult IJsonModel<PriceSheetResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete.");

        PriceSheetResult IPersistableModel<PriceSheetResult>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete.");

        BinaryData IPersistableModel<PriceSheetResult>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<PriceSheetResultData>)this).Write(options);

        string IPersistableModel<PriceSheetResult>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<PriceSheetResultData>)this).GetFormatFromOptions(options);
    }
}
