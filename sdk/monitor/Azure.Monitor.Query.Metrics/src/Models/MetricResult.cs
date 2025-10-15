// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.Query.Metrics.Models
{
    public partial class MetricResult
    {
        private const string SuccessErrorCode = "Success";
        private ResponseError _error;

        /// <summary> The name of the metric. </summary>
        public string Name => LocalizedName.Value;

        /// <summary> The name and the display name of the metric, i.e. it is localizable string. </summary>
        internal LocalizableString LocalizedName { get; }

        /// <summary> 'Success' or the error details on query failures for this metric. </summary>
        internal string ErrorCode { get; }

        /// <summary> Error message encountered querying this specific metric. </summary>
        internal string ErrorMessage { get; }

        /// <summary>
        /// Gets the error that occurred while querying the metric.
        /// </summary>
        public ResponseError Error => ErrorCode == SuccessErrorCode ? null : _error ??= new ResponseError(ErrorCode, ErrorMessage);
    }
}
