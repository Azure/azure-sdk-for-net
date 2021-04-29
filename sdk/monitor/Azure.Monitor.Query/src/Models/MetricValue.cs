// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.Monitor.Query.Models
{
    public partial class MetricValue
    {
        public override string ToString()
        {
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

            return builder.ToString();
        }
    }
}