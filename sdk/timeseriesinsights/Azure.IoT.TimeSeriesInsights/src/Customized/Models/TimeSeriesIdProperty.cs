// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// A definition of a single property that can be used in time series ID properties defined during environment creation.
    /// </summary>
    [CodeGenModel("TimeSeriesIdProperty")]
    public partial class TimeSeriesIdProperty
    {
        // This class declaration changes the class name and property name; do not remove.

        /// <summary> Initializes a new instance of TimeSeriesIdProperty. </summary>
        /// <param name="name"> The name of the property. </param>
        /// <param name="type"> The type of the property. Currently, only &quot;String&quot; is supported. </param>
        internal TimeSeriesIdProperty(string name, TimeSeriesIdPropertyType? type)
        {
            Name = name;
            PropertyType = type;
        }

        /// <summary> The type of the property. Currently, only &quot;String&quot; is supported. </summary>
        [CodeGenMember("PropertyType")]
        public TimeSeriesIdPropertyType? PropertyType { get; }
    }
}
