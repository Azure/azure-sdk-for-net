// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Property of an event that is either stored or computed. Properties are identified by both name and type. Different events can have properties
    /// with same name, but different type.
    /// </summary>
    [CodeGenModel("EventProperty")]
    public partial class TimeSeriesInsightsEventProperty
    {
        /// <summary>
        /// The type of the property.
        /// </summary>
        [CodeGenMember("Type")]
        public TimeSeriesPropertyType? PropertyValueType { get; set; }
    }
}
