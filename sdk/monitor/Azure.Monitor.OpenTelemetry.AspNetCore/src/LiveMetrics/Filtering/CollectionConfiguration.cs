﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Azure.Monitor.OpenTelemetry.Exporter.Internals;
    using Azure.Monitor.OpenTelemetry.AspNetCore.Models;

    using ExceptionDocument = Models.Exception;

    /// <summary>
    /// Represents the collection configuration - a set of calculated metrics, and full telemetry documents to be collected by the SDK.
    /// </summary>
    /// <remarks>
    /// This class is a hub for all pieces of configurable collection configuration.
    /// Upon initialization
    ///   - it creates collection-time instances of <see cref="DerivedMetric&lt;T&gt;"/> and maintains them in separate collections by telemetry type.
    ///     These are used to filter and calculated calculated metrics configured by the service.
    ///   - it creates certain metadata collections which are used by other collection-time components to learn more about what is being collected at any given time.
    /// </remarks>
    internal class CollectionConfiguration
    {
        private readonly CollectionConfigurationInfo info;

        #region Collection-time instances used to filter and calculate data on telemetry passing through the pipeline
        private readonly List<DerivedMetric<Request>> requestDocumentIngressMetrics = new List<DerivedMetric<Request>>();

        private readonly List<DerivedMetric<RemoteDependency>> dependencyTelemetryMetrics =
            new List<DerivedMetric<RemoteDependency>>();

        private readonly List<DerivedMetric<ExceptionDocument>> exceptionTelemetryMetrics =
            new List<DerivedMetric<ExceptionDocument>>();

        private readonly List<DerivedMetric<Trace>> traceTelemetryMetrics = new List<DerivedMetric<Trace>>();

        private readonly List<DocumentStream> documentStreams = new List<DocumentStream>();
        #endregion

        #region Metadata used by other components
        private readonly List<Tuple<string, Models.AggregationType?>> telemetryMetadata = new List<Tuple<string, Models.AggregationType?>>();
        #endregion

        public CollectionConfiguration(
           CollectionConfigurationInfo info,
           out CollectionConfigurationError[] errors,
           IEnumerable<DocumentStream>? previousDocumentStreams = null)
        {
            this.info = info ?? throw new ArgumentNullException(nameof(info));

            // create metrics based on descriptions in info
            this.CreateTelemetryMetrics(out CollectionConfigurationError[] metricErrors);

            // maintain a separate collection of all (Id, AggregationType) pairs with some additional data - to allow for uniform access to all types of metrics
            // this includes both telemetry metrics and Metric metrics
            this.CreateMetadata();

            // create document streams based on description in info
            this.CreateDocumentStreams(previousDocumentStreams ?? Array.Empty<DocumentStream>(), out CollectionConfigurationError[] documentStreamErrors);

            errors = metricErrors.Concat(documentStreamErrors).ToArray();

            UpdateAllErrorsWithKeyValue(errors, "ETag", this.info.ETag);
        }

        private void UpdateAllErrorsWithKeyValue(CollectionConfigurationError[] errors, string key, string value)
        {
            for (int i = 0; i < errors.Length; i++)
            {
                var newError = UpdateOrCreateError(errors[i], key, value);
                if (newError != null)
                {
                    errors[i] = newError;
                }
            }
        }

        private CollectionConfigurationError? UpdateOrCreateError(CollectionConfigurationError error, string key, string value)
        {
            for (int i = 0; i < error.Data.Count; i++)
            {
                if (error.Data[i].Key == key)
                {
                    error.Data[i] = new KeyValuePairString(error.Data[i].Key, value);

                    // TODO: MODEL CHANGED TO READONLY. I'M INVESTIGATING IF WE CAN REVERT THIS CHANGE. (2024-03-22)
                    //error.Data[i].Value = value;

                    return null;
                }
            }
            var newData = new List<KeyValuePairString>(error.Data)
            {
                new KeyValuePairString(key, value)
            };
            return new CollectionConfigurationError(error.CollectionConfigurationErrorType, error.Message, error.FullException, newData);
        }

        public IEnumerable<DerivedMetric<Request>> RequestMetrics => this.requestDocumentIngressMetrics;

        public IEnumerable<DerivedMetric<RemoteDependency>> DependencyMetrics => this.dependencyTelemetryMetrics;

        public IEnumerable<DerivedMetric<ExceptionDocument>> ExceptionMetrics => this.exceptionTelemetryMetrics;

        public IEnumerable<DerivedMetric<Trace>> TraceMetrics => this.traceTelemetryMetrics;

        /// <summary>
        /// Gets Telemetry types only. Used by QuickPulseTelemetryProcessor.
        /// </summary>
        public IEnumerable<Tuple<string, Models.AggregationType?>> TelemetryMetadata => this.telemetryMetadata;

        /// <summary>
        /// Gets document streams. Telemetry items are provided by QuickPulseTelemetryProcessor.
        /// </summary>
        public IEnumerable<DocumentStream> DocumentStreams => this.documentStreams;

        public string ETag => this.info.ETag;

        private static void AddMetric<DocumentIngress>(
          DerivedMetricInfo metricInfo,
          List<DerivedMetric<DocumentIngress>> metrics,
          out CollectionConfigurationError[] errors)
        {
            errors = Array.Empty<CollectionConfigurationError>();

            try
            {
                metrics.Add(new DerivedMetric<DocumentIngress>(metricInfo, out errors));
            }
            catch (System.Exception e)
            {
                // error creating the metric
                errors =
                    errors.Concat(
                        new[]
                        {
                            CollectionConfigurationError.CreateError(
                                CollectionConfigurationErrorType.MetricFailureToCreate,
                                string.Format(CultureInfo.InvariantCulture, "Failed to create metric {0}.", metricInfo),
                                e,
                                Tuple.Create("MetricId", metricInfo.Id)),
                        }).ToArray();
            }
        }

        private void CreateDocumentStreams(IEnumerable<DocumentStream> previousDocumentStreams,
            out CollectionConfigurationError[] errors)
        {
            var errorList = new List<CollectionConfigurationError>();
            var documentStreamIds = new HashSet<string>();

            // quota might be changing concurrently on the collection thread, but we don't need the exact value at any given time
            // we will try to carry over the last known values to this new configuration
            Dictionary<string, Tuple<float, float, float, float, float>> previousQuotasByStreamId =
                previousDocumentStreams.ToDictionary(
                    documentStream => documentStream.Id,
                    documentStream =>
                    Tuple.Create(
                        documentStream.RequestQuotaTracker.CurrentQuota,
                        documentStream.DependencyQuotaTracker.CurrentQuota,
                        documentStream.ExceptionQuotaTracker.CurrentQuota,
                        documentStream.EventQuotaTracker.CurrentQuota,
                        documentStream.TraceQuotaTracker.CurrentQuota));

            if (this.info.DocumentStreams != null)
            {
                float? maxQuota = this.info.QuotaInfo?.MaxQuota;
                float? quotaAccrualRatePerSec = this.info.QuotaInfo?.QuotaAccrualRatePerSec;

                foreach (DocumentStreamInfo documentStreamInfo in this.info.DocumentStreams)
                {
                    if (documentStreamIds.Contains(documentStreamInfo.Id))
                    {
                        // there must not be streams with duplicate ids
                        errorList.Add(
                            CollectionConfigurationError.CreateError(
                                CollectionConfigurationErrorType.DocumentStreamDuplicateIds,
                                string.Format(CultureInfo.InvariantCulture, "Document stream with a duplicate id ignored: {0}", documentStreamInfo.Id),
                                null,
                                Tuple.Create("DocumentStreamId", documentStreamInfo.Id)));

                        continue;
                    }

                    CollectionConfigurationError[]? localErrors = null;
                    try
                    {
                        previousQuotasByStreamId.TryGetValue(documentStreamInfo.Id, out Tuple<float, float, float, float, float>? previousQuotas);
                        float? initialQuota = this.info.QuotaInfo?.InitialQuota;

                        var documentStream = new DocumentStream(
                            documentStreamInfo,
                            out localErrors,
                            initialRequestQuota: initialQuota ?? previousQuotas?.Item1,
                            initialDependencyQuota: initialQuota ?? previousQuotas?.Item2,
                            initialExceptionQuota: initialQuota ?? previousQuotas?.Item3,
                            initialEventQuota: initialQuota ?? previousQuotas?.Item4,
                            initialTraceQuota: initialQuota ?? previousQuotas?.Item5,
                            maxRequestQuota: maxQuota,
                            maxDependencyQuota: maxQuota,
                            maxExceptionQuota: maxQuota,
                            maxEventQuota: maxQuota,
                            maxTraceQuota: maxQuota,
                            quotaAccrualRatePerSec: quotaAccrualRatePerSec);

                        documentStreamIds.Add(documentStreamInfo.Id);
                        this.documentStreams.Add(documentStream);
                    }
                    catch (System.Exception e)
                    {
                        errorList.Add(
                            CollectionConfigurationError.CreateError(
                                CollectionConfigurationErrorType.DocumentStreamFailureToCreate,
                                string.Format(CultureInfo.InvariantCulture, "Failed to create document stream {0}", documentStreamInfo),
                                e,
                                Tuple.Create("DocumentStreamId", documentStreamInfo.Id)));
                    }

                    if (localErrors != null)
                    {
                        UpdateAllErrorsWithKeyValue(localErrors, "DocumentStreamId", documentStreamInfo.Id);

                        errorList.AddRange(localErrors);
                    }
                }
            }

            errors = errorList.ToArray();
        }

        private void CreateTelemetryMetrics(out CollectionConfigurationError[] errors)
        {
            var errorList = new List<CollectionConfigurationError>();
            var metricIds = new HashSet<string>();

            foreach (DerivedMetricInfo metricInfo in info.Metrics)
            {
                if (metricIds.Contains(metricInfo.Id))
                {
                    // there must not be metrics with duplicate ids
                    errorList.Add(
                        CollectionConfigurationError.CreateError(
                            CollectionConfigurationErrorType.MetricDuplicateIds,
                            string.Format(CultureInfo.InvariantCulture, "Metric with a duplicate id ignored: {0}", metricInfo.Id),
                            null,
                            Tuple.Create("MetricId", metricInfo.Id)));

                    continue;
                }

                CollectionConfigurationError[] localErrors = Array.Empty<CollectionConfigurationError>();
                switch (metricInfo.TelemetryType)
                {
                    case TelemetryType.Request:
                        CollectionConfiguration.AddMetric(metricInfo, this.requestDocumentIngressMetrics, out localErrors);
                        break;
                    case TelemetryType.Dependency:
                        CollectionConfiguration.AddMetric(metricInfo, this.dependencyTelemetryMetrics, out localErrors);
                        break;
                    case TelemetryType.Exception:
                        CollectionConfiguration.AddMetric(metricInfo, this.exceptionTelemetryMetrics, out localErrors);
                        break;
                    case TelemetryType.Trace:
                        CollectionConfiguration.AddMetric(metricInfo, this.traceTelemetryMetrics, out localErrors);
                        break;
                    default:
                        errorList.Add(
                            CollectionConfigurationError.CreateError(
                                CollectionConfigurationErrorType.MetricTelemetryTypeUnsupported,
                                string.Format(CultureInfo.InvariantCulture, "TelemetryType is not supported: {0}", metricInfo.TelemetryType),
                                null,
                                Tuple.Create("MetricId", metricInfo.Id),
                                Tuple.Create("TelemetryType", metricInfo.TelemetryType.ToString())));
                        break;
                }

                if (localErrors != null)
                {
                    errorList.AddRange(localErrors);
                }

                metricIds.Add(metricInfo.Id);
            }

            errors = errorList.ToArray();
        }

        private void CreateMetadata()
        {
            foreach (var metricIds in
                this.requestDocumentIngressMetrics.Select(metric => Tuple.Create(metric.Id, metric.AggregationType))
                .Concat(this.dependencyTelemetryMetrics.Select(metric => Tuple.Create(metric.Id, metric.AggregationType)))
                .Concat(this.exceptionTelemetryMetrics.Select(metric => Tuple.Create(metric.Id, metric.AggregationType)))
                .Concat(this.traceTelemetryMetrics.Select(metric => Tuple.Create(metric.Id, metric.AggregationType))))
            {
                this.telemetryMetadata.Add(metricIds);
            }
        }
    }
}
