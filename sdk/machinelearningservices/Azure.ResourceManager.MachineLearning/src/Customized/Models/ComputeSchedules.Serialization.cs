// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("ComputeSchedules")]
namespace Azure.ResourceManager.MachineLearning.Models
{
    internal partial class ComputeSchedules
    {
        internal static ComputeSchedules DeserializeComputeSchedules(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<MachineLearningComputeStartStopSchedule>> computeStartStop = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("computeStartStop"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MachineLearningComputeStartStopSchedule> array = new List<MachineLearningComputeStartStopSchedule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MachineLearningComputeStartStopSchedule.DeserializeMachineLearningComputeStartStopSchedule(item));
                    }
                    computeStartStop = array;
                    continue;
                }
            }
            return new ComputeSchedules(Optional.ToList(computeStartStop));
        }
    }
}
