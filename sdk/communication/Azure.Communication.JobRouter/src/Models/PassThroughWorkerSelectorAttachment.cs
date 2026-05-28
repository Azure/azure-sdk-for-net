// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenSerialization(nameof(ExpiresAfter), SerializationValueHook = nameof(WriteExpiresAfter), DeserializationValueHook = nameof(ReadExpiresAfter))]
    public partial class PassThroughWorkerSelectorAttachment
    {
        /// <summary> Describes how the value of the label is compared to the value passed through. </summary>
        public LabelOperator LabelOperator { get; }

        /// <summary> Describes how long the attached worker selector is valid. </summary>
        [CodeGenMember("ExpiresAfterSeconds")]
        public TimeSpan? ExpiresAfter { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteExpiresAfter(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteNumberValue(ExpiresAfter.Value.TotalSeconds);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadExpiresAfter(JsonProperty property, ref TimeSpan? expiresAfter)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            var value = property.Value.GetDouble();
            expiresAfter = TimeSpan.FromSeconds(value);
        }

        /// <summary> Initializes a new instance of PassThroughWorkerSelectorAttachment. </summary>
        /// <param name="key"> The label key to query against. </param>
        /// <param name="labelOperator"> Describes how the value of the label is compared to the value passed through. </param>
        /// <param name="expiresAfter"> Describes how long the attached worker selector is valid. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public PassThroughWorkerSelectorAttachment(string key, LabelOperator labelOperator, TimeSpan? expiresAfter = default)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));

            Kind = WorkerSelectorAttachmentKind.PassThrough;
            Key = key;
            LabelOperator = labelOperator;
            ExpiresAfter = expiresAfter;
        }
    }
}
