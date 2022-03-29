// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// The time range to the left and right of the search span to be used for Interpolation. This is helpful in scenarios where the data points are
    /// missing close to the start or end of the input search span. Can be null.
    /// </summary>
    [CodeGenModel("InterpolationBoundary")]
    public partial class InterpolationBoundary
    {
    }
}
