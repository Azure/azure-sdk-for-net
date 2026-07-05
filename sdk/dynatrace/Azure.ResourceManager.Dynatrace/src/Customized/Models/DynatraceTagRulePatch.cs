// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Dynatrace.Models
{
    /// <summary> The updatable properties of the TagRule. </summary>
    // This model no longer exists in the swagger, but we keep it for compatibility reasons.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DynatraceTagRulePatch
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DynatraceTagRulePatch"/>. </summary>
        public DynatraceTagRulePatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DynatraceTagRulePatch"/>. </summary>
        /// <param name="logRules"> Set of rules for sending logs for the Monitor resource. </param>
        /// <param name="metricRules"> Set of rules for sending metrics for the Monitor resource. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DynatraceTagRulePatch(DynatraceMonitorResourceLogRules logRules, DynatraceMonitorResourceMetricRules metricRules, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            LogRules = logRules;
            MetricRules = metricRules;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Set of rules for sending logs for the Monitor resource. </summary>
        public DynatraceMonitorResourceLogRules LogRules { get; set; }
        /// <summary> Set of rules for sending metrics for the Monitor resource. </summary>
        internal DynatraceMonitorResourceMetricRules MetricRules { get; set; }
        /// <summary> List of filtering tags to be used for capturing metrics. If empty, all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules will only include resources with the associated tags. </summary>
        public IList<DynatraceMonitorResourceFilteringTag> MetricRulesFilteringTags
        {
            get
            {
                if (MetricRules is null)
                    MetricRules = new DynatraceMonitorResourceMetricRules();
                return MetricRules.FilteringTags;
            }
        }
    }
}
