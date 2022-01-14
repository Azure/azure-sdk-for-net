// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Monitor.Query.Models
{
    public partial class MetricValue
    {
        private string _toString;

        /// <summary> Initializes a new instance of MetricValue. </summary>
        /// <param name="timeStamp"> the timestamp for the metric value in ISO 8601 format. </param>
        /// <param name="average"> the average value in the time range. </param>
        /// <param name="minimum"> the least value in the time range. </param>
        /// <param name="maximum"> the greatest value in the time range. </param>
        /// <param name="total"> the sum of all of the values in the time range. </param>
        /// <param name="count"> the number of samples in the time range. Can be used to determine the number of values that contributed to the average value. </param>
        public MetricValue(DateTimeOffset timeStamp, double? average, double? minimum, double? maximum, double? total, double? count)
        {
            TimeStamp = timeStamp;
            Average = average;
            Minimum = minimum;
            Maximum = maximum;
            Total = total;
            Count = count;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (_toString != null) return _toString;

            var builder = new StringBuilder();
            builder.Append($"{nameof(TimeStamp)}: {TimeStamp} ");
            if (Average != null)
            {
                builder.Append($"{nameof(Average)}: {Average} ");
            }
            if (Minimum != null)
            {
                builder.Append($"{nameof(Minimum)}: {Minimum} ");
            }
            if (Maximum != null)
            {
                builder.Append($"{nameof(Maximum)}: {Maximum} ");
            }
            if (Total != null)
            {
                builder.Append($"{nameof(Total)}: {Total} ");
            }
            if (Count != null)
            {
                builder.Append($"{nameof(Count)}: {Count} ");
            }

            return _toString = builder.ToString();
        }
    }
}
