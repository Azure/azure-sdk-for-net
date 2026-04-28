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
    // This type was renamed to PriceSheetResultData and moved to the root namespace.
    // Stub retained for backward compatibility; explicitly implements IJsonModel<PriceSheetResult>
    // so ApiCompat against the shipped v1.1.0 interface list still passes.
    [Obsolete("This type is obsolete. Use PriceSheetResultData instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PriceSheetResult : ResourceData, IJsonModel<PriceSheetResult>
    {
        /// <summary> Initializes a new instance of <see cref="PriceSheetResult"/>. </summary>
        internal PriceSheetResult()
        {
            throw new NotSupportedException("This type is obsolete.");
        }

        /// <summary> Initializes a new instance of <see cref="PriceSheetResult"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="pricesheets"> Price sheet. </param>
        /// <param name="nextLink"> The link (url) to the next page of results. </param>
        /// <param name="download"> Pricesheet download details. </param>
        /// <param name="etag"> The etag for the resource. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PriceSheetResult(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IReadOnlyList<PriceSheetProperties> pricesheets, string nextLink, ConsumptionMeterDetails download, ETag? etag, IReadOnlyDictionary<string, string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            throw new NotSupportedException("This type is obsolete.");
        }

        /// <summary> Price sheet. </summary>
        public IReadOnlyList<PriceSheetProperties> Pricesheets { get; }
        /// <summary> The link (url) to the next page of results. </summary>
        public string NextLink { get; }
        /// <summary> Pricesheet download details. </summary>
        public ConsumptionMeterDetails Download { get; }
        /// <summary> The etag for the resource. </summary>
        public ETag? ETag { get; }
        /// <summary> Resource tags. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }

        // All IJsonModel/IPersistableModel members throw because this type is obsolete and cannot be
        // constructed (every ctor throws). The previous implementation cast `this` to
        // IJsonModel<PriceSheetResultData>, which would have thrown InvalidCastException
        // because this type does not implement that interface.
        void IJsonModel<PriceSheetResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use PriceSheetResultData instead.");

        PriceSheetResult IJsonModel<PriceSheetResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use PriceSheetResultData instead.");

        PriceSheetResult IPersistableModel<PriceSheetResult>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use PriceSheetResultData instead.");

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use PriceSheetResultData instead.");

        BinaryData IPersistableModel<PriceSheetResult>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use PriceSheetResultData instead.");

        string IPersistableModel<PriceSheetResult>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => throw new NotSupportedException("This type is obsolete. Use PriceSheetResultData instead.");
    }
}
