// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class CancelExceptionAction: IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of CancelExceptionAction. </summary>
        public CancelExceptionAction()
        {
            Kind = "cancel";
        }

        /// <summary>
        /// (Optional) A note that will be appended to the jobs' Notes collection with the
        /// current timestamp.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// (Optional) Indicates the outcome of the job, populate this field with your own
        /// custom values.
        /// </summary>
        public string DispositionCode { get; set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (Optional.IsDefined(Note))
            {
                writer.WritePropertyName("note"u8);
                writer.WriteStringValue(Note);
            }
            if (Optional.IsDefined(DispositionCode))
            {
                writer.WritePropertyName("dispositionCode"u8);
                writer.WriteStringValue(DispositionCode);
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
