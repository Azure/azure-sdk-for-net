// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Consumption.Models
{
    // This type was renamed to PriceSheetResultData and moved to the root namespace.
    // Stub retained for source/binary-compatibility with the shipped v1.1.0 surface only;
    // every member throws NotSupportedException at runtime. The serialization interfaces
    // are declared (as in v1.1.0) but no longer have a real implementation - they are part
    // of the v1.1.0 public surface and are required by ApiCompat to remain on the type.
    /// <summary> Obsolete. Use <see cref="PriceSheetResultData"/> instead. </summary>
    [Obsolete("This type is obsolete. Use PriceSheetResultData instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PriceSheetResult : ResourceData, IJsonModel<PriceSheetResult>, IPersistableModel<PriceSheetResult>
    {
        private const string ObsoleteMessage = "This type is obsolete. Use PriceSheetResultData instead.";

        /// <summary> Initializes a new instance of <see cref="PriceSheetResult"/>. </summary>
        internal PriceSheetResult()
        {
            throw new NotSupportedException(ObsoleteMessage);
        }

        /// <summary> Price sheet. </summary>
        public IReadOnlyList<PriceSheetProperties> Pricesheets => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> The link (url) to the next page of results. </summary>
        public string NextLink => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> Pricesheet download details. </summary>
        public ConsumptionMeterDetails Download => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> The etag for the resource. </summary>
        public ETag? ETag => throw new NotSupportedException(ObsoleteMessage);
        /// <summary> Resource tags. </summary>
        public IReadOnlyDictionary<string, string> Tags => throw new NotSupportedException(ObsoleteMessage);

        PriceSheetResult IJsonModel<PriceSheetResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException(ObsoleteMessage);
        void IJsonModel<PriceSheetResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException(ObsoleteMessage);
        PriceSheetResult IPersistableModel<PriceSheetResult>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException(ObsoleteMessage);
        string IPersistableModel<PriceSheetResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw new NotSupportedException(ObsoleteMessage);
        BinaryData IPersistableModel<PriceSheetResult>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException(ObsoleteMessage);
    }
}
