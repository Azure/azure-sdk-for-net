// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class WorkerWeightedAllocation : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of WorkerWeightedAllocation. </summary>
        /// <param name="weight"> The percentage of this weight, expressed as a fraction of 1. </param>
        /// <param name="workerSelectors">
        /// A collection of worker selectors that will be applied if this allocation is
        /// selected.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerSelectors"/> is null. </exception>
        public WorkerWeightedAllocation(double weight, IEnumerable<RouterWorkerSelector> workerSelectors)
        {
            Argument.AssertNotNull(workerSelectors, nameof(workerSelectors));

            Weight = weight;
            WorkerSelectors = workerSelectors.ToList();
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("weight"u8);
            writer.WriteNumberValue(Weight);
            writer.WritePropertyName("workerSelectors"u8);
            writer.WriteStartArray();
            foreach (var item in WorkerSelectors)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
