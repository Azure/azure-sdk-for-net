// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class StaticWorkerSelectorAttachment : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of StaticWorkerSelectorAttachment. </summary>
        /// <param name="workerSelector">
        /// Describes a condition that must be met against a set of labels for worker
        /// selection
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerSelector"/> is null. </exception>
        public StaticWorkerSelectorAttachment(RouterWorkerSelector workerSelector)
        {
            Argument.AssertNotNull(workerSelector, nameof(workerSelector));

            Kind = "static";
            WorkerSelector = workerSelector;
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("workerSelector"u8);
            writer.WriteObjectValue(WorkerSelector);
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
