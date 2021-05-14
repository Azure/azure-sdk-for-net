// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    /// <summary> the unit of the metric. </summary>
    [CodeGenModel("Unit")]
    public enum MetricUnit
    {
        /// <summary> Count. </summary>
        Count,
        /// <summary> Bytes. </summary>
        Bytes,
        /// <summary> Seconds. </summary>
        Seconds,
        /// <summary> CountPerSecond. </summary>
        CountPerSecond,
        /// <summary> BytesPerSecond. </summary>
        BytesPerSecond,
        /// <summary> Percent. </summary>
        Percent,
        /// <summary> MilliSeconds. </summary>
        MilliSeconds,
        /// <summary> ByteSeconds. </summary>
        ByteSeconds,
        /// <summary> Unspecified. </summary>
        Unspecified,
        /// <summary> Cores. </summary>
        Cores,
        /// <summary> MilliCores. </summary>
        MilliCores,
        /// <summary> NanoCores. </summary>
        NanoCores,
        /// <summary> BitsPerSecond. </summary>
        BitsPerSecond
    }
}