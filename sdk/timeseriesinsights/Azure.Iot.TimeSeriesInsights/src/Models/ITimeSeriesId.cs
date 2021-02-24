// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.TimeSeriesInsights
{
    /// <summary>
    /// Define Time Series Id specific properties and methods to be implemented by the different implementations of Time Series Id classes.
    /// </summary>
    public interface ITimeSeriesId
    {
        /// <summary>
        /// Builds an array to represent a single Time Series Id in order to use it when making calls against the Time
        /// Series Insights client library.
        /// </summary>
        /// <returns>An array representing a single Time Series Id.</returns>
        object[] ToArray();
    }
}
