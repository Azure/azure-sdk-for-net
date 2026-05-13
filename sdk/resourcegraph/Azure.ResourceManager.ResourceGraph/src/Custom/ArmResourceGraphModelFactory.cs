// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ResourceGraph.Models
{
    public static partial class ArmResourceGraphModelFactory
    {
        // Backward compatibility: The DateTimeInterval type was part of the ResourcesHistory preview API
        // (api-version 2021-06-01-preview), which is not included in the stable TypeSpec definition.
        // However, it was publicly exposed in the GA SDK (1.1.0) via the ArmResourceGraphModelFactory.
        // Since the TypeSpec-based generator no longer produces this type, we must retain this factory
        // method manually to avoid a breaking change (ApiCompat: CP0002 - member must exist).
        // Hidden with [EditorBrowsable(Never)] because the underlying ResourcesHistory API is preview-only
        // and callers should not take new dependencies on it.
        /// <summary> An interval in time specifying the date and time for the inclusive start and exclusive end. </summary>
        /// <param name="startOn"> The inclusive/closed start of the time interval. </param>
        /// <param name="endOn"> The exclusive/open end of the time interval. </param>
        /// <returns> A new <see cref="Models.DateTimeInterval"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DateTimeInterval DateTimeInterval(DateTimeOffset startOn = default, DateTimeOffset endOn = default)
        {
            return new DateTimeInterval(startOn, endOn);
        }

        // Backward compatibility: The ResourcesHistoryRequestOptions type was part of the ResourcesHistory
        // preview API (api-version 2021-06-01-preview), which is not included in the stable TypeSpec definition.
        // It was publicly exposed in the GA SDK (1.1.0) via the ArmResourceGraphModelFactory.
        // Since the TypeSpec-based generator no longer produces this type, we must retain this factory
        // method manually to avoid a breaking change (ApiCompat: CP0002 - member must exist).
        // Hidden with [EditorBrowsable(Never)] because the underlying ResourcesHistory API is preview-only
        // and callers should not take new dependencies on it.
        /// <summary> The options for history request evaluation. </summary>
        /// <param name="interval"> The time interval used to fetch history. </param>
        /// <param name="top"> The maximum number of rows that the query should return. </param>
        /// <param name="skip"> The number of rows to skip from the beginning of the results. </param>
        /// <param name="skipToken"> Continuation token for pagination. </param>
        /// <param name="resultFormat"> Defines in which format query result returned. </param>
        /// <returns> A new <see cref="Models.ResourcesHistoryRequestOptions"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourcesHistoryRequestOptions ResourcesHistoryRequestOptions(DateTimeInterval interval = null, int? top = default, int? skip = default, string skipToken = null, ResultFormat? resultFormat = default)
        {
            return new ResourcesHistoryRequestOptions(interval, top, skip, skipToken, resultFormat, serializedAdditionalRawData: null);
        }
    }
}
