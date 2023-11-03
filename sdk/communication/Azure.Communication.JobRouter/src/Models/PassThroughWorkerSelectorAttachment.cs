// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class PassThroughWorkerSelectorAttachment : IUtf8JsonSerializable
    {
        /// <summary> Describes how the value of the label is compared to the value pass through. </summary>
        public LabelOperator LabelOperator { get; internal set; }

        /// <summary> Describes how long the attached label selector is valid in seconds. </summary>
        public TimeSpan? ExpiresAfter { get; internal set; }

        [CodeGenMember("ExpiresAfterSeconds")]
        internal double? _expiresAfterSeconds
        {
            get
            {
                return ExpiresAfter?.TotalSeconds is null or 0 ? null : ExpiresAfter?.TotalSeconds;
            }
            set
            {
                ExpiresAfter = value != null ? TimeSpan.FromSeconds(value.Value) : null;
            }
        }

        /// <summary> Initializes a new instance of PassThroughWorkerSelectorAttachment. </summary>
        /// <param name="key"> The label key to query against. </param>
        /// <param name="labelOperator"> Describes how the value of the label is compared to the value pass through. </param>
        /// <param name="expiresAfter"> Describes how long the attached label selector is valid. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public PassThroughWorkerSelectorAttachment(string key, LabelOperator labelOperator, TimeSpan? expiresAfter = default)
            : this("pass-through", key, labelOperator, expiresAfter?.TotalSeconds)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("key"u8);
            writer.WriteStringValue(Key);
            writer.WritePropertyName("labelOperator"u8);
            writer.WriteStringValue(LabelOperator.ToString());
            if (Optional.IsDefined(_expiresAfterSeconds))
            {
                writer.WritePropertyName("expiresAfterSeconds"u8);
                writer.WriteNumberValue(_expiresAfterSeconds.Value);
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
