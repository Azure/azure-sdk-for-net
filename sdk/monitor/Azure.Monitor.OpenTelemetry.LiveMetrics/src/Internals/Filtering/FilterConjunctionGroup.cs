// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

    /// <summary>
    /// Defines an AND group of filters.
    /// </summary>
    internal class FilterConjunctionGroup<TTelemetry>
    {
        private readonly FilterConjunctionGroupInfo info;

        private readonly List<Filter<TTelemetry>> filters = new List<Filter<TTelemetry>>();

        public FilterConjunctionGroup(FilterConjunctionGroupInfo info, out CollectionConfigurationError[] errors)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.info = info;

            this.CreateFilters(out errors);
        }

        public bool CheckFilters(TTelemetry document, out CollectionConfigurationError[] errors)
        {
            var errorList = new List<CollectionConfigurationError>(this.filters.Count);

            foreach (Filter<TTelemetry> filter in this.filters)
            {
                bool filterPassed;
                try
                {
                    filterPassed = filter.Check(document);
                }
                catch (System.Exception)
                {
                    // the filter has failed to run (possibly incompatible field value in telemetry), consider the telemetry item filtered out by this conjunction group
                    ////!!!
                    ////errorList.Add(
                    ////    CollectionConfigurationError.CreateError(
                    ////        CollectionConfigurationErrorType.FilterFailureToRun,
                    ////        string.Format(CultureInfo.InvariantCulture, "Failter failed to run: {0}.", filter),
                    ////        e));
                    filterPassed = false;
                }

                if (!filterPassed)
                {
                    errors = errorList.ToArray();
                    return false;
                }
            }

            errors = errorList.ToArray();
            return true;
        }

        private void CreateFilters(out CollectionConfigurationError[] errors)
        {
            var errorList = new List<CollectionConfigurationError>();
            foreach (FilterInfo filterInfo in this.info.Filters)
            {
                try
                {
                    var filter = new Filter<TTelemetry>(filterInfo);
                    this.filters.Add(filter);
                }
                catch (System.Exception e)
                {
                    errorList.Add(
                        CollectionConfigurationError.CreateError(
                            CollectionConfigurationErrorType.FilterFailureToCreateUnexpected,
                            string.Format(CultureInfo.InvariantCulture, "Failed to create a filter {0}.", filterInfo),
                            e,
                            Tuple.Create("FilterFieldName", filterInfo.FieldName),
                            Tuple.Create("FilterPredicate", filterInfo.Predicate.ToString()),
                            Tuple.Create("FilterComparand", filterInfo.Comparand)));
                }
            }

            errors = errorList.ToArray();
        }
    }
}
