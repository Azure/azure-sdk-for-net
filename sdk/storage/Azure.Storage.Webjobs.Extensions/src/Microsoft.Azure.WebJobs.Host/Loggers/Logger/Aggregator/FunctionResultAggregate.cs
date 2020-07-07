// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Azure.WebJobs.Logging
{
    internal class FunctionResultAggregate
    {
        public string Name { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public TimeSpan AverageDuration { get; set; }
        public TimeSpan MaxDuration { get; set; }
        public TimeSpan MinDuration { get; set; }
        public int Successes { get; set; }
        public int Failures { get; set; }
        public int Count => Successes + Failures;
        public double SuccessRate => Math.Round((Successes / (double)Count) * 100, 2);

        public IReadOnlyDictionary<string, object> ToReadOnlyDictionary()
        {
            return new ReadOnlyDictionary<string, object>(new Dictionary<string, object>
            {
                [LogConstants.NameKey] = Name,
                [LogConstants.CountKey] = Count,
                [LogConstants.TimestampKey] = Timestamp,
                [LogConstants.AverageDurationKey] = AverageDuration,
                [LogConstants.MaxDurationKey] = MaxDuration,
                [LogConstants.MinDurationKey] = MinDuration,
                [LogConstants.SuccessesKey] = Successes,
                [LogConstants.FailuresKey] = Failures,
                [LogConstants.SuccessRateKey] = SuccessRate
            });
        }
    }
}
