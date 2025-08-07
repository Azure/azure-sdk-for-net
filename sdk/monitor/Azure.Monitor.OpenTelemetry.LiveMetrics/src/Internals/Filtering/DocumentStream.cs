// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Diagnostics.CodeAnalysis;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
    using ExceptionDocument = Models.Exception;

    /// <summary>
    /// Represents a concept of a uniquely identifiable set of full telemetry documents that are being reported by the SDK.
    /// The notion of a stream is needed since multiple UX sessions might be querying for full telemetry documents with
    /// different filtering criteria simultaneously.
    /// </summary>
    internal class DocumentStream
    {
        private const float DefaultMaxTelemetryQuota = 30f;

        private const float InitialTelemetryQuota = 3f;

        private readonly DocumentStreamInfo info;

        private readonly List<FilterConjunctionGroup<Request>> requestFilterGroups = new List<FilterConjunctionGroup<Request>>();

        private readonly List<FilterConjunctionGroup<RemoteDependency>> dependencyFilterGroups = new List<FilterConjunctionGroup<RemoteDependency>>();

        private readonly List<FilterConjunctionGroup<ExceptionDocument>> exceptionFilterGroups = new List<FilterConjunctionGroup<ExceptionDocument>>();

        private readonly List<FilterConjunctionGroup<Trace>> traceFilterGroups = new List<FilterConjunctionGroup<Trace>>();

        public DocumentStream(
            DocumentStreamInfo info,
            out CollectionConfigurationError[] errors,
            float? initialRequestQuota = null,
            float? initialDependencyQuota = null,
            float? initialExceptionQuota = null,
            float? initialEventQuota = null,
            float? initialTraceQuota = null,
            float? maxRequestQuota = null,
            float? maxDependencyQuota = null,
            float? maxExceptionQuota = null,
            float? maxEventQuota = null,
            float? maxTraceQuota = null,
            float? quotaAccrualRatePerSec = null)
        {
            this.info = info ?? throw new ArgumentNullException(nameof(info));

            CreateFilters(out errors);

            RequestQuotaTracker = new QuickPulseQuotaTracker(maxRequestQuota ?? DefaultMaxTelemetryQuota, initialRequestQuota ?? InitialTelemetryQuota, quotaAccrualRatePerSec);
            DependencyQuotaTracker = new QuickPulseQuotaTracker(maxDependencyQuota ?? DefaultMaxTelemetryQuota, initialDependencyQuota ?? InitialTelemetryQuota, quotaAccrualRatePerSec);
            ExceptionQuotaTracker = new QuickPulseQuotaTracker(maxExceptionQuota ?? DefaultMaxTelemetryQuota, initialExceptionQuota ?? InitialTelemetryQuota, quotaAccrualRatePerSec);
            EventQuotaTracker = new QuickPulseQuotaTracker(maxEventQuota ?? DefaultMaxTelemetryQuota, initialEventQuota ?? InitialTelemetryQuota, quotaAccrualRatePerSec);
            TraceQuotaTracker = new QuickPulseQuotaTracker(maxTraceQuota ?? DefaultMaxTelemetryQuota, initialTraceQuota ?? InitialTelemetryQuota, quotaAccrualRatePerSec);
        }

        public QuickPulseQuotaTracker RequestQuotaTracker { get; }

        public QuickPulseQuotaTracker DependencyQuotaTracker { get; }

        public QuickPulseQuotaTracker ExceptionQuotaTracker { get; }

        public QuickPulseQuotaTracker EventQuotaTracker { get; }

        public QuickPulseQuotaTracker TraceQuotaTracker { get; }

        public string Id => info.Id;

        public bool CheckFilters(Request document, out CollectionConfigurationError[] errors)
        {
            return CheckFilters(requestFilterGroups, document, out errors);
        }

        public bool CheckFilters(RemoteDependency document, out CollectionConfigurationError[] errors)
        {
            return CheckFilters(dependencyFilterGroups, document, out errors);
        }

        public bool CheckFilters(ExceptionDocument document, out CollectionConfigurationError[] errors)
        {
            return CheckFilters(exceptionFilterGroups, document, out errors);
        }

        public bool CheckFilters(Trace document, out CollectionConfigurationError[] errors)
        {
            return CheckFilters(traceFilterGroups, document, out errors);
        }

        private static bool CheckFilters<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] TTelemetry>(
            List<FilterConjunctionGroup<TTelemetry>> filterGroups,
            TTelemetry document,
            out CollectionConfigurationError[] errors)
            where TTelemetry : DocumentIngress
        {
            var errorList = new List<CollectionConfigurationError>();
            bool leastOneConjunctionGroupPassed = false;

            if (filterGroups.Count == 0)
            {
                errors = Array.Empty<CollectionConfigurationError>();

                // no filters for the telemetry type - filter out, we're not interested
                return false;
            }

            // iterate over filter groups (filters within each group are evaluated as AND, the groups are evaluated as OR)
            foreach (FilterConjunctionGroup<TTelemetry> conjunctionFilterGroup in filterGroups)
            {
                if (CheckFiltersGeneric(document, conjunctionFilterGroup, errorList))
                {
                    // no need to check remaining groups, one OR-connected group has passed
                    leastOneConjunctionGroupPassed = true;
                    break;
                }
            }

            errors = errorList.ToArray();

            return leastOneConjunctionGroupPassed;
        }

        private static bool CheckFiltersGeneric<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] TTelemetry>(
            TTelemetry document,
            FilterConjunctionGroup<TTelemetry> filterGroup,
            List<CollectionConfigurationError> errorList)
            where TTelemetry : DocumentIngress
        {
            bool filterPassed = false;

            try
            {
                if (filterGroup.CheckFilters(document, out CollectionConfigurationError[] groupErrors))
                {
                    errorList.AddRange(groupErrors);
                    filterPassed = true;
                }
            }
            catch (System.Exception)
            {
                // the filters have failed to run (possibly incompatible field value in telemetry), consider the telemetry item filtered out by this conjunction group
                ////!!!
                ////errorList.Add(
                ////    CollectionConfigurationError.CreateError(
                ////        CollectionConfigurationErrorType.DocumentStreamFilterFailureToRun,
                ////        string.Format(CultureInfo.InvariantCulture, "Document stream filter failed to run"),
                ////        e));
            }

            return filterPassed;
        }

        private void CreateFilters(out CollectionConfigurationError[] errors)
        {
            var errorList = new List<CollectionConfigurationError>();
            if (info.DocumentFilterGroups != null)
            {
                foreach (DocumentFilterConjunctionGroupInfo documentFilterConjunctionGroupInfo in info.DocumentFilterGroups)
                {
                    try
                    {
                        CollectionConfigurationError[] groupErrors;
                        switch (documentFilterConjunctionGroupInfo.TelemetryType.ToString())
                        {
                            case TelemetryType.Request:
                                requestFilterGroups.Add(new FilterConjunctionGroup<Request>(documentFilterConjunctionGroupInfo.Filters, out groupErrors));
                                break;
                            case TelemetryType.Dependency:
                                dependencyFilterGroups.Add(new FilterConjunctionGroup<RemoteDependency>(documentFilterConjunctionGroupInfo.Filters, out groupErrors));
                                break;
                            case TelemetryType.Exception:
                                exceptionFilterGroups.Add(new FilterConjunctionGroup<ExceptionDocument>(documentFilterConjunctionGroupInfo.Filters, out groupErrors));
                                break;
                            case TelemetryType.Trace:
                                traceFilterGroups.Add(new FilterConjunctionGroup<Trace>(documentFilterConjunctionGroupInfo.Filters, out groupErrors));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "Unsupported TelemetryType: '{0}'", documentFilterConjunctionGroupInfo.TelemetryType));
                        }

                        errorList.AddRange(groupErrors);
                    }
                    catch (System.Exception e)
                    {
                        errorList.Add(
                            CollectionConfigurationError.CreateError(
                                CollectionConfigurationErrorType.DocumentStreamFailureToCreateFilterUnexpected,
                                string.Format(CultureInfo.InvariantCulture, "Failed to create a document stream filter {0}.", documentFilterConjunctionGroupInfo),
                                e,
                                Tuple.Create("DocumentStreamId", info.Id)));
                    }
                }
            }

            errors = errorList.ToArray();
        }
    }
}
