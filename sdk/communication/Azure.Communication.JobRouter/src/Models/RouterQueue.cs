// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("RouterQueue")]
    public partial class RouterQueue : IUtf8JsonSerializable
    {
        [CodeGenMember("Labels")]
        internal IDictionary<string, object> _labels
        {
            get
            {
                return Labels != null && Labels.Count != 0
                    ? Labels?.ToDictionary(x => x.Key, x => x.Value?.Value)
                    : new ChangeTrackingDictionary<string, object>();
            }
            set
            {
                if (value != null && value.Count != 0)
                {
                    foreach (var label in value)
                    {
                        Labels[label.Key] = new LabelValue(label.Value);
                    }
                }
            }
        }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions.
        /// </summary>
        public IDictionary<string, LabelValue> Labels { get; } = new Dictionary<string, LabelValue>();

        /// <summary> The name of this queue. </summary>
        public string Name { get; internal set; }

        /// <summary> The ID of the distribution policy that will determine how a job is distributed to workers. </summary>
        public string DistributionPolicyId { get; internal set; }

        /// <summary> (Optional) The ID of the exception policy that determines various job escalation rules. </summary>
        public string ExceptionPolicyId { get; internal set; }

        /// <summary> Initializes a new instance of JobQueue. </summary>
        internal RouterQueue()
        {
            _labels = new ChangeTrackingDictionary<string, object>();
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(DistributionPolicyId))
            {
                writer.WritePropertyName("distributionPolicyId"u8);
                writer.WriteStringValue(DistributionPolicyId);
            }
            if (Optional.IsCollectionDefined(_labels))
            {
                writer.WritePropertyName("labels"u8);
                writer.WriteStartObject();
                foreach (var item in _labels)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(ExceptionPolicyId))
            {
                writer.WritePropertyName("exceptionPolicyId"u8);
                writer.WriteStringValue(ExceptionPolicyId);
            }
            writer.WriteEndObject();
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
