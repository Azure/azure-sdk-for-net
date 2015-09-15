//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Insights.Customizations.Shoebox;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// Thick client class for getting metrics
    /// </summary>
    internal partial class MetricOperations
    {
        public async Task<MetricListResponse> GetMetricsAsync(string resourceUri, string filterString, CancellationToken cancellationToken)
        {
            if (resourceUri == null)
            {
                throw new ArgumentNullException("resourceUri");
            }

            // Generate filter strings
            MetricFilter filter = MetricFilterExpressionParser.Parse(filterString);
            string filterStringNamesOnly = filter.DimensionFilters == null ? null
                : ShoeboxHelper.GenerateMetricDefinitionFilterString(filter.DimensionFilters.Select(df => df.Name));

            // Get definitions for requested metrics
            IList<MetricDefinition> definitions =
                (await this.Client.MetricDefinitionOperations.GetMetricDefinitionsAsync(
                    resourceUri,
                    filterStringNamesOnly,
                    cancellationToken).ConfigureAwait(false)).MetricDefinitionCollection.Value;

            // Get Metrics with definitions
            return await this.GetMetricsAsync(resourceUri, filterString, definitions, cancellationToken);
        }

        // Alternate method for getting metrics by passing in the definitions
        public async Task<MetricListResponse> GetMetricsAsync(
            string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions, CancellationToken cancellationToken)
        {
            if (definitions == null)
            {
                throw new ArgumentNullException("definitions");
            }

            if (resourceUri == null)
            {
                throw new ArgumentNullException("resourceUri");
            }

            // Remove any '/' characters from the start since these are handled by the hydra (thin) client
            // Don't encode Uri segments here since this will mess up the SAS retrievers (they use the resourceUri directly)
            resourceUri = resourceUri.TrimStart('/');

            MetricListResponse result;
            string invocationId = TracingAdapter.NextInvocationId.ToString(CultureInfo.InvariantCulture);

            // If no definitions provided, return empty collection
            if (!definitions.Any())
            {
                this.LogStartGetMetrics(invocationId, resourceUri, filterString, definitions);
                result = new MetricListResponse()
                {
                    RequestId = Guid.NewGuid().ToString("D"),
                    StatusCode = HttpStatusCode.OK,
                    MetricCollection = new MetricCollection()
                    {
                        Value = new Metric[0]
                    }
                };

                this.LogEndGetMetrics(invocationId, result);

                return result;
            }

            // Parse MetricFilter
            MetricFilter filter = MetricFilterExpressionParser.Parse(filterString);

            // Names in filter must match the names in the definitions
            if (filter.DimensionFilters != null && filter.DimensionFilters.Any())
            {
                IEnumerable<string> filterNames = filter.DimensionFilters.Select(df => df.Name);
                IEnumerable<string> definitionNames = definitions.Select(d => d.Name.Value);
                IEnumerable<string> filterOnly = filterNames.Where(fn => !definitionNames.Contains(fn, StringComparer.InvariantCultureIgnoreCase));
                IEnumerable<string> definitionOnly = definitionNames.Where(df => !filterNames.Contains(df, StringComparer.InvariantCultureIgnoreCase));

                if (filterOnly.Any() || definitionOnly.Any())
                {
                    throw new ArgumentException("Set of names specified in filter string must match set of names in provided definitions", "filterString");
                }

                // "Filter out" metrics with unsupported dimensions
                definitions = definitions.Where(d => SupportsRequestedDimensions(d, filter));
            }
            else
            {
                filter = new MetricFilter()
                {
                    TimeGrain = filter.TimeGrain,
                    StartTime = filter.StartTime,
                    EndTime = filter.EndTime,
                    DimensionFilters = definitions.Select(d => new MetricDimension()
                    {
                        Name = d.Name.Value
                    })
                };
            }

            // Parse out provider name and determine if provider is storage
            string providerName = this.GetProviderFromResourceId(resourceUri);
            bool isStorageProvider =
                string.Equals(providerName, "Microsoft.Storage", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(providerName, "Microsoft.ClassicStorage", StringComparison.OrdinalIgnoreCase);

            // Create supported MetricRetrievers
            IMetricRetriever proxyRetriever = new ProxyMetricRetriever(this);
            IMetricRetriever shoeboxRetriever = new ShoeboxMetricRetriever();
            IMetricRetriever storageRetriever = new StorageMetricRetriever();
            IMetricRetriever blobShoeboxMetricRetriever = new BlobShoeboxMetricRetriever();
            IMetricRetriever emptyRetriever = EmptyMetricRetriever.Instance;

            // Create the selector function here so it has access to the retrievers, filter, and providerName
            Func<MetricDefinition, IMetricRetriever> retrieverSelector = (d) =>
            {
                if (!d.MetricAvailabilities.Any())
                {
                    return emptyRetriever;
                }

                if (isStorageProvider)
                {
                    return storageRetriever;
                }

                if (IsBlobSasMetric(d, filter.TimeGrain))
                {
                    return blobShoeboxMetricRetriever;
                }

                if (IsTableSasMetric(d, filter.TimeGrain))
                {
                    return shoeboxRetriever;
                }

                return proxyRetriever;
            };

            // Group definitions by retriever so we can make one request to each retriever
            IEnumerable<IGrouping<IMetricRetriever, MetricDefinition>> groups = definitions.GroupBy(retrieverSelector);

            // Get Metrics from each retriever (group)
            IEnumerable<Task<MetricListResponse>> locationTasks = groups.Select(g =>
                g.Key.GetMetricsAsync(resourceUri, GetFilterStringForDefinitions(filter, g), g, invocationId));

            // Aggregate metrics from all groups
            this.LogStartGetMetrics(invocationId, resourceUri, filterString, definitions);
            MetricListResponse[] results = (await Task.Factory.ContinueWhenAll(locationTasks.ToArray(), tasks => tasks.Select(t => t.Result))).ToArray();
            IEnumerable<Metric> metrics = results.Aggregate<MetricListResponse, IEnumerable<Metric>>(
                new List<Metric>(), (list, response) => list.Union(response.MetricCollection.Value));

            this.LogMetricCountFromResponses(invocationId, metrics.Count());

            // Fill in values (resourceUri, displayName, unit) from definitions
            CompleteShoeboxMetrics(metrics, definitions, resourceUri);

            // Add empty objects for metrics that had no values come back, ensuring a metric is returned for each definition
            IEnumerable<Metric> emptyMetrics = (await emptyRetriever.GetMetricsAsync(
                resourceUri,
                filterString,
                definitions.Where(d => !metrics.Any(m => string.Equals(m.Name.Value, d.Name.Value, StringComparison.OrdinalIgnoreCase))),
                invocationId)).MetricCollection.Value;

            // Create response (merge and wrap metrics)
            result = new MetricListResponse()
            {
                RequestId = Guid.NewGuid().ToString("D"),
                StatusCode = HttpStatusCode.OK,
                MetricCollection = new MetricCollection()
                {
                    Value = metrics.Union(emptyMetrics).ToList()
                }
            };

            this.LogEndGetMetrics(invocationId, result);

            return result;
        }

        private string GetProviderFromResourceId(string resourceId)
        {
            // Find start index of provider name
            string knownStart = "/subscriptions/" + this.Client.Credentials.SubscriptionId + "/resourceGroups/";
            int endOfResourceGroup = resourceId.IndexOf('/', knownStart.Length);

            // skip /providers/
            // plus 1 to start index to skip first '/', plus 1 to result to skip last '/'
            int startOfProviderName = resourceId.IndexOf('/', endOfResourceGroup + 1) + 1;
            int endOfProviderName = resourceId.IndexOf('/', startOfProviderName);

            return resourceId.Substring(startOfProviderName, endOfProviderName - startOfProviderName);
        }

        private string GetFilterStringForDefinitions(MetricFilter filter, IEnumerable<MetricDefinition> definitions)
        {
            return ShoeboxHelper.GenerateMetricFilterString(new MetricFilter()
            {
                TimeGrain = filter.TimeGrain,
                StartTime = filter.StartTime,
                EndTime = filter.EndTime,
                DimensionFilters = filter.DimensionFilters.Where(df =>
                    definitions.Any(d => string.Equals(df.Name, d.Name.Value, StringComparison.OrdinalIgnoreCase)))
            });
        }

        private bool SupportsRequestedDimensions(MetricDefinition definition, MetricFilter filter)
        {
            MetricDimension metric = filter.DimensionFilters.FirstOrDefault(df => string.Equals(df.Name, definition.Name.Value, StringComparison.OrdinalIgnoreCase));
            var supportedDimensionNames = definition.Dimensions.Select(dim => dim.Name);
            var supportedDimensionValues = definition.Dimensions.ToDictionary(dim => dim.Name.Value, dim => dim.Values.Select(v => v.Value));

            // No dimensions specified for this metric
            if (metric == null || metric.Dimensions == null)
            {
                return true;
            }

            foreach (MetricFilterDimension dimension in metric.Dimensions)
            {
                // find dimension in definition
                Dimension d = definition.Dimensions.FirstOrDefault(dim => string.Equals(dim.Name.Value, dimension.Name));

                // Dimension name does't show up in definition
                if (d == null)
                {
                    return false;
                }

                // Requested dimension has any value that don't show up in the values list for the definiton
                if (dimension.Values.Any(value => !d.Values.Select(v => v.Value).Contains(value, StringComparer.OrdinalIgnoreCase)))
                {
                    return false;
                }
            }

            return true;
        }

        private void LogMetricCountFromResponses(string invocationId, int metricsCount)
        {
            if (TracingAdapter.IsEnabled)
            {
                TracingAdapter.Information("InvocationId: {0}. Total number of metrics in all resposes: {1}", invocationId, metricsCount);
            }
        }

        private void LogEndGetMetrics(string invocationId, MetricListResponse result)
        {
            if (TracingAdapter.IsEnabled)
            {
                TracingAdapter.Exit(invocationId, result);
            }
        }

        private void LogStartGetMetrics(string invocationId, string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions)
        {
            if (TracingAdapter.IsEnabled)
            {
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceUri", resourceUri);
                tracingParameters.Add("filterString", filterString);
                tracingParameters.Add("definitions", string.Concat(definitions.Select(d => d.Name)));

                TracingAdapter.Enter(invocationId, this, "GetMetricsAsync", tracingParameters);
            }
        }

        private static void CompleteShoeboxMetrics(IEnumerable<Metric> collection, IEnumerable<MetricDefinition> definitions, string resourceUri)
        {
            foreach (Metric metric in collection)
            {
                MetricDefinition definition = definitions.FirstOrDefault(md => string.Equals(md.Name.Value, metric.Name.Value, StringComparison.OrdinalIgnoreCase));

                metric.ResourceId = resourceUri;
                metric.Name.LocalizedValue = (definition != null && !string.IsNullOrEmpty(definition.Name.LocalizedValue))
                    ? definition.Name.LocalizedValue
                    : metric.Name.Value;
                metric.Unit = definition == null ? Unit.Count : definition.Unit;
            }
        }

        private static bool IsTableSasMetric(MetricDefinition definition, TimeSpan timeGrain)
        {
            MetricAvailability availability = definition.MetricAvailabilities.FirstOrDefault(a => a.TimeGrain.Equals(timeGrain));

            // Definition has requested availability, Location is null (non-SAS) or contains SAS key
            if (availability != null)
            {
                return availability.Location != null;
            }

            // Definition has availabilities, but none with the requested timegrain (Bad request)
            if (definition.MetricAvailabilities.Any())
            {
                throw new InvalidOperationException(string.Format(
                    CultureInfo.InvariantCulture,
                    "MetricDefinition for {0} does not contain an availability with timegrain {1}",
                    definition.Name.Value, timeGrain));
            }

            // Definition has no availablilities (metrics are not configured for this resource), return empty metrics (non-SAS)
            return false;
        }

        private static bool IsBlobSasMetric(MetricDefinition definition, TimeSpan timeGrain)
        {
            MetricAvailability availability = definition.MetricAvailabilities.FirstOrDefault(a => a.TimeGrain.Equals(timeGrain));

            // Definition has requested availability, Location is null (non-SAS) or contains SAS key
            if (availability != null)
            {
                return availability.BlobLocation != null;
            }

            // Definition has availabilities, but none with the requested timegrain (Bad request)
            if (definition.MetricAvailabilities.Any())
            {
                throw new InvalidOperationException(string.Format(
                    CultureInfo.InvariantCulture,
                    "MetricDefinition for {0} does not contain an availability with timegrain {1}",
                    definition.Name.Value, timeGrain));
            }

            // Definition has no availablilities (metrics are not configured for this resource), return empty metrics (non-SAS)
            return false;
        }
    }
}
