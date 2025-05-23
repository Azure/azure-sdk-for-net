// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering
{
    internal static class FilterInfoPredicateUtility
    {
        public static Predicate? ToPredicate(PredicateType? filterInfoPredicate)
        {
            if (filterInfoPredicate == null)
            {
                return null;
            }

            if (!Enum.TryParse<Predicate>(filterInfoPredicate.ToString(), out Predicate predicate))
            {
                throw new ArgumentOutOfRangeException(nameof(filterInfoPredicate), $"Unknown predicate value '{filterInfoPredicate}'");
            }
            return predicate;
        }
    }
}
