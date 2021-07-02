// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    public partial class Metric
    {
        private const string SuccessErrorCode = "Success";

        [CodeGenMember("Name")]
        private LocalizableString LocalizedName { get; }

        /// <summary> &apos;Success&apos; or the error details on query failures for this metric. </summary>
        private string ErrorCode { get; }
        /// <summary> Error message encountered querying this specific metric. </summary>
        private string ErrorMessage { get; }

        /// <summary> The name of the metric. </summary>
        public string Name => LocalizedName.Value;

        /// <summary> The time series returned when a data query is performed. </summary>
        [CodeGenMember("Timeseries")]
        public IReadOnlyList<TimeSeriesElement> TimeSeries { get; }

        /// <summary>
        /// Gets the error that occurred while querying the metric.
        /// </summary>
        public ResponseError Error => ErrorCode == SuccessErrorCode ? null : new ResponseError(ErrorCode, ErrorMessage, null, null, null);
    }
}
