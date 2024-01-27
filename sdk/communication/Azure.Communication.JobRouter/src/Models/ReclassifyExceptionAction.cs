// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ReclassifyExceptionAction : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of CancelExceptionAction. </summary>
        public ReclassifyExceptionAction()
        {
            Kind = ExceptionActionKind.Reclassify;
            LabelsToUpsert = new ChangeTrackingDictionary<string, RouterValue>();
        }

        /// <summary>
        /// (optional) Dictionary containing the labels to update (or add if not existing) in key-value pairs. Values must be primitive values - number, string, boolean.
        /// </summary>
        [CodeGenMember("LabelsToUpsert")]
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(WriteLabelsToUpsert), DeserializationValueHook = nameof(ReadLabelsToUpsert))]
        public IDictionary<string, RouterValue> LabelsToUpsert { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteLabelsToUpsert(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            foreach (var item in LabelsToUpsert)
            {
                writer.WritePropertyName(item.Key);
                if (item.Value == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteObjectValue(item.Value.Value);
            }
            writer.WriteEndObject();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadLabelsToUpsert(JsonProperty property, ref Optional<IDictionary<string, RouterValue>> labelsToUpsert)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            Dictionary<string, RouterValue> dictionary = new Dictionary<string, RouterValue>();
            foreach (var property0 in property.Value.EnumerateObject())
            {
                if (property0.Value.ValueKind == JsonValueKind.Null)
                {
                    dictionary.Add(property0.Name, null);
                }
                else
                {
                    dictionary.Add(property0.Name, new RouterValue(property0.Value.GetObject()));
                }
            }
            labelsToUpsert = dictionary;
        }

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
            if (Optional.IsCollectionDefined(LabelsToUpsert))
            {
                writer.WritePropertyName("labelsToUpsert"u8);
                WriteLabelsToUpsert(writer);
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToString());
            writer.WriteEndObject();
        }
    }
}
