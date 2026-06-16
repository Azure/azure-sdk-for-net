// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> The alert rule data source. </summary>
    [PersistableModelProxy(typeof(UnknownRuleDataSource))]
    [Obsolete("This API is no longer supported.", false)]
    public abstract partial class RuleDataSource : IJsonModel<RuleDataSource>, IPersistableModel<RuleDataSource>
    {
        /// <summary> Initializes a new instance of <see cref="RuleDataSource"/>. </summary>
        protected RuleDataSource()
        {
        }

        /// <summary> The legacy resource id. </summary>
        public ResourceIdentifier LegacyResourceId { get; set; }

        /// <summary> The metric namespace. </summary>
        public string MetricNamespace { get; set; }

        /// <summary> The resource id. </summary>
        public ResourceIdentifier ResourceId { get; set; }

        /// <summary> The resource location. </summary>
        public string ResourceLocation { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<RuleDataSource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        RuleDataSource IJsonModel<RuleDataSource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<RuleDataSource>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        RuleDataSource IPersistableModel<RuleDataSource>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<RuleDataSource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
