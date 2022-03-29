// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Monitor.Query.Models
{
    public partial class MetricValue
    {
        private string _toString;

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
