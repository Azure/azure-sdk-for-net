// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Monitor.Models
{
    // TypeSpec no longer models the legacy AlertRule condition hierarchy.
    // Keep this obsolete derived type so the stable AlertRuleCondition polymorphic API remains loadable.
    /// <summary> A rule condition based on a certain number of locations failing. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class LocationThresholdRuleCondition : AlertRuleCondition, IJsonModel<LocationThresholdRuleCondition>, IPersistableModel<LocationThresholdRuleCondition>
    {
        /// <summary> Initializes a new instance of <see cref="LocationThresholdRuleCondition"/>. </summary>
        /// <param name="failedLocationCount"> The number of locations that must fail to activate the alert. </param>
        public LocationThresholdRuleCondition(int failedLocationCount)
        {
            FailedLocationCount = failedLocationCount;
        }

        /// <summary> The number of locations that must fail to activate the alert. </summary>
        public int FailedLocationCount { get; set; }

        /// <summary> The time window over which to evaluate the condition. </summary>
        public TimeSpan? WindowSize { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        LocationThresholdRuleCondition IJsonModel<LocationThresholdRuleCondition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<LocationThresholdRuleCondition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        LocationThresholdRuleCondition IPersistableModel<LocationThresholdRuleCondition>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<LocationThresholdRuleCondition>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<LocationThresholdRuleCondition>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}
