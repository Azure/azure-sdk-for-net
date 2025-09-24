// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class ExecutionTriggerTypeExtensions
    {
        public static string ToSerialString(this ExecutionTriggerType value) => value switch
        {
            ExecutionTriggerType.RunOnce => "RunOnce",
            ExecutionTriggerType.OnSchedule => "OnSchedule",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ExecutionTriggerType value.")
        };

        public static ExecutionTriggerType ToExecutionTriggerType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "RunOnce")) return ExecutionTriggerType.RunOnce;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "OnSchedule")) return ExecutionTriggerType.OnSchedule;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ExecutionTriggerType value.");
        }
    }
}
