// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

    using ExceptionDocument = Azure.Monitor.OpenTelemetry.LiveMetrics.Models.Exception;

    /// <summary>
    /// Represents the collection configuration - a set of calculated metrics, and full telemetry documents to be collected by the SDK.
    /// </summary>
    /// <remarks>
    /// This class is a hub for all pieces of configurable collection configuration.
    /// Upon initialization
    ///   - it creates collection-time instances of <see cref="DerivedMetric&lt;T&gt;"/> and maintains them in separate collections by telemetry type.
    ///     These are used to filter and calculated calculated metrics configured by the service.
    ///   - it creates collection-time instances of DocumentStream which are used to filter and send out full telemetry documents. // TODO: Add DocumentStream back
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

        // private readonly List<DerivedMetric<EventTelemetry>> eventTelemetryMetrics = new List<DerivedMetric<EventTelemetry>>();

        // private readonly List<DerivedMetric<TraceTelemetry>> traceTelemetryMetrics = new List<DerivedMetric<TraceTelemetry>>();

        // TODO: Add back: private readonly List<DocumentStream> documentStreams = new List<DocumentStream>();
        #endregion

        #region Metadata used by other components
        private readonly List<Tuple<string, DerivedMetricInfoAggregation?>> telemetryMetadata = new List<Tuple<string, DerivedMetricInfoAggregation?>>();
        #endregion

        public CollectionConfiguration(
           CollectionConfigurationInfo info,
           out CollectionConfigurationError[] errors)
        {
            this.info = info ?? throw new ArgumentNullException(nameof(info));

            // create metrics based on descriptions in info
            this.CreateTelemetryMetrics(out CollectionConfigurationError[] metricErrors);

            // maintain a separate collection of all (Id, AggregationType) pairs with some additional data - to allow for uniform access to all types of metrics
            // this includes both telemetry metrics and Metric metrics
            this.CreateMetadata();

            //// create document streams based on description in info
            //this.CreateDocumentStreams(out CollectionConfigurationError[] documentStreamErrors, timeProvider, previousDocumentStreams ?? ArrayExtensions.Empty<DocumentStream>());

            //// create performance counters
            //this.CreatePerformanceCounters(out CollectionConfigurationError[] performanceCounterErrors);

            //errors = metricErrors.Concat(documentStreamErrors).Concat(performanceCounterErrors).ToArray();
            errors = metricErrors.ToArray();

            foreach (var error in errors)
            {
                UpdateMetricIdOfError(error, this.info.Etag);
            }
        }

        private void UpdateMetricIdOfError(CollectionConfigurationError error, string id)
        {
            for (int i = 0; i < error.Data.Count; i++)
            {
                if (error.Data[i].Key == "ETag")
                {
                    error.Data[i].Value = id;
                    return;
                }
            }
        }

        public IEnumerable<DerivedMetric<Request>> RequestMetrics => this.requestDocumentIngressMetrics;

        public IEnumerable<DerivedMetric<RemoteDependency>> DependencyMetrics => this.dependencyTelemetryMetrics;

        public IEnumerable<DerivedMetric<ExceptionDocument>> ExceptionMetrics => this.exceptionTelemetryMetrics;

        // public IEnumerable<CalculatedMetric<EventTelemetry>> EventMetrics => this.eventTelemetryMetrics;

        // public IEnumerable<CalculatedMetric<TraceTelemetry>> TraceMetrics => this.traceTelemetryMetrics;

        /// <summary>
        /// Gets Telemetry types only. Used by QuickPulseTelemetryProcessor.
        /// </summary>
        public IEnumerable<Tuple<string, DerivedMetricInfoAggregation?>> TelemetryMetadata => this.telemetryMetadata;

        ///// <summary>
        ///// Gets document streams. Telemetry items are provided by QuickPulseTelemetryProcessor.
        ///// </summary>
        //public IEnumerable<DocumentStream> DocumentStreams => this.documentStreams;

        public string ETag => this.info.Etag;

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

        // TODO: Add back the removed CreateDocumentStreams method.

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
                    //TODO: Add back:
                    //case TelemetryType.Event:
                    //    CollectionConfiguration.AddMetric(metricInfo, this.evenDocumentIngressMetrics, out localErrors);
                    //    break;
                    //case TelemetryType.Trace:
                    //    CollectionConfiguration.AddMetric(metricInfo, this.traceTelemetryMetrics, out localErrors);
                    //    break;
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
                .Concat(this.exceptionTelemetryMetrics.Select(metric => Tuple.Create(metric.Id, metric.AggregationType))))
            //TODO: Add back:
            //.Concat(this.evenDocumentIngressMetrics.Select(metric => Tuple.Create(metric.Id, metric.AggregationType)))
            //.Concat(this.traceTelemetryMetrics.Select(metric => Tuple.Create(metric.Id, metric.AggregationType)))
            {
                this.telemetryMetadata.Add(metricIds);
            }
        }
    }
}
