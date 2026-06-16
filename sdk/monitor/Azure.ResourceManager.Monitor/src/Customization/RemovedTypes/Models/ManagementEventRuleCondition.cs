// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> A management event rule condition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class ManagementEventRuleCondition : AlertRuleCondition, IJsonModel<ManagementEventRuleCondition>, IPersistableModel<ManagementEventRuleCondition>
    {
        /// <summary> Initializes a new instance of <see cref="ManagementEventRuleCondition"/>. </summary>
        public ManagementEventRuleCondition()
        {
        }

        /// <summary> The aggregation condition. </summary>
        public ManagementEventAggregationCondition Aggregation { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        ManagementEventRuleCondition IJsonModel<ManagementEventRuleCondition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<ManagementEventRuleCondition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        ManagementEventRuleCondition IPersistableModel<ManagementEventRuleCondition>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<ManagementEventRuleCondition>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<ManagementEventRuleCondition>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}
