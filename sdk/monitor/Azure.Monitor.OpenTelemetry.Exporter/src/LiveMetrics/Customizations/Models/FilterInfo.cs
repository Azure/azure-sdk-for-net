// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Models
{
    internal partial class FilterInfo
    {
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} {1} {2}", this.FieldName, this.Predicate, this.Comparand);
        }
    }
}
