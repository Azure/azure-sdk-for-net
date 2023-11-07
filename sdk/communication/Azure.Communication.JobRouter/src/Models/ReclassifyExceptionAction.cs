// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ReclassifyExceptionAction : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of CancelExceptionAction. </summary>
        public ReclassifyExceptionAction()
        {
            Kind = "reclassify";
            _labelsToUpsert = new ChangeTrackingDictionary<string, BinaryData>();
        }

        [CodeGenMember("LabelsToUpsert")]
        internal IDictionary<string, BinaryData> _labelsToUpsert
        {
            get
            {
                return LabelsToUpsert != null && LabelsToUpsert.Count != 0
                    ? LabelsToUpsert?.ToDictionary(x => x.Key, x => BinaryData.FromObjectAsJson(x.Value?.Value))
                    : new ChangeTrackingDictionary<string, BinaryData>();
            }
            set
            {
                if (value != null && value.Count != 0)
                {
                    foreach (var label in value)
                    {
                        LabelsToUpsert[label.Key] = new RouterValue(label.Value.ToObjectFromJson());
                    }
                }
            }
        }

        /// <summary>
        /// (optional) Dictionary containing the labels to update (or add if not existing) in key-value pairs
        /// </summary>
        public IDictionary<string, RouterValue> LabelsToUpsert { get; } = new Dictionary<string, RouterValue>();

        /// <summary>
        /// (optional) The new classification policy that will determine queue, priority
        /// and worker selectors.
        /// </summary>
        public string ClassificationPolicyId { get; set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(ClassificationPolicyId))
            {
                writer.WritePropertyName("classificationPolicyId"u8);
                writer.WriteStringValue(ClassificationPolicyId);
            }
            if (Optional.IsCollectionDefined(_labelsToUpsert))
            {
                writer.WritePropertyName("labelsToUpsert"u8);
                writer.WriteStartObject();
                foreach (var item in _labelsToUpsert)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteObjectValue(item.Value.ToObjectFromJson());
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
