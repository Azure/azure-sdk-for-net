// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.AppService.Models
{
    internal static partial class TriggeredWebJobStatusExtensions
    {
        public static string ToSerialString(this TriggeredWebJobStatus value) => value switch
        {
            TriggeredWebJobStatus.Success => "Success",
            TriggeredWebJobStatus.Failed => "Failed",
            TriggeredWebJobStatus.Error => "Error",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TriggeredWebJobStatus value.")
        };

        public static TriggeredWebJobStatus ToTriggeredWebJobStatus(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Success")) return TriggeredWebJobStatus.Success;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Failed")) return TriggeredWebJobStatus.Failed;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Error")) return TriggeredWebJobStatus.Error;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TriggeredWebJobStatus value.");
        }
    }
}
