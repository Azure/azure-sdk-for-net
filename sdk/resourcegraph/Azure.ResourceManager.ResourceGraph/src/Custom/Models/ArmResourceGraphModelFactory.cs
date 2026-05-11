// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.ResourceGraph.Models
{
    // Backward compatibility: add ModelFactory methods for preview API custom types.
    public static partial class ArmResourceGraphModelFactory
    {
        /// <summary> An interval in time specifying the date and time for the inclusive start and exclusive end. </summary>
        /// <param name="startOn"> The inclusive/closed start of the time interval. </param>
        /// <param name="endOn"> The exclusive/open end of the time interval. </param>
        /// <returns> A new <see cref="Models.DateTimeInterval"/> instance for mocking. </returns>
        public static DateTimeInterval DateTimeInterval(DateTimeOffset startOn = default, DateTimeOffset endOn = default)
        {
            return new DateTimeInterval(startOn, endOn);
        }

        /// <summary> The options for history request evaluation. </summary>
        /// <param name="interval"> The time interval used to fetch history. </param>
        /// <param name="top"> The maximum number of rows that the query should return. </param>
        /// <param name="skip"> The number of rows to skip from the beginning of the results. </param>
        /// <param name="skipToken"> Continuation token for pagination. </param>
        /// <param name="resultFormat"> Defines in which format query result returned. </param>
        /// <returns> A new <see cref="Models.ResourcesHistoryRequestOptions"/> instance for mocking. </returns>
        public static ResourcesHistoryRequestOptions ResourcesHistoryRequestOptions(DateTimeInterval interval = null, int? top = default, int? skip = default, string skipToken = null, ResultFormat? resultFormat = default)
        {
            return new ResourcesHistoryRequestOptions(interval, top, skip, skipToken, resultFormat, serializedAdditionalRawData: null);
        }
    }
}
